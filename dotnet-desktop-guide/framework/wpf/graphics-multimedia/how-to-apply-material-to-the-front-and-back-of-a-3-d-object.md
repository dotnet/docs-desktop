---
title: "How to: Apply Material to the Front and Back of a 3D Object"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "3D objects [WPF], applying Material class"
  - "Material class [WPF], applying to both sides of 3D object"
  - "classes [WPF], Material"
ms.assetid: d93c8ad6-4939-4d29-9544-4d16d98093c1
---
# How to: Apply Material to the Front and Back of a 3D Object
The following example shows how to apply a <xref:System.Windows.Media.Media3D.Material> to the front and back of a 3D object and animate the object to show both sides of the object. The <xref:System.Windows.Media.Media3D.GeometryModel3D.Material%2A> property of a <xref:System.Windows.Media.Media3D.GeometryModel3D> is used to apply a red <xref:System.Windows.Media.Brush> to the front side of the object and the <xref:System.Windows.Media.Media3D.GeometryModel3D.BackMaterial%2A> property of the <xref:System.Windows.Media.Media3D.GeometryModel3D> is used to apply a blue <xref:System.Windows.Media.Brush> to the back side of the object. The code below shows the application of the materials to the object:  
  
 [!code-xaml[Animation3DGallery_snip#BackMaterialAnimationExampleInline1](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/BackMaterialAnimationExample.xaml#backmaterialanimationexampleinline1)]  
  
## Example  
 The following code shows the entire sample.  
  
 [!code-xaml[Animation3DGallery_snip#BackMaterialAnimationExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/BackMaterialAnimationExample.xaml#backmaterialanimationexamplewholepage)]  
  
## See also

- [Create a 3D Scene](how-to-create-a-3-d-scene.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
- [Animate Material Properties in a 3D Scene](how-to-animate-material-properties-in-a-3-d-scene.md)
- [Apply Emissive Material to a 3D Object](how-to-apply-emissive-material-to-a-3-d-object.md)
