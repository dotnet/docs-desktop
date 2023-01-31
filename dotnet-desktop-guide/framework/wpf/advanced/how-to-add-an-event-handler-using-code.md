---
title: "How to: Add an Event Handler Using Code"
description: Use this example to learn how to add an event handler to an element in Windows Presentation Foundation by using code, instead of declaring it by using XAML.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "event handlers [WPF], adding"
  - "XAML [WPF], adding event handlers"
ms.assetid: 269c61e0-6bd9-4291-9bed-1c5ee66da486
---
# How to: Add an Event Handler Using Code

This example shows how to add an event handler to an element by using code.  
  
 If you want to add an event handler to a XAML element, and the markup page that contains the element has already been loaded, you must add the handler using code. Alternatively, if you are building up the element tree for an application entirely using code and not declaring any elements using XAML, you can call specific methods to add event handlers to the constructed element tree.  
  
## Example  

 The following example adds a new <xref:System.Windows.Controls.Button> to an existing page that is initially defined in XAML. A code-behind file implements an event handler method and then adds that method as a new event handler on the <xref:System.Windows.Controls.Button>.  
  
 The C# example uses the `+=` operator to assign a handler to an event. This is the same operator that is used to assign a handler in the common language runtime (CLR) event handling model. Microsoft Visual Basic does not support this operator as a means of adding event handlers. It instead requires one of two techniques:  
  
- Use the <xref:System.Windows.UIElement.AddHandler%2A> method, together with an `AddressOf` operator, to reference the event handler implementation.  
  
- Use the `Handles` keyword as part of the event handler definition. This technique is not shown here; see [Visual Basic and WPF Event Handling](visual-basic-and-wpf-event-handling.md).  
  
 [!code-xaml[RoutedEventAddRemoveHandler#XAML](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventAddRemoveHandler/CSharp/default.xaml#xaml)]  
  
 [!code-csharp[RoutedEventAddRemoveHandler#Handler](~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventAddRemoveHandler/CSharp/default.xaml.cs#handler)]
 [!code-vb[RoutedEventAddRemoveHandler#Handler](~/samples/snippets/visualbasic/VS_Snippets_Wpf/RoutedEventAddRemoveHandler/VisualBasic/default.xaml.vb#handler)]  
  
> [!NOTE]
> Adding an event handler in the initially parsed XAML page is much simpler. Within the object element where you want to add the event handler, add an attribute that matches the name of the event that you want to handle. Then specify the value of that attribute as the name of the event handler method that you defined in the code-behind file of the XAML page. For more information, see [XAML in WPF](xaml-in-wpf.md) or [Routed Events Overview](routed-events-overview.md).  
  
## See also

- [Routed Events Overview](routed-events-overview.md)
- [How-to Topics](events-how-to-topics.md)
