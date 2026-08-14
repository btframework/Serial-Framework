object fmMain: TfmMain
  Left = 385
  Top = 220
  BorderStyle = bsSingle
  Caption = 'Serial Client Demo'
  ClientHeight = 561
  ClientWidth = 867
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object laBaudRate: TLabel
    Left = 8
    Top = 88
    Width = 43
    Height = 13
    Caption = 'Baudrate'
  end
  object laDtrControl: TLabel
    Left = 216
    Top = 88
    Width = 50
    Height = 13
    Caption = 'Dtr Control'
  end
  object laRtsControl: TLabel
    Left = 8
    Top = 112
    Width = 52
    Height = 13
    Caption = 'Rts Control'
  end
  object laXonLim: TLabel
    Left = 8
    Top = 160
    Width = 38
    Height = 13
    Caption = 'Xon Lim'
  end
  object laXoffLim: TLabel
    Left = 216
    Top = 160
    Width = 38
    Height = 13
    Caption = 'Xoff Lim'
  end
  object laByteSize: TLabel
    Left = 216
    Top = 112
    Width = 44
    Height = 13
    Caption = 'Byte Size'
  end
  object laParity: TLabel
    Left = 8
    Top = 136
    Width = 26
    Height = 13
    Caption = 'Parity'
  end
  object laStopBites: TLabel
    Left = 216
    Top = 136
    Width = 42
    Height = 13
    Caption = 'Stop Bits'
  end
  object laXonChar: TLabel
    Left = 8
    Top = 192
    Width = 44
    Height = 13
    Caption = 'Xon Char'
  end
  object laXoffChar: TLabel
    Left = 88
    Top = 192
    Width = 44
    Height = 13
    Caption = 'Xoff Char'
  end
  object laErrorChar: TLabel
    Left = 168
    Top = 192
    Width = 47
    Height = 13
    Caption = 'Error Char'
  end
  object laEofChar: TLabel
    Left = 256
    Top = 192
    Width = 41
    Height = 13
    Caption = 'Eof Char'
  end
  object laEvtChar: TLabel
    Left = 336
    Top = 192
    Width = 41
    Height = 13
    Caption = 'Evt Char'
  end
  object laReadBufferSize: TLabel
    Left = 432
    Top = 88
    Width = 77
    Height = 13
    Caption = 'Read buffer size'
  end
  object laWriteBufferSize: TLabel
    Left = 432
    Top = 112
    Width = 76
    Height = 13
    Caption = 'Write buffer size'
  end
  object laReadInterval: TLabel
    Left = 432
    Top = 192
    Width = 64
    Height = 13
    Caption = 'Read Interval'
  end
  object laReadMultiplier: TLabel
    Left = 432
    Top = 216
    Width = 70
    Height = 13
    Caption = 'Read Multiplier'
  end
  object laReadConstant: TLabel
    Left = 432
    Top = 240
    Width = 71
    Height = 13
    Caption = 'Read Constant'
  end
  object laWriteMultiplier: TLabel
    Left = 432
    Top = 264
    Width = 69
    Height = 13
    Caption = 'Write Multiplier'
  end
  object laWriteConstant: TLabel
    Left = 432
    Top = 288
    Width = 70
    Height = 13
    Caption = 'Write Constant'
  end
  object laFunc: TLabel
    Left = 624
    Top = 96
    Width = 41
    Height = 13
    Caption = 'Function'
  end
  object laCharCode: TLabel
    Left = 624
    Top = 192
    Width = 85
    Height = 13
    Caption = 'Char code (ASCII)'
  end
  object laWriteTimeout: TLabel
    Left = 376
    Top = 16
    Width = 62
    Height = 13
    Caption = 'Write timeout'
  end
  object laLineFeed: TLabel
    Left = 560
    Top = 360
    Width = 44
    Height = 13
    Caption = 'Line feed'
  end
  object lbEvents: TListBox
    Left = 8
    Top = 384
    Width = 849
    Height = 169
    ItemHeight = 13
    TabOrder = 0
  end
  object btClear: TButton
    Left = 784
    Top = 352
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 1
    OnClick = btClearClick
  end
  object btEnum: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Enum'
    TabOrder = 2
    OnClick = btEnumClick
  end
  object cbPorts: TComboBox
    Left = 88
    Top = 8
    Width = 105
    Height = 21
    Style = csDropDownList
    TabOrder = 3
  end
  object btConnect: TButton
    Left = 200
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Connect'
    TabOrder = 4
    OnClick = btConnectClick
  end
  object btDisconnect: TButton
    Left = 280
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Disconnect'
    TabOrder = 5
    OnClick = btDisconnectClick
  end
  object btGetConfig: TButton
    Left = 8
    Top = 48
    Width = 75
    Height = 25
    Caption = 'Get Config'
    TabOrder = 6
    OnClick = btGetConfigClick
  end
  object edBaudRate: TEdit
    Left = 72
    Top = 80
    Width = 129
    Height = 21
    TabOrder = 7
  end
  object cbParityCheck: TCheckBox
    Left = 80
    Top = 224
    Width = 129
    Height = 17
    Caption = 'Parity check'
    TabOrder = 8
  end
  object cbOutxCtsFlow: TCheckBox
    Left = 224
    Top = 224
    Width = 129
    Height = 17
    Caption = 'Outx Cts Flow'
    TabOrder = 9
  end
  object cbOutxDsrFlow: TCheckBox
    Left = 80
    Top = 248
    Width = 129
    Height = 17
    Caption = 'Outx Dsr Flow'
    TabOrder = 10
  end
  object cbDtrControl: TComboBox
    Left = 280
    Top = 80
    Width = 129
    Height = 21
    Style = csDropDownList
    TabOrder = 11
    Items.Strings = (
      'dtrControlDisable'
      'dtrControlEnable'
      'dtrControlHandshake')
  end
  object cbDsrSensitivity: TCheckBox
    Left = 224
    Top = 248
    Width = 129
    Height = 17
    Caption = 'Dsr Sensitivity'
    TabOrder = 12
  end
  object cbTXContinueOnXoff: TCheckBox
    Left = 80
    Top = 272
    Width = 129
    Height = 17
    Caption = 'TX Continue OnX off'
    TabOrder = 13
  end
  object cbOutX: TCheckBox
    Left = 224
    Top = 272
    Width = 129
    Height = 17
    Caption = 'OutX'
    TabOrder = 14
  end
  object cbInX: TCheckBox
    Left = 224
    Top = 296
    Width = 129
    Height = 17
    Caption = 'InX'
    TabOrder = 15
  end
  object cbErrorCharReplace: TCheckBox
    Left = 80
    Top = 296
    Width = 129
    Height = 17
    Caption = 'Error Char Replace'
    TabOrder = 16
  end
  object cbNullStrip: TCheckBox
    Left = 80
    Top = 320
    Width = 129
    Height = 17
    Caption = 'Null Strip'
    TabOrder = 17
  end
  object cbRtsControl: TComboBox
    Left = 72
    Top = 104
    Width = 129
    Height = 21
    Style = csDropDownList
    TabOrder = 18
    Items.Strings = (
      'rtsControlDisable'
      'rtsControlEnable'
      'rtsControlHandshake'
      'rtsControlToggle')
  end
  object cbAbortOnError: TCheckBox
    Left = 224
    Top = 320
    Width = 129
    Height = 17
    Caption = 'Abort On Error'
    TabOrder = 19
  end
  object edXonLim: TEdit
    Left = 72
    Top = 152
    Width = 129
    Height = 21
    TabOrder = 20
  end
  object edXoffLim: TEdit
    Left = 280
    Top = 152
    Width = 129
    Height = 21
    TabOrder = 21
  end
  object cbByteSize: TComboBox
    Left = 280
    Top = 104
    Width = 129
    Height = 21
    Style = csDropDownList
    TabOrder = 22
    Items.Strings = (
      '4'
      '5'
      '6'
      '7'
      '8')
  end
  object cbParity: TComboBox
    Left = 72
    Top = 128
    Width = 129
    Height = 21
    Style = csDropDownList
    TabOrder = 23
    Items.Strings = (
      'spNo'
      'spOdd'
      'spEven'
      'spMark'
      'spSpace')
  end
  object cbStopBits: TComboBox
    Left = 280
    Top = 128
    Width = 129
    Height = 21
    Style = csDropDownList
    TabOrder = 24
    Items.Strings = (
      'sbOne'
      'sbOne5'
      'sbTwo')
  end
  object edXonChar: TEdit
    Left = 56
    Top = 184
    Width = 25
    Height = 21
    TabOrder = 25
  end
  object edXoffChar: TEdit
    Left = 136
    Top = 184
    Width = 25
    Height = 21
    TabOrder = 26
  end
  object edErrorChar: TEdit
    Left = 224
    Top = 184
    Width = 25
    Height = 21
    TabOrder = 27
  end
  object edEofChar: TEdit
    Left = 304
    Top = 184
    Width = 25
    Height = 21
    TabOrder = 28
  end
  object edEvtChar: TEdit
    Left = 384
    Top = 184
    Width = 25
    Height = 21
    TabOrder = 29
  end
  object btSetConfig: TButton
    Left = 96
    Top = 48
    Width = 75
    Height = 25
    Caption = 'Set Config'
    TabOrder = 30
    OnClick = btSetConfigClick
  end
  object edReadBufferSize: TEdit
    Left = 520
    Top = 80
    Width = 81
    Height = 21
    TabOrder = 31
  end
  object edWriteBufferSize: TEdit
    Left = 520
    Top = 104
    Width = 81
    Height = 21
    TabOrder = 32
  end
  object btGetBuffers: TButton
    Left = 432
    Top = 48
    Width = 75
    Height = 25
    Caption = 'Get buffers'
    TabOrder = 33
    OnClick = btGetBuffersClick
  end
  object btSetBuffers: TButton
    Left = 520
    Top = 48
    Width = 75
    Height = 25
    Caption = 'Set buffers'
    TabOrder = 34
    OnClick = btSetBuffersClick
  end
  object edReadInterval: TEdit
    Left = 520
    Top = 184
    Width = 81
    Height = 21
    TabOrder = 35
  end
  object edReadMultiplier: TEdit
    Left = 520
    Top = 208
    Width = 81
    Height = 21
    TabOrder = 36
  end
  object edReadConstant: TEdit
    Left = 520
    Top = 232
    Width = 81
    Height = 21
    TabOrder = 37
  end
  object edWriteMultiplier: TEdit
    Left = 520
    Top = 256
    Width = 81
    Height = 21
    TabOrder = 38
  end
  object edWriteConstant: TEdit
    Left = 520
    Top = 280
    Width = 81
    Height = 21
    TabOrder = 39
  end
  object btGetTimeouts: TButton
    Left = 432
    Top = 152
    Width = 75
    Height = 25
    Caption = 'Get timeouts'
    TabOrder = 40
    OnClick = btGetTimeoutsClick
  end
  object btSetTimeouts: TButton
    Left = 520
    Top = 152
    Width = 75
    Height = 25
    Caption = 'Set timeouts'
    TabOrder = 41
    OnClick = btSetTimeoutsClick
  end
  object btClearCommBreak: TButton
    Left = 624
    Top = 48
    Width = 105
    Height = 25
    Caption = 'Clear comm break'
    TabOrder = 42
    OnClick = btClearCommBreakClick
  end
  object cbFunc: TComboBox
    Left = 680
    Top = 88
    Width = 97
    Height = 21
    Style = csDropDownList
    ItemIndex = 0
    TabOrder = 43
    Text = 'escClrBreak'
    Items.Strings = (
      'escClrBreak'
      'escClrDtr'
      'escClrRts'
      'escSetBreak'
      'escSetDtr'
      'escSetRts'
      'escSetXoff'
      'escSetXon')
  end
  object btFunc: TButton
    Left = 784
    Top = 80
    Width = 75
    Height = 25
    Caption = 'Exec func'
    TabOrder = 44
    OnClick = btFuncClick
  end
  object btFlushBuffers: TButton
    Left = 624
    Top = 224
    Width = 75
    Height = 25
    Caption = 'Flush buffers'
    TabOrder = 45
    OnClick = btFlushBuffersClick
  end
  object cbpurgeRxAbort: TCheckBox
    Left = 624
    Top = 128
    Width = 73
    Height = 17
    Caption = 'Rx Abort'
    TabOrder = 46
  end
  object cbpurgeRxClear: TCheckBox
    Left = 624
    Top = 152
    Width = 73
    Height = 17
    Caption = 'Rx Clear'
    TabOrder = 47
  end
  object cbpurgeTxAbort: TCheckBox
    Left = 704
    Top = 128
    Width = 73
    Height = 17
    Caption = 'Tx Abort'
    TabOrder = 48
  end
  object cbpurgeTxClear: TCheckBox
    Left = 704
    Top = 152
    Width = 73
    Height = 17
    Caption = 'Tx Clear'
    TabOrder = 49
  end
  object btPurge: TButton
    Left = 784
    Top = 136
    Width = 75
    Height = 25
    Caption = 'Purge'
    TabOrder = 50
    OnClick = btPurgeClick
  end
  object btSetCommBreak: TButton
    Left = 736
    Top = 48
    Width = 89
    Height = 25
    Caption = 'Set comm break'
    TabOrder = 51
    OnClick = btSetCommBreakClick
  end
  object edChar: TEdit
    Left = 720
    Top = 184
    Width = 49
    Height = 21
    TabOrder = 52
    Text = '0'
  end
  object btTransmit: TButton
    Left = 784
    Top = 184
    Width = 75
    Height = 25
    Caption = 'Transmit'
    TabOrder = 53
    OnClick = btTransmitClick
  end
  object btSend: TButton
    Left = 480
    Top = 352
    Width = 75
    Height = 25
    Caption = 'Send'
    TabOrder = 54
    OnClick = btSendClick
  end
  object edText: TEdit
    Left = 8
    Top = 352
    Width = 465
    Height = 21
    TabOrder = 55
    Text = 'Something to send to serial'
  end
  object edWriteTimeout: TEdit
    Left = 456
    Top = 8
    Width = 121
    Height = 21
    TabOrder = 56
    Text = 'edWriteTimeout'
  end
  object btSetWriteTimeout: TButton
    Left = 592
    Top = 8
    Width = 105
    Height = 25
    Caption = 'Set write timeout'
    TabOrder = 57
    OnClick = btSetWriteTimeoutClick
  end
  object cbLineFeed: TComboBox
    Left = 616
    Top = 352
    Width = 97
    Height = 22
    Style = csOwnerDrawFixed
    ItemIndex = 0
    TabOrder = 58
    Text = 'None'
    Items.Strings = (
      'None'
      'CR'
      'LF'
      'CR & LF')
  end
end
