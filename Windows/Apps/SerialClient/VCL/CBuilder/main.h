//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "wclSerialClients.hpp"
#include "wclSerialDevices.hpp"
//---------------------------------------------------------------------------
class TfmMain : public TForm
{
__published:	// IDE-managed Components
    TLabel *laBaudRate;
    TLabel *laDtrControl;
    TLabel *laRtsControl;
    TLabel *laXonLim;
    TLabel *laXoffLim;
    TLabel *laByteSize;
    TLabel *laParity;
    TLabel *laStopBites;
    TLabel *laXonChar;
    TLabel *laXoffChar;
    TLabel *laErrorChar;
    TLabel *laEofChar;
    TLabel *laEvtChar;
    TLabel *laReadBufferSize;
    TLabel *laWriteBufferSize;
    TLabel *laReadInterval;
    TLabel *laReadMultiplier;
    TLabel *laReadConstant;
    TLabel *laWriteMultiplier;
    TLabel *laWriteConstant;
    TLabel *laFunc;
    TLabel *laCharCode;
    TLabel *laWriteTimeout;
    TLabel *laLineFeed;
    TListBox *lbEvents;
    TButton *btClear;
    TButton *btEnum;
    TComboBox *cbPorts;
    TButton *btConnect;
    TButton *btDisconnect;
    TButton *btGetConfig;
    TEdit *edBaudRate;
    TCheckBox *cbParityCheck;
    TCheckBox *cbOutxCtsFlow;
    TCheckBox *cbOutxDsrFlow;
    TComboBox *cbDtrControl;
    TCheckBox *cbDsrSensitivity;
    TCheckBox *cbTXContinueOnXoff;
    TCheckBox *cbOutX;
    TCheckBox *cbInX;
    TCheckBox *cbErrorCharReplace;
    TCheckBox *cbNullStrip;
    TComboBox *cbRtsControl;
    TCheckBox *cbAbortOnError;
    TEdit *edXonLim;
    TEdit *edXoffLim;
    TComboBox *cbByteSize;
    TComboBox *cbParity;
    TComboBox *cbStopBits;
    TEdit *edXonChar;
    TEdit *edXoffChar;
    TEdit *edErrorChar;
    TEdit *edEofChar;
    TEdit *edEvtChar;
    TButton *btSetConfig;
    TEdit *edReadBufferSize;
    TEdit *edWriteBufferSize;
    TButton *btGetBuffers;
    TButton *btSetBuffers;
    TEdit *edReadInterval;
    TEdit *edReadMultiplier;
    TEdit *edReadConstant;
    TEdit *edWriteMultiplier;
    TEdit *edWriteConstant;
    TButton *btGetTimeouts;
    TButton *btSetTimeouts;
    TButton *btClearCommBreak;
    TComboBox *cbFunc;
    TButton *btFunc;
    TButton *btFlushBuffers;
    TCheckBox *cbpurgeRxAbort;
    TCheckBox *cbpurgeRxClear;
    TCheckBox *cbpurgeTxAbort;
    TCheckBox *cbpurgeTxClear;
    TButton *btPurge;
    TButton *btSetCommBreak;
    TEdit *edChar;
    TButton *btTransmit;
    TButton *btSend;
    TEdit *edText;
    TEdit *edWriteTimeout;
    TButton *btSetWriteTimeout;
    TComboBox *cbLineFeed;

    void __fastcall FormCreate(TObject *Sender);
    void __fastcall FormDestroy(TObject *Sender);
    void __fastcall btClearClick(TObject *Sender);
    void __fastcall btEnumClick(TObject *Sender);
    void __fastcall btConnectClick(TObject *Sender);
    void __fastcall btDisconnectClick(TObject *Sender);
    void __fastcall btSetConfigClick(TObject *Sender);
    void __fastcall btGetConfigClick(TObject *Sender);
    void __fastcall btGetBuffersClick(TObject *Sender);
    void __fastcall btSetBuffersClick(TObject *Sender);
    void __fastcall btGetTimeoutsClick(TObject *Sender);
    void __fastcall btSetTimeoutsClick(TObject *Sender);
    void __fastcall btClearCommBreakClick(TObject *Sender);
    void __fastcall btSetCommBreakClick(TObject *Sender);
    void __fastcall btFlushBuffersClick(TObject *Sender);
    void __fastcall btFuncClick(TObject *Sender);
    void __fastcall btPurgeClick(TObject *Sender);
    void __fastcall btTransmitClick(TObject *Sender);
    void __fastcall btSendClick(TObject *Sender);
    void __fastcall btSetWriteTimeoutClick(TObject *Sender);
private:	// User declarations
    TwclSerialClient* FClient;
    TwclSerialMonitor* FMonitor;

    void __fastcall EnumComPorts();

    void __fastcall ReadConfiguration();
    void __fastcall ReadTimeouts();
    void __fastcall ReadBuffers();

    void __fastcall ClearConfig();
    void __fastcall ClearTimeouts();
    void __fastcall ClearBuffers();

    void __fastcall ClientConnect(TObject *Sender, const int Error);
    void __fastcall ClientData(TObject *Sender, const void* Data,
        const unsigned int Size);
    void __fastcall ClientDisconnect(TObject *Sender, const int Reason);
    void __fastcall ClientError(TObject *Sender, const TwclSerialErrors Errors,
        const TwclSerialCommunicationStates States);
    void __fastcall ClientReadError(TObject *Sender, const int Error);
    void __fastcall ClientEvents(TObject *Sender,
        const TwclSerialEvents Events);
public:		// User declarations
    __fastcall TfmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfmMain *fmMain;
//---------------------------------------------------------------------------
#endif
