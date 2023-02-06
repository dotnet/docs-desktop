---
title: "How to: Create and Use a GridLengthConverter Object"
description: Learn how to create and use a GridLengthConverter object, by means of the included code example in C# and Visual Basic.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Grid control [WPF], creating [WPF], GridLengthConverter objects"
ms.assetid: 5ab75911-e36a-4825-80e4-081c57e8e182
---
# How to: Create and Use a GridLengthConverter Object

## Example  

 The following example shows how to create and use an instance of <xref:System.Windows.GridLengthConverter>. The example defines a custom method called `changeCol`, which passes the <xref:System.Windows.Controls.ListBoxItem> to a <xref:System.Windows.GridLengthConverter> that converts the <xref:System.Windows.Controls.ContentControl.Content%2A> of a <xref:System.Windows.Controls.ListBoxItem> to an instance of <xref:System.Windows.GridLength>. The converted value is then passed back as the value of the <xref:System.Windows.Controls.ColumnDefinition.Width%2A> property of the <xref:System.Windows.Controls.ColumnDefinition> element.  
  
 The example also defines a second custom method, called `changeColVal`. This custom method converts the <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> of a <xref:System.Windows.Controls.Slider> to a <xref:System.String> and then passes that value back to the <xref:System.Windows.Controls.ColumnDefinition> as the <xref:System.Windows.Controls.ColumnDefinition.Width%2A> of the element.  
  
 Note that a separate Extensible Application Markup Language (XAML) file defines the contents of a <xref:System.Windows.Controls.ListBoxItem>.  
  
 [!code-csharp[gridlengthConverterGrid#1](~/samples/snippets/csharp/VS_Snippets_Wpf/gridlengthConverterGrid/CSharp/Window1.xaml.cs#1)]
 [!code-vb[gridlengthConverterGrid#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/gridlengthConverterGrid/VisualBasic/Window1.xaml.vb#1)]  
  
## See also

- <xref:System.Windows.GridLengthConverter>
- <xref:System.Windows.GridLength>
