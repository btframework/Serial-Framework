using System;
using System.Runtime.InteropServices;
using System.Text;
using wclCommon;

class Program
{
    const string LibObjC = "/usr/lib/libobjc.dylib";
    const string LibSystem = "/usr/lib/libSystem.dylib";

    [StructLayout(LayoutKind.Sequential)]
    struct NSRect
    {
        public double x;
        public double y;
        public double width;
        public double height;

        public NSRect(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

    // Delegate for applicationShouldTerminateAfterLastWindowClosed:
    // Objective-C BOOL is a signed char, but we use byte (unsigned char) with I1 marshalling.
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate byte ApplicationShouldTerminateIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    static IntPtr nsStringClass;
    static IntPtr targetClass;
    static IntPtr target;
    static ApplicationShouldTerminateIMP shouldTerminateDelegate;
    static IntPtr window;
    static IntPtr label;

    static void Main()
    {
        // Load AppKit framework
        const int RTLD_LAZY = 1;
        IntPtr appKit = dlopen("/System/Library/Frameworks/AppKit.framework/AppKit", RTLD_LAZY);
        if (appKit == IntPtr.Zero)
            throw new InvalidOperationException("Failed to load AppKit");

        // Get Objective-C classes
        IntPtr nsAppClass = objc_getClass("NSApplication");
        IntPtr nsWindowClass = objc_getClass("NSWindow");
        IntPtr nsTextFieldClass = objc_getClass("NSTextField");
        IntPtr nsFontClass = objc_getClass("NSFont");
        IntPtr nsScreenClass = objc_getClass("NSScreen");
        nsStringClass = objc_getClass("NSString");

        // Autorelease pool
        IntPtr autoreleasePoolClass = objc_getClass("NSAutoreleasePool");
        IntPtr autoreleasePool = objc_msgSend_IntPtr(autoreleasePoolClass, sel_registerName("new"));

        // Shared application
        IntPtr sharedApp = objc_msgSend_IntPtr(nsAppClass, sel_registerName("sharedApplication"));
        objc_msgSend_void_long(sharedApp, sel_registerName("setActivationPolicy:"), 0); // Regular

        // Get screen visible frame for centering
        IntPtr mainScreen = objc_msgSend_IntPtr(nsScreenClass, sel_registerName("mainScreen"));
        NSRect visibleFrame = objc_msgSend_NSRect(mainScreen, sel_registerName("visibleFrame"));

        double windowWidth = 291;
        double windowHeight = 59;
        double originX = visibleFrame.x + (visibleFrame.width - windowWidth) / 2;
        double originY = visibleFrame.y + (visibleFrame.height - windowHeight) / 2;
        NSRect windowRect = new NSRect(originX, originY, windowWidth, windowHeight);

        // Create window (styleMask: titled | closable | miniaturizable = 7)
        IntPtr windowAlloc = objc_msgSend_IntPtr(nsWindowClass, sel_registerName("alloc"));
        window = objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(
            windowAlloc,
            sel_registerName("initWithContentRect:styleMask:backing:defer:"),
            windowRect,
            7,      // styleMask: titled | closable | miniaturizable
            2,      // backing: buffered
            0);     // defer: NO

        // Window title
        IntPtr windowTitle = ToNSString("OS version test");
        objc_msgSend_void_IntPtr(window, sel_registerName("setTitle:"), windowTitle);

        // Get content view
        IntPtr contentView = objc_msgSend_IntPtr(window, sel_registerName("contentView"));

        // ---- Create label ----
        IntPtr labelAlloc = objc_msgSend_IntPtr(nsTextFieldClass, sel_registerName("alloc"));
        NSRect labelRect = new NSRect(8, 16, 275, 21);
        label = objc_msgSend_IntPtr_NSRect(labelAlloc, sel_registerName("initWithFrame:"), labelRect);
        objc_msgSend_void_byte(label, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(label, sel_registerName("setBordered:"), 0);
        objc_msgSend_void_byte(label, sel_registerName("setBezeled:"), 0);
        objc_msgSend_void_IntPtr(label, sel_registerName("setBackgroundColor:"), IntPtr.Zero); // transparent

        // Set bold font, size 16 (like Lazarus Font.Height = -16, Font.Style = [fsBold])
        IntPtr boldFont = objc_msgSend_IntPtr_Double(nsFontClass, sel_registerName("boldSystemFontOfSize:"), 16.0);
        if (boldFont != IntPtr.Zero)
        {
            objc_msgSend_void_IntPtr(label, sel_registerName("setFont:"), boldFont);
        }

        // Compute OS version string (similar to Pascal FormCreate)
        string osName;
        switch (wclOsVersion.OsType)
        {
            case wclOsType.osUnknown: osName = "OS unknown"; break;
            case wclOsType.osMacOS: osName = "Mac OS"; break;
            case wclOsType.osWinXP: osName = "Windows XP"; break;
            case wclOsType.osWinVista: osName = "Windows Vista"; break;
            case wclOsType.osWin7: osName = "Windows 7"; break;
            case wclOsType.osWin8: osName = "Windows 8"; break;
            case wclOsType.osWin81: osName = "Windows 8.1"; break;
            case wclOsType.osWin10: osName = "Windows 10"; break;
            case wclOsType.osWin11: osName = "Windows 11"; break;
            default: osName = "Undefined OS"; break;
        }

        string versionText = $"{osName} {wclOsVersion.Major}.{wclOsVersion.Minor}.{wclOsVersion.Build}";
        IntPtr labelString = ToNSString(versionText);
        objc_msgSend_void_IntPtr(label, sel_registerName("setStringValue:"), labelString);

        // Add label to content view
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), label);

        // ---- Set up app delegate for termination ----
        targetClass = objc_getClass("AppDelegate");
        if (targetClass == IntPtr.Zero)
        {
            IntPtr superclass = objc_getClass("NSObject");
            targetClass = objc_allocateClassPair(superclass, "AppDelegate", IntPtr.Zero);

            shouldTerminateDelegate = new ApplicationShouldTerminateIMP(ShouldTerminateAfterLastWindowClosed);
            IntPtr shouldTerminateImp = Marshal.GetFunctionPointerForDelegate(shouldTerminateDelegate);
            if (class_addMethod(targetClass, sel_registerName("applicationShouldTerminateAfterLastWindowClosed:"), shouldTerminateImp, "B@:@") == 0)
                throw new InvalidOperationException("Failed to add applicationShouldTerminateAfterLastWindowClosed: method");

            objc_registerClassPair(targetClass);
        }

        target = objc_msgSend_IntPtr(targetClass, sel_registerName("new"));
        objc_msgSend_void_IntPtr(sharedApp, sel_registerName("setDelegate:"), target);

        // Show window and activate
        objc_msgSend_void_IntPtr(window, sel_registerName("makeKeyAndOrderFront:"), IntPtr.Zero);
        objc_msgSend_void_byte(sharedApp, sel_registerName("activateIgnoringOtherApps:"), 1);

        // Run event loop
        objc_msgSend_void(sharedApp, sel_registerName("run"));

        // Drain pool
        objc_msgSend_void(autoreleasePool, sel_registerName("drain"));
    }

    static byte ShouldTerminateAfterLastWindowClosed(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        return 1; // YES
    }

    static IntPtr ToNSString(string s)
    {
        byte[] utf8 = Encoding.UTF8.GetBytes(s);
        IntPtr buf = Marshal.AllocHGlobal(utf8.Length + 1);
        Marshal.Copy(utf8, 0, buf, utf8.Length);
        Marshal.WriteByte(buf, utf8.Length, 0);

        IntPtr nsString = objc_msgSend_IntPtr_IntPtr(
            nsStringClass,
            sel_registerName("stringWithUTF8String:"),
            buf);

        Marshal.FreeHGlobal(buf);
        return nsString;
    }

    // ---- Native library imports ----

    [DllImport(LibSystem, EntryPoint = "dlopen")]
    static extern IntPtr dlopen(string path, int mode);

    [DllImport(LibObjC, EntryPoint = "objc_getClass")]
    static extern IntPtr objc_getClass(string name);

    [DllImport(LibObjC, EntryPoint = "sel_registerName")]
    static extern IntPtr sel_registerName(string name);

    [DllImport(LibObjC, EntryPoint = "objc_allocateClassPair")]
    static extern IntPtr objc_allocateClassPair(IntPtr superclass, string name, IntPtr extraBytes);

    [DllImport(LibObjC, EntryPoint = "objc_registerClassPair")]
    static extern void objc_registerClassPair(IntPtr cls);

    [DllImport(LibObjC, EntryPoint = "class_addMethod")]
    static extern byte class_addMethod(IntPtr cls, IntPtr name, IntPtr imp, string types);

    // objc_msgSend overloads
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern void objc_msgSend_void(IntPtr receiver, IntPtr selector);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern long objc_msgSend_long(IntPtr receiver, IntPtr selector);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern void objc_msgSend_void_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern void objc_msgSend_void_long(IntPtr receiver, IntPtr selector, long arg1);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern void objc_msgSend_void_byte(IntPtr receiver, IntPtr selector, byte arg1);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_NSRect(IntPtr receiver, IntPtr selector, NSRect arg1);

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(
        IntPtr receiver,
        IntPtr selector,
        NSRect arg1,
        ulong arg2,
        ulong arg3,
        byte arg4);

    // Returning NSRect (for NSScreen.visibleFrame)
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern NSRect objc_msgSend_NSRect(IntPtr receiver, IntPtr selector);

    // New overload for boldSystemFontOfSize: (returns NSFont)
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_Double(IntPtr receiver, IntPtr selector, double arg1);
}