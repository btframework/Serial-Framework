// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclMessaging.pas' rev: 30.00 (Windows)

#ifndef WclmessagingHPP
#define WclmessagingHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>
#include <wclWinApi.hpp>
#include <wclPowerApi.hpp>
#include <System.Classes.hpp>
#include <wclErrors.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclmessaging
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS TwclMessage;
class DELPHICLASS TwclAudioCategoryMessage;
class DELPHICLASS TwclBluetoothCategoryMessage;
class DELPHICLASS TwclConnectionCategoryMessage;
class DELPHICLASS TwclSerialCategoryMessage;
class DELPHICLASS TwclSystemCategoryMessage;
class DELPHICLASS TwclWiFiCategoryMessage;
class DELPHICLASS TwclWiiRemoteCategoryMessage;
class DELPHICLASS TwclUserDefinedCategoryMessage;
class DELPHICLASS TwclHardwareChangedMessage;
class DELPHICLASS TwclPowerStateChangedMessage;
class DELPHICLASS TwclMessageReceiver;
class DELPHICLASS TwclMessageBroadcaster;
//-- type declarations -------------------------------------------------------
enum DECLSPEC_DENUM TwclMessageCategory : unsigned int { mcAudio, mcBluetooth, mcConnection, mcSerial, mcSystem, mcWiFi, mcWiiRemote, mcUser };

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclMessage : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	System::Byte FId;
	TwclMessageCategory FCategory;
	int FRefCounter;
	unsigned FCreated;
	unsigned FQueued;
	unsigned FProcessed;
	
public:
	__fastcall TwclMessage(const System::Byte Id, const TwclMessageCategory Category);
	void __fastcall AddRef(void);
	void __fastcall Release(void);
	__property TwclMessageCategory Category = {read=FCategory, nodefault};
	__property System::Byte Id = {read=FId, nodefault};
	__property unsigned Created = {read=FCreated, nodefault};
	__property unsigned Queued = {read=FQueued, nodefault};
	__property unsigned Processed = {read=FProcessed, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclAudioCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclAudioCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclAudioCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclBluetoothCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclBluetoothCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclBluetoothCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclConnectionCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclConnectionCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclConnectionCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclSerialCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclSerialCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclSerialCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclSystemCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclSystemCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclSystemCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclWiFiCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclWiFiCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclWiFiCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclWiiRemoteCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclWiiRemoteCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclWiiRemoteCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclUserDefinedCategoryMessage : public TwclMessage
{
	typedef TwclMessage inherited;
	
public:
	__fastcall TwclUserDefinedCategoryMessage(const System::Byte Id);
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclUserDefinedCategoryMessage(void) { }
	
};

#pragma pack(pop)

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclHardwareChangedMessage : public TwclSystemCategoryMessage
{
	typedef TwclSystemCategoryMessage inherited;
	
private:
	GUID FInterfaceClass;
	GUID FDeviceClass;
	System::UnicodeString FInstance;
	bool FInserted;
	
public:
	__fastcall TwclHardwareChangedMessage(const GUID &InterfaceClass, const GUID &DeviceClass, const System::UnicodeString Instance, const bool Inserted);
	__property GUID InterfaceClass = {read=FInterfaceClass};
	__property GUID DeviceClass = {read=FDeviceClass};
	__property System::UnicodeString Instance = {read=FInstance};
	__property bool Inserted = {read=FInserted, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclHardwareChangedMessage(void) { }
	
};

#pragma pack(pop)

enum DECLSPEC_DENUM TwclPowerState : unsigned int { psPowerStatusChanged, psResumeAutomatic, psResume, psSuspend, psUnknown };

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclPowerStateChangedMessage : public TwclSystemCategoryMessage
{
	typedef TwclSystemCategoryMessage inherited;
	
private:
	TwclPowerState FState;
	
public:
	__fastcall TwclPowerStateChangedMessage(const TwclPowerState State);
	__property TwclPowerState State = {read=FState, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclPowerStateChangedMessage(void) { }
	
};

#pragma pack(pop)

enum DECLSPEC_DENUM TwclMessageProcessingMethod : unsigned int { mpAsync, mpSync };

enum DECLSPEC_DENUM TwclMessageReceiverState : unsigned int { rsClosed, rsOpening, rsListening, rsClosing };

typedef void __fastcall (__closure *TwclMessageEvent)(TwclMessage* const Message);

class PASCALIMPLEMENTATION TwclMessageReceiver : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	_RTL_CRITICAL_SECTION FCS;
	int FId;
	TwclMessageProcessingMethod FMethod;
	unsigned FOpenThreadId;
	System::Classes::TList* FQueue;
	TwclMessageReceiverState FState;
	NativeUInt FEvent;
	NativeUInt FThread;
	unsigned FThreadId;
	bool FTerminated;
	unsigned FMsg;
	HWND FWnd;
	TwclMessageEvent FOnMessage;
	int __fastcall Initialize(void);
	int __fastcall Uninitialize(void);
	int __fastcall ProcessMessages(void);
	void __fastcall DispatchMessages(void);
	int __fastcall Synchronize(void);
	void __fastcall AsyncThreadProc(void);
	int __fastcall AsyncInitialize(void);
	int __fastcall AsyncUninitialize(void);
	int __fastcall AsyncSynchronize(void);
	int __fastcall AsyncProcessMessages(void);
	bool __fastcall SyncWndProc(const unsigned uMsg, const NativeUInt wParam, const NativeInt lParam);
	int __fastcall SyncInitialize(void);
	int __fastcall SyncUninitialize(void);
	int __fastcall SyncSynchronize(void);
	int __fastcall SyncProcessMessages(void);
	
protected:
	virtual void __fastcall DoMessage(TwclMessage* const Message);
	
public:
	__fastcall virtual TwclMessageReceiver(void);
	__fastcall virtual ~TwclMessageReceiver(void);
	int __fastcall Close(void);
	int __fastcall Open(const TwclMessageProcessingMethod Method);
	int __fastcall Post(TwclMessage* const Message);
	int __fastcall ProcessAllMessages(void);
	__property int Id = {read=FId, nodefault};
	__property TwclMessageProcessingMethod Method = {read=FMethod, nodefault};
	__property unsigned OpenThreadId = {read=FOpenThreadId, nodefault};
	__property TwclMessageReceiverState State = {read=FState, nodefault};
	__property TwclMessageEvent OnMessage = {read=FOnMessage, write=FOnMessage};
};


#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclMessageBroadcaster : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	System::Classes::TList* FReceivers;
	_RTL_CRITICAL_SECTION FReceiversCS;
	NativeUInt FInitEvent;
	bool FSuccess;
	NativeUInt FThread;
	void *FDevNotify;
	NativeUInt FPowerNotify;
	HWND FWnd;
	void __fastcall MonitoringThread(void);
	void __fastcall RegisterDeviceChangesNotification(void);
	void __fastcall UnregisterDeviceChangesNotification(void);
	void __fastcall RegisterPowerChangeNotification(void);
	void __fastcall UnregisterPowerChangeNotification(void);
	bool __fastcall WindowProc(const unsigned uMsg, const NativeUInt wParam, const NativeInt lParam);
	int __fastcall InternalSubscribe(TwclMessageReceiver* const Receiver);
	int __fastcall InternalUnsubscribe(TwclMessageReceiver* const Receiver);
	__classmethod int __fastcall Subscribe(TwclMessageReceiver* const Receiver);
	__classmethod int __fastcall Unsubscribe(TwclMessageReceiver* const Receiver);
	void __fastcall InternalBroadcast(TwclMessage* const Message);
	int __fastcall InternalPost(const int RecevierId, TwclMessage* const Message);
	void __fastcall InternalProcessMessages(void);
	__classmethod int __fastcall LockBroadcaster();
	__classmethod void __fastcall ReleaseBroacaster();
	
public:
	__fastcall TwclMessageBroadcaster(void);
	__fastcall virtual ~TwclMessageBroadcaster(void);
	__classmethod int __fastcall Broadcast(TwclMessage* const Message);
	__classmethod int __fastcall Post(const int ReceiverId, TwclMessage* const Message);
	__classmethod int __fastcall ProcessMessages();
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
static const System::Int8 WCL_MSG_ID_SYS_HARDWARE_CHANGED = System::Int8(0x1);
static const System::Int8 WCL_MSG_ID_SYS_POWER_STATE_CHANGED = System::Int8(0x2);
extern DELPHI_PACKAGE GUID DEVINTERFACE_HID;
extern DELPHI_PACKAGE GUID DEVINTERFACE_USB;
extern DELPHI_PACKAGE GUID DEVINTERFACE_COMPORT;
extern DELPHI_PACKAGE GUID DEVINTERFACE_BLUETOOTHLE;
extern DELPHI_PACKAGE GUID DEVCLASS_BLUETOOTH;
extern DELPHI_PACKAGE GUID DEVCLASS_COMPORT;
extern DELPHI_PACKAGE GUID DEVCLASS_MODEM;
extern DELPHI_PACKAGE GUID DEVCLASS_COM0COM;
extern DELPHI_PACKAGE GUID DEVCLASS_NET;
extern DELPHI_PACKAGE GUID DEVCLASS_NETCLIENT;
extern DELPHI_PACKAGE GUID DEVCLASS_NETSERVICE;
extern DELPHI_PACKAGE GUID DEVCLASS_NETTRANS;
extern DELPHI_PACKAGE GUID DEVCLASS_USB;
extern DELPHI_PACKAGE GUID DEVCLASS_USB_HUB;
}	/* namespace Wclmessaging */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLMESSAGING)
using namespace Wclmessaging;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclmessagingHPP
