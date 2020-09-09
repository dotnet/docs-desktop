---
title: "How to: Find the Source Element in an Event Handler"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "source element in event handlers [WPF]"
  - "event handlers [WPF], finding source element in"
ms.assetid: 85f71c5a-b714-4c65-9711-7d905c2bbe98
---
# How to: Find the Source Element in an Event Handler
This example shows how to find the source element in an event handler.  
  
## Example  
 The following example shows a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler that is declared in a code-behind file. When a user clicks the button that the handler is attached to, the handler changes a property value. The handler code uses the <xref:System.Windows.RoutedEventArgs.Source%2A> property of the routed event data that is reported in the event arguments to change the <xref:System.Windows.FrameworkElement.Width%2A> property value on the <xref:System.Windows.RoutedEventArgs.Source%2A> element.  
  
 [!code-xaml[RoutedEventSource#XAMLHandler](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventSource/CSharp/default.xaml#xamlhandler)]  
  
 [!code-csharp[RoutedEventSource#Handler](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventSource/CSharp/default.xaml.cs#handler)]
 [!code-vb[RoutedEventSource#Handler](~/samples/snippets/visualbasic/VS_Snippets_Wpf/RoutedEventSource/VisualBasic/default.xaml.vb#handler)]  
  
## See also

- <xref:System.Windows.RoutedEventArgs>
- [Routed Events Overview](routed-events-overview.md)
- [How-to Topics](events-how-to-topics.md)
