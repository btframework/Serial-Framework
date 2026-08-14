// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclSerialDevices.pas' rev: 30.00 (Windows)

#ifndef WclserialdevicesHPP
#define WclserialdevicesHPP

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
#include <wclSerialErrors.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclserialdevices
{
//-- forward type declarations -----------------------------------------------
struct TwclSerialDevice;
struct TwclUsbDevice;
class DELPHICLASS TwclSerialMonitor;
//-- type declarations -------------------------------------------------------
struct DECLSPEC_DRECORD TwclSerialDevice
{
public:
	System::UnicodeString FriendlyName;
	bool IsModem;
	System::UnicodeString DeviceName;
};


typedef System::DynamicArray<TwclSerialDevice> TwclSerialDevices;

struct DECLSPEC_DRECORD TwclUsbDevice
{
public:
	System::UnicodeString FriendlyName;
	System::Word VendorId;
	System::Word ProductId;
	System::UnicodeString Instance;
	System::UnicodeString Manufacturer;
	GUID ClassGuid;
	bool Enabled;
};


typedef System::DynamicArray<TwclUsbDevice> TwclUsbDevices;

typedef void __fastcall (__closure *TwclSerialDeviceEvent)(System::TObject* Sender, const System::UnicodeString DeviceName);

typedef void __fastcall (__closure *TwclUsbDeviceEvent)(System::TObject* Sender, const System::UnicodeString Instance);

class PASCALIMPLEMENTATION TwclSerialMonitor : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	Wclmessaging::TwclMessageReceiver* FReceiver;
	TwclSerialDeviceEvent FOnSerialDeviceAdded;
	TwclSerialDeviceEvent FOnSerialDeviceRemoved;
	System::Classes::TNotifyEvent FOnStarted;
	System::Classes::TNotifyEvent FOnStopped;
	TwclUsbDeviceEvent FOnUsbDeviceAdded;
	TwclUsbDeviceEvent FOnUsbDeviceRemoved;
	Wclmessaging::TwclMessageProcessingMethod __fastcall GetMessageProcessing(void);
	bool __fastcall GetMonitoring(void);
	void __fastcall ProcessSerialDevicesChanges(Wclmessaging::TwclHardwareChangedMessage* const Msg);
	void __fastcall ProcessUsbDevicesChanges(Wclmessaging::TwclHardwareChangedMessage* const Msg);
	int __fastcall EnumSerialDevicesByClass(const GUID &DeviceClass, TwclSerialDevices &Devices);
	int __fastcall SwitchUsbDevice(const System::UnicodeString Instance, const bool Enable);
	
protected:
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual void __fastcall DoSerialDeviceAdded(const System::UnicodeString DeviceName);
	virtual void __fastcall DoSerialDeviceRemoved(const System::UnicodeString DeviceName);
	virtual void __fastcall DoStarted(void);
	virtual void __fastcall DoStopped(void);
	virtual void __fastcall DoUsbDeviceAdded(const System::UnicodeString Instance);
	virtual void __fastcall DoUsbDeviceRemoved(const System::UnicodeString Instance);
	
public:
	__fastcall virtual TwclSerialMonitor(void);
	__fastcall virtual ~TwclSerialMonitor(void);
	int __fastcall EnumSerialDevices(/* out */ TwclSerialDevices &Devices);
	int __fastcall EnumUsbDevices(/* out */ TwclUsbDevices &Devices);
	int __fastcall Start(const Wclmessaging::TwclMessageProcessingMethod MessageProcessing = (Wclmessaging::TwclMessageProcessingMethod)(0x1));
	int __fastcall Stop(void);
	int __fastcall DisableUsbDevice(const System::UnicodeString Instance);
	int __fastcall EnableUsbDevice(const System::UnicodeString Instance);
	__property bool Monitoring = {read=GetMonitoring, nodefault};
	__property Wclmessaging::TwclMessageProcessingMethod MessageProcessing = {read=GetMessageProcessing, nodefault};
	__property TwclSerialDeviceEvent OnSerialDeviceAdded = {read=FOnSerialDeviceAdded, write=FOnSerialDeviceAdded};
	__property TwclSerialDeviceEvent OnSerialDeviceRemoved = {read=FOnSerialDeviceRemoved, write=FOnSerialDeviceRemoved};
	__property System::Classes::TNotifyEvent OnStarted = {read=FOnStarted, write=FOnStarted};
	__property System::Classes::TNotifyEvent OnStopped = {read=FOnStopped, write=FOnStopped};
	__property TwclUsbDeviceEvent OnUsbDeviceAdded = {read=FOnUsbDeviceAdded, write=FOnUsbDeviceAdded};
	__property TwclUsbDeviceEvent OnUsbDeviceRemoved = {read=FOnUsbDeviceRemoved, write=FOnUsbDeviceRemoved};
};


//-- var, const, procedure ---------------------------------------------------
}	/* namespace Wclserialdevices */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLSERIALDEVICES)
using namespace Wclserialdevices;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclserialdevicesHPP
