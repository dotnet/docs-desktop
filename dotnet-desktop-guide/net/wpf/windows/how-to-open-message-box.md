---
title: How to display a message box
description: Learn about how to show a message box in Windows Foundation Presentation (WPF). Message boxes prompt users for a response, allowing the calling window to process that response.
ms.date: 03/15/2021
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "message boxes [WPF]"
---

# How to open a message box (WPF .NET)

A _message box_ is a dialog box that is used to quickly display information and optionally allow users to make decisions. Access to the message box is provided by the <xref:System.Windows.MessageBox> class. A message box is displayed _modally_. And the code that displays the message box is paused until the user closes the message box either with the close button or a response button.

The following illustration demonstrates the parts of a message box:

<a name="diagram"></a>
:::image type="content" source="media/how-to-open-message-box/diagram.png" alt-text="A figure that shows the parts of a message box for WPF.":::

- A title bar with a caption (1).
- A close button (2).
- Icon (3).
- Message displayed to the user (4).
- Response buttons (5).

For presenting or gathering complex data, a dialog box might be more suitable than a message box. For more information, see [Dialog boxes overview](dialog-boxes-overview.md).

## Display a message box

To create a message box, you use the <xref:System.Windows.MessageBox> class. The <xref:System.Windows.MessageBox.Show%2A?displayProperty=nameWithType> method lets you configure the message box text, title, icon, and buttons, shown in the following code:

:::code language="csharp" source="snippets/how-to-open-message-box/csharp/Window1.xaml.cs" id="YesNoCancel":::
:::code language="vb" source="snippets/how-to-open-message-box/vb/Window1.xaml.vb" id="YesNoCancel":::

The <xref:System.Windows.MessageBox.Show%2A?displayProperty=nameWithType> method overloads provide ways to configure the message box. These options include:

- Title bar **caption**
- Message **icon**
- Message **text**
- Response **buttons**

Here are some more examples of using a message box.

- Display an alert.

  :::code language="csharp" source="snippets/how-to-open-message-box/csharp/Window1.xaml.cs" id="AlertSimple":::
  :::code language="vb" source="snippets/how-to-open-message-box/vb/Window1.xaml.vb" id="AlertSimple":::

  The previous code displays a message box like the following image:

  :::image type="content" source="media/how-to-open-message-box/alert-simple.png" alt-text="A simple message box for WPF that has no options configured.":::

  It's a good idea to use the options provided by the message box class. Using the same alert as before, set more options to make it more visually appealing:

  :::code language="csharp" source="snippets/how-to-open-message-box/csharp/Window1.xaml.cs" id="Alert":::
  :::code language="vb" source="snippets/how-to-open-message-box/vb/Window1.xaml.vb" id="Alert":::

  The previous code displays a message box like the following image:

  :::image type="content" source="media/how-to-open-message-box/alert.png" alt-text="A warning message box for WPF that has an icon, caption, and text.":::

- Display a warning.

  :::code language="csharp" source="snippets/how-to-open-message-box/csharp/Window1.xaml.cs" id="Warning":::
  :::code language="vb" source="snippets/how-to-open-message-box/vb/Window1.xaml.vb" id="Warning":::

  The previous code displays a message box like the following image:

  :::image type="content" source="media/how-to-open-message-box/warning.png" alt-text="A simple message box for WPF that has displays a warning icon.":::

- Ask the user a question.

  :::code language="csharp" source="snippets/how-to-open-message-box/csharp/Window1.xaml.cs" id="Prompt":::
  :::code language="vb" source="snippets/how-to-open-message-box/vb/Window1.xaml.vb" id="Prompt":::

  The previous code displays a message box like the following image:

  :::image type="content" source="media/how-to-open-message-box/prompt.png" alt-text="A simple message box for WPF that prompts the user with a yes or no question.":::

## Handle a message box response

The <xref:System.Windows.MessageBox.Show%2A?displayProperty=nameWithType> method displays the message box and returns a result. The result indicates how the user closed the message box:

:::code language="csharp" source="snippets/how-to-open-message-box/csharp/Window1.xaml.cs" id="MessageBoxShow":::
:::code language="vb" source="snippets/how-to-open-message-box/vb/Window1.xaml.vb" id="MessageBoxShow":::

When a user presses the buttons at the bottom of the message box, the corresponding <xref:System.Windows.MessageBoxResult> is returned. However, if the user presses the <kbd>ESC</kbd> key or presses the **Close** button (#2 in the [message box illustration](#diagram)), the result of the message box varies based on the button options:

| Button options | <kbd>ESC</kbd> or **Close** button result |
|----------------|-------------------------------------------|
| `OK`           | `OK`                                      |
| `OKCancel`     | `Cancel`                                  |
| `YesNo`        | <kbd>ESC</kbd> keyboard shortcut and **Close** button disabled. User must press **Yes** or **No**. |
| `YesNoCancel`  | `Cancel`                                  |

For more information on using message boxes, see <xref:System.Windows.MessageBox> and the [MessageBox sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/MessageBox).

## See also

- [Overview of WPF windows](index.md)
- [Dialog boxes overview](dialog-boxes-overview.md)
- [How to display a common dialog box](how-to-open-common-system-dialog-box.md)
- [MessageBox sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/MessageBox)
- <xref:System.Windows.MessageBox?displayProperty=fullName>
- <xref:System.Windows.MessageBox.Show%2A?displayProperty=fullName>
- <xref:System.Windows.MessageBoxResult?displayProperty=fullName>
