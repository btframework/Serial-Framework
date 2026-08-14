unit main;

interface

uses
  Forms, Controls, StdCtrls, Classes, wclSystemEvents, wclMessaging;

type
  TfmMain = class(TForm)
    btOpen: TButton;
    btClose: TButton;
    btGetState: TButton;
    lbLog: TListBox;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure btOpenClick(Sender: TObject);
    procedure btCloseClick(Sender: TObject);
    procedure btGetStateClick(Sender: TObject);

  private
    FMonitor: TwclPowerEventsMonitor;

    procedure PowerStateChanged(Sender: TObject; const State: TwclPowerState);
    procedure MonitorStarted(Sender: TObject);
    procedure MonitorStopped(Sender: TObject);
  end;

var
  fmMain: TfmMain;

implementation

uses
  wclErrors, SysUtils;

{$R *.dfm}

procedure TfmMain.FormCreate(Sender: TObject);
begin
  FMonitor := TwclPowerEventsMonitor.Create;
  FMonitor.OnPowerStateChanged := PowerStateChanged;
  FMonitor.OnStarted := MonitorStarted;
  FMonitor.OnStopped := MonitorStopped;
end;

procedure TfmMain.FormDestroy(Sender: TObject);
begin
  FMonitor.Free;
end;

procedure TfmMain.btOpenClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FMonitor.Start;
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Start failed: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.btCloseClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FMonitor.Stop;
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Stop failed: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.PowerStateChanged(Sender: TObject;
  const State: TwclPowerState);
begin
  case State of
    psPowerStatusChanged: lbLog.Items.Add('Power status changed');
    psResumeAutomatic: lbLog.Items.Add('Resumed');
    psResume: lbLog.Items.Add('Resumed by user');
    psSuspend: lbLog.Items.Add('Suspended');
    psUnknown: lbLog.Items.Add('Unknonw');
  end;
end;

procedure TfmMain.MonitorStarted(Sender: TObject);
begin
  lbLog.Items.Add('Monitor started');
end;

procedure TfmMain.MonitorStopped(Sender: TObject);
begin
  lbLog.Items.Add('Monitor stopped');
end;

procedure TfmMain.btGetStateClick(Sender: TObject);
var
  Status: TwclPowerStatus;
  Str: string;
begin
  if not FMonitor.GetPowerStatus(Status) then
    lbLog.Items.Add('Get status failed')

  else begin
    case Status.ACLineStatus of
      lsOffline: lbLog.Items.Add('AC: Offline');
      lsOnline: lbLog.Items.Add('AC: Online');
      lsBackup: lbLog.Items.Add('AC: Backup');
      lsUnknown: lbLog.Items.Add('AC: Unknown');
    end;

    Str := '[';
    if csCapacityHigh in Status.BatteryChargeStatus then
      Str := Str + ' csCapacityHigh';
    if csCapacityLow in Status.BatteryChargeStatus then
      Str := Str + ' csCapacityLow';
    if csCapacityCritical in Status.BatteryChargeStatus then
      Str := Str + ' csCapacityCritical';
    if csCharging in Status.BatteryChargeStatus then
      Str := Str + ' csCharging';
    if csNoSystemBattery in Status.BatteryChargeStatus then
      Str := Str + ' csNoSystemBattery';
    Str := Str + ' ]';
    lbLog.Items.Add('Batt: ' + Str);

    lbLog.Items.Add('Batt percent: ' + IntToStr(Status.BatteryLifePercent));

    if Status.BatterySavingState then
      lbLog.Items.Add('Battery saving');

    if Status.BatteryLifeTime <> $FFFFFFFF then
      lbLog.Items.Add('Batt life: ' + IntToStr(Status.BatteryLifeTime));

    if Status.BatteryFullLifeTime <> $FFFFFFFF then
      lbLog.Items.Add('Batt full life: ' + IntToStr(Status.BatteryFullLifeTime));
  end;
end;

end.
