---
title: "Tutorial: Hosting Visual Objects in a Win32 Application"
description: Learn to write a sample application that hosts Windows Presentation Foundation (WPF) visual objects in a Win32 window.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "visual objects in Win32 code [WPF]"
  - "Win32 code [WPF], visual objects in"
  - "hosting [WPF], visual objects in Win32 code"
ms.assetid: f0e1600c-3217-43d5-875d-1864fa7fe628
---
# Tutorial: Hosting Visual Objects in a Win32 Application

WPF functionality to your application rather than rewrite your code. To provide support for Win32 and WPF graphics subsystems used concurrently in an application, WPF provides a mechanism for hosting objects in a Win32 window.  
  
 This tutorial describes how to write a sample application, [Hit Test with Win32 Interoperation Sample](https://github.com/microsoft/WPF-Samples/tree/master/Visual%20Layer/VisualsHitTesting), that hosts WPF visual objects in a Win32 window.  

<a name="requirements"></a>

## Requirements  

 This tutorial assumes a basic familiarity with both WPF and Win32 programming. For a basic introduction to WPF programming, see [Walkthrough: My first WPF desktop application](../getting-started/walkthrough-my-first-wpf-desktop-application.md). For an introduction to Win32 programming, see any of the numerous books on the subject, in particular *Programming Windows* by Charles Petzold.  
  
> [!NOTE]
> This tutorial includes a number of code examples from the associated sample. However, for readability, it does not include the complete sample code. For the complete sample code, see [Hit Test with Win32 Interoperation Sample](https://github.com/microsoft/WPF-Samples/tree/master/Visual%20Layer/VisualsHitTesting).  
  
<a name="creating_the_host_win32_window"></a>

## Creating the Host Win32 Window  

 The key to hosting WPF objects in a Win32 window is the <xref:System.Windows.Interop.HwndSource> class. This class wraps the WPF objects in a Win32 window, allowing them to be incorporated into your user interface (UI) as a child window.  
  
 The following example shows the code for creating the <xref:System.Windows.Interop.HwndSource> object as the Win32 container window for the visual objects. To set the window style, position, and other parameters for the Win32 window, use the <xref:System.Windows.Interop.HwndSourceParameters> object.  
  
 [!code-csharp[VisualsHitTesting#101](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyWindow.cs#101)]
 [!code-vb[VisualsHitTesting#101](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyWindow.vb#101)]  
  
> [!NOTE]
> The value of the <xref:System.Windows.Interop.HwndSourceParameters.ExtendedWindowStyle%2A> property cannot be set to WS_EX_TRANSPARENT. This means that the host Win32 window cannot be transparent. For this reason, the background color of the host Win32 window is set to the same background color as its parent window.  
  
<a name="adding_visual_objects_to_the_host_win32_window"></a>

## Adding Visual Objects to the Host Win32 Window  

 Once you have created a host Win32 container window for the visual objects, you can add visual objects to it. You will want to ensure that any transformations of the visual objects, such as animations, do not extend beyond the bounds of the host Win32 window's bounding rectangle.  
  
 The following example shows the code for creating the <xref:System.Windows.Interop.HwndSource> object and adding visual objects to it.  
  
> [!NOTE]
> The <xref:System.Windows.Interop.HwndSource.RootVisual%2A> property of the <xref:System.Windows.Interop.HwndSource> object is set to the first visual object added to the host Win32 window. The root visual object defines the top-most node of the visual object tree. Any subsequent visual objects added to the host Win32 window are added as child objects.  
  
 [!code-csharp[VisualsHitTesting#100](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyWindow.cs#100)]
 [!code-vb[VisualsHitTesting#100](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyWindow.vb#100)]  
  
<a name="implementing_the_win32_message_filter"></a>

## Implementing the Win32 Message Filter  

 The host Win32 window for the visual objects requires a window message filter procedure to handle messages that are sent to the window from the application queue. The window procedure receives messages from the Win32 system. These may be input messages or window-management messages. You can optionally handle a message in your window procedure or pass the message to the system for default processing.  
  
 The <xref:System.Windows.Interop.HwndSource> object that you defined as the parent for the visual objects must reference the window message filter procedure you provide. When you create the <xref:System.Windows.Interop.HwndSource> object, set the <xref:System.Windows.Interop.HwndSourceParameters.HwndSourceHook%2A> property to reference the window procedure.  
  
 [!code-csharp[VisualsHitTesting#102](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyWindow.cs#102)]
 [!code-vb[VisualsHitTesting#102](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyWindow.vb#102)]  
  
 The following example shows the code for handling the left and right mouse button up messages. The coordinate value of the mouse hit position is contained in the value of the `lParam` parameter.  
  
 [!code-csharp[VisualsHitTesting#103](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyWindow.cs#103)]
 [!code-vb[VisualsHitTesting#103](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyWindow.vb#103)]  
  
<a name="processing_the_win32_messages"></a>

## Processing the Win32 Messages  

 The code in the following example shows how a hit test is performed against the hierarchy of visual objects contained in the host Win32 window. You can identify whether a point is within the geometry of a visual object, by using the <xref:System.Windows.Media.VisualTreeHelper.HitTest%2A> method to specify the root visual object and the coordinate value to hit test against. In this case, the root visual object is the value of the <xref:System.Windows.Interop.HwndSource.RootVisual%2A> property of the <xref:System.Windows.Interop.HwndSource> object.  
  
 [!code-csharp[VisualsHitTesting#104](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyCircle.cs#104)]
 [!code-vb[VisualsHitTesting#104](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyCircle.vb#104)]  
  
 For more information on hit testing against visual objects, see [Hit Testing in the Visual Layer](hit-testing-in-the-visual-layer.md).  
  
## See also

- <xref:System.Windows.Interop.HwndSource>
- [Hit Test with Win32 Interoperation Sample](https://github.com/microsoft/WPF-Samples/tree/master/Visual%20Layer/VisualsHitTesting)
- [Hit Testing in the Visual Layer](hit-testing-in-the-visual-layer.md)
