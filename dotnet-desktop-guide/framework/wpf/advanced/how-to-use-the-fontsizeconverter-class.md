---
title: "How to: Use the FontSizeConverter Class"
description: Learn how to create an instance of the FontSizeConverter class and discover how to use it to change font sizes.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "FontSizeConverter objects [WPF]"
  - "typography [WPF], FontSizeConverter objects"
ms.assetid: 3b0592bd-7223-4860-a108-a5d72f3a9178
---
# How to: Use the FontSizeConverter Class

## Example  

 This example shows how to create an instance of <xref:System.Windows.FontSizeConverter> and use it to change a font size.  
  
 The example defines a custom method called `changeSize` that converts the contents of a <xref:System.Windows.Controls.ListBoxItem>, as defined in a separate Extensible Application Markup Language (XAML) file, to an instance of <xref:System.Double>, and later into a <xref:System.String>. This method passes the <xref:System.Windows.Controls.ListBoxItem> to a <xref:System.Windows.FontSizeConverter> object, which converts the <xref:System.Windows.Controls.ContentControl.Content%2A> of a <xref:System.Windows.Controls.ListBoxItem> to an instance of <xref:System.Double>. This value is then passed back as the value of the <xref:System.Windows.Controls.TextBlock.FontSize%2A> property of the <xref:System.Windows.Controls.TextBlock> element.  
  
 This example also defines a second custom method that is called `changeFamily`. This method converts the <xref:System.Windows.Controls.ContentControl.Content%2A> of the <xref:System.Windows.Controls.ListBoxItem> to a <xref:System.String>, and then passes that value to the <xref:System.Windows.Controls.TextBlock.FontFamily%2A> property of the <xref:System.Windows.Controls.TextBlock> element.  
  
 This example does not run.  
  
 [!code-csharp[FontSizeConverter#1](~/samples/snippets/csharp/VS_Snippets_Wpf/FontSizeConverter/CSharp/Window1.xaml.cs#1)]  
  
## See also

- <xref:System.Windows.FontSizeConverter>
