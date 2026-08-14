// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclLafApi.pas' rev: 30.00 (Windows)

#ifndef WcllafapiHPP
#define WcllafapiHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <wclWinRtApi.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wcllafapi
{
//-- forward type declarations -----------------------------------------------
__interface ILimitedAccessFeatureRequestResult;
typedef System::DelphiInterface<ILimitedAccessFeatureRequestResult> _di_ILimitedAccessFeatureRequestResult;
__interface ILimitedAccessFeaturesStatics;
typedef System::DelphiInterface<ILimitedAccessFeaturesStatics> _di_ILimitedAccessFeaturesStatics;
//-- type declarations -------------------------------------------------------
enum DECLSPEC_DENUM LimitedAccessFeatureStatus : unsigned int { LimitedAccessFeatureStatus_Unavailable, LimitedAccessFeatureStatus_Available, LimitedAccessFeatureStatus_AvailableWithoutToken, LimitedAccessFeatureStatus_Unknown };

__interface  INTERFACE_UUID("{D45156A6-1E24-5DDD-ABB4-6188ABA4D5BF}") ILimitedAccessFeatureRequestResult  : public Wclwinrtapi::IInspectable 
{
	virtual HRESULT __stdcall get_FeatureId(/* out */ void * &value) = 0 ;
	virtual HRESULT __stdcall get_Status(/* out */ LimitedAccessFeatureStatus &value) = 0 ;
	virtual HRESULT __stdcall get_EstimatedRemovalDate(/* out */ Wclwinrtapi::_di_IDateTimeReference &value) = 0 ;
};

__interface  INTERFACE_UUID("{8BE612D4-302B-5FBF-A632-1A99E43E8925}") ILimitedAccessFeaturesStatics  : public Wclwinrtapi::IInspectable 
{
	virtual HRESULT __stdcall TryUnlockFeature(void * featureId, void * token, void * attestation, /* out */ _di_ILimitedAccessFeatureRequestResult &result) = 0 ;
};

//-- var, const, procedure ---------------------------------------------------
#define LimitedAccessFeaturesName L"Windows.ApplicationModel.LimitedAccessFeatures"
}	/* namespace Wcllafapi */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLLAFAPI)
using namespace Wcllafapi;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WcllafapiHPP
