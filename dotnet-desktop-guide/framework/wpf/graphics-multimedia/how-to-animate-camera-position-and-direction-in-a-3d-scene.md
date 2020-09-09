---
title: "How to: Animate Camera Position and Direction in a 3D Scene"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "animation [WPF], camera position in 3D scenes"
  - "camera direction [WPF], animating in 3D scenes"
  - "3D scenes [WPF], animating camera position"
  - "3D scenes [WPF], animating camera direction"
  - "camera position [WPF], animating in 3D scenes"
  - "animation [WPF], camera direction in 3D scenes"
ms.assetid: 480224b7-a5e5-4165-ba7f-ef760ddff94a
---
# How to: Animate Camera Position and Direction in a 3D Scene
The following example shows how to animate the position of a camera and animate the direction it is pointing in a 3D scene. This is done by using <xref:System.Windows.Media.Animation.Point3DAnimation> and <xref:System.Windows.Media.Animation.Vector3DAnimation> to animate the <xref:System.Windows.Media.Media3D.ProjectionCamera.Position%2A> and <xref:System.Windows.Media.Media3D.ProjectionCamera.LookDirection%2A> properties respectively of the <xref:System.Windows.Media.Media3D.PerspectiveCamera>. You might use an animation like this to change the onlooker's view of a scene in response to an event.  
  
## Example  
 [!code-xaml[Animation3DGallery_snip#PointVector3DAnimationExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/PointVector3DAnimationExample.xaml#pointvector3danimationexamplewholepage)]  
  
## See also

- <xref:System.Windows.Media.Animation.Vector3DAnimation>
- <xref:System.Windows.Media.Animation.Point3DAnimation>
- [Animate Camera Position and Direction Using Key Frames](how-to-animate-camera-position-and-direction-using-key-frames.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
