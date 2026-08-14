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
__fastcall TfmMain::TfmMain(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormDestroy(TObject *Sender)
{
    FMonitor->Stop();
    FMonitor->Free();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btClearClick(TObject *Sender)
{
    lbLog->Items->Clear();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btEnumSerialClick(TObject *Sender)
{
    lvDevices->Items->Clear();
    lvDevices->Columns->Clear();

    TListColumn* Column = lvDevices->Columns->Add();
    Column->Caption = "Device name";
    Column->Width = 80;
    Column = lvDevices->Columns->Add();
    Column->Caption = "Friendly name";
    Column->Width = 350;
    Column = lvDevices->Columns->Add();
    Column->Caption = "IsModem";
    Column->Width = 70;

    TwclSerialDevices Devices;
    int Res = FMonitor->EnumSerialDevices(Devices);
    if (Res != WCL_E_SUCCESS)
    {
        lbLog->Items->Add("Enum serial devices failed: 0x" + IntToHex(Res, 8));
        return;
    }

    if (Devices.Length == 0)
    {
        lbLog->Items->Add("No serial devices found");
        return;
    }

    lbLog->Items->Add("Found " + IntToStr(Devices.Length) + " serial devices");
    for (int i = 0; i < Devices.Length; i++)
    {
        TListItem* Item = lvDevices->Items->Add();
        Item->Caption = Devices[i].DeviceName;
        Item->SubItems->Add(Devices[i].FriendlyName);
        Item->SubItems->Add(BoolToStr(Devices[i].IsModem, true));
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btEnumUSBClick(TObject *Sender)
{
    lvDevices->Items->Clear();
    lvDevices->Columns->Clear();

    TListColumn* Column = lvDevices->Columns->Add();
    Column->Caption = "Instance";
    Column->Width = 250;
    Column = lvDevices->Columns->Add();
    Column->Caption = "Friendly name";
    Column->Width = 250;
    Column = lvDevices->Columns->Add();
    Column->Caption = "VID";
    Column->Width = 50;
    Column = lvDevices->Columns->Add();
    Column->Caption = "PID";
    Column->Width = 50;
    Column = lvDevices->Columns->Add();
    Column->Caption = "Class";
    Column->Width = 250;
    Column = lvDevices->Columns->Add();
    Column->Caption = "Manufacturer";
    Column->Width = 200;
    Column = lvDevices->Columns->Add();
    Column->Caption = "Enabled";
    Column->Width = 70;

    TwclUsbDevices Devices;
    int Res = FMonitor->EnumUsbDevices(Devices);
    if (Res != WCL_E_SUCCESS)
    {
        lbLog->Items->Add("Enum USB devices failed: 0x" + IntToHex(Res, 8));
        return;
    }

    if (Devices.Length == 0)
    {
        lbLog->Items->Add("No USB devices found");
        return;
    }

    lbLog->Items->Add("Found " + IntToStr(Devices.Length) + " USB devices");
    for (int i = 0; i < Devices.Length; i++)
    {
        TListItem* Item = lvDevices->Items->Add();
        Item->Caption = Devices[i].Instance;
        Item->SubItems->Add(Devices[i].FriendlyName);
        Item->SubItems->Add(IntToHex(Devices[i].VendorId, 4));
        Item->SubItems->Add(IntToHex(Devices[i].ProductId, 4));
        Item->SubItems->Add(Sysutils::GUIDToString(Devices[i].ClassGuid));
        Item->SubItems->Add(Devices[i].Manufacturer);
        Item->SubItems->Add(BoolToStr(Devices[i].Enabled, true));
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btDisableClick(TObject *Sender)
{
    SwitchUsbDevice(false);    
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btEnableClick(TObject *Sender)
{
    SwitchUsbDevice(true);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::SwitchUsbDevice(const bool Enable)
{
    if (lvDevices->Columns->Count < 7)
    {
        ShowMessage("Enumerate USB devices");
        return;
    }

    if (lvDevices->Items->Count == 0)
    {
        ShowMessage("No USB devices found");
        return;
    }

    if (lvDevices->Selected == NULL)
    {
        ShowMessage("Select USB device");
        return;
    }

    int Res;
    String Instance = lvDevices->Selected->Caption;
    if (Enable)
        Res = FMonitor->EnableUsbDevice(Instance);
    else
        Res = FMonitor->DisableUsbDevice(Instance);
    if (Res != WCL_E_SUCCESS)
    {
        if (Enable)
        {
            ShowMessage("Error enabling USB: 0x" + IntToHex(Res, 8));
            return;
        }

        ShowMessage("Error disabling USB: 0x" + IntToHex(Res, 8));
        return;
    }

    if (Enable)
    {
        ShowMessage("Device enabled");
        return;
    }

    ShowMessage("Device disabled");
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorStarted(TObject *Sender)
{
    lbLog->Items->Add("Monitor started");
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorStopped(TObject *Sender)
{
    lbLog->Items->Add("Monitor stopped");
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorSerialDeviceAdded(TObject *Sender,
	const String DeviceName)
{
	lbLog->Items->Add("Device added: " + DeviceName);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorSerialDeviceRemoved(TObject *Sender,
	const String DeviceName)
{
	lbLog->Items->Add("Device removed: " + DeviceName);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorUsbDeviceAdded(TObject *Sender,
	const String Instance)
{
	lbLog->Items->Add("Device added: " + Instance);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorUsbDeviceRemoved(TObject *Sender,
    const String Instance)
{
    lbLog->Items->Add("Device removed: " + Instance);
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btStartClick(TObject *Sender)
{
    int Res = FMonitor->Start();
    if (Res != WCL_E_SUCCESS)
        lbLog->Items->Add("Start failed: 0x" + IntToHex(Res, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btStopClick(TObject *Sender)
{
    int Res = FMonitor->Stop();
    if (Res != WCL_E_SUCCESS)
        lbLog->Items->Add("Stop failed: 0x" + IntToHex(Res, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormCreate(TObject *Sender)
{
    FMonitor = new TwclSerialMonitor();
    FMonitor->OnStarted = MonitorStarted;
    FMonitor->OnStopped = MonitorStopped;
    FMonitor->OnSerialDeviceAdded = MonitorSerialDeviceAdded;
    FMonitor->OnSerialDeviceRemoved = MonitorSerialDeviceRemoved;
    FMonitor->OnUsbDeviceAdded = MonitorUsbDeviceAdded;
    FMonitor->OnUsbDeviceRemoved = MonitorUsbDeviceRemoved;
}
//---------------------------------------------------------------------------

