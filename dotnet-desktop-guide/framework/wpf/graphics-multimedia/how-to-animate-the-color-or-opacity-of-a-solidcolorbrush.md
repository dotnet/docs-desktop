---
title: "How to: Animate the Color or Opacity of a SolidColorBrush"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "SolidColorBrush [WPF], animating color of"
  - "colors [WPF], animating"
  - "opacity [WPF], animating"
  - "animation [WPF], color of SolidColorBrush"
  - "animation [WPF], opacity of SolidColorBrush"
  - "SolidColorBrush [WPF], animating opacity of"
ms.assetid: d9154354-843f-4713-bad1-35bb0ba6eaeb
---
# How to: Animate the Color or Opacity of a SolidColorBrush
This example shows how to animate the <xref:System.Windows.Media.SolidColorBrush.Color%2A> and <xref:System.Windows.Media.Brush.Opacity%2A> of a <xref:System.Windows.Media.SolidColorBrush>.  
  
## Example  
 The following example uses three animations to animate the <xref:System.Windows.Media.SolidColorBrush.Color%2A> and <xref:System.Windows.Media.Brush.Opacity%2A> of a <xref:System.Windows.Media.SolidColorBrush>.  
  
- The first animation, a <xref:System.Windows.Media.Animation.ColorAnimation>, changes the brush's color to <xref:System.Windows.Media.Colors.Gray%2A> when the mouse enters the rectangle.  
  
- The next animation, another <xref:System.Windows.Media.Animation.ColorAnimation>, changes the brush's color to <xref:System.Windows.Media.Colors.Orange%2A> when the mouse leaves the rectangle.  
  
- The final animation, a <xref:System.Windows.Media.Animation.DoubleAnimation>, changes the brush's opacity to 0.0 when the left mouse button is pressed.  
  
 [!code-csharp[brushanimations_snip#SolidColorBrushAnimationExample](~/samples/snippets/csharp/VS_Snippets_Wpf/brushanimations_snip/CSharp/SolidColorBrushExample.cs#solidcolorbrushanimationexample)]  
  
 For a more complete sample, which shows how to animate different types of brushes, see the [Brushes Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/Brushes). For more information about animation, see the [Animation Overview](animation-overview.md).  
  
 For consistency with other animation examples, the code versions of this example use a <xref:System.Windows.Media.Animation.Storyboard> object to apply their animations. However, when applying a single animation in code, it's simpler to use the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method instead of using a <xref:System.Windows.Media.Animation.Storyboard>. For an example, see [Animate a Property Without Using a Storyboard](how-to-animate-a-property-without-using-a-storyboard.md).  
  
## See also

- [Animation Overview](animation-overview.md)
- [Storyboards Overview](storyboards-overview.md)
- [Brushes Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Graphics/Brushes)
