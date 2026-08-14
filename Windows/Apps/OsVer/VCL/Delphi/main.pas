unit main;

interface

uses
  Forms, Classes, Controls, StdCtrls;

type
  TfmMain = class(TForm)
    laOsVersion: TLabel;
    procedure FormCreate(Sender: TObject);
  end;

var
  fmMain: TfmMain;

implementation

uses
  wclOsVersion, SysUtils;

{$R *.dfm}

procedure TfmMain.FormCreate(Sender: TObject);
var
  Str: string;
begin
  case wclOsVer.OsType of
    osUnknown: Str := 'OS unknown';
    osMacOS: Str := 'Mac OS';
    osWinXP: Str := 'Windows XP';
    osWinVista: Str := 'Windows Vista';
    osWin7: Str := 'Windows 7';
    osWin8: Str := 'Windows 8';
    osWin81: Str := 'Windows 8.1';
    osWin10: Str := 'Windows 10';
    osWin11: Str := 'Windows 11';
    else Str := 'Undefined OS';
  end;

  Str := Str + ' ' + IntToStr(wclOsVer.Major) + '.' +
    IntToStr(wclOsVer.Minor) + '.' + IntToStr(wclOsVer.Build);
  laOsVersion.Caption := Str;
end;

end.
