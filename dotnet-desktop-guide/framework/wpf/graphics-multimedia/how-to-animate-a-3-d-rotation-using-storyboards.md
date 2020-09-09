---
title: "How to: Animate a 3D Rotation Using Storyboards"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Storyboards [WPF]"
  - "3D translations [WPF], animating [WPF], with Storyboards"
  - "animation [WPF], 3D translations [WPF], with Storyboards"
ms.assetid: 1020e44e-e21e-49a8-be53-53cbc1910e83
---
# How to: Animate a 3D Rotation Using Storyboards
The following example shows how to make a 3D object rotate while it "wobbles" by animating the <xref:System.Windows.Media.Media3D.AxisAngleRotation3D.Angle%2A> and <xref:System.Windows.Media.Media3D.AxisAngleRotation3D.Axis%2A> properties of an <xref:System.Windows.Media.Media3D.AxisAngleRotation3D> object. This <xref:System.Windows.Media.Media3D.AxisAngleRotation3D> object specifies the rotation transform of the 3D object and so animating its properties creates the desire rotation effect. Within the Storyboard, <xref:System.Windows.Media.Animation.DoubleAnimation> is used to animate the <xref:System.Windows.Media.Media3D.AxisAngleRotation3D.Angle%2A> property while <xref:System.Windows.Media.Animation.Vector3DAnimation> is used to animate the <xref:System.Windows.Media.Media3D.AxisAngleRotation3D.Axis%2A> property.  
  
## Example  
 [!code-xaml[Animation3DGallery_snip#Rotate3DUsingAxisAngleRotation3DExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/Rotat3DUsingAxisAngleRotation3DExample.xaml#rotate3dusingaxisanglerotation3dexamplewholepage)]  
  
## See also

- [Animate a 3D Rotation Using Rotation3DAnimation](how-to-animate-a-3-d-rotation-using-rotation3danimation.md)
- [Animate a 3D Rotation Using Key Frames (Rotation3DAnimationUsingKeyFrames)](how-to-animate-a-3-d-rotation-using-key-frames.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
- [Storyboards Overview](storyboards-overview.md)
