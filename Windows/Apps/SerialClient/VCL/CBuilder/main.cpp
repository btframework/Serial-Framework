//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TfmMain *fmMain;
//---------------------------------------------------------------------------
#pragma comment(lib, "wclCommon")
#pragma comment(lib, "wclCommunication")
#pragma comment(lib, "wclSerialFramework")
//---------------------------------------------------------------------------
int __fastcall DtrControlToIndex(TwclSerialDtrControl Control)
{
    switch (Control)
    {
        case dtrControlDisable:
            return 0;
        case dtrControlEnable:
            return 1;
        case dtrControlHandshake:
            return 2;
        default:
            return -1;
    }
}
//---------------------------------------------------------------------------
TwclSerialDtrControl __fastcall IndexToDtrControl(int Index)
{
    switch (Index)
    {
        case 0:
            return dtrControlDisable;
        case 1:
            return dtrControlEnable;
        case 2:
            return dtrControlHandshake;
        default:
            return dtrControlDisable;
    }
}
//---------------------------------------------------------------------------
int __fastcall RtsControlToIndex(TwclSerialRtsControl Control)
{
    switch (Control)
    {
        case rtsControlDisable:
            return 0;
        case rtsControlEnable:
            return 1;
        case rtsControlHandshake:
            return 2;
        case rtsControlToggle:
            return 3;
        default:
            return -1;
    }
}
//---------------------------------------------------------------------------
TwclSerialRtsControl __fastcall IndexToRtsControl(int Index)
{
    switch (Index)
    {
        case 0:
            return rtsControlDisable;
        case 1:
            return rtsControlEnable;
        case 2:
            return rtsControlHandshake;
        case 3:
            return rtsControlToggle;
        default:
            return rtsControlDisable;
    }
}
//---------------------------------------------------------------------------
int __fastcall ParityToIndex(TwclSerialParity Parity)
{
    switch (Parity)
    {
        case spNo:
            return 0;
        case spOdd:
            return 1;
        case spEven:
            return 2;
        case spMark:
            return 3;
        case spSpace:
            return 4;
        default:
            return -1;
    }
}
//---------------------------------------------------------------------------
TwclSerialParity __fastcall IndexToParity(int Index)
{
    switch (Index)
    {
        case 0:
            return spNo;
        case 1:
            return spOdd;
        case 2:
            return spEven;
        case 3:
            return spMark;
        case 4:
            return spSpace;
        default:
            return spNo;
    }
}
//---------------------------------------------------------------------------
int __fastcall StopBitsToIndex(TwclSerialStopBits StopBits)
{
    switch (StopBits)
    {
        case sbOne:
            return 0;
        case sbOne5:
            return 1;
        case sbTwo:
            return 2;
        default:
            return -1;
    }
}
//---------------------------------------------------------------------------
TwclSerialStopBits __fastcall IndexToStopBits(int Index)
{
    switch (Index)
    {
        case 0:
            return sbOne;
        case 1:
            return sbOne5;
        case 2:
            return sbTwo;
        default:
            return sbOne;
    }
}
//---------------------------------------------------------------------------
__fastcall TfmMain::TfmMain(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormCreate(TObject *Sender)
{
    FClient = new TwclSerialClient();
    FClient->OnConnect = ClientConnect;
    FClient->OnData = ClientData;
    FClient->OnDisconnect = ClientDisconnect;
    FClient->OnError = ClientError;
    FClient->OnReadError = ClientReadError;
    FClient->OnEvents = ClientEvents;

    FMonitor = new TwclSerialMonitor();
    
    EnumComPorts();

    ClearConfig();
    ClearTimeouts();
    ClearBuffers();

	edWriteTimeout->Text = IntToStr((int)FClient->WriteTimeout);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormDestroy(TObject *Sender)
{
    FClient->Disconnect();
    FMonitor->Stop();

    FClient->Free();
    FMonitor->Free();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btClearClick(TObject *Sender)
{
    lbEvents->Clear();   
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ReadConfiguration()
{
    TwclSerialConfig Config;
    int Res = FClient->GetConfig(Config);
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Read configuration error: 0x" + IntToHex(Res, 8));
        return;
    }

	edBaudRate->Text = IntToStr((int)Config.BaudRate);
	edXonLim->Text = IntToStr(Config.XonLim);
    edXoffLim->Text = IntToStr(Config.XoffLim);
    edXonChar->Text = IntToStr(Config.XonChar);
    edXoffChar->Text = IntToStr(Config.XoffChar);
    edErrorChar->Text = IntToStr(Config.ErrorChar);
    edEofChar->Text = IntToStr(Config.EofChar);
    edEvtChar->Text = IntToStr(Config.EvtChar);

    cbParityCheck->Checked = Config.ParityCheck;
    cbOutxCtsFlow->Checked = Config.OutxCtsFlow;
    cbOutxDsrFlow->Checked = Config.OutxDsrFlow;
    cbDsrSensitivity->Checked = Config.DsrSensitivity;
    cbTXContinueOnXoff->Checked = Config.TxContinueOnXoff;
    cbOutX->Checked = Config.OutX;
    cbInX->Checked = Config.InX;
    cbErrorCharReplace->Checked = Config.ErrorCharReplace;
    cbNullStrip->Checked = Config.NullStrip;
    cbAbortOnError->Checked = Config.AbortOnError;

    cbRtsControl->ItemIndex = RtsControlToIndex(Config.RtsControl);
    cbDtrControl->ItemIndex = DtrControlToIndex(Config.DtrControl);
    cbParity->ItemIndex = ParityToIndex(Config.Parity);
    cbStopBits->ItemIndex = StopBitsToIndex(Config.StopBits);
    cbByteSize->ItemIndex = Config.ByteSize - 4;
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ReadTimeouts()
{
    TwclSerialTimeouts Times;
    int Res = FClient->GetTimeouts(Times);
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Get timeouts error: 0x" + IntToHex(Res, 8));
        return;
    }

	edReadInterval->Text = IntToStr((int)Times.ReadInterval);
	edReadMultiplier->Text = IntToStr((int)Times.ReadMultiplier);
	edReadConstant->Text = IntToStr((int)Times.ReadConstant);
	edWriteMultiplier->Text = IntToStr((int)Times.WriteMultiplier);
	edWriteConstant->Text = IntToStr((int)Times.WriteConstant);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btEnumClick(TObject *Sender)
{
    EnumComPorts();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::EnumComPorts()
{
    cbPorts->Clear();

    TwclSerialDevices Ports;
    int Res = FMonitor->EnumSerialDevices(Ports);
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Error enumerating COM ports: 0x" +
            IntToHex(Res, 8));
        return;
    }

    for (int i = 0; i < Ports.Length; i++)
        cbPorts->Items->Add(Ports[i].DeviceName);

    if (cbPorts->Items->Count > 0)
        cbPorts->ItemIndex = 0;
    else
        cbPorts->ItemIndex = -1;
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btConnectClick(TObject *Sender)
{
    if (cbPorts->ItemIndex == -1)
    {
        MessageDlg("Select COM port", mtWarning, TMsgDlgButtons() << mbOK, 0);
        return;
    }

    int Res = FClient->Connect(cbPorts->Items->Strings[cbPorts->ItemIndex]);
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btDisconnectClick(TObject *Sender)
{
    int Res = FClient->Disconnect();
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClearConfig()
{
    edBaudRate->Text = "";
    edXonLim->Text = "";
    edXoffLim->Text = "";
    edXonChar->Text = "";
    edXoffChar->Text = "";
    edErrorChar->Text = "";
    edEofChar->Text = "";
    edEvtChar->Text = "";

    cbParityCheck->Checked = false;
    cbOutxCtsFlow->Checked = false;
    cbOutxDsrFlow->Checked = false;
    cbDsrSensitivity->Checked = false;
    cbTXContinueOnXoff->Checked = false;
    cbOutX->Checked = false;
    cbInX->Checked = false;
    cbErrorCharReplace->Checked = false;
    cbNullStrip->Checked = false;
    cbAbortOnError->Checked = false;

    cbRtsControl->ItemIndex = -1;
    cbDtrControl->ItemIndex = -1;
    cbByteSize->ItemIndex = -1;
    cbParity->ItemIndex = -1;
    cbStopBits->ItemIndex = -1;
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btSetConfigClick(TObject *Sender)
{
    TwclSerialConfig Config;
    Config.BaudRate = StrToInt64(edBaudRate->Text);
    Config.XonLim = StrToInt(edXonLim->Text);
    Config.XoffLim = StrToInt(edXoffLim->Text);
    Config.XonChar = Char(StrToInt(edXonChar->Text));
    Config.XoffChar = Char(StrToInt(edXoffChar->Text));
    Config.ErrorChar = Char(StrToInt(edErrorChar->Text));
    Config.EofChar = Char(StrToInt(edEofChar->Text));
    Config.EvtChar = Char(StrToInt(edEvtChar->Text));

    Config.ParityCheck = cbParityCheck->Checked;
    Config.OutxCtsFlow = cbOutxCtsFlow->Checked;
    Config.OutxDsrFlow = cbOutxDsrFlow->Checked;
    Config.DsrSensitivity = cbDsrSensitivity->Checked;
    Config.TxContinueOnXoff = cbTXContinueOnXoff->Checked;
    Config.OutX = cbOutX->Checked;
    Config.InX = cbInX->Checked;
    Config.ErrorCharReplace = cbErrorCharReplace->Checked;
    Config.NullStrip = cbNullStrip->Checked;
    Config.AbortOnError = cbAbortOnError->Checked;

    Config.RtsControl = IndexToRtsControl(cbRtsControl->ItemIndex);
    Config.DtrControl = IndexToDtrControl(cbDtrControl->ItemIndex);
    Config.Parity = IndexToParity(cbParity->ItemIndex);
    Config.StopBits = IndexToStopBits(cbStopBits->ItemIndex);
    Config.ByteSize = cbByteSize->ItemIndex + 4;

    int Res = FClient->SetConfig(Config);
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btGetConfigClick(TObject *Sender)
{
    ReadConfiguration();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClearBuffers()
{
    edReadBufferSize->Text = "";
    edWriteBufferSize->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClearTimeouts()
{
    edReadInterval->Text = "";
    edReadMultiplier->Text = "";
    edReadConstant->Text = "";
    edWriteMultiplier->Text = "";
    edWriteConstant->Text = "";
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ReadBuffers()
{
    unsigned int Size = 0;
    int Res = FClient->GetReadBufferSize(Size);
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Get read buffer size error: 0x" +
            IntToHex(Res, 8));
    }
    else
		edReadBufferSize->Text = IntToStr((int)Size);

    Res = FClient->GetWriteBufferSize(Size);
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Get write buffer size error: 0x" +
            IntToHex(Res, 8));
    }
    else
		edWriteBufferSize->Text = IntToStr((int)Size);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btGetBuffersClick(TObject *Sender)
{
    ReadBuffers();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btSetBuffersClick(TObject *Sender)
{
    int Res = FClient->SetReadBufferSize(
        StrToInt64(edReadBufferSize->Text));
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Set read buffer size error: 0x" +
            IntToHex(Res, 8));
    }

    Res = FClient->SetWriteBufferSize(
        StrToInt64(edWriteBufferSize->Text));
    if (Res != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Set write buffer size error: 0x" +
            IntToHex(Res, 8));
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btGetTimeoutsClick(TObject *Sender)
{
    ReadTimeouts();    
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btSetTimeoutsClick(TObject *Sender)
{
    TwclSerialTimeouts Times;
    Times.ReadInterval = StrToInt64(edReadInterval->Text);
    Times.ReadMultiplier = StrToInt64(edReadMultiplier->Text);
    Times.ReadConstant = StrToInt64(edReadConstant->Text);
    Times.WriteMultiplier = StrToInt64(edWriteMultiplier->Text);
    Times.WriteConstant = StrToInt64(edWriteConstant->Text);
    int Res = FClient->SetTimeouts(Times);
    if (Res != WCL_E_SUCCESS)
        lbEvents->Items->Add("Set timeouts error: 0x" + IntToHex(Res, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btClearCommBreakClick(TObject *Sender)
{
    int Res = FClient->ClearCommBreak();
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btSetCommBreakClick(TObject *Sender)
{
    int Res = FClient->SetCommBreak();
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btFlushBuffersClick(TObject *Sender)
{
    int Res = FClient->FlushBuffers();
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btFuncClick(TObject *Sender)
{
    int Res = FClient->EscapeCommFunction(
        TwclSerialEscapeFunction(cbFunc->ItemIndex));
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btPurgeClick(TObject *Sender)
{
    TwclSerialPurgeFlags Flags;
    if (cbpurgeRxAbort->Checked)
        Flags << purgeRxAbort;
    if (cbpurgeRxClear->Checked)
        Flags << purgeRxClear;
    if (cbpurgeTxAbort->Checked)
        Flags << purgeTxAbort;
    if (cbpurgeTxClear->Checked)
        Flags << purgeTxClear;

    int Res = FClient->PurgeComm(Flags);
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btTransmitClick(TObject *Sender)
{
    int Res = FClient->TransmitCommChar(Char(StrToInt(edChar->Text)));
    if (Res != WCL_E_SUCCESS)
    {
        MessageDlg("Error: 0x" + IntToHex(Res, 8), mtError,
            TMsgDlgButtons() << mbOK, 0);
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btSendClick(TObject *Sender)
{
    AnsiString Str = AnsiString(edText->Text);
    switch (cbLineFeed->ItemIndex)
    {
        case 1:
            Str += AnsiChar(13);
            break;
        case 2:
            Str += AnsiChar(10);
            break;
        case 3:
            Str += (AnsiChar(13) + AnsiChar(10));
            break;
    }
    unsigned int Written = 0;
    int Res = FClient->Write(Str.c_str(), Str.Length(), Written);
    lbEvents->Items->Add("Sent: " + IntToStr((int)Written) + " bytes from " +
        IntToStr(Str.Length()));
    if (Res != WCL_E_SUCCESS)
        lbEvents->Items->Add("Write error: 0x" + IntToHex(Res, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btSetWriteTimeoutClick(TObject *Sender)
{
    FClient->WriteTimeout = StrToInt(edWriteTimeout->Text);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClientConnect(TObject *Sender, const int Error)
{
    if (Error != WCL_E_SUCCESS)
    {
        lbEvents->Items->Add("Connect error: 0x" + IntToHex(Error, 8));
        return;
    }

    lbEvents->Items->Add("Connected to Serial Device: " +
        FClient->DeviceName);

    ReadConfiguration();
    ReadTimeouts();
    ReadBuffers();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClientData(TObject *Sender, const void* Data,
    const unsigned int Size)
{
    if (Size == 0)
    {
        lbEvents->Items->Add("Empty data received");
        return;
    }

    AnsiString Str((char*)Data, Size);
    lbEvents->Items->Add("Received: " + Str);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClientDisconnect(TObject *Sender, const int Reason)
{
    lbEvents->Items->Add("Disconnected: 0x" + IntToHex(Reason, 8));

    ClearConfig();
    ClearTimeouts();
    ClearBuffers();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClientError(TObject *Sender,
    const TwclSerialErrors Errors, const TwclSerialCommunicationStates States)
{
    String Str = "";
    if (Errors.Contains(erBreak))
        Str += "erBreak ";
    if (Errors.Contains(erFrame))
        Str += "erFrame ";
    if (Errors.Contains(erOverrun))
        Str += "erOverrun ";
    if (Errors.Contains(erRxOver))
        Str += "erRxOver ";
    if (Errors.Contains(erRxParity))
        Str += "erRxParity ";
    lbEvents->Items->Add("Error: " + Str);

    Str = "";
    if (States.Contains(csCtsHold))
        Str += "csCtsHold ";
    if (States.Contains(csDsrHold))
        Str += "csDsrHold ";
    if (States.Contains(csRlsdHold))
        Str += "csRlsdHold ";
    if (States.Contains(csXoffHold))
        Str += "csXoffHold ";
    if (States.Contains(csXoffSent))
        Str += "csXoffSent ";
    if (States.Contains(csEof))
        Str += "csEof ";
    if (States.Contains(csTxim))
        Str += "csTxim ";
    lbEvents->Items->Add("States: " + Str);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClientReadError(TObject *Sender, const int Error)
{
    lbEvents->Items->Add("Read error: 0x" + IntToHex(Error, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::ClientEvents(TObject *Sender,
    const TwclSerialEvents Events)
{
    String Str = "";
    if (Events.Contains(evBreak))
        Str += "evBreak ";
    if (Events.Contains(evCts))
        Str += "evCts ";
    if (Events.Contains(evDsr))
        Str += "evDsr ";
    if (Events.Contains(evRing))
        Str += "evRing ";
    if (Events.Contains(evRlsd))
        Str += "evRlsd ";
    if (Events.Contains(evChar))
        Str += "evChar ";
    lbEvents->Items->Add("Event: " + Str);

    if (!Events.Empty())
    {
        TwclModemStatuses Status;
        int Res = FClient->GetModemStatus(Status);
        if (Res != WCL_E_SUCCESS)
            lbEvents->Items->Add("GetModemStatus error: 0x" + IntToHex(Res, 8));
        else
        {
            Str = "";
            if (Status.Contains(msCtsOn))
                Str += "msCtsOn ";
            if (Status.Contains(msDsrOn))
                Str += "msDsrOn ";
            if (Status.Contains(msRingOn))
                Str += "msRingOn ";
            if (Status.Contains(msDsrOn))
                Str += "msDsrOn ";
            if (Status.Contains(msRlsdOn))
                Str += "msRlsdOn ";
            if (Str != "")
                lbEvents->Items->Add("Modem status: " + Str);
        }
    }
}
//---------------------------------------------------------------------------
