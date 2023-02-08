---
title: "Create a new app with Visual Studio tutorial"
description: Follow this tutorial to learn how to create a new Windows Forms app for .NET with Visual Studio 2019.
ms.date: 02/07/2023
ms.topic: tutorial
dev_langs: 
  - "csharp"
  - "vb"
---

# Tutorial: Create a Windows Forms app with .NET

In this short tutorial, you'll learn how to create a new Windows Forms app with Visual Studio. Once the initial app has been generated, you'll learn how to add controls and how to handle events. By the end of this tutorial, you'll have a simple app that adds names to a list box.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a new Windows Forms app
> - Add controls to a form
> - Handle control events to provide app functionality
> - Run the app

## Prerequisites

:::moniker range="netdesktop-6.0"

- [Visual Studio 2022 version 17.0 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2022+desktopguide+winforms)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-workloads)
  - Select the [.NET 6 individual component](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-individual-components)

:::moniker-end

:::moniker range="netdesktop-7.0"

- [Visual Studio 2022 version 17.4 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2022+desktopguide+winforms)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-workloads)
  - Select the [.NET 7 individual component](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-individual-components)

:::moniker-end

> [!TIP]
> Use Visual Studio 2022 version 17.4 or later and install both the .NET 7 and .NET 6 individual components. Support for .NET 7 was added in Visual Studio 2022 version 17.4.

## Create a Windows Forms app

The first step to creating a new app is opening Visual Studio and generating the app from a template.

:::moniker range="netdesktop-6.0"

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-create-new-project.png" alt-text="Create a new Windows Forms project in Visual Studio 2022 for .NET.":::

01. In the **Search for templates** box, type **winforms**, and wait for the search results to appear.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the list of templates, select **Windows Forms App** and then click **Next**.

    > [!IMPORTANT]
    > Don't select the **Windows Forms App (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, you'll see the corresponding template.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-template-search.png" alt-text="Search for the Windows Forms template in Visual Studio 2022 for .NET.":::

01. In the **Configure your new project** window, set the **Project name** to _Names_ and click **Next**.

    You can also save your project to a different folder by adjusting the **Location** path.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-config-new-project.png" alt-text="Configure new Windows Forms project in Visual Studio 2022 for .NET.":::

01. Finally, in the **Additional information** window, select **.NET 6.0 (Long-term support)** for the **Framework** setting, and then click **Create**.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-select-framework.png" alt-text="Select the target framework for a Windows Forms project in Visual Studio 2022.":::

:::moniker-end

:::moniker range="netdesktop-7.0"

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-create-new-project.png" alt-text="Create a new Windows Forms project in Visual Studio 2022 for .NET.":::

01. In the **Search for templates** box, type **winforms**, and wait for the search results to appear.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the list of templates, select **Windows Forms App** and then click **Next**.

    > [!IMPORTANT]
    > Don't select the **Windows Forms App (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, you'll see the corresponding template.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-template-search.png" alt-text="Search for the Windows Forms template in Visual Studio 2022 for .NET.":::

01. In the **Configure your new project** window, set the **Project name** to _Names_ and click **Next**.

    You can also save your project to a different folder by adjusting the **Location** path.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-config-new-project.png" alt-text="Configure new Windows Forms project in Visual Studio 2022 for .NET.":::

01. Finally, in the **Additional information** window, select **.NET 7.0 (Standard Term Support)** for the **Framework** setting, and then click **Create**.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-select-framework.png" alt-text="Select the target framework for a Windows Forms project in Visual Studio 2022.":::

:::moniker-end

Once the app is generated, Visual Studio should open the designer pane for the default form, _Form1_. If the form designer isn't visible, double-click on the form in the **Solution Explorer** pane to open the designer window.

### Important parts of Visual Studio

Support for Windows Forms in Visual Studio has four important components that you'll interact with as you create an app:

:::image type="content" source="media/create-app-visual-studio/vs-main-window.png" alt-text="The important components of Visual Studio 2022 you should know when creating a Windows Forms project for .NET.":::

01. Solution Explorer

    All of your project files, code, forms, resources, will appear in this pane.

02. Properties

    This pane shows property settings you can configure based on the item selected. For example, if you select an item from **Solution Explorer**, you'll see property settings related to the file. If you select an object in the **Designer**, you'll see settings for the control or form.

03. Form Designer

    This is the designer for the form. It's interactive and you can drag-and-drop objects from the **Toolbox**. By selecting and moving items in the designer, you can visually compose the user interface (UI) for your app.

04. Toolbox

    The toolbox contains all of the controls you can add to a form. To add a control to the current form, double-click a control or drag-and-drop the control.

> [!TIP]
> If the toolbox isn't visible, you can display it through the **View** > **Toolbox** menu item.
>
> :::image type="content" source="media/create-app-visual-studio/menu-toolbox.png" alt-text="The view menu with the toolbox item highlighted in a Visual Studio 2022 Windows Forms project.":::

## Add controls to the form

With the _Form1_ form designer open, use the **Toolbox** pane to add the following controls to the form:

- Label
- Button
- Listbox
- Textbox

You can position and size the controls according to the following settings. Either visually move them to match the screenshot that follows, or click on each control and configure the settings in the **Properties** pane. You can also click on the form title area to select the form:

| Object      | Setting  | Value      |
|-------------|----------|------------|
| **Form**    | Text     | `Names`    |
|             | Size     | `268, 180` |
| **Label**   | Location | `12, 9`    |
|             | Text     | `Names`    |
| **Listbox** | Name     | `lstNames` |
|             | Location | `12, 27`   |
|             | Size     | `120, 94`  |
| **Textbox** | Name     | `txtName`  |
|             | Location | `138, 26`  |
|             | Size     | `100, 23`  |
| **Button**  | Name     | `btnAdd`   |
|             | Location | `138, 55`  |
|             | Size     | `100, 23`  |
|             | Text     | `Add Name` |

You should have a form in the designer that looks similar to the following:

:::image type="content" source="media/create-app-visual-studio/vs-form-preview.png" alt-text="Visual Studio 2022 designer with the form open for Windows Forms for .NET.":::

## Handle events

Now that the form has all of its controls laid out, you need to handle the events of the controls to respond to user input. With the form designer still open, perform the following steps:

01. Select the button control on the form.
01. In the **Properties** pane, click on the events icon :::image type="icon" source="media/create-app-visual-studio/icon-events.png" border="false"::: to list the events of the button.
01. Find the **Click** event and double-click it to generate an event handler.

    This action adds the following code to the the form:

    ```csharp
    private void btnAdd_Click(object sender, EventArgs e)
    {

    }
    ```

    ```vb
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

    End Sub
    ```

    The code we'll put in this handler will add the name specified by the `txtName` textbox control to the `lstNames` listbox control. However, we want there to be two conditions to adding the name: the name provided must not be blank, and the name must not already exist.

01. The following code demonstrates adding a name to the `lstNames` control:

    :::code language="csharp" source="snippets/create-app-visual-studio/csharp/Form1.cs" id="buttonClick":::

    :::code language="vb" source="snippets/create-app-visual-studio/vb/Form1.vb" id="buttonClick":::

## Run the app

Now that the event has been coded, you can run the app by pressing the <kbd>F5</kbd> key or by selecting **Debug** > **Start Debugging** from the menu. The form displays and you can enter a name in the textbox and then add it by clicking the button.

:::image type="content" source="media/create-app-visual-studio/app-running.png" alt-text="Running a Windows Forms for .NET app in Visual Studio 2022.":::

## Next steps

> [!div class="nextstepaction"]
> [Learn more about Windows Forms](../overview/index.md)
