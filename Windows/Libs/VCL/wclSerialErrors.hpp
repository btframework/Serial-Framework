// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclSerialErrors.pas' rev: 30.00 (Windows)

#ifndef WclserialerrorsHPP
#define WclserialerrorsHPP

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

namespace Wclserialerrors
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS wclESerial;
class DELPHICLASS wclESerialMonitor;
class DELPHICLASS wclESerialClient;
//-- type declarations -------------------------------------------------------
#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESerial : public Wclerrors::wclException
{
	typedef Wclerrors::wclException inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESerial(const System::UnicodeString Msg) : Wclerrors::wclException(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESerial(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : Wclerrors::wclException(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESerial(NativeUInt Ident)/* overload */ : Wclerrors::wclException(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESerial(System::PResStringRec ResStringRec)/* overload */ : Wclerrors::wclException(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESerial(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : Wclerrors::wclException(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESerial(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : Wclerrors::wclException(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESerial(const System::UnicodeString Msg, int AHelpContext) : Wclerrors::wclException(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESerial(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : Wclerrors::wclException(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESerial(NativeUInt Ident, int AHelpContext)/* overload */ : Wclerrors::wclException(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESerial(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : Wclerrors::wclException(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESerial(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : Wclerrors::wclException(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESerial(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : Wclerrors::wclException(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESerial(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESerialMonitor : public wclESerial
{
	typedef wclESerial inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESerialMonitor(const System::UnicodeString Msg) : wclESerial(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESerialMonitor(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESerial(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESerialMonitor(NativeUInt Ident)/* overload */ : wclESerial(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESerialMonitor(System::PResStringRec ResStringRec)/* overload */ : wclESerial(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESerialMonitor(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESerial(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESerialMonitor(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESerial(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESerialMonitor(const System::UnicodeString Msg, int AHelpContext) : wclESerial(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESerialMonitor(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESerial(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESerialMonitor(NativeUInt Ident, int AHelpContext)/* overload */ : wclESerial(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESerialMonitor(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESerial(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESerialMonitor(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESerial(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESerialMonitor(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESerial(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESerialMonitor(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION wclESerialClient : public wclESerial
{
	typedef wclESerial inherited;
	
public:
	/* Exception.Create */ inline __fastcall wclESerialClient(const System::UnicodeString Msg) : wclESerial(Msg) { }
	/* Exception.CreateFmt */ inline __fastcall wclESerialClient(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High) : wclESerial(Msg, Args, Args_High) { }
	/* Exception.CreateRes */ inline __fastcall wclESerialClient(NativeUInt Ident)/* overload */ : wclESerial(Ident) { }
	/* Exception.CreateRes */ inline __fastcall wclESerialClient(System::PResStringRec ResStringRec)/* overload */ : wclESerial(ResStringRec) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESerialClient(NativeUInt Ident, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESerial(Ident, Args, Args_High) { }
	/* Exception.CreateResFmt */ inline __fastcall wclESerialClient(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High)/* overload */ : wclESerial(ResStringRec, Args, Args_High) { }
	/* Exception.CreateHelp */ inline __fastcall wclESerialClient(const System::UnicodeString Msg, int AHelpContext) : wclESerial(Msg, AHelpContext) { }
	/* Exception.CreateFmtHelp */ inline __fastcall wclESerialClient(const System::UnicodeString Msg, System::TVarRec const *Args, const int Args_High, int AHelpContext) : wclESerial(Msg, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESerialClient(NativeUInt Ident, int AHelpContext)/* overload */ : wclESerial(Ident, AHelpContext) { }
	/* Exception.CreateResHelp */ inline __fastcall wclESerialClient(System::PResStringRec ResStringRec, int AHelpContext)/* overload */ : wclESerial(ResStringRec, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESerialClient(System::PResStringRec ResStringRec, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESerial(ResStringRec, Args, Args_High, AHelpContext) { }
	/* Exception.CreateResFmtHelp */ inline __fastcall wclESerialClient(NativeUInt Ident, System::TVarRec const *Args, const int Args_High, int AHelpContext)/* overload */ : wclESerial(Ident, Args, Args_High, AHelpContext) { }
	/* Exception.Destroy */ inline __fastcall virtual ~wclESerialClient(void) { }
	
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
#define WCL_SERIAL_FRAMEWORK_VERSION L"8.0.4.0"
static const int WCL_E_SERIAL_MONITORING_RUNNING = int(0x20000);
static const int WCL_E_SERIAL_MONITORING_NOT_RUNNING = int(0x20001);
static const int WCL_E_SERIAL_DEVICE_CLASS_NOT_FOUND = int(0x20002);
static const int WCL_E_SERIAL_ALLOCATE_MASTER_PORT_FAILED = int(0x20003);
static const int WCL_E_SERIAL_MASTER_PORT_NOT_ALLOCATED = int(0x20004);
static const int WCL_E_SERIAL_CREATE_DEVICES_FILTER_FAILED = int(0x20005);
static const int WCL_E_SERIAL_IO_SERVICES_NOT_FOUND = int(0x20006);
static const int WCL_E_SERIAL_FEATURE_NOT_SUPPORTED = int(0x20007);
static const int WCL_E_SERIAL_UNABLE_GET_DEVICE_NODE = int(0x20008);
static const int WCL_E_SERIAL_DEVICE_SWITCH_FAILED = int(0x20009);
static const int WCL_E_SERIAL_DEVICE_REMOVED = int(0x2000a);
static const int WCL_E_SERIAL_CLIENT_NOT_CONNECTED = int(0x2000b);
static const int WCL_E_SERIAL_CLIENT_CONNECTED = int(0x2000c);
static const int WCL_E_SERIAL_CLIENT_BUSY = int(0x2000d);
static const int WCL_E_SERIAL_CONNECTION_TERMINATE = int(0x2000e);
static const int WCL_E_SERIAL_READ_ERROR = int(0x2000f);
static const int WCL_E_SERIAL_CREATE_OVERLAPPED_EVENT_FAILED = int(0x20010);
static const int WCL_E_SERIAL_CREATE_RESTART_EVENT_FAILED = int(0x20011);
static const int WCL_E_SERIAL_OPEN_PORT_FAILED = int(0x20012);
static const int WCL_E_SERIAL_GET_COMM_CONFIGURATION_FAILED = int(0x20013);
static const int WCL_E_SERIAL_SET_COMM_CONFIGURATION_FAILED = int(0x20014);
static const int WCL_E_SERIAL_GET_COMM_TIMEOUTS_FAILED = int(0x20015);
static const int WCL_E_SERIAL_SET_EVENTS_MASK_FAILED = int(0x20016);
static const int WCL_E_SERIAL_GET_READ_BUFFER_SIZE_FAILED = int(0x20017);
static const int WCL_E_SERIAL_GET_WRITE_BUFFER_SIZE_FAILED = int(0x20018);
static const int WCL_E_SERIAL_SET_READ_BUFFER_SIZE_FILED = int(0x20019);
static const int WCL_E_SERIAL_SET_WRITE_BUFFER_SIZE_FAILED = int(0x2001a);
static const int WCL_E_SERIAL_INIT_OVERLAPPED_OPERATION_FAILED = int(0x2001b);
static const int WCL_E_SERIAL_WRITE_TIMEOUT = int(0x2001c);
static const int WCL_E_SERIAL_WRITE_FAILED = int(0x2001d);
static const int WCL_E_SERIAL_DEVICE_WRITE_TIMEOUT = int(0x2001e);
static const int WCL_E_SERIAL_GET_COMM_FEATURES_FAILED = int(0x2001f);
static const int WCL_E_SERIAL_SET_COMM_TIMEOUTS_FAILED = int(0x20020);
static const int WCL_E_SERIAL_CLEAR_COMM_BREAK_FAILED = int(0x20021);
static const int WCL_E_SERIAL_ESCAPE_COMM_FUNCTION_FAILED = int(0x20022);
static const int WCL_E_SERIAL_FLUSH_BUFFERS_FAILED = int(0x20023);
static const int WCL_E_SERIAL_GET_MODEM_STATUS_FAILED = int(0x20024);
static const int WCL_E_SERIAL_PURGE_COMM_FAILED = int(0x20025);
static const int WCL_E_SERIAL_SET_COMM_BREAK_FAILED = int(0x20026);
static const int WCL_E_SERIAL_TRANSMIT_COMM_CHAR_FAILED = int(0x20027);
}	/* namespace Wclserialerrors */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLSERIALERRORS)
using namespace Wclserialerrors;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclserialerrorsHPP
