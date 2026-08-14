// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclUser32.pas' rev: 30.00 (Windows)

#ifndef Wcluser32HPP
#define Wcluser32HPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Messages.hpp>
#include <Winapi.Windows.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wcluser32
{
//-- forward type declarations -----------------------------------------------
//-- type declarations -------------------------------------------------------
typedef bool __fastcall (__closure *TwclWndProc)(const unsigned uMsg, const NativeUInt wParam, const NativeInt lParam);

//-- var, const, procedure ---------------------------------------------------
#define NULL_HDEVNOTIFY (void*)(0)
static const System::Word WCL_WINDOW_INIT_MSG = System::Word(0x8001);
extern DELPHI_PACKAGE HWND __fastcall wclCreateWindow(const System::UnicodeString Name, const TwclWndProc WndProc);
extern DELPHI_PACKAGE void __fastcall wclDestroyWindow(const HWND Wnd);
extern DELPHI_PACKAGE void __fastcall wclRunMessageLoop(void)/* overload */;
extern DELPHI_PACKAGE void __fastcall wclRunMessageLoop(const HWND hWnd)/* overload */;
}	/* namespace Wcluser32 */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLUSER32)
using namespace Wcluser32;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// Wcluser32HPP
