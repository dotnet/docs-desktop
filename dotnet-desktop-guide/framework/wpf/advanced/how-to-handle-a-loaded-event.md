---
title: "How to: Handle a Loaded Event"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "XAML [WPF], Loaded events"
  - "events [WPF], Loaded"
  - "Loaded events [WPF]"
ms.assetid: 0cf8d003-8441-4df4-807a-6db09347e829
description: Learn how to handle the FrameworkElement.Loaded event, with an example scenario for handling that event. 
---
# How to: Handle a Loaded Event

This example shows how to handle the <xref:System.Windows.FrameworkElement.Loaded?displayProperty=nameWithType> event, and an appropriate scenario for handling that event. The handler  creates a <xref:System.Windows.Controls.Button> when the page loads.  
  
## Example  

 The following example uses Extensible Application Markup Language (XAML) together with a code-behind file.  
  
 [!code-xaml[FELoaded#XAML](~/samples/snippets/csharp/VS_Snippets_Wpf/FELoaded/CSharp/default.xaml#xaml)]  
  
 [!code-csharp[FELoaded#Handler](~/samples/snippets/csharp/VS_Snippets_Wpf/FELoaded/CSharp/default.xaml.cs#handler)]
 [!code-vb[FELoaded#Handler](~/samples/snippets/visualbasic/VS_Snippets_Wpf/FELoaded/VisualBasic/default.xaml.vb#handler)]  
  
## See also

- <xref:System.Windows.FrameworkElement>
- [Object Lifetime Events](object-lifetime-events.md)
- [Routed Events Overview](routed-events-overview.md)
- [How-to Topics](base-elements-how-to-topics.md)
