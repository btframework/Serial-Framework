unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls, ComCtrls,
  wclSerialDevices;

type

  { TfmMain }

  TfmMain = class(TForm)
    btClear: TButton;
    btDisable: TButton;
    btEnable: TButton;
    btEnumSerial: TButton;
    btStart: TButton;
    btStop: TButton;
    btEnumUSB: TButton;
    lbLog: TListBox;
    lvDevices: TListView;
    procedure btClearClick(Sender: TObject);
    procedure btDisableClick(Sender: TObject);
    procedure btEnableClick(Sender: TObject);
    procedure btEnumSerialClick(Sender: TObject);
    procedure btEnumUSBClick(Sender: TObject);
    procedure btStartClick(Sender: TObject);
    procedure btStopClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);

  private
    FMonitor: TwclSerialMonitor;

    procedure MonitorStarted(Sender: TObject);
    procedure MonitorStopped(Sender: TObject);
    procedure SerialDeviceAdded(Sender: TObject; const DeviceName: string);
    procedure SerialDeviceRemoved(Sender: TObject; const DeviceName: string);
    procedure UsbDeviceAdded(Sender: TObject; const Instance: string);
    procedure UsbDeviceRemoved(Sender: TObject; const Instance: string);

    procedure SwitchUsbDevice(const Enable: Boolean);
  end;

var
  fmMain: TfmMain;

implementation

uses
  wclErrors;

{$R *.lfm}

{ TfmMain }

procedure TfmMain.FormCreate(Sender: TObject);
begin
  FMonitor := TwclSerialMonitor.Create;
  FMonitor.OnStarted := @MonitorStarted;
  FMonitor.OnStopped := @MonitorStopped;
  FMonitor.OnSerialDeviceAdded := @SerialDeviceAdded;
  FMonitor.OnSerialDeviceRemoved := @SerialDeviceRemoved;
  FMonitor.OnUsbDeviceAdded := @UsbDeviceAdded;
  FMonitor.OnUsbDeviceRemoved := @UsbDeviceRemoved;
end;

procedure TfmMain.btClearClick(Sender: TObject);
begin
  lbLog.Items.Clear;
end;

procedure TfmMain.btDisableClick(Sender: TObject);
begin
  SwitchUsbDevice(False);
end;

procedure TfmMain.btEnableClick(Sender: TObject);
begin
  SwitchUsbDevice(True);
end;

procedure TfmMain.btEnumSerialClick(Sender: TObject);
var
  Column: TListColumn;
  Res: Integer;
  Devices: TwclSerialDevices;
  i: Integer;
  Item: TListItem;
begin
  lvDevices.Items.Clear;
  lvDevices.Columns.Clear;

  Column := lvDevices.Columns.Add;
  Column.Caption := 'Device name';
  Column.Width := 80;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'Friendly name';
  Column.Width := 350;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'IsModem';
  Column.Width := 70;

  Res := FMonitor.EnumSerialDevices(Devices);
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Enum serial devices failed: 0x' + IntToHex(Res, 8))

  else begin
    if Length(Devices) = 0 then
      lbLog.Items.Add('No serial devices found')

    else begin
      lbLog.Items.Add('Found ' + IntToStr(Length(Devices)) + ' serial devices');
      for i := 0 to Length(Devices) - 1 do begin
        Item := lvDevices.Items.Add;
        Item.Caption := Devices[i].DeviceName;
        Item.SubItems.Add(Devices[i].FriendlyName);
        Item.SubItems.Add(BoolToStr(Devices[i].IsModem, True));
      end;
    end;
  end;
end;

procedure TfmMain.btEnumUSBClick(Sender: TObject);
var
  Column: TListColumn;
  Res: Integer;
  Devices: TwclUsbDevices;
  i: Integer;
  Item: TListItem;
begin
  lvDevices.Items.Clear;
  lvDevices.Columns.Clear;

  Column := lvDevices.Columns.Add;
  Column.Caption := 'Instance';
  Column.Width := 250;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'Friendly name';
  Column.Width := 250;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'VID';
  Column.Width := 50;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'PID';
  Column.Width := 50;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'Class';
  Column.Width := 250;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'Manufacturer';
  Column.Width := 200;
  Column := lvDevices.Columns.Add;
  Column.Caption := 'Enabled';
  Column.Width := 70;

  Res := FMonitor.EnumUsbDevices(Devices);
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Enum USB devices failed: 0x' + IntToHex(Res, 8))

  else begin
    if Length(Devices) = 0 then
      lbLog.Items.Add('No USB devices found')

    else begin
      lbLog.Items.Add('Found ' + IntToStr(Length(Devices)) + ' USB devices');
      for i := 0 to Length(Devices) - 1 do begin
        Item := lvDevices.Items.Add;
        Item.Caption := Devices[i].Instance;
        Item.SubItems.Add(Devices[i].FriendlyName);
        Item.SubItems.Add(IntToHex(Devices[i].VendorId, 4));
        Item.SubItems.Add(IntToHex(Devices[i].ProductId, 4));
        Item.SubItems.Add(GUIDToString(Devices[i].ClassGuid));
        Item.SubItems.Add(Devices[i].Manufacturer);
        Item.SubItems.Add(BoolToStr(Devices[i].Enabled, True));
      end;
    end;
  end;
end;

procedure TfmMain.btStartClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FMonitor.Start;
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Start failed: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.btStopClick(Sender: TObject);
var
  Res: Integer;
begin
  Res := FMonitor.Stop;
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Stop failed: 0x' + IntToHex(Res, 8));
end;

procedure TfmMain.FormDestroy(Sender: TObject);
begin
  FMonitor.Free;
end;

procedure TfmMain.MonitorStarted(Sender: TObject);
begin
  lbLog.Items.Add('Monitor started');
end;

procedure TfmMain.MonitorStopped(Sender: TObject);
begin
  lbLog.Items.Add('Monitor stopped');
end;

procedure TfmMain.SerialDeviceAdded(Sender: TObject; const DeviceName: string);
begin
  lbLog.Items.Add('Device added: ' + DeviceName);
end;

procedure TfmMain.SerialDeviceRemoved(Sender: TObject;
  const DeviceName: string);
begin
  lbLog.Items.Add('Device removed: ' + DeviceName);
end;

procedure TfmMain.UsbDeviceAdded(Sender: TObject; const Instance: string);
begin
  lbLog.Items.Add('Device added: ' + Instance);
end;

procedure TfmMain.UsbDeviceRemoved(Sender: TObject; const Instance: string);
begin
  lbLog.Items.Add('Device removed: ' + Instance);
end;

procedure TfmMain.SwitchUsbDevice(const Enable: Boolean);
var
  Instance: string;
  Res: Integer;
begin
  if lvDevices.Columns.Count < 7 then
    ShowMessage('Enumerate USB devices')

  else begin
    if lvDevices.Items.Count = 0 then
      ShowMessage('No USB devices found')

    else begin
      if lvDevices.Selected = nil then
        ShowMessage('Select USB device')

      else begin
        Instance := lvDevices.Selected.Caption;
        if Enable then
          Res := FMonitor.EnableUsbDevice(Instance)
        else
          Res := FMonitor.DisableUsbDevice(Instance);
        if Res <> WCL_E_SUCCESS then begin
          if Enable then
            ShowMessage('Error enabling USB: 0x' + IntToHex(Res, 8))
          else
            ShowMessage('Error disabling USB: 0x' + IntToHex(Res, 8));
        end else begin
          if Enable then
            ShowMessage('Device enabled')
          else
            ShowMessage('Device disabled');
        end;
      end;
    end;
  end;
end;

end.

