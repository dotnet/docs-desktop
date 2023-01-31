---
title: "How to: Make an Object Follow the Mouse Pointer"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "following the mouse pointer (cursor)"
  - "mouse pointer (cursor), making objects follow"
  - "cursor (mouse pointer), making objects follow"
ms.assetid: 50b20415-14bc-405c-baf3-2fb254fffde3
description: Learn how to make an object follow the mouse pointer and change the dimensions of an object when the mouse pointer moves on the screen.
---
# How to: Make an Object Follow the Mouse Pointer

This example shows how to change the dimensions of an object when the mouse pointer moves on the screen.  
  
 The example includes an user interface (UI) and a code-behind file that creates the event handler.  
  
## Example  

 The following XAML creates the UI, which consists of an <xref:System.Windows.Shapes.Ellipse> inside of a <xref:System.Windows.Controls.StackPanel>, and attaches the event handler for the <xref:System.Windows.UIElement.MouseMove> event.  
  
 [!code-xaml[mouseMoveWithPointer#MouseMoveWithPointerXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/mouseMoveWithPointer/CSharp/Window1.xaml#mousemovewithpointerxaml)]  
  
 The following code behind creates the <xref:System.Windows.UIElement.MouseMove> event handler.  When the mouse pointer moves, the height and the width of the <xref:System.Windows.Shapes.Ellipse> are increased and decreased.  
  
 [!code-csharp[mouseMoveWithPointer#MouseMovePointerGetPosition](~/samples/snippets/csharp/VS_Snippets_Wpf/mouseMoveWithPointer/CSharp/Window1.xaml.cs#mousemovepointergetposition)]
 [!code-vb[mouseMoveWithPointer#MouseMovePointerGetPosition](~/samples/snippets/visualbasic/VS_Snippets_Wpf/mouseMoveWithPointer/VisualBasic/Window1.xaml.vb#mousemovepointergetposition)]  
  
## See also

- [Input Overview](input-overview.md)
