---
title: "How to: Repeat an Animation"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "RepeatBehavior property of timelines [WPF]"
  - "repeating animating [WPF]"
  - "Timelines RepeatBehavior property [WPF]"
  - "animation [WPF], repeating"
ms.assetid: e6f3b068-eeeb-47fd-8d40-8848c31f1e1e
---
# How to: Repeat an Animation
This example shows how to use the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property of a <xref:System.Windows.Media.Animation.Timeline> in order to control the repeat behavior of an animation.  
  
## Example  
 The <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property of a <xref:System.Windows.Media.Animation.Timeline> controls how many times an animation repeats its simple duration. By using <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A>, you can specify that a <xref:System.Windows.Media.Animation.Timeline> repeats for a certain number of times (an iteration count) or for a specified time period. In either case, the animation goes through as many beginning-to-end runs that it needs in order to fill the requested count or duration.  
  
 By default, timelines have a repeat count of 1.0, which means they play one time and do not repeat. However, if you set the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property of a <xref:System.Windows.Media.Animation.Timeline> to <xref:System.Windows.Media.Animation.RepeatBehavior.Forever%2A>, the timeline repeats indefinitely.  
  
 The following example shows how to use the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property to control the repeat behavior of an animation. The example animates the <xref:System.Windows.FrameworkElement.Width%2A> property of five rectangles with each rectangle using a different type of repeat behavior.  
  
 [!code-xaml[timingbehaviors_snip#RepeatBehaviorWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_snip/CSharp/RepeatBehaviorExample.xaml#repeatbehaviorwholepage)]  
  
 For the complete sample, see [Animation Timing Behavior Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Animation/AnimationTiming).  
  
## See also

- [Accumulate Animation Values During Repeat Cycles](how-to-accumulate-animation-values-during-repeat-cycles.md)
- [Specify Whether a Timeline Automatically Reverses](how-to-specify-whether-a-timeline-automatically-reverses.md)
- [Animation and Timing How-to Topics](animation-and-timing-how-to-topics.md)
- [Animation Overview](animation-overview.md)
- [Animation Timing Behavior Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Animation/AnimationTiming)
