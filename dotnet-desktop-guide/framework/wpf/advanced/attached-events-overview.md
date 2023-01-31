---
title: "Attached Events Overview"
description: Learn about using attached events with Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
ms.topic: overview
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "handling attached events [WPF]"
  - "defining attached events as routed events [WPF]"
  - "attached events [WPF], scenarios for"
  - "attached events vs. routed events [WPF]"
  - "backing attached events with routed events [WPF]"
  - "attached events [WPF], definition"
ms.assetid: 2c40eae3-80e4-4a45-ae09-df6c9ab4d91e
---
# Attached Events Overview

Extensible Application Markup Language (XAML) defines a language component and type of event called an *attached event*. The concept of an attached event enables you to add a handler for a particular event to an arbitrary element rather than to an element that actually defines or inherits the event. In this case, neither the object potentially raising the event nor the destination handling instance defines or otherwise "owns" the event.  

<a name="prerequisites"></a>

## Prerequisites  

 This topic assumes that you have read [Routed Events Overview](routed-events-overview.md) and [XAML in WPF](xaml-in-wpf.md).  
  
<a name="Syntax"></a>

## Attached Event Syntax  

 Attached events have a XAML syntax and a coding pattern that must be used by the backing code in order to support the attached event usage.  
  
 In XAML syntax, the attached event is specified not just by its event name, but by its owning type plus the event name, separated by a dot (.). Because the event name is qualified with the name of its owning type, the attached event syntax allows any attached event to be attached to any element that can be instantiated.  
  
 For example, the following is the XAML syntax for attaching a handler for a custom `NeedsCleaning` attached event:  
  
 [!code-xaml[WPFAquariumSln#AE](~/samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquarium/Window1.xaml#ae)]  
  
 Note the `aqua:` prefix; the prefix is necessary in this case because the attached event is a custom event that comes from a custom mapped xmlns.  
  
<a name="WPFImplements"></a>

## How WPF Implements Attached Events

In WPF, attached events are backed by a <xref:System.Windows.RoutedEvent> field and are routed through the tree after they are raised. Typically, the source of the attached event (the object that raises the event) is a system or service source, and the object that runs the code that raises the event is therefore not a direct part of the element tree.  
  
<a name="Scenarios"></a>

## Scenarios for Attached Events  

 In WPF, attached events are present in certain feature areas where there is service-level abstraction, such as for the events enabled by the static <xref:System.Windows.Input.Mouse> class or the <xref:System.Windows.Controls.Validation> class. Classes that interact with or use the service can either use the event in the attached event syntax, or they can choose to surface the attached event as a routed event that is part of how the class integrates the capabilities of the service.  
  
 Although WPF defines a number of attached events, the scenarios where you will either use or handle the attached event directly are very limited. Generally, the attached event serves an architecture purpose, but is then forwarded to a non-attached (backed with a CLR event "wrapper") routed event.  
  
 For instance, the underlying attached event <xref:System.Windows.Input.Mouse.MouseDown?displayProperty=nameWithType> can more easily be handled on any given <xref:System.Windows.UIElement> by using <xref:System.Windows.UIElement.MouseDown> on that <xref:System.Windows.UIElement> rather than dealing with attached event syntax either in XAML or code. The attached event serves a purpose in the architecture because it allows for future expansion of input devices. The hypothetical device would only need to raise <xref:System.Windows.Input.Mouse.MouseDown?displayProperty=nameWithType> in order to simulate mouse input, and would not need to derive from <xref:System.Windows.Input.Mouse> to do so. However, this scenario involves code handling of the events, and XAML handling of the attached event is not relevant to this scenario.  
  
<a name="Handling"></a>

## Handling an Attached Event in WPF  

 The process for handling an attached event, and the handler code that you will write, is basically the same as for a routed event.  
  
 In general, a WPF attached event is not very different from a WPF routed event. The differences are how the event is sourced and how it is exposed by a class as a member (which also affects the XAML handler syntax).  
  
 However, as noted earlier, the existing WPF attached events are not particularly intended for handling in WPF. More often, the purpose of the event is to enable a composited element to report a state to a parent element in compositing, in which case the event is usually raised in code and also relies on class handling in the relevant parent class. For instance, items within a <xref:System.Windows.Controls.Primitives.Selector> are expected to raise the attached <xref:System.Windows.Controls.Primitives.Selector.Selected> event, which is then class handled by the <xref:System.Windows.Controls.Primitives.Selector> class and then potentially converted by the <xref:System.Windows.Controls.Primitives.Selector> class into a different routed event, <xref:System.Windows.Controls.Primitives.Selector.SelectionChanged>. For more information on routed events and class handling, see [Marking Routed Events as Handled, and Class Handling](marking-routed-events-as-handled-and-class-handling.md).  
  
<a name="Custom"></a>

## Defining Your Own Attached Events as Routed Events  

 If you are deriving from common WPF base classes, you can implement your own attached events by including certain pattern methods in your class and by using utility methods that are already present on the base classes.  
  
 The pattern is as follows:  
  
- A method **Add*EventName*Handler** with two parameters. The first parameter is the instance to which the event handler is added. The second parameter is the event handler to add. The method must be `public` and `static`, with no return value.  
  
- A method **Remove*EventName*Handler** with two parameters. The first parameter is the instance from which the event handler is removed. The second parameter is the event handler to remove. The method must be `public` and `static`, with no return value.  
  
 The **Add*EventName*Handler** accessor method facilitates XAML processing when attached event handler attributes are declared on an element. The **Add*EventName*Handler** and **Remove*EventName*Handler** methods also enable code access to the event handler store for the attached event.  
  
 This general pattern is not yet precise enough for practical implementation in a framework, because any given XAML reader implementation might have different schemes for identifying underlying events in the supporting language and architecture. This is one of the reasons that WPF implements attached events as routed events; the identifier to use for an event (<xref:System.Windows.RoutedEvent>) is already defined by the WPF event system. Also, routing an event is a natural implementation extension on the XAML language-level concept of an attached event.  
  
 The **Add*EventName*Handler** implementation for a WPF attached event consists of calling the <xref:System.Windows.UIElement.AddHandler%2A> with the routed event and handler as arguments.  
  
 This implementation strategy and the routed event system in general restrict handling for attached events to either <xref:System.Windows.UIElement> derived classes or <xref:System.Windows.ContentElement> derived classes, because only those classes have <xref:System.Windows.UIElement.AddHandler%2A> implementations.  
  
 For example, the following code defines the `NeedsCleaning` attached event on the owner class `Aquarium`, using the WPF attached event strategy of declaring the attached event as a routed event.  
  
 [!code-csharp[WPFAquariumSln#AECode](~/samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#aecode)]
 [!code-vb[WPFAquariumSln#AECode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#aecode)]  
  
 Note that the method used to establish the attached event identifier field, <xref:System.Windows.EventManager.RegisterRoutedEvent%2A>, is actually the same method that is used to register a non-attached routed event. Attached events and routed events all are registered to a centralized internal store. This event store implementation enables the "events as an interface" conceptual consideration that is discussed in [Routed Events Overview](routed-events-overview.md).  
  
<a name="Raising"></a>

## Raising a WPF Attached Event  

 You do not typically need to raise existing WPF-defined attached events from your code. These events follow the general "service" conceptual model, and service classes such as <xref:System.Windows.Input.InputManager> are responsible for raising the events.  
  
 However, if you are defining a custom attached event based on the WPF model of basing attached events on <xref:System.Windows.RoutedEvent>, you can use <xref:System.Windows.UIElement.RaiseEvent%2A> to raise an attached event from any <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement>. Raising a routed event (attached or not) requires that you declare a particular element in the element tree as the event source; that source is reported as the <xref:System.Windows.UIElement.RaiseEvent%2A> caller. Determining which element is reported as the source in the tree is your service's responsibility  
  
## See also

- [Routed Events Overview](routed-events-overview.md)
- [XAML Syntax In Detail](xaml-syntax-in-detail.md)
- [XAML and Custom Classes for WPF](xaml-and-custom-classes-for-wpf.md)
