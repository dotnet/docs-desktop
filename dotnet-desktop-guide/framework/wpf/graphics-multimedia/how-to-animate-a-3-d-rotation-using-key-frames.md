---
title: "How to: Animate a 3D Rotation Using Key Frames"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "animation [WPF], 3D translations [WPF], with key frames (Rotation3DAnimation)"
  - "key frames [WPF], Rotation3DAnimation"
  - "3D translations [WPF], animating [WPF], with key frames (Rotation3DAnimation)"
ms.assetid: 6f671b95-7f30-4836-9a4f-aeb7dc30121f
---
# How to: Animate a 3D Rotation Using Key Frames
In the following example, <xref:System.Windows.Media.Animation.Rotation3DAnimationUsingKeyFrames> is used to make a 3D object rotate while its axis of rotation animates resulting in a "wobble". This animation uses the following key frames:  
  
1. <xref:System.Windows.Media.Animation.LinearRotation3DKeyFrame> is used to create a smooth, linear interpolation between values.  
  
2. <xref:System.Windows.Media.Animation.DiscreteRotation3DKeyFrame> is used to create sudden "jumps" between values (no interpolation).  
  
3. <xref:System.Windows.Media.Animation.SplineRotation3DKeyFrame> is used to create a variable transition between values depending on the <xref:System.Windows.Media.Animation.SplineRotation3DKeyFrame.KeySpline%2A> property. In the example below, this part of the animation starts off slow but toward the end of the time segment, speeds up exponentially.  
  
## Example  
 [!code-xaml[Animation3DGallery_snip#Rotation3DAnimationUsingKeyFramesExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/Rotation3DAnimationUsingKeyFramesExample.xaml#rotation3danimationusingkeyframesexamplewholepage)]  
  
## See also

- [3D Graphics Overview](3-d-graphics-overview.md)
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
- [Animate a 3D Rotation Using Storyboards](how-to-animate-a-3-d-rotation-using-storyboards.md)
- [Animate a 3D Rotation Using Rotation3DAnimation](how-to-animate-a-3-d-rotation-using-rotation3danimation.md)
- [Animate a 3D Rotation Using Quaternions](how-to-animate-a-3-d-rotation-using-quaternions.md)
- [Animate a 3D Rotation Using Key Frames (QuaternionAnimationUsingKeyFrames)](animate-a-3-d-rotation-quaternionanimationusingkeyframes.md)
