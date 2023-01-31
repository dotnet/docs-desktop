---
title: "How to: Handle a Routed Event"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "routed events [WPF], handling"
  - "bubbling events [WPF]"
ms.assetid: 157787b4-f469-4047-8777-5b034145f32e
description: Learn how bubbling events work and how to write a handler that can process the routed event data, with supporting information and examples. 
---
# How to: Handle a Routed Event

This example shows how bubbling events work and how to write a handler that can process the routed event data.  
  
## Example  

 In Windows Presentation Foundation (WPF), elements are arranged in an element tree structure. The parent element can participate in the handling of events that are initially raised by child elements in the element tree. This is possible because of event routing.  
  
 Routed events typically follow one of two routing strategies, bubbling or tunneling. This example focuses on the bubbling event and uses the <xref:System.Windows.Controls.Primitives.ButtonBase.Click?displayProperty=nameWithType> event to show how routing works.  
  
 The following example creates two <xref:System.Windows.Controls.Button> controls and uses XAML attribute syntax to attach an event handler to a common parent element, which in this example is <xref:System.Windows.Controls.StackPanel>. Instead of attaching individual event handlers for each <xref:System.Windows.Controls.Button> child element, the example uses attribute syntax to attach the event handler to the <xref:System.Windows.Controls.StackPanel> parent element. This event-handling pattern shows how to use event routing as a technique for reducing the number of elements where a handler is attached. All the bubbling events for each <xref:System.Windows.Controls.Button> route through the parent element.  
  
 Note that on the parent <xref:System.Windows.Controls.StackPanel> element, the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event name specified as the attribute is partially qualified by naming the <xref:System.Windows.Controls.Button> class. The <xref:System.Windows.Controls.Button> class is a <xref:System.Windows.Controls.Primitives.ButtonBase> derived class that has the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event in its members listing. This partial qualification technique for attaching an event handler is necessary if the event that is being handled does not exist in the members listing of the element where the routed event handler is attached.  
  
 [!code-xaml[RoutedEventHandle#XAML](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventHandle/CSharp/default.xaml#xaml)]  
  
 The following example handles the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event.  The example reports which element handles the event and which element raises the event. The event handler is executed when the user clicks either button.  
  
 [!code-csharp[RoutedEventHandle#Handler](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventHandle/CSharp/default.xaml.cs#handler)]
 [!code-vb[RoutedEventHandle#Handler](~/samples/snippets/visualbasic/VS_Snippets_Wpf/RoutedEventHandle/VisualBasic/MainWindow.xaml.vb#handler)]  
  
## See also

- <xref:System.Windows.RoutedEvent>
- [Input Overview](input-overview.md)
- [Routed Events Overview](routed-events-overview.md)
- [How-to Topics](events-how-to-topics.md)
- [XAML Syntax In Detail](xaml-syntax-in-detail.md)
