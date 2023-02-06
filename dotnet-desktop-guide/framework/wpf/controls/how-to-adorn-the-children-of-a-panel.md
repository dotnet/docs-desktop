---
title: "How to: Adorn the Children of a Panel"
description: Learn how to adorn the children of a panel by means of the included code samples in C# and Visual Basic.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "adorners [WPF], binding to children of Panels"
  - "Panel control [WPF], binding adorners to children"
ms.assetid: 4cc9b972-b472-4e5c-bdf3-3702d7fbb1f5
---
# How to: Adorn the Children of a Panel

This example shows how to programmatically bind an adorner to the children of a specified <xref:System.Windows.Controls.Panel>.  
  
## Example  

 To bind an adorner to the children of a <xref:System.Windows.Controls.Panel>, follow these steps:  
  
1. Declare a new <xref:System.Windows.Documents.AdornerLayer> object and call the `static`<xref:System.Windows.Documents.AdornerLayer.GetAdornerLayer%2A> method to find an adorner layer for the element whose children are to be adorned.  
  
2. Enumerate through the children of the parent element and call the <xref:System.Windows.Documents.AdornerLayer.Add%2A> method to bind an adorner to each child element.  
  
 The following example binds a SimpleCircleAdorner (shown above) to the children of a <xref:System.Windows.Controls.StackPanel> named *myStackPanel*.  
  
 [!code-csharp[Adorners_SimpleCircleAdorner#_AdornChildren](~/samples/snippets/csharp/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/CSharp/Window1.xaml.cs#_adornchildren)]
 [!code-vb[Adorners_SimpleCircleAdorner#_AdornChildren](~/samples/snippets/visualbasic/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/VisualBasic/Window1.xaml.vb#_adornchildren)]  
  
> [!NOTE]
> Using Extensible Application Markup Language (XAML) to bind an adorner to another element is currently not supported.  
  
## See also

- [Adorners Overview](adorners-overview.md)
