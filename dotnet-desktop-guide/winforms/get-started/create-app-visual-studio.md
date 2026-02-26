---
title: "Create a Windows Forms app tutorial"
description: Learn how to create a Windows Forms (winforms) app with Visual Studio 2026 in this step-by-step tutorial. Start building your first app today!
ms.date: 02/26/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: tutorial
dev_langs:
  - "csharp"
  - "vb"
#customer intent: As a new developer, I want to create a new Windows Forms app.
---

# Tutorial: Create a Windows Forms app by using .NET

In this tutorial, you learn how to use Visual Studio to create a Windows Forms app. Visual Studio provides a visual designer for you to add controls and handle events. By the end of this tutorial, you have a simple app that adds names to a list box.

In this tutorial, you:

> [!div class="checklist"]
>
> - Create a new Windows Forms app.
> - Add controls to a form.
> - Handle control events to provide app functionality.
> - Run the app.

## Prerequisites

- [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2026+desktopguide+winforms)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=visualstudio&preserve-view=true#change-workloads-or-individual-components)
  - Select the [.NET 10 individual component](/visualstudio/install/modify-visual-studio?view=visualstudio&preserve-view=true#change-workloads-or-individual-components)

## Create a Windows Forms app

The first step to creating a new app is opening Visual Studio and generating the app from a template.

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/vs-start-1-intro.png" alt-text="A screenshot of the start dialog from Visual Studio 2026. The 'create a new project' button is highlighted with a red box.":::

01. In the **Search for templates** box, type **winforms**, and wait for the search results to appear.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the list of templates, select **Windows Forms App** and then select **Next**.

    > [!IMPORTANT]
    > Don't select the **Windows Forms App (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, the corresponding template is listed.

    :::image type="content" source="media/create-app-visual-studio/vs-start-2-templates.png" alt-text="Screenshot of Visual Studio's 'Create a new project' dialog with 'winforms' in the search box and Windows Forms App templates highlighted.":::

01. In the **Configure your new project** window, set the **Project name** to _Names_ and select **Next**.

    You can also save your project to a different folder by adjusting the **Location** path.

    :::image type="content" source="media/create-app-visual-studio/vs-start-3-name.png" alt-text="A screenshot of the 'configure your new project' dialog from Visual Studio 2026. The 'Project name' textbox has the word 'Names' in it and is highlighted with a red box. The 'Next' button is also highlighted with a red box.":::

01. Finally, in the **Additional information** window, select **.NET 10.0 (Long Term Support)** for the **Framework** setting, and then select **Create**.

    :::image type="content" source="media/create-app-visual-studio/vs-start-4-framework.png" alt-text="A screenshot of the 'Additional information' dialog from Visual Studio 2026. The 'Framework' dropdown box has '.NET 10 (Long Term Support)' selected and highlighted with a red box. The 'Create' button is also highlighted with a red box.":::

After Visual Studio generates the app, it opens the designer window for the default form, _Form1_. If the form designer isn't visible, double-click on the form in the **Solution Explorer** window to open the designer window.

### Enable the Toolbox and Properties windows

By default, Visual Studio doesn't open the Toolbox and Properties windows. Visual Studio remembers when you open these windows and keeps them open in the future.

To open the windows:

01. Select the **View** > **Toolbox** menu item.
01. Select the **View** > **Properties Window** menu item.

:::image type="content" source="media/create-app-visual-studio/menu-toolbox.png" alt-text="The view menu with both the toolbox item and properties window item highlighted in a Visual Studio 2026 Windows Forms project.":::

### Important parts of Visual Studio

Support for Windows Forms in Visual Studio has four important components that you interact with as you create an app:

:::image type="content" source="media/create-app-visual-studio/vs-main-window.png" alt-text="The important components of Visual Studio 2026 you should know when creating a Windows Forms project for .NET.":::

01. Solution Explorer

    All of your project files, code, forms, and resources appear in this window.

02. Properties

    This window shows property settings you can configure based on the context of the item selected. For example, if you select an item from **Solution Explorer**, you see settings related to the file. If you select an object in the **Designer**, you see the properties of the control or form.

03. Form Designer

    This is the designer for the form. It's interactive and you can drag and drop objects from the **Toolbox**. By selecting and moving items in the designer, you can visually compose the user interface (UI) for your app.

04. Toolbox

    The toolbox contains all of the controls you can add to a form. To add a control to the current form, double-click a control or drag and drop the control to the form.

## Add controls to the form

With the _Form1_ form designer open, use the **Toolbox** window to add the following controls to the form by dragging them from the toolbox and dropping them on the form:

- Button
- Label
- ListBox
- TextBox

Position and size the controls according to the following image:

:::image type="content" source="media/create-app-visual-studio/vs-form-preview.png" alt-text="Visual Studio 2026 designer with the form open for Windows Forms for .NET. There's a listbox to for storing names, a textbox to contain a name, and a button add the name.":::

You can either move and resize the controls with the mouse to match the previous image, or use the following table to configure each control. To configure a control, select it in the designer, then set the appropriate setting in the **Properties** window. When configuring the form, select the form's title bar.

> [!div class="mx-tableNormal"]
>
> | Object      | Setting  | Value      |
> |-------------|----------|------------|
> | **Label**   | Location | `12, 9`    |
> |             | Text     | `Names`    |
> | **ListBox** | Name     | `lstNames` |
> |             | Location | `12, 27`   |
> |             | Size     | `120, 94`  |
> | **TextBox** | Name     | `txtName`  |
> |             | Location | `138, 26`  |
> |             | Size     | `100, 23`  |
> | **Button**  | Name     | `btnAdd`   |
> |             | Location | `138, 55`  |
> |             | Size     | `100, 23`  |
> |             | Text     | `Add Name` |
> | **Form**    | Text     | `Names`    |
> |             | Size     | `268, 180` |

## Handle events

After you lay out all the controls on the form, add event handlers to respond to user input. Go to the form designer and perform the following steps:

01. Select the **Add Name** button control on the form.
01. In the **Properties** window, select the events icon :::image type="icon" source="media/create-app-visual-studio/icon-events.png" alt-text="Events icon from Visual Studio." border="false"::: to list the events of the button.
01. Find the **Click** event and double-click it to generate an event handler.

    This action adds the following code to the form:

    ```csharp
    private void btnAdd_Click(object sender, EventArgs e)
    {

    }
    ```

    ```vb
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub
    ```

    The code for this handler adds the name specified by the `txtName` textbox to the `lstNames` listbox. However, you want to add two conditions for adding the name: the name can't be blank, and the name can't already exist.

01. The following code demonstrates adding a name to the `lstNames` control:

    :::code language="csharp" source="snippets/create-app-visual-studio/csharp/Form1.cs" id="buttonClick":::

    :::code language="vb" source="snippets/create-app-visual-studio/vb/Form1.vb" id="buttonClick":::

## Run the app

After you handle the event, run the app by pressing the <kbd>F5</kbd> key or by selecting **Debug** > **Start Debugging** from the menu. When the app starts, the form is displayed. Enter a name in the textbox and select the button.

:::image type="content" source="media/create-app-visual-studio/app-running.png" alt-text="Running a Windows Forms for .NET app in Visual Studio 2026.":::

## Related content

- [Learn more about Windows Forms](../overview/index.md)
- [Overview of using controls](../controls/overview.md)
- [Events overview](../forms/events.md)
