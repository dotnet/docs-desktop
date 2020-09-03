---
title: "FilterInputMessage"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "raw input [WPF]"
  - "FilterInputMessage method [WPF]"
ms.assetid: 4d74c6cf-7d1d-49ff-96c1-231340ce54f5
---
# FilterInputMessage
Called by PresentationHost.exe whenever a message is received unless E_NOTIMPL is returned.  
  
## Syntax  
  
```cpp  
HRESULT FilterInputMessage( [in] MSG* pMsg ) ;  
```  
  
## Parameters  
 `pMsg`  
  
 [in] The WM_INPUT message sent to the window that is getting raw input.  
  
## Property Value/Return Value  
 HRESULT:  
  
 S_OK - The filter did not process the message and further processing may occur.  
  
 S_FALSE - The filter processed this message and no further processing should occur.  
  
 E_NOTIMPL – If this value is returned, [FilterInputMessage](filterinputmessage.md) is not called again. This might be returned from a host application that is only interested in providing custom progress and error user interfaces to PresentationHost.exe is not interested in being forwarded raw input messages from PresentationHost.exe.  
  
## Remarks  
 PresentationHost.exe is the target of various raw input devices, including keyboard, mice, and remote controls. Sometimes, behavior in the host application is dependent on input that would otherwise be consumed by PresentationHost.exe. For example, a host application may depend on receiving certain input messages to determine whether or not to display specific user interface elements.  
  
 To allow the host application to receive the necessary input messages to provide these behaviors, PresentationHost.exe forwards appropriate raw input messages to the hosted application by calling [FilterInputMessage](filterinputmessage.md).  
  
 The hosted application receives raw input messages by registering with the set of raw input devices (Human Interface Devices) returned by [GetRawInputDevices](getrawinputdevices.md).  
  
## See also

- [WM_INPUT message](/windows/desktop/inputdev/wm-input)
