---
title: "WPF Host (PresentationHost.exe)"
description: Learn about Windows Presentation Foundation (WPF) Host (PresentationHost.exe), which enables WPF applications to be hosted in compatible browsers.
titleSuffix: ""
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WPF Host application [WPF]"
  - "PresentationHost.exe"
ms.assetid: 3215bfa1-722c-4ac8-a7c5-bdd02d30afbd
---
# WPF Host (PresentationHost.exe)

Windows Presentation Foundation (WPF) Host (PresentationHost.exe) is the application that enables WPF applications to be hosted in compatible browsers (including Microsoft Internet Explorer 6 and later). By default, Windows Presentation Foundation (WPF) Host is registered as the shell and MIME handler for browser-hosted WPF content, which includes:  
  
- Loose (uncompiled) XAML files (.xaml).  
  
- XAML browser application (XBAP) (.xbap).  
  
 For files of these types, Windows Presentation Foundation (WPF) Host:  
  
- Launches the registered HTML handler to host the Windows Presentation Foundation (WPF) content.  
  
- Loads the right versions of the required common language runtime (CLR) and Windows Presentation Foundation (WPF) assemblies.  
  
- Ensures the appropriate permission levels for the zone of deployment are in place.  
  
 This topic describes the command line parameters that can be used with PresentationHost.exe.  
  
## Usage  

 `PresentationHost.exe [parameters] uri|filename`  
  
## Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|filename|The path of the file to be activated. Can also be a URI.|  
|-debug|When activating an application, does not commit it to or run it from the store. This only works when a local file is activated.|  
|-debugSecurityZoneURL \<url>|Used with a URL value to indicate to PresentationHost.exe that an application should be debugged as if it were deployed from the specified URL. This determines both the deployment zone and the site of origin.|  
|-embedding|Required by OLE. If the `-event` or `-debug` parameter are specified, it is not necessary to specify the `-embedding` parameter, since that parameter is set internally.|  
|-event \<eventname>|Open the event with this name and signal it when PresentationHost.exe is initialized and ready to host WPF content. PresentationHost.exe will terminate if there was an error opening the event, such as if it has not already been created.|  
|-launchApplication \<url>|Launches a standalone ClickOnce application from the specified URL. Internet Explorer and WinINet security policy concerning .NET applications are applied.|  
  
## Scenarios  
  
### Shell Handler  

 `PresentationHost.exe example.xbap`  
  
### MIME Handler  

 `PresentationHost.exe -embedding example.xbap`  
  
### Visual Studio Debugging  

 `PresentationHost.exe -debug example.xbap`  
  
### Visual Studio Debugging In Zone  

 `PresentationHost.exe -debug -debugSecurityZoneURL http://www.example.com c:\folderpath\example.xbap`  
  
## See also

- [Security](../security-wpf.md)
