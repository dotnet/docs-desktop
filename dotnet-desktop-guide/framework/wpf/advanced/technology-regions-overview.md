---
title: "Technology Regions Overview"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "window regions [WPF]"
  - "Win32 code [WPF], WPF interoperation"
  - "Win32 code [WPF], airspace"
  - "airspace [WPF]"
  - "interoperability [WPF], airspace"
  - "Win32 code [WPF], window regions"
ms.assetid: b7cc350f-b9e2-48b1-be14-60f3d853222e
description: Learn about the issues that might influence the presentation and input for your WPF interoperation application.
---
# Technology Regions Overview

If multiple presentation technologies are used in an application, such as WPF, Win32, or DirectX, they must share the rendering areas within a common top-level window. This topic describes issues that might influence the presentation and input for your WPF interoperation application.  
  
## Regions  

 Within a top-level window, you can conceptualize that each HWND that comprises one of the technologies of an interoperation application has its own region (also called "airspace"). Each pixel within the window belongs to exactly one HWND, which constitutes the region of that HWND. (Strictly speaking, there is more than one WPF region if there is more than one WPF HWND, but for purposes of this discussion, you can assume there is only one). The region implies that all layers or other windows that attempt to render above that pixel during application lifetime must be part of the same render-level technology. Attempting to render WPF pixels over Win32 leads to undesirable results, and is disallowed as much as possible through the interoperation APIs.  
  
### Region Examples  

 The following illustration shows an application that mixes Win32, DirectX, and WPF. Each technology uses its own separate, non-overlapping set of pixels, and there are no region issues.  
  
 ![An example of an application that mixes Win32, DirectX, and WPF.](./media/technology-regions-overview/win32-directx-windows-presentation-foundation-application.png)  
  
 Suppose that this application uses the mouse pointer position to create an animation that attempts to render over any of these three regions. No matter which technology was responsible for the animation itself, that technology would violate the region of the other two. The following illustration shows an attempt to render a WPF circle over a Win32 region.  
  
 ![An attempt to render a WPF circle over a Win32 region.](./media/technology-regions-overview/render-windows-presentation-foundation-circle-over-win32-region.png)  
  
 Another violation is if you try to use transparency/alpha blending between different technologies.  In the following illustration, the WPF box violates the Win32 and DirectX regions. Because pixels in that WPF box are semi-transparent, they would have to be owned jointly by both DirectX and WPF, which is not possible.  So this is another violation and cannot be built.  
  
 ![Diagram showing a WPF box violating the Win32 and DirectX regions.](./media/technology-regions-overview/windows-foundation-presentation-box-violate-win32-directx-region.png)  
  
 The previous three examples used rectangular regions, but different shapes are possible.  For example, a region can have a hole. The following illustration shows a Win32 region with a rectangular hole this is the size of the WPF and DirectX regions combined.  
  
 ![Diagram that shows a Win32 region with a rectangular hole.](./media/technology-regions-overview/win32-region-rectangular-hole.png)  
  
 Regions can also be completely nonrectangular, or any shape describable by a Win32 HRGN (region).  
  
 ![Diagram that shows a nonrectangular region.](./media/technology-regions-overview/nonrectangular-win32-region.png)  
  
## Transparency and Top-Level Windows  

 The window manager in Windows only really processes Win32 HWNDs. Therefore, every WPF <xref:System.Windows.Window> is an HWND. The <xref:System.Windows.Window> HWND must abide by the general rules for any HWND. Within that HWND, WPF code can do whatever the overall WPF APIs support. But for interactions with other HWNDs on the desktop, WPF must abide by Win32 processing and rendering rules.  WPF supports non-rectangular windows by using Win32 APIs—HRGNs for non-rectangular windows, and layered windows for a per-pixel alpha.  
  
 Constant alpha and color keys are not supported.  Win32 layered window capabilities vary by platform.  
  
 Layered windows can make the entire window translucent (semi-transparent) by specifying an alpha value to apply to every pixel in the window.  (Win32 in fact supports per-pixel alpha, but this is very difficult to use in practical programs because in this mode you would need to draw any child HWND yourself, including dialogs and dropdowns).  
  
 WPF supports HRGNs; however, there are no managed APIs for this functionality. You can use platform invoke and <xref:System.Windows.Interop.HwndSource> to call the relevant Win32 APIs. For more information, see [Calling Native Functions from Managed Code](/cpp/dotnet/calling-native-functions-from-managed-code).  
  
 WPF layered windows have different capabilities on different operating systems. This is because WPF uses DirectX to render, and layered windows were primarily designed for GDI rendering, not DirectX rendering.  
  
- WPF supports hardware accelerated layered windows.  
  
- WPF does not support transparency color keys, because WPF cannot guarantee to render the exact color you requested, particularly when rendering is hardware-accelerated.  
  
## See also

- [WPF and Win32 Interoperation](wpf-and-win32-interoperation.md)
- [Walkthrough: Hosting a WPF Clock in Win32](walkthrough-hosting-a-wpf-clock-in-win32.md)
- [Hosting Win32 Content in WPF](hosting-win32-content-in-wpf.md)
