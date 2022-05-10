---
title: "How to add an event handler using code"
description: Learn how to add an event handler in code-behind for an element in Windows Presentation Foundation (WPF).
ms.date: "02/01/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "event handlers [WPF], adding"
  - "XAML [WPF], adding event handlers"
---
<!-- The acrolinx score was 99 on 02/01/2021-->

# How to add an event handler using code (WPF .NET)

You can assign an event handler to an element in Windows Presentation Foundation (WPF) using markup or code-behind. Although it's customary to assign an event handler in Extensible Application Markup Language (XAML), sometimes you might have to assign an event handler in code-behind. For instance, use code when:

- You assign an event handler to an element after the markup page that contains the element loads.
- You add an element and assign its event handler after the markup page that will contain the element loads.
- You define the element tree for your application entirely in code.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of routed events, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write Windows Presentation Foundation (WPF) applications.

## Syntax for event handler assignment

C# supports event handler assignment using:

- The `+=` operator, which is also used in the common language runtime (CLR) event handling model.
- The <xref:System.Windows.UIElement.AddHandler%2A?displayProperty=nameWithType> method.

VB supports event handler assignment using:

- The [AddHandler](/dotnet/visual-basic/language-reference/statements/addhandler-statement) statement with the [AddressOf](/dotnet/visual-basic/language-reference/operators/addressof-operator) operator, which is also used in the CLR event handling model.
- The [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword in the event handler definition. For more information, see [Visual Basic and WPF event handling](visual-basic-and-wpf-event-handling.md).
- The <xref:System.Windows.UIElement.AddHandler%2A?displayProperty=nameWithType> method, together with the `AddressOf` operator to reference the event handler.

## Example

The following example uses XAML to define a <xref:System.Windows.Controls.Button> named `ButtonCreatedByXaml` and to assign the `ButtonCreatedByXaml_Click` method as its <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler. `Click` is a built-in routed event for buttons that derive from <xref:System.Windows.Controls.Primitives.ButtonBase>.

:::code language="xaml" source="./snippets/how-to-add-an-event-handler-using-code/csharp/MainWindow.xaml" id="ButtonCreatedByXaml":::

The example uses code-behind to implement the `ButtonCreatedByXaml_Click` and `ButtonCreatedByCode_Click` handlers, and to assign the `ButtonCreatedByCode_Click` handler to the `ButtonCreatedByCode` and `StackPanel1` elements. Event handler methods can only be implemented in code-behind.

:::code language="csharp" source="./snippets/how-to-add-an-event-handler-using-code/csharp/MainWindow.xaml.cs" id="ButtonEventHandlers":::
:::code language="vb" source="./snippets/how-to-add-an-event-handler-using-code/vb/MainWindow.xaml.vb" id="ButtonEventHandlers":::

When `ButtonCreatedByXaml` is clicked and its event handler runs, `ButtonCreatedByXaml_Click` programmatically:

1. Adds a new button named `ButtonCreatedByCode` to the already constructed XAML element tree.
1. Specifies properties for the new button, such as the name, content, and background color.
1. Assigns the `ButtonCreatedByCode_Click` event handler to `ButtonCreatedByCode`.
1. Assigns the same `ButtonCreatedByCode_Click` event handler to `StackPanel1`.

When `ButtonCreatedByCode` is clicked:

1. The <xref:System.Windows.Controls.Primitives.ButtonBase.Click> routed event is raised on `ButtonCreatedByCode`.
1. The `ButtonCreatedByCode_Click` event handler assigned to `ButtonCreatedByCode` is triggered.
1. The `Click` routed event traverses up the element tree to `StackPanel1`.
1. The `ButtonCreatedByCode_Click` event handler assigned to `StackPanel1` is triggered.
1. The `Click` routed event continues up the element tree potentially triggering other `Click` event handlers assigned to other traversed elements.

The `ButtonCreatedByCode_Click` event handler obtains the following information about the event that triggered it:

- The [sender](xref:System.Windows.RoutedEventHandler) object, which is the element that the event handler is assigned to. The `sender` will be `ButtonCreatedByCode` the first time the handler runs, and `StackPanel1` the second time.
- The <xref:System.Windows.RoutedEventArgs.Source?displayProperty=nameWithType> object, which is the element that originally raised the event. In this example, the `Source` is always `ButtonCreatedByCode`.

> [!NOTE]
> A key difference between a routed event and a CLR event is that a routed event traverses the element tree, looking for handlers, whereas a CLR event doesn't traverse the element tree and handlers can only attach to the source object that raised the event. As a result, a routed event `sender` can be any traversed element in the element tree.

For more information on how to create and handle routed events, see [How to create a custom routed event](how-to-create-a-custom-routed-event.md) and [Handle a routed event](/dotnet/desktop/wpf/advanced/how-to-handle-a-routed-event?view=netframeworkdesktop-4.8&preserve-view=true).

## See also

- [Routed events overview](routed-events-overview.md)
- [XAML in WPF](../xaml/index.md)
