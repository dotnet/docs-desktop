---
title: "LoadFromHistory Function - WPF unmanaged API reference"
description: Learn about the LoadFromHistory function and how it works with unmanaged API Reference in Windows Presentation Foundation (WPF).
titleSuffix: ""
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "LoadFromHistory"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: d037c062-a911-4949-b251-ccd3e48b1d17
---
# LoadFromHistory Function (WPF Unmanaged API Reference)

This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for windows management.  
  
## Syntax  
  
```cpp  
HRESULT LoadFromHistory_export(  
        IStream* pHistoryStream,
        IBindCtx* pBindCtx  
)  
```  
  
## Parameters  

 pHistoryStream  
 A pointer to a stream of history information.  
  
 pBindCtx  
 A pointer to a bind context.  
  
## Requirements  

 **Platforms:** See [.NET Framework System Requirements](/dotnet/framework/get-started/system-requirements).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** Available since 3.0  
  
## See also

- [WPF Unmanaged API Reference](wpf-unmanaged-api-reference.md)
