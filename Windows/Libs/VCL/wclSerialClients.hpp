// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclSerialClients.pas' rev: 30.00 (Windows)

#ifndef WclserialclientsHPP
#define WclserialclientsHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>
#include <wclWinApi.hpp>
#include <wclConnections.hpp>
#include <wclMessaging.hpp>
#include <wclErrors.hpp>
#include <wclConnectionErrors.hpp>
#include <wclSerialErrors.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclserialclients
{
//-- forward type declarations -----------------------------------------------
struct TwclSerialConfig;
struct TwclSerialTimeouts;
struct TwclSerialFeatures;
class DELPHICLASS TwclSerialClient;
//-- type declarations -------------------------------------------------------
enum DECLSPEC_DENUM TwclSerialDtrControl : unsigned int { dtrControlDisable, dtrControlEnable, dtrControlHandshake };

enum DECLSPEC_DENUM TwclSerialRtsControl : unsigned int { rtsControlDisable, rtsControlEnable, rtsControlHandshake, rtsControlToggle };

enum DECLSPEC_DENUM TwclSerialParity : unsigned int { spNo, spOdd, spEven, spMark, spSpace };

typedef System::Set<TwclSerialParity, TwclSerialParity::spNo, TwclSerialParity::spSpace> TwclSerialParities;

enum DECLSPEC_DENUM TwclSerialStopBits : unsigned int { sbOne, sbOne5, sbTwo };

typedef System::Set<TwclSerialStopBits, TwclSerialStopBits::sbOne, TwclSerialStopBits::sbTwo> TwclSerialStopBitsSet;

struct DECLSPEC_DRECORD TwclSerialConfig
{
public:
	unsigned BaudRate;
	bool ParityCheck;
	bool OutxCtsFlow;
	bool OutxDsrFlow;
	TwclSerialDtrControl DtrControl;
	bool DsrSensitivity;
	bool TxContinueOnXoff;
	bool OutX;
	bool InX;
	bool ErrorCharReplace;
	bool NullStrip;
	TwclSerialRtsControl RtsControl;
	bool AbortOnError;
	System::Word XonLim;
	System::Word XoffLim;
	System::Byte ByteSize;
	TwclSerialParity Parity;
	TwclSerialStopBits StopBits;
	char XonChar;
	char XoffChar;
	char ErrorChar;
	char EofChar;
	char EvtChar;
};


struct DECLSPEC_DRECORD TwclSerialTimeouts
{
public:
	unsigned ReadInterval;
	unsigned ReadMultiplier;
	unsigned ReadConstant;
	unsigned WriteMultiplier;
	unsigned WriteConstant;
};


enum DECLSPEC_DENUM TwclSerialPurgeFlag : unsigned int { purgeRxAbort, purgeRxClear, purgeTxAbort, purgeTxClear };

typedef System::Set<TwclSerialPurgeFlag, TwclSerialPurgeFlag::purgeRxAbort, TwclSerialPurgeFlag::purgeTxClear> TwclSerialPurgeFlags;

enum DECLSPEC_DENUM TwclSerialEscapeFunction : unsigned int { escClrBreak, escClrDtr, escClrRts, escSetBreak, escSetDtr, escSetRts, escSetXoff, escSetXon };

enum DECLSPEC_DENUM TwclSerialEvent : unsigned int { evBreak, evCts, evDsr, evRing, evRlsd, evChar };

typedef System::Set<TwclSerialEvent, TwclSerialEvent::evBreak, TwclSerialEvent::evChar> TwclSerialEvents;

enum DECLSPEC_DENUM TwclSerialError : unsigned int { erBreak, erFrame, erOverrun, erRxOver, erRxParity };

typedef System::Set<TwclSerialError, TwclSerialError::erBreak, TwclSerialError::erRxParity> TwclSerialErrors;

enum DECLSPEC_DENUM TwclSerialCommunicationState : unsigned int { csCtsHold, csDsrHold, csRlsdHold, csXoffHold, csXoffSent, csEof, csTxim };

typedef System::Set<TwclSerialCommunicationState, TwclSerialCommunicationState::csCtsHold, TwclSerialCommunicationState::csTxim> TwclSerialCommunicationStates;

enum DECLSPEC_DENUM TwclModemStatus : unsigned int { msCtsOn, msDsrOn, msRingOn, msRlsdOn };

typedef System::Set<TwclModemStatus, TwclModemStatus::msCtsOn, TwclModemStatus::msRlsdOn> TwclModemStatuses;

enum DECLSPEC_DENUM TwclSerialBaudRate : unsigned int { br075, br110, br134_5, br150, br300, br600, br1200, br1800, br2400, br4800, br7200, br9600, br14400, br19200, br38400, br56K, br57600, br115200, br128K, brUser };

typedef System::Set<TwclSerialBaudRate, TwclSerialBaudRate::br075, TwclSerialBaudRate::brUser> TwclSerialBaudRates;

enum DECLSPEC_DENUM TwclSerialType : unsigned int { stFax, stLat, stModem, stNetworkBridge, stParallelPort, stRS232, stRS422, stRS423, stRS449, stScanner, stTcpIpTelNet, stX25, stUnspecified };

enum DECLSPEC_DENUM TwclSerialCapability : unsigned int { sc16BitMode, scDtrDsr, scIntervalTimeouts, scParityCheck, scRlsd, scRtsCts, scSetXChar, scSpecialChars, scTotalTimeouts, scXOnXoff };

typedef System::Set<TwclSerialCapability, TwclSerialCapability::sc16BitMode, TwclSerialCapability::scXOnXoff> TwclSerialCapabilities;

enum DECLSPEC_DENUM TwclSerialParam : unsigned int { spBaud, spDataBits, spHandshaking, spParity, spParityCheck, sRlsd, spStopBits };

typedef System::Set<TwclSerialParam, TwclSerialParam::spBaud, TwclSerialParam::spStopBits> TwclSerialParams;

enum DECLSPEC_DENUM TwclSerialDataSize : unsigned int { sdFive, sdSix, sdSeven, sdEight, sdSixteen, sdWide };

typedef System::Set<TwclSerialDataSize, TwclSerialDataSize::sdFive, TwclSerialDataSize::sdWide> TwclSerialDataSizes;

struct DECLSPEC_DRECORD TwclSerialFeatures
{
public:
	unsigned MaxTxBuffer;
	unsigned MaxRxBuffer;
	TwclSerialBaudRate MaxBaudRate;
	TwclSerialType SerialType;
	TwclSerialCapabilities Capabilities;
	TwclSerialParams SettableParams;
	TwclSerialBaudRates SettableBaud;
	TwclSerialDataSizes SettableData;
	TwclSerialStopBitsSet SettableStopBits;
	TwclSerialParities SettableParity;
};


typedef void __fastcall (__closure *TwclSerialDeviceErrorEvent)(System::TObject* Sender, const TwclSerialErrors Errors, const TwclSerialCommunicationStates States);

typedef void __fastcall (__closure *TwclSerialDeviceEventsEvent)(System::TObject* Sender, const TwclSerialEvents Events);

typedef void __fastcall (__closure *TwclSerialDeviceReadErrorEvent)(System::TObject* Sender, const int Error);

class PASCALIMPLEMENTATION TwclSerialClient : public Wclconnections::TwclClientDataConnection
{
	typedef Wclconnections::TwclClientDataConnection inherited;
	
private:
	bool FConnectionLock;
	System::UnicodeString FDeviceName;
	NativeUInt FHandle;
	unsigned FWriteTimeout;
	_DCB FDcb;
	NativeUInt FOverlappedEvent;
	NativeUInt FRestartEvent;
	_COMMTIMEOUTS FTimeouts;
	TwclSerialDeviceErrorEvent FOnError;
	TwclSerialDeviceEventsEvent FOnEvents;
	TwclSerialDeviceReadErrorEvent FOnReadError;
	
protected:
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual int __fastcall HalCommunicate(const NativeUInt Event);
	virtual int __fastcall HalConnect(const NativeUInt Event);
	virtual int __fastcall HalDisconnect(void);
	virtual int __fastcall HalGetReadBufferSize(unsigned &Size);
	virtual int __fastcall HalGetWriteBufferSize(unsigned &Size);
	virtual int __fastcall HalSetReadBufferSize(const unsigned Size);
	virtual int __fastcall HalSetWriteBufferSize(const unsigned Size);
	virtual int __fastcall HalWrite(const void * Data, const unsigned Size, unsigned &Written);
	virtual int __fastcall HalGetFeatures(TwclSerialFeatures &Features);
	virtual int __fastcall HalGetConfig(TwclSerialConfig &Config);
	virtual int __fastcall HalSetConfig(const TwclSerialConfig &Config);
	virtual int __fastcall HalGetTimeouts(TwclSerialTimeouts &Timeouts);
	virtual int __fastcall HalSetTimeouts(const TwclSerialTimeouts &Timeouts);
	virtual int __fastcall HalClearCommBreak(void);
	virtual int __fastcall HalEscapeCommFunction(const TwclSerialEscapeFunction Func);
	virtual int __fastcall HalFlushBuffers(void);
	virtual int __fastcall HalGetModemStatus(TwclModemStatuses &Status);
	virtual int __fastcall HalPurgeComm(const TwclSerialPurgeFlags Flags);
	virtual int __fastcall HalSetCommBreak(void);
	virtual int __fastcall HalTransmitCommChar(const char Ch);
	virtual void __fastcall DoError(const TwclSerialErrors Errors, const TwclSerialCommunicationStates States);
	virtual void __fastcall DoEvents(const TwclSerialEvents Events);
	virtual void __fastcall DoReadError(const int Error);
	
public:
	__fastcall virtual TwclSerialClient(void);
	HIDESBASE int __fastcall Connect(const System::UnicodeString DeviceName, const Wclmessaging::TwclMessageProcessingMethod MessageProcessing = (Wclmessaging::TwclMessageProcessingMethod)(0x1));
	int __fastcall GetFeatures(/* out */ TwclSerialFeatures &Features);
	int __fastcall GetConfig(/* out */ TwclSerialConfig &Config);
	int __fastcall SetConfig(const TwclSerialConfig &Config);
	int __fastcall GetTimeouts(/* out */ TwclSerialTimeouts &Timeouts);
	int __fastcall SetTimeouts(const TwclSerialTimeouts &Timeouts);
	int __fastcall ClearCommBreak(void);
	int __fastcall EscapeCommFunction(const TwclSerialEscapeFunction Func);
	int __fastcall FlushBuffers(void);
	int __fastcall GetModemStatus(/* out */ TwclModemStatuses &Status);
	int __fastcall PurgeComm(const TwclSerialPurgeFlags Flags);
	int __fastcall SetCommBreak(void);
	int __fastcall TransmitCommChar(const char Ch);
	__property System::UnicodeString DeviceName = {read=FDeviceName};
	__property unsigned WriteTimeout = {read=FWriteTimeout, write=FWriteTimeout, nodefault};
	__property TwclSerialDeviceErrorEvent OnError = {read=FOnError, write=FOnError};
	__property TwclSerialDeviceEventsEvent OnEvents = {read=FOnEvents, write=FOnEvents};
	__property TwclSerialDeviceReadErrorEvent OnReadError = {read=FOnReadError, write=FOnReadError};
public:
	/* TwclClientConnection.Destroy */ inline __fastcall virtual ~TwclSerialClient(void) { }
	
};


//-- var, const, procedure ---------------------------------------------------
}	/* namespace Wclserialclients */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLSERIALCLIENTS)
using namespace Wclserialclients;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclserialclientsHPP
