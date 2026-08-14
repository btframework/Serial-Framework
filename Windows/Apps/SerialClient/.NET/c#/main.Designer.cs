namespace SerialClient
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btEnum = new System.Windows.Forms.Button();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.laWriteTimeout = new System.Windows.Forms.Label();
            this.edWriteTimeout = new System.Windows.Forms.TextBox();
            this.btSetWriteTimeout = new System.Windows.Forms.Button();
            this.btGetConfig = new System.Windows.Forms.Button();
            this.btSetConfig = new System.Windows.Forms.Button();
            this.laBaudRate = new System.Windows.Forms.Label();
            this.edBaudRate = new System.Windows.Forms.TextBox();
            this.cbRtsControl = new System.Windows.Forms.ComboBox();
            this.laRtsControl = new System.Windows.Forms.Label();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.laParity = new System.Windows.Forms.Label();
            this.edXonLim = new System.Windows.Forms.TextBox();
            this.laXonLim = new System.Windows.Forms.Label();
            this.cbDtrControl = new System.Windows.Forms.ComboBox();
            this.laDtrControl = new System.Windows.Forms.Label();
            this.cbByteSize = new System.Windows.Forms.ComboBox();
            this.laByteSize = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.laStopBites = new System.Windows.Forms.Label();
            this.edXoffLim = new System.Windows.Forms.TextBox();
            this.laXoffLim = new System.Windows.Forms.Label();
            this.laXonChar = new System.Windows.Forms.Label();
            this.edXonChar = new System.Windows.Forms.TextBox();
            this.laXoffChar = new System.Windows.Forms.Label();
            this.edXoffChar = new System.Windows.Forms.TextBox();
            this.laErrorChar = new System.Windows.Forms.Label();
            this.edErrorChar = new System.Windows.Forms.TextBox();
            this.laEofChar = new System.Windows.Forms.Label();
            this.edEofChar = new System.Windows.Forms.TextBox();
            this.laEvtChar = new System.Windows.Forms.Label();
            this.edEvtChar = new System.Windows.Forms.TextBox();
            this.cbParityCheck = new System.Windows.Forms.CheckBox();
            this.cbOutxDsrFlow = new System.Windows.Forms.CheckBox();
            this.cbTXContinueOnXoff = new System.Windows.Forms.CheckBox();
            this.cbErrorCharReplace = new System.Windows.Forms.CheckBox();
            this.cbNullStrip = new System.Windows.Forms.CheckBox();
            this.cbOutxCtsFlow = new System.Windows.Forms.CheckBox();
            this.cbDsrSensitivity = new System.Windows.Forms.CheckBox();
            this.cbOutX = new System.Windows.Forms.CheckBox();
            this.cbInX = new System.Windows.Forms.CheckBox();
            this.cbAbortOnError = new System.Windows.Forms.CheckBox();
            this.btGetBuffers = new System.Windows.Forms.Button();
            this.btSetBuffers = new System.Windows.Forms.Button();
            this.laReadBufferSize = new System.Windows.Forms.Label();
            this.edReadBufferSize = new System.Windows.Forms.TextBox();
            this.edWriteBufferSize = new System.Windows.Forms.TextBox();
            this.laWriteBufferSize = new System.Windows.Forms.Label();
            this.btGetTimeouts = new System.Windows.Forms.Button();
            this.btSetTimeouts = new System.Windows.Forms.Button();
            this.edReadInterval = new System.Windows.Forms.TextBox();
            this.edReadMultiplier = new System.Windows.Forms.TextBox();
            this.edReadConstant = new System.Windows.Forms.TextBox();
            this.edWriteMultiplier = new System.Windows.Forms.TextBox();
            this.edWriteConstant = new System.Windows.Forms.TextBox();
            this.laReadInterval = new System.Windows.Forms.Label();
            this.laReadMultiplier = new System.Windows.Forms.Label();
            this.laReadConstant = new System.Windows.Forms.Label();
            this.laWriteMultiplier = new System.Windows.Forms.Label();
            this.laWriteConstant = new System.Windows.Forms.Label();
            this.btClearCommBreak = new System.Windows.Forms.Button();
            this.btSetCommBreak = new System.Windows.Forms.Button();
            this.cbFunc = new System.Windows.Forms.ComboBox();
            this.laFunc = new System.Windows.Forms.Label();
            this.btFunc = new System.Windows.Forms.Button();
            this.cbPurgeRxAbort = new System.Windows.Forms.CheckBox();
            this.cbPurgeRxClear = new System.Windows.Forms.CheckBox();
            this.cbPurgeTxAbort = new System.Windows.Forms.CheckBox();
            this.cbPurgeTxClear = new System.Windows.Forms.CheckBox();
            this.btPurge = new System.Windows.Forms.Button();
            this.edChar = new System.Windows.Forms.TextBox();
            this.btTransmit = new System.Windows.Forms.Button();
            this.laCharCode = new System.Windows.Forms.Label();
            this.btFlushBuffers = new System.Windows.Forms.Button();
            this.edText = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.laLineFeed = new System.Windows.Forms.Label();
            this.cbLineFeed = new System.Windows.Forms.ComboBox();
            this.btClear = new System.Windows.Forms.Button();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btEnum
            // 
            this.btEnum.Location = new System.Drawing.Point(12, 12);
            this.btEnum.Name = "btEnum";
            this.btEnum.Size = new System.Drawing.Size(75, 23);
            this.btEnum.TabIndex = 0;
            this.btEnum.Text = "Enum";
            this.btEnum.UseVisualStyleBackColor = true;
            this.btEnum.Click += new System.EventHandler(this.btEnumClick);
            // 
            // cbPorts
            // 
            this.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(93, 14);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(112, 21);
            this.cbPorts.TabIndex = 1;
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(211, 12);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 2;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnectClick);
            // 
            // btDisconnect
            // 
            this.btDisconnect.Location = new System.Drawing.Point(292, 12);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btDisconnect.TabIndex = 3;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnectClick);
            // 
            // laWriteTimeout
            // 
            this.laWriteTimeout.AutoSize = true;
            this.laWriteTimeout.Location = new System.Drawing.Point(373, 17);
            this.laWriteTimeout.Name = "laWriteTimeout";
            this.laWriteTimeout.Size = new System.Drawing.Size(69, 13);
            this.laWriteTimeout.TabIndex = 4;
            this.laWriteTimeout.Text = "Write timeout";
            // 
            // edWriteTimeout
            // 
            this.edWriteTimeout.Location = new System.Drawing.Point(448, 14);
            this.edWriteTimeout.Name = "edWriteTimeout";
            this.edWriteTimeout.Size = new System.Drawing.Size(100, 20);
            this.edWriteTimeout.TabIndex = 5;
            // 
            // btSetWriteTimeout
            // 
            this.btSetWriteTimeout.Location = new System.Drawing.Point(554, 12);
            this.btSetWriteTimeout.Name = "btSetWriteTimeout";
            this.btSetWriteTimeout.Size = new System.Drawing.Size(104, 23);
            this.btSetWriteTimeout.TabIndex = 6;
            this.btSetWriteTimeout.Text = "Set write timeout";
            this.btSetWriteTimeout.UseVisualStyleBackColor = true;
            this.btSetWriteTimeout.Click += new System.EventHandler(this.btSetWriteTimeoutClick);
            // 
            // btGetConfig
            // 
            this.btGetConfig.Location = new System.Drawing.Point(12, 54);
            this.btGetConfig.Name = "btGetConfig";
            this.btGetConfig.Size = new System.Drawing.Size(75, 23);
            this.btGetConfig.TabIndex = 7;
            this.btGetConfig.Text = "Get config";
            this.btGetConfig.UseVisualStyleBackColor = true;
            this.btGetConfig.Click += new System.EventHandler(this.btGetConfigClick);
            // 
            // btSetConfig
            // 
            this.btSetConfig.Location = new System.Drawing.Point(93, 54);
            this.btSetConfig.Name = "btSetConfig";
            this.btSetConfig.Size = new System.Drawing.Size(75, 23);
            this.btSetConfig.TabIndex = 8;
            this.btSetConfig.Text = "Set config";
            this.btSetConfig.UseVisualStyleBackColor = true;
            this.btSetConfig.Click += new System.EventHandler(this.btSetConfigClick);
            // 
            // laBaudRate
            // 
            this.laBaudRate.AutoSize = true;
            this.laBaudRate.Location = new System.Drawing.Point(12, 86);
            this.laBaudRate.Name = "laBaudRate";
            this.laBaudRate.Size = new System.Drawing.Size(50, 13);
            this.laBaudRate.TabIndex = 9;
            this.laBaudRate.Text = "Baudrate";
            // 
            // edBaudRate
            // 
            this.edBaudRate.Location = new System.Drawing.Point(82, 83);
            this.edBaudRate.Name = "edBaudRate";
            this.edBaudRate.Size = new System.Drawing.Size(121, 20);
            this.edBaudRate.TabIndex = 10;
            // 
            // cbRtsControl
            // 
            this.cbRtsControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRtsControl.FormattingEnabled = true;
            this.cbRtsControl.Items.AddRange(new object[] {
            "rtsControlDisable",
            "rtsControlEnable",
            "rtsControlHandshake",
            "rtsControlToggle"});
            this.cbRtsControl.Location = new System.Drawing.Point(82, 109);
            this.cbRtsControl.Name = "cbRtsControl";
            this.cbRtsControl.Size = new System.Drawing.Size(121, 21);
            this.cbRtsControl.TabIndex = 11;
            // 
            // laRtsControl
            // 
            this.laRtsControl.AutoSize = true;
            this.laRtsControl.Location = new System.Drawing.Point(12, 112);
            this.laRtsControl.Name = "laRtsControl";
            this.laRtsControl.Size = new System.Drawing.Size(64, 13);
            this.laRtsControl.TabIndex = 12;
            this.laRtsControl.Text = "RTS control";
            // 
            // cbParity
            // 
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "spNo",
            "spOdd",
            "spEven",
            "spMark",
            "spSpace"});
            this.cbParity.Location = new System.Drawing.Point(82, 136);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 21);
            this.cbParity.TabIndex = 13;
            // 
            // laParity
            // 
            this.laParity.AutoSize = true;
            this.laParity.Location = new System.Drawing.Point(12, 139);
            this.laParity.Name = "laParity";
            this.laParity.Size = new System.Drawing.Size(33, 13);
            this.laParity.TabIndex = 14;
            this.laParity.Text = "Parity";
            // 
            // edXonLim
            // 
            this.edXonLim.Location = new System.Drawing.Point(82, 163);
            this.edXonLim.Name = "edXonLim";
            this.edXonLim.Size = new System.Drawing.Size(121, 20);
            this.edXonLim.TabIndex = 15;
            // 
            // laXonLim
            // 
            this.laXonLim.AutoSize = true;
            this.laXonLim.Location = new System.Drawing.Point(12, 166);
            this.laXonLim.Name = "laXonLim";
            this.laXonLim.Size = new System.Drawing.Size(45, 13);
            this.laXonLim.TabIndex = 16;
            this.laXonLim.Text = "XON lim";
            // 
            // cbDtrControl
            // 
            this.cbDtrControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDtrControl.FormattingEnabled = true;
            this.cbDtrControl.Items.AddRange(new object[] {
            "dtrControlDisable",
            "dtrControlEnable",
            "dtrControlHandshake"});
            this.cbDtrControl.Location = new System.Drawing.Point(280, 83);
            this.cbDtrControl.Name = "cbDtrControl";
            this.cbDtrControl.Size = new System.Drawing.Size(121, 21);
            this.cbDtrControl.TabIndex = 17;
            // 
            // laDtrControl
            // 
            this.laDtrControl.AutoSize = true;
            this.laDtrControl.Location = new System.Drawing.Point(209, 86);
            this.laDtrControl.Name = "laDtrControl";
            this.laDtrControl.Size = new System.Drawing.Size(65, 13);
            this.laDtrControl.TabIndex = 18;
            this.laDtrControl.Text = "DTR control";
            // 
            // cbByteSize
            // 
            this.cbByteSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbByteSize.FormattingEnabled = true;
            this.cbByteSize.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbByteSize.Location = new System.Drawing.Point(280, 109);
            this.cbByteSize.Name = "cbByteSize";
            this.cbByteSize.Size = new System.Drawing.Size(121, 21);
            this.cbByteSize.TabIndex = 19;
            // 
            // laByteSize
            // 
            this.laByteSize.AutoSize = true;
            this.laByteSize.Location = new System.Drawing.Point(209, 112);
            this.laByteSize.Name = "laByteSize";
            this.laByteSize.Size = new System.Drawing.Size(49, 13);
            this.laByteSize.TabIndex = 20;
            this.laByteSize.Text = "Byte size";
            // 
            // cbStopBits
            // 
            this.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "sbOne",
            "sbOne5",
            "sbTwo"});
            this.cbStopBits.Location = new System.Drawing.Point(280, 136);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cbStopBits.TabIndex = 21;
            // 
            // laStopBites
            // 
            this.laStopBites.AutoSize = true;
            this.laStopBites.Location = new System.Drawing.Point(209, 139);
            this.laStopBites.Name = "laStopBites";
            this.laStopBites.Size = new System.Drawing.Size(48, 13);
            this.laStopBites.TabIndex = 22;
            this.laStopBites.Text = "Stop bits";
            // 
            // edXoffLim
            // 
            this.edXoffLim.Location = new System.Drawing.Point(280, 163);
            this.edXoffLim.Name = "edXoffLim";
            this.edXoffLim.Size = new System.Drawing.Size(121, 20);
            this.edXoffLim.TabIndex = 23;
            // 
            // laXoffLim
            // 
            this.laXoffLim.AutoSize = true;
            this.laXoffLim.Location = new System.Drawing.Point(209, 166);
            this.laXoffLim.Name = "laXoffLim";
            this.laXoffLim.Size = new System.Drawing.Size(49, 13);
            this.laXoffLim.TabIndex = 24;
            this.laXoffLim.Text = "XOFF lim";
            // 
            // laXonChar
            // 
            this.laXonChar.AutoSize = true;
            this.laXonChar.Location = new System.Drawing.Point(12, 192);
            this.laXonChar.Name = "laXonChar";
            this.laXonChar.Size = new System.Drawing.Size(30, 13);
            this.laXonChar.TabIndex = 25;
            this.laXonChar.Text = "XON";
            // 
            // edXonChar
            // 
            this.edXonChar.Location = new System.Drawing.Point(48, 189);
            this.edXonChar.Name = "edXonChar";
            this.edXonChar.Size = new System.Drawing.Size(29, 20);
            this.edXonChar.TabIndex = 26;
            // 
            // laXoffChar
            // 
            this.laXoffChar.AutoSize = true;
            this.laXoffChar.Location = new System.Drawing.Point(89, 192);
            this.laXoffChar.Name = "laXoffChar";
            this.laXoffChar.Size = new System.Drawing.Size(34, 13);
            this.laXoffChar.TabIndex = 27;
            this.laXoffChar.Text = "XOFF";
            // 
            // edXoffChar
            // 
            this.edXoffChar.Location = new System.Drawing.Point(129, 189);
            this.edXoffChar.Name = "edXoffChar";
            this.edXoffChar.Size = new System.Drawing.Size(29, 20);
            this.edXoffChar.TabIndex = 28;
            // 
            // laErrorChar
            // 
            this.laErrorChar.AutoSize = true;
            this.laErrorChar.Location = new System.Drawing.Point(175, 192);
            this.laErrorChar.Name = "laErrorChar";
            this.laErrorChar.Size = new System.Drawing.Size(29, 13);
            this.laErrorChar.TabIndex = 29;
            this.laErrorChar.Text = "Error";
            // 
            // edErrorChar
            // 
            this.edErrorChar.Location = new System.Drawing.Point(210, 189);
            this.edErrorChar.Name = "edErrorChar";
            this.edErrorChar.Size = new System.Drawing.Size(29, 20);
            this.edErrorChar.TabIndex = 30;
            // 
            // laEofChar
            // 
            this.laEofChar.AutoSize = true;
            this.laEofChar.Location = new System.Drawing.Point(257, 192);
            this.laEofChar.Name = "laEofChar";
            this.laEofChar.Size = new System.Drawing.Size(28, 13);
            this.laEofChar.TabIndex = 31;
            this.laEofChar.Text = "EOF";
            // 
            // edEofChar
            // 
            this.edEofChar.Location = new System.Drawing.Point(291, 189);
            this.edEofChar.Name = "edEofChar";
            this.edEofChar.Size = new System.Drawing.Size(29, 20);
            this.edEofChar.TabIndex = 32;
            // 
            // laEvtChar
            // 
            this.laEvtChar.AutoSize = true;
            this.laEvtChar.Location = new System.Drawing.Point(338, 192);
            this.laEvtChar.Name = "laEvtChar";
            this.laEvtChar.Size = new System.Drawing.Size(28, 13);
            this.laEvtChar.TabIndex = 33;
            this.laEvtChar.Text = "EVT";
            // 
            // edEvtChar
            // 
            this.edEvtChar.Location = new System.Drawing.Point(372, 189);
            this.edEvtChar.Name = "edEvtChar";
            this.edEvtChar.Size = new System.Drawing.Size(29, 20);
            this.edEvtChar.TabIndex = 34;
            // 
            // cbParityCheck
            // 
            this.cbParityCheck.AutoSize = true;
            this.cbParityCheck.Location = new System.Drawing.Point(92, 215);
            this.cbParityCheck.Name = "cbParityCheck";
            this.cbParityCheck.Size = new System.Drawing.Size(85, 17);
            this.cbParityCheck.TabIndex = 35;
            this.cbParityCheck.Text = "Parity check";
            this.cbParityCheck.UseVisualStyleBackColor = true;
            // 
            // cbOutxDsrFlow
            // 
            this.cbOutxDsrFlow.AutoSize = true;
            this.cbOutxDsrFlow.Location = new System.Drawing.Point(92, 238);
            this.cbOutxDsrFlow.Name = "cbOutxDsrFlow";
            this.cbOutxDsrFlow.Size = new System.Drawing.Size(104, 17);
            this.cbOutxDsrFlow.TabIndex = 36;
            this.cbOutxDsrFlow.Text = "OUTX DSR flow";
            this.cbOutxDsrFlow.UseVisualStyleBackColor = true;
            // 
            // cbTXContinueOnXoff
            // 
            this.cbTXContinueOnXoff.AutoSize = true;
            this.cbTXContinueOnXoff.Location = new System.Drawing.Point(92, 261);
            this.cbTXContinueOnXoff.Name = "cbTXContinueOnXoff";
            this.cbTXContinueOnXoff.Size = new System.Drawing.Size(129, 17);
            this.cbTXContinueOnXoff.TabIndex = 37;
            this.cbTXContinueOnXoff.Text = "TX continue on XOFF";
            this.cbTXContinueOnXoff.UseVisualStyleBackColor = true;
            // 
            // cbErrorCharReplace
            // 
            this.cbErrorCharReplace.AutoSize = true;
            this.cbErrorCharReplace.Location = new System.Drawing.Point(92, 284);
            this.cbErrorCharReplace.Name = "cbErrorCharReplace";
            this.cbErrorCharReplace.Size = new System.Drawing.Size(110, 17);
            this.cbErrorCharReplace.TabIndex = 38;
            this.cbErrorCharReplace.Text = "Error char replace";
            this.cbErrorCharReplace.UseVisualStyleBackColor = true;
            // 
            // cbNullStrip
            // 
            this.cbNullStrip.AutoSize = true;
            this.cbNullStrip.Location = new System.Drawing.Point(92, 307);
            this.cbNullStrip.Name = "cbNullStrip";
            this.cbNullStrip.Size = new System.Drawing.Size(76, 17);
            this.cbNullStrip.TabIndex = 39;
            this.cbNullStrip.Text = "NULL strip";
            this.cbNullStrip.UseVisualStyleBackColor = true;
            // 
            // cbOutxCtsFlow
            // 
            this.cbOutxCtsFlow.AutoSize = true;
            this.cbOutxCtsFlow.Location = new System.Drawing.Point(254, 215);
            this.cbOutxCtsFlow.Name = "cbOutxCtsFlow";
            this.cbOutxCtsFlow.Size = new System.Drawing.Size(105, 17);
            this.cbOutxCtsFlow.TabIndex = 40;
            this.cbOutxCtsFlow.Text = "OUTX CTS  flow";
            this.cbOutxCtsFlow.UseVisualStyleBackColor = true;
            // 
            // cbDsrSensitivity
            // 
            this.cbDsrSensitivity.AutoSize = true;
            this.cbDsrSensitivity.Location = new System.Drawing.Point(254, 238);
            this.cbDsrSensitivity.Name = "cbDsrSensitivity";
            this.cbDsrSensitivity.Size = new System.Drawing.Size(97, 17);
            this.cbDsrSensitivity.TabIndex = 41;
            this.cbDsrSensitivity.Text = "DSR sensitivity";
            this.cbDsrSensitivity.UseVisualStyleBackColor = true;
            // 
            // cbOutX
            // 
            this.cbOutX.AutoSize = true;
            this.cbOutX.Location = new System.Drawing.Point(254, 261);
            this.cbOutX.Name = "cbOutX";
            this.cbOutX.Size = new System.Drawing.Size(56, 17);
            this.cbOutX.TabIndex = 42;
            this.cbOutX.Text = "OUTX";
            this.cbOutX.UseVisualStyleBackColor = true;
            // 
            // cbInX
            // 
            this.cbInX.AutoSize = true;
            this.cbInX.Location = new System.Drawing.Point(254, 284);
            this.cbInX.Name = "cbInX";
            this.cbInX.Size = new System.Drawing.Size(44, 17);
            this.cbInX.TabIndex = 43;
            this.cbInX.Text = "INX";
            this.cbInX.UseVisualStyleBackColor = true;
            // 
            // cbAbortOnError
            // 
            this.cbAbortOnError.AutoSize = true;
            this.cbAbortOnError.Location = new System.Drawing.Point(254, 307);
            this.cbAbortOnError.Name = "cbAbortOnError";
            this.cbAbortOnError.Size = new System.Drawing.Size(90, 17);
            this.cbAbortOnError.TabIndex = 44;
            this.cbAbortOnError.Text = "Abort on error";
            this.cbAbortOnError.UseVisualStyleBackColor = true;
            // 
            // btGetBuffers
            // 
            this.btGetBuffers.Location = new System.Drawing.Point(427, 54);
            this.btGetBuffers.Name = "btGetBuffers";
            this.btGetBuffers.Size = new System.Drawing.Size(75, 23);
            this.btGetBuffers.TabIndex = 45;
            this.btGetBuffers.Text = "Get buffers";
            this.btGetBuffers.UseVisualStyleBackColor = true;
            this.btGetBuffers.Click += new System.EventHandler(this.btGetBuffersClick);
            // 
            // btSetBuffers
            // 
            this.btSetBuffers.Location = new System.Drawing.Point(508, 54);
            this.btSetBuffers.Name = "btSetBuffers";
            this.btSetBuffers.Size = new System.Drawing.Size(75, 23);
            this.btSetBuffers.TabIndex = 46;
            this.btSetBuffers.Text = "Set buffers";
            this.btSetBuffers.UseVisualStyleBackColor = true;
            this.btSetBuffers.Click += new System.EventHandler(this.btSetBuffersClick);
            // 
            // laReadBufferSize
            // 
            this.laReadBufferSize.AutoSize = true;
            this.laReadBufferSize.Location = new System.Drawing.Point(418, 86);
            this.laReadBufferSize.Name = "laReadBufferSize";
            this.laReadBufferSize.Size = new System.Drawing.Size(84, 13);
            this.laReadBufferSize.TabIndex = 47;
            this.laReadBufferSize.Text = "Read buffer size";
            // 
            // edReadBufferSize
            // 
            this.edReadBufferSize.Location = new System.Drawing.Point(508, 83);
            this.edReadBufferSize.Name = "edReadBufferSize";
            this.edReadBufferSize.Size = new System.Drawing.Size(83, 20);
            this.edReadBufferSize.TabIndex = 48;
            // 
            // edWriteBufferSize
            // 
            this.edWriteBufferSize.Location = new System.Drawing.Point(507, 109);
            this.edWriteBufferSize.Name = "edWriteBufferSize";
            this.edWriteBufferSize.Size = new System.Drawing.Size(83, 20);
            this.edWriteBufferSize.TabIndex = 49;
            // 
            // laWriteBufferSize
            // 
            this.laWriteBufferSize.AutoSize = true;
            this.laWriteBufferSize.Location = new System.Drawing.Point(418, 112);
            this.laWriteBufferSize.Name = "laWriteBufferSize";
            this.laWriteBufferSize.Size = new System.Drawing.Size(83, 13);
            this.laWriteBufferSize.TabIndex = 50;
            this.laWriteBufferSize.Text = "Write buffer size";
            // 
            // btGetTimeouts
            // 
            this.btGetTimeouts.Location = new System.Drawing.Point(427, 156);
            this.btGetTimeouts.Name = "btGetTimeouts";
            this.btGetTimeouts.Size = new System.Drawing.Size(75, 23);
            this.btGetTimeouts.TabIndex = 51;
            this.btGetTimeouts.Text = "Get timeouts";
            this.btGetTimeouts.UseVisualStyleBackColor = true;
            this.btGetTimeouts.Click += new System.EventHandler(this.btGetTimeoutsClick);
            // 
            // btSetTimeouts
            // 
            this.btSetTimeouts.Location = new System.Drawing.Point(508, 156);
            this.btSetTimeouts.Name = "btSetTimeouts";
            this.btSetTimeouts.Size = new System.Drawing.Size(75, 23);
            this.btSetTimeouts.TabIndex = 52;
            this.btSetTimeouts.Text = "Set timeouts";
            this.btSetTimeouts.UseVisualStyleBackColor = true;
            this.btSetTimeouts.Click += new System.EventHandler(this.btSetTimeoutsClick);
            // 
            // edReadInterval
            // 
            this.edReadInterval.Location = new System.Drawing.Point(507, 185);
            this.edReadInterval.Name = "edReadInterval";
            this.edReadInterval.Size = new System.Drawing.Size(84, 20);
            this.edReadInterval.TabIndex = 53;
            // 
            // edReadMultiplier
            // 
            this.edReadMultiplier.Location = new System.Drawing.Point(508, 211);
            this.edReadMultiplier.Name = "edReadMultiplier";
            this.edReadMultiplier.Size = new System.Drawing.Size(83, 20);
            this.edReadMultiplier.TabIndex = 54;
            // 
            // edReadConstant
            // 
            this.edReadConstant.Location = new System.Drawing.Point(508, 237);
            this.edReadConstant.Name = "edReadConstant";
            this.edReadConstant.Size = new System.Drawing.Size(82, 20);
            this.edReadConstant.TabIndex = 55;
            // 
            // edWriteMultiplier
            // 
            this.edWriteMultiplier.Location = new System.Drawing.Point(508, 263);
            this.edWriteMultiplier.Name = "edWriteMultiplier";
            this.edWriteMultiplier.Size = new System.Drawing.Size(82, 20);
            this.edWriteMultiplier.TabIndex = 56;
            // 
            // edWriteConstant
            // 
            this.edWriteConstant.Location = new System.Drawing.Point(508, 289);
            this.edWriteConstant.Name = "edWriteConstant";
            this.edWriteConstant.Size = new System.Drawing.Size(83, 20);
            this.edWriteConstant.TabIndex = 57;
            // 
            // laReadInterval
            // 
            this.laReadInterval.AutoSize = true;
            this.laReadInterval.Location = new System.Drawing.Point(418, 188);
            this.laReadInterval.Name = "laReadInterval";
            this.laReadInterval.Size = new System.Drawing.Size(70, 13);
            this.laReadInterval.TabIndex = 58;
            this.laReadInterval.Text = "Read interval";
            // 
            // laReadMultiplier
            // 
            this.laReadMultiplier.AutoSize = true;
            this.laReadMultiplier.Location = new System.Drawing.Point(418, 214);
            this.laReadMultiplier.Name = "laReadMultiplier";
            this.laReadMultiplier.Size = new System.Drawing.Size(76, 13);
            this.laReadMultiplier.TabIndex = 59;
            this.laReadMultiplier.Text = "Read multiplier";
            // 
            // laReadConstant
            // 
            this.laReadConstant.AutoSize = true;
            this.laReadConstant.Location = new System.Drawing.Point(418, 240);
            this.laReadConstant.Name = "laReadConstant";
            this.laReadConstant.Size = new System.Drawing.Size(77, 13);
            this.laReadConstant.TabIndex = 60;
            this.laReadConstant.Text = "Read constant";
            // 
            // laWriteMultiplier
            // 
            this.laWriteMultiplier.AutoSize = true;
            this.laWriteMultiplier.Location = new System.Drawing.Point(418, 266);
            this.laWriteMultiplier.Name = "laWriteMultiplier";
            this.laWriteMultiplier.Size = new System.Drawing.Size(75, 13);
            this.laWriteMultiplier.TabIndex = 61;
            this.laWriteMultiplier.Text = "Write multiplier";
            // 
            // laWriteConstant
            // 
            this.laWriteConstant.AutoSize = true;
            this.laWriteConstant.Location = new System.Drawing.Point(418, 292);
            this.laWriteConstant.Name = "laWriteConstant";
            this.laWriteConstant.Size = new System.Drawing.Size(76, 13);
            this.laWriteConstant.TabIndex = 62;
            this.laWriteConstant.Text = "Write constant";
            // 
            // btClearCommBreak
            // 
            this.btClearCommBreak.Location = new System.Drawing.Point(613, 54);
            this.btClearCommBreak.Name = "btClearCommBreak";
            this.btClearCommBreak.Size = new System.Drawing.Size(116, 23);
            this.btClearCommBreak.TabIndex = 63;
            this.btClearCommBreak.Text = "Clear comm BREAK";
            this.btClearCommBreak.UseVisualStyleBackColor = true;
            this.btClearCommBreak.Click += new System.EventHandler(this.btClearCommBreakClick);
            // 
            // btSetCommBreak
            // 
            this.btSetCommBreak.Location = new System.Drawing.Point(735, 54);
            this.btSetCommBreak.Name = "btSetCommBreak";
            this.btSetCommBreak.Size = new System.Drawing.Size(116, 23);
            this.btSetCommBreak.TabIndex = 64;
            this.btSetCommBreak.Text = "Set comm BREAK";
            this.btSetCommBreak.UseVisualStyleBackColor = true;
            this.btSetCommBreak.Click += new System.EventHandler(this.btSetCommBreakClick);
            // 
            // cbFunc
            // 
            this.cbFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFunc.FormattingEnabled = true;
            this.cbFunc.Items.AddRange(new object[] {
            "escClrBreak",
            "escClrDtr",
            "escClrRts",
            "escSetBreak",
            "escSetDtr",
            "escSetRts",
            "escSetXoff",
            "escSetXon"});
            this.cbFunc.Location = new System.Drawing.Point(664, 83);
            this.cbFunc.Name = "cbFunc";
            this.cbFunc.Size = new System.Drawing.Size(108, 21);
            this.cbFunc.TabIndex = 65;
            // 
            // laFunc
            // 
            this.laFunc.AutoSize = true;
            this.laFunc.Location = new System.Drawing.Point(610, 86);
            this.laFunc.Name = "laFunc";
            this.laFunc.Size = new System.Drawing.Size(48, 13);
            this.laFunc.TabIndex = 66;
            this.laFunc.Text = "Function";
            // 
            // btFunc
            // 
            this.btFunc.Location = new System.Drawing.Point(778, 83);
            this.btFunc.Name = "btFunc";
            this.btFunc.Size = new System.Drawing.Size(75, 23);
            this.btFunc.TabIndex = 67;
            this.btFunc.Text = "Exec func";
            this.btFunc.UseVisualStyleBackColor = true;
            this.btFunc.Click += new System.EventHandler(this.btFuncClick);
            // 
            // cbPurgeRxAbort
            // 
            this.cbPurgeRxAbort.AutoSize = true;
            this.cbPurgeRxAbort.Location = new System.Drawing.Point(613, 111);
            this.cbPurgeRxAbort.Name = "cbPurgeRxAbort";
            this.cbPurgeRxAbort.Size = new System.Drawing.Size(68, 17);
            this.cbPurgeRxAbort.TabIndex = 68;
            this.cbPurgeRxAbort.Text = "RX abort";
            this.cbPurgeRxAbort.UseVisualStyleBackColor = true;
            // 
            // cbPurgeRxClear
            // 
            this.cbPurgeRxClear.AutoSize = true;
            this.cbPurgeRxClear.Location = new System.Drawing.Point(613, 134);
            this.cbPurgeRxClear.Name = "cbPurgeRxClear";
            this.cbPurgeRxClear.Size = new System.Drawing.Size(67, 17);
            this.cbPurgeRxClear.TabIndex = 69;
            this.cbPurgeRxClear.Text = "RX clear";
            this.cbPurgeRxClear.UseVisualStyleBackColor = true;
            // 
            // cbPurgeTxAbort
            // 
            this.cbPurgeTxAbort.AutoSize = true;
            this.cbPurgeTxAbort.Location = new System.Drawing.Point(687, 111);
            this.cbPurgeTxAbort.Name = "cbPurgeTxAbort";
            this.cbPurgeTxAbort.Size = new System.Drawing.Size(67, 17);
            this.cbPurgeTxAbort.TabIndex = 70;
            this.cbPurgeTxAbort.Text = "TX abort";
            this.cbPurgeTxAbort.UseVisualStyleBackColor = true;
            // 
            // cbPurgeTxClear
            // 
            this.cbPurgeTxClear.AutoSize = true;
            this.cbPurgeTxClear.Location = new System.Drawing.Point(687, 134);
            this.cbPurgeTxClear.Name = "cbPurgeTxClear";
            this.cbPurgeTxClear.Size = new System.Drawing.Size(66, 17);
            this.cbPurgeTxClear.TabIndex = 71;
            this.cbPurgeTxClear.Text = "TX clear";
            this.cbPurgeTxClear.UseVisualStyleBackColor = true;
            // 
            // btPurge
            // 
            this.btPurge.Location = new System.Drawing.Point(776, 120);
            this.btPurge.Name = "btPurge";
            this.btPurge.Size = new System.Drawing.Size(75, 23);
            this.btPurge.TabIndex = 72;
            this.btPurge.Text = "Purge";
            this.btPurge.UseVisualStyleBackColor = true;
            this.btPurge.Click += new System.EventHandler(this.btPurgeClick);
            // 
            // edChar
            // 
            this.edChar.Location = new System.Drawing.Point(708, 156);
            this.edChar.Name = "edChar";
            this.edChar.Size = new System.Drawing.Size(62, 20);
            this.edChar.TabIndex = 73;
            this.edChar.Text = "0";
            // 
            // btTransmit
            // 
            this.btTransmit.Location = new System.Drawing.Point(776, 155);
            this.btTransmit.Name = "btTransmit";
            this.btTransmit.Size = new System.Drawing.Size(75, 23);
            this.btTransmit.TabIndex = 74;
            this.btTransmit.Text = "Transmit";
            this.btTransmit.UseVisualStyleBackColor = true;
            this.btTransmit.Click += new System.EventHandler(this.btTransmitClick);
            // 
            // laCharCode
            // 
            this.laCharCode.AutoSize = true;
            this.laCharCode.Location = new System.Drawing.Point(610, 159);
            this.laCharCode.Name = "laCharCode";
            this.laCharCode.Size = new System.Drawing.Size(92, 13);
            this.laCharCode.TabIndex = 75;
            this.laCharCode.Text = "Char code (ASCII)";
            // 
            // btFlushBuffers
            // 
            this.btFlushBuffers.Location = new System.Drawing.Point(697, 192);
            this.btFlushBuffers.Name = "btFlushBuffers";
            this.btFlushBuffers.Size = new System.Drawing.Size(75, 23);
            this.btFlushBuffers.TabIndex = 76;
            this.btFlushBuffers.Text = "Flush buffers";
            this.btFlushBuffers.UseVisualStyleBackColor = true;
            this.btFlushBuffers.Click += new System.EventHandler(this.btFlushBuffersClick);
            // 
            // edText
            // 
            this.edText.Location = new System.Drawing.Point(15, 341);
            this.edText.Name = "edText";
            this.edText.Size = new System.Drawing.Size(473, 20);
            this.edText.TabIndex = 77;
            this.edText.Text = "Something to send to serial";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(494, 339);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 78;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSendClick);
            // 
            // laLineFeed
            // 
            this.laLineFeed.AutoSize = true;
            this.laLineFeed.Location = new System.Drawing.Point(575, 344);
            this.laLineFeed.Name = "laLineFeed";
            this.laLineFeed.Size = new System.Drawing.Size(51, 13);
            this.laLineFeed.TabIndex = 79;
            this.laLineFeed.Text = "Line feed";
            // 
            // cbLineFeed
            // 
            this.cbLineFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLineFeed.FormattingEnabled = true;
            this.cbLineFeed.Items.AddRange(new object[] {
            "None",
            "CR",
            "LF",
            "CR & LF"});
            this.cbLineFeed.Location = new System.Drawing.Point(632, 341);
            this.cbLineFeed.Name = "cbLineFeed";
            this.cbLineFeed.Size = new System.Drawing.Size(121, 21);
            this.cbLineFeed.TabIndex = 80;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(776, 339);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 81;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClearClick);
            // 
            // lbEvents
            // 
            this.lbEvents.FormattingEnabled = true;
            this.lbEvents.Location = new System.Drawing.Point(15, 367);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.Size = new System.Drawing.Size(836, 186);
            this.lbEvents.TabIndex = 82;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 563);
            this.Controls.Add(this.lbEvents);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.cbLineFeed);
            this.Controls.Add(this.laLineFeed);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.edText);
            this.Controls.Add(this.btFlushBuffers);
            this.Controls.Add(this.laCharCode);
            this.Controls.Add(this.btTransmit);
            this.Controls.Add(this.edChar);
            this.Controls.Add(this.btPurge);
            this.Controls.Add(this.cbPurgeTxClear);
            this.Controls.Add(this.cbPurgeTxAbort);
            this.Controls.Add(this.cbPurgeRxClear);
            this.Controls.Add(this.cbPurgeRxAbort);
            this.Controls.Add(this.btFunc);
            this.Controls.Add(this.laFunc);
            this.Controls.Add(this.cbFunc);
            this.Controls.Add(this.btSetCommBreak);
            this.Controls.Add(this.btClearCommBreak);
            this.Controls.Add(this.laWriteConstant);
            this.Controls.Add(this.laWriteMultiplier);
            this.Controls.Add(this.laReadConstant);
            this.Controls.Add(this.laReadMultiplier);
            this.Controls.Add(this.laReadInterval);
            this.Controls.Add(this.edWriteConstant);
            this.Controls.Add(this.edWriteMultiplier);
            this.Controls.Add(this.edReadConstant);
            this.Controls.Add(this.edReadMultiplier);
            this.Controls.Add(this.edReadInterval);
            this.Controls.Add(this.btSetTimeouts);
            this.Controls.Add(this.btGetTimeouts);
            this.Controls.Add(this.laWriteBufferSize);
            this.Controls.Add(this.edWriteBufferSize);
            this.Controls.Add(this.edReadBufferSize);
            this.Controls.Add(this.laReadBufferSize);
            this.Controls.Add(this.btSetBuffers);
            this.Controls.Add(this.btGetBuffers);
            this.Controls.Add(this.cbAbortOnError);
            this.Controls.Add(this.cbInX);
            this.Controls.Add(this.cbOutX);
            this.Controls.Add(this.cbDsrSensitivity);
            this.Controls.Add(this.cbOutxCtsFlow);
            this.Controls.Add(this.cbNullStrip);
            this.Controls.Add(this.cbErrorCharReplace);
            this.Controls.Add(this.cbTXContinueOnXoff);
            this.Controls.Add(this.cbOutxDsrFlow);
            this.Controls.Add(this.cbParityCheck);
            this.Controls.Add(this.edEvtChar);
            this.Controls.Add(this.laEvtChar);
            this.Controls.Add(this.edEofChar);
            this.Controls.Add(this.laEofChar);
            this.Controls.Add(this.edErrorChar);
            this.Controls.Add(this.laErrorChar);
            this.Controls.Add(this.edXoffChar);
            this.Controls.Add(this.laXoffChar);
            this.Controls.Add(this.edXonChar);
            this.Controls.Add(this.laXonChar);
            this.Controls.Add(this.laXoffLim);
            this.Controls.Add(this.edXoffLim);
            this.Controls.Add(this.laStopBites);
            this.Controls.Add(this.cbStopBits);
            this.Controls.Add(this.laByteSize);
            this.Controls.Add(this.cbByteSize);
            this.Controls.Add(this.laDtrControl);
            this.Controls.Add(this.cbDtrControl);
            this.Controls.Add(this.laXonLim);
            this.Controls.Add(this.edXonLim);
            this.Controls.Add(this.laParity);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.laRtsControl);
            this.Controls.Add(this.cbRtsControl);
            this.Controls.Add(this.edBaudRate);
            this.Controls.Add(this.laBaudRate);
            this.Controls.Add(this.btSetConfig);
            this.Controls.Add(this.btGetConfig);
            this.Controls.Add(this.btSetWriteTimeout);
            this.Controls.Add(this.edWriteTimeout);
            this.Controls.Add(this.laWriteTimeout);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.btEnum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Client Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMainClosed);
            this.Load += new System.EventHandler(this.fmMainLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEnum;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Label laWriteTimeout;
        private System.Windows.Forms.TextBox edWriteTimeout;
        private System.Windows.Forms.Button btSetWriteTimeout;
        private System.Windows.Forms.Button btGetConfig;
        private System.Windows.Forms.Button btSetConfig;
        private System.Windows.Forms.Label laBaudRate;
        private System.Windows.Forms.TextBox edBaudRate;
        private System.Windows.Forms.ComboBox cbRtsControl;
        private System.Windows.Forms.Label laRtsControl;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label laParity;
        private System.Windows.Forms.TextBox edXonLim;
        private System.Windows.Forms.Label laXonLim;
        private System.Windows.Forms.ComboBox cbDtrControl;
        private System.Windows.Forms.Label laDtrControl;
        private System.Windows.Forms.ComboBox cbByteSize;
        private System.Windows.Forms.Label laByteSize;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label laStopBites;
        private System.Windows.Forms.TextBox edXoffLim;
        private System.Windows.Forms.Label laXoffLim;
        private System.Windows.Forms.Label laXonChar;
        private System.Windows.Forms.TextBox edXonChar;
        private System.Windows.Forms.Label laXoffChar;
        private System.Windows.Forms.TextBox edXoffChar;
        private System.Windows.Forms.Label laErrorChar;
        private System.Windows.Forms.TextBox edErrorChar;
        private System.Windows.Forms.Label laEofChar;
        private System.Windows.Forms.TextBox edEofChar;
        private System.Windows.Forms.Label laEvtChar;
        private System.Windows.Forms.TextBox edEvtChar;
        private System.Windows.Forms.CheckBox cbParityCheck;
        private System.Windows.Forms.CheckBox cbOutxDsrFlow;
        private System.Windows.Forms.CheckBox cbTXContinueOnXoff;
        private System.Windows.Forms.CheckBox cbErrorCharReplace;
        private System.Windows.Forms.CheckBox cbNullStrip;
        private System.Windows.Forms.CheckBox cbOutxCtsFlow;
        private System.Windows.Forms.CheckBox cbDsrSensitivity;
        private System.Windows.Forms.CheckBox cbOutX;
        private System.Windows.Forms.CheckBox cbInX;
        private System.Windows.Forms.CheckBox cbAbortOnError;
        private System.Windows.Forms.Button btGetBuffers;
        private System.Windows.Forms.Button btSetBuffers;
        private System.Windows.Forms.Label laReadBufferSize;
        private System.Windows.Forms.TextBox edReadBufferSize;
        private System.Windows.Forms.TextBox edWriteBufferSize;
        private System.Windows.Forms.Label laWriteBufferSize;
        private System.Windows.Forms.Button btGetTimeouts;
        private System.Windows.Forms.Button btSetTimeouts;
        private System.Windows.Forms.TextBox edReadInterval;
        private System.Windows.Forms.TextBox edReadMultiplier;
        private System.Windows.Forms.TextBox edReadConstant;
        private System.Windows.Forms.TextBox edWriteMultiplier;
        private System.Windows.Forms.TextBox edWriteConstant;
        private System.Windows.Forms.Label laReadInterval;
        private System.Windows.Forms.Label laReadMultiplier;
        private System.Windows.Forms.Label laReadConstant;
        private System.Windows.Forms.Label laWriteMultiplier;
        private System.Windows.Forms.Label laWriteConstant;
        private System.Windows.Forms.Button btClearCommBreak;
        private System.Windows.Forms.Button btSetCommBreak;
        private System.Windows.Forms.ComboBox cbFunc;
        private System.Windows.Forms.Label laFunc;
        private System.Windows.Forms.Button btFunc;
        private System.Windows.Forms.CheckBox cbPurgeRxAbort;
        private System.Windows.Forms.CheckBox cbPurgeRxClear;
        private System.Windows.Forms.CheckBox cbPurgeTxAbort;
        private System.Windows.Forms.CheckBox cbPurgeTxClear;
        private System.Windows.Forms.Button btPurge;
        private System.Windows.Forms.TextBox edChar;
        private System.Windows.Forms.Button btTransmit;
        private System.Windows.Forms.Label laCharCode;
        private System.Windows.Forms.Button btFlushBuffers;
        private System.Windows.Forms.TextBox edText;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label laLineFeed;
        private System.Windows.Forms.ComboBox cbLineFeed;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.ListBox lbEvents;
    }
}

