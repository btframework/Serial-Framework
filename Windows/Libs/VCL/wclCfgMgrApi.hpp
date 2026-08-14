// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclCfgMgrApi.pas' rev: 30.00 (Windows)

#ifndef WclcfgmgrapiHPP
#define WclcfgmgrapiHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <Winapi.Windows.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclcfgmgrapi
{
//-- forward type declarations -----------------------------------------------
//-- type declarations -------------------------------------------------------
typedef unsigned CONFIGRET;

typedef unsigned *PDEVINST;

typedef unsigned DEVINST;

typedef System::WideChar * DEVINSTID;

//-- var, const, procedure ---------------------------------------------------
static const System::Int8 CR_SUCCESS = System::Int8(0x0);
static const System::Int8 CM_LOCATE_DEVNODE_PHANTOM = System::Int8(0x1);
static const System::Int8 CM_DISABLE_UI_NOT_OK = System::Int8(0x4);
static const System::Int8 CM_DISABLE_PERSIST = System::Int8(0x8);
static const System::Int8 CM_PROB_DISABLED = System::Int8(0x16);
static const System::Word DN_HAS_PROBLEM = System::Word(0x400);
static const System::Word DN_PRIVATE_PROBLEM = System::Word(0x8000);
extern "C" unsigned __stdcall CM_Get_DevNode_Status(PULONG pulStatus, PULONG pulProblemNumber, unsigned dnDevInst, unsigned ulFlags);
extern "C" unsigned __stdcall CM_Disable_DevNode(unsigned dnDevInst, unsigned ulFlags);
extern "C" unsigned __stdcall CM_Enable_DevNode(unsigned dnDevInst, unsigned ulFlags);
extern "C" unsigned __stdcall CM_Locate_DevNode(PDEVINST pdnDevInst, System::WideChar * pDeviceID, unsigned ulFlags);
}	/* namespace Wclcfgmgrapi */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLCFGMGRAPI)
using namespace Wclcfgmgrapi;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclcfgmgrapiHPP
