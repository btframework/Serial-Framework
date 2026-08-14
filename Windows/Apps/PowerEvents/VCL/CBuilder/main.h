//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <wclSystemEvents.hpp>
//---------------------------------------------------------------------------
class TfmMain : public TForm
{
__published:	// IDE-managed Components
    TButton *btOpen;
    TButton *btClose;
    TButton *btGetState;
    TListBox *lbLog;
    void __fastcall FormCreate(TObject *Sender);
    void __fastcall FormDestroy(TObject *Sender);
    void __fastcall btOpenClick(TObject *Sender);
    void __fastcall btCloseClick(TObject *Sender);
    void __fastcall btGetStateClick(TObject *Sender);
private:
    TwclPowerEventsMonitor* FMonitor;

    void __fastcall PowerStateChanged(TObject* Sender,
        const TwclPowerState State);
    void __fastcall MonitorStarted(TObject* Sender);
    void __fastcall MonitorStopped(TObject* Sender);
public:		// User declarations
    __fastcall TfmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfmMain *fmMain;
//---------------------------------------------------------------------------
#endif
