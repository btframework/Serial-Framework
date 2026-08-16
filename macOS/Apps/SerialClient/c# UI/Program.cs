using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using wclCommon;
using wclCommunication;
using wclSerialFramework;

class Program
{
    const string LibObjC = "/usr/lib/libobjc.dylib";
    const string LibSystem = "/usr/lib/libSystem.dylib";

    [StructLayout(LayoutKind.Sequential)]
    struct NSRect
    {
        public double x, y, width, height;
        public NSRect(double x, double y, double w, double h) { this.x = x; this.y = y; width = w; height = h; }
    }

    // Delegates
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] delegate void ButtonClickIMP(IntPtr self, IntPtr cmd, IntPtr sender);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] delegate byte ApplicationShouldTerminateIMP(IntPtr self, IntPtr cmd, IntPtr sender);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] delegate void TimerCallbackIMP(IntPtr self, IntPtr cmd, IntPtr timer);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)] delegate void ActionIMP(IntPtr self, IntPtr cmd, IntPtr sender); // used for combo box action

    static IntPtr nsStringClass;
    static IntPtr targetClass;
    static IntPtr target;
    static ButtonClickIMP connectDelegate, disconnectDelegate, enumDelegate, getConfigDelegate, setConfigDelegate;
    static ButtonClickIMP getBuffersDelegate, setBuffersDelegate, getTimeoutsDelegate, setTimeoutsDelegate;
    static ButtonClickIMP setWriteTimeoutDelegate, clearCommBreakDelegate, setCommBreakDelegate;
    static ButtonClickIMP funcDelegate, flushBuffersDelegate, purgeDelegate, transmitDelegate, sendDelegate, clearDelegate;
    static ApplicationShouldTerminateIMP shouldTerminateDelegate;
    static TimerCallbackIMP timerDelegate;
    
    static IntPtr window;
    static IntPtr logTextView;
    static IntPtr timer;

    // UI controls
    static IntPtr cbPorts, cbDtrControl, cbRtsControl, cbByteSize, cbParity, cbStopBits;
    static IntPtr cbFunc, cbLineFeed;
    static IntPtr edBaudRate, edXonLim, edXoffLim, edXonChar, edXoffChar, edErrorChar, edEofChar, edEvtChar;
    static IntPtr edReadBufferSize, edWriteBufferSize, edReadInterval, edReadMultiplier, edReadConstant, edWriteMultiplier, edWriteConstant;
    static IntPtr edWriteTimeout, edChar, edText;
    static IntPtr cbParityCheck, cbOutxCtsFlow, cbOutxDsrFlow, cbDsrSensitivity, cbTXContinueOnXoff, cbOutX, cbInX;
    static IntPtr cbErrorCharReplace, cbNullStrip, cbAbortOnError;
    static IntPtr cbpurgeRxAbort, cbpurgeRxClear, cbpurgeTxAbort, cbpurgeTxClear;

    static wclSerialClient client;
    static wclSerialMonitor monitor;

    static ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();
    static StringBuilder logText = new StringBuilder();
    
    static void Main()
    {
        // Load AppKit
        const int RTLD_LAZY = 1;
        IntPtr appKit = dlopen("/System/Library/Frameworks/AppKit.framework/AppKit", RTLD_LAZY);
        if (appKit == IntPtr.Zero) throw new InvalidOperationException("Failed to load AppKit");

        // Get classes
        IntPtr nsAppClass = objc_getClass("NSApplication");
        IntPtr nsWindowClass = objc_getClass("NSWindow");
        IntPtr nsButtonClass = objc_getClass("NSButton");
        IntPtr nsTextFieldClass = objc_getClass("NSTextField");
        IntPtr nsScrollViewClass = objc_getClass("NSScrollView");
        IntPtr nsTextViewClass = objc_getClass("NSTextView");
        IntPtr nsScreenClass = objc_getClass("NSScreen");
        IntPtr nsTimerClass = objc_getClass("NSTimer");
        IntPtr nsPopUpButtonClass = objc_getClass("NSPopUpButton");
        nsStringClass = objc_getClass("NSString");

        // Autorelease pool
        IntPtr autoreleasePoolClass = objc_getClass("NSAutoreleasePool");
        IntPtr autoreleasePool = objc_msgSend_IntPtr(autoreleasePoolClass, sel_registerName("new"));

        // Shared app
        IntPtr sharedApp = objc_msgSend_IntPtr(nsAppClass, sel_registerName("sharedApplication"));
        objc_msgSend_void_long(sharedApp, sel_registerName("setActivationPolicy:"), 0);

        // Screen centering
        IntPtr mainScreen = objc_msgSend_IntPtr(nsScreenClass, sel_registerName("mainScreen"));
        NSRect visibleFrame = objc_msgSend_NSRect(mainScreen, sel_registerName("visibleFrame"));
        double winW = 875, winH = 569;
        double originX = visibleFrame.x + (visibleFrame.width - winW) / 2;
        double originY = visibleFrame.y + (visibleFrame.height - winH) / 2;
        NSRect winRect = new NSRect(originX, originY, winW, winH);

        // Window
        IntPtr windowAlloc = objc_msgSend_IntPtr(nsWindowClass, sel_registerName("alloc"));
        window = objc_msgSend_IntPtr_NSRect_ulong_ulong_byte(
            windowAlloc,
            sel_registerName("initWithContentRect:styleMask:backing:defer:"),
            winRect,
            7,  // titled | closable | miniaturizable
            2, 0);

        objc_msgSend_void_IntPtr(window, sel_registerName("setTitle:"), ToNSString("Serial Client Demo"));
        IntPtr contentView = objc_msgSend_IntPtr(window, sel_registerName("contentView"));

        // ---- Top row: Enum button, Ports combo, Connect, Disconnect, Write timeout, Set write timeout ----
        CreateButton(8, winH - 8 - 25, 75, 25, "Enum", contentView, sel_registerName("enumClicked:"));
        cbPorts = CreatePopUpButton(88, winH - 10 - 23, 105, 23, contentView);
        CreateButton(200, winH - 8 - 25, 75, 25, "Connect", contentView, sel_registerName("connectClicked:"));
        CreateButton(280, winH - 8 - 25, 75, 25, "Disconnect", contentView, sel_registerName("disconnectClicked:"));
        edWriteTimeout = CreateTextField(456, winH - 10 - 23, 121, 23, contentView);
        CreateButton(592, winH - 8 - 25, 105, 25, "Set write timeout", contentView, sel_registerName("setWriteTimeoutClicked:"));

        // ---- Second row: Get/Set Config, Get/Set Buffers, Get/Set Timeouts, Clear/Set Comm Break ----
        CreateButton(8, winH - 48 - 25, 75, 25, "Get Config", contentView, sel_registerName("getConfigClicked:"));
        CreateButton(88, winH - 48 - 25, 75, 25, "Set Config", contentView, sel_registerName("setConfigClicked:"));
        CreateButton(428, winH - 48 - 25, 75, 25, "Get buffers", contentView, sel_registerName("getBuffersClicked:"));
        CreateButton(512, winH - 48 - 25, 75, 25, "Set buffers", contentView, sel_registerName("setBuffersClicked:"));
        CreateButton(432, winH - 152 - 25, 75, 25, "Get timeouts", contentView, sel_registerName("getTimeoutsClicked:"));
        CreateButton(520, winH - 152 - 25, 75, 25, "Set timeouts", contentView, sel_registerName("setTimeoutsClicked:"));
        CreateButton(624, winH - 48 - 25, 112, 25, "Clear comm break", contentView, sel_registerName("clearCommBreakClicked:"));
        CreateButton(747, winH - 48 - 25, 112, 25, "Set comm break", contentView, sel_registerName("setCommBreakClicked:"));

        // ---- Labels and fields (config area) ----
        CreateLabel(8, winH - 86 - 15, 50, 15, "Baudrate", contentView);
        edBaudRate = CreateTextField(72, winH - 80 - 23, 129, 23, contentView);
        CreateLabel(216, winH - 86 - 15, 59, 15, "Dtr Control", contentView);
        cbDtrControl = CreatePopUpButton(280, winH - 80 - 23, 129, 23, contentView);
        AddPopUpItems(cbDtrControl, new string[] { "dtrControlDisable", "dtrControlEnable", "dtrControlHandshake" });

        CreateLabel(8, winH - 112 - 15, 62, 15, "Rts Control", contentView);
        cbRtsControl = CreatePopUpButton(72, winH - 104 - 23, 129, 23, contentView);
        AddPopUpItems(cbRtsControl, new string[] { "rtsControlDisable", "rtsControlEnable", "rtsControlHandshake", "rtsControlToggle" });

        CreateLabel(216, winH - 112 - 15, 49, 15, "Byte Size", contentView);
        cbByteSize = CreatePopUpButton(280, winH - 104 - 23, 129, 23, contentView);
        AddPopUpItems(cbByteSize, new string[] { "4", "5", "6", "7", "8" });

        CreateLabel(8, winH - 136 - 15, 30, 15, "Parity", contentView);
        cbParity = CreatePopUpButton(72, winH - 128 - 23, 129, 23, contentView);
        AddPopUpItems(cbParity, new string[] { "spNo", "spOdd", "spEven", "spMark", "spSpace" });

        CreateLabel(216, winH - 136 - 15, 49, 15, "Stop Bits", contentView);
        cbStopBits = CreatePopUpButton(280, winH - 128 - 23, 129, 23, contentView);
        AddPopUpItems(cbStopBits, new string[] { "sbOne", "sbOne5", "sbTwo" });

        CreateLabel(8, winH - 160 - 15, 45, 15, "Xon Lim", contentView);
        edXonLim = CreateTextField(72, winH - 152 - 23, 129, 23, contentView);
        CreateLabel(216, winH - 160 - 15, 44, 15, "Xoff Lim", contentView);
        edXoffLim = CreateTextField(280, winH - 152 - 23, 129, 23, contentView);

        CreateLabel(8, winH - 192 - 15, 51, 15, "Xon Char", contentView);
        edXonChar = CreateTextField(58, winH - 184 - 23, 25, 23, contentView);
        CreateLabel(88, winH - 192 - 15, 50, 15, "Xoff Char", contentView);
        edXoffChar = CreateTextField(144, winH - 184 - 23, 25, 23, contentView);
        CreateLabel(168, winH - 192 - 15, 57, 15, "Error Char", contentView);
        edErrorChar = CreateTextField(224, winH - 184 - 23, 25, 23, contentView);
        CreateLabel(256, winH - 192 - 15, 48, 15, "Eof Char", contentView);
        edEofChar = CreateTextField(304, winH - 184 - 23, 25, 23, contentView);
        CreateLabel(336, winH - 192 - 15, 46, 15, "Evt Char", contentView);
        edEvtChar = CreateTextField(384, winH - 184 - 23, 25, 23, contentView);

        // Checkboxes (config)
        cbParityCheck = CreateCheckBox(80, winH - 224 - 19, 83, 19, "Parity check", contentView);
        cbOutxCtsFlow = CreateCheckBox(224, winH - 224 - 19, 93, 19, "Outx Cts Flow", contentView);
        cbOutxDsrFlow = CreateCheckBox(80, winH - 248 - 19, 94, 19, "Outx Dsr Flow", contentView);
        cbDsrSensitivity = CreateCheckBox(224, winH - 248 - 19, 95, 19, "Dsr Sensitivity", contentView);
        cbTXContinueOnXoff = CreateCheckBox(80, winH - 272 - 19, 127, 19, "TX Continue OnX off", contentView);
        cbOutX = CreateCheckBox(224, winH - 272 - 19, 44, 19, "OutX", contentView);
        cbInX = CreateCheckBox(224, winH - 296 - 19, 35, 19, "InX", contentView);
        cbErrorCharReplace = CreateCheckBox(80, winH - 296 - 19, 124, 19, "Error Char Replace", contentView);
        cbNullStrip = CreateCheckBox(80, winH - 320 - 19, 68, 19, "Null Strip", contentView);
        cbAbortOnError = CreateCheckBox(224, winH - 320 - 19, 95, 19, "Abort On Error", contentView);

        // Buffers and timeouts fields
        CreateLabel(428, winH - 86 - 15, 89, 15, "Read buffer size", contentView);
        edReadBufferSize = CreateTextField(520, winH - 80 - 23, 81, 23, contentView);
        CreateLabel(429, winH - 112 - 15, 87, 15, "Write buffer size", contentView);
        edWriteBufferSize = CreateTextField(520, winH - 107 - 23, 81, 23, contentView);
        CreateLabel(432, winH - 192 - 15, 72, 15, "Read Interval", contentView);
        edReadInterval = CreateTextField(520, winH - 184 - 23, 81, 23, contentView);
        CreateLabel(432, winH - 216 - 15, 82, 15, "Read Multiplier", contentView);
        edReadMultiplier = CreateTextField(520, winH - 208 - 23, 81, 23, contentView);
        CreateLabel(432, winH - 240 - 15, 83, 15, "Read Constant", contentView);
        edReadConstant = CreateTextField(520, winH - 232 - 23, 81, 23, contentView);
        CreateLabel(432, winH - 264 - 15, 80, 15, "Write Multiplier", contentView);
        edWriteMultiplier = CreateTextField(520, winH - 256 - 23, 81, 23, contentView);
        CreateLabel(432, winH - 288 - 15, 81, 15, "Write Constant", contentView);
        edWriteConstant = CreateTextField(520, winH - 280 - 23, 81, 23, contentView);

        // Function area
        CreateLabel(624, winH - 86 - 15, 47, 15, "Function", contentView);
        cbFunc = CreatePopUpButton(680, winH - 80 - 23, 97, 23, contentView);
        AddPopUpItems(cbFunc, new string[] { "escClrBreak", "escClrDtr", "escClrRts", "escSetBreak", "escSetDtr", "escSetRts", "escSetXoff", "escSetXon" });
        SelectPopUpItem(cbFunc, 0);

        CreateButton(782, winH - 76 - 25, 75, 25, "Exec func", contentView, sel_registerName("funcClicked:"));
        CreateButton(624, winH - 230 - 25, 75, 25, "Flush buffers", contentView, sel_registerName("flushBuffersClicked:"));

        // Purge checkboxes and button
        cbpurgeRxAbort = CreateCheckBox(624, winH - 128 - 19, 63, 19, "Rx Abort", contentView);
        cbpurgeRxClear = CreateCheckBox(624, winH - 152 - 19, 65, 19, "Rx Clear", contentView);
        cbpurgeTxAbort = CreateCheckBox(704, winH - 128 - 19, 61, 19, "Tx Abort", contentView);
        cbpurgeTxClear = CreateCheckBox(704, winH - 152 - 19, 63, 19, "Tx Clear", contentView);
        CreateButton(784, winH - 136 - 25, 75, 25, "Purge", contentView, sel_registerName("purgeClicked:"));

        // Transmit char
        CreateLabel(624, winH - 192 - 15, 98, 15, "Char code (ASCII)", contentView);
        edChar = CreateTextField(728, winH - 184 - 23, 49, 23, contentView);
        SetTextFieldText(edChar, "0");
        CreateButton(784, winH - 184 - 25, 75, 25, "Transmit", contentView, sel_registerName("transmitClicked:"));

        // Send area
        CreateLabel(560, winH - 360 - 15, 51, 15, "Line feed", contentView);
        cbLineFeed = CreatePopUpButton(616, winH - 352 - 22, 97, 22, contentView);
        AddPopUpItems(cbLineFeed, new string[] { "None", "CR", "LF", "CR & LF" });
        SelectPopUpItem(cbLineFeed, 0);
        edText = CreateTextField(8, winH - 352 - 23, 465, 23, contentView);
        SetTextFieldText(edText, "Something to send to serial");
        CreateButton(480, winH - 352 - 25, 75, 25, "Send", contentView, sel_registerName("sendClicked:"));
        CreateButton(784, winH - 352 - 25, 75, 25, "Clear", contentView, sel_registerName("clearClicked:"));

        // Log area (listbox -> text view)
        IntPtr logScrollAlloc = objc_msgSend_IntPtr(nsScrollViewClass, sel_registerName("alloc"));
        NSRect logScrollRect = new NSRect(8, 8, 849, 169);
        IntPtr logScrollView = objc_msgSend_IntPtr_NSRect(logScrollAlloc, sel_registerName("initWithFrame:"), logScrollRect);
        objc_msgSend_void_byte(logScrollView, sel_registerName("setHasVerticalScroller:"), 1);
        objc_msgSend_void_byte(logScrollView, sel_registerName("setHasHorizontalScroller:"), 0);

        IntPtr logTextAlloc = objc_msgSend_IntPtr(nsTextViewClass, sel_registerName("alloc"));
        NSRect logTextRect = new NSRect(0, 0, 849, 169);
        logTextView = objc_msgSend_IntPtr_NSRect(logTextAlloc, sel_registerName("initWithFrame:"), logTextRect);
        objc_msgSend_void_byte(logTextView, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(logTextView, sel_registerName("setSelectable:"), 1);
        objc_msgSend_void_IntPtr(logScrollView, sel_registerName("setDocumentView:"), logTextView);
        objc_msgSend_void_IntPtr(contentView, sel_registerName("addSubview:"), logScrollView);

        // Create custom class for target
        // Create custom class for target
        targetClass = objc_getClass("AppDelegate");
        if (targetClass == IntPtr.Zero)
        {
            IntPtr superclass = objc_getClass("NSObject");
            targetClass = objc_allocateClassPair(superclass, "AppDelegate", IntPtr.Zero);

            // Assign delegates to static fields and register methods
            enumDelegate = new ButtonClickIMP(OnEnumClicked);
            class_addMethod(targetClass, sel_registerName("enumClicked:"), Marshal.GetFunctionPointerForDelegate(enumDelegate), "v@:@");

            connectDelegate = new ButtonClickIMP(OnConnectClicked);
            class_addMethod(targetClass, sel_registerName("connectClicked:"), Marshal.GetFunctionPointerForDelegate(connectDelegate), "v@:@");

            disconnectDelegate = new ButtonClickIMP(OnDisconnectClicked);
            class_addMethod(targetClass, sel_registerName("disconnectClicked:"), Marshal.GetFunctionPointerForDelegate(disconnectDelegate), "v@:@");

            getConfigDelegate = new ButtonClickIMP(OnGetConfigClicked);
            class_addMethod(targetClass, sel_registerName("getConfigClicked:"), Marshal.GetFunctionPointerForDelegate(getConfigDelegate), "v@:@");

            setConfigDelegate = new ButtonClickIMP(OnSetConfigClicked);
            class_addMethod(targetClass, sel_registerName("setConfigClicked:"), Marshal.GetFunctionPointerForDelegate(setConfigDelegate), "v@:@");

            getBuffersDelegate = new ButtonClickIMP(OnGetBuffersClicked);
            class_addMethod(targetClass, sel_registerName("getBuffersClicked:"), Marshal.GetFunctionPointerForDelegate(getBuffersDelegate), "v@:@");

            setBuffersDelegate = new ButtonClickIMP(OnSetBuffersClicked);
            class_addMethod(targetClass, sel_registerName("setBuffersClicked:"), Marshal.GetFunctionPointerForDelegate(setBuffersDelegate), "v@:@");

            getTimeoutsDelegate = new ButtonClickIMP(OnGetTimeoutsClicked);
            class_addMethod(targetClass, sel_registerName("getTimeoutsClicked:"), Marshal.GetFunctionPointerForDelegate(getTimeoutsDelegate), "v@:@");

            setTimeoutsDelegate = new ButtonClickIMP(OnSetTimeoutsClicked);
            class_addMethod(targetClass, sel_registerName("setTimeoutsClicked:"), Marshal.GetFunctionPointerForDelegate(setTimeoutsDelegate), "v@:@");

            setWriteTimeoutDelegate = new ButtonClickIMP(OnSetWriteTimeoutClicked);
            class_addMethod(targetClass, sel_registerName("setWriteTimeoutClicked:"), Marshal.GetFunctionPointerForDelegate(setWriteTimeoutDelegate), "v@:@");

            clearCommBreakDelegate = new ButtonClickIMP(OnClearCommBreakClicked);
            class_addMethod(targetClass, sel_registerName("clearCommBreakClicked:"), Marshal.GetFunctionPointerForDelegate(clearCommBreakDelegate), "v@:@");

            setCommBreakDelegate = new ButtonClickIMP(OnSetCommBreakClicked);
            class_addMethod(targetClass, sel_registerName("setCommBreakClicked:"), Marshal.GetFunctionPointerForDelegate(setCommBreakDelegate), "v@:@");

            funcDelegate = new ButtonClickIMP(OnFuncClicked);
            class_addMethod(targetClass, sel_registerName("funcClicked:"), Marshal.GetFunctionPointerForDelegate(funcDelegate), "v@:@");

            flushBuffersDelegate = new ButtonClickIMP(OnFlushBuffersClicked);
            class_addMethod(targetClass, sel_registerName("flushBuffersClicked:"), Marshal.GetFunctionPointerForDelegate(flushBuffersDelegate), "v@:@");

            purgeDelegate = new ButtonClickIMP(OnPurgeClicked);
            class_addMethod(targetClass, sel_registerName("purgeClicked:"), Marshal.GetFunctionPointerForDelegate(purgeDelegate), "v@:@");

            transmitDelegate = new ButtonClickIMP(OnTransmitClicked);
            class_addMethod(targetClass, sel_registerName("transmitClicked:"), Marshal.GetFunctionPointerForDelegate(transmitDelegate), "v@:@");

            sendDelegate = new ButtonClickIMP(OnSendClicked);
            class_addMethod(targetClass, sel_registerName("sendClicked:"), Marshal.GetFunctionPointerForDelegate(sendDelegate), "v@:@");

            clearDelegate = new ButtonClickIMP(OnClearClicked);
            class_addMethod(targetClass, sel_registerName("clearClicked:"), Marshal.GetFunctionPointerForDelegate(clearDelegate), "v@:@");

            shouldTerminateDelegate = new ApplicationShouldTerminateIMP(ShouldTerminateAfterLastWindowClosed);
            class_addMethod(targetClass, sel_registerName("applicationShouldTerminateAfterLastWindowClosed:"), Marshal.GetFunctionPointerForDelegate(shouldTerminateDelegate), "B@:@");

            timerDelegate = new TimerCallbackIMP(OnTimerFired);
            class_addMethod(targetClass, sel_registerName("processLogQueue:"), Marshal.GetFunctionPointerForDelegate(timerDelegate), "v@:@");

            objc_registerClassPair(targetClass);
        }

        target = objc_msgSend_IntPtr(targetClass, sel_registerName("new"));
        // Set target for all buttons
        SetTargetForAllButtons(contentView, target);
        objc_msgSend_void_IntPtr(sharedApp, sel_registerName("setDelegate:"), target);

        // Initialize client and monitor
        client = new wclSerialClient();
        client.OnConnect += ClientConnect;
        client.OnDisconnect += ClientDisconnect;
        client.OnData += ClientData;
        client.OnError += ClientError;
        client.OnReadError += ClientReadError;
        client.OnEvents += ClientEvents;

        monitor = new wclSerialMonitor();

        // Initial enumeration, clear config/timeouts/buffers, set write timeout display
        EnumComPorts();
        ClearConfigFields();
        ClearTimeoutsFields();
        ClearBuffersFields();
        SetTextFieldText(edWriteTimeout, client.WriteTimeout.ToString());

        // Start timer for log updates
        timer = objc_msgSend_IntPtr_Double_IntPtr_IntPtr_IntPtr_byte(
            nsTimerClass,
            sel_registerName("scheduledTimerWithTimeInterval:target:selector:userInfo:repeats:"),
            0.1, target, sel_registerName("processLogQueue:"), IntPtr.Zero, 1);

        // Show window
        objc_msgSend_void_IntPtr(window, sel_registerName("makeKeyAndOrderFront:"), IntPtr.Zero);
        objc_msgSend_void_byte(sharedApp, sel_registerName("activateIgnoringOtherApps:"), 1);

        // Run event loop
        objc_msgSend_void(sharedApp, sel_registerName("run"));

        // Cleanup
        objc_msgSend_void(timer, sel_registerName("invalidate"));
        client.Disconnect();
        monitor.Stop();
        objc_msgSend_void(autoreleasePool, sel_registerName("drain"));
    }

    // ---------- UI Helper Methods ----------
    static void RegisterButtonAction(string selectorName, ButtonClickIMP handler)
    {
        class_addMethod(targetClass, sel_registerName(selectorName), Marshal.GetFunctionPointerForDelegate(handler), "v@:@");
    }

    static void SetTargetForAllButtons(IntPtr view, IntPtr target)
    {
        // Recursively set target for all buttons (only direct subviews for simplicity)
        IntPtr subviews = objc_msgSend_IntPtr(view, sel_registerName("subviews"));
        ulong count = (ulong)objc_msgSend_ulong(subviews, sel_registerName("count"));
        for (ulong i = 0; i < count; i++)
        {
            IntPtr subview = objc_msgSend_IntPtr_ulong(subviews, sel_registerName("objectAtIndex:"), i);
            IntPtr cls = objc_msgSend_IntPtr(subview, sel_registerName("class"));
            IntPtr className = objc_msgSend_IntPtr(cls, sel_registerName("className"));
            string name = FromNSString(className);
            if (name == "NSButton")
            {
                objc_msgSend_void_IntPtr(subview, sel_registerName("setTarget:"), target);
            }
        }
    }

    static IntPtr CreateLabel(double x, double y, double w, double h, string text, IntPtr parent)
    {
        IntPtr labelAlloc = objc_msgSend_IntPtr(objc_getClass("NSTextField"), sel_registerName("alloc"));
        IntPtr label = objc_msgSend_IntPtr_NSRect(labelAlloc, sel_registerName("initWithFrame:"), new NSRect(x, y, w, h));
        objc_msgSend_void_byte(label, sel_registerName("setEditable:"), 0);
        objc_msgSend_void_byte(label, sel_registerName("setBordered:"), 0);
        objc_msgSend_void_byte(label, sel_registerName("setBezeled:"), 0);
        objc_msgSend_void_IntPtr(label, sel_registerName("setBackgroundColor:"), IntPtr.Zero);
        objc_msgSend_void_IntPtr(label, sel_registerName("setStringValue:"), ToNSString(text));
        objc_msgSend_void_IntPtr(parent, sel_registerName("addSubview:"), label);
        return label;
    }

    static IntPtr CreateTextField(double x, double y, double w, double h, IntPtr parent)
    {
        IntPtr fieldAlloc = objc_msgSend_IntPtr(objc_getClass("NSTextField"), sel_registerName("alloc"));
        IntPtr field = objc_msgSend_IntPtr_NSRect(fieldAlloc, sel_registerName("initWithFrame:"), new NSRect(x, y, w, h));
        objc_msgSend_void_IntPtr(parent, sel_registerName("addSubview:"), field);
        return field;
    }

    static IntPtr CreateButton(double x, double y, double w, double h, string title, IntPtr parent, IntPtr actionSelector)
    {
        IntPtr btnAlloc = objc_msgSend_IntPtr(objc_getClass("NSButton"), sel_registerName("alloc"));
        IntPtr btn = objc_msgSend_IntPtr_NSRect(btnAlloc, sel_registerName("initWithFrame:"), new NSRect(x, y, w, h));
        objc_msgSend_void_IntPtr(btn, sel_registerName("setTitle:"), ToNSString(title));
        objc_msgSend_void_IntPtr(btn, sel_registerName("setTarget:"), target); // will be set later after target creation? but target not created yet
        // Actually target will be created later, so we set action now but target later after target exists.
        objc_msgSend_void_IntPtr(btn, sel_registerName("setAction:"), actionSelector);
        objc_msgSend_void_IntPtr(parent, sel_registerName("addSubview:"), btn);
        return btn;
    }

    static IntPtr CreatePopUpButton(double x, double y, double w, double h, IntPtr parent)
    {
        IntPtr popAlloc = objc_msgSend_IntPtr(objc_getClass("NSPopUpButton"), sel_registerName("alloc"));
        IntPtr pop = objc_msgSend_IntPtr_NSRect(popAlloc, sel_registerName("initWithFrame:"), new NSRect(x, y, w, h));
        objc_msgSend_void_IntPtr(parent, sel_registerName("addSubview:"), pop);
        return pop;
    }

    static void AddPopUpItems(IntPtr pop, string[] items)
    {
        objc_msgSend_void(pop, sel_registerName("removeAllItems"));
        foreach (string item in items)
            objc_msgSend_void_IntPtr(pop, sel_registerName("addItemWithTitle:"), ToNSString(item));
    }

    static void SelectPopUpItem(IntPtr pop, int index)
    {
        objc_msgSend_void_long(pop, sel_registerName("selectItemAtIndex:"), index);
    }

    static IntPtr CreateCheckBox(double x, double y, double w, double h, string title, IntPtr parent)
    {
        IntPtr checkAlloc = objc_msgSend_IntPtr(objc_getClass("NSButton"), sel_registerName("alloc"));
        IntPtr check = objc_msgSend_IntPtr_NSRect(checkAlloc, sel_registerName("initWithFrame:"), new NSRect(x, y, w, h));
        objc_msgSend_void_long(check, sel_registerName("setButtonType:"), 1); // switch
        objc_msgSend_void_IntPtr(check, sel_registerName("setTitle:"), ToNSString(title));
        objc_msgSend_void_IntPtr(parent, sel_registerName("addSubview:"), check);
        return check;
    }

    static void SetTextFieldText(IntPtr field, string text)
    {
        objc_msgSend_void_IntPtr(field, sel_registerName("setStringValue:"), ToNSString(text));
    }

    static string GetTextFieldText(IntPtr field)
    {
        IntPtr str = objc_msgSend_IntPtr(field, sel_registerName("stringValue"));
        return FromNSString(str);
    }

    static int GetPopUpSelectedIndex(IntPtr pop)
    {
        return (int)objc_msgSend_long(pop, sel_registerName("indexOfSelectedItem"));
    }

    static bool GetCheckBoxState(IntPtr check)
    {
        return objc_msgSend_long(check, sel_registerName("state")) == 1;
    }

    static void SetCheckBoxState(IntPtr check, bool on)
    {
        objc_msgSend_void_long(check, sel_registerName("setState:"), on ? 1 : 0);
    }

    // ---------- Business logic (from Pascal) ----------
    static void EnumComPorts()
    {
        List<wclSerialDevice> devices;
        int res = monitor.EnumSerialDevices(out devices);
        objc_msgSend_void(cbPorts, sel_registerName("removeAllItems"));
        if (res != wclErrors.WCL_E_SUCCESS)
        {
            AddLog("Error enumerating COM ports: 0x" + res.ToString("X8"));
        }
        else
        {
            foreach (var dev in devices)
                objc_msgSend_void_IntPtr(cbPorts, sel_registerName("addItemWithTitle:"), ToNSString(dev.DeviceName));
            if (devices.Count > 0)
                SelectPopUpItem(cbPorts, 0);
            else
                SelectPopUpItem(cbPorts, -1);
        }
    }

    static void ReadConfiguration()
    {
        wclSerialConfig config;
        int res = client.GetConfig(out config);
        if (res != wclErrors.WCL_E_SUCCESS)
        {
            AddLog("Read configuration error: 0x" + res.ToString("X8"));
            return;
        }
        SetTextFieldText(edBaudRate, config.BaudRate.ToString());
        SetTextFieldText(edXonLim, config.XonLim.ToString());
        SetTextFieldText(edXoffLim, config.XoffLim.ToString());
        SetTextFieldText(edXonChar, ((int)config.XonChar).ToString());
        SetTextFieldText(edXoffChar, ((int)config.XoffChar).ToString());
        SetTextFieldText(edErrorChar, ((int)config.ErrorChar).ToString());
        SetTextFieldText(edEofChar, ((int)config.EofChar).ToString());
        SetTextFieldText(edEvtChar, ((int)config.EvtChar).ToString());

        SetCheckBoxState(cbParityCheck, config.ParityCheck);
        SetCheckBoxState(cbOutxCtsFlow, config.OutxCtsFlow);
        SetCheckBoxState(cbOutxDsrFlow, config.OutxDsrFlow);
        SetCheckBoxState(cbDsrSensitivity, config.DsrSensitivity);
        SetCheckBoxState(cbTXContinueOnXoff, config.TxContinueOnXoff);
        SetCheckBoxState(cbOutX, config.OutX);
        SetCheckBoxState(cbInX, config.InX);
        SetCheckBoxState(cbErrorCharReplace, config.ErrorCharReplace);
        SetCheckBoxState(cbNullStrip, config.NullStrip);
        SetCheckBoxState(cbAbortOnError, config.AbortOnError);

        SelectPopUpItem(cbRtsControl, RtsControlToIndex(config.RtsControl));
        SelectPopUpItem(cbDtrControl, DtrControlToIndex(config.DtrControl));
        SelectPopUpItem(cbParity, ParityToIndex(config.Parity));
        SelectPopUpItem(cbStopBits, StopBitsToIndex(config.StopBits));
        SelectPopUpItem(cbByteSize, config.ByteSize - 4);
    }

    static void ReadTimeouts()
    {
        wclSerialTimeouts times;
        int res = client.GetTimeouts(out times);
        if (res != wclErrors.WCL_E_SUCCESS)
        {
            AddLog("Get timeouts error: 0x" + res.ToString("X8"));
            return;
        }
        SetTextFieldText(edReadInterval, times.ReadInterval.ToString());
        SetTextFieldText(edReadMultiplier, times.ReadMultiplier.ToString());
        SetTextFieldText(edReadConstant, times.ReadConstant.ToString());
        SetTextFieldText(edWriteMultiplier, times.WriteMultiplier.ToString());
        SetTextFieldText(edWriteConstant, times.WriteConstant.ToString());
    }

    static void ReadBuffers()
    {
        uint size;
        int res = client.GetReadBufferSize(out size);
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Get read buffer size error: 0x" + res.ToString("X8"));
        else
            SetTextFieldText(edReadBufferSize, size.ToString());

        res = client.GetWriteBufferSize(out size);
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Get write buffer size error: 0x" + res.ToString("X8"));
        else
            SetTextFieldText(edWriteBufferSize, size.ToString());
    }

    static void ClearConfigFields()
    {
        SetTextFieldText(edBaudRate, "");
        SetTextFieldText(edXonLim, "");
        SetTextFieldText(edXoffLim, "");
        SetTextFieldText(edXonChar, "");
        SetTextFieldText(edXoffChar, "");
        SetTextFieldText(edErrorChar, "");
        SetTextFieldText(edEofChar, "");
        SetTextFieldText(edEvtChar, "");
        SetCheckBoxState(cbParityCheck, false);
        SetCheckBoxState(cbOutxCtsFlow, false);
        SetCheckBoxState(cbOutxDsrFlow, false);
        SetCheckBoxState(cbDsrSensitivity, false);
        SetCheckBoxState(cbTXContinueOnXoff, false);
        SetCheckBoxState(cbOutX, false);
        SetCheckBoxState(cbInX, false);
        SetCheckBoxState(cbErrorCharReplace, false);
        SetCheckBoxState(cbNullStrip, false);
        SetCheckBoxState(cbAbortOnError, false);
        SelectPopUpItem(cbRtsControl, -1);
        SelectPopUpItem(cbDtrControl, -1);
        SelectPopUpItem(cbByteSize, -1);
        SelectPopUpItem(cbParity, -1);
        SelectPopUpItem(cbStopBits, -1);
    }

    static void ClearTimeoutsFields()
    {
        SetTextFieldText(edReadInterval, "");
        SetTextFieldText(edReadMultiplier, "");
        SetTextFieldText(edReadConstant, "");
        SetTextFieldText(edWriteMultiplier, "");
        SetTextFieldText(edWriteConstant, "");
    }

    static void ClearBuffersFields()
    {
        SetTextFieldText(edReadBufferSize, "");
        SetTextFieldText(edWriteBufferSize, "");
    }

    static int DtrControlToIndex(wclSerialDtrControl ctrl)
    {
        switch (ctrl) { case wclSerialDtrControl.dtrControlDisable: return 0; case wclSerialDtrControl.dtrControlEnable: return 1; case wclSerialDtrControl.dtrControlHandshake: return 2; default: return -1; }
    }
    static wclSerialDtrControl IndexToDtrControl(int idx)
    {
        switch (idx) { case 0: return wclSerialDtrControl.dtrControlDisable; case 1: return wclSerialDtrControl.dtrControlEnable; case 2: return wclSerialDtrControl.dtrControlHandshake; default: return wclSerialDtrControl.dtrControlDisable; }
    }
    static int RtsControlToIndex(wclSerialRtsControl ctrl)
    {
        switch (ctrl) { case wclSerialRtsControl.rtsControlDisable: return 0; case wclSerialRtsControl.rtsControlEnable: return 1; case wclSerialRtsControl.rtsControlHandshake: return 2; case wclSerialRtsControl.rtsControlToggle: return 3; default: return -1; }
    }
    static wclSerialRtsControl IndexToRtsControl(int idx)
    {
        switch (idx) { case 0: return wclSerialRtsControl.rtsControlDisable; case 1: return wclSerialRtsControl.rtsControlEnable; case 2: return wclSerialRtsControl.rtsControlHandshake; case 3: return wclSerialRtsControl.rtsControlToggle; default: return wclSerialRtsControl.rtsControlDisable; }
    }
    static int ParityToIndex(wclSerialParity parity)
    {
        switch (parity) { case wclSerialParity.spNo: return 0; case wclSerialParity.spOdd: return 1; case wclSerialParity.spEven: return 2; case wclSerialParity.spMark: return 3; case wclSerialParity.spSpace: return 4; default: return -1; }
    }
    static wclSerialParity IndexToParity(int idx)
    {
        switch (idx) { case 0: return wclSerialParity.spNo; case 1: return wclSerialParity.spOdd; case 2: return wclSerialParity.spEven; case 3: return wclSerialParity.spMark; case 4: return wclSerialParity.spSpace; default: return wclSerialParity.spNo; }
    }
    static int StopBitsToIndex(wclSerialStopBits sb)
    {
        switch (sb) { case wclSerialStopBits.sbOne: return 0; case wclSerialStopBits.sbOne5: return 1; case wclSerialStopBits.sbTwo: return 2; default: return -1; }
    }
    static wclSerialStopBits IndexToStopBits(int idx)
    {
        switch (idx) { case 0: return wclSerialStopBits.sbOne; case 1: return wclSerialStopBits.sbOne5; case 2: return wclSerialStopBits.sbTwo; default: return wclSerialStopBits.sbOne; }
    }

    // ---------- Event Handlers (button actions) ----------
    static void OnEnumClicked(IntPtr self, IntPtr cmd, IntPtr sender) { EnumComPorts(); }
    static void OnConnectClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        if (GetPopUpSelectedIndex(cbPorts) == -1)
            ShowAlert("Warning", "Select COM port");
        else
        {
            string device = FromNSString(objc_msgSend_IntPtr(cbPorts, sel_registerName("titleOfSelectedItem")));
            int res = client.Connect(device, wclMessageProcessingMethod.mpAsync);
            if (res != wclErrors.WCL_E_SUCCESS)
                ShowAlert("Error", "0x" + res.ToString("X8"));
        }
    }
    static void OnDisconnectClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = client.Disconnect();
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnGetConfigClicked(IntPtr self, IntPtr cmd, IntPtr sender) { ReadConfiguration(); }
    static void OnSetConfigClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        wclSerialConfig config = new wclSerialConfig();
        try
        {
            config.BaudRate = Convert.ToUInt32(GetTextFieldText(edBaudRate));
            config.XonLim = Convert.ToUInt16(GetTextFieldText(edXonLim));
            config.XoffLim = Convert.ToUInt16(GetTextFieldText(edXoffLim));
            config.XonChar = Convert.ToByte(GetTextFieldText(edXonChar));
            config.XoffChar = Convert.ToByte(GetTextFieldText(edXoffChar));
            config.ErrorChar = Convert.ToByte(GetTextFieldText(edErrorChar));
            config.EofChar = Convert.ToByte(GetTextFieldText(edEofChar));
            config.EvtChar = Convert.ToByte(GetTextFieldText(edEvtChar));
            config.ParityCheck = GetCheckBoxState(cbParityCheck);
            config.OutxCtsFlow = GetCheckBoxState(cbOutxCtsFlow);
            config.OutxDsrFlow = GetCheckBoxState(cbOutxDsrFlow);
            config.DsrSensitivity = GetCheckBoxState(cbDsrSensitivity);
            config.TxContinueOnXoff = GetCheckBoxState(cbTXContinueOnXoff);
            config.OutX = GetCheckBoxState(cbOutX);
            config.InX = GetCheckBoxState(cbInX);
            config.ErrorCharReplace = GetCheckBoxState(cbErrorCharReplace);
            config.NullStrip = GetCheckBoxState(cbNullStrip);
            config.AbortOnError = GetCheckBoxState(cbAbortOnError);
            config.RtsControl = IndexToRtsControl(GetPopUpSelectedIndex(cbRtsControl));
            config.DtrControl = IndexToDtrControl(GetPopUpSelectedIndex(cbDtrControl));
            config.Parity = IndexToParity(GetPopUpSelectedIndex(cbParity));
            config.StopBits = IndexToStopBits(GetPopUpSelectedIndex(cbStopBits));
            config.ByteSize = (Byte)(GetPopUpSelectedIndex(cbByteSize) + 4);
        }
        catch (Exception ex) { ShowAlert("Error", "Invalid input: " + ex.Message); return; }

        int res = client.SetConfig(config);
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnGetBuffersClicked(IntPtr self, IntPtr cmd, IntPtr sender) { ReadBuffers(); }
    static void OnSetBuffersClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        try
        {
            UInt32 readSize = Convert.ToUInt32(GetTextFieldText(edReadBufferSize));
            int res = client.SetReadBufferSize(readSize);
            if (res != wclErrors.WCL_E_SUCCESS)
                AddLog("Set read buffer size error: 0x" + res.ToString("X8"));
            UInt32 writeSize = Convert.ToUInt32(GetTextFieldText(edWriteBufferSize));
            res = client.SetWriteBufferSize(writeSize);
            if (res != wclErrors.WCL_E_SUCCESS)
                AddLog("Set write buffer size error: 0x" + res.ToString("X8"));
        }
        catch (Exception ex) { AddLog("Invalid buffer size: " + ex.Message); }
    }
    static void OnGetTimeoutsClicked(IntPtr self, IntPtr cmd, IntPtr sender) { ReadTimeouts(); }
    static void OnSetTimeoutsClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        wclSerialTimeouts times = new wclSerialTimeouts();
        try
        {
            times.ReadInterval = Convert.ToUInt32(GetTextFieldText(edReadInterval));
            times.ReadMultiplier = Convert.ToUInt32(GetTextFieldText(edReadMultiplier));
            times.ReadConstant = Convert.ToUInt32(GetTextFieldText(edReadConstant));
            times.WriteMultiplier = Convert.ToUInt32(GetTextFieldText(edWriteMultiplier));
            times.WriteConstant = Convert.ToUInt32(GetTextFieldText(edWriteConstant));
        }
        catch (Exception ex) { AddLog("Invalid timeout value: " + ex.Message); return; }
        int res = client.SetTimeouts(times);
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Set timeouts error: 0x" + res.ToString("X8"));
    }
    static void OnSetWriteTimeoutClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        try { client.WriteTimeout = Convert.ToUInt32(GetTextFieldText(edWriteTimeout)); }
        catch (Exception ex) { ShowAlert("Error", "Invalid write timeout: " + ex.Message); }
    }
    static void OnClearCommBreakClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = client.ClearCommBreak();
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnSetCommBreakClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = client.SetCommBreak();
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnFuncClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int idx = GetPopUpSelectedIndex(cbFunc);
        wclSerialEscapeFunction func = (wclSerialEscapeFunction)idx;
        int res = client.EscapeCommFunction(func);
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnFlushBuffersClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        int res = client.FlushBuffers();
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnPurgeClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        wclSerialPurgeFlag flags = 0;
        if (GetCheckBoxState(cbpurgeRxAbort)) flags |= wclSerialPurgeFlag.purgeRxAbort;
        if (GetCheckBoxState(cbpurgeRxClear)) flags |= wclSerialPurgeFlag.purgeRxClear;
        if (GetCheckBoxState(cbpurgeTxAbort)) flags |= wclSerialPurgeFlag.purgeTxAbort;
        if (GetCheckBoxState(cbpurgeTxClear)) flags |= wclSerialPurgeFlag.purgeTxClear;
        int res = client.PurgeComm(flags);
        if (res != wclErrors.WCL_E_SUCCESS)
            ShowAlert("Error", "0x" + res.ToString("X8"));
    }
    static void OnTransmitClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        try
        {
            byte b = (byte)Convert.ToInt32(GetTextFieldText(edChar));
            int res = client.TransmitCommChar(b);
            if (res != wclErrors.WCL_E_SUCCESS)
                ShowAlert("Error", "0x" + res.ToString("X8"));
        }
        catch (Exception ex) { ShowAlert("Error", "Invalid char code: " + ex.Message); }
    }
    static void OnSendClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        string text = GetTextFieldText(edText);
        int lf = GetPopUpSelectedIndex(cbLineFeed);
        switch (lf)
        {
            case 1: text += "\r"; break;
            case 2: text += "\n"; break;
            case 3: text += "\r\n"; break;
        }
        byte[] data = Encoding.ASCII.GetBytes(text);
        uint written;
        int res = client.Write(data, out written);
        AddLog($"Sent: {written} bytes from {data.Length}");
        if (res != wclErrors.WCL_E_SUCCESS)
            AddLog("Write error: 0x" + res.ToString("X8"));
    }
    static void OnClearClicked(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        logText.Clear();
        SetOutputText("");
    }

    // ---------- Client event handlers (thread-safe via queue) ----------
    static void ClientConnect(object sender, int error)
    {
        if (error == wclErrors.WCL_E_SUCCESS)
        {
            AddLog("Connected to Serial Device: " + client.DeviceName);
            ReadConfiguration();
            ReadTimeouts();
            ReadBuffers();
        }
        else
            AddLog("Connect error: 0x" + error.ToString("X8"));
    }
    static void ClientDisconnect(object sender, int reason)
    {
        AddLog("Disconnected: 0x" + reason.ToString("X8"));
        ClearConfigFields();
        ClearTimeoutsFields();
        ClearBuffersFields();
    }
    static void ClientData(object sender, byte[] data)
    {
        if (data != null && data.Length > 0)
        {
            string str = Encoding.ASCII.GetString(data);
            AddLog($"Received [{data.Length}]: {str}");
        }
        else
            AddLog("Empty data received");
    }
    static void ClientError(object sender, wclSerialError errors, wclSerialCommunicationState states)
    {
        string err = "";
        if ((errors & wclSerialError.erBreak) != 0) err += "erBreak ";
        if ((errors & wclSerialError.erFrame) != 0) err += "erFrame ";
        if ((errors & wclSerialError.erOverrun) != 0) err += "erOverrun ";
        if ((errors & wclSerialError.erRxOver) != 0) err += "erRxOver ";
        if ((errors & wclSerialError.erRxParity) != 0) err += "erRxParity ";
        if (err != "") AddLog("Error: " + err);

        string st = "";
        if ((states & wclSerialCommunicationState.csCtsHold) != 0) st += "csCtsHold ";
        if ((states & wclSerialCommunicationState.csDsrHold) != 0) st += "csDsrHold ";
        if ((states & wclSerialCommunicationState.csRlsdHold) != 0) st += "csRlsdHold ";
        if ((states & wclSerialCommunicationState.csXoffHold) != 0) st += "csXoffHold ";
        if ((states & wclSerialCommunicationState.csXoffSent) != 0) st += "csXoffSent ";
        if ((states & wclSerialCommunicationState.csEof) != 0) st += "csEof ";
        if ((states & wclSerialCommunicationState.csTxim) != 0) st += "csTxim ";
        if (st != "") AddLog("States: " + st);
    }
    static void ClientReadError(object sender, int error)
    {
        AddLog("Read error: 0x" + error.ToString("X8"));
    }
    static void ClientEvents(object sender, wclSerialEvent events)
    {
        string ev = "";
        if ((events & wclSerialEvent.evBreak) != 0) ev += "evBreak ";
        if ((events & wclSerialEvent.evCts) != 0) ev += "evCts ";
        if ((events & wclSerialEvent.evDsr) != 0) ev += "evDsr ";
        if ((events & wclSerialEvent.evRing) != 0) ev += "evRing ";
        if ((events & wclSerialEvent.evRlsd) != 0) ev += "evRlsd ";
        if ((events & wclSerialEvent.evChar) != 0) ev += "evChar ";
        if (ev != "") AddLog("Event: " + ev);

        if (events != 0)
        {
            wclModemStatus status;
            int res = client.GetModemStatus(out status);
            if (res != wclErrors.WCL_E_SUCCESS)
                AddLog("GetModemStatus error: 0x" + res.ToString("X8"));
            else
            {
                string st = "";
                if ((status & wclModemStatus.msCtsOn) != 0) st += "msCtsOn ";
                if ((status & wclModemStatus.msDsrOn) != 0) st += "msDsrOn ";
                if ((status & wclModemStatus.msRingOn) != 0) st += "msRingOn ";
                if ((status & wclModemStatus.msRlsdOn) != 0) st += "msRlsdOn ";
                if (st != "") AddLog("Modem status: " + st);
            }
        }
    }

    // ---------- Logging ----------
    static void AddLog(string message)
    {
        logQueue.Enqueue(message);
    }

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
        objc_msgSend_void_IntPtr(logTextView, sel_registerName("setString:"), ToNSString(text));
    }

    static void ShowAlert(string title, string message)
    {
        IntPtr alertClass = objc_getClass("NSAlert");
        IntPtr alert = objc_msgSend_IntPtr(alertClass, sel_registerName("new"));
        objc_msgSend_void_IntPtr(alert, sel_registerName("setMessageText:"), ToNSString(title));
        objc_msgSend_void_IntPtr(alert, sel_registerName("setInformativeText:"), ToNSString(message));
        objc_msgSend_long(alert, sel_registerName("runModal"));
    }

    static byte ShouldTerminateAfterLastWindowClosed(IntPtr self, IntPtr cmd, IntPtr sender)
    {
        client.Disconnect();
        monitor.Stop();
        return 1;
    }

    // ---------- String conversion ----------
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

    // ---------- Native imports ----------
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
    static extern ulong objc_msgSend_ulong(IntPtr receiver, IntPtr selector);
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
    [DllImport(LibObjC, EntryPoint = "objc_msgSend")]
    static extern IntPtr objc_msgSend_IntPtr_ulong(IntPtr receiver, IntPtr selector, ulong arg1);
}