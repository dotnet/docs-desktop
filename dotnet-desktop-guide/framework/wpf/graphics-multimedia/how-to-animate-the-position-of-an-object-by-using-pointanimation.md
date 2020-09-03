---
title: "How to: Animate the Position of an Object by Using PointAnimation"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "graphics [WPF], animation"
  - "animation [WPF], PointAnimation"
ms.assetid: 42310977-cc90-438a-8a47-0345898e01be
---
# How to: Animate the Position of an Object by Using PointAnimation
This example shows how to use the <xref:System.Windows.Media.Animation.PointAnimation> class to animate an object along a <xref:System.Windows.Shapes.Path>.  
  
## Example  
 The following example moves an ellipse along a <xref:System.Windows.Shapes.Path> from one point on the screen to another. The example animates the position of an <xref:System.Windows.Media.EllipseGeometry> by using <xref:System.Windows.Media.Animation.PointAnimation> to animate the <xref:System.Windows.Media.EllipseGeometry.Center%2A> property.  
  
 [!code-csharp[BasicAnimations_snip#PointAnimationWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/BasicAnimations_snip/CSharp/PointAnimationExample.cs#pointanimationwholepage)]
 [!code-vb[BasicAnimations_snip#PointAnimationWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BasicAnimations_snip/VisualBasic/PointAnimationExample.vb#pointanimationwholepage)]  
  
## See also

- <xref:System.Windows.Media.Animation.PointAnimation>
- <xref:System.Windows.Shapes.Path>
- <xref:System.Windows.Media.EllipseGeometry>
- <xref:System.Windows.Media.EllipseGeometry.Center%2A>
- [Animation Overview](animation-overview.md)
- [Graphics and Multimedia](index.md)
- [Graphics How-to Topics](graphics-how-to-topics.md)
- [Animation and Timing How-to Topics](animation-and-timing-how-to-topics.md)
