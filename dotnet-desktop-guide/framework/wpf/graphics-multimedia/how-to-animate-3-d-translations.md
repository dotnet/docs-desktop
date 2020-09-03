---
title: "How to: Animate 3D Translations"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "animation [WPF], 3D translations"
  - "3D translations [WPF], animating"
ms.assetid: d4eece1f-0cd2-4a2c-8370-293354c380e4
---
# How to: Animate 3D Translations
This topic demonstrates how to animate a translation transformation set on a 3D model.  
  
 The code below shows the application of a <xref:System.Windows.Media.Media3D.TranslateTransform3D> object to the <xref:System.Windows.Media.Media3D.Model3D.Transform%2A> property of a <xref:System.Windows.Media.Media3D.GeometryModel3D>.  
  
 [!code-xaml[Animation3DGallery_snip#Translation3DAnimationInline1](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/Translation3DAnimationExample.xaml#translation3danimationinline1)]  
  
 The <xref:System.Windows.Media.Media3D.TranslateTransform3D.OffsetX%2A> property of this <xref:System.Windows.Media.Media3D.TranslateTransform3D> object is animated using the code below.  
  
 [!code-xaml[Animation3DGallery_snip#Translation3DAnimationInline2](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/Translation3DAnimationExample.xaml#translation3danimationinline2)]  
  
## Example  
 The following code shows the entire sample.  
  
 [!code-xaml[Animation3DGallery_snip#Translation3DAnimationExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/Translation3DAnimationExample.xaml#translation3danimationexamplewholepage)]  
  
## See also

- [Animation Overview](animation-overview.md)
- [Create a 3D Scene](how-to-create-a-3-d-scene.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
- [Transforms Overview](transforms-overview.md)
