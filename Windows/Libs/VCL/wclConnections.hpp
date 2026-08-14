// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclConnections.pas' rev: 30.00 (Windows)

#ifndef WclconnectionsHPP
#define WclconnectionsHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>
#include <wclWinApi.hpp>
#include <System.Classes.hpp>
#include <wclMessaging.hpp>
#include <wclErrors.hpp>
#include <wclConnectionErrors.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclconnections
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS TwclCustomConnection;
class DELPHICLASS TwclClientConnection;
class DELPHICLASS TwclClientDataConnection;
class DELPHICLASS TwclServerClientConnection;
class DELPHICLASS TwclServerConnection;
class DELPHICLASS TwclServerClientDataConnection;
class DELPHICLASS TwclServerDataConnection;
class DELPHICLASS TwclCustomDataProcessor;
//-- type declarations -------------------------------------------------------
#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclCustomConnection : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	_RTL_CRITICAL_SECTION FCS;
	Wclmessaging::TwclMessageReceiver* FReceiver;
	unsigned FThreadId;
	Wclmessaging::TwclMessageProcessingMethod __fastcall GetMessageProcessing(void);
	
protected:
	void __fastcall EnterCS(void);
	void __fastcall LeaveCS(void);
	int __fastcall PostMessage(Wclmessaging::TwclMessage* Message);
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual void __fastcall CheckState(void) = 0 ;
	__property Wclmessaging::TwclMessageReceiver* Receiver = {read=FReceiver};
	__property unsigned ThreadId = {read=FThreadId, nodefault};
	
public:
	__fastcall virtual TwclCustomConnection(void);
	__fastcall virtual ~TwclCustomConnection(void);
	__property Wclmessaging::TwclMessageProcessingMethod MessageProcessing = {read=GetMessageProcessing, nodefault};
};

#pragma pack(pop)

enum DECLSPEC_DENUM TwclClientState : unsigned int { csDisconnected, csPreparing, csConnecting, csConnected, csDisconnecting };

typedef void __fastcall (__closure *TwclClientConnectEvent)(System::TObject* Sender, const int Error);

typedef void __fastcall (__closure *TwclClientDisconnectEvent)(System::TObject* Sender, const int Reason);

class PASCALIMPLEMENTATION TwclClientConnection : public TwclCustomConnection
{
	typedef TwclCustomConnection inherited;
	
private:
	TwclClientState FState;
	unsigned FTimeout;
	NativeUInt FDisconnectEvent;
	NativeUInt FThread;
	TwclClientConnectEvent FOnConnect;
	TwclClientDisconnectEvent FOnDisconnect;
	void __fastcall SetTimeout(const unsigned Value);
	void __fastcall CommunicationThread(void);
	
protected:
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual void __fastcall CheckState(void);
	void __fastcall InternalDisconnect(const int Reason);
	void __fastcall NotifyClosed(const int Reason);
	virtual void __fastcall DoConnect(const int Error);
	virtual void __fastcall DoDisconnect(const int Reason);
	virtual int __fastcall HalCommunicate(const NativeUInt Event);
	virtual int __fastcall HalConnect(const NativeUInt Event) = 0 ;
	virtual int __fastcall HalDisconnect(void) = 0 ;
	int __fastcall Connect(const Wclmessaging::TwclMessageProcessingMethod MessageProcessing);
	
public:
	__fastcall virtual TwclClientConnection(void);
	__fastcall virtual ~TwclClientConnection(void);
	int __fastcall Disconnect(void);
	__property TwclClientState State = {read=FState, nodefault};
	__property unsigned Timeout = {read=FTimeout, write=SetTimeout, default=10000};
	__property TwclClientConnectEvent OnConnect = {read=FOnConnect, write=FOnConnect};
	__property TwclClientDisconnectEvent OnDisconnect = {read=FOnDisconnect, write=FOnDisconnect};
};


typedef void __fastcall (__closure *TwclClientDataEvent)(System::TObject* Sender, const void * Data, const unsigned Size);

class PASCALIMPLEMENTATION TwclClientDataConnection : public TwclClientConnection
{
	typedef TwclClientConnection inherited;
	
private:
	TwclClientDataEvent FOnData;
	
protected:
	void __fastcall NotifyDataReceived(const void * Data, const unsigned Size);
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual void __fastcall DoData(const void * Data, const unsigned Size);
	virtual int __fastcall HalGetReadBufferSize(unsigned &Size) = 0 ;
	virtual int __fastcall HalGetWriteBufferSize(unsigned &Size) = 0 ;
	virtual int __fastcall HalSetReadBufferSize(const unsigned Size) = 0 ;
	virtual int __fastcall HalSetWriteBufferSize(const unsigned Size) = 0 ;
	virtual int __fastcall HalWrite(const void * Data, const unsigned Size, unsigned &Written) = 0 ;
	
public:
	__fastcall virtual TwclClientDataConnection(void);
	int __fastcall GetReadBufferSize(/* out */ unsigned &Size);
	int __fastcall GetWriteBufferSize(/* out */ unsigned &Size);
	int __fastcall SetReadBufferSize(const unsigned Size);
	int __fastcall SetWriteBufferSize(const unsigned Size);
	int __fastcall Write(const void * Data, const unsigned Size, /* out */ unsigned &Written);
	__property TwclClientDataEvent OnData = {read=FOnData, write=FOnData};
public:
	/* TwclClientConnection.Destroy */ inline __fastcall virtual ~TwclClientDataConnection(void) { }
	
};


class PASCALIMPLEMENTATION TwclServerClientConnection : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	_RTL_CRITICAL_SECTION FCS;
	bool FDisconnected;
	void *FParams;
	Wclmessaging::TwclMessageReceiver* FReceiver;
	TwclServerConnection* FServer;
	unsigned FThreadId;
	NativeUInt FDisconnectEvent;
	NativeUInt FThread;
	NativeUInt FThreadInitDoneEvent;
	int FThreadInitResult;
	TwclClientConnectEvent FOnConnect;
	TwclClientDisconnectEvent FOnDisconnect;
	int __fastcall CopyParams(const void * Params, const unsigned Size);
	void __fastcall FreeParams(void);
	void __fastcall CommunicationThread(void);
	void __fastcall InternalDisconnect(const int Reason);
	int __fastcall Accept(TwclServerConnection* const Server, const void * Params, const unsigned Size);
	__property TwclClientConnectEvent OnConnect = {read=FOnConnect, write=FOnConnect};
	__property TwclClientDisconnectEvent OnDisconnect = {read=FOnDisconnect, write=FOnDisconnect};
	
protected:
	void __fastcall EnterCS(void);
	void __fastcall LeaveCS(void);
	int __fastcall PostMessage(Wclmessaging::TwclMessage* Message);
	void __fastcall NotifyClosed(const int Reason);
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual int __fastcall HalAccept(void) = 0 ;
	virtual int __fastcall HalCommunicate(const NativeUInt Event);
	virtual int __fastcall HalDisconnect(void) = 0 ;
	virtual void __fastcall DoConnect(const int Error);
	virtual void __fastcall DoDisconnect(const int Reason);
	__property bool Disconnected = {read=FDisconnected, nodefault};
	__property void * Params = {read=FParams};
	__property Wclmessaging::TwclMessageReceiver* Receiver = {read=FReceiver};
	__property unsigned ThreadId = {read=FThreadId, nodefault};
	
public:
	__fastcall virtual TwclServerClientConnection(void);
	__fastcall virtual ~TwclServerClientConnection(void);
	int __fastcall Disconnect(void);
	__property TwclServerConnection* Server = {read=FServer};
};


enum DECLSPEC_DENUM TwclServerState : unsigned int { ssClosed, ssPreparing, ssListening, ssAccepting, ssClosing };

typedef void __fastcall (__closure *TwclServerClientConnectEvent)(System::TObject* Sender, TwclServerClientConnection* const Client, const int Error);

typedef void __fastcall (__closure *TwclServerClientDisconnectEvent)(System::TObject* Sender, TwclServerClientConnection* const Client, const int Reason);

class PASCALIMPLEMENTATION TwclServerConnection : public TwclCustomConnection
{
	typedef TwclCustomConnection inherited;
	
public:
	TwclServerClientConnection* operator[](const int Index) { return Clients[Index]; }
	
private:
	System::Classes::TList* FClients;
	TwclServerState FState;
	TwclServerClientConnection* FClientToDelete;
	NativeUInt FCloseEvent;
	NativeUInt FThread;
	NativeUInt FThreadInitDoneEvent;
	int FThreadInitResult;
	TwclClientDisconnectEvent FOnClosed;
	TwclServerClientConnectEvent FOnConnect;
	TwclServerClientDisconnectEvent FOnDisconnect;
	System::Classes::TNotifyEvent FOnListen;
	TwclServerClientConnection* __fastcall GetClients(const int Index);
	int __fastcall GetClientsCount(void);
	void __fastcall ClientConnect(System::TObject* Sender, const int Error);
	void __fastcall ClientDisconnect(System::TObject* Sender, const int Reason);
	void __fastcall CommunicationThread(void);
	void __fastcall DeleteClient(TwclServerClientConnection* const Client);
	
protected:
	virtual void __fastcall CheckState(void);
	void __fastcall InternalClose(const int Reason);
	int __fastcall CreateClientConnection(const void * Params, const unsigned Size);
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual void __fastcall SetClientEventHandler(TwclServerClientConnection* const Client);
	virtual void __fastcall DoClosed(const int Reason);
	virtual void __fastcall DoConnect(TwclServerClientConnection* const Client, const int Error);
	virtual void __fastcall DoDisconnect(TwclServerClientConnection* const Client, const int Reason);
	virtual void __fastcall DoListen(void);
	virtual int __fastcall HalListen(const NativeUInt Event) = 0 ;
	virtual int __fastcall HalClose(void) = 0 ;
	virtual TwclServerClientConnection* __fastcall HalCreateClient(void) = 0 ;
	virtual int __fastcall HalPrepare(void) = 0 ;
	int __fastcall Listen(const Wclmessaging::TwclMessageProcessingMethod MessageProcessing);
	
public:
	__fastcall virtual TwclServerConnection(void);
	__fastcall virtual ~TwclServerConnection(void);
	int __fastcall Close(void);
	__property TwclServerClientConnection* Clients[const int Index] = {read=GetClients/*, default*/};
	__property int ClientsCount = {read=GetClientsCount, nodefault};
	__property TwclServerState State = {read=FState, nodefault};
	__property TwclClientDisconnectEvent OnClosed = {read=FOnClosed, write=FOnClosed};
	__property TwclServerClientConnectEvent OnConnect = {read=FOnConnect, write=FOnConnect};
	__property TwclServerClientDisconnectEvent OnDisconnect = {read=FOnDisconnect, write=FOnDisconnect};
	__property System::Classes::TNotifyEvent OnListen = {read=FOnListen, write=FOnListen};
};


class PASCALIMPLEMENTATION TwclServerClientDataConnection : public TwclServerClientConnection
{
	typedef TwclServerClientConnection inherited;
	
private:
	TwclClientDataEvent FOnData;
	__property TwclClientDataEvent OnData = {read=FOnData, write=FOnData};
	
protected:
	void __fastcall NotifyDataReceived(const void * Data, const unsigned Size);
	virtual void __fastcall MessageReceived(Wclmessaging::TwclMessage* const Message);
	virtual void __fastcall DoData(const void * Data, const unsigned Size);
	virtual int __fastcall HalGetReadBufferSize(unsigned &Size) = 0 ;
	virtual int __fastcall HalGetWriteBufferSize(unsigned &Size) = 0 ;
	virtual int __fastcall HalSetReadBufferSize(const unsigned Size) = 0 ;
	virtual int __fastcall HalSetWriteBufferSize(const unsigned Size) = 0 ;
	virtual int __fastcall HalWrite(const void * Data, const unsigned Size, unsigned &Written) = 0 ;
	
public:
	__fastcall virtual TwclServerClientDataConnection(void);
	int __fastcall GetReadBufferSize(/* out */ unsigned &Size);
	int __fastcall GetWriteBufferSize(/* out */ unsigned &Size);
	int __fastcall SetReadBufferSize(const unsigned Size);
	int __fastcall SetWriteBufferSize(const unsigned Size);
	int __fastcall Write(const void * Data, const unsigned Size, /* out */ unsigned &Written);
public:
	/* TwclServerClientConnection.Destroy */ inline __fastcall virtual ~TwclServerClientDataConnection(void) { }
	
};


typedef void __fastcall (__closure *TwclServerConnectionDataEvent)(System::TObject* Sender, TwclServerClientDataConnection* const Client, const void * Data, const unsigned Size);

class PASCALIMPLEMENTATION TwclServerDataConnection : public TwclServerConnection
{
	typedef TwclServerConnection inherited;
	
private:
	TwclServerConnectionDataEvent FOnData;
	void __fastcall ClientData(System::TObject* Sender, const void * Data, const unsigned Size);
	
protected:
	virtual void __fastcall SetClientEventHandler(TwclServerClientConnection* const Client);
	virtual void __fastcall DoData(TwclServerClientDataConnection* const Client, const void * Data, const unsigned Size);
	
public:
	__fastcall virtual TwclServerDataConnection(void);
	__property TwclServerConnectionDataEvent OnData = {read=FOnData, write=FOnData};
public:
	/* TwclServerConnection.Destroy */ inline __fastcall virtual ~TwclServerDataConnection(void) { }
	
};


typedef void __fastcall (__closure *TwclDataProcessorWriteEvent)(System::TObject* Sender, const void * Data, const unsigned Size, unsigned &Written, int &Error);

class PASCALIMPLEMENTATION TwclCustomDataProcessor : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	TwclDataProcessorWriteEvent FOnWrite;
	
protected:
	int __fastcall Write(const void * Data, const unsigned Size);
	virtual void __fastcall DoWrite(const void * Data, const unsigned Size, /* out */ unsigned &Written, /* out */ int &Error);
	
public:
	__fastcall virtual TwclCustomDataProcessor(void);
	virtual void __fastcall ProcessData(const void * Data, const unsigned Size) = 0 ;
	__property TwclDataProcessorWriteEvent OnWrite = {read=FOnWrite, write=FOnWrite};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclCustomDataProcessor(void) { }
	
};


//-- var, const, procedure ---------------------------------------------------
}	/* namespace Wclconnections */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLCONNECTIONS)
using namespace Wclconnections;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclconnectionsHPP
