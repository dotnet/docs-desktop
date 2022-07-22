---
title: "IWpfHostSupport"
description: Learn about IWpfHostSupport. Win32 applications such as Web browsers can host WPF content, including XAML browser applications (XBAPs) and loose XAML.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "IWpfHostSupport interface [WPF]"
ms.assetid: cc5a0281-de81-4cc1-87e4-0e46b1a811e9
---
# IWpfHostSupport

Applications that host Windows Presentation Foundation (WPF) content via PresentationHost.exe implement this interface to provide a point of integration between the host and PresentationHost.exe.  
  
## Remarks  

 Win32 applications such as Web browsers can host WPF content, including XAML browser applications (XBAPs) and loose XAML. To host WPF content, Win32 applications create an instance of the [WebBrowser control](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa752040(v=vs.85)). To be hosted, WPF creates an instance of PresentationHost.exe, which provides the hosted WPF content to the host for display in the [WebBrowser control](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa752040(v=vs.85)).  
  
 The integration enabled by `IWpfHostSupport` allows PresentationHost.exe to:  
  
- Discover and register with the raw input devices (Human Interface Devices) that the host application is interested in.  
  
- Receive input messages from the registered raw input devices and forward appropriate messages to the host application.  
  
- Query the host application for custom progress and error user interfaces.  
  
> [!NOTE]
> This API is only intended and supported for use on the local client machine  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|[GetRawInputDevices](getrawinputdevices.md)|Allows PresentationHost.exe to discover the raw input devices (Human Interface Devices) that the host application is interested in.|  
|[FilterInputMessage](filterinputmessage.md)|Called by PresentationHost.exe whenever a message is received unless E_NOTIMPL is returned.|  
|[GetCustomUI](getcustomui.md)|By default, PresentationHost.exe provides its own deployment progress and deployment error user interfaces that are displayed when WPF content is deployed.|
