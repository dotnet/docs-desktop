---
title: "How to: Draw Text to a Control's Background"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "controls [WPF], drawing text to backgrounds"
  - "text [WPF], drawing to control backgrounds"
  - "drawing [WPF], text to control backgrounds"
  - "backgrounds [WPF], drawing text to"
  - "typography [WPF], drawing text to control backgrounds"
ms.assetid: 686d8fba-f61c-4974-a871-c635d67a7f69
---
# How to: Draw Text to a Control's Background
You can draw text directly to the background of a control by converting a text string to a <xref:System.Windows.Media.FormattedText> object, and then drawing the object to the control's <xref:System.Windows.Media.DrawingContext>. You can also use this technique for drawing to the background of objects derived from <xref:System.Windows.Controls.Panel>, such as <xref:System.Windows.Controls.Canvas> and <xref:System.Windows.Controls.StackPanel>.  
  
 ![Screenshot of controls displaying text as background.](./media/how-to-draw-text-to-a-control-background/draw-text-background.png "DrawText2Background01")  
Example of controls with custom text backgrounds  
  
## Example  
 To draw to the background of a control, create a new <xref:System.Windows.Media.DrawingBrush> object and draw the converted text to the object's <xref:System.Windows.Media.DrawingContext>. Then, assign the new <xref:System.Windows.Media.DrawingBrush> to the control's background property.  
  
 The following code example shows how to create a <xref:System.Windows.Media.FormattedText> object and draw to the background of a <xref:System.Windows.Controls.Label> and <xref:System.Windows.Controls.Button> object.  
  
 [!code-csharp[DrawTextToControlBackground#DrawTextToControlBackground1](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawTextToControlBackground/CSHARP/Window1.xaml.cs#drawtexttocontrolbackground1)]  
  
## See also

- <xref:System.Windows.Media.FormattedText>
- [Drawing Formatted Text](drawing-formatted-text.md)
