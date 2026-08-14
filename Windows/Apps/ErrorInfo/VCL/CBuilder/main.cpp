//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "wclErrors.hpp"
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
void __fastcall TfmMain::btGetDetailsClick(TObject *Sender)
{
    if (edError->Text == "")
    {
        ShowMessage("Enter error code.");
        return;
    }

    int Err = StrToInt(edError->Text);

    lbErrorInfo->Items->Clear();

    TwclErrorInformation* Info = new TwclErrorInformation();
    if (!Info->Open(edPath->Text))
        ShowMessage("Open errors definition file failed");
    else
    {
        TwclErrorDetails Details;
        if (!Info->GetDetails(Err, Details))
            ShowMessage("Unable to get error details");
        else
        {
            lbErrorInfo->Items->Add("Error code: 0x" + IntToHex(Details.Error, 8));
            lbErrorInfo->Items->Add("Framework: " + Details.Framework);
            lbErrorInfo->Items->Add("Category: " + Details.Category);
            lbErrorInfo->Items->Add("Constant name: " + Details.Constant);
            lbErrorInfo->Items->Add(Details.Description);
        }
        Info->Close();
    }
    Info->Free();
}
//---------------------------------------------------------------------------
