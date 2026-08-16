using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using wclCommon;
using wclSerialFramework;

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

    // Delegate types
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void ButtonClickIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate byte ApplicationShouldTerminateIMP(IntPtr self, IntPtr cmd, IntPtr sender);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void TimerCallbackIMP(IntPtr self, IntPtr cmd, IntPtr timer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate long NumberOfRowsIMP(IntPtr self, IntPtr cmd, IntPtr tableView);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate IntPtr ObjectValueForColumnIMP(IntPtr self, IntPtr cmd, IntPtr tableView, IntPtr tableColumn, long row);

    static IntPtr nsStringClass;
    static IntPtr targetClass;
    static IntPtr target;
    static ButtonClickIMP startDelegate, stopDelegate, enumSerialDelegate, enumUsbDelegate, enableDelegate, disableDelegate, clearDelegate;
    static ApplicationShouldTerminateIMP shouldTerminateDelegate;
    static TimerCallbackIMP timerDelegate;
    static NumberOfRowsIMP numberOfRowsDelegate;
    static ObjectValueForColumnIMP objectValueDelegate;

    static IntPtr window;
    static IntPtr tableView;
    static IntPtr outputTextView;
    static IntPtr timer;

    // Static field for NSTableColumn class (needed in enum handlers)
    static IntPtr nsTableColumnClass;

    static wclSerialMonitor monitor;

    static ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
    static StringBuilder logText = new StringBuilder();

    // Data for table view
    static List<string[]> tableRows = new List<string[]>();
    static int currentColumnCount = 0;

    static void Main()
    {
        // Load AppKit
        const int RTLD_LAZY = 1;
        IntPtr appKit = dlopen("/System/Library/Frameworks/AppKit.framework/AppKit", RTLD_LAZY);
        if (appKit == IntPtr.Zero)
            throw new InvalidOperationException("Failed to load AppKit");

        // Get classes
        IntPtr nsAppClass = objc_getClass("NSApplication");
        IntPtr nsWindowClass = objc_getClass("NSWindow");
        IntPtr nsButtonClass = objc_getClass("NSButton");
        IntPtr nsTextFieldClass = objc_getClass("NSTextField");
        IntPtr nsScrollViewClass = objc_getClass("NSScrollView");
        IntPtr nsTextViewClass = objc_getClass("NSTextView");
        IntPtr nsScreenClass = objc_getClass("NSScreen");
        IntPtr nsTimerClass = objc_getClass("NSTimer");
        nsTableColumnClass = objc_getClass("NSTableColumn"); // assigned to static field
        IntPtr nsTableViewClass = objc_getClass("NSTableView");
        IntPtr nsTableHeaderViewClass = objc_getClass("NSTableHeaderView");
        nsStringClass = objc_getClass("NSString");

        // Autorelease pool
        IntPtr autoreleasePoolClass = objc_getClass("NSAutoreleasePool");
        IntPtr autoreleasePool = objc_msgSend_IntPtr(autoreleasePoolClass, sel_registerName("new"));

        // Shared application
        IntPtr sharedApp = objc_msgSend_IntPtr(nsAppClass, sel_registerName("sharedApplication"));
        objc_msgSend_void_long(sharedApp, sel_registerName("setActivationPolicy:"), 0);

        // Screen frame for centering
        IntPtr mainScreen = objc_msgSend_IntPtr(nsScreenClass, sel_registerName("mainScreen"));
        NSRect visibleFrame = objc_msgSend_NSRect(mainScreen, sel_registerName("visibleFrame"));
        double winW = 556, winH = 460;
        double originX = visibleFrame.x + (visibleFrame.width - winW) / 2;
        double originY = visibleFrame.y + (visibleFrame.height - winH) / 2;
        NSRect winRect = new NSRect(originX, originY, winW, winH);

        // Create window (non-resizable)
        IntPtr windowAlloc = objc_msgSend_IntPtr(nsWindowClass, sel_registerName("alloc"));
        window = objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(
            windowAlloc,
            sel_registerName("initWithContentRect:styleMask:backing:defer:"),
            winRect,
            7,      // titled | closable | miniaturizable
            2,      // buffered
            0);

        objc_msgSend_void_IntPtr(window, sel_registerName("setTitle:"), ToNSString("Serial Monitor Test"));
        IntPtr contentView = objc_msgSend_IntPtr(window, sel_registerName("contentView"));

        // Buttons layout (top row)
        double buttonY = winH - 8 - 25; // top = 8
        double[] buttonXs = { 8, 88, 184, 280, 384, 470 };
        string[] buttonTitles = { "Start", "Stop", "Enum serial", "Enum USB", "Disable", "Enable" };
        IntPtr[] buttons = new IntPtr[6];
        for (int i = 0; i < 6; i++)
        {
            IntPtr btnAlloc = objc_msgSend_IntPtr(nsButtonClass, sel_registerName("alloc"));
            double width = (i == 2) ? 88 : 75; // Enum serial is 88
            NSRect btnRect = new NSRect(buttonXs[i], buttonY, width, 25);
            IntPtr btn = objc_msgSend_IntPtr_NSRect(btnAlloc, sel_registerName("initWithFrame:"), btnRect);
            objc_msgSend_void_IntPtr(btn, sel_registerName("setTitle:"), ToNSString(buttonTitles[i]));
            objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), btn);
            buttons[i] = btn;
        }

        // Clear button
        IntPtr clearAlloc = objc_msgSend_IntPtr(nsButtonClass, sel_registerName("alloc"));
        NSRect clearRect = new NSRect(470, winH - 224 - 25, 75, 25);
        IntPtr clearButton = objc_msgSend_IntPtr_NSRect(clearAlloc, sel_registerName("initWithFrame:"), clearRect);
        objc_msgSend_void_IntPtr(clearButton, sel_registerName("setTitle:"), ToNSString("Clear"));
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), clearButton);

        // Table view inside scroll view
        IntPtr tableScrollAlloc = objc_msgSend_IntPtr(nsScrollViewClass, sel_registerName("alloc"));
        NSRect tableScrollRect = new NSRect(8, winH - 40 - 169, 537, 169); // top = 40, height=169
        IntPtr tableScrollView = objc_msgSend_IntPtr_NSRect(tableScrollAlloc, sel_registerName("initWithFrame:"), tableScrollRect);
        objc_msgSend_void_byte(tableScrollView, sel_registerName("setHasVerticalScroller:"), 1);
        objc_msgSend_void_byte(tableScrollView, sel_registerName("setHasHorizontalScroller:"), 1);

        IntPtr tableAlloc = objc_msgSend_IntPtr(nsTableViewClass, sel_registerName("alloc"));
        NSRect tableRect = new NSRect(0, 0, 537, 169);
        tableView = objc_msgSend_IntPtr_NSRect(tableAlloc, sel_registerName("initWithFrame:"), tableRect);
        objc_msgSend_void_IntPtr(tableScrollView, sel_registerName("setDocumentView:"), tableView);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), tableScrollView);

        // Log text view
        IntPtr logScrollAlloc = objc_msgSend_IntPtr(nsScrollViewClass, sel_registerName("alloc"));
        NSRect logScrollRect = new NSRect(8, winH - 256 - 193, 537, 193);
        IntPtr logScrollView = objc_msgSend_IntPtr_NSRect(logScrollAlloc, sel_registerName("initWithFrame:"), logScrollRect);
        objc_msgSend_void_byte(logScrollView, sel_registerName("setHasVerticalScroller:"), 1);
        objc_msgSend_void_byte(logScrollView, sel_registerName("setHasHorizontalScroller:"), 0);

        IntPtr logTextAlloc = objc_msgSend_IntPtr(nsTextViewClass, sel_registerName("alloc"));
        NSRect logTextRect = new NSRect(0, 0, 537, 193);
        outputTextView = objc_msgSend_IntPtr_NSRect(logTextAlloc, sel_registerName("initWithFrame:"), logTextRect);
        objc_msgSend_void_byte(outputTextView, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(outputTextView, sel_registerName("setSelectable:"), 1);
        objc_msgSend_void_IntPtr(logScrollView, sel_registerName("setDocumentView:"), outputTextView);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), logScrollView);

        // Create custom class for target
        targetClass = objc_getClass("AppDelegate");
        if (targetClass == IntPtr.Zero)
        {
            IntPtr superclass = objc_getClass("NSObject");
            targetClass = objc_allocateClassPair(superclass, "AppDelegate", IntPtr.Zero);

            // Button actions
            startDelegate = new ButtonClickIMP(OnStartClicked);
            class_addMethod(targetClass, sel_registerName("startClicked:"), Marshal.GetFunctionPointerForDelegate(startDelegate), "v@:@");
            stopDelegate = new ButtonClickIMP(OnStopClicked);
            class_addMethod(targetClass, sel_registerName("stopClicked:"), Marshal.GetFunctionPointerForDelegate(stopDelegate), "v@:@");
            enumSerialDelegate = new ButtonClickIMP(OnEnumSerialClicked);
            class_addMethod(targetClass, sel_registerName("enumSerialClicked:"), Marshal.GetFunctionPointerForDelegate(enumSerialDelegate), "v@:@");
            enumUsbDelegate = new ButtonClickIMP(OnEnumUsbClicked);
            class_addMethod(targetClass, sel_registerName("enumUsbClicked:"), Marshal.GetFunctionPointerForDelegate(enumUsbDelegate), "v@:@");
            enableDelegate = new ButtonClickIMP(OnEnableClicked);
            class_addMethod(targetClass, sel_registerName("enableClicked:"), Marshal.GetFunctionPointerForDelegate(enableDelegate), "v@:@");
            disableDelegate = new ButtonClickIMP(OnDisableClicked);
            class_addMethod(targetClass, sel_registerName("disableClicked:"), Marshal.GetFunctionPointerForDelegate(disableDelegate), "v@:@");
            clearDelegate = new ButtonClickIMP(OnClearClicked);
            class_addMethod(targetClass, sel_registerName("clearClicked:"), Marshal.GetFunctionPointerForDelegate(clearDelegate), "v@:@");

            // Timer
            timerDelegate = new TimerCallbackIMP(OnTimerFired);
            class_addMethod(targetClass, sel_registerName("processLogQueue:"), Marshal.GetFunctionPointerForDelegate(timerDelegate), "v@:@");

            // Application delegate
            shouldTerminateDelegate = new ApplicationShouldTerminateIMP(ShouldTerminateAfterLastWindowClosed);
            class_addMethod(targetClass, sel_registerName("applicationShouldTerminateAfterLastWindowClosed:"), Marshal.GetFunctionPointerForDelegate(shouldTerminateDelegate), "B@:@");

            // Table data source methods
            numberOfRowsDelegate = new NumberOfRowsIMP(NumberOfRows);
            class_addMethod(targetClass, sel_registerName("numberOfRowsInTableView:"), Marshal.GetFunctionPointerForDelegate(numberOfRowsDelegate), "l@:@");
            objectValueDelegate = new ObjectValueForColumnIMP(ObjectValueForColumn);
            class_addMethod(targetClass, sel_registerName("tableView:objectValueForTableColumn:row:"), Marshal.GetFunctionPointerForDelegate(objectValueDelegate), "@@:@@l");

            objc_registerClassPair(targetClass);
        }

        target = objc_msgSend_IntPtr(targetClass, sel_registerName("new"));

        // Set button targets
        objc_msgSend_void_IntPtr(buttons[0], sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(buttons[0], sel_registerName("setAction:"), sel_registerName("startClicked:"));
        objc_msgSend_void_IntPtr(buttons[1], sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(buttons[1], sel_registerName("setAction:"), sel_registerName("stopClicked:"));
        objc_msgSend_void_IntPtr(buttons[2], sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(buttons[2], sel_registerName("setAction:"), sel_registerName("enumSerialClicked:"));
        objc_msgSend_void_IntPtr(buttons[3], sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(buttons[3], sel_registerName("setAction:"), sel_registerName("enumUsbClicked:"));
        objc_msgSend_void_IntPtr(buttons[4], sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(buttons[4], sel_registerName("setAction:"), sel_registerName("disableClicked:"));
        objc_msgSend_void_IntPtr(buttons[5], sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(buttons[5], sel_registerName("setAction:"), sel_registerName("enableClicked:"));
        objc_msgSend_void_IntPtr(clearButton, sel_registerName("setTarget:"), target);
        objc_msgSend_void_IntPtr(clearButton, sel_registerName("setAction:"), sel_registerName("clearClicked:"));

        // Set table view data source
        objc_msgSend_void_IntPtr(tableView, sel_registerName("setDataSource:"), target);
        objc_msgSend_void_IntPtr(tableView, sel_registerName("setDelegate:"), target);

        // Set app delegate
        objc_msgSend_void_IntPtr(sharedApp, sel_registerName("setDelegate:"), target);

        // Create monitor
        monitor = new wclSerialMonitor();
        monitor.OnStarted += MonitorStarted;
        monitor.OnStopped += MonitorStopped;
        monitor.OnSerialDeviceAdded += SerialDeviceAdded;
        monitor.OnSerialDeviceRemoved += SerialDeviceRemoved;
        monitor.OnUsbDeviceAdded += UsbDeviceAdded;
        monitor.OnUsbDeviceRemoved += UsbDeviceRemoved;

        // Start timer to process log queue
        timer = objc_msgSend_IntPtr_Double_IntPtr_IntPtr_IntPtr_byte(
            nsTimerClass,
            sel_registerName("scheduledTimerWithTimeInterval:target:selector:userInfo:repeats:"),
            0.1,
            target,
            sel_registerName("processLogQueue:"),
            IntPtr.Zero,
            1);

        // Show window
        objc_msgSend_void_IntPtr(window, sel_registerName("makeKeyAndOrderFront:"), IntPtr.Zero);
        objc_msgSend_void_byte(sharedApp, sel_registerName("activateIgnoringOtherApps:"), 1);

        // Run
        objc_msgSend_void(sharedApp, sel_registerName("run"));

        // Cleanup
        objc_msgSend_void(timer, sel_registerName("invalidate"));
        monitor.Stop();
        objc_msgSend_void(autoreleasePool, sel_registerName("drain"));
    }

    // Button handlers
    static void OnStartClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = monitor.Start();
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Start failed: 0x" + res.ToString("X8"));
    }

    static void OnStopClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = monitor.Stop();
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Stop failed: 0x" + res.ToString("X8"));
    }

    static void OnEnumSerialClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        // Clear table rows
        tableRows.Clear();
        currentColumnCount = 3;

        if (serialColumnsCreated == false)
        {
            serialColumnsCreated = true;
            string[] titles = { "Device name", "Friendly name", "IsModem" };
            double[] widths = { 80, 350, 70 };
            for (int i = 0; i < 3; i++)
            {
                IntPtr colAlloc = objc_msgSend_IntPtr(nsTableColumnClass, sel_registerName("alloc"));
                IntPtr column = objc_msgSend_IntPtr_IntPtr(colAlloc, sel_registerName("initWithIdentifier:"), ToNSString(i.ToString()));
                objc_msgSend_void_IntPtr(column, sel_registerName("setTitle:"), ToNSString(titles[i]));
                objc_msgSend_void_Double(column, sel_registerName("setWidth:"), widths[i]);
                objc_msgSend_void_IntPtr(tableView, sel_registerName("addTableColumn:"), column);
            }
        }

        List<wclSerialDevice> devices;
        int res = monitor.EnumSerialDevices(out devices);
        if (res != wclErrors.WCL_E_SUCCESS)
        {
            AddLog("Enum serial devices failed: 0x" + res.ToString("X8"));
        }
        else if (devices == null || devices.Count == 0)
        {
            AddLog("No serial devices found");
        }
        else
        {
            AddLog("Found " + devices.Count + " serial devices");
            foreach (var dev in devices)
            {
                tableRows.Add(new string[] { dev.DeviceName, dev.FriendlyName, dev.IsModem ? "True" : "False" });
            }
        }
        objc_msgSend_void(tableView, sel_registerName("reloadData"));
    }

    static void OnEnumUsbClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        tableRows.Clear();
        currentColumnCount = 7;

        if (usbColumnsCreated == false)
        {
            usbColumnsCreated = true;
            string[] titles = { "Instance", "Friendly name", "VID", "PID", "Class", "Manufacturer", "Enabled" };
            double[] widths = { 250, 250, 50, 50, 250, 200, 70 };
            for (int i = 0; i < 7; i++)
            {
                IntPtr colAlloc = objc_msgSend_IntPtr(nsTableColumnClass, sel_registerName("alloc"));
                IntPtr column = objc_msgSend_IntPtr_IntPtr(colAlloc, sel_registerName("initWithIdentifier:"), ToNSString(i.ToString()));
                objc_msgSend_void_IntPtr(column, sel_registerName("setTitle:"), ToNSString(titles[i]));
                objc_msgSend_void_Double(column, sel_registerName("setWidth:"), widths[i]);
                objc_msgSend_void_IntPtr(tableView, sel_registerName("addTableColumn:"), column);
            }
        }

        List<wclUsbDevice> usbDevices;
        int res = monitor.EnumUsbDevices(out usbDevices);
        if (res != wclErrors.WCL_E_SUCCESS)
        {
            AddLog("Enum USB devices failed: 0x" + res.ToString("X8"));
        }
        else if (usbDevices == null || usbDevices.Count == 0)
        {
            AddLog("No USB devices found");
        }
        else
        {
            AddLog("Found " + usbDevices.Count + " USB devices");
            foreach (var dev in usbDevices)
            {
                tableRows.Add(new string[] {
                    dev.Instance,
                    dev.FriendlyName,
                    dev.VendorId.ToString("X4"),
                    dev.ProductId.ToString("X4"),
                    dev.ClassGuid.ToString(),
                    dev.Manufacturer,
                    dev.Enabled ? "True" : "False"
                });
            }
        }
        objc_msgSend_void(tableView, sel_registerName("reloadData"));
    }

    static void OnEnableClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        SwitchUsbDevice(true);
    }

    static void OnDisableClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        SwitchUsbDevice(false);
    }

    static void SwitchUsbDevice(bool enable)
    {
        if (currentColumnCount != 7)
        {
            ShowAlert("Information", "Enumerate USB devices first.");
            return;
        }
        if (tableRows.Count == 0)
        {
            ShowAlert("Information", "No USB devices found.");
            return;
        }
        long selectedRow = objc_msgSend_long(tableView, sel_registerName("selectedRow"));
        if (selectedRow < 0 || selectedRow >= tableRows.Count)
        {
            ShowAlert("Information", "Select USB device.");
            return;
        }
        string instance = tableRows[(int)selectedRow][0];
        int res;
        if (enable)
            res = monitor.EnableUsbDevice(instance);
        else
            res = monitor.DisableUsbDevice(instance);
        if (res != wclErrors.WCL_E_SUCCESS)
        {
            string action = enable ? "enabling" : "disabling";
            ShowAlert("Error", $"Error {action} USB: 0x{res:X8}");
        }
        else
        {
            ShowAlert("Success", enable ? "Device enabled" : "Device disabled");
        }
    }

    static void OnClearClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        logText.Clear();
        SetOutputText("");
    }

    // Monitor event handlers (thread-safe via queue)
    static void MonitorStarted(object sender, EventArgs e) { AddLog("Monitor started"); }
    static void MonitorStopped(object sender, EventArgs e) { AddLog("Monitor stopped"); }
    static void SerialDeviceAdded(object sender, string deviceName) { AddLog("Device added: " + deviceName); }
    static void SerialDeviceRemoved(object sender, string deviceName) { AddLog("Device removed: " + deviceName); }
    static void UsbDeviceAdded(object sender, string instance) { AddLog("Device added: " + instance); }
    static void UsbDeviceRemoved(object sender, string instance) { AddLog("Device removed: " + instance); }

    static void AddLog(string msg) { logQueue.Enqueue(msg); }

    static void OnTimerFired(IntPtr self, IntPtr cmd, IntPtr timer)
    {
        bool changed = false;
        while (logQueue.TryDequeue(out string msg))
        {
            logText.AppendLine(msg);
            changed = true;
        }
        if (changed)
            SetOutputText(logText.ToString());
    }

    static void SetOutputText(string text)
    {
        objc_msgSend_void_IntPtr(outputTextView, sel_registerName("setString:"), ToNSString(text));
    }

    // NSTableView data source methods
    static long NumberOfRows(IntPtr self, IntPtr cmd, IntPtr tableView)
    {
        return tableRows.Count;
    }

    static IntPtr ObjectValueForColumn(IntPtr self, IntPtr cmd, IntPtr tableView, IntPtr tableColumn, long row)
    {
        if (row < 0 || row >= tableRows.Count)
            return IntPtr.Zero;
        IntPtr ident = objc_msgSend_IntPtr(tableColumn, sel_registerName("identifier"));
        string colStr = FromNSString(ident);
        int colIndex = int.Parse(colStr);
        if (colIndex < 0 || colIndex >= tableRows[(int)row].Length)
            return IntPtr.Zero;
        return ToNSString(tableRows[(int)row][colIndex]);
    }

    static byte ShouldTerminateAfterLastWindowClosed(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        monitor.Stop();
        return 1;
    }

    static void ShowAlert(string title, string message)
    {
        IntPtr alertClass = objc_getClass("NSAlert");
        IntPtr alert = objc_msgSend_IntPtr(alertClass, sel_registerName("new"));
        objc_msgSend_void_IntPtr(alert, sel_registerName("setMessageText:"), ToNSString(title));
        objc_msgSend_void_IntPtr(alert, sel_registerName("setInformativeText:"), ToNSString(message));
        objc_msgSend_long(alert, sel_registerName("runModal"));
    }

    // String conversion helpers
    static IntPtr ToNSString(string s)
    {
        byte[] utf8 = Encoding.UTF8.GetBytes(s);
        IntPtr buf = Marshal.AllocHGlobal(utf8.Length + 1);
        Marshal.Copy(utf8, 0, buf, utf8.Length);
        Marshal.WriteByte(buf, utf8.Length, 0);
        IntPtr nsStr = objc_msgSend_IntPtr_IntPtr(nsStringClass, sel_registerName("stringWithUTF8String:"), buf);
        Marshal.FreeHGlobal(buf);
        return nsStr;
    }

    static string FromNSString(IntPtr nsString)
    {
        if (nsString == IntPtr.Zero) return "";
        IntPtr utf8 = objc_msgSend_IntPtr(nsString, sel_registerName("UTF8String"));
        return utf8 == IntPtr.Zero ? "" : Marshal.PtrToStringUTF8(utf8);
    }

    // Flags for column creation
    static bool serialColumnsCreated = false;
    static bool usbColumnsCreated = false;

    // Native imports
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

    // objc_msgSend variants
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
    static extern void objc_msgSend_void_Double(IntPtr receiver, IntPtr selector, double arg1);
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_NSRect(IntPtr receiver, IntPtr selector, NSRect arg1);
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(IntPtr receiver, IntPtr selector, NSRect arg1, ulong arg2, ulong arg3, byte arg4);
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern NSRect objc_msgSend_NSRect(IntPtr receiver, IntPtr selector);
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_Double_IntPtr_IntPtr_IntPtr_byte(IntPtr receiver, IntPtr selector, double arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, byte arg5);
}