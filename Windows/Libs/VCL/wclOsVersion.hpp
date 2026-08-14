// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclOsVersion.pas' rev: 30.00 (Windows)

#ifndef WclosversionHPP
#define WclosversionHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclosversion
{
//-- forward type declarations -----------------------------------------------
class DELPHICLASS TwclOsVersion;
//-- type declarations -------------------------------------------------------
enum DECLSPEC_DENUM TwclOsType : unsigned int { osUnknown, osMacOS, osWinXP, osWinVista, osWin7, osWin8, osWin81, osWin10, osWin11 };

#pragma pack(push,4)
class PASCALIMPLEMENTATION TwclOsVersion : public System::TObject
{
	typedef System::TObject inherited;
	
private:
	System::Word FBuild;
	System::Word FMajor;
	System::Word FMinor;
	TwclOsType FOsType;
	
public:
	__fastcall TwclOsVersion(void);
	__property System::Word Build = {read=FBuild, nodefault};
	__property System::Word Major = {read=FMajor, nodefault};
	__property System::Word Minor = {read=FMinor, nodefault};
	__property TwclOsType OsType = {read=FOsType, nodefault};
public:
	/* TObject.Destroy */ inline __fastcall virtual ~TwclOsVersion(void) { }
	
};

#pragma pack(pop)

//-- var, const, procedure ---------------------------------------------------
extern DELPHI_PACKAGE TwclOsVersion* wclOsVer;
}	/* namespace Wclosversion */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLOSVERSION)
using namespace Wclosversion;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclosversionHPP
