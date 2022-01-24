---
title: "How to add an event handler using code"
description: Learn how to add an event handler in code behind for an element in Windows Presentation Foundation (WPF).
ms.date: "01/24/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "event handlers [WPF], adding"
  - "XAML [WPF], adding event handlers"
---
<!-- The acrolinx score was 77 on 01/24/2021-->

# How to add an event handler using code (WPF .NET)

This article describes how to add an event handler in code behind for an Extensible Application Markup Language (XAML) element in Windows Presentation Foundation (WPF). Adding an event handler in XAML markup is much simpler, though not always feasible. Add an event handler in code behind when:

- You want to add an event handler to a XAML element at some point in time after the markup page containing the element is loaded.
- You want to add an XAML element and its event handler at some point after the markup page that will contain the element is loaded.
- You're defining the element tree for your application entirely in code behind, not XAML.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Example

The following example uses code to add a new <xref:System.Windows.Controls.Button> and its event handler to an already constructed element tree.

:::code language="csharp"
C# supports assigning an event handler to an element using:

- The `+=` operator, as used in the CLR event handling model.
- The <xref:System.Windows.UIElement.AddHandler%2A> method. :::

:::code language="vb"
VB supports assigning an event handler to an element using:

- The <xref:System.Windows.UIElement.AddHandler%2A> method together with the `AddressOf` operator to reference the event handler.
- The `Handles` keyword in the event handler definition. For more information, see [Visual Basic and WPF event handling](/dotnet/desktop/wpf/advanced/visual-basic-and-wpf-event-handling?view=netframeworkdesktop-4.8&preserve-view=true). :::

<!-->:::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventAddRemoveHandler/CSharp/default.xaml" id="xaml":::

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_Wpf/RoutedEventAddRemoveHandler/CSharp/default.xaml.cs" id="handler":::
:::code language="vb" source="~/samples/snippets/visualbasic/VS_Snippets_Wpf/RoutedEventAddRemoveHandler/VisualBasic/default.xaml.vb" id="handler":::-->

> [!NOTE]
> Implementing an event handler in XAML markup is simpler than through code behind. For more information, see [XAML in WPF](xaml-in-wpf.md) or [Routed events overview](routed-events-overview.md).

## See also

- [Routed events overview](/dotnet/desktop/wpf/advanced/routed-events-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [How-to Topics](/dotnet/desktop/wpf/advanced/events-how-to-topics?view=netframeworkdesktop-4.8&preserve-view=true)
