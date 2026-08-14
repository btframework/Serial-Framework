// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclPowerApi.pas' rev: 30.00 (Windows)

#ifndef WclpowerapiHPP
#define WclpowerapiHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclpowerapi
{
//-- forward type declarations -----------------------------------------------
struct DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS;
//-- type declarations -------------------------------------------------------
typedef NativeUInt HPOWERNOTIFY;

typedef NativeUInt *PHPOWERNOTIFY;

typedef unsigned __stdcall (*PDEVICE_NOTIFY_CALLBACK_ROUTINE)(void * Context, unsigned _Type, void * Setting);

typedef DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS *PDEVICE_NOTIFY_SUBSCRIBE_PARAMETERS;

struct DECLSPEC_DRECORD DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
{
public:
	PDEVICE_NOTIFY_CALLBACK_ROUTINE Callback;
	void *Context;
};


//-- var, const, procedure ---------------------------------------------------
extern DELPHI_PACKAGE unsigned __fastcall PowerRegisterSuspendResumeNotification(unsigned Flags, PDEVICE_NOTIFY_SUBSCRIBE_PARAMETERS Recipient, PHPOWERNOTIFY RegistrationHandle);
extern DELPHI_PACKAGE unsigned __fastcall PowerUnregisterSuspendResumeNotification(NativeUInt RegistrationHandle);
extern DELPHI_PACKAGE bool __fastcall wclPowerApiLoad(void);
extern DELPHI_PACKAGE void __fastcall wclPowerApiUnload(void);
}	/* namespace Wclpowerapi */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLPOWERAPI)
using namespace Wclpowerapi;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclpowerapiHPP
