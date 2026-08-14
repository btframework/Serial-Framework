//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include <wclOsVersion.hpp>
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
    String Str;
    switch (wclOsVer->OsType)
    {
        case osUnknown:
            Str = "OS unknown";
            break;
        case osMacOS:
            Str = "Mac OS";
            break;
        case osWinXP:
            Str = "Windows XP";
            break;
        case osWinVista:
            Str = "Windows Vista";
            break;
        case osWin7:
            Str = "Windows 7";
            break;
        case osWin8:
            Str = "Windows 8";
            break;
        case osWin81:
            Str = "Windows 8.1";
            break;
        case osWin10:
            Str = "Windows 10";
            break;
        case osWin11:
            Str = "Windows 11";
            break;
        default:
            Str = "Undefined OS";
            break;
    }

    Str = Str + " " + IntToStr(wclOsVer->Major) + "." +
        IntToStr(wclOsVer->Minor) + "." + IntToStr(wclOsVer->Build);
    laOsVersion->Caption = Str;
}
//---------------------------------------------------------------------------
