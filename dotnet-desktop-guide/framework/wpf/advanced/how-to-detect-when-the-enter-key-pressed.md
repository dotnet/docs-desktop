---
title: "How to: Detect When the Enter Key Pressed"
description: Detect when the Enter key is selected on the keyboard in Windows Presentation Foundation. This example consists of XAML and a code-behind file.
ms.date: 07/16/2024
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Enter key [WPF], detecting"
  - "keys [WPF], Enter"
ms.assetid: a66f39d2-ef4a-43a5-b454-a4ea0fe88655
# TODO:
# When upgrading this article to .NET, add more examples such as doing a global handler, attached behavior, input command, etc>
#
---
# How to: Detect When the Enter Key Pressed

This example shows how to detect when the <xref:System.Windows.Input.Key.Enter> key is pressed on the keyboard.

This example consists of a Extensible Application Markup Language (XAML) file and a code-behind file.

## Example

When the user presses the <xref:System.Windows.Input.Key.Enter> key in the <xref:System.Windows.Controls.TextBox>, the input in the text box appears in another area of the user interface (UI).

The following XAML creates the user interface, which consists of a <xref:System.Windows.Controls.StackPanel>, a <xref:System.Windows.Controls.TextBlock>, and a <xref:System.Windows.Controls.TextBox>.

:::code language="xaml" source="./snippets/how-to-detect-when-the-enter-key-pressed/csharp/MainWindow.xaml" id="example":::

The following code behind creates the <xref:System.Windows.UIElement.KeyDown> event handler.  If the key that is pressed is the <xref:System.Windows.Input.Key.Enter> key, a message is displayed in the <xref:System.Windows.Controls.TextBlock>.

:::code language="csharp" source="./snippets/how-to-detect-when-the-enter-key-pressed/csharp/MainWindow.xaml.cs" id="handler":::
:::code language="vb" source="./snippets/how-to-detect-when-the-enter-key-pressed/vb/MainWindow.xaml.vb" id="handler":::

## See also

- [Input Overview](input-overview.md)
- [Routed Events Overview](routed-events-overview.md)
