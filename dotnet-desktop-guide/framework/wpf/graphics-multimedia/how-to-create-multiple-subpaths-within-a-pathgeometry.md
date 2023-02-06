---
title: "How to: Create Multiple Subpaths Within a PathGeometry"
description: Learn how to create multiple subpaths in a PathGeometry, you must create a PathFigure for each subpath.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "multiple subpaths [WPF]"
  - "graphics [WPF], subpaths"
  - "subpaths [WPF]"
ms.assetid: 104a862c-dde2-4e62-ac87-80660dd1681c
---
# How to: Create Multiple Subpaths Within a PathGeometry

This example shows how to create multiple subpaths in a <xref:System.Windows.Media.PathGeometry>. To create multiple subpaths, you create a <xref:System.Windows.Media.PathFigure> for each subpath.  
  
## Example  

 The following example creates two subpaths, each one a triangle.  
  
 [!code-xaml[GeometrySample#38](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/pathgeometryexample.xaml#38)]  
  
 The following example shows how to create multiple subpaths by using a <xref:System.Windows.Shapes.Path> and XAML attribute syntax. Each `M` creates a new subpath so that the example creates two subpaths that each draw a triangle.  
  
 [!code-xaml[GeometrySample#58](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/geometryattributesyntaxexample.xaml#58)]  
  
 (Note that this attribute syntax actually creates a <xref:System.Windows.Media.StreamGeometry>, a lighter-weight version of a <xref:System.Windows.Media.PathGeometry>. For more information, see the [Path Markup Syntax](path-markup-syntax.md) page.)  
  
## See also

- [Geometry Overview](geometry-overview.md)
