---
title: "Weak event patterns"
description: Learn how to use the weak event pattern in Windows Presentation Foundation (WPF) to avoid memory leaks.
ms.date: "04/11/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "weak event pattern implementation [WPF]"
  - "event handlers [WPF], weak event pattern"
  - "IWeakEventListener interface [WPF]"
---
<!-- The acrolinx score was 93 on 04/11/2022-->

# Weak event patterns (WPF .NET)

In applications, it's possible that handlers attached to event sources won't be destroyed in coordination with the listener object that attached the handler to the source. This situation can lead to memory leaks. Windows Presentation Foundation (WPF) introduces a design pattern that can be used to address this issue. The design pattern provides a dedicated manager class for particular events, and implements an interface on listeners for that event. This design pattern is known as the *weak event pattern*.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of routed events, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write Windows Presentation Foundation (WPF) applications.

## Why implement the weak event pattern?

Listening for events can lead to memory leaks. The usual technique for listening to an event is to use language-specific syntax to attach a handler to an event on a source. For example, the C# statement `source.SomeEvent += new SomeEventHandler(MyEventHandler)` or the VB statement `AddHandler source.SomeEvent, AddressOf MyEventHandler`. However, this technique creates a strong reference from the event source to the event listener. Unless the event handler is explicitly unregistered, the object lifetime of the listener will be influenced by the object lifetime of the source. In certain circumstances, you might want the object lifetime of the listener to be controlled by other factors, such as whether it currently belongs to the visual tree of the application. Whenever the object lifetime of the source extends beyond the useful object lifetime of the listener, the listener is kept alive longer than necessary. In this case, the unallocated memory amounts to a memory leak.

The weak event pattern is designed to solve the memory leak problem. The weak event pattern can be used when a listener needs to register for an event, but the listener doesn't explicitly know when to unregister. The weak event pattern can also be used when the object lifetime of the source exceeds the useful object lifetime of the listener. In this case, *useful* is determined by you. The weak event pattern allows the listener to register for and receive the event without affecting the object lifetime characteristics of the listener in any way. In effect, the implied reference from the source doesn't determine whether the listener is eligible for garbage collection. The reference is a weak reference, thus the naming of the weak event pattern and the related APIs. The listener can be garbage collected or otherwise destroyed, and the source can continue without retaining noncollectible handler references to a now destroyed object.

## Who should implement the weak event pattern?

The weak event pattern is primarily relevant to control authors. As a control author, you're largely responsible for the behavior and containment of your control and the impact it has on the applications in which it's inserted. This includes the control's object lifetime behavior, in particular the handling of the described memory leak problem.

Certain scenarios inherently lend themselves to the application of the weak event pattern. One such scenario is data binding. In data binding, it's common for the source object to be independent of the listener object, which is a target of a binding. Many aspects of WPF data binding already have the weak event pattern applied in how the events are implemented.

## How to Implement the weak event pattern

There are four ways to implement the weak event pattern, and each approach uses a different event manager. Select the event manager that best suits your scenario.

- [Existing weak event manager](#use-an-existing-weak-event-manager-class):
  
  Use an existing weak event manager class when the event you want to subscribe to has a corresponding <xref:System.Windows.WeakEventManager>. For a list of weak event managers that are included with WPF, see the inheritance hierarchy in the `WeakEventManager` class. Because the included weak event managers are limited, you'll probably need to choose one of the other approaches.

- [Generic weak event manager](#use-the-generic-weak-event-manager-class):
  
  Use a generic <xref:System.Windows.WeakEventManager%602> when an existing <xref:System.Windows.WeakEventManager> isn't available and you're looking for the easiest way to implement weak events. However, the generic `WeakEventManager<TEventSource,TEventArgs>` is less efficient than the existing or custom weak event manager because it uses reflection to discover the event from its name. Also, the code needed to register the event using the generic `WeakEventManager<TEventSource,TEventArgs>` is more verbose than using an existing or custom `WeakEventManager`.

- [Custom weak event manager](#create-a-custom-weak-event-manager-class):
  
  Create a custom <xref:System.Windows.WeakEventManager> when an existing `WeakEventManager` isn't available and efficiency is crucial. Although more efficient than a generic `WeakEventManager`, a custom `WeakEventManager` requires you to write more upfront code.

- [Third-party weak event manager](https://www.nuget.org/packages?q=weak+event+manager&prerel=false):
  
  Use a third-party weak event manager when you need functionality that's not provided by the other approaches. NuGet has some [weak event managers](https://www.nuget.org/packages?q=weak+event+manager&prerel=false). Many WPF frameworks also support the pattern. For example, see [Prism's documentation on loosely coupled event subscription](https://github.com/PrismLibrary/Prism-Documentation/blob/master/docs/wpf/legacy/Communication.md#subscribing-to-events).

The following sections describe how to implement the weak event pattern through use of the different event manager types. For the generic and custom weak event manager examples, the event to subscribe to has the following characteristics.

- The event name is `SomeEvent`.
- The event is raised by the `SomeEventSource` class.
- The event handler has type `EventHandler<SomeEventArgs>`.
- The event passes a parameter of type `SomeEventArgs` to the event handlers.

### Use an existing weak event manager class

01. Find an existing weak event manager. For a list of weak event managers included with WPF, see the inheritance hierarchy of the <xref:System.Windows.WeakEventManager> class.

01. Use the new weak event manager instead of the normal event hookup.

    For example, if your code uses the following pattern to subscribe to an event:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="AddExistingStrongEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="AddExistingStrongEventHandler":::

    Change it to the following pattern:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="AddExistingWeakEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="AddExistingWeakEventHandler":::

    Similarly, if your code uses the following pattern to unsubscribe from an event:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="RemoveExistingStrongEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="RemoveExistingStrongEventHandler":::

    Change it to the following pattern:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="RemoveExistingWeakEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="RemoveExistingWeakEventHandler":::

### Use the generic weak event manager class

Use the generic <xref:System.Windows.WeakEventManager%602> class instead of the normal event hookup.

When you use `WeakEventManager<TEventSource,TEventArgs>` to register event listeners, you supply the event source and <xref:System.EventArgs> type as the type parameters to the class. Call <xref:System.Windows.WeakEventManager%602.AddHandler%2A> as shown in the following code:

:::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="AddGenericWeakEventHandler":::
:::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="AddGenericWeakEventHandler":::

### Create a custom weak event manager class

01. Copy the following class template to your project. The following class inherits from the <xref:System.Windows.WeakEventManager> class:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/WeakEventManagerTemplate.cs" id="WeakEventManagerTemplate":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/WeakEventManagerTemplate.vb" id="WeakEventManagerTemplate":::

01. Rename `SomeEventWeakEventManager`, `SomeEvent`, `SomeEventSource`, and `SomeEventArgs` to match your event name.

01. Set the [access modifiers](/dotnet/csharp/language-reference/keywords/access-modifiers) for the weak event manager class to match the accessibility of the event it manages.

01. Use the new weak event manager instead of the normal event hookup.

    For example, if your code uses the following pattern to subscribe to an event:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="AddCustomStrongEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="AddCustomStrongEventHandler":::

    Change it to the following pattern:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="AddCustomWeakEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="AddCustomWeakEventHandler":::

    Similarly, if your code uses the following pattern to unsubscribe to an event:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="RemoveCustomStrongEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="RemoveCustomStrongEventHandler":::

    Change it to the following pattern:

    :::code language="csharp" source="./snippets/weak-event-patterns/csharp/MainWindow.xaml.cs" id="RemoveCustomWeakEventHandler":::
    :::code language="vb" source="./snippets/weak-event-patterns/vb/MainWindow.xaml.vb" id="RemoveCustomWeakEventHandler":::

## See also

- <xref:System.Windows.WeakEventManager>
- <xref:System.Windows.IWeakEventListener>
- [Routed events overview](routed-events-overview.md)
- [Data binding overview](../data/index.md)
