---
title: Dialog Boxes Overview
description: Learn about the varieties of dialog boxes in Windows Foundation Presentation (WPF). With a dialog box you gather and display information to a user.
ms.date: "03/12/2021"
helpviewer_keywords: 
  - "modeless dialog boxes [WPF]"
  - "modal dialog boxes [WPF]"
  - "dialog boxes [WPF]"
  - "message boxes [WPF]"
---

# Dialog boxes overview (WPF .NET)

Windows Presentation Foundation (WPF) provides dialog boxes in addition to a standard window. This article discusses how a dialog box works and what types of dialog boxes you can create and use. Dialog boxes are used to:

- Display specific information to users.
- Gather information from users.
- Both display and gather information.
- Display an operating system prompt, such a print window.
- Select a file or folder.

These types of windows are known as _dialog boxes_, and there are two types: modal and modeless.

Displaying a _modal_ dialog box to the user is a technique with which the application interrupts what it was doing until the user closes the dialog box. This generally comes in the form of a prompt or alert. Other windows in the application can't be interacted with until the dialog box is closed. Once the _modal_ dialog box is closed, the application continues. The most common dialog boxes are used to show an open file or save file prompt, displaying the printer dialog, or messaging the user with some status.

A *modeless* dialog box doesn't prevent a user from activating other windows while it's open. For example, if a user wants to find occurrences of a particular word in a document, a main window will often open a dialog box to ask a user what word they're looking for. Since the application doesn't want to prevent the user from editing the document, the dialog box doesn't need to be modal. A modeless dialog box at least provides a **Close** button to close the dialog box. Other buttons may be provided to execute specific functions, such as a **Find Next** button to find the next word in a word search.

With WPF you can create several types of dialog boxes, such as message boxes, common dialog boxes, and custom dialog boxes. This article discusses each, and the [Dialog Box Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/DialogBox) provides matching examples.

## Message boxes

A *message box* is a dialog box that can be used to display textual information and to allow users to make decisions with buttons. The following figure shows a message box that asks a question and provides the user with three buttons to answer the question.

:::image type="content" source="media/dialog-boxes-overview/word-processor-dialog.png" alt-text="Word processor dialog box asking if you want to save the changes to the document before the application closes.":::

To create a message box, you use the <xref:System.Windows.MessageBox> class. <xref:System.Windows.MessageBox> lets you configure the message box text, title, icon, and buttons.

For more information, see [How to use a message box](how-to-display-message-box.md).

## Common dialog boxes

Windows implements different kinds of reusable dialog boxes that are common to all applications, including dialog boxes for selecting files and printing.

Since these dialog boxes are provided by the operating system, they're shared among all the applications that run on the operating system. These dialog boxes provide a consistent user experience, and are known as *common dialog boxes*. As a user uses a common dialog box in one application, they don't need to learn how to use that dialog box in other applications.

WPF encapsulates the open file, save file, and print common dialog boxes and exposes them as managed classes for you to use in standalone applications.

:::image type="content" source="media/dialog-boxes-overview/open-file-dialog-box.png" alt-text="Open file dialog box called from WPF.":::

To learn more about common dialog boxes, see the following articles:

- [How to display a common dialog box](how-to-display-common-system-dialog-box.md)
- [Show the Open File dialog box](how-to-display-common-system-dialog-box.md#open-file-dialog-box)
- [Show the Save File dialog box](how-to-display-common-system-dialog-box.md#save-file-dialog-box)
- [Show the Print dialog box](how-to-display-common-system-dialog-box.md#print-dialog-box)

## Custom dialog boxes

While common dialog boxes are useful, and should be used when possible, they don't support the requirements of domain-specific dialog boxes. In these cases, you need to create your own dialog boxes. As we'll see, a dialog box is a window with special behaviors. <xref:System.Windows.Window> implements those behaviors and you use the window to create custom modal and modeless dialog boxes.

There are many design considerations to take into account when you create your own dialog box. Although both an application window and dialog box contain similarities, such as sharing the same base class, a dialog box is used for a specific purpose. Usually a dialog box is required when you need to prompt a user for some sort of information or response. Typically the application will pause while the dialog box (modal) is displayed, restricting access to the rest of the application. Once the dialog box is closed, the application continues. Confining interactions to the dialog box alone, though, isn't a requirement.

### Implementing a dialog box

When designing a dialog box, follow these suggestions to create a good user experience:

❌ DON'T clutter the dialog window. The dialog experience is for the user to enter some data, or to make a choice.

✔️ DO provide an **OK** button to close the window.

✔️ DO set the **OK** button's <xref:System.Windows.Controls.Button.IsDefault%2A> property to `true` to allow the user to press the <kbd>ENTER</kbd> key to accept and close the window.

✔️ CONSIDER adding a **Cancel** button so that the user can close the window and indicate that they don't want to continue.

✔️ DO set the **Cancel** button's <xref:System.Windows.Controls.Button.IsCancel%2A> property to `true` to allow the user to press the <kbd>ESC</kbd> key to close the window.

✔️ DO set the title of the window to accurately describe what the dialog represents, or what the user should do with the dialog.

✔️ DO set minimum width and height values for the window, preventing the user from resizing the window too small.

✔️ CONSIDER disabling the ability to resize the window if <xref:System.Windows.Window.ShowInTaskbar%2A> is set to `false`. You can disable resizing by setting <xref:System.Windows.Window.ResizeMode%2A> to <xref:System.Windows.ResizeMode.NoResize>

The following code demonstrates this configuration.

:::code language="xaml" source="snippets/dialog-boxes-overview/csharp/Margins.xaml" highlight="5-9,58-59":::

The previous XAML creates a window that looks similar to the following image:

:::image type="content" source="media/dialog-boxes-overview/example-dialog.png" alt-text="A dialog box window for WPF that shows left, top, right, bottom text boxes.":::

The user experience for a dialog box also extends into the menu bar or the button of the window that opens the dialog box. When a menu item or button runs a function that requires user interaction through a dialog box before the function can continue, the control should use an ellipsis at the end of its header text:

```xaml
<MenuItem Header="_Margins..." Click="formatMarginsMenuItem_Click" />
<!-- or -->
<Button Content="_Margins..." Click="formatMarginsButton_Click" />
```

When a menu item or button runs a function that displays a dialog box that **doesn't** require user interaction, such as an _About_ dialog box, an ellipsis isn't required.

## See also

- [Overview of WPF windows](index.md)
- [How to display a common dialog box](how-to-display-common-system-dialog-box.md)
- [How to display and manage a window or dialog box](how-to-display-window-dialog-box.md)
- [How to use a message box](how-to-display-message-box.md)
- [Dialog Box Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/DialogBox)
- <xref:System.Windows.Window?displayProperty=fullName>
- <xref:System.Windows.MessageBox?displayProperty=fullName>
