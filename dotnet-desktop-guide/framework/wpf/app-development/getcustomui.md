---
title: "GetCustomUI"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "custom error messages [WPF]"
ms.assetid: e55180fc-35bb-4f80-a136-772b5eb3e4e5
---
# GetCustomUI
Called by PresentationHost.exe to get custom progress and error messages from the host, if implemented.  
  
## Syntax  
  
```cpp  
HRESULT GetCustomUI( [out] BSTR* pwzProgressAssemblyName, [out] BSTR* pwzProgressClassName, [out] BSTR* pwzErrorAssemblyName, [out] BSTR* pwzErrorClassName );  
```  
  
## Parameters  
 `pwzProgressAssemblyName`  
  
 [out] A pointer to the assembly that contains the host-supplied progress user interface.  
  
 `pwzProgressClassName`  
  
 [out] The name of the class that is the host-supplied progress user interface, preferably a XAML file with <xref:System.Windows.Controls.Page> is its top-level element. This class resides in the assembly that is specified by `pwzProgressAssemblyName`.  
  
 `pwzErrorAssemblyName`  
  
 [out] A pointer to the assembly that contains the host-supplied error user interface.  
  
 `pwzErrorClassName`  
  
 [out] The name of the class that is the host-supplied error user interface, preferably a XAML file with <xref:System.Windows.Controls.Page> is its top-level element. This class resides in the assembly that is specified by `pwzErrorAssemblyName`.  
  
## Property Value/Return Value  
 HRESULT: Ignored.  
  
## Remarks  
 A host application may have a specific theme that PresentationHost.exe’s default user interfaces may not conform to. If this is the case, the host application can implement [GetCustomUI](getcustomui.md) to return progress and error user interfaces to PresentationHost.exe. PresentationHost.exe will always call [GetCustomUI](getcustomui.md) before using its default user interfaces.  
  
 This function is called once during PresentationHost’s initialization.  
  
## See also

- [IWpfHostSupport](iwpfhostsupport.md)
