---
title: "How to: Interactively Control a Clock"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controlling clocks interactively [WPF]"
  - "clocks [WPF], controlling interactively"
ms.assetid: d0b520e0-2f18-4cef-977f-2909e709548a
---
# How to: Interactively Control a Clock
A <xref:System.Windows.Media.Animation.Clock> object's <xref:System.Windows.Media.Animation.ClockController> property enables you to interactively start, pause, resume, seek, advance the clock to its fill period, and stop the clock. Only the root clock of a timing tree can be interactively controlled.  
  
> [!NOTE]
> There are other ways to interactively control animations that don't require you to work directly with clocks: you can also use Storyboards. Storyboards are supported in both markup and code. For an example, see [Animate a Property by Using a Storyboard](how-to-animate-a-property-by-using-a-storyboard.md) or the [Animation Overview](animation-overview.md).  
  
 In the following example, several buttons are used to interactively control an animation clock.  
  
## Example  
 [!code-csharp[timingbehaviors_procedural_snip#GraphicsMMClockControllerExample](~/samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_procedural_snip/CSharp/ClockControllerExample.cs#graphicsmmclockcontrollerexample)]
 [!code-vb[timingbehaviors_procedural_snip#GraphicsMMClockControllerExample](~/samples/snippets/visualbasic/VS_Snippets_Wpf/timingbehaviors_procedural_snip/visualbasic/clockcontrollerexample.vb#graphicsmmclockcontrollerexample)]  
  
## See also

- [Animate a Property by Using a Storyboard](how-to-animate-a-property-by-using-a-storyboard.md)
- [Animation Overview](animation-overview.md)
