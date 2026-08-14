//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include <wclErrors.hpp>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#pragma resource "lafapp.res"
TfmMain *fmMain;
//---------------------------------------------------------------------------
#pragma comment(lib, "wclCommon")
//---------------------------------------------------------------------------
__fastcall TfmMain::TfmMain(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::btUnlockClick(TObject *Sender)
{
    if (cbLaf->ItemIndex == -1)
	{
        lbLog->Items->Add("No LAF found");
        return;
    }

	String Laf = cbLaf->Text;
	#if (__BCPLUSPLUS__ >= 0x0610)
		int Res = TwclLafManager::Unlock(Laf);
	#else
		int Res = TwclLafManager::Unlock(__classid(TwclLafManager), Laf);
	#endif
    if (Res != WCL_E_SUCCESS)
        lbLog->Items->Add("Unlock " + Laf + " failed: 0x" + IntToHex(Res, 8));
    else
        lbLog->Items->Add("LAF " + Laf + " unlocked");
}
//---------------------------------------------------------------------------
void __fastcall TfmMain::FormCreate(TObject *Sender)
{
    String Pfn;
    String AppName;
	String Publisher;
	#if (__BCPLUSPLUS__ >= 0x0610)
		int Res = TwclLafManager::GetIdentity(Pfn, AppName, Publisher);
	#else
		int Res = TwclLafManager::GetIdentity(__classid(TwclLafManager), Pfn,
			AppName, Publisher);
	#endif
	if (Res != WCL_E_SUCCESS)
	{
		lbLog->Items->Add("Get identity failed: 0x" + IntToHex(Res, 8));
		return;
	}

	lbLog->Items->Add("PFN: " + Pfn);
	lbLog->Items->Add("AppName: " + AppName);
	lbLog->Items->Add("Publisher: " + Publisher);

	TStringList* Laf = new TStringList();
	__try
	{
		#if (__BCPLUSPLUS__ >= 0x0610)
			Res = TwclLafManager::Enum(Laf);
		#else
			Res = TwclLafManager::Enum(__classid(TwclLafManager), Laf);
		#endif
        if (Res != WCL_E_SUCCESS)
        {
            lbLog->Items->Add("Enum LAF failed: 0x" + IntToHex(Res, 8));
            return;
        }

        if (Laf->Count > 0)
        {
            for (int i = 0; i < Laf->Count; i++)
                cbLaf->Items->Add(Laf->Strings[i]);

            cbLaf->ItemIndex = 0;
        }
    }
    __finally
    {
        Laf->Free();
    }
}
//---------------------------------------------------------------------------
