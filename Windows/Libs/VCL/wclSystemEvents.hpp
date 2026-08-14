// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclSystemEvents.pas' rev: 30.00 (Windows)

#ifndef WclsystemeventsHPP
#define WclsystemeventsHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <System.Classes.hpp>
#include <wclMessaging.hpp>
#include <wclErrors.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclsystemevents
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS TwclSystemEventsMonitor;
struct TwclPowerStatus;
class DELPHICLASS TwclPowerEventsMonitor;
//-- type declarations -------------------------------------------------------
class PASCALIMPLEMENTATION TwclSystemEventsMonitor : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	Wclmessaging::TwclMessageReceiver* FReceiver;
	System::Classes::TNotifyEvent FOnStarted;
	System::Classes::TNotifyEvent FOnStopped;
	bool __fastcall GetActive(void);
	Wclmessaging::TwclMessageProcessingMethod __fastcall GetMessageProcessing(void);
	void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	
protected:
	virtual void __fastcall SystemMessageReceived(Wclmessaging::TwclSystemCategoryMessage* const Message);
	virtual void __fastcall DoStarted(void);
	virtual void __fastcall DoStopped(void);
	
public:
	__fastcall virtual TwclSystemEventsMonitor(void);
	__fastcall virtual ~TwclSystemEventsMonitor(void);
	int __fastcall Stop(void);
	int __fastcall Start(const Wclmessaging::TwclMessageProcessingMethod Method = (Wclmessaging::TwclMessageProcessingMethod)(0x1));
	__property bool Active = {read=GetActive, nodefault};
	__property Wclmessaging::TwclMessageProcessingMethod MessageProcessing = {read=GetMessageProcessing, nodefault};
	__property System::Classes::TNotifyEvent OnStarted = {read=FOnStarted, write=FOnStarted};
	__property System::Classes::TNotifyEvent OnStopped = {read=FOnStopped, write=FOnStopped};
};


enum DECLSPEC_DENUM TwclACLineStatus : unsigned int { lsOffline, lsOnline, lsBackup, lsUnknown };

enum DECLSPEC_DENUM TwclBatteryChargeStatus : unsigned int { csCapacityHigh, csCapacityLow, csCapacityCritical, csCharging, csNoSystemBattery, csUnknown };

typedef System::Set<TwclBatteryChargeStatus, TwclBatteryChargeStatus::csCapacityHigh, TwclBatteryChargeStatus::csUnknown> TwclBatteryChargeStatusFlags;

struct DECLSPEC_DRECORD TwclPowerStatus
{
public:
	TwclACLineStatus ACLineStatus;
	TwclBatteryChargeStatusFlags BatteryChargeStatus;
	System::Byte BatteryLifePercent;
	bool BatterySavingState;
	unsigned BatteryLifeTime;
	unsigned BatteryFullLifeTime;
};


typedef void __fastcall (__closure *TwclPowerStateChangedEvent)(System::TObject* Sender, const Wclmessaging::TwclPowerState State);

class PASCALIMPLEMENTATION TwclPowerEventsMonitor : public TwclSystemEventsMonitor
{
	typedef TwclSystemEventsMonitor inherited;
	
private:
	TwclPowerStateChangedEvent FOnPowerStateChanged;
	
protected:
	virtual void __fastcall SystemMessageReceived(Wclmessaging::TwclSystemCategoryMessage* const Message);
	virtual void __fastcall DoPowerStateChanged(const Wclmessaging::TwclPowerState State);
	
public:
	__fastcall virtual TwclPowerEventsMonitor(void);
	bool __fastcall GetPowerStatus(/* out */ TwclPowerStatus &Status);
	__property TwclPowerStateChangedEvent OnPowerStateChanged = {read=FOnPowerStateChanged, write=FOnPowerStateChanged};
public:
	/* TwclSystemEventsMonitor.Destroy */ inline __fastcall virtual ~TwclPowerEventsMonitor(void) { }
	
};


//-- var, const, procedure ---------------------------------------------------
}	/* namespace Wclsystemevents */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLSYSTEMEVENTS)
using namespace Wclsystemevents;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclsystemeventsHPP
