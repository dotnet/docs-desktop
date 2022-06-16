---
title: "How to create a custom routed event"
description: Learn how to implement a custom routed event for an element in Windows Presentation Foundation (WPF).
ms.date: "02/02/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "routed events [WPF], creating"
  - "events [WPF], routing"
---
<!-- The acrolinx score was 93 on 02/02/2021-->

# How to create a custom routed event (WPF .NET)

Windows Presentation Foundation (WPF) application developers and component authors can create custom routed events to extend the functionality of common language runtime (CLR) events. For information on routed event capabilities, see [Why use routed events](routed-events-overview.md#why-use-routed-events). This article covers the basics of creating a custom routed event.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of routed events, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write Windows Presentation Foundation (WPF) applications.

## Routed event steps

The basic steps to create a routed event are:

1. Register a <xref:System.Windows.RoutedEvent> using the <xref:System.Windows.EventManager.RegisterRoutedEvent%2A> method.

1. The registration call returns a `RoutedEvent` instance, known as a routed event identifier, which holds the registered event name, [routing strategy](routed-events-overview.md#routing-strategies), and other event details. Assign the identifier to a static readonly field. By convention:
    - The identifier for a routed event with a [bubbling](<xref:System.Windows.RoutingStrategy.Bubble>) strategy is named `<event name>Event`. For example, if the event name is `Tap` then the identifier should be named `TapEvent`.
    - The identifier for a routed event with a [tunneling](<xref:System.Windows.RoutingStrategy.Tunnel>) strategy is named `Preview<event name>Event`. For example, if the event name is `Tap` then the identifier should be named `PreviewTapEvent`.

1. Define CLR [add](<xref:System.Windows.UIElement.AddHandler%2A>) and [remove](<xref:System.Windows.UIElement.RemoveHandler%2A>) event accessors. Without CLR event accessors, you'll only be able to add or remove event handlers through direct calls to the <xref:System.Windows.UIElement.AddHandler%2A?displayProperty=nameWithType> and <xref:System.Windows.UIElement.RemoveHandler%2A?displayProperty=nameWithType> methods. With CLR event accessors, you gain these event handler assignment mechanisms:

    - For Extensible Application Markup Language (XAML), you can use attribute syntax to add event handlers.
    - For C#, you can use the `+=` and `-=` operators to add or remove event handlers.
    - For VB, you can use the [AddHandler](/dotnet/visual-basic/language-reference/statements/addhandler-statement) and [RemoveHandler](/dotnet/visual-basic/language-reference/statements/removehandler-statement) statements to add or remove event handlers.

1. Add custom logic for triggering your routed event. For example, your logic might trigger the event based on user-input and application state.

## Example

The following example implements the `CustomButton` class in a custom control library. The `CustomButton` class, which derives from <xref:System.Windows.Controls.Button>:

1. Registers a <xref:System.Windows.RoutedEvent> named `ConditionalClick` using the <xref:System.Windows.EventManager.RegisterRoutedEvent%2A> method, and specifies the [bubbling](<xref:System.Windows.RoutingStrategy.Bubble>) strategy during registration.
1. Assigns the `RoutedEvent` instance returned from the registration call to a static readonly field named `ConditionalClickEvent`.
1. Defines CLR [add](<xref:System.Windows.UIElement.AddHandler%2A>) and [remove](<xref:System.Windows.UIElement.RemoveHandler%2A>) event accessors.
1. Adds custom logic to raise the custom routed event when the `CustomButton` is clicked and an external condition applies. Although the example code raises the `ConditionalClick` routed event from within the overridden `OnClick` virtual method, you can raise your event any way you choose.

:::code language="csharp" source="./snippets/how-to-create-a-custom-routed-event/WpfControlLibraryCsharp/CustomButton.cs" id="CustomButton":::
:::code language="vb" source="./snippets/how-to-create-a-custom-routed-event/WpfControlLibraryVb/CustomButton.vb" id="CustomButton":::

The example includes a separate WPF application that uses XAML markup to add an instance of the `CustomButton` to a <xref:System.Windows.Controls.StackPanel>, and to assign the `Handler_ConditionalClick` method as the `ConditionalClick` event handler for the `CustomButton` and `StackPanel1` elements.

:::code language="xaml" source="./snippets/how-to-create-a-custom-routed-event/csharp/MainWindow.xaml" id="MainWindowXaml":::

In code-behind, the WPF application defines the `Handler_ConditionalClick` event handler method. Event handler methods can only be implemented in code-behind.

:::code language="csharp" source="./snippets/how-to-create-a-custom-routed-event/csharp/MainWindow.xaml.cs" id="EventHandler":::
:::code language="vb" source="./snippets/how-to-create-a-custom-routed-event/vb/MainWindow.xaml.vb" id="EventHandler":::

When `CustomButton` is clicked:

1. The `ConditionalClick` routed event is raised on `CustomButton`.
1. The `Handler_ConditionalClick` event handler attached to `CustomButton` is triggered.
1. The `ConditionalClick` routed event traverses up the element tree to `StackPanel1`.
1. The `Handler_ConditionalClick` event handler attached to `StackPanel1` is triggered.
1. The `ConditionalClick` routed event continues up the element tree potentially triggering other `ConditionalClick` event handlers attached to other traversed elements.

The `Handler_ConditionalClick` event handler obtains the following information about the event that triggered it:

- The [sender](xref:System.Windows.RoutedEventHandler) object, which is the element that the event handler is attached to. The `sender` will be `CustomButton` the first time the handler runs, and `StackPanel1` the second time.
- The <xref:System.Windows.RoutedEventArgs.Source?displayProperty=nameWithType> object, which is the element that originally raised the event. In this example, the `Source` is always `CustomButton`.

> [!NOTE]
> A key difference between a routed event and a CLR event is that a routed event traverses the element tree, looking for handlers, whereas a CLR event doesn't traverse the element tree and handlers can only attach to the source object that raised the event. As a result, a routed event `sender` can be any traversed element in the element tree.

You can create a tunneling event the same way as a bubbling event, except you'll set the routing strategy in the event registration call to <xref:System.Windows.RoutingStrategy.Tunnel>. For more information on tunneling events, see [WPF input events](routed-events-overview.md#wpf-input-events).

## See also

- [Routed events overview](routed-events-overview.md)
- [Input overview](/dotnet/desktop/wpf/advanced/input-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [Control authoring overview](/dotnet/desktop/wpf/controls/control-authoring-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [Handle a routed event](/dotnet/desktop/wpf/advanced/how-to-handle-a-routed-event?view=netframeworkdesktop-4.8&preserve-view=true).
