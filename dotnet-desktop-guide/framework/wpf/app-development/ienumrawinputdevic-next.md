---
title: "IEnumRAWINPUTDEVIC:Next"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Next method [WPF]"
ms.assetid: 3698b44d-510e-4d18-b32b-85f17188ee26
---
# IEnumRAWINPUTDEVIC:Next
Enumerates the next `celt` [RAWINPUTDEVICE](/windows/desktop/api/winuser/ns-winuser-rawinputdevice) structures in the enumerator's list, returning them in `rgelt` along with the actual number of enumerated elements in `pceltFetched`.  
  
## Syntax  
  
```cpp  
HRESULT Next(  
      [in] ULONG celt,  
      [out, size_is(celt), length_is(*pceltFetched)] RAWINPUTDEVICE *rgelt,  
      [out] ULONG *pceltFetched);  
```  
  
## Parameters  
 `celt`  
  
 [in] Number of [RAWINPUTDEVICE](/windows/desktop/api/winuser/ns-winuser-rawinputdevice) structures returned in `rgelt`.  
  
 `rgelt`  
  
 [out] Array of size celt (or larger) to receive enumerated RAWINPUTDEVICE structures.  
  
 `pceltFetched`  
  
 [out] Pointer to the number of elements actually supplied in `rgelt`. Caller can pass in `NULL` if `rgelt` is one.  
  
## Property Value/Return Value  
 HRESULT: S_OK if the number of elements supplied is `celt`; S_FALSE otherwise.
