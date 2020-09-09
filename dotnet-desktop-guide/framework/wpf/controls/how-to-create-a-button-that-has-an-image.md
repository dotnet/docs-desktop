---
title: "How to: Create a Button That Has an Image"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Button controls [WPF], creating"
ms.assetid: 607a193c-4098-4dd8-8dc0-51256cec2020
---
# How to: Create a Button That Has an Image
This example shows how to include an image on a <xref:System.Windows.Controls.Button>.  
  
## Example  
 The following example creates two <xref:System.Windows.Controls.Button> controls. One <xref:System.Windows.Controls.Button> contains text and the other contains an image. The image is in a folder called data, which is a subfolder of the example’s project folder. When a user clicks the <xref:System.Windows.Controls.Button> that has the image, the background and the text of the other <xref:System.Windows.Controls.Button> change.  
  
 This example creates <xref:System.Windows.Controls.Button> controls by using markup but uses code to write the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handlers.  
  
 [!code-xaml[BtnColor#4](~/samples/snippets/csharp/VS_Snippets_Wpf/BtnColor/CSharp/Pane1.xaml#4)]  
  
 [!code-csharp[BtnColor#6](~/samples/snippets/csharp/VS_Snippets_Wpf/BtnColor/CSharp/Pane1.xaml.cs#6)]
 [!code-vb[BtnColor#6](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BtnColor/VisualBasic/Pane1.xaml.vb#6)]  
  
## See also

- [Controls](index.md)
- [Control Library](control-library.md)
