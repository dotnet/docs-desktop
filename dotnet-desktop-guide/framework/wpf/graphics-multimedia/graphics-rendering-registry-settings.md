---
title: "Graphics Rendering Registry Settings"
description: Find out how to use registry settings for troubleshooting, debugging, and product support purposes in the Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
helpviewer_keywords: 
  - "rendering graphics [WPF], registry settings"
  - "rendering graphics [WPF]"
  - "rendering graphics [WPF], troubleshooting"
  - "troubleshooting graphics rendering [WPF]"
  - "graphics [WPF], rendering"
ms.assetid: f4b41b42-327d-407c-b398-3ed5f505df8b
---
# Graphics Rendering Registry Settings

This topic provides an overview of the WPF graphics rendering registry settings that affect WPF applications.  

<a name="overview"></a>

## When to Use Graphics Rendering Registry Settings  

 These registry settings are provided for troubleshooting, debugging, and product support purposes. Because changes to the registry affect all WPF applications, your application should never alter these registry keys automatically, or during installation.  
  
<a name="xpdmandwddm"></a>

## What are XPDM and WDDM?  

 Some of the graphics rendering registry settings have different default values, depending on whether your video card uses an XPDM or WDDM driver. XPDM is the Microsoft Windows XP Display Driver Model and WDDM is the Windows Display Driver Model. WDDM is available on computers running Windows Vista and Windows 7. XPDM is available on computers running Windows Vista, Microsoft Windows XP, and Microsoft Windows Server 2003. For more information about WDDM, see [Windows Display Driver Model (WDDM) Design Guide](/windows-hardware/drivers/display/windows-vista-display-driver-model-design-guide).  
  
<a name="registry_settings"></a>

## Registry Settings  

 WPF provides four registry settings for controlling WPF rendering:  
  
|Setting|Description|  
|-------------|-----------------|  
|**Disable Hardware Acceleration Option**|Specifies whether hardware acceleration should be enabled.|  
|**Maximum Multisample Value**|Specifies the degree of multisampling for antialiasing 3D content.|  
|**Required Video Driver Date Setting**|Specifies whether the system disables hardware acceleration for drivers released before November 2004.|  
|**Use Reference Rasterizer Option**|Specifies whether WPF should use the reference rasterizer.|  
  
 These settings can be accessed by any external configuration utility that knows how to reference the WPF registry settings. These settings can also be created or modified by accessing the values directly by using the Windows Registry Editor.  
  
<a name="disablehardwareacceleration"></a>

## Disable Hardware Acceleration Option  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\DisableHWAcceleration`|DWORD|  
  
 The **disable hardware acceleration option** enables you to turn off hardware acceleration for debugging and test purposes. When you see rendering artifacts in an application, try turning off hardware acceleration. If the artifact disappears, the problem might be with your video driver.  
  
 The **disable hardware acceleration option** is a DWORD value that is either 0 or 1. A value of 1 disables hardware acceleration. A value of 0 enables hardware acceleration, provided the system meets hardware acceleration requirements; for more information, see [Graphics Rendering Tiers](../advanced/graphics-rendering-tiers.md).  
  
<a name="maxmultisample"></a>

## Maximum Multisample Value  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\MaxMultisampleType`|DWORD|  
  
 The **maximum multisample value** enables you to adjust the maximum amount of antialiasing of 3D content. Use this level to disable 3D antialiasing in Windows Vista.  
  
 The **maximum multisample value** is a DWORD value that ranges from 0 to 16. A value of 0 specifies that multisample antialiasing of 3D content should be disabled, and a value of 16 will attempt to use up to 16x multisample antialiasing, if supported by the video card. Beware that setting this registry key value on computers using XPDM drivers will cause applications to use a large amount of additional video memory, decrease the performance of 3D rendering, and has the potential to introduce rendering errors and stability problems.  
  
 When this registry key is not set, WPF defaults to 0 for XPDM drivers and 4 for WDDM drivers.  
  
<a name="requiredvideodriverdatesetting"></a>

## Required Video Driver Date Setting  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\RequiredVideoDriverDate`|String|  
  
 In November, 2004, Microsoft released a new version of the driver testing guidelines; the drivers written after this date offer better stability. By default, WPF will use the hardware acceleration pipeline for these drivers and will fall back to software rendering for XPDM drivers published before this date.  
  
 The **required video driver date setting** enables you to specify an alternate minimum date for XPDM drivers. You should only specify a date earlier than November, 2004 if you are confident that your video driver is stable enough to support WPF.  
  
 The required video driver setting takes a string of the following format:  
  
| String format |  
|---------------|  
|*YYYY* `/` *MM* `/` *DD*|  
  
 Where *YYYY* is the four-digit year, *MM* is the two-digit month, and *DD* is the two digit day. When this value is unset, WPF uses November, 2004 as its required video driver date.  
  
<a name="usereferencerasterizeroption"></a>

## Use Reference Rasterizer Option  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\UseReferenceRasterizer`|DWORD|  
  
 The **use reference rasterizer option** enables you to force WPF into a simulated hardware rendering mode for debugging: WPF goes into hardware mode, but uses the Microsoft Direct3D reference software rasterizer, d3dref9.dll, instead of an actual hardware device.  
  
 The reference rasterizer is very slow, but bypasses your video driver to avoid any rendering issues caused by driver problems. For this reason, you can use the reference rasterizer to determine if rendering issues are caused by the video driver. The d3dref9.dll file must be in a location where the application can access it, such as in any location in the system path or in the local directory of the application.  
  
 The **use reference rasterizer option** takes a DWORD value. A value of 0 indicates that the reference rasterizer is not used. Any other non-zero value forces WPF to use the reference rasterizer.  
  
## See also

- [Graphics Rendering Tiers](../advanced/graphics-rendering-tiers.md)
- [WPF Graphics Rendering Overview](wpf-graphics-rendering-overview.md)
