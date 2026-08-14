<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbEvents = New System.Windows.Forms.ListBox()
        Me.btClear = New System.Windows.Forms.Button()
        Me.cbLineFeed = New System.Windows.Forms.ComboBox()
        Me.laLineFeed = New System.Windows.Forms.Label()
        Me.btSend = New System.Windows.Forms.Button()
        Me.edText = New System.Windows.Forms.TextBox()
        Me.btFlushBuffers = New System.Windows.Forms.Button()
        Me.laCharCode = New System.Windows.Forms.Label()
        Me.btTransmit = New System.Windows.Forms.Button()
        Me.edChar = New System.Windows.Forms.TextBox()
        Me.btPurge = New System.Windows.Forms.Button()
        Me.cbPurgeTxClear = New System.Windows.Forms.CheckBox()
        Me.cbPurgeTxAbort = New System.Windows.Forms.CheckBox()
        Me.cbPurgeRxClear = New System.Windows.Forms.CheckBox()
        Me.cbPurgeRxAbort = New System.Windows.Forms.CheckBox()
        Me.btFunc = New System.Windows.Forms.Button()
        Me.laFunc = New System.Windows.Forms.Label()
        Me.cbFunc = New System.Windows.Forms.ComboBox()
        Me.btSetCommBreak = New System.Windows.Forms.Button()
        Me.btClearCommBreak = New System.Windows.Forms.Button()
        Me.laWriteConstant = New System.Windows.Forms.Label()
        Me.laWriteMultiplier = New System.Windows.Forms.Label()
        Me.laReadConstant = New System.Windows.Forms.Label()
        Me.laReadMultiplier = New System.Windows.Forms.Label()
        Me.laReadInterval = New System.Windows.Forms.Label()
        Me.edWriteConstant = New System.Windows.Forms.TextBox()
        Me.edWriteMultiplier = New System.Windows.Forms.TextBox()
        Me.edReadConstant = New System.Windows.Forms.TextBox()
        Me.edReadMultiplier = New System.Windows.Forms.TextBox()
        Me.edReadInterval = New System.Windows.Forms.TextBox()
        Me.btSetTimeouts = New System.Windows.Forms.Button()
        Me.btGetTimeouts = New System.Windows.Forms.Button()
        Me.laWriteBufferSize = New System.Windows.Forms.Label()
        Me.edWriteBufferSize = New System.Windows.Forms.TextBox()
        Me.edReadBufferSize = New System.Windows.Forms.TextBox()
        Me.laReadBufferSize = New System.Windows.Forms.Label()
        Me.btSetBuffers = New System.Windows.Forms.Button()
        Me.btGetBuffers = New System.Windows.Forms.Button()
        Me.cbAbortOnError = New System.Windows.Forms.CheckBox()
        Me.cbInX = New System.Windows.Forms.CheckBox()
        Me.cbOutX = New System.Windows.Forms.CheckBox()
        Me.cbDsrSensitivity = New System.Windows.Forms.CheckBox()
        Me.cbOutxCtsFlow = New System.Windows.Forms.CheckBox()
        Me.cbNullStrip = New System.Windows.Forms.CheckBox()
        Me.cbErrorCharReplace = New System.Windows.Forms.CheckBox()
        Me.cbTXContinueOnXoff = New System.Windows.Forms.CheckBox()
        Me.cbOutxDsrFlow = New System.Windows.Forms.CheckBox()
        Me.cbParityCheck = New System.Windows.Forms.CheckBox()
        Me.edEvtChar = New System.Windows.Forms.TextBox()
        Me.laEvtChar = New System.Windows.Forms.Label()
        Me.edEofChar = New System.Windows.Forms.TextBox()
        Me.laEofChar = New System.Windows.Forms.Label()
        Me.edErrorChar = New System.Windows.Forms.TextBox()
        Me.laErrorChar = New System.Windows.Forms.Label()
        Me.edXoffChar = New System.Windows.Forms.TextBox()
        Me.laXoffChar = New System.Windows.Forms.Label()
        Me.edXonChar = New System.Windows.Forms.TextBox()
        Me.laXonChar = New System.Windows.Forms.Label()
        Me.laXoffLim = New System.Windows.Forms.Label()
        Me.edXoffLim = New System.Windows.Forms.TextBox()
        Me.laStopBites = New System.Windows.Forms.Label()
        Me.cbStopBits = New System.Windows.Forms.ComboBox()
        Me.laByteSize = New System.Windows.Forms.Label()
        Me.cbByteSize = New System.Windows.Forms.ComboBox()
        Me.laDtrControl = New System.Windows.Forms.Label()
        Me.cbDtrControl = New System.Windows.Forms.ComboBox()
        Me.laXonLim = New System.Windows.Forms.Label()
        Me.edXonLim = New System.Windows.Forms.TextBox()
        Me.laParity = New System.Windows.Forms.Label()
        Me.cbParity = New System.Windows.Forms.ComboBox()
        Me.laRtsControl = New System.Windows.Forms.Label()
        Me.cbRtsControl = New System.Windows.Forms.ComboBox()
        Me.edBaudRate = New System.Windows.Forms.TextBox()
        Me.laBaudRate = New System.Windows.Forms.Label()
        Me.btSetConfig = New System.Windows.Forms.Button()
        Me.btGetConfig = New System.Windows.Forms.Button()
        Me.btSetWriteTimeout = New System.Windows.Forms.Button()
        Me.edWriteTimeout = New System.Windows.Forms.TextBox()
        Me.laWriteTimeout = New System.Windows.Forms.Label()
        Me.btDisconnect = New System.Windows.Forms.Button()
        Me.btConnect = New System.Windows.Forms.Button()
        Me.cbPorts = New System.Windows.Forms.ComboBox()
        Me.btEnum = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbEvents
        '
        Me.lbEvents.FormattingEnabled = True
        Me.lbEvents.Location = New System.Drawing.Point(15, 366)
        Me.lbEvents.Name = "lbEvents"
        Me.lbEvents.Size = New System.Drawing.Size(836, 186)
        Me.lbEvents.TabIndex = 165
        '
        'btClear
        '
        Me.btClear.Location = New System.Drawing.Point(776, 338)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(75, 23)
        Me.btClear.TabIndex = 164
        Me.btClear.Text = "Clear"
        Me.btClear.UseVisualStyleBackColor = True
        '
        'cbLineFeed
        '
        Me.cbLineFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLineFeed.FormattingEnabled = True
        Me.cbLineFeed.Items.AddRange(New Object() {"None", "CR", "LF", "CR & LF"})
        Me.cbLineFeed.Location = New System.Drawing.Point(632, 340)
        Me.cbLineFeed.Name = "cbLineFeed"
        Me.cbLineFeed.Size = New System.Drawing.Size(121, 21)
        Me.cbLineFeed.TabIndex = 163
        '
        'laLineFeed
        '
        Me.laLineFeed.AutoSize = True
        Me.laLineFeed.Location = New System.Drawing.Point(575, 343)
        Me.laLineFeed.Name = "laLineFeed"
        Me.laLineFeed.Size = New System.Drawing.Size(51, 13)
        Me.laLineFeed.TabIndex = 162
        Me.laLineFeed.Text = "Line feed"
        '
        'btSend
        '
        Me.btSend.Location = New System.Drawing.Point(494, 338)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(75, 23)
        Me.btSend.TabIndex = 161
        Me.btSend.Text = "Send"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'edText
        '
        Me.edText.Location = New System.Drawing.Point(15, 340)
        Me.edText.Name = "edText"
        Me.edText.Size = New System.Drawing.Size(473, 20)
        Me.edText.TabIndex = 160
        Me.edText.Text = "Something to send to serial"
        '
        'btFlushBuffers
        '
        Me.btFlushBuffers.Location = New System.Drawing.Point(697, 191)
        Me.btFlushBuffers.Name = "btFlushBuffers"
        Me.btFlushBuffers.Size = New System.Drawing.Size(75, 23)
        Me.btFlushBuffers.TabIndex = 159
        Me.btFlushBuffers.Text = "Flush buffers"
        Me.btFlushBuffers.UseVisualStyleBackColor = True
        '
        'laCharCode
        '
        Me.laCharCode.AutoSize = True
        Me.laCharCode.Location = New System.Drawing.Point(610, 158)
        Me.laCharCode.Name = "laCharCode"
        Me.laCharCode.Size = New System.Drawing.Size(92, 13)
        Me.laCharCode.TabIndex = 158
        Me.laCharCode.Text = "Char code (ASCII)"
        '
        'btTransmit
        '
        Me.btTransmit.Location = New System.Drawing.Point(776, 154)
        Me.btTransmit.Name = "btTransmit"
        Me.btTransmit.Size = New System.Drawing.Size(75, 23)
        Me.btTransmit.TabIndex = 157
        Me.btTransmit.Text = "Transmit"
        Me.btTransmit.UseVisualStyleBackColor = True
        '
        'edChar
        '
        Me.edChar.Location = New System.Drawing.Point(708, 155)
        Me.edChar.Name = "edChar"
        Me.edChar.Size = New System.Drawing.Size(62, 20)
        Me.edChar.TabIndex = 156
        Me.edChar.Text = "0"
        '
        'btPurge
        '
        Me.btPurge.Location = New System.Drawing.Point(776, 119)
        Me.btPurge.Name = "btPurge"
        Me.btPurge.Size = New System.Drawing.Size(75, 23)
        Me.btPurge.TabIndex = 155
        Me.btPurge.Text = "Purge"
        Me.btPurge.UseVisualStyleBackColor = True
        '
        'cbPurgeTxClear
        '
        Me.cbPurgeTxClear.AutoSize = True
        Me.cbPurgeTxClear.Location = New System.Drawing.Point(687, 133)
        Me.cbPurgeTxClear.Name = "cbPurgeTxClear"
        Me.cbPurgeTxClear.Size = New System.Drawing.Size(66, 17)
        Me.cbPurgeTxClear.TabIndex = 154
        Me.cbPurgeTxClear.Text = "TX clear"
        Me.cbPurgeTxClear.UseVisualStyleBackColor = True
        '
        'cbPurgeTxAbort
        '
        Me.cbPurgeTxAbort.AutoSize = True
        Me.cbPurgeTxAbort.Location = New System.Drawing.Point(687, 110)
        Me.cbPurgeTxAbort.Name = "cbPurgeTxAbort"
        Me.cbPurgeTxAbort.Size = New System.Drawing.Size(67, 17)
        Me.cbPurgeTxAbort.TabIndex = 153
        Me.cbPurgeTxAbort.Text = "TX abort"
        Me.cbPurgeTxAbort.UseVisualStyleBackColor = True
        '
        'cbPurgeRxClear
        '
        Me.cbPurgeRxClear.AutoSize = True
        Me.cbPurgeRxClear.Location = New System.Drawing.Point(613, 133)
        Me.cbPurgeRxClear.Name = "cbPurgeRxClear"
        Me.cbPurgeRxClear.Size = New System.Drawing.Size(67, 17)
        Me.cbPurgeRxClear.TabIndex = 152
        Me.cbPurgeRxClear.Text = "RX clear"
        Me.cbPurgeRxClear.UseVisualStyleBackColor = True
        '
        'cbPurgeRxAbort
        '
        Me.cbPurgeRxAbort.AutoSize = True
        Me.cbPurgeRxAbort.Location = New System.Drawing.Point(613, 110)
        Me.cbPurgeRxAbort.Name = "cbPurgeRxAbort"
        Me.cbPurgeRxAbort.Size = New System.Drawing.Size(68, 17)
        Me.cbPurgeRxAbort.TabIndex = 151
        Me.cbPurgeRxAbort.Text = "RX abort"
        Me.cbPurgeRxAbort.UseVisualStyleBackColor = True
        '
        'btFunc
        '
        Me.btFunc.Location = New System.Drawing.Point(778, 82)
        Me.btFunc.Name = "btFunc"
        Me.btFunc.Size = New System.Drawing.Size(75, 23)
        Me.btFunc.TabIndex = 150
        Me.btFunc.Text = "Exec func"
        Me.btFunc.UseVisualStyleBackColor = True
        '
        'laFunc
        '
        Me.laFunc.AutoSize = True
        Me.laFunc.Location = New System.Drawing.Point(610, 85)
        Me.laFunc.Name = "laFunc"
        Me.laFunc.Size = New System.Drawing.Size(48, 13)
        Me.laFunc.TabIndex = 149
        Me.laFunc.Text = "Function"
        '
        'cbFunc
        '
        Me.cbFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFunc.FormattingEnabled = True
        Me.cbFunc.Items.AddRange(New Object() {"escClrBreak", "escClrDtr", "escClrRts", "escSetBreak", "escSetDtr", "escSetRts", "escSetXoff", "escSetXon"})
        Me.cbFunc.Location = New System.Drawing.Point(664, 82)
        Me.cbFunc.Name = "cbFunc"
        Me.cbFunc.Size = New System.Drawing.Size(108, 21)
        Me.cbFunc.TabIndex = 148
        '
        'btSetCommBreak
        '
        Me.btSetCommBreak.Location = New System.Drawing.Point(735, 53)
        Me.btSetCommBreak.Name = "btSetCommBreak"
        Me.btSetCommBreak.Size = New System.Drawing.Size(116, 23)
        Me.btSetCommBreak.TabIndex = 147
        Me.btSetCommBreak.Text = "Set comm BREAK"
        Me.btSetCommBreak.UseVisualStyleBackColor = True
        '
        'btClearCommBreak
        '
        Me.btClearCommBreak.Location = New System.Drawing.Point(613, 53)
        Me.btClearCommBreak.Name = "btClearCommBreak"
        Me.btClearCommBreak.Size = New System.Drawing.Size(116, 23)
        Me.btClearCommBreak.TabIndex = 146
        Me.btClearCommBreak.Text = "Clear comm BREAK"
        Me.btClearCommBreak.UseVisualStyleBackColor = True
        '
        'laWriteConstant
        '
        Me.laWriteConstant.AutoSize = True
        Me.laWriteConstant.Location = New System.Drawing.Point(418, 291)
        Me.laWriteConstant.Name = "laWriteConstant"
        Me.laWriteConstant.Size = New System.Drawing.Size(76, 13)
        Me.laWriteConstant.TabIndex = 145
        Me.laWriteConstant.Text = "Write constant"
        '
        'laWriteMultiplier
        '
        Me.laWriteMultiplier.AutoSize = True
        Me.laWriteMultiplier.Location = New System.Drawing.Point(418, 265)
        Me.laWriteMultiplier.Name = "laWriteMultiplier"
        Me.laWriteMultiplier.Size = New System.Drawing.Size(75, 13)
        Me.laWriteMultiplier.TabIndex = 144
        Me.laWriteMultiplier.Text = "Write multiplier"
        '
        'laReadConstant
        '
        Me.laReadConstant.AutoSize = True
        Me.laReadConstant.Location = New System.Drawing.Point(418, 239)
        Me.laReadConstant.Name = "laReadConstant"
        Me.laReadConstant.Size = New System.Drawing.Size(77, 13)
        Me.laReadConstant.TabIndex = 143
        Me.laReadConstant.Text = "Read constant"
        '
        'laReadMultiplier
        '
        Me.laReadMultiplier.AutoSize = True
        Me.laReadMultiplier.Location = New System.Drawing.Point(418, 213)
        Me.laReadMultiplier.Name = "laReadMultiplier"
        Me.laReadMultiplier.Size = New System.Drawing.Size(76, 13)
        Me.laReadMultiplier.TabIndex = 142
        Me.laReadMultiplier.Text = "Read multiplier"
        '
        'laReadInterval
        '
        Me.laReadInterval.AutoSize = True
        Me.laReadInterval.Location = New System.Drawing.Point(418, 187)
        Me.laReadInterval.Name = "laReadInterval"
        Me.laReadInterval.Size = New System.Drawing.Size(70, 13)
        Me.laReadInterval.TabIndex = 141
        Me.laReadInterval.Text = "Read interval"
        '
        'edWriteConstant
        '
        Me.edWriteConstant.Location = New System.Drawing.Point(508, 288)
        Me.edWriteConstant.Name = "edWriteConstant"
        Me.edWriteConstant.Size = New System.Drawing.Size(83, 20)
        Me.edWriteConstant.TabIndex = 140
        '
        'edWriteMultiplier
        '
        Me.edWriteMultiplier.Location = New System.Drawing.Point(508, 262)
        Me.edWriteMultiplier.Name = "edWriteMultiplier"
        Me.edWriteMultiplier.Size = New System.Drawing.Size(82, 20)
        Me.edWriteMultiplier.TabIndex = 139
        '
        'edReadConstant
        '
        Me.edReadConstant.Location = New System.Drawing.Point(508, 236)
        Me.edReadConstant.Name = "edReadConstant"
        Me.edReadConstant.Size = New System.Drawing.Size(82, 20)
        Me.edReadConstant.TabIndex = 138
        '
        'edReadMultiplier
        '
        Me.edReadMultiplier.Location = New System.Drawing.Point(508, 210)
        Me.edReadMultiplier.Name = "edReadMultiplier"
        Me.edReadMultiplier.Size = New System.Drawing.Size(83, 20)
        Me.edReadMultiplier.TabIndex = 137
        '
        'edReadInterval
        '
        Me.edReadInterval.Location = New System.Drawing.Point(507, 184)
        Me.edReadInterval.Name = "edReadInterval"
        Me.edReadInterval.Size = New System.Drawing.Size(84, 20)
        Me.edReadInterval.TabIndex = 136
        '
        'btSetTimeouts
        '
        Me.btSetTimeouts.Location = New System.Drawing.Point(508, 155)
        Me.btSetTimeouts.Name = "btSetTimeouts"
        Me.btSetTimeouts.Size = New System.Drawing.Size(75, 23)
        Me.btSetTimeouts.TabIndex = 135
        Me.btSetTimeouts.Text = "Set timeouts"
        Me.btSetTimeouts.UseVisualStyleBackColor = True
        '
        'btGetTimeouts
        '
        Me.btGetTimeouts.Location = New System.Drawing.Point(427, 155)
        Me.btGetTimeouts.Name = "btGetTimeouts"
        Me.btGetTimeouts.Size = New System.Drawing.Size(75, 23)
        Me.btGetTimeouts.TabIndex = 134
        Me.btGetTimeouts.Text = "Get timeouts"
        Me.btGetTimeouts.UseVisualStyleBackColor = True
        '
        'laWriteBufferSize
        '
        Me.laWriteBufferSize.AutoSize = True
        Me.laWriteBufferSize.Location = New System.Drawing.Point(418, 111)
        Me.laWriteBufferSize.Name = "laWriteBufferSize"
        Me.laWriteBufferSize.Size = New System.Drawing.Size(83, 13)
        Me.laWriteBufferSize.TabIndex = 133
        Me.laWriteBufferSize.Text = "Write buffer size"
        '
        'edWriteBufferSize
        '
        Me.edWriteBufferSize.Location = New System.Drawing.Point(507, 108)
        Me.edWriteBufferSize.Name = "edWriteBufferSize"
        Me.edWriteBufferSize.Size = New System.Drawing.Size(83, 20)
        Me.edWriteBufferSize.TabIndex = 132
        '
        'edReadBufferSize
        '
        Me.edReadBufferSize.Location = New System.Drawing.Point(508, 82)
        Me.edReadBufferSize.Name = "edReadBufferSize"
        Me.edReadBufferSize.Size = New System.Drawing.Size(83, 20)
        Me.edReadBufferSize.TabIndex = 131
        '
        'laReadBufferSize
        '
        Me.laReadBufferSize.AutoSize = True
        Me.laReadBufferSize.Location = New System.Drawing.Point(418, 85)
        Me.laReadBufferSize.Name = "laReadBufferSize"
        Me.laReadBufferSize.Size = New System.Drawing.Size(84, 13)
        Me.laReadBufferSize.TabIndex = 130
        Me.laReadBufferSize.Text = "Read buffer size"
        '
        'btSetBuffers
        '
        Me.btSetBuffers.Location = New System.Drawing.Point(508, 53)
        Me.btSetBuffers.Name = "btSetBuffers"
        Me.btSetBuffers.Size = New System.Drawing.Size(75, 23)
        Me.btSetBuffers.TabIndex = 129
        Me.btSetBuffers.Text = "Set buffers"
        Me.btSetBuffers.UseVisualStyleBackColor = True
        '
        'btGetBuffers
        '
        Me.btGetBuffers.Location = New System.Drawing.Point(427, 53)
        Me.btGetBuffers.Name = "btGetBuffers"
        Me.btGetBuffers.Size = New System.Drawing.Size(75, 23)
        Me.btGetBuffers.TabIndex = 128
        Me.btGetBuffers.Text = "Get buffers"
        Me.btGetBuffers.UseVisualStyleBackColor = True
        '
        'cbAbortOnError
        '
        Me.cbAbortOnError.AutoSize = True
        Me.cbAbortOnError.Location = New System.Drawing.Point(254, 306)
        Me.cbAbortOnError.Name = "cbAbortOnError"
        Me.cbAbortOnError.Size = New System.Drawing.Size(90, 17)
        Me.cbAbortOnError.TabIndex = 127
        Me.cbAbortOnError.Text = "Abort on error"
        Me.cbAbortOnError.UseVisualStyleBackColor = True
        '
        'cbInX
        '
        Me.cbInX.AutoSize = True
        Me.cbInX.Location = New System.Drawing.Point(254, 283)
        Me.cbInX.Name = "cbInX"
        Me.cbInX.Size = New System.Drawing.Size(44, 17)
        Me.cbInX.TabIndex = 126
        Me.cbInX.Text = "INX"
        Me.cbInX.UseVisualStyleBackColor = True
        '
        'cbOutX
        '
        Me.cbOutX.AutoSize = True
        Me.cbOutX.Location = New System.Drawing.Point(254, 260)
        Me.cbOutX.Name = "cbOutX"
        Me.cbOutX.Size = New System.Drawing.Size(56, 17)
        Me.cbOutX.TabIndex = 125
        Me.cbOutX.Text = "OUTX"
        Me.cbOutX.UseVisualStyleBackColor = True
        '
        'cbDsrSensitivity
        '
        Me.cbDsrSensitivity.AutoSize = True
        Me.cbDsrSensitivity.Location = New System.Drawing.Point(254, 237)
        Me.cbDsrSensitivity.Name = "cbDsrSensitivity"
        Me.cbDsrSensitivity.Size = New System.Drawing.Size(97, 17)
        Me.cbDsrSensitivity.TabIndex = 124
        Me.cbDsrSensitivity.Text = "DSR sensitivity"
        Me.cbDsrSensitivity.UseVisualStyleBackColor = True
        '
        'cbOutxCtsFlow
        '
        Me.cbOutxCtsFlow.AutoSize = True
        Me.cbOutxCtsFlow.Location = New System.Drawing.Point(254, 214)
        Me.cbOutxCtsFlow.Name = "cbOutxCtsFlow"
        Me.cbOutxCtsFlow.Size = New System.Drawing.Size(105, 17)
        Me.cbOutxCtsFlow.TabIndex = 123
        Me.cbOutxCtsFlow.Text = "OUTX CTS  flow"
        Me.cbOutxCtsFlow.UseVisualStyleBackColor = True
        '
        'cbNullStrip
        '
        Me.cbNullStrip.AutoSize = True
        Me.cbNullStrip.Location = New System.Drawing.Point(92, 306)
        Me.cbNullStrip.Name = "cbNullStrip"
        Me.cbNullStrip.Size = New System.Drawing.Size(76, 17)
        Me.cbNullStrip.TabIndex = 122
        Me.cbNullStrip.Text = "NULL strip"
        Me.cbNullStrip.UseVisualStyleBackColor = True
        '
        'cbErrorCharReplace
        '
        Me.cbErrorCharReplace.AutoSize = True
        Me.cbErrorCharReplace.Location = New System.Drawing.Point(92, 283)
        Me.cbErrorCharReplace.Name = "cbErrorCharReplace"
        Me.cbErrorCharReplace.Size = New System.Drawing.Size(110, 17)
        Me.cbErrorCharReplace.TabIndex = 121
        Me.cbErrorCharReplace.Text = "Error char replace"
        Me.cbErrorCharReplace.UseVisualStyleBackColor = True
        '
        'cbTXContinueOnXoff
        '
        Me.cbTXContinueOnXoff.AutoSize = True
        Me.cbTXContinueOnXoff.Location = New System.Drawing.Point(92, 260)
        Me.cbTXContinueOnXoff.Name = "cbTXContinueOnXoff"
        Me.cbTXContinueOnXoff.Size = New System.Drawing.Size(129, 17)
        Me.cbTXContinueOnXoff.TabIndex = 120
        Me.cbTXContinueOnXoff.Text = "TX continue on XOFF"
        Me.cbTXContinueOnXoff.UseVisualStyleBackColor = True
        '
        'cbOutxDsrFlow
        '
        Me.cbOutxDsrFlow.AutoSize = True
        Me.cbOutxDsrFlow.Location = New System.Drawing.Point(92, 237)
        Me.cbOutxDsrFlow.Name = "cbOutxDsrFlow"
        Me.cbOutxDsrFlow.Size = New System.Drawing.Size(104, 17)
        Me.cbOutxDsrFlow.TabIndex = 119
        Me.cbOutxDsrFlow.Text = "OUTX DSR flow"
        Me.cbOutxDsrFlow.UseVisualStyleBackColor = True
        '
        'cbParityCheck
        '
        Me.cbParityCheck.AutoSize = True
        Me.cbParityCheck.Location = New System.Drawing.Point(92, 214)
        Me.cbParityCheck.Name = "cbParityCheck"
        Me.cbParityCheck.Size = New System.Drawing.Size(85, 17)
        Me.cbParityCheck.TabIndex = 118
        Me.cbParityCheck.Text = "Parity check"
        Me.cbParityCheck.UseVisualStyleBackColor = True
        '
        'edEvtChar
        '
        Me.edEvtChar.Location = New System.Drawing.Point(372, 188)
        Me.edEvtChar.Name = "edEvtChar"
        Me.edEvtChar.Size = New System.Drawing.Size(29, 20)
        Me.edEvtChar.TabIndex = 117
        '
        'laEvtChar
        '
        Me.laEvtChar.AutoSize = True
        Me.laEvtChar.Location = New System.Drawing.Point(338, 191)
        Me.laEvtChar.Name = "laEvtChar"
        Me.laEvtChar.Size = New System.Drawing.Size(28, 13)
        Me.laEvtChar.TabIndex = 116
        Me.laEvtChar.Text = "EVT"
        '
        'edEofChar
        '
        Me.edEofChar.Location = New System.Drawing.Point(291, 188)
        Me.edEofChar.Name = "edEofChar"
        Me.edEofChar.Size = New System.Drawing.Size(29, 20)
        Me.edEofChar.TabIndex = 115
        '
        'laEofChar
        '
        Me.laEofChar.AutoSize = True
        Me.laEofChar.Location = New System.Drawing.Point(257, 191)
        Me.laEofChar.Name = "laEofChar"
        Me.laEofChar.Size = New System.Drawing.Size(28, 13)
        Me.laEofChar.TabIndex = 114
        Me.laEofChar.Text = "EOF"
        '
        'edErrorChar
        '
        Me.edErrorChar.Location = New System.Drawing.Point(210, 188)
        Me.edErrorChar.Name = "edErrorChar"
        Me.edErrorChar.Size = New System.Drawing.Size(29, 20)
        Me.edErrorChar.TabIndex = 113
        '
        'laErrorChar
        '
        Me.laErrorChar.AutoSize = True
        Me.laErrorChar.Location = New System.Drawing.Point(175, 191)
        Me.laErrorChar.Name = "laErrorChar"
        Me.laErrorChar.Size = New System.Drawing.Size(29, 13)
        Me.laErrorChar.TabIndex = 112
        Me.laErrorChar.Text = "Error"
        '
        'edXoffChar
        '
        Me.edXoffChar.Location = New System.Drawing.Point(129, 188)
        Me.edXoffChar.Name = "edXoffChar"
        Me.edXoffChar.Size = New System.Drawing.Size(29, 20)
        Me.edXoffChar.TabIndex = 111
        '
        'laXoffChar
        '
        Me.laXoffChar.AutoSize = True
        Me.laXoffChar.Location = New System.Drawing.Point(89, 191)
        Me.laXoffChar.Name = "laXoffChar"
        Me.laXoffChar.Size = New System.Drawing.Size(34, 13)
        Me.laXoffChar.TabIndex = 110
        Me.laXoffChar.Text = "XOFF"
        '
        'edXonChar
        '
        Me.edXonChar.Location = New System.Drawing.Point(48, 188)
        Me.edXonChar.Name = "edXonChar"
        Me.edXonChar.Size = New System.Drawing.Size(29, 20)
        Me.edXonChar.TabIndex = 109
        '
        'laXonChar
        '
        Me.laXonChar.AutoSize = True
        Me.laXonChar.Location = New System.Drawing.Point(12, 191)
        Me.laXonChar.Name = "laXonChar"
        Me.laXonChar.Size = New System.Drawing.Size(30, 13)
        Me.laXonChar.TabIndex = 108
        Me.laXonChar.Text = "XON"
        '
        'laXoffLim
        '
        Me.laXoffLim.AutoSize = True
        Me.laXoffLim.Location = New System.Drawing.Point(209, 165)
        Me.laXoffLim.Name = "laXoffLim"
        Me.laXoffLim.Size = New System.Drawing.Size(49, 13)
        Me.laXoffLim.TabIndex = 107
        Me.laXoffLim.Text = "XOFF lim"
        '
        'edXoffLim
        '
        Me.edXoffLim.Location = New System.Drawing.Point(280, 162)
        Me.edXoffLim.Name = "edXoffLim"
        Me.edXoffLim.Size = New System.Drawing.Size(121, 20)
        Me.edXoffLim.TabIndex = 106
        '
        'laStopBites
        '
        Me.laStopBites.AutoSize = True
        Me.laStopBites.Location = New System.Drawing.Point(209, 138)
        Me.laStopBites.Name = "laStopBites"
        Me.laStopBites.Size = New System.Drawing.Size(48, 13)
        Me.laStopBites.TabIndex = 105
        Me.laStopBites.Text = "Stop bits"
        '
        'cbStopBits
        '
        Me.cbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStopBits.FormattingEnabled = True
        Me.cbStopBits.Items.AddRange(New Object() {"sbOne", "sbOne5", "sbTwo"})
        Me.cbStopBits.Location = New System.Drawing.Point(280, 135)
        Me.cbStopBits.Name = "cbStopBits"
        Me.cbStopBits.Size = New System.Drawing.Size(121, 21)
        Me.cbStopBits.TabIndex = 104
        '
        'laByteSize
        '
        Me.laByteSize.AutoSize = True
        Me.laByteSize.Location = New System.Drawing.Point(209, 111)
        Me.laByteSize.Name = "laByteSize"
        Me.laByteSize.Size = New System.Drawing.Size(49, 13)
        Me.laByteSize.TabIndex = 103
        Me.laByteSize.Text = "Byte size"
        '
        'cbByteSize
        '
        Me.cbByteSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbByteSize.FormattingEnabled = True
        Me.cbByteSize.Items.AddRange(New Object() {"4", "5", "6", "7", "8"})
        Me.cbByteSize.Location = New System.Drawing.Point(280, 108)
        Me.cbByteSize.Name = "cbByteSize"
        Me.cbByteSize.Size = New System.Drawing.Size(121, 21)
        Me.cbByteSize.TabIndex = 102
        '
        'laDtrControl
        '
        Me.laDtrControl.AutoSize = True
        Me.laDtrControl.Location = New System.Drawing.Point(209, 85)
        Me.laDtrControl.Name = "laDtrControl"
        Me.laDtrControl.Size = New System.Drawing.Size(65, 13)
        Me.laDtrControl.TabIndex = 101
        Me.laDtrControl.Text = "DTR control"
        '
        'cbDtrControl
        '
        Me.cbDtrControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDtrControl.FormattingEnabled = True
        Me.cbDtrControl.Items.AddRange(New Object() {"dtrControlDisable", "dtrControlEnable", "dtrControlHandshake"})
        Me.cbDtrControl.Location = New System.Drawing.Point(280, 82)
        Me.cbDtrControl.Name = "cbDtrControl"
        Me.cbDtrControl.Size = New System.Drawing.Size(121, 21)
        Me.cbDtrControl.TabIndex = 100
        '
        'laXonLim
        '
        Me.laXonLim.AutoSize = True
        Me.laXonLim.Location = New System.Drawing.Point(12, 165)
        Me.laXonLim.Name = "laXonLim"
        Me.laXonLim.Size = New System.Drawing.Size(45, 13)
        Me.laXonLim.TabIndex = 99
        Me.laXonLim.Text = "XON lim"
        '
        'edXonLim
        '
        Me.edXonLim.Location = New System.Drawing.Point(82, 162)
        Me.edXonLim.Name = "edXonLim"
        Me.edXonLim.Size = New System.Drawing.Size(121, 20)
        Me.edXonLim.TabIndex = 98
        '
        'laParity
        '
        Me.laParity.AutoSize = True
        Me.laParity.Location = New System.Drawing.Point(12, 138)
        Me.laParity.Name = "laParity"
        Me.laParity.Size = New System.Drawing.Size(33, 13)
        Me.laParity.TabIndex = 97
        Me.laParity.Text = "Parity"
        '
        'cbParity
        '
        Me.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbParity.FormattingEnabled = True
        Me.cbParity.Items.AddRange(New Object() {"spNo", "spOdd", "spEven", "spMark", "spSpace"})
        Me.cbParity.Location = New System.Drawing.Point(82, 135)
        Me.cbParity.Name = "cbParity"
        Me.cbParity.Size = New System.Drawing.Size(121, 21)
        Me.cbParity.TabIndex = 96
        '
        'laRtsControl
        '
        Me.laRtsControl.AutoSize = True
        Me.laRtsControl.Location = New System.Drawing.Point(12, 111)
        Me.laRtsControl.Name = "laRtsControl"
        Me.laRtsControl.Size = New System.Drawing.Size(64, 13)
        Me.laRtsControl.TabIndex = 95
        Me.laRtsControl.Text = "RTS control"
        '
        'cbRtsControl
        '
        Me.cbRtsControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRtsControl.FormattingEnabled = True
        Me.cbRtsControl.Items.AddRange(New Object() {"rtsControlDisable", "rtsControlEnable", "rtsControlHandshake", "rtsControlToggle"})
        Me.cbRtsControl.Location = New System.Drawing.Point(82, 108)
        Me.cbRtsControl.Name = "cbRtsControl"
        Me.cbRtsControl.Size = New System.Drawing.Size(121, 21)
        Me.cbRtsControl.TabIndex = 94
        '
        'edBaudRate
        '
        Me.edBaudRate.Location = New System.Drawing.Point(82, 82)
        Me.edBaudRate.Name = "edBaudRate"
        Me.edBaudRate.Size = New System.Drawing.Size(121, 20)
        Me.edBaudRate.TabIndex = 93
        '
        'laBaudRate
        '
        Me.laBaudRate.AutoSize = True
        Me.laBaudRate.Location = New System.Drawing.Point(12, 85)
        Me.laBaudRate.Name = "laBaudRate"
        Me.laBaudRate.Size = New System.Drawing.Size(50, 13)
        Me.laBaudRate.TabIndex = 92
        Me.laBaudRate.Text = "Baudrate"
        '
        'btSetConfig
        '
        Me.btSetConfig.Location = New System.Drawing.Point(93, 53)
        Me.btSetConfig.Name = "btSetConfig"
        Me.btSetConfig.Size = New System.Drawing.Size(75, 23)
        Me.btSetConfig.TabIndex = 91
        Me.btSetConfig.Text = "Set config"
        Me.btSetConfig.UseVisualStyleBackColor = True
        '
        'btGetConfig
        '
        Me.btGetConfig.Location = New System.Drawing.Point(12, 53)
        Me.btGetConfig.Name = "btGetConfig"
        Me.btGetConfig.Size = New System.Drawing.Size(75, 23)
        Me.btGetConfig.TabIndex = 90
        Me.btGetConfig.Text = "Get config"
        Me.btGetConfig.UseVisualStyleBackColor = True
        '
        'btSetWriteTimeout
        '
        Me.btSetWriteTimeout.Location = New System.Drawing.Point(554, 11)
        Me.btSetWriteTimeout.Name = "btSetWriteTimeout"
        Me.btSetWriteTimeout.Size = New System.Drawing.Size(104, 23)
        Me.btSetWriteTimeout.TabIndex = 89
        Me.btSetWriteTimeout.Text = "Set write timeout"
        Me.btSetWriteTimeout.UseVisualStyleBackColor = True
        '
        'edWriteTimeout
        '
        Me.edWriteTimeout.Location = New System.Drawing.Point(448, 13)
        Me.edWriteTimeout.Name = "edWriteTimeout"
        Me.edWriteTimeout.Size = New System.Drawing.Size(100, 20)
        Me.edWriteTimeout.TabIndex = 88
        '
        'laWriteTimeout
        '
        Me.laWriteTimeout.AutoSize = True
        Me.laWriteTimeout.Location = New System.Drawing.Point(373, 16)
        Me.laWriteTimeout.Name = "laWriteTimeout"
        Me.laWriteTimeout.Size = New System.Drawing.Size(69, 13)
        Me.laWriteTimeout.TabIndex = 87
        Me.laWriteTimeout.Text = "Write timeout"
        '
        'btDisconnect
        '
        Me.btDisconnect.Location = New System.Drawing.Point(292, 11)
        Me.btDisconnect.Name = "btDisconnect"
        Me.btDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.btDisconnect.TabIndex = 86
        Me.btDisconnect.Text = "Disconnect"
        Me.btDisconnect.UseVisualStyleBackColor = True
        '
        'btConnect
        '
        Me.btConnect.Location = New System.Drawing.Point(211, 11)
        Me.btConnect.Name = "btConnect"
        Me.btConnect.Size = New System.Drawing.Size(75, 23)
        Me.btConnect.TabIndex = 85
        Me.btConnect.Text = "Connect"
        Me.btConnect.UseVisualStyleBackColor = True
        '
        'cbPorts
        '
        Me.cbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPorts.FormattingEnabled = True
        Me.cbPorts.Location = New System.Drawing.Point(93, 13)
        Me.cbPorts.Name = "cbPorts"
        Me.cbPorts.Size = New System.Drawing.Size(112, 21)
        Me.cbPorts.TabIndex = 84
        '
        'btEnum
        '
        Me.btEnum.Location = New System.Drawing.Point(12, 11)
        Me.btEnum.Name = "btEnum"
        Me.btEnum.Size = New System.Drawing.Size(75, 23)
        Me.btEnum.TabIndex = 83
        Me.btEnum.Text = "Enum"
        Me.btEnum.UseVisualStyleBackColor = True
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 563)
        Me.Controls.Add(Me.lbEvents)
        Me.Controls.Add(Me.btClear)
        Me.Controls.Add(Me.cbLineFeed)
        Me.Controls.Add(Me.laLineFeed)
        Me.Controls.Add(Me.btSend)
        Me.Controls.Add(Me.edText)
        Me.Controls.Add(Me.btFlushBuffers)
        Me.Controls.Add(Me.laCharCode)
        Me.Controls.Add(Me.btTransmit)
        Me.Controls.Add(Me.edChar)
        Me.Controls.Add(Me.btPurge)
        Me.Controls.Add(Me.cbPurgeTxClear)
        Me.Controls.Add(Me.cbPurgeTxAbort)
        Me.Controls.Add(Me.cbPurgeRxClear)
        Me.Controls.Add(Me.cbPurgeRxAbort)
        Me.Controls.Add(Me.btFunc)
        Me.Controls.Add(Me.laFunc)
        Me.Controls.Add(Me.cbFunc)
        Me.Controls.Add(Me.btSetCommBreak)
        Me.Controls.Add(Me.btClearCommBreak)
        Me.Controls.Add(Me.laWriteConstant)
        Me.Controls.Add(Me.laWriteMultiplier)
        Me.Controls.Add(Me.laReadConstant)
        Me.Controls.Add(Me.laReadMultiplier)
        Me.Controls.Add(Me.laReadInterval)
        Me.Controls.Add(Me.edWriteConstant)
        Me.Controls.Add(Me.edWriteMultiplier)
        Me.Controls.Add(Me.edReadConstant)
        Me.Controls.Add(Me.edReadMultiplier)
        Me.Controls.Add(Me.edReadInterval)
        Me.Controls.Add(Me.btSetTimeouts)
        Me.Controls.Add(Me.btGetTimeouts)
        Me.Controls.Add(Me.laWriteBufferSize)
        Me.Controls.Add(Me.edWriteBufferSize)
        Me.Controls.Add(Me.edReadBufferSize)
        Me.Controls.Add(Me.laReadBufferSize)
        Me.Controls.Add(Me.btSetBuffers)
        Me.Controls.Add(Me.btGetBuffers)
        Me.Controls.Add(Me.cbAbortOnError)
        Me.Controls.Add(Me.cbInX)
        Me.Controls.Add(Me.cbOutX)
        Me.Controls.Add(Me.cbDsrSensitivity)
        Me.Controls.Add(Me.cbOutxCtsFlow)
        Me.Controls.Add(Me.cbNullStrip)
        Me.Controls.Add(Me.cbErrorCharReplace)
        Me.Controls.Add(Me.cbTXContinueOnXoff)
        Me.Controls.Add(Me.cbOutxDsrFlow)
        Me.Controls.Add(Me.cbParityCheck)
        Me.Controls.Add(Me.edEvtChar)
        Me.Controls.Add(Me.laEvtChar)
        Me.Controls.Add(Me.edEofChar)
        Me.Controls.Add(Me.laEofChar)
        Me.Controls.Add(Me.edErrorChar)
        Me.Controls.Add(Me.laErrorChar)
        Me.Controls.Add(Me.edXoffChar)
        Me.Controls.Add(Me.laXoffChar)
        Me.Controls.Add(Me.edXonChar)
        Me.Controls.Add(Me.laXonChar)
        Me.Controls.Add(Me.laXoffLim)
        Me.Controls.Add(Me.edXoffLim)
        Me.Controls.Add(Me.laStopBites)
        Me.Controls.Add(Me.cbStopBits)
        Me.Controls.Add(Me.laByteSize)
        Me.Controls.Add(Me.cbByteSize)
        Me.Controls.Add(Me.laDtrControl)
        Me.Controls.Add(Me.cbDtrControl)
        Me.Controls.Add(Me.laXonLim)
        Me.Controls.Add(Me.edXonLim)
        Me.Controls.Add(Me.laParity)
        Me.Controls.Add(Me.cbParity)
        Me.Controls.Add(Me.laRtsControl)
        Me.Controls.Add(Me.cbRtsControl)
        Me.Controls.Add(Me.edBaudRate)
        Me.Controls.Add(Me.laBaudRate)
        Me.Controls.Add(Me.btSetConfig)
        Me.Controls.Add(Me.btGetConfig)
        Me.Controls.Add(Me.btSetWriteTimeout)
        Me.Controls.Add(Me.edWriteTimeout)
        Me.Controls.Add(Me.laWriteTimeout)
        Me.Controls.Add(Me.btDisconnect)
        Me.Controls.Add(Me.btConnect)
        Me.Controls.Add(Me.cbPorts)
        Me.Controls.Add(Me.btEnum)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "fmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serial Client Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents lbEvents As ListBox
    Private WithEvents btClear As Button
    Private WithEvents cbLineFeed As ComboBox
    Private WithEvents laLineFeed As Label
    Private WithEvents btSend As Button
    Private WithEvents edText As TextBox
    Private WithEvents btFlushBuffers As Button
    Private WithEvents laCharCode As Label
    Private WithEvents btTransmit As Button
    Private WithEvents edChar As TextBox
    Private WithEvents btPurge As Button
    Private WithEvents cbPurgeTxClear As CheckBox
    Private WithEvents cbPurgeTxAbort As CheckBox
    Private WithEvents cbPurgeRxClear As CheckBox
    Private WithEvents cbPurgeRxAbort As CheckBox
    Private WithEvents btFunc As Button
    Private WithEvents laFunc As Label
    Private WithEvents cbFunc As ComboBox
    Private WithEvents btSetCommBreak As Button
    Private WithEvents btClearCommBreak As Button
    Private WithEvents laWriteConstant As Label
    Private WithEvents laWriteMultiplier As Label
    Private WithEvents laReadConstant As Label
    Private WithEvents laReadMultiplier As Label
    Private WithEvents laReadInterval As Label
    Private WithEvents edWriteConstant As TextBox
    Private WithEvents edWriteMultiplier As TextBox
    Private WithEvents edReadConstant As TextBox
    Private WithEvents edReadMultiplier As TextBox
    Private WithEvents edReadInterval As TextBox
    Private WithEvents btSetTimeouts As Button
    Private WithEvents btGetTimeouts As Button
    Private WithEvents laWriteBufferSize As Label
    Private WithEvents edWriteBufferSize As TextBox
    Private WithEvents edReadBufferSize As TextBox
    Private WithEvents laReadBufferSize As Label
    Private WithEvents btSetBuffers As Button
    Private WithEvents btGetBuffers As Button
    Private WithEvents cbAbortOnError As CheckBox
    Private WithEvents cbInX As CheckBox
    Private WithEvents cbOutX As CheckBox
    Private WithEvents cbDsrSensitivity As CheckBox
    Private WithEvents cbOutxCtsFlow As CheckBox
    Private WithEvents cbNullStrip As CheckBox
    Private WithEvents cbErrorCharReplace As CheckBox
    Private WithEvents cbTXContinueOnXoff As CheckBox
    Private WithEvents cbOutxDsrFlow As CheckBox
    Private WithEvents cbParityCheck As CheckBox
    Private WithEvents edEvtChar As TextBox
    Private WithEvents laEvtChar As Label
    Private WithEvents edEofChar As TextBox
    Private WithEvents laEofChar As Label
    Private WithEvents edErrorChar As TextBox
    Private WithEvents laErrorChar As Label
    Private WithEvents edXoffChar As TextBox
    Private WithEvents laXoffChar As Label
    Private WithEvents edXonChar As TextBox
    Private WithEvents laXonChar As Label
    Private WithEvents laXoffLim As Label
    Private WithEvents edXoffLim As TextBox
    Private WithEvents laStopBites As Label
    Private WithEvents cbStopBits As ComboBox
    Private WithEvents laByteSize As Label
    Private WithEvents cbByteSize As ComboBox
    Private WithEvents laDtrControl As Label
    Private WithEvents cbDtrControl As ComboBox
    Private WithEvents laXonLim As Label
    Private WithEvents edXonLim As TextBox
    Private WithEvents laParity As Label
    Private WithEvents cbParity As ComboBox
    Private WithEvents laRtsControl As Label
    Private WithEvents cbRtsControl As ComboBox
    Private WithEvents edBaudRate As TextBox
    Private WithEvents laBaudRate As Label
    Private WithEvents btSetConfig As Button
    Private WithEvents btGetConfig As Button
    Private WithEvents btSetWriteTimeout As Button
    Private WithEvents edWriteTimeout As TextBox
    Private WithEvents laWriteTimeout As Label
    Private WithEvents btDisconnect As Button
    Private WithEvents btConnect As Button
    Private WithEvents cbPorts As ComboBox
    Private WithEvents btEnum As Button
End Class
