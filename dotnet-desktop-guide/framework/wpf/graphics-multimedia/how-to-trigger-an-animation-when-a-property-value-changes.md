---
title: "How to: Trigger an Animation When a Property Value Changes"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "animation [WPF], starting when property values change"
  - "triggering animation [WPF]"
  - "Storyboards [WPF], starting when property values change"
ms.assetid: 12399c21-0300-4f4f-9e3a-d92d9907e5f5
---
# How to: Trigger an Animation When a Property Value Changes
This example shows how to use a <xref:System.Windows.Trigger> to start a <xref:System.Windows.Media.Animation.Storyboard> when a property value changes. You can use a <xref:System.Windows.Trigger> inside a <xref:System.Windows.Style>, <xref:System.Windows.Controls.ControlTemplate>, or <xref:System.Windows.DataTemplate>.  
  
## Example  
 The following example uses a <xref:System.Windows.Trigger> to animate the <xref:System.Windows.UIElement.Opacity%2A> of a <xref:System.Windows.Controls.Button> when its <xref:System.Windows.UIElement.IsMouseOver%2A> property becomes `true`.  
  
 [!code-xaml[AnimatePropertyStoryboards#PropertyTriggerExample](~/samples/snippets/xaml/VS_Snippets_Wpf/AnimatePropertyStoryboards/XAML/PropertyTriggerExample.xaml#propertytriggerexample)]  
  
 Animations applied by property <xref:System.Windows.Trigger> objects behave in a more complex fashion than <xref:System.Windows.EventTrigger> animations or animations started using <xref:System.Windows.Media.Animation.Storyboard> methods.  They "handoff" with animations defined by other <xref:System.Windows.Trigger> objects, but compose with <xref:System.Windows.EventTrigger> and method-triggered animations.  
  
## See also

- <xref:System.Windows.Trigger>
- [Property Animation Techniques Overview](property-animation-techniques-overview.md)
- [Storyboards Overview](storyboards-overview.md)
