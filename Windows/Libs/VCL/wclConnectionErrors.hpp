// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclConnectionErrors.pas' rev: 30.00 (Windows)

#ifndef WclconnectionerrorsHPP
#define WclconnectionerrorsHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <wclErrors.hpp>
#include <System.SysUtils.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclconnectionerrors
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS wclEConnection;
class DELPHICLASS wclEConnectionActive;
//-- type declarations -------------------------------------------------------
#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEConnection : public Wclerrors::wclException
{
	typedef Wclerrors::wclException inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEConnection(const System::UnicodeString Msg) : Wclerrors::wclException(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEConnection(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : Wclerrors::wclException(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEConnection(NativeUInt Ident)/* overload */ : Wclerrors::wclException(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEConnection(System::PResStringRec ResStringRec)/* overload */ : Wclerrors::wclException(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEConnection(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : Wclerrors::wclException(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEConnection(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : Wclerrors::wclException(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEConnection(const System::UnicodeString Msg, int AHelpContext) : Wclerrors::wclException(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEConnection(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : Wclerrors::wclException(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEConnection(NativeUInt Ident, int AHelpContext)/* overload */ : Wclerrors::wclException(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEConnection(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : Wclerrors::wclException(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEConnection(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : Wclerrors::wclException(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEConnection(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : Wclerrors::wclException(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEConnection(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclEConnectionActive : public wclEConnection
{
	typedef wclEConnection inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclEConnectionActive(const System::UnicodeString Msg) : wclEConnection(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclEConnectionActive(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclEConnection(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclEConnectionActive(NativeUInt Ident)/* overload */ : wclEConnection(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclEConnectionActive(System::PResStringRec ResStringRec)/* overload */ : wclEConnection(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEConnectionActive(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclEConnection(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclEConnectionActive(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclEConnection(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclEConnectionActive(const System::UnicodeString Msg, int AHelpContext) : wclEConnection(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclEConnectionActive(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclEConnection(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEConnectionActive(NativeUInt Ident, int AHelpContext)/* overload */ : wclEConnection(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclEConnectionActive(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclEConnection(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEConnectionActive(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclEConnection(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclEConnectionActive(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclEConnection(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclEConnectionActive(void) { }
	
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
#define WCL_COMMUNICATION_VERSION L"8.0.4.0"
static const int WCL_E_CONNECTION_CONNECTED = int(0x10000);
static const int WCL_E_CONNECTION_NOT_CONNECTED = int(0x10001);
static const int WCL_E_CONNECTION_DISCONNECTED = int(0x10002);
static const int WCL_E_CONNECTION_CLOSED = int(0x10003);
static const int WCL_E_CONNECTION_LISTENING = int(0x10004);
static const int WCL_E_CONNECTION_CREATE_CONNECT_EVENT_FAILED = int(0x10005);
static const int WCL_E_CONNECTION_TERMINATED_BY_USER = int(0x10006);
static const int WCL_E_CONNECTION_SYSTEM_SUSPENDING = int(0x10007);
static const int WCL_E_CONNECTION_UNABLE_CREATE_DISCONNECT_EVENT = int(0x10008);
static const int WCL_E_CONNECTION_UNABLE_START_COMMUNICATION = int(0x10009);
static const int WCL_E_CONNECTION_CREATE_INIT_EVENT_FAILED = int(0x1000a);
static const int WCL_E_CONNECTION_SERVER_CLOSED = int(0x1000b);
static const int WCL_E_CONNECTION_NOT_CREATED = int(0x1000c);
static const int WCL_E_CONNECTION_UNABLE_FIND_CLIENT_CLASS = int(0x1000d);
static const int WCL_E_CONNECTION_ACCEPTING_CLIENT = int(0x1000e);
static const int WCL_E_CONNECTION_CREATE_TERMINATION_EVENT_FAILED = int(0x1000f);
static const int WCL_E_CONNECTION_DATA_WRITE_FAILED = int(0x10010);
static const int WCL_E_OBEX_NOT_CONNECTED = int(0x11000);
static const int WCL_E_OBEX_CONNECTED = int(0x11001);
static const int WCL_E_OBEX_OPERATION_IN_PROGRESS = int(0x11002);
static const int WCL_E_OBEX_CONTINUE = int(0x11003);
static const int WCL_E_OBEX_CREATED = int(0x11004);
static const int WCL_E_OBEX_ACCEPTED = int(0x11005);
static const int WCL_E_OBEX_NON_AUTHORITATIVE = int(0x11006);
static const int WCL_E_OBEX_NO_CONTENT = int(0x11007);
static const int WCL_E_OBEX_RESET_CONTENT = int(0x11008);
static const int WCL_E_OBEX_PARTIAL_CONTENT = int(0x11009);
static const int WCL_E_OBEX_MULTIPLE_CHOICES = int(0x1100a);
static const int WCL_E_OBEX_MOVED_PERMANENTLY = int(0x1100b);
static const int WCL_E_OBEX_MOVED_TEMPORARY = int(0x1100c);
static const int WCL_E_OBEX_SEE_OTHER = int(0x1100d);
static const int WCL_E_OBEX_NOT_MODIFIED = int(0x1100e);
static const int WCL_E_OBEX_USE_PROXY = int(0x1100f);
static const int WCL_E_OBEX_BAD_REQUEST = int(0x11010);
static const int WCL_E_OBEX_UNAUTHORIZED = int(0x11011);
static const int WCL_E_OBEX_PAYMENT_REQUIRED = int(0x11012);
static const int WCL_E_OBEX_FORBIDDEN = int(0x11013);
static const int WCL_E_OBEX_NOT_FOUND = int(0x11014);
static const int WCL_E_OBEX_METHOD_NOT_ALLOWED = int(0x11015);
static const int WCL_E_OBEX_NOT_ACCEPTABLE = int(0x11016);
static const int WCL_E_OBEX_PROXY_AUTH_REQUIRED = int(0x11017);
static const int WCL_E_OBEX_REQUEST_TIMEOUT = int(0x11018);
static const int WCL_E_OBEX_CONFLICT = int(0x11019);
static const int WCL_E_OBEX_GONE = int(0x1101a);
static const int WCL_E_OBEX_LENGTH_REQUIRED = int(0x1101b);
static const int WCL_E_OBEX_PRECONDITION_FAILED = int(0x1101c);
static const int WCL_E_OBEX_REQUEST_TOO_LARGE = int(0x1101d);
static const int WCL_E_OBEX_URL_TOO_LARGE = int(0x1101e);
static const int WCL_E_OBEX_UNSUPPORTED_MEDIA_TYPE = int(0x1101f);
static const int WCL_E_OBEX_INTERNAL = int(0x11020);
static const int WCL_E_OBEX_NOT_IMPLEMENTED = int(0x11021);
static const int WCL_E_OBEX_BAD_GATEWAY = int(0x11022);
static const int WCL_E_OBEX_SERVICE_UNAVAILABLE = int(0x11023);
static const int WCL_E_OBEX_GATEWAY_TIMEOUT = int(0x11024);
static const int WCL_E_OBEX_HTTP_VERSION_NOT_SUPPORTED = int(0x11025);
static const int WCL_E_OBEX_DATABASE_FULL = int(0x11026);
static const int WCL_E_OBEX_DATABASE_LOCKED = int(0x11027);
static const int WCL_E_OBEX_UNEXPECTED = int(0x11028);
static const int WCL_E_OBEX_OPERATION_TERMINATED_BY_USER = int(0x11029);
static const int WCL_E_OBEX_OPERATION_TERMINATED_BY_DISCONNECT = int(0x1102a);
static const int WCL_E_OBEX_DISCONNECTED = int(0x1102b);
static const int WCL_E_OBEX_INVALID_OPERATION_SEQUENCE = int(0x1102c);
static const int WCL_E_OBEX_COM_INIT_FAILED = int(0x1102d);
static const int WCL_E_OBEX_XML_NOT_AVAILABLE = int(0x1102e);
static const int WCL_E_OBEX_INVALID_DIR_LIST = int(0x1102f);
static const int WCL_E_OBEX_INVALID_DIR_FORMAT = int(0x11030);
static const int WCL_E_OBEX_INVALID_STATE = int(0x11031);
}	/* namespace Wclconnectionerrors */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLCONNECTIONERRORS)
using namespace Wclconnectionerrors;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclconnectionerrorsHPP
