---
title: "How to: Round the Corners of a RectangleGeometry"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "corners [WPF], rounding"
  - "RectangleGeometry class [WPF], rounding corners"
  - "graphics [WPF], rounding corners of RectangleGeometry objects [WPF]"
  - "rounding corners of RectangleGeometry objects [WPF]"
ms.assetid: 926644bc-1357-4c0b-ac81-694bd090ae87
---
# How to: Round the Corners of a RectangleGeometry
To round the corners of a <xref:System.Windows.Media.RectangleGeometry>, set its <xref:System.Windows.Media.RectangleGeometry.RadiusX%2A> and <xref:System.Windows.Media.RectangleGeometry.RadiusY%2A> properties to a value greater than zero. The larger the values, the rounder the rectangle's corners.  
  
## Example  
 The following example shows several <xref:System.Windows.Media.RectangleGeometry> objects with different <xref:System.Windows.Media.RectangleGeometry.RadiusX%2A> and <xref:System.Windows.Media.RectangleGeometry.RadiusY%2A> settings. The <xref:System.Windows.Media.RectangleGeometry> objects are displayed using <xref:System.Windows.Shapes.Path> elements.  
  
 [!code-xaml[GeometryOverviewSamples_snip#GraphicsMMRoundedRectangleGeometryExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometryOverviewSamples_snip/CS/RectangleGeometryRoundedCornerExample.xaml#graphicsmmroundedrectanglegeometryexamplewholepage)]  
  
 ![Rectangles with different RadiusX&#47;RadiusY settings](./media/graphicsmm-rounded.png "graphicsmm_rounded")  
Rectangles with Rounded Corners  
  
## See also

- [Geometry Overview](geometry-overview.md)
- [Create a Composite Shape](how-to-create-a-composite-shape.md)
- [Create a Shape by Using a PathGeometry](how-to-create-a-shape-by-using-a-pathgeometry.md)
