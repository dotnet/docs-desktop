---
title: "How to: Create a Cubic Bezier Curve"
description: Learn how to create a cubic Bezier curve using the PathGeometry, PathFigure, and BezierSegment classes.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "curves [WPF], cubic Bezier"
  - "Bezier curves [WPF], cubic"
  - "graphics [WPF], cubic Bezier curves"
  - "cubic Bezier curves [WPF]"
ms.assetid: 450a3a77-7c57-48b0-a008-0f6051add980
---
# How to: Create a Cubic Bezier Curve

This example shows how to create a cubic Bezier curve. To create a cubic Bezier curve, use the <xref:System.Windows.Media.PathGeometry>, <xref:System.Windows.Media.PathFigure>, and <xref:System.Windows.Media.BezierSegment> classes.  To display the resulting geometry, use a <xref:System.Windows.Shapes.Path> element, or use it with a <xref:System.Windows.Media.GeometryDrawing> or a <xref:System.Windows.Media.DrawingContext>. In the following examples, a cubic Bezier curve is drawn from (10, 100) to (300, 100). The curve has control points of (100, 0) and (200, 200).  
  
## Example  

 In Extensible Application Markup Language (XAML), you may use abbreviated markup syntax to describe a path.  
  
 [!code-xaml[GeometrySample#53](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/geometryattributesyntaxexample.xaml#53)]
  
 In XAML, you can also draw a cubic Bezier curve using object tags. The following is equivalent to the previous XAML example.  
  
 [!code-xaml[GeometrySample#33](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/pathgeometryexample.xaml#33)]  
  
 This example is part of larger sample; for the complete sample, see the [Geometries Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/Geometry).  
  
## See also

- [Create an Elliptical Arc](how-to-create-an-elliptical-arc.md)
- [Create a LineSegment in a PathGeometry](how-to-create-a-linesegment-in-a-pathgeometry.md)
- [Create a Cubic Bezier Curve](how-to-create-a-cubic-bezier-curve.md)
- [Create a Quadratic Bezier Curve](how-to-create-a-quadratic-bezier-curve.md)
