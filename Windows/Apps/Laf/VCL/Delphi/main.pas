unit main;

interface

uses
  Forms, Controls, StdCtrls, Classes, wclLaf;

type
  TfmMain = class(TForm)
    laAvailableLaf: TLabel;
    cbLaf: TComboBox;
    btUnlock: TButton;
    lbLog: TListBox;
    procedure FormCreate(Sender: TObject);
    procedure btUnlockClick(Sender: TObject);
  end;

var
  fmMain: TfmMain;

implementation

uses
  wclErrors, SysUtils;

{$R *.dfm}
{$R lafapp.res}

procedure TfmMain.btUnlockClick(Sender: TObject);
var
  Laf: string;
  Res: Integer;
begin
  if cbLaf.ItemIndex = -1 then
    lbLog.Items.Add('No LAF found')

  else begin
    Laf := cbLaf.Text;
    Res := TwclLafManager.Unlock(Laf);
    if Res <> WCL_E_SUCCESS then
      lbLog.Items.Add('Unlock ' + Laf + ' failed: 0x' + IntToHex(Res, 8))
    else
      lbLog.Items.Add('LAF ' + Laf + ' unlocked');
  end;
end;

procedure TfmMain.FormCreate(Sender: TObject);
var
  Res: Integer;
  Pfn: string;
  AppName: string;
  Publisher: string;
  Laf: TStringList;
  i: Integer;
begin
  Res := TwclLafManager.GetIdentity(Pfn, AppName, Publisher);
  if Res <> WCL_E_SUCCESS then
    lbLog.Items.Add('Get identity failed: 0x' + IntToHex(Res, 8))

  else begin
    lbLog.Items.Add('PFN: ' + Pfn);
    lbLog.Items.Add('AppName: ' + AppName);
    lbLog.Items.Add('Publisher: ' + Publisher);

    Laf := TStringList.Create;

    Res := TwclLafManager.Enum(Laf);
    if Res <> WCL_E_SUCCESS then
      lbLog.Items.Add('Enum LAF failed: 0x' + IntToHex(Res, 8))

    else begin
      if Laf.Count > 0 then begin
        for i := 0 to Laf.Count - 1 do
          cbLaf.Items.Add(Laf[i]);

        cbLaf.ItemIndex := 0;
      end;
    end;
  end;
end;

end.
