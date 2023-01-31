---
title: "How to: Horizontally or Vertically Align Content in a StackPanel"
description: Learn how to adjust content orientation in a Windows Presentation Foundation StackPanel and the HorizontalAlignment and VerticalAlignment of child content.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "StackPanel control [WPF], content alignment [WPF]"
  - "content alignment [WPF]"
  - "aligning [WPF], content"
ms.assetid: c1e8f962-72c8-4e7a-8670-7a2d7e021791
---
# How to: Horizontally or Vertically Align Content in a StackPanel

This example shows how to adjust the <xref:System.Windows.Controls.StackPanel.Orientation%2A> of content within a <xref:System.Windows.Controls.StackPanel> element, and also how to adjust the <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A> and <xref:System.Windows.FrameworkElement.VerticalAlignment%2A> of child content.  
  
## Example  

 The following example creates three <xref:System.Windows.Controls.ListBox> elements in Extensible Application Markup Language (XAML). Each <xref:System.Windows.Controls.ListBox> represents the possible values of the <xref:System.Windows.Controls.StackPanel.Orientation%2A>, <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A>, and <xref:System.Windows.FrameworkElement.VerticalAlignment%2A> properties of a <xref:System.Windows.Controls.StackPanel>. When a user selects a value in any of the <xref:System.Windows.Controls.ListBox> elements, the associated property of the <xref:System.Windows.Controls.StackPanel> and its child <xref:System.Windows.Controls.Button> elements change.  
  
 [!code-xaml[StackPanelIntroSamp#1](~/samples/snippets/csharp/VS_Snippets_Wpf/StackPanelIntroSamp/CSharp/Window1.xaml#1)]  
  
 The following code-behind file defines the changes to the events that are associated with the <xref:System.Windows.Controls.ListBox> selection changes. <xref:System.Windows.Controls.StackPanel> is identified by the <xref:System.Windows.FrameworkElement.Name%2A> `sp1`.  
  
 [!code-csharp[StackPanelIntroSamp#2](~/samples/snippets/csharp/VS_Snippets_Wpf/StackPanelIntroSamp/CSharp/Window1.xaml.cs#2)]
 [!code-vb[StackPanelIntroSamp#2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/StackPanelIntroSamp/VisualBasic/Window1.xaml.vb#2)]  
  
## See also

- <xref:System.Windows.Controls.StackPanel>
- <xref:System.Windows.Controls.ListBox>
- <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A>
- <xref:System.Windows.FrameworkElement.VerticalAlignment%2A>
- [Panels Overview](panels-overview.md)
