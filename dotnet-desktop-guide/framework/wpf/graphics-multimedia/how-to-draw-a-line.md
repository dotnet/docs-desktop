---
title: "How to: Draw a Line"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "drawing [WPF], lines"
  - "graphics [WPF], lines"
  - "lines [WPF], drawing"
ms.assetid: 0513ee01-6b27-4bb3-85f3-3a3e6710d80e
---
# How to: Draw a Line
This example shows you how to draw lines by using the <xref:System.Windows.Shapes.Line> element.  
  
 To draw a line, create a <xref:System.Windows.Shapes.Line> element. Use its <xref:System.Windows.Shapes.Line.X1%2A> and <xref:System.Windows.Shapes.Line.Y1%2A> properties to set its start point; and use its <xref:System.Windows.Shapes.Line.X2%2A> and <xref:System.Windows.Shapes.Line.Y2%2A> properties to set its end point. Finally, set its <xref:System.Windows.Shapes.Shape.Stroke%2A> and <xref:System.Windows.Shapes.Shape.StrokeThickness%2A> because a line without a stroke is invisible.  
  
 Setting the <xref:System.Windows.Shapes.Shape.Fill%2A> element for a line has no effect, because a line has no interior.  
  
 The following example draws three lines inside a <xref:System.Windows.Controls.Canvas> element.  
  
## Example  
 [!code-xaml[drawingwithshapeelements#LineExample1](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingWithShapeElements/CS/lineexample.xaml#lineexample1)]  
  
 This example is part of a larger sample; for the complete sample, see [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements).  
  
## See also

- <xref:System.Windows.Shapes.Line>
- [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements)
