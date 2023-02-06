---
title: "How to: Animate a Property Without Using a Storyboard"
description: Learn how to use the BeginAnimation method to animate a property without using a Storyboard with several provided code examples.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "non-Storyboard animation"
  - "local animation [WPF]"
  - "animation [WPF], non-Storyboard (local)"
ms.assetid: d411db70-4df7-487d-82bc-95a7c1b2e7f8
---
# How to: Animate a Property Without Using a Storyboard

This example shows one way to apply an animation to a property without using a <xref:System.Windows.Media.Animation.Storyboard>.  
  
> [!NOTE]
> This functionality is not available in XAML, see [Animate a Property by Using a Storyboard](how-to-animate-a-property-by-using-a-storyboard.md).  
  
 To apply a local animation to a property, use the <xref:System.Windows.UIElement.BeginAnimation%2A> method. This method takes two parameters: a <xref:System.Windows.DependencyProperty> that specifies the property to animate, and the animation to apply to that property.  
  
## Example  

 The following example shows how to animate the width and background color of a <xref:System.Windows.Controls.Button>.  
  
 [!code-cpp[animateproperty#11](~/samples/snippets/cpp/VS_Snippets_Wpf/animateproperty/CPP/LocalAnimationExample.cpp#11)]
 [!code-csharp[animateproperty#11](~/samples/snippets/csharp/VS_Snippets_Wpf/animateproperty/CSharp/LocalAnimationExample.cs#11)]
 [!code-vb[animateproperty#11](~/samples/snippets/visualbasic/VS_Snippets_Wpf/animateproperty/VisualBasic/LocalAnimationExample.vb#11)]  
  
 A variety of animation classes in the <xref:System.Windows.Media.Animation> namespace exist for animating different types of properties. For more information about animating properties, see [Animation Overview](animation-overview.md). For more information about dependency properties (the type of properties that are shown in these examples) and their features, see [Dependency Properties Overview](../advanced/dependency-properties-overview.md).  
  
 There are other ways to animate without using <xref:System.Windows.Media.Animation.Storyboard> objects; for more information, see [Property Animation Techniques Overview](property-animation-techniques-overview.md).  
  
## See also

- <xref:System.Windows.Media.Animation.AnimationTimeline>
- <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A>
- <xref:System.Windows.Media.Animation>
- <xref:System.Windows.Media.Animation.Storyboard>
- [Property Animation Techniques Overview](property-animation-techniques-overview.md)
- [Animation Overview](animation-overview.md)
