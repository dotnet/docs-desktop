---
title: "ProcessUnhandledException Function - WPF unmanaged API reference"
description: Learn how to use the ProcessUnhandledException function, which is used by the Windows Presentation Foundation (WPF) infrastructure for exception handling.
titleSuffix: ""
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ProcessUnhandledException"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: 495ce5f6-bb4d-4b30-807a-c3c35f1ca95c
---
# ProcessUnhandledException Function (WPF Unmanaged API Reference)

This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for exception handling.  
  
## Syntax  
  
```cpp  
void __stdcall ProcessUnhandledException(  
   __in_ecount(1) BSTR errorMsg  
)  
```  
  
## Parameters  

 errorMsg  
 The error message.  
  
## Requirements  

 **Platforms:** See [.NET Framework System Requirements](/dotnet/framework/get-started/system-requirements).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** Available since 3.0  
  
## See also

- [WPF Unmanaged API Reference](wpf-unmanaged-api-reference.md)
