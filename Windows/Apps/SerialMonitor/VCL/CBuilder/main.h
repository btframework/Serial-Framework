//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "wclSerialDevices.hpp"
#include <ComCtrls.hpp>
//---------------------------------------------------------------------------
class TfmMain : public TForm
{
__published:	// IDE-managed Components
    TButton *btStart;
    TButton *btStop;
    TListBox *lbLog;
    TButton *btClear;
    TButton *btEnumSerial;
    TListView *lvDevices;
    TButton *btEnumUSB;
    TButton *btDisable;
    TButton *btEnable;
    void __fastcall FormDestroy(TObject *Sender);
    void __fastcall btClearClick(TObject *Sender);
    void __fastcall btEnumSerialClick(TObject *Sender);
    void __fastcall btEnumUSBClick(TObject *Sender);
    void __fastcall btDisableClick(TObject *Sender);
    void __fastcall btEnableClick(TObject *Sender);
    void __fastcall btStartClick(TObject *Sender);
    void __fastcall btStopClick(TObject *Sender);
    void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
    TwclSerialMonitor* FMonitor;

    void __fastcall MonitorStarted(TObject *Sender);
    void __fastcall MonitorStopped(TObject *Sender);
    void __fastcall MonitorSerialDeviceAdded(TObject *Sender,
		const String DeviceName);
	void __fastcall MonitorSerialDeviceRemoved(TObject *Sender,
		const String DeviceName);
	void __fastcall MonitorUsbDeviceAdded(TObject *Sender,
		const String Instance);
	void __fastcall MonitorUsbDeviceRemoved(TObject *Sender,
        const String Instance);

    void __fastcall SwitchUsbDevice(const bool Enable);
public:		// User declarations
    __fastcall TfmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfmMain *fmMain;
//---------------------------------------------------------------------------
#endif
