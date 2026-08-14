unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls;

type

  { TfmMain }

  TfmMain = class(TForm)
    btGetDetails: TButton;
    edError: TEdit;
    edPath: TEdit;
    laDescr: TLabel;
    laPath: TLabel;
    lbErrorInfo: TListBox;
    procedure btGetDetailsClick(Sender: TObject);
  private

  public

  end;

var
  fmMain: TfmMain;

implementation

uses
  wclErrors;

{$R *.lfm}

{ TfmMain }

procedure TfmMain.btGetDetailsClick(Sender: TObject);
var
  Info: TwclErrorInformation;
  Err: Integer;
  Details: TwclErrorDetails;
begin
  if edError.Text = '' then
    ShowMessage('Enter error code.')

  else begin
    Err := StrToInt(edError.Text);

    lbErrorInfo.Items.Clear;

    Info := TwclErrorInformation.Create;
    if not Info.Open(edPath.Text) then
      ShowMessage('Open errors definition file failed')
    else begin
      if not Info.GetDetails(Err, Details) then
        ShowMessage('Unable to get error details')
      else begin
        lbErrorInfo.Items.Add('Error code: 0x' + IntToHex(Details.Error, 8));
        lbErrorInfo.Items.Add('Framework: ' + Details.Framework);
        lbErrorInfo.Items.Add('Category: ' + Details.Category);
        lbErrorInfo.Items.Add('Constant name: ' + Details.Constant);
        lbErrorInfo.Items.Add(Details.Description);
      end;
      Info.Close;
    end;
    Info.Free;
  end;
end;

end.

