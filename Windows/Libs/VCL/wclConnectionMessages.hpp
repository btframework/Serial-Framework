// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclConnectionMessages.pas' rev: 30.00 (Windows)

#ifndef WclconnectionmessagesHPP
#define WclconnectionmessagesHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>
#include <wclWinApi.hpp>
#include <wclMessaging.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclconnectionmessages
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS TwclConnectionConnectMessage;
class DELPHICLASS TwclConnectionDisconnectMessage;
class DELPHICLASS TwclConnectionDataMessage;
class DELPHICLASS TwclConnectionAcceptMessage;
//-- type declarations -------------------------------------------------------
#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclConnectionConnectMessage : public Wclmessaging::TwclConnectionCategoryMessage
{
	typedef Wclmessaging::TwclConnectionCategoryMessage inherited;
	
private:
	int FError;
	NativeUInt FEvent;
	
public:
	__fastcall TwclConnectionConnectMessage(const int Error, const NativeUInt Event);
	__fastcall virtual ~TwclConnectionConnectMessage(void);
	void __fastcall Signal(void);
	__property int Error = {read=FError, nodefault};
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclConnectionDisconnectMessage : public Wclmessaging::TwclConnectionCategoryMessage
{
	typedef Wclmessaging::TwclConnectionCategoryMessage inherited;
	
private:
	int FReason;
	
public:
	__fastcall TwclConnectionDisconnectMessage(const int Reason);
	__property int Reason = {read=FReason, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclConnectionDisconnectMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclConnectionDataMessage : public Wclmessaging::TwclConnectionCategoryMessage
{
	typedef Wclmessaging::TwclConnectionCategoryMessage inherited;
	
private:
	void *FData;
	unsigned FSize;
	
public:
	__fastcall TwclConnectionDataMessage(const void * Data, const unsigned Size);
	__fastcall virtual ~TwclConnectionDataMessage(void);
	__property void * Data = {read=FData};
	__property unsigned Size = {read=FSize, nodefault};
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclConnectionAcceptMessage : public Wclmessaging::TwclConnectionCategoryMessage
{
	typedef Wclmessaging::TwclConnectionCategoryMessage inherited;
	
private:
	NativeUInt FEvent;
	void *FParams;
	unsigned FSize;
	int *FResult;
	
public:
	__fastcall TwclConnectionAcceptMessage(const NativeUInt Event, const System::PInteger Result, const void * Params, const unsigned Size);
	__fastcall virtual ~TwclConnectionAcceptMessage(void);
	void __fastcall Signal(const int Result);
	__property void * Params = {read=FParams};
	__property unsigned Size = {read=FSize, nodefault};
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
static const System::Int8 WCL_MSG_ID_CONNECTION_CONNECT = System::Int8(0x1);
static const System::Int8 WCL_MSG_ID_CONNECTION_DISCONNECT = System::Int8(0x2);
static const System::Int8 WCL_MSG_ID_CONNECTION_DATA = System::Int8(0x3);
static const System::Int8 WCL_MSG_ID_CONNECTION_ACCEPT = System::Int8(0x4);
}	/* namespace Wclconnectionmessages */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLCONNECTIONMESSAGES)
using namespace Wclconnectionmessages;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclconnectionmessagesHPP
