---
title: Dialog Boxes Overview
description: Learn about the varieties of dialog boxes in Windows Foundation Presentation (WPF) that you can use to gather and display information.
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

# Dialog boxes overview

Windows Presentation Foundation (WPF) provides dialog boxes in addition to the main window. This article discusses how a dialog box works and what types of dialog boxes you can create and use. Dialog boxes are generally used to:

- Display specific information to users.
- Gather information from users.
- Both display and gather information.
- Display an operating system prompt, such a print window.
- Select a file or folder.

These types of windows are known as _dialog boxes_, and there are two types: modal and modeless.

Displaying a _modal_ dialog box to the user is a technique with which the application interrupts what it was doing until the user closes the dialog box. This generally comes in the form of a prompt or alert. Other windows in the application can't be interacted with until the dialog box is closed. Once the _modal_ dialog box is closed, the application continues. The most common dialog boxes are used to show an open file or save file prompt, displaying the printer dialog, or messaging the user with some status.

A *modeless* dialog box, on the other hand, doesn't prevent a user from activating other windows while it is open. For example, if a user wants to find occurrences of a particular word in a document, a main window will often open a dialog box to ask a user what word they are looking for. Since the application doesn't want to prevent the user from editing the document, the dialog box doesn't need to be modal. A modeless dialog box at least provides a **Close** button to close the dialog box. Additional buttons may be provided to execute specific functions, such as a **Find Next** button to find the next word in a word search.

With WPF you can create several types of dialog boxes, including message boxes, common dialog boxes, and custom dialog boxes. This article discusses each, and the [Dialog Box Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/DialogBox) provides matching examples.

## Message boxes

A *message box* is a dialog box that can be used to display textual information and to allow users to make decisions with buttons. The following figure shows a message box that displays textual information, asks a question, and provides the user with three buttons to answer the question.

:::image type="content" source="media/dialog-boxes-overview/word-processor-dialog.png" alt-text="Word processor dialog box asking if you want to save the changes to the document before the application closes.":::

To create a message box, you use the <xref:System.Windows.MessageBox> class. <xref:System.Windows.MessageBox> lets you configure the message box text, title, icon, and buttons, shown in the following code:

:::code language="csharp" source="snippets/dialog-boxes-overview/csharp/Window1.xaml.cs" id="YesNoCancel":::
:::code language="vb" source="snippets/dialog-boxes-overview/vb/Window1.xaml.vb" id="YesNoCancel":::

The <xref:System.Windows.MessageBox.Show%2A?displayProperty=nameWithType> method displays the message box. Inspect the user's decision by inspecting the `result` variable:

:::code language="csharp" source="snippets/dialog-boxes-overview/csharp/Window1.xaml.cs" id="MessageBoxShow":::
:::code language="vb" source="snippets/dialog-boxes-overview/vb/Window1.xaml.vb" id="MessageBoxShow":::

For more information on using message boxes, see <xref:System.Windows.MessageBox>, [MessageBox Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/MessageBox), and [Dialog Box Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/DialogBox).

For presenting an gathering complex data, a dialog box might be more suitable than a message box. There are two types of dialog boxes, [Common dialog boxes](#common-dialog-boxes) provided by the operating system, and [Custom dialog boxes](#custom-dialog-boxes) created for your application.

## Common dialog boxes

Windows implements a variety of reusable dialog boxes that are common to all applications, including dialog boxes for selecting files and printing. Since these dialog boxes are implemented by the operating system, they can be shared among all the applications that run on the operating system, which helps user experience consistency. As a user uses operating system-provided dialog boxes in one application, they don't need to learn how to use that dialog box in other applications. Because these dialog boxes are available to all applications and because they help provide a consistent user experience, they are known as *common dialog boxes*.

WPF encapsulates the open file, save file, and print common dialog boxes and exposes them as managed classes for you to use in standalone applications. This article provides a brief overview of each.

### Open File dialog

The open file dialog box, shown in the following figure, is used by file opening functionality to retrieve the name of a file to open.

:::image type="content" source="media/dialog-boxes-overview/open-file-dialog-box.png" alt-text="An Open dialog box showing the location to retrieve the fileshown from a WPF application.":::

The common open file dialog box is implemented as the <xref:Microsoft.Win32.OpenFileDialog> class and is located in the <xref:Microsoft.Win32> namespace. The following code shows how to create, configure, and show one, and how to process the result.

:::code language="csharp" source="snippets/dialog-boxes-overview/csharp/Window1.xaml.cs" id="OpenFile":::
:::code language="vb" source="snippets/dialog-boxes-overview/vb/Window1.xaml.vb" id="OpenFile":::

For or more information on the open file dialog box, see <xref:Microsoft.Win32.OpenFileDialog?displayProperty=nameWithType>.

### Save File dialog box

The save file dialog box, shown in the following figure, is used by file saving functionality to retrieve the name of a file to save.

:::image type="content" source="media/dialog-boxes-overview/save-file-dialog-box.png" alt-text="A Save As dialog box showing the location to save the file shown from a WPF application.":::

The common save file dialog box is implemented as the <xref:Microsoft.Win32.SaveFileDialog> class, and is located in the <xref:Microsoft.Win32> namespace. The following code shows how to create, configure, and show one, and how to process the result.

:::code language="csharp" source="snippets/dialog-boxes-overview/csharp/Window1.xaml.cs" id="SaveFile":::
:::code language="vb" source="snippets/dialog-boxes-overview/vb/Window1.xaml.vb" id="SaveFile":::

For more information on the save file dialog box, see <xref:Microsoft.Win32.SaveFileDialog?displayProperty=nameWithType>.

### Print dialog box

The print dialog box, shown in the following figure, is used by printing functionality to choose and configure the printer that a user would like to print data to.

:::image type="content" source="media/dialog-boxes-overview/print-data-dialog-box.png" alt-text="A print dialog box shown from a WPF application.":::

The common print dialog box is implemented as the <xref:System.Windows.Controls.PrintDialog> class, and is located in the <xref:System.Windows.Controls> namespace. The following code shows how to create, configure, and show one.

:::code language="csharp" source="snippets/dialog-boxes-overview/csharp/Window1.xaml.cs" id="Print":::
:::code language="vb" source="snippets/dialog-boxes-overview/vb/Window1.xaml.vb" id="Print":::

For more information on the print dialog box, see <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType>. For detailed discussion of printing in WPF, see [Printing overview](../advanced/printing-overview.md).

<a name="Custom_Dialog_Boxes"></a>
## Custom dialog boxes

While common dialog boxes are useful, and should be used when possible, they do not support the requirements of domain-specific dialog boxes. In these cases, you need to create your own dialog boxes. As we'll see, a dialog box is a window with special behaviors. <xref:System.Windows.Window> implements those behaviors and, consequently, you use <xref:System.Windows.Window> to create custom modal and modeless dialog boxes.

<a name="Creating_a_Modal_Custom_Dialog_Box"></a>
### Creating a modal custom dialog box

This article shows how to use <xref:System.Windows.Window> to create a typical modal dialog box implementation, using the `Margins` dialog box as an example (see [Dialog Box Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/DialogBox)). The `Margins` dialog box is shown in the following figure.

 ![A Margins dialog box with fields to define left margin, top margin, right margin, and bottom margin.](./media/dialog-boxes-overview/margin-size-dialog-box.png)

#### Configuring a modal dialog box

The user interface for a typical dialog box includes the following:

- The various controls that are required to gather the desired data.

- An **OK** button that users click to close the dialog box, return to the function, and continue processing.

- A **Cancel** button that users click to close the dialog box and stop the function from further processing.

- A **Close** button in the title bar.

- An icon.

- **Minimize**, **Maximize**, and **Restore** buttons.

- A **System** menu to minimize, maximize, restore, and close the dialog box.

- A position above and in the center of the window that opened the dialog box.

- The ability to be resized where possible to prevent the dialog box from being too small, and to provide the user with a useful default size. This requires that you set both the default and a minimum dimensions.

- The ESC key as a keyboard shortcut that causes the **Cancel** button to be pressed. You do this by setting the <xref:System.Windows.Controls.Button.IsCancel%2A> property of the **Cancel** button to `true`.

- The ENTER (or RETURN) key as a keyboard shortcut that causes the **OK** button to be pressed. You do this by setting the <xref:System.Windows.Controls.Button.IsDefault%2A> property of the **OK** button `true`.

The following code demonstrates this configuration.

[!code-xaml[MarginsDialogBox XAML file](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml?range=1-16,106-112)]

[!code-csharp[MarginsDialogBox C# code-behind](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml.cs?range=1-12,67-68)]
[!code-vb[MarginsDialogBox VB code-behind](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MarginsDialogBox.xaml.vb?range=1-11,61-62)]

The user experience for a dialog box also extends into the menu bar of the window that opens the dialog box. When a menu item runs a function that requires user interaction through a dialog box before the function can continue, the menu item for the function will have an ellipsis in its header, as shown here.

[!code-xaml[Menu bar of MainWindow.Xaml file](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MainWindow.xaml#L26-L27)]

When a menu item runs a function that displays a dialog box which does not require user interaction, such as an About dialog box, an ellipsis is not required.

#### Opening a modal dialog box

A dialog box is typically shown as a result of a user selecting a menu item to perform a domain-specific function, such as setting the margins of a document in a word processor. Showing a window as a dialog box is similar to showing a normal window, although it requires additional dialog box-specific configuration. The entire process of instantiating, configuring, and opening a dialog box is shown in the following code.

[!code-csharp[Opening a modal dialog box](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MainWindow.xaml.cs?range=1-11,78-88,193-195)]
[!code-vb[Opening a modal dialog box](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MainWindow.xaml.vb?range=1-9,58-67,130-132)]

Here, the code passes default information (the current margins) to the dialog box. It also sets the <xref:System.Windows.Window.Owner%2A?displayProperty=nameWithType> property with a reference to the window that is showing the dialog box. In general, you should always set the owner for a dialog box to provide window state-related behaviors that are common to all dialog boxes (see [WPF Windows Overview](wpf-windows-overview.md) for more information).

> [!NOTE]
> You must provide an owner to support user interface (UI) automation for dialog boxes (see [UI Automation Overview](/dotnet/framework/ui-automation/ui-automation-overview)).

After the dialog box is configured, it is shown modally by calling the <xref:System.Windows.Window.ShowDialog%2A> method.

#### Validating user-provided data

When a dialog box is opened and the user provides the required data, a dialog box is responsible for ensuring that the provided data is valid for the following reasons:

- From a security perspective, all input should be validated.

- From a domain-specific perspective, data validation prevents erroneous data from being processed by the code, which could potentially throw exceptions.

- From a user-experience perspective, a dialog box can help users by showing them which data they have entered is invalid.

- From a performance perspective, data validation in a multi-tier application can reduce the number of round trips between the client and the application tiers, particularly when the application is composed of Web services or server-based databases.

To validate a bound control in WPF, you need to define a validation rule and associate it with the binding. A validation rule is a custom class that derives from <xref:System.Windows.Controls.ValidationRule>. The following example shows a validation rule, `MarginValidationRule`, which checks that a bound value is a <xref:System.Double> and is within a specified range.

[!code-csharp[Margin validation rules](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginValidationRule.cs)]
[!code-vb[Margin validation rules](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MarginValidationRule.vb)]

In this code, the validation logic of a validation rule is implemented by overriding the <xref:System.Windows.Controls.ValidationRule.Validate%2A> method, which validates the data and returns an appropriate <xref:System.Windows.Controls.ValidationResult>.

To associate the validation rule with the bound control, you use the following markup.

[!code-xaml[Associating a validation rule with a control](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml?range=1-16,57-68,111-112)]

Once the validation rule is associated, WPF will automatically apply it when data is entered into the bound control. When a control contains invalid data, WPF will display a red border around the invalid control, as shown in the following figure.

![A Margins dialog box with a red border around the invalid left margin value.](./media/dialog-boxes-overview/invalid-left-margin-dialog.png)

WPF does not restrict a user to the invalid control until they have entered valid data. This is good behavior for a dialog box; a user should be able to freely navigate the controls in a dialog box whether or not data is valid. However, this means a user can enter invalid data and press the **OK** button. For this reason, your code also needs to validate all controls in a dialog box when the **OK** button is pressed by handling the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event.

[!code-csharp[Validating all controls in a dialog box](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml.cs?range=1-8,26-29,33-68)]
[!code-vb[Validating all controls in a dialog box](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MarginsDialogBox.xaml.vb?range=1-8,27-29,33-62)]

This code enumerates all dependency objects on a window and, if any are invalid (as returned by <xref:System.Windows.Controls.Validation.GetHasError%2A>, the invalid control gets the focus, the `IsValid` method returns `false`, and the window is considered invalid.

Once a dialog box is valid, it can safely close and return. As part of the return process, it needs to return a result to the calling function.

#### Setting the modal dialog result

Opening a dialog box using <xref:System.Windows.Window.ShowDialog%2A> is fundamentally like calling a method: the code that opened the dialog box using <xref:System.Windows.Window.ShowDialog%2A> waits until <xref:System.Windows.Window.ShowDialog%2A> returns. When <xref:System.Windows.Window.ShowDialog%2A> returns, the code that called it needs to decide whether to continue processing or stop processing, based on whether the user pressed the **OK** button or the **Cancel** button. To facilitate this decision, the dialog box needs to return the user's choice as a <xref:System.Boolean> value that is returned from the <xref:System.Windows.Window.ShowDialog%2A> method.

When the **OK** button is clicked, <xref:System.Windows.Window.ShowDialog%2A> should return `true`. This is achieved by setting the <xref:System.Windows.Window.DialogResult%2A> property of the dialog box when the **OK** button is clicked.

[!code-csharp[Responding to the OK button](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml.cs?range=1-8,25-27,32-33,67-68)]
[!code-vb[Responding to the OK button](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MarginsDialogBox.xaml.vb?range=1-8,27,31-33,61-62)]

Note that setting the <xref:System.Windows.Window.DialogResult%2A> property also causes the window to close automatically, which alleviates the need to explicitly call <xref:System.Windows.Window.Close%2A>.

When the **Cancel** button is clicked, <xref:System.Windows.Window.ShowDialog%2A> should return `false`, which also requires setting the <xref:System.Windows.Window.DialogResult%2A> property.

[!code-csharp[Responding to the Cancel button](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml.cs?range=1-8,19-24,67-68)]
[!code-vb[Responding to the Cancel button](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MarginsDialogBox.xaml.vb?range=1-8,22-25,61-62)]

When a button's <xref:System.Windows.Controls.Button.IsCancel%2A> property is set to `true` and the user presses either the **Cancel** button or the ESC key, <xref:System.Windows.Window.DialogResult%2A> is automatically set to `false`. The following markup has the same effect as the preceding code, without the need to handle the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event.

[!code-xaml[Markup instead of handling the Click event](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MarginsDialogBox.xaml#L109-L109)]

A dialog box automatically returns `false` when a user presses the **Close** button in the title bar or chooses the **Close** menu item from the **System** menu.

#### Processing data returned from a modal dialog box

When <xref:System.Windows.Window.DialogResult%2A> is set by a dialog box, the function that opened it can get the dialog box result by inspecting the <xref:System.Windows.Window.DialogResult%2A> property when <xref:System.Windows.Window.ShowDialog%2A> returns.

[!code-csharp[Processing data returned from the modal dialog box](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MainWindow.xaml.cs?range=1-10,77-79,89-96,194-195)]
[!code-vb[Processing data returned from the modal dialog box](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MainWindow.xaml.vb?range=1-9,58,69-73,131-132)]

If the dialog result is `true`, the function uses that as a cue to retrieve and process the data provided by the user.

> [!NOTE]
> After <xref:System.Windows.Window.ShowDialog%2A> has returned, a dialog box cannot be reopened. Instead, you need to create a new instance.

If the dialog result is `false`, the function should end processing appropriately.

<a name="Creating_a_Modeless_Custom_Dialog_Box"></a>
### Creating a modeless custom dialog box

A modeless dialog box, such as the Find Dialog Box shown in the following figure, has the same fundamental appearance as the modal dialog box.

![Screenshot that shows a Find dialog box.](./media/dialog-boxes-overview/find-modeless-dialog-box.png)

However, the behavior is slightly different, as described in the following sections.

#### Opening a modeless dialog box

A modeless dialog box is opened by calling the <xref:System.Windows.Window.Show%2A> method.

[!code-xaml[XAML to define a modeless dialog box](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MainWindow.xaml#L21-L22)]

[!code-csharp[Opening a modeless dialog box](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MainWindow.xaml.cs?range=1-10,65-76,194-195)]
[!code-vb[Openng a modeless dialog box](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MainWindow.xaml.vb?range=1-9,18-23,131,132)]

Unlike <xref:System.Windows.Window.ShowDialog%2A>, <xref:System.Windows.Window.Show%2A> returns immediately. Consequently, the calling window cannot tell when the modeless dialog box is closed and, therefore, does not know when to check for a dialog box result or get data from the dialog box for further processing. Instead, the dialog box needs to create an alternative way to return data to the calling window for processing.

#### Processing data returned from a modeless dialog box

In this example, the `FindDialogBox` may return one or more find results to the main window, depending on the text being searched for without any specific frequency. As with a modal dialog box, a modeless dialog box can return results using properties. However, the window that owns the dialog box needs to know when to check those properties. One way to enable this is for the dialog box to implement an event that is raised whenever text is found. `FindDialogBox` implements the `TextFoundEvent` for this purpose, which first requires a delegate.

[!code-csharp[The TextFoundEventHandler delegate](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/TextFoundEventHandler.cs)]
[!code-vb[The TextFoundEventHandler delegate](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/TextFoundEventHandler.vb)]

Using the `TextFoundEventHandler` delegate, `FindDialogBox` implements the `TextFoundEvent`.

[!code-csharp[The TextFound event](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/FindDialogBox.xaml.cs?range=1-17,125-126)]
[!code-vb[The TextFound event](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/FindDialogBox.xaml.vb?range=1-15,102-103)]

Consequently, `Find` can raise the event when a search result is found.

[!code-csharp[Raising the TextFound event](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/FindDialogBox.xaml.cs?range=1-9,50-52,91-94,124-127)]
[!code-vb[Raising the TextFound event](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/FindDialogBox.xaml.vb?range=1-9,15,60-64,102-103)]

The owner window then needs to register with and handle this event.

[!code-csharp[Registering and handling the event](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/MainWindow.xaml.cs?range=1-10,184-195)]
[!code-vb[Registering and handling the event](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/MainWindow.xaml.vb?range=1-9,126-132)]

#### Closing a modeless dialog box

Because <xref:System.Windows.Window.DialogResult%2A> does not need to be set, a modeless dialog can be closed using system provide mechanisms, including the following:

- Clicking the **Close** button in the title bar.

- Pressing ALT+F4.

- Choosing **Close** from the **System** menu.

Alternatively, your code can call <xref:System.Windows.Window.Close%2A> when the **Close** button is clicked.

[!code-csharp[Calling the Close method](~/samples/snippets/csharp/VS_Snippets_Wpf/DialogBoxSample/CSharp/FindDialogBox.xaml.cs?range=1-9,119-126)]
[!code-vb[Calling the Close method](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DialogBoxSample/VisualBasic/FindDialogBox.xaml.vb?range=1-9,99-103)]

## See also

- [Popup Overview](../controls/popup-overview.md)
- [Dialog Box Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/DialogBox)
