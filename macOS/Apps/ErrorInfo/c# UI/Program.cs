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

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ButtonClickIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    delegate bool ApplicationShouldTerminateIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    static IntPtr nsStringClass;
    static IntPtr targetClass;
    static IntPtr target;
    static ButtonClickIMP clickDelegate;
    static ApplicationShouldTerminateIMP shouldTerminateDelegate;
    static IntPtr window;
    static IntPtr pathField;
    static IntPtr errorCodeField;
    static IntPtr outputTextView;

    const string DefaultPath = "errors8.xml"; // matches the Lazarus form default
    const string DefaultErrorCode = "$00000000";

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
        IntPtr nsButtonClass = objc_getClass("NSButton");
        IntPtr nsTextFieldClass = objc_getClass("NSTextField");
        IntPtr nsScrollViewClass = objc_getClass("NSScrollView");
        IntPtr nsTextViewClass = objc_getClass("NSTextView");
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

        // Window content size matches Lazarus form: 531x389
        double windowWidth = 531;
        double windowHeight = 389;
        double originX = visibleFrame.x + (visibleFrame.width - windowWidth) / 2;
        double originY = visibleFrame.y + (visibleFrame.height - windowHeight) / 2;
        NSRect windowRect = new NSRect(originX, originY, windowWidth, windowHeight);

        // Create window with styleMask: titled (1) + closable (2) + miniaturizable (4) = 7 (non-resizable)
        IntPtr windowAlloc = objc_msgSend_IntPtr(nsWindowClass, sel_registerName("alloc"));
        window = objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(
            windowAlloc,
            sel_registerName("initWithContentRect:styleMask:backing:defer:"),
            windowRect,
            7,      // styleMask: titled | closable | miniaturizable
            2,      // backing: buffered
            0);     // defer: NO

        // Window title
        IntPtr windowTitle = ToNSString("Error Information");
        objc_msgSend_void_IntPtr(window, sel_registerName("setTitle:"), windowTitle);

        // Get content view
        IntPtr contentView = objc_msgSend_IntPtr(window, sel_registerName("contentView"));

        // ---- Create "Errors definition file path" label ----
        IntPtr pathLabelAlloc = objc_msgSend_IntPtr(nsTextFieldClass, sel_registerName("alloc"));
        NSRect pathLabelRect = new NSRect(8, 350, 133, 15);
        IntPtr pathLabel = objc_msgSend_IntPtr_NSRect(pathLabelAlloc, sel_registerName("initWithFrame:"), pathLabelRect);
        IntPtr pathLabelText = ToNSString("Errors definition file path");
        objc_msgSend_void_IntPtr(pathLabel, sel_registerName("setStringValue:"), pathLabelText);
        objc_msgSend_void_byte(pathLabel, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(pathLabel, sel_registerName("setBordered:"), 0);
        objc_msgSend_void_byte(pathLabel, sel_registerName("setBezeled:"), 0);
        objc_msgSend_void_IntPtr(pathLabel, sel_registerName("setBackgroundColor:"), IntPtr.Zero); // transparent
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), pathLabel);

        // ---- Create path edit field ----
        IntPtr pathFieldAlloc = objc_msgSend_IntPtr(nsTextFieldClass, sel_registerName("alloc"));
        NSRect pathFieldRect = new NSRect(152, 346, 369, 23);
        pathField = objc_msgSend_IntPtr_NSRect(pathFieldAlloc, sel_registerName("initWithFrame:"), pathFieldRect);
        IntPtr pathDefault = ToNSString(DefaultPath);
        objc_msgSend_void_IntPtr(pathField, sel_registerName("setStringValue:"), pathDefault);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), pathField);

        // ---- Create "Error code..." label ----
        IntPtr errorLabelAlloc = objc_msgSend_IntPtr(nsTextFieldClass, sel_registerName("alloc"));
        NSRect errorLabelRect = new NSRect(8, 310, 274, 15);
        IntPtr errorLabel = objc_msgSend_IntPtr_NSRect(errorLabelAlloc, sel_registerName("initWithFrame:"), errorLabelRect);
        IntPtr errorLabelText = ToNSString("Error code. Start with $ or 0x for hexadecimal value");
        objc_msgSend_void_IntPtr(errorLabel, sel_registerName("setStringValue:"), errorLabelText);
        objc_msgSend_void_byte(errorLabel, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(errorLabel, sel_registerName("setBordered:"), 0);
        objc_msgSend_void_byte(errorLabel, sel_registerName("setBezeled:"), 0);
        objc_msgSend_void_IntPtr(errorLabel, sel_registerName("setBackgroundColor:"), IntPtr.Zero); // transparent
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), errorLabel);

        // ---- Create error code field ----
        IntPtr errorFieldAlloc = objc_msgSend_IntPtr(nsTextFieldClass, sel_registerName("alloc"));
        NSRect errorFieldRect = new NSRect(296, 306, 121, 23);
        errorCodeField = objc_msgSend_IntPtr_NSRect(errorFieldAlloc, sel_registerName("initWithFrame:"), errorFieldRect);
        IntPtr errorDefault = ToNSString(DefaultErrorCode);
        objc_msgSend_void_IntPtr(errorCodeField, sel_registerName("setStringValue:"), errorDefault);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), errorCodeField);

        // ---- Create "Get details" button ----
        IntPtr buttonAlloc = objc_msgSend_IntPtr(nsButtonClass, sel_registerName("alloc"));
        NSRect buttonRect = new NSRect(446, 303, 75, 25);
        IntPtr button = objc_msgSend_IntPtr_NSRect(buttonAlloc, sel_registerName("initWithFrame:"), buttonRect);
        IntPtr buttonTitle = ToNSString("Get details");
        objc_msgSend_void_IntPtr(button, sel_registerName("setTitle:"), buttonTitle);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), button);

        // ---- Create scrollable text view (as listbox) ----
        IntPtr scrollViewAlloc = objc_msgSend_IntPtr(nsScrollViewClass, sel_registerName("alloc"));
        NSRect scrollRect = new NSRect(8, 8, 513, 281);
        IntPtr scrollView = objc_msgSend_IntPtr_NSRect(scrollViewAlloc, sel_registerName("initWithFrame:"), scrollRect);
        objc_msgSend_void_byte(scrollView, sel_registerName("setHasVerticalScroller:"), 1);
        objc_msgSend_void_byte(scrollView, sel_registerName("setHasHorizontalScroller:"), 0);

        IntPtr textViewAlloc = objc_msgSend_IntPtr(nsTextViewClass, sel_registerName("alloc"));
        NSRect textRect = new NSRect(0, 0, 513, 281);
        outputTextView = objc_msgSend_IntPtr_NSRect(textViewAlloc, sel_registerName("initWithFrame:"), textRect);
        objc_msgSend_void_byte(outputTextView, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(outputTextView, sel_registerName("setSelectable:"), 1);
        objc_msgSend_void_IntPtr(scrollView, sel_registerName("setDocumentView:"), outputTextView);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), scrollView);

        // ---- Set up custom target class ----
        targetClass = objc_getClass("AppDelegate");
        if (targetClass == IntPtr.Zero)
        {
            IntPtr superclass = objc_getClass("NSObject");
            targetClass = objc_allocateClassPair(superclass, "AppDelegate", IntPtr.Zero);

            clickDelegate = new ButtonClickIMP(OnGetDetailsClicked);
            IntPtr clickImp = Marshal.GetFunctionPointerForDelegate(clickDelegate);
            if (class_addMethod(targetClass, sel_registerName("getDetailsClicked:"), clickImp, "v@:@") == 0)
                throw new InvalidOperationException("Failed to add getDetailsClicked: method");

            shouldTerminateDelegate = new ApplicationShouldTerminateIMP(ShouldTerminateAfterLastWindowClosed);
            IntPtr shouldTerminateImp = Marshal.GetFunctionPointerForDelegate(shouldTerminateDelegate);
            if (class_addMethod(targetClass, sel_registerName("applicationShouldTerminateAfterLastWindowClosed:"), shouldTerminateImp, "B@:@") == 0)
                throw new InvalidOperationException("Failed to add applicationShouldTerminateAfterLastWindowClosed: method");

            objc_registerClassPair(targetClass);
        }

        target = objc_msgSend_IntPtr(targetClass, sel_registerName("new"));

        // Set button target/action
        objc_msgSend_void_IntPtr(button, sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(button, sel_registerName("setAction:"), sel_registerName("getDetailsClicked:"));

        // Set app delegate
        objc_msgSend_void_IntPtr(sharedApp, sel_registerName("setDelegate:"), target);

        // Show window and activate
        objc_msgSend_void_IntPtr(window, sel_registerName("makeKeyAndOrderFront:"), IntPtr.Zero);
        objc_msgSend_void_byte(sharedApp, sel_registerName("activateIgnoringOtherApps:"), 1);

        // Run event loop
        objc_msgSend_void(sharedApp, sel_registerName("run"));

        // Drain pool
        objc_msgSend_void(autoreleasePool, sel_registerName("drain"));
    }

    static void OnGetDetailsClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        // Get path
        IntPtr pathStringPtr = objc_msgSend_IntPtr(pathField, sel_registerName("stringValue"));
        string path = FromNSString(pathStringPtr);

        // Get error code string
        IntPtr errorStringPtr = objc_msgSend_IntPtr(errorCodeField, sel_registerName("stringValue"));
        string errorInput = FromNSString(errorStringPtr);

        if (string.IsNullOrWhiteSpace(errorInput))
        {
            ShowAlert("Error", "Enter error code.");
            return;
        }

        int errorCode;
        try
        {
            int numberBase = 10;
            if (errorInput.StartsWith("0x") || errorInput.StartsWith("$"))
            {
                numberBase = 16;
                if (errorInput.StartsWith("$"))
                    errorInput = errorInput.Replace("$", "0x");
            }
            errorCode = Convert.ToInt32(errorInput, numberBase);
        }
        catch (Exception ex)
        {
            ShowAlert("Error", $"Error parsing error code: {ex.Message}");
            return;
        }

        // Query error info
        wclErrorInformation info = new wclErrorInformation();
        if (!info.Open(path))
        {
            ShowAlert("Error", "Open errors definition file failed");
            return;
        }

        try
        {
            wclErrorDetails details = new wclErrorDetails();
            if (!info.GetDetails(errorCode, ref details))
            {
                ShowAlert("Error", "Unable to get error details");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error code: 0x{details.Error:X8}");
            sb.AppendLine($"Framework: {details.Framework}");
            sb.AppendLine($"Category: {details.Category}");
            sb.AppendLine($"Constant name: {details.Constant}");
            sb.AppendLine(details.Description);

            SetOutputText(sb.ToString());
        }
        finally
        {
            info.Close();
        }
    }

    static void SetOutputText(string text)
    {
        IntPtr nsString = ToNSString(text);
        objc_msgSend_void_IntPtr(outputTextView, sel_registerName("setString:"), nsString);
    }

    static void ShowAlert(string title, string message)
    {
        IntPtr nsAlertClass = objc_getClass("NSAlert");
        IntPtr alertAlloc = objc_msgSend_IntPtr(nsAlertClass, sel_registerName("alloc"));
        IntPtr alert = objc_msgSend_IntPtr(alertAlloc, sel_registerName("init"));

        IntPtr titleNs = ToNSString(title);
        objc_msgSend_void_IntPtr(alert, sel_registerName("setMessageText:"), titleNs);

        IntPtr messageNs = ToNSString(message);
        objc_msgSend_void_IntPtr(alert, sel_registerName("setInformativeText:"), messageNs);

        objc_msgSend_long(alert, sel_registerName("runModal"));
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

    static string FromNSString(IntPtr nsString)
    {
        if (nsString == IntPtr.Zero)
            return string.Empty;

        IntPtr utf8Ptr = objc_msgSend_IntPtr(nsString, sel_registerName("UTF8String"));
        if (utf8Ptr == IntPtr.Zero)
            return string.Empty;

        return Marshal.PtrToStringUTF8(utf8Ptr);
    }

    static bool ShouldTerminateAfterLastWindowClosed(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        return true;
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
}