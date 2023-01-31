---
title: "How to: Hit Test Using a Win32 Host Container"
description: Learn how to set up mouse event handlers for a Win32 window that is used as a host container for visual objects to execute a hit test.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "hit tests [WPF], using Win32 host containers"
  - "visual objects [WPF], hit tests on"
  - "Win32 host containers [WPF], hit tests using"
ms.assetid: 9491f7f3-d8ba-4573-a888-2f064d1349dc
---
# How to: Hit Test Using a Win32 Host Container

You can create visual objects within a Win32 window by providing a host window container for the visual objects. To provide event handling for the contained visual objects you process the messages passed to the host window container’s message filter loop. Refer to [Tutorial: Hosting Visual Objects in a Win32 Application](tutorial-hosting-visual-objects-in-a-win32-application.md) for more information on how to host visual objects in a Win32 window.  
  
## Example  

 The following code shows how to set up mouse event handlers for a Win32 window that is used as a host container for visual objects.  
  
 [!code-csharp[VisualsHitTesting#103](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyWindow.cs#103)]
 [!code-vb[VisualsHitTesting#103](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyWindow.vb#103)]  
  
 The following example shows how to set up a hit test in response to trapping specific mouse events.  
  
 [!code-csharp[VisualsHitTesting#104](~/samples/snippets/csharp/VS_Snippets_Wpf/VisualsHitTesting/CSharp/MyCircle.cs#104)]
 [!code-vb[VisualsHitTesting#104](~/samples/snippets/visualbasic/VS_Snippets_Wpf/VisualsHitTesting/VisualBasic/MyCircle.vb#104)]  
  
 The <xref:System.Windows.Interop.HwndSource> object presents Windows Presentation Foundation (WPF) content within a Win32 window. The value of the <xref:System.Windows.Interop.HwndSource.RootVisual%2A> property of the <xref:System.Windows.Interop.HwndSource> object represents the top-most node in the visual tree hierarchy.  
  
 For the complete sample on hit testing objects using a Win32 host container, see [Hit Test with Win32 Interoperation Sample](https://github.com/microsoft/WPF-Samples/tree/master/Visual%20Layer/VisualsHitTesting).  
  
## See also

- <xref:System.Windows.Interop.HwndSource>
- [Hit Testing in the Visual Layer](hit-testing-in-the-visual-layer.md)
- [Tutorial: Hosting Visual Objects in a Win32 Application](tutorial-hosting-visual-objects-in-a-win32-application.md)
