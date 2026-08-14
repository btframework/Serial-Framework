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
//---------------------------------------------------------------------------
__fastcall TfmMain::TfmMain(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormCreate(TObject *Sender)
{
    FMonitor = new TwclPowerEventsMonitor();
    FMonitor->OnPowerStateChanged = PowerStateChanged;
    FMonitor->OnStarted = MonitorStarted;
    FMonitor->OnStopped = MonitorStopped;
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormDestroy(TObject *Sender)
{
    FMonitor->Free();
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btOpenClick(TObject *Sender)
{
    int Res = FMonitor->Start();
    if (Res != WCL_E_SUCCESS)
        lbLog->Items->Add("Start failed: 0x" + IntToHex(Res, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btCloseClick(TObject *Sender)
{
    int Res = FMonitor->Stop();
    if (Res != WCL_E_SUCCESS)
        lbLog->Items->Add("Stop failed: 0x" + IntToHex(Res, 8));
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::PowerStateChanged(TObject* Sender,
    const TwclPowerState State)
{
    switch (State)
    {
        case psPowerStatusChanged:
            lbLog->Items->Add("Power status changed");
            break;
        case psResumeAutomatic:
            lbLog->Items->Add("Resumed");
            break;
        case psResume:
            lbLog->Items->Add("Resumed by user");
            break;
        case psSuspend:
            lbLog->Items->Add("Suspended");
            break;
        case psUnknown:
            lbLog->Items->Add("Unknonw");
            break;
    }
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorStarted(TObject* Sender)
{
    lbLog->Items->Add("Monitor started");
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::MonitorStopped(TObject* Sender)
{
    lbLog->Items->Add("Monitor stopped");
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btGetStateClick(TObject *Sender)
{
    TwclPowerStatus Status;
    if (!FMonitor->GetPowerStatus(Status))
    {
        lbLog->Items->Add("Get status failed");
        return;
    }

    switch (Status.ACLineStatus)
    {
        case lsOffline:
            lbLog->Items->Add("AC: Offline");
            break;
        case lsOnline:
            lbLog->Items->Add("AC: Online");
            break;
        case lsBackup:
            lbLog->Items->Add("AC: Backup");
            break;
        case lsUnknown:
            lbLog->Items->Add("AC: Unknown");
            break;
    }

    String Str = "[";
    if (Status.BatteryChargeStatus.Contains(csCapacityHigh))
        Str = Str + " csCapacityHigh";
    if (Status.BatteryChargeStatus.Contains(csCapacityLow))
        Str = Str + " csCapacityLow";
    if (Status.BatteryChargeStatus.Contains(csCapacityCritical))
        Str = Str + " csCapacityCritical";
    if (Status.BatteryChargeStatus.Contains(csCharging))
        Str = Str + " csCharging";
    if (Status.BatteryChargeStatus.Contains(csNoSystemBattery))
        Str = Str + " csNoSystemBattery";
    Str = Str + " ]";
    lbLog->Items->Add("Batt: " + Str);

    lbLog->Items->Add("Batt percent: " + IntToStr(Status.BatteryLifePercent));

    if (Status.BatterySavingState)
        lbLog->Items->Add("Battery saving");

    if (Status.BatteryLifeTime != 0xFFFFFFFF)
		lbLog->Items->Add("Batt life: " + IntToStr((int)Status.BatteryLifeTime));

    if (Status.BatteryFullLifeTime != 0xFFFFFFFF)
    {
        lbLog->Items->Add("Batt full life: " +
            IntToStr((int)Status.BatteryFullLifeTime));
    }
}
//---------------------------------------------------------------------------

