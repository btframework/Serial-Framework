object fmMain: TfmMain
  Left = 192
  Top = 117
  BorderStyle = bsSingle
  Caption = 'Serial Monitor Test'
  ClientHeight = 451
  ClientWidth = 554
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
  object btStart: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Start'
    TabOrder = 0
    OnClick = btStartClick
  end
  object btStop: TButton
    Left = 88
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Stop'
    TabOrder = 1
    OnClick = btStopClick
  end
  object lbLog: TListBox
    Left = 8
    Top = 248
    Width = 537
    Height = 193
    ItemHeight = 13
    TabOrder = 2
  end
  object btClear: TButton
    Left = 472
    Top = 216
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 3
    OnClick = btClearClick
  end
  object btEnumSerial: TButton
    Left = 176
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Enum serial'
    TabOrder = 4
    OnClick = btEnumSerialClick
  end
  object lvDevices: TListView
    Left = 8
    Top = 40
    Width = 537
    Height = 169
    Columns = <>
    GridLines = True
    ReadOnly = True
    RowSelect = True
    TabOrder = 5
    ViewStyle = vsReport
  end
  object btEnumUSB: TButton
    Left = 256
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Enum USB'
    TabOrder = 6
    OnClick = btEnumUSBClick
  end
  object btDisable: TButton
    Left = 368
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Disable'
    TabOrder = 7
    OnClick = btDisableClick
  end
  object btEnable: TButton
    Left = 448
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Enable'
    TabOrder = 8
    OnClick = btEnableClick
  end
end
