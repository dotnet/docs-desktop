---
title: "How to: Animate a Matrix by Using Key Frames"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "animation [WPF], Matrix properties with key frames"
  - "Matrix properties [WPF], animating with key frames"
  - "key frames [WPF], animating Matrix properties with"
ms.assetid: b851a4c7-ecb1-420e-9203-83e7afd037fd
---
# How to: Animate a Matrix by Using Key Frames
This example shows how to animate the <xref:System.Windows.Media.MatrixTransform.Matrix%2A> property of a <xref:System.Windows.Media.MatrixTransform> by using key frames.  
  
## Example  
 The following example uses the <xref:System.Windows.Media.Animation.MatrixAnimationUsingKeyFrames> class to animate the <xref:System.Windows.Media.MatrixTransform.Matrix%2A> property of a <xref:System.Windows.Media.MatrixTransform>. The example uses the <xref:System.Windows.Media.MatrixTransform> object to transform the appearance and position of a <xref:System.Windows.Controls.Button>.  
  
 This animation uses the <xref:System.Windows.Media.Animation.DiscreteMatrixKeyFrame> class to create two key frames and does the following with them:  
  
1. Animates the first <xref:System.Windows.Media.Matrix> during the first 0.2 seconds. The example changes the <xref:System.Windows.Media.Matrix.M11%2A> and <xref:System.Windows.Media.Matrix.M12%2A> properties of the <xref:System.Windows.Media.Matrix>. This change causes the button to stretch and become skewed. The example also changes the <xref:System.Windows.Media.Matrix.OffsetX%2A> and <xref:System.Windows.Media.Matrix.OffsetY%2A> properties so that the button changes position.  
  
2. Animates the second <xref:System.Windows.Media.Matrix> at 1.0 seconds. The button moves to another position while the button is no longer skewed or stretched.  
  
3. Repeats the animation indefinitely.  
  
> [!NOTE]
> Key frames that derive from the <xref:System.Windows.Media.Animation.DiscreteMatrixKeyFrame> object create sudden jumps between values, that is, the movement of the animation is jerky.  
  
 [!code-xaml[keyframes_snip#MatrixAnimationUsingKeyFramesWholePage](~/samples/snippets/xaml/VS_Snippets_Wpf/keyframes_snip/XAML/MatrixAnimationUsingKeyFramesExample.xaml#matrixanimationusingkeyframeswholepage)]  
  
 For the complete sample, see [KeyFrame Animation Sample](https://github.com/microsoft/WPF-Samples/tree/master/Animation/KeyFrameAnimation).  
  
## See also

- <xref:System.Windows.Media.MatrixTransform.Matrix%2A>
- <xref:System.Windows.Media.MatrixTransform>
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
- [Key-Frame How-to Topics](key-frame-animation-how-to-topics.md)
