---
title: "ForwardTranslateAccelerator Function - WPF unmanaged API reference"
description: Learn about the ForwardTranslateAccelerator function of the Windows Presentation Foundation (WPF) unmanaged API reference.
titleSuffix: ""
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ForwardTranslateAccelerator"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: fff47a86-9d9f-4176-9530-10e1876e393f
---
# ForwardTranslateAccelerator Function (WPF Unmanaged API Reference)

This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for windows management.  
  
## Syntax  
  
```cpp  
HRESULT ForwardTranslateAccelerator(  
   MSG* pMsg,
   VARIANT_BOOL appUnhandled  
)  
```  
  
## Parameters  

 pMsg  
 A pointer to a message.  
  
 appUnhandled  
 `true` when the app has already been given a chance to handle the input message, but has not handled it; otherwise, `false`.  
  
## Requirements  

 **Platforms:** See [.NET Framework System Requirements](/dotnet/framework/get-started/system-requirements).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** Available since 3.0  
  
## See also

- [WPF Unmanaged API Reference](wpf-unmanaged-api-reference.md)
