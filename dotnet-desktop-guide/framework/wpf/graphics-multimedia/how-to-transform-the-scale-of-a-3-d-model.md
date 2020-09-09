---
title: "How to: Transform the Scale of a 3D Model"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "scaling [WPF], 3D objects"
  - "3D objects [WPF], scaling"
ms.assetid: f3fdfe33-f7dc-44b0-84a5-e43b89947f35
---
# How to: Transform the Scale of a 3D Model
This example shows how to scale a 3D object. To scale a 3D object, use a <xref:System.Windows.Media.Media3D.ScaleTransform3D>. The <xref:System.Windows.Media.Media3D.ScaleTransform3D.ScaleX%2A>, <xref:System.Windows.Media.Media3D.ScaleTransform3D.ScaleY%2A>, and <xref:System.Windows.Media.Media3D.ScaleTransform3D.ScaleZ%2A> properties resize the element by the factor you specify. For example, a <xref:System.Windows.Media.Media3D.ScaleTransform3D.ScaleX%2A> value of 1.5 stretches an object to 150 percent of its original width. A <xref:System.Windows.Media.Media3D.ScaleTransform3D.ScaleY%2A> value of 0.5 shrinks the height of an object by 50 percent. The code below shows using a <xref:System.Windows.Media.Media3D.ScaleTransform3D> as the transform for a <xref:System.Windows.Media.Media3D.GeometryModel3D>.  
  
 [!code-xaml[3DGallery_snip#ScaleTransform3DExampleInline1](~/samples/snippets/csharp/VS_Snippets_Wpf/3DGallery_snip/CS/ScaleTransform3DExample.xaml#scaletransform3dexampleinline1)]  
  
## Example  
 The following code shows the entire sample.  
  
 [!code-xaml[3DGallery_snip#ScaleTransform3DExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/3DGallery_snip/CS/ScaleTransform3DExample.xaml#scaletransform3dexamplewholepage)]  
  
## See also

- [Animate 3D Translations](how-to-animate-3-d-translations.md)
- [Create a 3D Scene](how-to-create-a-3-d-scene.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
