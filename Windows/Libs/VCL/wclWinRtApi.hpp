// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclWinRtApi.pas' rev: 30.00 (Windows)

#ifndef WclwinrtapiHPP
#define WclwinrtapiHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <wclWinApi.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclwinrtapi
{
//-- forward type declarations -----------------------------------------------
struct DateTime;
struct TimeSpan;
__interface IInspectable;
typedef System::DelphiInterface<IInspectable> _di_IInspectable;
__interface IActivationFactory;
typedef System::DelphiInterface<IActivationFactory> _di_IActivationFactory;
__interface IDateTimeReference;
typedef System::DelphiInterface<IDateTimeReference> _di_IDateTimeReference;
__interface ITimeSpanReference;
typedef System::DelphiInterface<ITimeSpanReference> _di_ITimeSpanReference;
__interface IByteReference;
typedef System::DelphiInterface<IByteReference> _di_IByteReference;
__interface IShortReference;
typedef System::DelphiInterface<IShortReference> _di_IShortReference;
__interface IIntReference;
typedef System::DelphiInterface<IIntReference> _di_IIntReference;
__interface IUInt32Reference;
typedef System::DelphiInterface<IUInt32Reference> _di_IUInt32Reference;
__interface IUInt64Reference;
typedef System::DelphiInterface<IUInt64Reference> _di_IUInt64Reference;
//-- type declarations -------------------------------------------------------
typedef unsigned UINT32;

typedef void * HSTRING;

typedef void * *PHSTRING;

typedef PHSTRING *PPHSTRING;

typedef System::WideChar * PCNZWCH;

enum DECLSPEC_DENUM RO_INIT_TYPE : unsigned int { RO_INIT_SINGLETHREADED, RO_INIT_MULTITHREADED };

enum DECLSPEC_DENUM TrustLevel : unsigned int { BaseTrust, PartialTrust, FullTrust };

struct DECLSPEC_DRECORD DateTime
{
public:
	__int64 UniversalTime;
};


struct DECLSPEC_DRECORD TimeSpan
{
public:
	__int64 Duration;
};


__interface  INTERFACE_UUID("{AF86E2E0-B12D-4C6A-9C5A-D7AA65101E90}") IInspectable  : public System::IInterface 
{
	virtual HRESULT __stdcall GetIids(/* out */ unsigned &iidCount, /* out */ System::PGUID &iids) = 0 ;
	virtual HRESULT __stdcall GetRuntimeClassName(/* out */ void * &className) = 0 ;
	virtual HRESULT __stdcall GetTrustLevel(/* out */ TrustLevel &trust) = 0 ;
};

__interface  INTERFACE_UUID("{00000035-0000-0000-C000-000000000046}") IActivationFactory  : public IInspectable 
{
	virtual HRESULT __stdcall ActivateInstance(/* out */ _di_IInspectable &instance) = 0 ;
};

__interface  INTERFACE_UUID("{5541D8A7-497C-5AA4-86FC-7713ADBF2A2C}") IDateTimeReference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ DateTime &value) = 0 ;
};

__interface  INTERFACE_UUID("{604D0C4C-91DE-5C2A-935F-362F13EAF800}") ITimeSpanReference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ TimeSpan &value) = 0 ;
};

__interface  INTERFACE_UUID("{E5198CC8-2873-55F5-B0A1-84FF9E4AAD62}") IByteReference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ System::Byte &value) = 0 ;
};

__interface  INTERFACE_UUID("{6EC9E41B-6709-5647-9918-A1270110FC4E}") IShortReference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ short &value) = 0 ;
};

__interface  INTERFACE_UUID("{548CEFBD-BC8A-5FA0-8DF2-957440FC8BF4}") IIntReference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ int &value) = 0 ;
};

__interface  INTERFACE_UUID("{513EF3AF-E784-5325-A91E-97C2B8111CF3}") IUInt32Reference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ unsigned &value) = 0 ;
};

__interface  INTERFACE_UUID("{6755E376-53BB-568B-A11D-17239868309E}") IUInt64Reference  : public IInspectable 
{
	virtual HRESULT __stdcall get_Value(/* out */ __int64 &value) = 0 ;
};

//-- var, const, procedure ---------------------------------------------------
extern DELPHI_PACKAGE int __fastcall wclWinRtActivateInstance(const System::UnicodeString ClassName, const GUID &ClsId, /* out */ void *Instance);
extern DELPHI_PACKAGE int __fastcall wclWinRtActivateFactory(const System::UnicodeString ClassName, const GUID &ClsId, /* out */ void *Factory);
extern DELPHI_PACKAGE int __fastcall wclWinRtStringToHString(const System::UnicodeString Str, /* out */ void * &hStr);
extern DELPHI_PACKAGE void __fastcall wclWinRtDeleteHString(const void * hStr);
extern DELPHI_PACKAGE System::UnicodeString __fastcall wclWinRtHStringToString(const void * hStr);
extern DELPHI_PACKAGE int __fastcall wclWinRtLoad(void);
extern DELPHI_PACKAGE int __fastcall wclWinRtUnload(void);
}	/* namespace Wclwinrtapi */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLWINRTAPI)
using namespace Wclwinrtapi;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclwinrtapiHPP
