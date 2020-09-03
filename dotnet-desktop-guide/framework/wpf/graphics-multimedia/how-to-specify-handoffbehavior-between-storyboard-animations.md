---
title: "How to: Specify HandoffBehavior Between Storyboard Animations"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Storyboards [WPF], handoff behavior between animations"
  - "animation [WPF], handoff behavior between"
ms.assetid: 97bd6842-929b-49d9-813e-46553ae46472
---
# How to: Specify HandoffBehavior Between Storyboard Animations
This example shows how to specify handoff behavior between storyboard animations. The <xref:System.Windows.Media.Animation.BeginStoryboard.HandoffBehavior%2A> property of <xref:System.Windows.Media.Animation.BeginStoryboard> specifies how new animations interact with any existing ones that are already applied to a property.  
  
## Example  
 The following example creates two buttons that enlarge when the mouse cursor moves over them and become smaller when the cursor moves away. If you mouse over a button and then quickly remove the cursor, the second animation will be applied before the first one is finished. It is when two animations overlap like this that you can see the difference between the <xref:System.Windows.Media.Animation.BeginStoryboard.HandoffBehavior%2A> values of <xref:System.Windows.Media.Animation.HandoffBehavior.Compose> and <xref:System.Windows.Media.Animation.HandoffBehavior.SnapshotAndReplace>. A value of <xref:System.Windows.Media.Animation.HandoffBehavior.Compose> combines the overlapping animations causing a smoother transition between animations while a value of <xref:System.Windows.Media.Animation.HandoffBehavior.SnapshotAndReplace> causes the new animation to immediately replace the earlier overlapping animation.  
  
 [!code-xaml[timingbehaviors_snip#HandoffBehaviorWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_snip/CSharp/HandoffBehaviorExample.xaml#handoffbehaviorwholepage)]  
  
## See also

- <xref:System.Windows.Media.Animation.BeginStoryboard>
- <xref:System.Windows.Media.Animation.BeginStoryboard.HandoffBehavior%2A>
- [Animation Overview](animation-overview.md)
- [Animation and Timing How-to Topics](animation-and-timing-how-to-topics.md)
