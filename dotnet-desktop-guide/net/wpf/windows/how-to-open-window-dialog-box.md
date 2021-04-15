---
title: How to open a window
description: Learn about how to show a window or dialog box in Windows Foundation Presentation (WPF). You'll also learn how to handle common scenarios around managing a window or dialog box.
ms.date: "03/12/2021"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "modeless dialog boxes [WPF]"
  - "modal dialog boxes [WPF]"
  - "dialog boxes [WPF]"
  - "message boxes [WPF]"
---

# How to open a window or dialog box (WPF .NET)

You can create your own windows and display them in Windows Presentation Foundation (WPF). In this article, you'll learn how to display modal and modeless windows and dialogs.

Conceptually, a window and a dialog box are the same thing: they're displayed to a user to provide information or interaction. They're both "window" objects. The design of the window and the way it's used, is what makes a dialog box. A dialog box is generally small in size and requires the user to respond to it. For more information, see [Overview of WPF windows](index.md) and [Dialog boxes overview](dialog-boxes-overview.md).

If you're interested in opening operating system dialog boxes, see [How to open a common dialog box](how-to-open-common-system-dialog-box.md).

## Open as modal

When a modal window is opened, it generally represents a dialog box. WPF restricts interaction to the modal window, and the code that opened the window pauses until the window closes. This mechanism provides an easy way for you to prompt the user with data and wait for their response.

Use the <xref:System.Windows.Window.ShowDialog%2A> method to open a window. The following code instantiates the window, and opens it modally. The code opening the window pauses, waiting for the window to be closed:

:::code language="csharp" source="snippets/how-to-open-window-dialog-box/csharp/Window1.xaml.cs" id="ShowDialog":::
:::code language="vb" source="snippets/how-to-open-window-dialog-box/vb/Window1.xaml.vb" id="ShowDialog":::

> [!IMPORTANT]
> Once a window is closed, the same object instance can't be used to reopen the window.

For more information about how to handle the user response to a dialog box, see [Dialog boxes overview: Processing the response](dialog-boxes-overview.md#processing-the-response).

## Open as modeless

Opening a window modeless means displaying it as a normal window. The code that opens the window continues to run as the window becomes visible. You can focus and interact with all modeless windows displayed by your application, without restriction.

Use the <xref:System.Windows.Window.Show%2A> method to open a window. The following code instantiates the window, and opens it modeless. The code opening the window continues to run:

:::code language="csharp" source="snippets/how-to-open-window-dialog-box/csharp/Window1.xaml.cs" id="ShowNormal":::
:::code language="vb" source="snippets/how-to-open-window-dialog-box/vb/Window1.xaml.vb" id="ShowNormal":::

> [!IMPORTANT]
> Once a window is closed, the same object instance can't be used to reopen the window.

## See also

- [Overview of WPF windows](index.md)
- [Dialog boxes overview](dialog-boxes-overview.md)
- [How to close a window or dialog box](how-to-close-window-dialog-box.md)
- [How to open a common dialog box](how-to-open-common-system-dialog-box.md)
- [How to open a message box](how-to-open-message-box.md)
- <xref:System.Windows.Window?displayProperty=fullName>
- <xref:System.Windows.Window.DialogResult?displayProperty=fullName>
- <xref:System.Windows.Window.Show?displayProperty=fullName>
- <xref:System.Windows.Window.ShowDialog?displayProperty=fullName>
