using System;
using System.Collections.Concurrent;
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

    // Delegates for Objective-C methods
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ButtonClickIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate byte ApplicationShouldTerminateIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void TimerCallbackIMP(IntPtr self, IntPtr cmd, IntPtr timer);

    static IntPtr nsStringClass;
    static IntPtr targetClass;
    static IntPtr target;
    static ButtonClickIMP openDelegate;
    static ButtonClickIMP closeDelegate;
    static ButtonClickIMP getStateDelegate;
    static ApplicationShouldTerminateIMP shouldTerminateDelegate;
    static TimerCallbackIMP timerDelegate;
    static IntPtr window;
    static IntPtr outputTextView;
    static IntPtr timer;

    static wclPowerEventsMonitor monitor;
    static ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
    static StringBuilder logText = new StringBuilder();

    const string LogEmpty = "";

    static void Main()
    {
        // Load AppKit
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
        IntPtr nsTimerClass = objc_getClass("NSTimer");
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
        double windowWidth = 436;
        double windowHeight = 335;
        double originX = visibleFrame.x + (visibleFrame.width - windowWidth) / 2;
        double originY = visibleFrame.y + (visibleFrame.height - windowHeight) / 2;
        NSRect windowRect = new NSRect(originX, originY, windowWidth, windowHeight);

        // Create window (styleMask: titled | closable | miniaturizable = 7)
        IntPtr windowAlloc = objc_msgSend_IntPtr(nsWindowClass, sel_registerName("alloc"));
        window = objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(
            windowAlloc,
            sel_registerName("initWithContentRect:styleMask:backing:defer:"),
            windowRect,
            7,      // non-resizable
            2,      // buffered
            0);

        // Window title
        IntPtr windowTitle = ToNSString("Power Events test application");
        objc_msgSend_void_IntPtr(window, sel_registerName("setTitle:"), windowTitle);

        // Get content view
        IntPtr contentView = objc_msgSend_IntPtr(window, sel_registerName("contentView"));

        // ---- Create Open button ----
        IntPtr openAlloc = objc_msgSend_IntPtr(nsButtonClass, sel_registerName("alloc"));
        NSRect openRect = new NSRect(8, 302, 75, 25);
        IntPtr openButton = objc_msgSend_IntPtr_NSRect(openAlloc, sel_registerName("initWithFrame:"), openRect);
        objc_msgSend_void_IntPtr(openButton, sel_registerName("setTitle:"), ToNSString("Open"));
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), openButton);

        // ---- Create Close button ----
        IntPtr closeAlloc = objc_msgSend_IntPtr(nsButtonClass, sel_registerName("alloc"));
        NSRect closeRect = new NSRect(88, 302, 75, 25);
        IntPtr closeButton = objc_msgSend_IntPtr_NSRect(closeAlloc, sel_registerName("initWithFrame:"), closeRect);
        objc_msgSend_void_IntPtr(closeButton, sel_registerName("setTitle:"), ToNSString("Close"));
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), closeButton);

        // ---- Create Get state button ----
        IntPtr getStateAlloc = objc_msgSend_IntPtr(nsButtonClass, sel_registerName("alloc"));
        NSRect getStateRect = new NSRect(184, 302, 75, 25);
        IntPtr getStateButton = objc_msgSend_IntPtr_NSRect(getStateAlloc, sel_registerName("initWithFrame:"), getStateRect);
        objc_msgSend_void_IntPtr(getStateButton, sel_registerName("setTitle:"), ToNSString("Get state"));
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), getStateButton);

        // ---- Create scrollable text view as log ----
        IntPtr scrollAlloc = objc_msgSend_IntPtr(nsScrollViewClass, sel_registerName("alloc"));
        NSRect scrollRect = new NSRect(8, 8, 417, 281);
        IntPtr scrollView = objc_msgSend_IntPtr_NSRect(scrollAlloc, sel_registerName("initWithFrame:"), scrollRect);
        objc_msgSend_void_byte(scrollView, sel_registerName("setHasVerticalScroller:"), 1);
        objc_msgSend_void_byte(scrollView, sel_registerName("setHasHorizontalScroller:"), 0);

        IntPtr textViewAlloc = objc_msgSend_IntPtr(nsTextViewClass, sel_registerName("alloc"));
        NSRect textRect = new NSRect(0, 0, 417, 281);
        outputTextView = objc_msgSend_IntPtr_NSRect(textViewAlloc, sel_registerName("initWithFrame:"), textRect);
        objc_msgSend_void_byte(outputTextView, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(outputTextView, sel_registerName("setSelectable:"), 1);
        objc_msgSend_void_IntPtr(scrollView, sel_registerName("setDocumentView:"), outputTextView);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), scrollView);

        // ---- Set up custom class for buttons, timer, and app delegate ----
        targetClass = objc_getClass("AppDelegate");
        if (targetClass == IntPtr.Zero)
        {
            IntPtr superclass = objc_getClass("NSObject");
            targetClass = objc_allocateClassPair(superclass, "AppDelegate", IntPtr.Zero);

            // Button actions
            openDelegate = new ButtonClickIMP(OnOpenClicked);
            IntPtr openImp = Marshal.GetFunctionPointerForDelegate(openDelegate);
            class_addMethod(targetClass, sel_registerName("openClicked:"), openImp, "v@:@");

            closeDelegate = new ButtonClickIMP(OnCloseClicked);
            IntPtr closeImp = Marshal.GetFunctionPointerForDelegate(closeDelegate);
            class_addMethod(targetClass, sel_registerName("closeClicked:"), closeImp, "v@:@");

            getStateDelegate = new ButtonClickIMP(OnGetStateClicked);
            IntPtr getStateImp = Marshal.GetFunctionPointerForDelegate(getStateDelegate);
            class_addMethod(targetClass, sel_registerName("getStateClicked:"), getStateImp, "v@:@");

            // Timer callback
            timerDelegate = new TimerCallbackIMP(OnTimerFired);
            IntPtr timerImp = Marshal.GetFunctionPointerForDelegate(timerDelegate);
            class_addMethod(targetClass, sel_registerName("processLogQueue:"), timerImp, "v@:@");

            // Application delegate
            shouldTerminateDelegate = new ApplicationShouldTerminateIMP(ShouldTerminateAfterLastWindowClosed);
            IntPtr shouldTerminateImp = Marshal.GetFunctionPointerForDelegate(shouldTerminateDelegate);
            class_addMethod(targetClass, sel_registerName("applicationShouldTerminateAfterLastWindowClosed:"), shouldTerminateImp, "B@:@");

            objc_registerClassPair(targetClass);
        }

        target = objc_msgSend_IntPtr(targetClass, sel_registerName("new"));

        // Set button targets/actions
        objc_msgSend_void_IntPtr(openButton, sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(openButton, sel_registerName("setAction:"), sel_registerName("openClicked:"));

        objc_msgSend_void_IntPtr(closeButton, sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(closeButton, sel_registerName("setAction:"), sel_registerName("closeClicked:"));

        objc_msgSend_void_IntPtr(getStateButton, sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(getStateButton, sel_registerName("setAction:"), sel_registerName("getStateClicked:"));

        // Set app delegate
        objc_msgSend_void_IntPtr(sharedApp, sel_registerName("setDelegate:"), target);

        // Create and configure power events monitor
        monitor = new wclPowerEventsMonitor();
        monitor.OnStarted += MonitorStarted;
        monitor.OnStopped += MonitorStopped;
        monitor.OnPowerStateChanged += PowerStateChanged;

        // Start a timer to process log queue on the main thread
        // +[NSTimer scheduledTimerWithTimeInterval:target:selector:userInfo:repeats:]
        timer = objc_msgSend_IntPtr_Double_IntPtr_IntPtr_IntPtr_byte(
            nsTimerClass,
            sel_registerName("scheduledTimerWithTimeInterval:target:selector:userInfo:repeats:"),
            0.1,                // interval
            target,             // target
            sel_registerName("processLogQueue:"), // selector
            IntPtr.Zero,        // userInfo
            1);                 // repeats: YES

        // Show window and activate
        objc_msgSend_void_IntPtr(window, sel_registerName("makeKeyAndOrderFront:"), IntPtr.Zero);
        objc_msgSend_void_byte(sharedApp, sel_registerName("activateIgnoringOtherApps:"), 1);

        // Run the app
        objc_msgSend_void(sharedApp, sel_registerName("run"));

        // Cleanup
        objc_msgSend_void(timer, sel_registerName("invalidate"));
        monitor.Stop();
        objc_msgSend_void(autoreleasePool, sel_registerName("drain"));
    }

    // ---------- Button handlers ----------
    static void OnOpenClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = monitor.Start();
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Start failed: 0x" + res.ToString("X8"));
    }

    static void OnCloseClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = monitor.Stop();
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Stop failed: 0x" + res.ToString("X8"));
    }

    static void OnGetStateClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        wclPowerStatus status;
        if (!monitor.GetPowerStatus(out status))
        {
            AddLog("Get status failed");
            return;
        }

        switch (status.ACLineStatus)
        {
            case wclACLineStatus.lsOffline: AddLog("AC: Offline"); break;
            case wclACLineStatus.lsOnline: AddLog("AC: Online"); break;
            case wclACLineStatus.lsBackup: AddLog("AC: Backup"); break;
            case wclACLineStatus.lsUnknown: AddLog("AC: Unknown"); break;
        }

        string batt = "[";
        if ((wclBatteryChargeStatus.csCapacityHigh & status.BatteryChargeStatus) != 0) batt += " csCapacityHigh";
        if ((wclBatteryChargeStatus.csCapacityLow & status.BatteryChargeStatus) != 0) batt += " csCapacityLow";
        if ((wclBatteryChargeStatus.csCapacityCritical & status.BatteryChargeStatus) != 0) batt += " csCapacityCritical";
        if ((wclBatteryChargeStatus.csCharging & status.BatteryChargeStatus) != 0) batt += " csCharging";
        if ((wclBatteryChargeStatus.csNoSystemBattery & status.BatteryChargeStatus) != 0) batt += " csNoSystemBattery";
        batt += " ]";
        AddLog("Batt: " + batt);

        AddLog("Batt percent: " + status.BatteryLifePercent.ToString());

        if (status.BatterySavingState)
            AddLog("Battery saving");

        if (status.BatteryLifeTime != UInt32.MaxValue)
            AddLog("Batt life: " + status.BatteryLifeTime.ToString());

        if (status.BatteryFullLifeTime != UInt32.MaxValue)
            AddLog("Batt full life: " + status.BatteryFullLifeTime.ToString());
    }

    // ---------- Monitor event handlers (may be called on background threads) ----------
    static void MonitorStarted(object sender, EventArgs e)
    {
        AddLog("Monitor started");
    }

    static void MonitorStopped(object sender, EventArgs e)
    {
        AddLog("Monitor stopped");
    }

    static void PowerStateChanged(object sender, wclPowerState state)
    {
        switch (state)
        {
            case wclPowerState.psPowerStatusChanged: AddLog("Power status changed"); break;
            case wclPowerState.psResumeAutomatic: AddLog("Resumed"); break;
            case wclPowerState.psResume: AddLog("Resumed by user"); break;
            case wclPowerState.psSuspend: AddLog("Suspended"); break;
            case wclPowerState.psUnknown: AddLog("Unknown"); break;
        }
    }

    // ---------- Helper: thread-safe log queue ----------
    static void AddLog(string message)
    {
        logQueue.Enqueue(message);
    }

    // Timer callback – runs on main thread
    static void OnTimerFired(IntPtr self, IntPtr cmd, IntPtr timer)
    {
        bool changed = false;
        while (logQueue.TryDequeue(out string msg))
        {
            logText.AppendLine(msg);
            changed = true;
        }

        if (changed)
        {
            SetOutputText(logText.ToString());
        }
    }

    static void SetOutputText(string text)
    {
        IntPtr nsString = ToNSString(text);
        objc_msgSend_void_IntPtr(outputTextView, sel_registerName("setString:"), nsString);
    }

    static byte ShouldTerminateAfterLastWindowClosed(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        // Stop monitoring when the app is about to quit
        monitor.Stop();
        return 1; // YES
    }

    // ---------- String conversion ----------
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

    // ---------- Native library imports ----------
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

    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern NSRect objc_msgSend_NSRect(IntPtr receiver, IntPtr selector);

    // For NSTimer scheduledTimerWithTimeInterval...
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_Double_IntPtr_IntPtr_IntPtr_byte(
        IntPtr receiver,
        IntPtr selector,
        double arg1,
        IntPtr arg2,
        IntPtr arg3,
        IntPtr arg4,
        byte arg5);
}