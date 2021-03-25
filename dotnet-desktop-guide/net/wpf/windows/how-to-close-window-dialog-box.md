---
title: How to close a window
description: Learn about how to close a window or dialog box in Windows Foundation Presentation (WPF). You'll also learn how to return a result from the window or dialog box.
ms.date: "03/24/2021"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "modeless dialog boxes [WPF]"
  - "modal dialog boxes [WPF]"
  - "dialog boxes [WPF]"
  - "message boxes [WPF]"
---

# How to close a window or dialog box (WPF .NET)

In this article, you'll learn about the different ways to close a window or dialog box. A user can close a window by using the elements in the non-client area, including the following:

- The **Close** item of the **System** menu.
- Pressing <kbd>ALT + F4</kbd>.
- Pressing the **Close** button.
- Pressing <kbd>ESC</kbd> when a button has the <xref:System.Windows.Controls.Button.IsCancel%2A> property set to `true` on a modal window.

When designing a window, provide more mechanisms to the client area to close a window. Some of the common design elements on a window that are used to close it include the following:

- An **Exit** item in the **File** menu, typically for main application windows.
- A **Close** item in the **File** menu, typically on a secondary application window.
- A **Cancel** button, typically on a modal dialog box.
- A **Close** button, typically on a modeless dialog box.

> [!IMPORTANT]
> Once a window is closed, the same object instance can't be used to reopen the window.

For more information about the life of a window, see [Overview of WPF windows: Window lifetime](index.md#window-lifetime).

## Close a modal window

When closing a window that was opened with the <xref:System.Windows.Window.ShowDialog%2A> method, set the <xref:System.Windows.Window.DialogResult> property to either `true` or `false` to indicate an "accepted" or "canceled" state, respectively. As soon as the `DialogResult` property is set to a value, the window closes. The following code demonstrates setting the `DialogResult` property:

:::code language="csharp" source="snippets/how-to-close-window-dialog-box/csharp/Menus.xaml.cs" id="CloseDialog":::
:::code language="vb" source="snippets/how-to-close-window-dialog-box/vb/Menus.xaml.vb" id="CloseDialog":::

You can also call the <xref:System.Windows.Window.Close%2A> method. If the `Close` method is used, the <xref:System.Windows.Window.DialogResult> property is set to `false`.

Once a window has been closed, it can't be reopened with the same object instance. If you try to show the same window, a <xref:System.InvalidOperationException> is thrown. Instead, create a new instance of the window and open it.

## Close a modeless window

When closing a window that was opened with the <xref:System.Windows.Window.Show%2A> method, use the <xref:System.Windows.Window.Close%2A> method. The following code demonstrates closing a modeless window:

:::code language="csharp" source="snippets/how-to-close-window-dialog-box/csharp/Menus.xaml.cs" id="CloseNormal":::
:::code language="vb" source="snippets/how-to-close-window-dialog-box/vb/Menus.xaml.vb" id="CloseNormal":::

## Close with IsCancel

The <xref:System.Windows.Controls.Button.IsCancel?displayProperty=nameWithType> property can be set to `true` to enable the <kbd>ESC</kbd> key to automatically close the window. This only works when the window is opened with <xref:System.Windows.Window.ShowDialog%2A> method.

:::code language="xaml" source="snippets/how-to-close-window-dialog-box/csharp/Window1.xaml" id="CancelButton":::

## Hide a window

Instead of closing a window, a window can be hidden with the <xref:System.Windows.Window.Hide%2A> method. A hidden window can be reopened, unlike a window that has been closed. If you're going to reuse a window object instance, hide the window instead of closing it. The following code demonstrates hiding a window:

:::code language="csharp" source="snippets/how-to-close-window-dialog-box/csharp/Menus.xaml.cs" id="Hide":::
:::code language="vb" source="snippets/how-to-close-window-dialog-box/vb/Menus.xaml.vb" id="Hide":::

## Cancel close and hide

If you've designed your buttons to hide a window instead of closing it, the user can still bypass this and close the window. The **Close** item of the system menu and the **Close** button of the non-client area of the window, will close the window instead of hiding it. Consider this scenario when your intent is to hide a window instead of closing it.

> [!CAUTION]
> If a window is shown modally with <xref:System.Windows.Window.ShowDialog%2A>, the <xref:System.Windows.Window.DialogResult> property will be set to `null` when the window is hidden. You'll need to communicate state back to the calling code by adding your own property to the window.

When a window is closed, the <xref:System.Windows.Window.Closing> event is raised. The handler is passed a <xref:System.ComponentModel.CancelEventArgs>, which implements the <xref:System.ComponentModel.CancelEventArgs.Cancel> property. Set that property to `true` to prevent a window from closing. The following code demonstrates how to cancel the closure and instead hide the window:

:::code language="csharp" source="snippets/how-to-close-window-dialog-box/csharp/Margins.xaml.cs" id="CancelAndHide":::
:::code language="vb" source="snippets/how-to-close-window-dialog-box/vb/Margins.xaml.vb" id="CancelAndHide":::

There may be times where you don't want to hide a window, but actually prevent the user from closing it. For more information, see [Overview of WPF windows: Cancel window closure](index.md#cancel-window-closure).

## See also

- [Overview of WPF windows](index.md)
- [Dialog boxes overview](dialog-boxes-overview.md)
- [How to open a window or dialog box](how-to-open-window-dialog-box.md)
- <xref:System.Windows.Window.Close?displayProperty=fullName>
- <xref:System.Windows.Window.Closing?displayProperty=fullName>
- <xref:System.Windows.Window.DialogResult?displayProperty=fullName>
- <xref:System.Windows.Window.Hide?displayProperty=fullName>
- <xref:System.Windows.Window.Show?displayProperty=fullName>
- <xref:System.Windows.Window.ShowDialog?displayProperty=fullName>
