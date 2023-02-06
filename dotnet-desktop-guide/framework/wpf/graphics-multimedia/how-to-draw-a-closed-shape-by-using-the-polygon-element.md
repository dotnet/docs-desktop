---
title: "How to: Draw a Closed Shape by Using the Polygon Element"
description: Learn how to draw a closed shape by creating a Polygon element and using its Points property to specify the vertices of a shape.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "graphics [WPF], Polygon elements"
  - "closed shapes [WPF], drawing with Polygon elements"
  - "Polygon elements [WPF]"
  - "drawing [WPF], closed shapes with Polygon elements"
ms.assetid: 4b0ca008-29ce-48dd-8bc3-f3a20ffca6a6
---
# How to: Draw a Closed Shape by Using the Polygon Element

This example shows how to draw a closed shape by using the <xref:System.Windows.Shapes.Polygon> element. To draw a closed shape, create a <xref:System.Windows.Shapes.Polygon> element and use its <xref:System.Windows.Shapes.Polygon.Points%2A> property to specify the vertices of a shape. A line is automatically drawn that connects the first and last points. Finally, specify a <xref:System.Windows.Shapes.Shape.Fill%2A>, a <xref:System.Windows.Shapes.Shape.Stroke%2A>, or both.  
  
## Example  

 In Extensible Application Markup Language (XAML), valid syntax for points is a space-delimited list of comma-separated x- and y-coordinate pairs.  
  
 [!code-xaml[drawingwithshapeelements#PolygonExample1](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingWithShapeElements/CS/polygonexample.xaml#polygonexample1)]  
  
 Although the example uses a <xref:System.Windows.Controls.Canvas> to contain the polygons, you can use polygon elements (and all the other shape elements) with any <xref:System.Windows.Controls.Panel> or <xref:System.Windows.Controls.Control> that supports non-text content.  
  
 This example is part of a larger sample; for the complete sample, see [Shape Elements Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/ShapeElements).
