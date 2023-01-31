---
title: "How to: Bind an Adorner to an Element"
description: Learn how to bind an adorner to a UIElement by a 2-step method and following the included code examples in C# and Visual Basic.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "UIElements [WPF], binding adorners to"
  - "adorners [WPF], binding to specified UIElements"
ms.assetid: b2101611-a0ee-4137-bdb8-9b3673d2e6b9
---
# How to: Bind an Adorner to an Element

This example shows how to programmatically bind an adorner to a specified <xref:System.Windows.UIElement>.  
  
## Example  

 To bind an adorner to a particular <xref:System.Windows.UIElement>, follow these steps:  
  
1. Call the `static` method <xref:System.Windows.Documents.AdornerLayer.GetAdornerLayer%2A> to get an <xref:System.Windows.Documents.AdornerLayer> object for the <xref:System.Windows.UIElement> to be adorned. <xref:System.Windows.Documents.AdornerLayer.GetAdornerLayer%2A> walks up the visual tree, starting at the specified **UIElement**, and returns the first adorner layer it finds. (If no adorner layers are found, the method returns null.)  
  
2. Call the <xref:System.Windows.Documents.AdornerLayer.Add%2A> method to bind the adorner to the target **UIElement**.  
  
 The following example binds a SimpleCircleAdorner (shown above) to a <xref:System.Windows.Controls.TextBox> named *myTextBox*.  
  
 [!code-csharp[Adorners_SimpleCircleAdorner#_AdornSingleElement](~/samples/snippets/csharp/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/CSharp/Window1.xaml.cs#_adornsingleelement)]
 [!code-vb[Adorners_SimpleCircleAdorner#_AdornSingleElement](~/samples/snippets/visualbasic/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/VisualBasic/Window1.xaml.vb#_adornsingleelement)]  
  
> [!NOTE]
> Using Extensible Application Markup Language (XAML) to bind an adorner to another element is currently not supported.  
  
## See also

- [Adorners Overview](adorners-overview.md)
