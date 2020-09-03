---
title: "How to: Add an Animation Output Value to an Animation Starting Value"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "animation [WPF]"
ms.assetid: b89a82be-b03d-481e-a8d3-cc513d09ca00
---
# How to: Add an Animation Output Value to an Animation Starting Value
This example shows how to add an animation output value to an animation starting value.  
  
## Example  
 The <xref:System.Windows.Media.Animation.DoubleAnimation.IsAdditive%2A> property specifies whether you want the output value of an animation added to the starting value (base value) of an animated property. You can use the <xref:System.Windows.Media.Animation.DoubleAnimation.IsAdditive%2A> property with most basic animations and most key frame animations. For more information, see [Animation Overview](animation-overview.md) and [Key-Frame Animations Overview](key-frame-animations-overview.md).  
  
 The following example shows the effect of using the <xref:System.Windows.Media.Animation.DoubleAnimation.IsAdditive%2A?displayProperty=nameWithType> property with <xref:System.Windows.Media.Animation.DoubleAnimation> and using the <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames.IsAdditive%2A?displayProperty=nameWithType> property with <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames>.  
  
 [!code-xaml[timingbehaviors_snip#IsAdditiveWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_snip/CSharp/IsAdditiveExample.xaml#isadditivewholepage)]  
  
## See also

- [Accumulate Animation Values During Repeat Cycles](how-to-accumulate-animation-values-during-repeat-cycles.md)
- [Animation Overview](animation-overview.md)
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
- [Animation and Timing How-to Topics](animation-and-timing-how-to-topics.md)
