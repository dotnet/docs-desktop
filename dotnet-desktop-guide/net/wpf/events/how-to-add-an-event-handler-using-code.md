---
title: "How to add an event handler using code"
description: Learn how to add an event handler in code-behind for an element in Windows Presentation Foundation (WPF).
ms.date: "01/24/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "event handlers [WPF], adding"
  - "XAML [WPF], adding event handlers"
---
<!-- The acrolinx score was 97 on 01/24/2021-->

# How to add an event handler using code (WPF .NET)

You can assign an event handler to an element in Windows Presentation Foundation (WPF) using markup or code-behind. Although it's customary to assign an event handler in Extensible Application Markup Language (XAML), sometimes you might have to assign an event handler in code-behind. For instance, when:

- You assign an event handler to an element after the markup page that contains the element loads.
- You add an element and assign its event handler after the markup page that will contain the element loads.
- You define the element tree for your application entirely in code.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Syntax for event handler assignment

C# supports event handler assignment using:

- The `+=` operator, which is also used in the common language runtime (CLR) event handling model.
- The <xref:System.Windows.UIElement.AddHandler%2A> method.

VB supports event handler assignment using:

- The [AddHandler](/dotnet/visual-basic/language-reference/statements/addhandler-statement) statement with the [AddressOf](/dotnet/visual-basic/language-reference/operators/addressof-operator) operator, which is also used in the CLR event handling model.
- The [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword in the event handler definition. For more information, see [Visual Basic and WPF event handling](/dotnet/desktop/wpf/advanced/visual-basic-and-wpf-event-handling?view=netframeworkdesktop-4.8&preserve-view=true).
- The <xref:System.Windows.UIElement.AddHandler%2A?displayProperty=nameWithType> method, together with the [AddressOf](/dotnet/visual-basic/language-reference/operators/addressof-operator) operator to reference the event handler.

## Example

The following example has a <xref:System.Windows.Controls.Button> named `ButtonCreatedByXaml` defined in XAML. The button's XAML attribute `Click="ButtonCreatedByXaml_Click"` specifies the event handler for the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event. That attribute is in the form of `<event name>="<event handler name>"`.

:::code language="xaml" source="./snippets/how-to-add-an-event-handler-using-code/csharp/MainWindow.xaml" id="ButtonCreatedByXaml":::

:::code language="csharp" source="./snippets/how-to-add-an-event-handler-using-code/csharp/MainWindow.xaml.cs" id="ButtonEventHandlers":::
:::code language="vb" source="./snippets/how-to-add-an-event-handler-using-code/vb/MainWindow.xaml.vb" id="ButtonEventHandlers":::

When the `ButtonCreatedByXaml` button is clicked and its event handler runs, `ButtonCreatedByXaml_Click` programmatically:

- Adds a new button named `ButtonCreatedByCode` to the already constructed XAML element tree.
- Specifies properties for the new button, such as the button content and background color.
- Assigns the `ButtonCreatedByCode_Click` event handler to the new button.

If the new button `ButtonCreatedByCode` is clicked, its `ButtonCreatedByCode_Click` event handler will run.

For more information on assigning event handlers in code-behind, see [How to create a custom routed event](/dotnet/desktop/wpf/advanced/how-to-create-a-custom-routed-event?view=netframeworkdesktop-4.8&preserve-view=true).

## See also

- [Routed events overview](/dotnet/desktop/wpf/advanced/routed-events-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [XAML in WPF](/dotnet/desktop/wpf/advanced/xaml-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
