---
title: "How to: Create a 3D Scene"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "scenes [WPF], 3D"
  - "3D scenes"
ms.assetid: adb4a598-71a2-4dd5-b677-ea3fc11b78b2
---
# How to: Create a 3D Scene
This example shows how to create a 3D object that looks like a flat sheet of paper which has been rotated. A <xref:System.Windows.Controls.Viewport3D> along with the following components are used to create this simple 3D scene:  
  
- A camera is created using a <xref:System.Windows.Media.Media3D.PerspectiveCamera>. The camera specifies what part of the 3D scene is viewable.  
  
- A mesh is created to specify the shape of 3D object (sheet of paper) using the <xref:System.Windows.Media.Media3D.GeometryModel3D.Geometry%2A> property of <xref:System.Windows.Media.Media3D.GeometryModel3D>.  
  
- A material is specified to be displayed on the surface of the object (linear gradient in this sample) using the <xref:System.Windows.Media.Media3D.GeometryModel3D.Material%2A> property of <xref:System.Windows.Media.Media3D.GeometryModel3D>.  
  
- A light is created to shine on the object using <xref:System.Windows.Media.Media3D.DirectionalLight>.  
  
## Example  
 The code below shows how to create a 3D scene in XAML.  
  
 [!code-xaml[3DGallery_snip#Basic3DShapeExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/3DGallery_snip/CS/Basic3DShapeExample.xaml#basic3dshapeexamplewholepage)]  
  
## Example  
 The code below shows how to create the same 3D scene in procedural code.  
  
 [!code-csharp[3DGallery_procedural_snip#Basic3DShapeCodeExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/3DGallery_procedural_snip/CSharp/Basic3DShapeExample.cs#basic3dshapecodeexamplewholepage)]
 [!code-vb[3DGallery_procedural_snip#Basic3DShapeCodeExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/3DGallery_procedural_snip/visualbasic/basic3dshapeexample.vb#basic3dshapecodeexamplewholepage)]  
  
## See also

- [3D Graphics Overview](3-d-graphics-overview.md)
