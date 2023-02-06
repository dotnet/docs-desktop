---
title: "SaveToHistory Function - WPF unmanaged API reference"
titleSuffix: ""
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
description: Learn about the SaveToHistory function.
dev_langs: 
  - "cpp"
api_name: 
  - "SaveToHistory"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: 6dd101a3-44ad-4143-b228-772156f9b8ff
---
# SaveToHistory Function (WPF Unmanaged API Reference)

This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for windows management.  
  
## Syntax  
  
```cpp  
HRESULT SaveToHistory(  
   __in_ecount(1) IStream* pHistoryStream  
)  
```  
  
## Parameters  

 pHistoryStream  
 A pointer to the history stream.  
  
## Requirements  

 **Platforms:** See [.NET Framework System Requirements](/dotnet/framework/get-started/system-requirements).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** Available since 3.0  
  
## See also

- [WPF Unmanaged API Reference](wpf-unmanaged-api-reference.md)
