---
title: "How to: Apply a Drawing to a 3D Model"
description: Learn how to use a DrawingBrush as the Material applied to a 3D model in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
ms.service: dotnet-framework
helpviewer_keywords:
  - "drawings [WPF], applying to 3D models"
  - "3D models [WPF], applying drawings to"
ms.assetid: 68357577-b7fc-446e-8be9-a8cc7df3a350
---
# How to: Apply a Drawing to a 3D Model

This example shows how to use a <xref:System.Windows.Media.DrawingBrush> as the <xref:System.Windows.Media.Media3D.Material> applied to a 3D model.

The following code defines a <xref:System.Windows.Media.DrawingGroup> as the content of a <xref:System.Windows.Media.DrawingBrush>.  The <xref:System.Windows.Media.DrawingBrush> is set as the <xref:System.Windows.Media.Media3D.DiffuseMaterial.Brush%2A> property of the <xref:System.Windows.Media.Media3D.DiffuseMaterial> applied to a 3D plane.

> [!NOTE]
> It is often desirable to define complex objects and values like the drawing below as resources which can be reused and simplify your code. See [XAML Resources](../systems/xaml-resources-overview.md) for more information.

[!code-xaml[3DGallery_snip#ApplyDrawingToMaterialInline1](~/samples/snippets/csharp/VS_Snippets_Wpf/3DGallery_snip/CS/ApplyDrawingToMaterialExample.xaml#applydrawingtomaterialinline1)]

## Example

The following code shows the entire sample.

[!code-xaml[3DGallery_snip#ApplyDrawingToMaterialExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/3DGallery_snip/CS/ApplyDrawingToMaterialExample.xaml#applydrawingtomaterialexamplewholepage)]

## See also

- [XAML Resources](../systems/xaml-resources-overview.md)
- [Create a 3D Scene](how-to-create-a-3-d-scene.md)
- [Drawing Objects Overview](drawing-objects-overview.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
