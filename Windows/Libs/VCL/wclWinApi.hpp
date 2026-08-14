// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclWinApi.pas' rev: 30.00 (Windows)

#ifndef WclwinapiHPP
#define WclwinapiHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.msxml.hpp>
#include <Winapi.Windows.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclwinapi
{
//-- forward type declarations -----------------------------------------------
//-- type declarations -------------------------------------------------------
typedef unsigned TThreadID;

typedef int TThreadResult;

typedef NativeUInt TThreadHandle;

typedef NativeUInt TEventHandle;

typedef NativeUInt TAutoResetEventHandle;

typedef NativeUInt TManualResetEventHandle;

//-- var, const, procedure ---------------------------------------------------
static const System::Int8 NULL_HANDLE = System::Int8(0x0);
extern DELPHI_PACKAGE NativeUInt __fastcall wclCreateAutoResetEvent(void);
extern DELPHI_PACKAGE NativeUInt __fastcall wclBeginThread(System::TThreadFunc Func, const void * Param, /* out */ unsigned &ThreadId)/* overload */;
extern DELPHI_PACKAGE NativeUInt __fastcall wclBeginThread(System::TThreadFunc Func, /* out */ unsigned &ThreadId)/* overload */;
extern DELPHI_PACKAGE NativeUInt __fastcall wclBeginThread(System::TThreadFunc Func, const void * Param)/* overload */;
extern DELPHI_PACKAGE NativeUInt __fastcall wclBeginThread(System::TThreadFunc Func)/* overload */;
extern DELPHI_PACKAGE bool __fastcall wclCreateMsXmlInstance(/* out */ _di_IXMLDOMDocument &Doc);
}	/* namespace Wclwinapi */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLWINAPI)
using namespace Wclwinapi;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclwinapiHPP
