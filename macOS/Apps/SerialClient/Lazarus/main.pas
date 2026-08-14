unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls,
  wclSerialDevices, wclSerialClients;

type

  { TfmMain }

  TfmMain = class(TForm)
    btClear: TButton;
    btClearCommBreak: TButton;
    btConnect: TButton;
    btDisconnect: TButton;
    btEnum: TButton;
    btFlushBuffers: TButton;
    btFunc: TButton;
    btGetBuffers: TButton;
    btGetConfig: TButton;
    btGetTimeouts: TButton;
    btPurge: TButton;
    btSend: TButton;
    btSetBuffers: TButton;
    btSetCommBreak: TButton;
    btSetConfig: TButton;
    btSetTimeouts: TButton;
    btSetWriteTimeout: TButton;
    btTransmit: TButton;
    cbAbortOnError: TCheckBox;
    cbByteSize: TComboBox;
    cbDsrSensitivity: TCheckBox;
    cbDtrControl: TComboBox;
    cbErrorCharReplace: TCheckBox;
    cbFunc: TComboBox;
    cbInX: TCheckBox;
    cbLineFeed: TComboBox;
    cbNullStrip: TCheckBox;
    cbOutX: TCheckBox;
    cbOutxCtsFlow: TCheckBox;
    cbOutxDsrFlow: TCheckBox;
    cbParity: TComboBox;
    cbParityCheck: TCheckBox;
    cbPorts: TComboBox;
    cbpurgeRxAbort: TCheckBox;
    cbpurgeRxClear: TCheckBox;
    cbpurgeTxAbort: TCheckBox;
    cbpurgeTxClear: TCheckBox;
    cbRtsControl: TComboBox;
    cbStopBits: TComboBox;
    cbTXContinueOnXoff: TCheckBox;
    edBaudRate: TEdit;
    edChar: TEdit;
    edEofChar: TEdit;
    edErrorChar: TEdit;
    edEvtChar: TEdit;
    edReadBufferSize: TEdit;
    edReadConstant: TEdit;
    edReadInterval: TEdit;
    edReadMultiplier: TEdit;
    edText: TEdit;
    edWriteBufferSize: TEdit;
    edWriteConstant: TEdit;
    edWriteMultiplier: TEdit;
    edWriteTimeout: TEdit;
    edXoffChar: TEdit;
    edXoffLim: TEdit;
    edXonChar: TEdit;
    edXonLim: TEdit;
    laBaudRate: TLabel;
    laByteSize: TLabel;
    laCharCode: TLabel;
    laDtrControl: TLabel;
    laEofChar: TLabel;
    laErrorChar: TLabel;
    laEvtChar: TLabel;
    laFunc: TLabel;
    laLineFeed: TLabel;
    laParity: TLabel;
    laReadBufferSize: TLabel;
    laReadConstant: TLabel;
    laReadInterval: TLabel;
    laReadMultiplier: TLabel;
    laRtsControl: TLabel;
    laStopBites: TLabel;
    laWriteBufferSize: TLabel;
    laWriteConstant: TLabel;
    laWriteMultiplier: TLabel;
    laWriteTimeout: TLabel;
    laXoffChar: TLabel;
    laXoffLim: TLabel;
    laXonChar: TLabel;
    laXonLim: TLabel;
    lbEvents: TListBox;
    procedure btClearClick(Sender: TObject);
    procedure btClearCommBreakClick(Sender: TObject);
    procedure btConnectClick(Sender: TObject);
    procedure btDisconnectClick(Sender: TObject);
    procedure btEnumClick(Sender: TObject);
    procedure btFlushBuffersClick(Sender: TObject);
    procedure btFuncClick(Sender: TObject);
    procedure btGetBuffersClick(Sender: TObject);
    procedure btGetConfigClick(Sender: TObject);
    procedure btGetTimeoutsClick(Sender: TObject);
    procedure btPurgeClick(Sender: TObject);
    procedure btSendClick(Sender: TObject);
    procedure btSetBuffersClick(Sender: TObject);
    procedure btSetCommBreakClick(Sender: TObject);
    procedure btSetConfigClick(Sender: TObject);
    procedure btSetTimeoutsClick(Sender: TObject);
    procedure btSetWriteTimeoutClick(Sender: TObject);
    procedure btTransmitClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);

  private
    FClient: TwclSerialClient;
    FMonitor: TwclSerialMonitor;

    procedure EnumComPorts;

    procedure ReadConfiguration;
    procedure ReadTimeouts;
    procedure ReadBuffers;

    procedure ClearConfig;
    procedure ClearTimeouts;
    procedure ClearBuffers;

    procedure SerialClientConnect(Sender: TObject; const Error: Integer);
    procedure SerialClientData(Sender: TObject; const Data: Pointer;
      const Size: Cardinal);
    procedure SerialClientDisconnect(Sender: TObject; const Reason: Integer);
    procedure SerialClientError(Sender: TObject; const Errors: TwclSerialErrors;
      const States: TwclSerialCommunicationStates);
    procedure SerialClientReadError(Sender: TObject; const Error: Integer);
    procedure SerialClientEvents(Sender: TObject;
      const Events: TwclSerialEvents);
  end;

var
  fmMain: TfmMain;

implementation

uses
  wclErrors;

{$R *.lfm}

function DtrControlToIndex(Control: TwclSerialDtrControl): Integer;
begin
  case Control of
    dtrControlDisable: Result := 0;
    dtrControlEnable: Result := 1;
    dtrControlHandshake: Result := 2;
    else Result := -1;
  end;
end;

function IndexToDtrControl(Index: Integer): TwclSerialDtrControl;
begin
  case Index of
    0: Result := dtrControlDisable;
    1: Result := dtrControlEnable;
    2: Result := dtrControlHandshake;
    else Result := dtrControlDisable;
  end;
end;

function RtsControlToIndex(Control: TwclSerialRtsControl): Integer;
begin
  case Control of
    rtsControlDisable: Result := 0;
    rtsControlEnable: Result := 1;
    rtsControlHandshake: Result := 2;
    rtsControlToggle: Result := 3;
    else Result := -1;
  end;
end;

function IndexToRtsControl(Index: Integer): TwclSerialRtsControl;
begin
  case Index of
    0: Result := rtsControlDisable;
    1: Result := rtsControlEnable;
    2: Result := rtsControlHandshake;
    3: Result := rtsControlToggle;
    else Result := rtsControlDisable;
  end;
end;

function ParityToIndex(Parity: TwclSerialParity): Integer;
begin
  case Parity of
    spNo: Result := 0;
    spOdd: Result := 1;
    spEven: Result := 2;
    spMark: Result := 3;
    spSpace: Result := 4;
    else Result := -1;
  end;
end;

function IndexToParity(Index: Integer): TwclSerialParity;
begin
  case Index of
    0: Result := spNo;
    1: Result := spOdd;
    2: Result := spEven;
    3: Result := spMark;
    4: Result := spSpace;
    else Result := spNo;
  end;
end;

function StopBitsToIndex(StopBits: TwclSerialStopBits): Integer;
begin
  case StopBits of
    sbOne: Result := 0;
    sbOne5: Result := 1;
    sbTwo: Result := 2;
    else Result := -1;
  end;
end;

function IndexToStopBits(Index: Integer): TwclSerialStopBits;
begin
  case Index of
    0: Result := sbOne;
    1: Result := sbOne5;
    2: Result := sbTwo;
    else Result := sbOne;
  end;
end;

{ TfmMain }

procedure TfmMain.FormCreate(Sender: TObject);
begin
  FClient := TwclSerialClient.Create;
  FClient.OnConnect := @SerialClientConnect;
  FClient.OnData := @SerialClientData;
  FClient.OnDisconnect := @SerialClientDisconnect;
  FClient.OnError := @SerialClientError;
  FClient.OnReadError := @SerialClientReadError;
  FClient.OnEvents := @SerialClientEvents;

  FMonitor := TwclSerialMonitor.Create;

  EnumComPorts;

  ClearConfig;
  ClearTimeouts;
  ClearBuffers;

  edWriteTimeout.Text := IntToStr(FClient.WriteTimeout);
end;

procedure TfmMain.FormDestroy(Sender: TObject);
begin
  FClient.Disconnect;
  FMonitor.Stop;

  FClient.Free;
  FMonitor.Free;
end;

procedure TfmMain.btClearClick(Sender: TObject);
begin
  lbEvents.Clear;
end;

procedure TfmMain.btClearCommBreakClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.ClearCommBreak;
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btConnectClick(Sender: TObject);
var
  Res: Integer;
begin
  if cbPorts.ItemIndex = -1 then
    MessageDlg('Select COM port', mtWarning, [mbOK], 0)

  else begin
    Res := FClient.Connect(cbPorts.Items[cbPorts.ItemIndex]);
    if Res <> WCL_E_SUCCESS then
      MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
  end;
end;

procedure TfmMain.btDisconnectClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.Disconnect;
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btEnumClick(Sender: TObject);
begin
  EnumComPorts;
end;

procedure TfmMain.btFlushBuffersClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.FlushBuffers;
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btFuncClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.EscapeCommFunction(
    TwclSerialEscapeFunction(cbFunc.ItemIndex));
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btGetBuffersClick(Sender: TObject);
begin
  ReadBuffers;
end;

procedure TfmMain.btGetConfigClick(Sender: TObject);
begin
  ReadConfiguration;
end;

procedure TfmMain.btGetTimeoutsClick(Sender: TObject);
begin
  ReadTimeouts;
end;

procedure TfmMain.btPurgeClick(Sender: TObject);
var
  Flags: TwclSerialPurgeFlags;
  Res: Integer;
begin
  Flags := [];
  if cbpurgeRxAbort.Checked then
    Include(Flags, purgeRxAbort);
  if cbpurgeRxClear.Checked then
    Include(Flags, purgeRxClear);
  if cbpurgeTxAbort.Checked then
    Include(Flags, purgeTxAbort);
  if cbpurgeTxClear.Checked then
    Include(Flags, purgeTxClear);

  Res := FClient.PurgeComm(Flags);
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btSendClick(Sender: TObject);
var
  Res: Integer;
  Str: AnsiString;
  Written: Cardinal;
begin
  Str := AnsiString(edText.Text);
  case cbLineFeed.ItemIndex of
    1: Str := Str + #13;
    2: Str := Str + #10;
    3: Str := Str + #13#10;
  end;
  Res := FClient.Write(Pointer(Str), Length(Str), Written);
  lbEvents.Items.Add('Sent: ' + IntToStr(Written) + ' bytes from ' +
    IntToStr(Length(Str)));
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Write error: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.btSetBuffersClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.SetReadBufferSize(StrToInt64(edReadBufferSize.Text));
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Set read buffer size error: 0x' + IntToHex(Res, 8));

  Res := FClient.SetWriteBufferSize(StrToInt64(edWriteBufferSize.Text));
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Set write buffer size error: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.btSetCommBreakClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.SetCommBreak;
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btSetConfigClick(Sender: TObject);
var
  Config: TwclSerialConfig;
  Res: Integer;
begin
  Config.BaudRate := StrToInt64(edBaudRate.Text);
  Config.XonLim := StrToInt(edXonLim.Text);
  Config.XoffLim := StrToInt(edXoffLim.Text);
  Config.XonChar := Char(StrToInt(edXonChar.Text));
  Config.XoffChar := Char(StrToInt(edXoffChar.Text));
  Config.ErrorChar := Char(StrToInt(edErrorChar.Text));
  Config.EofChar := Char(StrToInt(edEofChar.Text));
  Config.EvtChar := Char(StrToInt(edEvtChar.Text));

  Config.ParityCheck := cbParityCheck.Checked;
  Config.OutxCtsFlow := cbOutxCtsFlow.Checked;
  Config.OutxDsrFlow := cbOutxDsrFlow.Checked;
  Config.DsrSensitivity := cbDsrSensitivity.Checked;
  Config.TXContinueOnXoff := cbTXContinueOnXoff.Checked;
  Config.OutX := cbOutX.Checked;
  Config.InX := cbInX.Checked;
  Config.ErrorCharReplace := cbErrorCharReplace.Checked;
  Config.NullStrip := cbNullStrip.Checked;
  Config.AbortOnError := cbAbortOnError.Checked;

  Config.RtsControl := IndexToRtsControl(cbRtsControl.ItemIndex);
  Config.DtrControl := IndexToDtrControl(cbDtrControl.ItemIndex);
  Config.Parity := IndexToParity(cbParity.ItemIndex);
  Config.StopBits := IndexToStopBits(cbStopBits.ItemIndex);
  Config.ByteSize := cbByteSize.ItemIndex + 4;

  Res := FClient.SetConfig(Config);
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.btSetTimeoutsClick(Sender: TObject);
var
  Times: TwclSerialTimeouts;
  Res: Integer;
begin
  Times.ReadInterval := StrToInt64(edReadInterval.Text);
  Times.ReadMultiplier := StrToInt64(edReadMultiplier.Text);
  Times.ReadConstant := StrToInt64(edReadConstant.Text);
  Times.WriteMultiplier := StrToInt64(edWriteMultiplier.Text);
  Times.WriteConstant := StrToInt64(edWriteConstant.Text);
  Res := FClient.SetTimeouts(Times);
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Set timeouts error: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.btSetWriteTimeoutClick(Sender: TObject);
begin
  FClient.WriteTimeout := StrToInt(edWriteTimeout.Text);
end;

procedure TfmMain.btTransmitClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FClient.TransmitCommChar(Char(StrToInt(edChar.Text)));
  if Res <> WCL_E_SUCCESS then
    MessageDlg('Error: 0x' + IntToHex(Res, 8), mtError, [mbOK], 0);
end;

procedure TfmMain.EnumComPorts;
var
  Ports: TwclSerialDevices;
  Res: Integer;
  i: Integer;
begin
  cbPorts.Clear;

  Res := FMonitor.EnumSerialDevices(Ports);
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Error enumerating COM ports: 0x' + IntToHex(Res, 8))

  else begin
    for i := 0 to Length(Ports) - 1 do
      cbPorts.Items.Add(Ports[i].DeviceName);

    if cbPorts.Items.Count > 0 then
      cbPorts.ItemIndex := 0
    else
      cbPorts.ItemIndex := -1;
  end;
end;

procedure TfmMain.ReadConfiguration;
var
  Config: TwclSerialConfig;
  Res: Integer;
begin
  Res := FClient.GetConfig(Config);
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Read configuration error: 0x' + IntToHex(Res, 8))

  else begin
    edBaudRate.Text := IntToStr(Config.BaudRate);
    edXonLim.Text := IntToStr(Config.XonLim);
    edXoffLim.Text := IntToStr(Config.XoffLim);
    edXonChar.Text := IntToStr(Ord(Config.XonChar));
    edXoffChar.Text := IntToStr(Ord(Config.XoffChar));
    edErrorChar.Text := IntToStr(Ord(Config.ErrorChar));
    edEofChar.Text := IntToStr(Ord(Config.EofChar));
    edEvtChar.Text := IntToStr(Ord(Config.EvtChar));

    cbParityCheck.Checked := Config.ParityCheck;
    cbOutxCtsFlow.Checked := Config.OutxCtsFlow;
    cbOutxDsrFlow.Checked := Config.OutxDsrFlow;
    cbDsrSensitivity.Checked := Config.DsrSensitivity;
    cbTXContinueOnXoff.Checked := Config.TXContinueOnXoff;
    cbOutX.Checked := Config.OutX;
    cbInX.Checked := Config.InX;
    cbErrorCharReplace.Checked := Config.ErrorCharReplace;
    cbNullStrip.Checked := Config.NullStrip;
    cbAbortOnError.Checked := Config.AbortOnError;

    cbRtsControl.ItemIndex := RtsControlToIndex(Config.RtsControl);
    cbDtrControl.ItemIndex := DtrControlToIndex(Config.DtrControl);
    cbParity.ItemIndex := ParityToIndex(Config.Parity);
    cbStopBits.ItemIndex := StopBitsToIndex(Config.StopBits);
    cbByteSize.ItemIndex := Config.ByteSize - 4;
  end;
end;

procedure TfmMain.ReadTimeouts;
var
  Times: TwclSerialTimeouts;
  Res: Integer;
begin
  Res := FClient.GetTimeouts(Times);
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Get timeouts error: 0x' + IntToHex(Res, 8))

  else begin
    edReadInterval.Text := IntToStr(Times.ReadInterval);
    edReadMultiplier.Text := IntToStr(Times.ReadMultiplier);
    edReadConstant.Text := IntToStr(Times.ReadConstant);
    edWriteMultiplier.Text := IntToStr(Times.WriteMultiplier);
    edWriteConstant.Text := IntToStr(Times.WriteConstant);
  end;
end;

procedure TfmMain.ReadBuffers;
var
  Res: Integer;
  Size: Cardinal;
begin
  Res := FClient.GetReadBufferSize(Size);
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Get read buffer size error: 0x' + IntToHex(Res, 8))
  else
    edReadBufferSize.Text := IntToStr(Size);

  Res := FClient.GetWriteBufferSize(Size);
  if Res <> WCL_E_SUCCESS then
    lbEvents.Items.Add('Get write buffer size error: 0x' + IntToHex(Res, 8))
  else
    edWriteBufferSize.Text := IntToStr(Size);
end;

procedure TfmMain.ClearConfig;
begin
  edBaudRate.Text := '';
  edXonLim.Text := '';
  edXoffLim.Text := '';
  edXonChar.Text := '';
  edXoffChar.Text := '';
  edErrorChar.Text := '';
  edEofChar.Text := '';
  edEvtChar.Text := '';

  cbParityCheck.Checked := False;
  cbOutxCtsFlow.Checked := False;
  cbOutxDsrFlow.Checked := False;
  cbDsrSensitivity.Checked := False;
  cbTXContinueOnXoff.Checked := False;
  cbOutX.Checked := False;
  cbInX.Checked := False;
  cbErrorCharReplace.Checked := False;
  cbNullStrip.Checked := False;
  cbAbortOnError.Checked := False;

  cbRtsControl.ItemIndex := -1;
  cbDtrControl.ItemIndex := -1;
  cbByteSize.ItemIndex := -1;
  cbParity.ItemIndex := -1;
  cbStopBits.ItemIndex := -1;
end;

procedure TfmMain.ClearTimeouts;
begin
  edReadInterval.Text := '';
  edReadMultiplier.Text := '';
  edReadConstant.Text := '';
  edWriteMultiplier.Text := '';
  edWriteConstant.Text := '';
end;

procedure TfmMain.ClearBuffers;
begin
  edReadBufferSize.Text := '';
  edWriteBufferSize.Text := '';
end;

procedure TfmMain.SerialClientConnect(Sender: TObject; const Error: Integer);
begin
  if Error = WCL_E_SUCCESS then begin
    lbEvents.Items.Add('Connected to Serial Device: ' +
      FClient.DeviceName);

    ReadConfiguration;
    ReadTimeouts;
    ReadBuffers;

  end else
    lbEvents.Items.Add('Connect error: 0x' + IntToHex(Error, 8));
end;

procedure TfmMain.SerialClientData(Sender: TObject; const Data: Pointer;
  const Size: Cardinal);
var
  Str: AnsiString;
begin
  if Size > 0 then begin
    Str := '';
    SetLength(Str, Size);
    Move(Data^, Pointer(Str)^, Size);
    lbEvents.Items.Add('Received [' + IntToStr(Size) + ']: ' + Str);

  end else
    lbEvents.Items.Add('Empty data received');
end;

procedure TfmMain.SerialClientDisconnect(Sender: TObject;
  const Reason: Integer);
begin
  lbEvents.Items.Add('Disconnected: 0x' + IntToHex(Reason, 8));

  ClearConfig;
  ClearTimeouts;
  ClearBuffers;
end;

procedure TfmMain.SerialClientError(Sender: TObject;
  const Errors: TwclSerialErrors; const States: TwclSerialCommunicationStates);
var
  Str: string;
begin
  Str := '';
  if erBreak in Errors then
    Str := Str + 'erBreak ';
  if erFrame in Errors then
    Str := Str + 'erFrame ';
  if erOverrun in Errors then
    Str := Str + 'erOverrun ';
  if erRxOver in Errors then
    Str := Str + 'erRxOver ';
  if erRxParity in Errors then
    Str := Str + 'erRxParity ';
  lbEvents.Items.Add('Error: ' + Str);

  Str := '';
  if csCtsHold in States then
    Str := Str + 'csCtsHold ';
  if csDsrHold in States then
    Str := Str + 'csDsrHold ';
  if csRlsdHold in States then
    Str := Str + 'csRlsdHold ';
  if csXoffHold in States then
    Str := Str + 'csXoffHold ';
  if csXoffSent in States then
    Str := Str + 'csXoffSent ';
  if csEof in States then
    Str := Str + 'csEof ';
  if csTxim in States then
    Str := Str + 'csTxim ';
  lbEvents.Items.Add('States: ' + Str);
end;

procedure TfmMain.SerialClientReadError(Sender: TObject; const Error: Integer);
begin
  lbEvents.Items.Add('Read error: 0x' + IntToHex(Error, 8));
end;

procedure TfmMain.SerialClientEvents(Sender: TObject;
  const Events: TwclSerialEvents);
var
  Str: string;
  Res: Integer;
  Status: TwclModemStatuses;
begin
  Str := '';
  if evBreak in Events then
    Str := Str + 'evBreak ';
  if evCts in Events then
    Str := Str + 'evCts ';
  if evDsr in Events then
    Str := Str + 'evDsr ';
  if evRing in Events then
    Str := Str + 'evRing ';
  if evRlsd in Events then
    Str := Str + 'evRlsd ';
  if evChar in Events then
    Str := Str + 'evChar ';
  lbEvents.Items.Add('Event: ' + Str);

  if Events <> [] then begin
    Res := FClient.GetModemStatus(Status);
    if Res <> WCL_E_SUCCESS then
      lbEvents.Items.Add('GetModemStatus error: 0x' + IntToHex(Res, 8))

    else begin
      Str := '';
      if msCtsOn in Status then
        Str := Str + 'msCtsOn ';
      if msDsrOn in Status then
        Str := Str + 'msDsrOn ';
      if msRingOn in Status then
        Str := Str + 'msRingOn ';
      if msDsrOn in Status then
        Str := Str + 'msDsrOn ';
      if msRlsdOn in Status then
        Str := Str + 'msRlsdOn ';
      if Str <> '' then
        lbEvents.Items.Add('Modem status: ' + Str);
    end;
  end;
end;

end.

