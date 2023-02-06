---
title: "How to: Draw a Polyline by Using the Polyline Element"
description: Learn how to draw a polyline by creating a Polyline element and using its Points property to specify the shape vertices.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "connected lines [WPF]"
  - "polylines [WPF], drawing"
  - "graphics [WPF], polylines"
  - "lines [WPF], connected (see polylines)"
  - "drawing [WPF], polylines"
ms.assetid: 65db8935-d047-4295-87c4-b427ff3ad293
---
# How to: Draw a Polyline by Using the Polyline Element

This example shows how to draw a polyline, which is a series of connected lines, by using the <xref:System.Windows.Shapes.Polyline> element.  
  
 To draw a polyline, create a <xref:System.Windows.Shapes.Polyline> element and use its <xref:System.Windows.Shapes.Polyline.Points%2A> property to specify the shape vertices. Finally, use the <xref:System.Windows.Shapes.Shape.Stroke%2A> and <xref:System.Windows.Shapes.Shape.StrokeThickness%2A> properties to describe the polyline outline because a line without a stroke is invisible.  
  
> [!NOTE]
> Because the <xref:System.Windows.Shapes.Polyline> element is not a closed shape, the <xref:System.Windows.Shapes.Shape.Fill%2A> property has no effect, even if you deliberately close the shape outline. To create a closed shape with a <xref:System.Windows.Shapes.Shape.Fill%2A>, use a <xref:System.Windows.Shapes.Polygon> element.  
  
 The following example draws two <xref:System.Windows.Shapes.Polyline> elements inside a <xref:System.Windows.Controls.Canvas>.  
  
## Example  

 In Extensible Application Markup Language (XAML), valid syntax for points is a space-delimited list of comma-separated x- and y-coordinate pairs.  
  
 [!code-xaml[drawingwithshapeelements#PolylineExample1](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingWithShapeElements/CS/polylineexample.xaml#polylineexample1)]  
  
 Although this example uses a <xref:System.Windows.Controls.Canvas> to contain the polylines, you can use polyline elements (and all the other shape elements) with any <xref:System.Windows.Controls.Panel> or <xref:System.Windows.Controls.Control> that supports non-text content.  
  
 This example is part of a larger sample; for the complete sample, see [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements).  
  
## See also

- <xref:System.Windows.Shapes.Polyline>
- <xref:System.Windows.Shapes.Polygon>
- <xref:System.Windows.Shapes.Shape>
- [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements)
- [Shapes and Basic Drawing in WPF Overview](shapes-and-basic-drawing-in-wpf-overview.md)
