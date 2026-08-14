// CodeGear C++Builder
// Copyright (c) 1995, 2015 by Embarcadero Technologies, Inc.
// All rights reserved

// (DO NOT EDIT: machine generated header) 'wclCryptoApi.pas' rev: 30.00 (Windows)

#ifndef WclcryptoapiHPP
#define WclcryptoapiHPP

#pragma delphiheader begin
#pragma option push
#pragma option -w-      // All warnings off
#pragma option -Vx      // Zero-length empty class member 
#pragma pack(push,8)
#include <System.hpp>
#include <SysInit.hpp>
#include <wclWinApi.hpp>
#include <Winapi.Windows.hpp>

//-- user supplied -----------------------------------------------------------

namespace Wclcryptoapi
{
//-- forward type declarations -----------------------------------------------
//-- type declarations -------------------------------------------------------
typedef NativeUInt *PHCRYPTPROV;

typedef NativeUInt HCRYPTPROV;

typedef NativeUInt *PHCRYPTKEY;

typedef NativeUInt HCRYPTKEY;

typedef NativeUInt *PHCRYPTHASH;

typedef NativeUInt HCRYPTHASH;

typedef unsigned ALG_ID;

//-- var, const, procedure ---------------------------------------------------
static const System::Int8 PROV_RSA_AES = System::Int8(0x18);
static const unsigned CRYPT_VERIFYCONTEXT = unsigned(0xf0000000);
static const System::Word ALG_CLASS_HASH = System::Word(0x8000);
static const System::Int8 ALG_TYPE_ANY = System::Int8(0x0);
static const System::Int8 ALG_SID_SHA_256 = System::Int8(0xc);
static const System::Word CALG_SHA_256 = System::Word(0x800c);
static const System::Int8 HP_HASHVAL = System::Int8(0x2);
static const System::Word MAX_HASH = System::Word(0x104);
extern "C" System::LongBool __stdcall CryptAcquireContext(PHCRYPTPROV phProv, System::WideChar * szContainer, System::WideChar * szProvider, unsigned dwProvType, unsigned dwFlags);
extern "C" System::LongBool __stdcall CryptCreateHash(NativeUInt hProv, unsigned Algid, NativeUInt hKey, unsigned dwFlags, PHCRYPTHASH phHash);
extern "C" System::LongBool __stdcall CryptHashData(NativeUInt hHash, System::PByte pbData, unsigned dwDataLen, unsigned dwFlags);
extern "C" System::LongBool __stdcall CryptGetHashParam(NativeUInt hHash, unsigned dwParam, System::PByte pbData, unsigned* pdwDataLen, unsigned dwFlags);
extern "C" System::LongBool __stdcall CryptDestroyHash(NativeUInt hHash);
extern "C" System::LongBool __stdcall CryptReleaseContext(NativeUInt hProv, unsigned dwFlags);
}	/* namespace Wclcryptoapi */
#if !defined(DELPHIHEADER_NO_IMPLICIT_NAMESPACE_USE) && !defined(NO_USING_NAMESPACE_WCLCRYPTOAPI)
using namespace Wclcryptoapi;
#endif
#pragma pack(pop)
#pragma option pop

#pragma delphiheader end.
//-- end unit ----------------------------------------------------------------
#endif	// WclcryptoapiHPP
