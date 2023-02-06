---
title: "How to: Scroll Content by Using the IScrollInfo Interface"
description: Learn how to scroll content by using the IScrollInfo interface in a Windows Presentation Foundation (WPF) application.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ScrollViewer control [WPF], scrolling content"
  - "scrolling content [WPF]"
  - "IScrollInfo interface [WPF]"
ms.assetid: d8700bef-a3f8-4c12-9de2-fc3b79f32cd3
---
# How to: Scroll Content by Using the IScrollInfo Interface

This example shows how to scroll content by using the <xref:System.Windows.Controls.Primitives.IScrollInfo> interface.  
  
## Example  

 The following example demonstrates the features of the <xref:System.Windows.Controls.Primitives.IScrollInfo> interface. The example creates a <xref:System.Windows.Controls.StackPanel> element in Extensible Application Markup Language (XAML) that is nested in a parent <xref:System.Windows.Controls.ScrollViewer>. The child elements of the <xref:System.Windows.Controls.StackPanel> can be scrolled logically by using the methods defined by the <xref:System.Windows.Controls.Primitives.IScrollInfo> interface and cast to the instance of <xref:System.Windows.Controls.StackPanel> (`sp1`) in code.  
  
 [!code-xaml[IScrollInfoMethods#2](~/samples/snippets/csharp/VS_Snippets_Wpf/IScrollInfoMethods/CSharp/Window1.xaml#2)]  
  
 Each <xref:System.Windows.Controls.Button> in the XAML file triggers an associated custom method that controls scrolling behavior in <xref:System.Windows.Controls.StackPanel>. The following example shows how to use the <xref:System.Windows.Controls.Primitives.IScrollInfo.LineUp%2A> and <xref:System.Windows.Controls.Primitives.IScrollInfo.LineDown%2A> methods; it also generically shows how to use all the positioning methods that the <xref:System.Windows.Controls.Primitives.IScrollInfo> class defines.  
  
 [!code-csharp[IScrollInfoMethods#3](~/samples/snippets/csharp/VS_Snippets_Wpf/IScrollInfoMethods/CSharp/Window1.xaml.cs#3)]
 [!code-vb[IScrollInfoMethods#3](~/samples/snippets/visualbasic/VS_Snippets_Wpf/IScrollInfoMethods/VisualBasic/Window1.xaml.vb#3)]  
  
## See also

- <xref:System.Windows.Controls.ScrollViewer>
- <xref:System.Windows.Controls.Primitives.IScrollInfo>
- <xref:System.Windows.Controls.StackPanel>
- [ScrollViewer Overview](scrollviewer-overview.md)
- [How-to Topics](scrollviewer-how-to-topics.md)
- [Panels Overview](panels-overview.md)
