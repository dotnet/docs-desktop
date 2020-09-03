---
title: "How to: Animate a Property by Using an AnimationClock"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "animation [WPF], properties [WPF], with AnimationClocks"
  - "AnimationClocks [WPF]"
ms.assetid: e6542021-714c-4675-9567-04f1c7380834
---
# How to: Animate a Property by Using an AnimationClock
This example shows how to use <xref:System.Windows.Media.Animation.Clock> objects to animate a property.  
  
 There are three ways to animate a dependency property:  
  
- Create an <xref:System.Windows.Media.Animation.AnimationTimeline> and associate it with that property by using a <xref:System.Windows.Media.Animation.Storyboard>.  
  
- Use the object's <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method to apply a single <xref:System.Windows.Media.Animation.AnimationTimeline> to a target property.  
  
- Create an <xref:System.Windows.Media.Animation.AnimationClock> from an <xref:System.Windows.Media.Animation.AnimationTimeline> and apply it to a property.  
  
 <xref:System.Windows.Media.Animation.Storyboard> objects and the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method enable you to animate properties without directly creating and distributing clocks (for examples, see [Animate a Property by Using a Storyboard](how-to-animate-a-property-by-using-a-storyboard.md) and [Animate a Property Without Using a Storyboard](how-to-animate-a-property-without-using-a-storyboard.md)); clocks are created and distributed for you automatically.  
  
## Example  
 The following example shows how to create an <xref:System.Windows.Media.Animation.AnimationClock> and apply it to two similar properties.  
  
 [!code-csharp[timingbehaviors_procedural_snip#GraphicsMMCreateAnimationClockWholeClass](~/samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_procedural_snip/CSharp/AnimationClockExample.cs#graphicsmmcreateanimationclockwholeclass)]
 [!code-vb[timingbehaviors_procedural_snip#GraphicsMMCreateAnimationClockWholeClass](~/samples/snippets/visualbasic/VS_Snippets_Wpf/timingbehaviors_procedural_snip/visualbasic/animationclockexample.vb#graphicsmmcreateanimationclockwholeclass)]  
  
 For an example showing how to interactively control a <xref:System.Windows.Media.Animation.Clock> after it starts, see [Interactively Control a Clock](how-to-interactively-control-a-clock.md).  
  
## See also

- [Animate a Property by Using a Storyboard](how-to-animate-a-property-by-using-a-storyboard.md)
- [Animate a Property Without Using a Storyboard](how-to-animate-a-property-without-using-a-storyboard.md)
- [Property Animation Techniques Overview](property-animation-techniques-overview.md)
