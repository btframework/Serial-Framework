// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclSerialMessages.pas' rev: 30.00 (Windows)

#ifndef WclserialmessagesHPP
#define WclserialmessagesHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <wclMessaging.hpp>
#include <wclSerialClients.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclserialmessages
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS TwclSerialEventsMessage;
class DELPHICLASS TwclSerialErrorMessage;
class DELPHICLASS TwclSerialReadErrorMessage;
//-- type declarations -------------------------------------------------------
#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclSerialEventsMessage : public Wclmessaging::TwclSerialCategoryMessage
{
	typedef Wclmessaging::TwclSerialCategoryMessage inherited;
	
private:
	Wclserialclients::TwclSerialEvents FEvents;
	
public:
	__fastcall TwclSerialEventsMessage(const Wclserialclients::TwclSerialEvents Events);
	__property Wclserialclients::TwclSerialEvents Events = {read=FEvents, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclSerialEventsMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclSerialErrorMessage : public Wclmessaging::TwclSerialCategoryMessage
{
	typedef Wclmessaging::TwclSerialCategoryMessage inherited;
	
private:
	Wclserialclients::TwclSerialErrors FErrors;
	Wclserialclients::TwclSerialCommunicationStates FStates;
	
public:
	__fastcall TwclSerialErrorMessage(const Wclserialclients::TwclSerialErrors Errors, const Wclserialclients::TwclSerialCommunicationStates States);
	__property Wclserialclients::TwclSerialErrors Errors = {read=FErrors, nodefault};
	__property Wclserialclients::TwclSerialCommunicationStates States = {read=FStates, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclSerialErrorMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclSerialReadErrorMessage : public Wclmessaging::TwclSerialCategoryMessage
{
	typedef Wclmessaging::TwclSerialCategoryMessage inherited;
	
private:
	int FError;
	
public:
	__fastcall TwclSerialReadErrorMessage(const int Error);
	__property int Error = {read=FError, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclSerialReadErrorMessage(void) { }
	
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
static const System::Int8 WCL_MSG_ID_SERIAL_BASE = System::Int8(0x0);
static const System::Int8 WCL_MSG_ID_SERIAL_EVENTS = System::Int8(0x1);
static const System::Int8 WCL_MSG_ID_SERIAL_ERROR = System::Int8(0x2);
static const System::Int8 WCL_MSG_ID_SERIAL_READ_ERROR = System::Int8(0x3);
}	/* namespace Wclserialmessages */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLSERIALMESSAGES)
using namespace Wclserialmessages;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclserialmessagesHPP
