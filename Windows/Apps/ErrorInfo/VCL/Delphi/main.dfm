object fmMain: TfmMain
  Left = 399
  Top = 168
  BorderStyle = bsSingle
  Caption = 'Error Information'
  ClientHeight = 387
  ClientWidth = 531
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object laPath: TLabel
    Left = 8
    Top = 24
    Width = 112
    Height = 13
    Caption = 'Errors definition file path'
  end
  object laDescr: TLabel
    Left = 8
    Top = 64
    Width = 240
    Height = 13
    Caption = 'Error code. Start with $ or 0x for hexadecimal value'
  end
  object edPath: TEdit
    Left = 136
    Top = 16
    Width = 385
    Height = 21
    TabOrder = 0
    Text = 'https://www.btframework.com/errors8.xml'
  end
  object edError: TEdit
    Left = 264
    Top = 56
    Width = 121
    Height = 21
    TabOrder = 1
    Text = '$00000000'
  end
  object btGetDetails: TButton
    Left = 400
    Top = 56
    Width = 75
    Height = 25
    Caption = 'Get details'
    TabOrder = 2
    OnClick = btGetDetailsClick
  end
  object lbErrorInfo: TListBox
    Left = 8
    Top = 96
    Width = 513
    Height = 281
    ItemHeight = 13
    TabOrder = 3
  end
end
