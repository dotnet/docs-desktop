---
title: "How to: Create a Custom Routed Event"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "routed events [WPF], creating"
  - "events [WPF], routing"
ms.assetid: b79f459a-1c3f-4045-b2d4-1659cc8eaa3c
description: Learn how to to support event routing, by registering a RoutedEvent using the RegisterRoutedEvent method.
---
# How to: Create a Custom Routed Event

For your custom event to support event routing, you need to register a <xref:System.Windows.RoutedEvent> using the <xref:System.Windows.EventManager.RegisterRoutedEvent%2A> method. This example demonstrates the basics of creating a custom routed event.  
  
## Example  

 As shown in the following example, you first register a <xref:System.Windows.RoutedEvent> using the <xref:System.Windows.EventManager.RegisterRoutedEvent%2A> method. By convention, the <xref:System.Windows.RoutedEvent> static field name should end with the suffix ***Event***. In this example, the name of the event is `Tap` and the routing strategy of the event is <xref:System.Windows.RoutingStrategy.Bubble>. After the registration call, you can provide add-and-remove common language runtime (CLR) event accessors for the event.  
  
 Note that even though the event is raised through the `OnTap` virtual method in this particular example, how you raise your event or how your event responds to changes depends on your needs.  
  
 Note also that this example basically implements an entire subclass of <xref:System.Windows.Controls.Button>; that subclass is built as a separate assembly and then instantiated as a custom class on a separate Windows Presentation Foundation (WPF) element does.  
  
 [!code-csharp[RoutedEventCustom#CustomClass](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventCustom/CSharp/SDKSampleLibrary/class1.cs#customclass)]
 [!code-vb[RoutedEventCustom#CustomClass](~/samples/snippets/visualbasic/VS_Snippets_Wpf/RoutedEventCustom/VB/SDKSampleLibrary/Class1.vb#customclass)]  
  
 [!code-xaml[RoutedEventCustom#Page](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventCustom/CSharp/RoutedEventCustomApp/default.xaml#page)]  
  
 Tunneling events are created the same way, but with <xref:System.Windows.RoutedEvent.RoutingStrategy%2A> set to <xref:System.Windows.RoutingStrategy.Tunnel> in the registration call. By convention, tunneling events in WPF are prefixed with the word "Preview".  
  
 To see an example of how bubbling events work, see [Handle a Routed Event](how-to-handle-a-routed-event.md).  
  
## See also

- [Routed Events Overview](routed-events-overview.md)
- [Input Overview](input-overview.md)
- [Control Authoring Overview](../controls/control-authoring-overview.md)
