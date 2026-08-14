object fmMain: TfmMain
  Left = 723
  Top = 263
  BorderStyle = bsSingle
  Caption = 'Power Events test application'
  ClientHeight = 332
  ClientWidth = 432
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
  object btOpen: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Open'
    TabOrder = 0
    OnClick = btOpenClick
  end
  object btClose: TButton
    Left = 88
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Close'
    TabOrder = 1
    OnClick = btCloseClick
  end
  object btGetState: TButton
    Left = 184
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Get state'
    TabOrder = 2
    OnClick = btGetStateClick
  end
  object lbLog: TListBox
    Left = 8
    Top = 48
    Width = 417
    Height = 273
    ItemHeight = 13
    TabOrder = 3
  end
end
