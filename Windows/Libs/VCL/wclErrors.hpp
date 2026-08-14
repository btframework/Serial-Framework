// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclErrors.pas' rev: 30.00 (Windows)

#ifndef WclerrorsHPP
#define WclerrorsHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>
#include <Winapi.msxml.hpp>
#include <System.SysUtils.hpp>
#include <Winapi.MSXMLIntf.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclerrors
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS wclException;
class DELPHICLASS wclEInvalidArgument;
class DELPHICLASS wclEIndexOutOfRange;
class DELPHICLASS wclECritical;
class DELPHICLASS wclESystem;
class DELPHICLASS wclESysRefCounter;
class DELPHICLASS wclESysOutOfMemory;
class DELPHICLASS wclESysOutOfResources;
class DELPHICLASS wclESysInvalidArgument;
class DELPHICLASS wclESysOs;
class DELPHICLASS wclEMessaging;
class DELPHICLASS wclEMessageReceiver;
class DELPHICLASS wclEMessageBroadcaster;
struct TwclErrorDetails;
class DELPHICLASS TwclErrorInformation;
//-- type declarations -------------------------------------------------------
#pragma pack(push,4)
class PASCALIMPLEMENTATION wclException : public System::Sysutils::Exception
{
	typedef System::Sysutils::Exception inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclException(const System::UnicodeString Msg) : System::Sysutils::Exception(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclException(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : System::Sysutils::Exception(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclException(NativeUInt Ident)/* overload */ : System::Sysutils::Exception(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclException(System::PResStringRec ResStringRec)/* overload */ : System::Sysutils::Exception(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclException(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : System::Sysutils::Exception(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclException(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : System::Sysutils::Exception(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclException(const System::UnicodeString Msg, int AHelpContext) : System::Sysutils::Exception(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclException(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : System::Sysutils::Exception(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclException(NativeUInt Ident, int AHelpContext)/* overload */ : System::Sysutils::Exception(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclException(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : System::Sysutils::Exception(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclException(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : System::Sysutils::Exception(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclException(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : System::Sysutils::Exception(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclException(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEInvalidArgument : public wclException
{
	typedef wclException inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEInvalidArgument(const System::UnicodeString Msg) : wclException(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEInvalidArgument(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclException(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEInvalidArgument(NativeUInt Ident)/* overload */ : wclException(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEInvalidArgument(System::PResStringRec ResStringRec)/* overload */ : wclException(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEInvalidArgument(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclException(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEInvalidArgument(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclException(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEInvalidArgument(const System::UnicodeString Msg, int AHelpContext) : wclException(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEInvalidArgument(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclException(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEInvalidArgument(NativeUInt Ident, int AHelpContext)/* overload */ : wclException(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEInvalidArgument(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclException(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEInvalidArgument(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclException(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEInvalidArgument(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclException(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEInvalidArgument(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEIndexOutOfRange : public wclException
{
	typedef wclException inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEIndexOutOfRange(const System::UnicodeString Msg) : wclException(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEIndexOutOfRange(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclException(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEIndexOutOfRange(NativeUInt Ident)/* overload */ : wclException(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEIndexOutOfRange(System::PResStringRec ResStringRec)/* overload */ : wclException(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEIndexOutOfRange(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclException(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEIndexOutOfRange(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclException(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEIndexOutOfRange(const System::UnicodeString Msg, int AHelpContext) : wclException(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEIndexOutOfRange(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclException(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEIndexOutOfRange(NativeUInt Ident, int AHelpContext)/* overload */ : wclException(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEIndexOutOfRange(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclException(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEIndexOutOfRange(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclException(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEIndexOutOfRange(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclException(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEIndexOutOfRange(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclECritical : public wclException
{
	typedef wclException inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclECritical(const System::UnicodeString Msg) : wclException(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclECritical(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclException(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclECritical(NativeUInt Ident)/* overload */ : wclException(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclECritical(System::PResStringRec ResStringRec)/* overload */ : wclException(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclECritical(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclException(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclECritical(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclException(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclECritical(const System::UnicodeString Msg, int AHelpContext) : wclException(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclECritical(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclException(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclECritical(NativeUInt Ident, int AHelpContext)/* overload */ : wclException(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclECritical(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclException(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclECritical(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclException(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclECritical(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclException(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclECritical(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESystem : public wclECritical
{
	typedef wclECritical inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESystem(const System::UnicodeString Msg) : wclECritical(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESystem(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclECritical(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESystem(NativeUInt Ident)/* overload */ : wclECritical(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESystem(System::PResStringRec ResStringRec)/* overload */ : wclECritical(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESystem(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclECritical(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESystem(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclECritical(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESystem(const System::UnicodeString Msg, int AHelpContext) : wclECritical(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESystem(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclECritical(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESystem(NativeUInt Ident, int AHelpContext)/* overload */ : wclECritical(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESystem(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclECritical(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESystem(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclECritical(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESystem(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclECritical(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESystem(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESysRefCounter : public wclESystem
{
	typedef wclESystem inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESysRefCounter(const System::UnicodeString Msg) : wclESystem(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESysRefCounter(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESystem(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESysRefCounter(NativeUInt Ident)/* overload */ : wclESystem(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESysRefCounter(System::PResStringRec ResStringRec)/* overload */ : wclESystem(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysRefCounter(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysRefCounter(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESysRefCounter(const System::UnicodeString Msg, int AHelpContext) : wclESystem(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESysRefCounter(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESystem(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysRefCounter(NativeUInt Ident, int AHelpContext)/* overload */ : wclESystem(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysRefCounter(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESystem(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysRefCounter(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysRefCounter(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESysRefCounter(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESysOutOfMemory : public wclESystem
{
	typedef wclESystem inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESysOutOfMemory(const System::UnicodeString Msg) : wclESystem(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESysOutOfMemory(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESystem(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESysOutOfMemory(NativeUInt Ident)/* overload */ : wclESystem(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESysOutOfMemory(System::PResStringRec ResStringRec)/* overload */ : wclESystem(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysOutOfMemory(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysOutOfMemory(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESysOutOfMemory(const System::UnicodeString Msg, int AHelpContext) : wclESystem(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESysOutOfMemory(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESystem(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysOutOfMemory(NativeUInt Ident, int AHelpContext)/* overload */ : wclESystem(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysOutOfMemory(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESystem(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysOutOfMemory(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysOutOfMemory(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESysOutOfMemory(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESysOutOfResources : public wclESystem
{
	typedef wclESystem inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESysOutOfResources(const System::UnicodeString Msg) : wclESystem(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESysOutOfResources(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESystem(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESysOutOfResources(NativeUInt Ident)/* overload */ : wclESystem(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESysOutOfResources(System::PResStringRec ResStringRec)/* overload */ : wclESystem(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysOutOfResources(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysOutOfResources(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESysOutOfResources(const System::UnicodeString Msg, int AHelpContext) : wclESystem(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESysOutOfResources(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESystem(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysOutOfResources(NativeUInt Ident, int AHelpContext)/* overload */ : wclESystem(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysOutOfResources(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESystem(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysOutOfResources(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysOutOfResources(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESysOutOfResources(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESysInvalidArgument : public wclESystem
{
	typedef wclESystem inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESysInvalidArgument(const System::UnicodeString Msg) : wclESystem(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESysInvalidArgument(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESystem(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESysInvalidArgument(NativeUInt Ident)/* overload */ : wclESystem(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESysInvalidArgument(System::PResStringRec ResStringRec)/* overload */ : wclESystem(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysInvalidArgument(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysInvalidArgument(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESysInvalidArgument(const System::UnicodeString Msg, int AHelpContext) : wclESystem(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESysInvalidArgument(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESystem(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysInvalidArgument(NativeUInt Ident, int AHelpContext)/* overload */ : wclESystem(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysInvalidArgument(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESystem(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysInvalidArgument(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysInvalidArgument(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESysInvalidArgument(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESysOs : public wclESystem
{
	typedef wclESystem inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESysOs(const System::UnicodeString Msg) : wclESystem(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESysOs(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESystem(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESysOs(NativeUInt Ident)/* overload */ : wclESystem(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESysOs(System::PResStringRec ResStringRec)/* overload */ : wclESystem(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysOs(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESysOs(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESystem(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESysOs(const System::UnicodeString Msg, int AHelpContext) : wclESystem(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESysOs(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESystem(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysOs(NativeUInt Ident, int AHelpContext)/* overload */ : wclESystem(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESysOs(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESystem(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysOs(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESysOs(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESystem(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESysOs(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEMessaging : public wclECritical
{
	typedef wclECritical inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEMessaging(const System::UnicodeString Msg) : wclECritical(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEMessaging(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclECritical(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEMessaging(NativeUInt Ident)/* overload */ : wclECritical(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEMessaging(System::PResStringRec ResStringRec)/* overload */ : wclECritical(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEMessaging(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclECritical(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEMessaging(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclECritical(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEMessaging(const System::UnicodeString Msg, int AHelpContext) : wclECritical(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEMessaging(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclECritical(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEMessaging(NativeUInt Ident, int AHelpContext)/* overload */ : wclECritical(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEMessaging(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclECritical(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEMessaging(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclECritical(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEMessaging(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclECritical(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEMessaging(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEMessageReceiver : public wclEMessaging
{
	typedef wclEMessaging inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEMessageReceiver(const System::UnicodeString Msg) : wclEMessaging(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEMessageReceiver(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclEMessaging(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEMessageReceiver(NativeUInt Ident)/* overload */ : wclEMessaging(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEMessageReceiver(System::PResStringRec ResStringRec)/* overload */ : wclEMessaging(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEMessageReceiver(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclEMessaging(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEMessageReceiver(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclEMessaging(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEMessageReceiver(const System::UnicodeString Msg, int AHelpContext) : wclEMessaging(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEMessageReceiver(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclEMessaging(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEMessageReceiver(NativeUInt Ident, int AHelpContext)/* overload */ : wclEMessaging(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEMessageReceiver(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclEMessaging(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEMessageReceiver(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclEMessaging(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEMessageReceiver(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclEMessaging(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEMessageReceiver(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEMessageBroadcaster : public wclEMessaging
{
	typedef wclEMessaging inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEMessageBroadcaster(const System::UnicodeString Msg) : wclEMessaging(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEMessageBroadcaster(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclEMessaging(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEMessageBroadcaster(NativeUInt Ident)/* overload */ : wclEMessaging(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEMessageBroadcaster(System::PResStringRec ResStringRec)/* overload */ : wclEMessaging(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEMessageBroadcaster(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclEMessaging(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEMessageBroadcaster(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclEMessaging(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEMessageBroadcaster(const System::UnicodeString Msg, int AHelpContext) : wclEMessaging(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEMessageBroadcaster(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclEMessaging(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEMessageBroadcaster(NativeUInt Ident, int AHelpContext)/* overload */ : wclEMessaging(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEMessageBroadcaster(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclEMessaging(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEMessageBroadcaster(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclEMessaging(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEMessageBroadcaster(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclEMessaging(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEMessageBroadcaster(void) { }
	
};

#pragma pack(pop)

struct DECLSPEC_DRECORD TwclErrorDetails
{
public:
	int Error;
	System::UnicodeString Framework;
	System::UnicodeString Category;
	System::UnicodeString Constant;
	System::UnicodeString Description;
};


#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclErrorInformation : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	bool FComInitialized;
	_RTL_CRITICAL_SECTION FCS;
	_di_IXMLDOMDocument FDocument;
	_di_IXMLDOMElement FRootElement;
	_di_IXMLDOMNodeList FFrameworks;
	bool __fastcall GetFrameworksNodes(void);
	bool __fastcall GetRootElement(void);
	bool __fastcall LoadDocument(const System::UnicodeString FileName);
	bool __fastcall GetAttributeText(const _di_IXMLDOMNode Node, const System::UnicodeString AttributeName, /* out */ System::UnicodeString &Text);
	bool __fastcall ErrorFound(const _di_IXMLDOMNode Node, const int Error);
	bool __fastcall GetOpened(void);
	
public:
	__fastcall TwclErrorInformation(void);
	__fastcall virtual ~TwclErrorInformation(void);
	bool __fastcall Close(void);
	bool __fastcall Open(const System::UnicodeString FileName);
	bool __fastcall GetDetails(const int Error, TwclErrorDetails &Details);
	__property bool Opened = {read=GetOpened, nodefault};
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
#define WCL_COMMON_VERSION L"8.0.4.0"
static const System::Int8 WCL_E_SUCCESS = System::Int8(0x0);
static const System::Int8 WCL_E_INVALID_ARGUMENT = System::Int8(0x1);
static const System::Int8 WCL_E_OUT_OF_MEMORY = System::Int8(0x2);
static const System::Int8 WCL_E_OUT_OF_RESOURCES = System::Int8(0x3);
static const System::Int8 WCL_E_NOT_IMPLEMENTED = System::Int8(0x4);
static const System::Word WCL_E_WINRT_CORE_DLL_NOT_FOUND = System::Word(0x1000);
static const System::Word WCL_E_WINRT_STRING_DLL_NOT_FOUND = System::Word(0x1001);
static const System::Word WCL_E_WINRT_INIT_FAILED = System::Word(0x1002);
static const System::Word WCL_E_WINRT_CREATE_STRING_FAILED = System::Word(0x1003);
static const System::Word WCL_E_WINRT_ACTIVATE_INSTANCE_FAILED = System::Word(0x1004);
static const System::Word WCL_E_WINRT_CREATE_INTERFACE_FAILED = System::Word(0x1005);
static const System::Word WCL_E_MR_CLOSED = System::Word(0x2000);
static const System::Word WCL_E_MR_OPENED = System::Word(0x2001);
static const System::Word WCL_E_MR_NOT_OPENED = System::Word(0x2002);
static const System::Word WCL_E_MR_CREATE_SYNC_OBJ_FAILED = System::Word(0x2003);
static const System::Word WCL_E_MR_SYNC_OBJ_NOT_CREATED = System::Word(0x2004);
static const System::Word WCL_E_MR_SYNCHRONIZE_FAILED = System::Word(0x2005);
static const System::Word WCL_E_MR_REGISTER_SYNC_OBJ_FAILED = System::Word(0x2006);
static const System::Word WCL_E_MR_INVALID_THREAD = System::Word(0x2007);
static const System::Word WCL_E_MB_NOT_CREATED = System::Word(0x3000);
static const System::Word WCL_E_MB_RECEIVER_ALREADY_SUBSCRIBED = System::Word(0x3001);
static const System::Word WCL_E_MB_RECEIVER_NOT_SUBSCRIBED = System::Word(0x3002);
static const System::Word WCL_E_MB_RECEIVER_NOT_FOUND = System::Word(0x3003);
static const System::Word WCL_E_LAF_MANAGER_FEATURE_NOT_SUPPORTED = System::Word(0x4000);
static const System::Word WCL_E_LAF_MANAGER_START_THREAD_FAILED = System::Word(0x4001);
static const System::Word WCL_E_LAF_MANAGER_GET_LAF_LIST_FAILED = System::Word(0x4002);
static const System::Word WCL_E_LAF_NOT_FOUND = System::Word(0x4003);
static const System::Word WCL_E_LAF_OPEN_KEY_FAILED = System::Word(0x4004);
static const System::Word WCL_E_LAF_KEY_NOT_FOUND = System::Word(0x4005);
static const System::Word WCL_E_LAF_ACQUIRE_CONTEXT_FAILED = System::Word(0x4006);
static const System::Word WCL_E_LAF_CREATE_HASH_FAILED = System::Word(0x4007);
static const System::Word WCL_E_LAF_CRYPT_HASH_FAILED = System::Word(0x4008);
static const System::Word WCL_E_LAF_GET_CRYPTED_HASH_FAILED = System::Word(0x4009);
static const System::Word WCL_E_LAF_IDENTITY_NOT_FOUND = System::Word(0x400a);
static const System::Word WCL_E_LAF_IDENTITY_READ_FAILED = System::Word(0x400b);
static const System::Word WCL_E_LAF_IDENTITY_INVALID = System::Word(0x400c);
static const System::Word WCL_E_LAF_IDENTITY_EMPTY = System::Word(0x400d);
static const System::Word WCL_E_LAF_IDENTITY_INVALID_FORMAT = System::Word(0x400e);
static const System::Word WCL_E_LAF_UNLOCK_REQUEST_FAILED = System::Word(0x400f);
static const System::Word WCL_E_LAF_GET_REQUEST_STATUS_FAILED = System::Word(0x4010);
static const System::Word WCL_E_LAF_LOCKED = System::Word(0x4011);
static const System::Word WCL_E_LAF_UNAVAILABLE = System::Word(0x4012);
static const System::Word WCL_E_LAF_STATUS_UNKNOWN = System::Word(0x4013);
}	/* namespace Wclerrors */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLERRORS)
using namespace Wclerrors;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclerrorsHPP
