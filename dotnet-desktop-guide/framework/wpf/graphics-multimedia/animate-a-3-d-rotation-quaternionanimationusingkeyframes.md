---
title: "How to: Animate a 3D Rotation Using Key Frames (QuaternionAnimationUsingKeyFrames)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "3D translations [WPF], animating [WPF], with key frames (QuaternionAnimationUsingKeyFrames)"
  - "key frames [WPF], QuaternionAnimationUsingKeyFrames"
  - "animation [WPF], 3D translations [WPF], with key frames (QuaternionAnimationUsingKeyFrames)"
ms.assetid: 09e5707b-7523-4a08-9aa7-bb13cbedccdf
---
# How to: Animate a 3D Rotation Using Key Frames (QuaternionAnimationUsingKeyFrames)
In the following example, <xref:System.Windows.Media.Animation.QuaternionAnimationUsingKeyFrames> is used to make a 3D object rotate. This animation uses the following key frames:  
  
1. <xref:System.Windows.Media.Animation.LinearRotation3DKeyFrame> is used to create a smooth, linear interpolation between values.  
  
2. <xref:System.Windows.Media.Animation.DiscreteRotation3DKeyFrame> is used to create sudden "jumps" between values (no interpolation).  
  
3. <xref:System.Windows.Media.Animation.SplineRotation3DKeyFrame> is used to create a variable transition between values depending on the <xref:System.Windows.Media.Animation.SplineRotation3DKeyFrame.KeySpline%2A> property. In the example below, this part of the animation starts off slow but toward the end of the time segment, speeds up exponentially.  
  
## Example  
 [!code-xaml[Animation3DGallery_snip#QuaternionAnimationUsingKeyFramesExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/QuaternionAnimationUsingKeyFramesExample.xaml#quaternionanimationusingkeyframesexamplewholepage)]  
  
## See also

- [Animate a 3D Rotation Using Storyboards](how-to-animate-a-3-d-rotation-using-storyboards.md)
- [Animate a 3D Rotation Using Rotation3DAnimation](how-to-animate-a-3-d-rotation-using-rotation3danimation.md)
- [Animate a 3D Rotation Using Quaternions](how-to-animate-a-3-d-rotation-using-quaternions.md)
- [Animate a 3D Rotation Using Key Frames (Rotation3DAnimationUsingKeyFrames)](how-to-animate-a-3-d-rotation-using-key-frames.md)
- [3D Graphics Overview](3-d-graphics-overview.md)
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
