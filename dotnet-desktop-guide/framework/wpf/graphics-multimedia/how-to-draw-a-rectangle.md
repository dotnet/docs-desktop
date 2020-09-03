---
title: "How to: Draw a Rectangle"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "drawing [WPF], rectangles"
  - "graphics [WPF], rectangles"
  - "rectangles [WPF], drawing"
ms.assetid: beeb57ef-fab5-4446-a38a-1588f97b4c2f
---
# How to: Draw a Rectangle
This example shows how to draw a rectangle by using the <xref:System.Windows.Shapes.Rectangle> element.  
  
 To draw a rectangle, create a <xref:System.Windows.Shapes.Rectangle> element and specify its <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A>. To paint the inside of the rectangle, set its <xref:System.Windows.Shapes.Shape.Fill%2A>. To give the rectangle an outline, use its <xref:System.Windows.Shapes.Shape.Stroke%2A> and <xref:System.Windows.Shapes.Shape.StrokeThickness%2A> properties.  
  
 To give the rectangle rounded corners, specify the optional <xref:System.Windows.Shapes.Rectangle.RadiusX%2A> and <xref:System.Windows.Shapes.Rectangle.RadiusY%2A> properties. The <xref:System.Windows.Shapes.Rectangle.RadiusX%2A> and <xref:System.Windows.Shapes.Rectangle.RadiusY%2A> properties set the x-axis and y-axis radii of the ellipse that is used to round the corners of the rectangle.  
  
 In the following example, two <xref:System.Windows.Shapes.Rectangle> elements are drawn in a <xref:System.Windows.Controls.Canvas>. The first rectangle has a <xref:System.Windows.Media.Brushes.Blue%2A> interior. The second rectangle has a <xref:System.Windows.Media.Brushes.Blue%2A> interior, a <xref:System.Windows.Media.Brushes.Black%2A> outline, and rounded corners.  
  
## Example  
 [!code-xaml[drawingwithshapeelements#Rectangle1](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingWithShapeElements/CS/rectangleexample.xaml#rectangle1)]  
  
 Although this example uses a <xref:System.Windows.Controls.Canvas> to contain the rectangles, you can use rectangle elements (and all the other shape elements) with any <xref:System.Windows.Controls.Panel> or <xref:System.Windows.Controls.Control> that supports non-text content. In fact, rectangles are particularly useful for providing backgrounds for portions of <xref:System.Windows.Controls.Grid> panels. For an example, see the [Table Overview](../advanced/table-overview.md).  
  
 This example is part of a larger sample; for the complete sample, see [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements).  
  
## See also

- <xref:System.Windows.Shapes.Rectangle>
- [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements)
- [Shapes and Basic Drawing in WPF Overview](shapes-and-basic-drawing-in-wpf-overview.md)
- [Table Overview](../advanced/table-overview.md)
