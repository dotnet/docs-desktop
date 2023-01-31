---
title: "How to: Create a Quadratic Bezier Curve"
description: Learn how to create a quadratic Bezier curve using the PathGeometry, the PathFigure, and the QuadraticBezierSegment classes.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Bezier curves [WPF], creating"
  - "quadratic Bezier curves [WPF], creating"
  - "graphics [WPF], quadratic Bezier curves"
ms.assetid: cd8fca4a-504e-4fd8-92ea-2969065a6e02
---
# How to: Create a Quadratic Bezier Curve

This example shows how to create a quadratic Bezier curve.  To create a quadratic Bezier curve, use the <xref:System.Windows.Media.PathGeometry>, <xref:System.Windows.Media.PathFigure>, and <xref:System.Windows.Media.QuadraticBezierSegment> classes.  
  
## Example  

 In the following examples, a quadratic Bezier curve is drawn from (10,100) to (300,100). The curve has a control point of (200,200).  

 In Extensible Application Markup Language (XAML), you can use attribute syntax to describe a path.  
  
 [!code-xaml[GeometrySample#54](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/geometryattributesyntaxexample.xaml#54)]  

 (Note that this attribute syntax actually creates a <xref:System.Windows.Media.StreamGeometry>, a lighter-weight version of a <xref:System.Windows.Media.PathGeometry>. For more information, see the [Path Markup Syntax](path-markup-syntax.md) page.)  
  
 In XAML, you may also draw a quadratic Bezier curve using object element syntax. The following is equivalent to the previous XAML example.  
  
 [!code-xaml[GeometrySample#34](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/pathgeometryexample.xaml#34)]  
  
 This example is part of larger sample; for the complete sample, see the [Geometries Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/Geometry).  
  
## See also

- [Create an Elliptical Arc](how-to-create-an-elliptical-arc.md)
- [Create a Cubic Bezier Curve](how-to-create-a-cubic-bezier-curve.md)
