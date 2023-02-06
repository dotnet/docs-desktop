---
title: "How to: Use the Content-Scrolling Methods of ScrollViewer"
description: Learn how to use the content-scrolling methods of a ScrollViewer element in a Windows Presentation Foundation (WPF) application.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "IScrollInfo interface [WPF]"
  - "scrolling methods [WPF]"
  - "ScrollViewer control [WPF], scrolling methods"
ms.assetid: 4708cc65-6510-45f8-82e6-30b0d3e30045
---
# How to: Use the Content-Scrolling Methods of ScrollViewer

This example shows how to use the scrolling methods of the <xref:System.Windows.Controls.ScrollViewer> element. These methods provide incremental scrolling of content, either by line or by page, in a <xref:System.Windows.Controls.ScrollViewer>.  
  
## Example  

 The following example creates a <xref:System.Windows.Controls.ScrollViewer> named `sv1`, which hosts a child <xref:System.Windows.Controls.TextBlock> element. Because the <xref:System.Windows.Controls.TextBlock> is larger than the parent <xref:System.Windows.Controls.ScrollViewer>, scroll bars appear in order to enable scrolling. <xref:System.Windows.Controls.Button> elements that represent the various scrolling methods are docked on the left in a separate <xref:System.Windows.Controls.StackPanel>. Each <xref:System.Windows.Controls.Button> in the XAML file calls a related custom method that controls scrolling behavior in <xref:System.Windows.Controls.ScrollViewer>.  
  
 [!code-xaml[ScrollViewerMethods#1](~/samples/snippets/csharp/VS_Snippets_Wpf/ScrollViewerMethods/CSharp/Window1.xaml#1)]  
  
 The following example uses the <xref:System.Windows.Controls.ScrollViewer.LineUp%2A> and <xref:System.Windows.Controls.ScrollViewer.LineDown%2A> methods.  
  
 [!code-csharp[ScrollViewerMethods#2](~/samples/snippets/csharp/VS_Snippets_Wpf/ScrollViewerMethods/CSharp/Window1.xaml.cs#2)]
 [!code-vb[ScrollViewerMethods#2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ScrollViewerMethods/VisualBasic/Window1.xaml.vb#2)]  
  
## See also

- <xref:System.Windows.Controls.ScrollViewer>
- <xref:System.Windows.Controls.StackPanel>
