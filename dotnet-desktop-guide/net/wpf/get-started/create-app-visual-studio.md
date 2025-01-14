---
title: "Create a new app with Visual Studio tutorial"
description: Follow this tutorial to learn how to create a new WPF app for .NET with Visual Studio 2022. WPF apps run on Windows.
ms.date: 11/15/2024
ms.topic: tutorial
ms.custom: update-template, updateeachrelease
dev_langs: 
  - "csharp"
  - "vb"
#customer intent: As a new developer, I want to create a new WPF app.
---

# Tutorial: Create a new WPF app with .NET

In this tutorial, you learn how to use Visual Studio to create a new Windows Presentation Foundation (WPF) app. With Visual Studio, you add controls to windows to design the UI of the app, and handle input events from those controls to interact with the user. By the end of this tutorial, you have a simple app that adds names to a list box.

In this tutorial, you:

> [!div class="checklist"]
>
> - Create a new WPF app.
> - Add controls to a window.
> - Handle control events to provide app functionality.
> - Run the app.

Here's a preview of the app created while following this tutorial:

:::image type="content" source="media/create-app-visual-studio/app-finished.png" alt-text="Finished sample app for WPF tutorial":::

## Prerequisites

:::moniker range="netdesktop-6.0"

> [!CAUTION]
> .NET 6 is no longer supported. It's recommended that you use .NET 9.0.

- [Visual Studio 2022 version 17.0 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2022+desktopguide+wpf)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-workloads)
  - Select the [.NET 6 individual component](/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-individual-components)

:::moniker-end

:::moniker range="netdesktop-7.0"

> [!CAUTION]
> .NET 7 is no longer supported. It's recommended that you use .NET 9.0.

- [Visual Studio 2022 version 17.4 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2022+desktopguide+wpf)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-workloads)
  - Select the [.NET 7 individual component](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-individual-components)

:::moniker-end

:::moniker range="netdesktop-8.0"

- [Visual Studio 2022 version 17.8 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2022+desktopguide+winforms)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-workloads)
  - Select the [.NET 8 individual component](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-individual-components)

:::moniker-end

:::moniker range="netdesktop-9.0"

- [Visual Studio 2022 version 17.12 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&0utm_content=download+vs2022+desktopguide+winforms)
  - Select the [.NET desktop development workload](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-workloads)
  - Select the [.NET 9 individual component](/visualstudio/install/modify-visual-studio?view=vs-2022&preserve-view=true#modify-individual-components)

:::moniker-end

## Create a WPF app

The first step to creating a new app is opening Visual Studio and generating the app from a template.

:::moniker range="netdesktop-6.0"

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-create-new-project.png" alt-text="Create a new WPF project in Visual Studio 2022 for .NET. 6":::

01. In the **Search for templates** box, type _wpf_, and then press <kbd>Enter</kbd>.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the templates list, select **WPF Application** and then select **Next**.

    > [!IMPORTANT]
    > Don't select the **WPF Application (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, only the template for that language is shown.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-template-search.png" alt-text="Search for the WPF template in Visual Studio 2022 for .NET. 6":::

01. In the **Configure your new project** window, do the following:

    01. In the **Project name** box, enter _Names_.
    01. Select the **Place solution and project in the same directory** check box.
    01. Optionally, choose a different **Location** to save your code.
    01. Select the **Next** button.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-config-new-project.png" alt-text="Configure new WPF project in Visual Studio 2022 for .NET 6":::

01. In the **Additional information** window, select **.NET 6.0 (Long-term support)** for **Target Framework**. Select the **Create** button.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-6.0/vs-config-new-project-next.png" alt-text="Select target framework for new WPF project in Visual Studio 2022 for .NET 6":::

:::moniker-end

:::moniker range="netdesktop-7.0"

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-create-new-project.png" alt-text="Create a new WPF project in Visual Studio 2022 for .NET 7.":::

01. In the **Search for templates** box, type _wpf_, and then press <kbd>Enter</kbd>.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the templates list, select **WPF Application** and then select **Next**.

    > [!IMPORTANT]
    > Don't select the **WPF Application (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, only the template for that language is shown.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-template-search.png" alt-text="Search for the WPF template in Visual Studio 2022 for .NET. 7":::

01. In the **Configure your new project** window, do the following:

    01. In the **Project name** box, enter _Names_.
    01. Select the **Place solution and project in the same directory** check box.
    01. Optionally, choose a different **Location** to save your code.
    01. Select the **Next** button.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-config-new-project.png" alt-text="Configure new WPF project in Visual Studio 2022 for .NET 7":::

01. In the **Additional information** window, select **.NET 7.0 (Standard Term Support)** for **Target Framework**. Select the **Create** button.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-7.0/vs-config-new-project-next.png" alt-text="Select target framework for new WPF project in Visual Studio 2022 for .NET 7":::

:::moniker-end

:::moniker range="netdesktop-8.0"

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/vs-start-1-intro.png" alt-text="A screenshot of the start dialog from Visual Studio 2022. The 'create a new project' button is highlighted with a red box.":::

01. In the **Search for templates** box, type _wpf_, and then press <kbd>Enter</kbd>.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the templates list, select **WPF Application** and then select **Next**.

    > [!IMPORTANT]
    > Don't select the **WPF Application (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, only the template for that language is shown.

    :::image type="content" source="media/create-app-visual-studio/vs-start-2-templates.png" alt-text="The term 'wpf' is in a search box and is highlighted with a red arrow. Two templates in the results list are highlighted with red boxes, C# and Visual Basic. The 'Next' button at the bottom-right of the screen is highlighted with a red box.":::

01. In the **Configure your new project** window, do the following:

    01. In the **Project name** box, enter _Names_.
    01. Select the **Place solution and project in the same directory** check box.
    01. Optionally, choose a different **Location** to save your code.
    01. Select the **Next** button.

    :::image type="content" source="media/create-app-visual-studio/vs-start-3-name.png" alt-text="A screenshot of the 'configure your new project' dialog from Visual Studio 2022. The 'Project name' textbox has the word 'Names' in it and is highlighted with a red box. The 'Place solution and project in the same directory' checkbox is checked and pointed to with a red arrow. The 'Next' button is also highlighted with a red box.":::

01. In the **Additional information** window, select **.NET 8.0 (Long Term Support)** for **Target Framework**. Select the **Create** button.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-8.0/vs-start-4-framework.png" alt-text="A screenshot of the 'Additional information' dialog from Visual Studio 2022. The 'Framework' dropdown box has '.NET 8.0 (Long Term Support)' selected and highlighted with a red arrow. The 'Create' button is also highlighted with a red box.":::

:::moniker-end

:::moniker range="netdesktop-9.0"

01. Open Visual Studio.
01. Select **Create a new project**.

    :::image type="content" source="media/create-app-visual-studio/vs-start-1-intro.png" alt-text="A screenshot of the start dialog from Visual Studio 2022. The 'create a new project' button is highlighted with a red box.":::

01. In the **Search for templates** box, type _wpf_, and then press <kbd>Enter</kbd>.
01. In the **code language** dropdown, choose **C#** or **Visual Basic**.
01. In the templates list, select **WPF Application** and then select **Next**.

    > [!IMPORTANT]
    > Don't select the **WPF Application (.NET _Framework_)** template.

    The following image shows both C# and Visual Basic .NET project templates. If you applied the **code language** filter, only the template for that language is shown.

    :::image type="content" source="media/create-app-visual-studio/vs-start-2-templates.png" alt-text="The term 'wpf' is in a search box and is highlighted with a red arrow. Two templates in the results list are highlighted with red boxes, C# and Visual Basic. The 'Next' button at the bottom-right of the screen is highlighted with a red box.":::

01. In the **Configure your new project** window, do the following:

    01. In the **Project name** box, enter _Names_.
    01. Select the **Place solution and project in the same directory** check box.
    01. Optionally, choose a different **Location** to save your code.
    01. Select the **Next** button.

    :::image type="content" source="media/create-app-visual-studio/vs-start-3-name.png" alt-text="A screenshot of the 'configure your new project' dialog from Visual Studio 2022. The 'Project name' textbox has the word 'Names' in it and is highlighted with a red box. The 'Place solution and project in the same directory' checkbox is checked and pointed to with a red arrow. The 'Next' button is also highlighted with a red box.":::

01. In the **Additional information** window, select **.NET 9.0 (Standard Term Support)** for **Target Framework**. Select the **Create** button.

    :::image type="content" source="media/create-app-visual-studio/netdesktop-9.0/vs-start-4-framework.png" alt-text="A screenshot of the 'Additional information' dialog from Visual Studio 2022. The 'Framework' dropdown box has '.NET 9.0 (Standard Term Support)' selected and highlighted with a red arrow. The 'Create' button is also highlighted with a red box.":::

:::moniker-end

Once the app is generated, Visual Studio should open the XAML designer window for the default window, _MainWindow_. If the designer isn't visible, double-click on the _MainWindow.xaml_ file in the **Solution Explorer** window to open the designer.

### Important parts of Visual Studio

Support for WPF in Visual Studio has five important components that you interact with as you create an app:

:::image type="content" source="media/create-app-visual-studio/vs-main-window.png" alt-text="The important components of Visual Studio you should know when creating a WPF project for .NET":::

01. Solution Explorer

    All of your project files, code, windows, resources, appear in this window.

02. Properties

    This window shows property settings you can configure based on the item selected. For example, if you select an item from **Solution Explorer**, you'll see property settings related to the file. If you select an object in the **Designer**, you'll see settings for the element. Regarding the previous image, the window's title bar was selected in the designer.

03. Toolbox

    The toolbox contains all of the controls you can add to a design surface. To add a control to the current surface, double-click the control or drag-and-drop the control on the surface. It's common to instead use the XAML code editor window to design a user interface (UI), while using the XAML designer window to preview the results.

04. XAML designer

    This is the designer for a XAML document. It's interactive and you can drag-and-drop objects from the **Toolbox**. By selecting and moving items in the designer, you can visually compose the UI for your app.

    When both the designer and editor are visible, changes to one is reflected in the other.

    When you select items in the designer, the **Properties** window displays the properties and attributes about that object.

05. XAML code editor

    This is the XAML code editor for a XAML document. The XAML code editor is a way to craft your UI by hand without a designer. The designer might automatically set properties on a control when the control is added in the designer. The XAML code editor gives you a lot more control.

    When both the designer and editor are visible, changes to one is reflected in the other. As you navigate the text caret in the code editor, the **Properties** window displays the properties and attributes about that object.

## Examine the XAML

After your project is created, the XAML code editor is visible with a minimal amount of XAML code to display the window. If the editor isn't open, double-click the _MainWindow.xaml_ item in the **Solution Explorer** window. You should see XAML similar to the following example:

```xaml
<Window x:Class="Names.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Names"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>

    </Grid>
</Window>
```

> [!IMPORTANT]
> If you're coding in Visual Basic, the XAML is slightly different, specifically the `x:Class=".."` attribute. XAML in Visual Basic uses the object's class name and omits the namespace to the class.

To better understand the XAML, let's break it down. XAML is simply XML that that's processed by WPF to create a UI. To understand XAML, you should, at a minimum, be familiar with the basics of XML.

The document root `<Window>` represents the type of object described by the XAML file. There are eight attributes declared, and they generally belong to three categories:

- XML namespaces

  An XML namespace provides structure to the XML, determining what XML content can be declared in the file.

  The main `xmlns` attribute imports the XML namespace for the entire file, and in this case, maps to the types declared by WPF. The other XML namespaces declare a prefix and import other types and objects for the XAML file. For example, the `xmlns:local` namespace declares the `local` prefix and maps to the objects declared by your project, the ones declared in the `Names` code namespace.

- `x:Class` attribute

  This attribute maps the `<Window>` to the type defined by your code: the _MainWindow.xaml.cs_ or _MainWindow.xaml.vb_ file, which is the `Names.MainWindow` class in C# and `MainWindow` in Visual Basic.

- `Title` attribute

  Any normal attribute declared on the XAML object sets a property of that object. In this case, the `Title` attribute sets the `Window.Title` property.

## Change the window

For our example app, this window is too large, and the title bar isn't descriptive. Let's fix that.

01. First, Run the app by pressing the <kbd>F5</kbd> key or by selecting **Debug** > **Start Debugging** from the menu.

    You'll see the default window generated by the template displayed, without any controls, and a title of **MainWindow**:

    :::image type="content" source="media/create-app-visual-studio/app-default.png" alt-text="A blank WPF app" :::

01. Change the title of the window by setting the `Title` to `Names`.
01. Change the size of the window by setting the `Height` to `180` and `Width` to `260`.

    :::code language="xaml" source="snippets/create-app-visual-studio/csharp/Start.xaml" highlight="8":::

## Prepare the layout

WPF provides a powerful layout system with many different layout controls. Layout controls help place and size child controls, and can even do so automatically. The default layout control provided to you in this XAML is the `<Grid>` control.

The grid control lets you define rows and columns, much like a table, and place controls within the bounds of a specific row and column combination. You can have any number of child controls or other layout controls added to the grid. For example, you can place another `<Grid>` control in a specific row and column combination, and that new grid can then define more rows and columns and have its own children.

The grid control places its child controls in rows and columns. A grid always has a single row and column declared, meaning, the grid by default is a single cell. That doesn't really give you much flexibility in placing controls.

Adjust the grid's layout for the controls required for this app.

01. Add a new attribute to the `<Grid>` element: `Margin="10"`.

    This setting brings the grid in from the window edges and makes it look a little nicer.

01. Define two rows and two columns, dividing the grid into four cells:

    :::code language="xaml" source="snippets/create-app-visual-studio/csharp/LayoutStep2.xaml" range="9-21":::

01. Select the grid in either the XAML code editor or XAML designer, you'll see that the XAML designer shows each row and column:

    :::image type="content" source="media/create-app-visual-studio/vs-designer-grid-rows-columns.png" alt-text="A WPF app with the margin set on a grid":::

## Add the first control

Now that the grid has been configured, we can start adding controls to it. First, start with the label control.

01. Create a new `<Label>` element inside the `<Grid>` element, after the row and column definitions. Set the content of the element to the string value of `Names`:

    :::code language="xaml" source="snippets/create-app-visual-studio/csharp/LayoutStep3.xaml" range="9-23" highlight="13":::

    The `<Label>Names</Label>` defines the content `Names`. Some controls understand how to handle content, others don't. The content of a control maps to the `Content` property. Setting the content through XAML attribute syntax, you would use this format: `<Label Content="Names" />`. Both ways accomplish the same thing, setting the content of the label to display the text `Names`.

    Notice that the label takes up half the window, as it was automatically positioned to the first row and column of the grid. For our first row, we don't need that much space because we're only going to use that row for the label.

01. Change the `Height` attribute of the first `<RowDefinition>` from `*` to `Auto`.

    The `Auto` value automatically sizes the grid row to the size of its contents, in this case, the label control.

    :::code language="xaml" source="snippets/create-app-visual-studio/csharp/LayoutStep4.xaml" range="11-14" highlight="2":::

    Notice that the designer now shows the label occupying a small amount of the available height. There's now more room for the next row to occupy.

    :::image type="content" source="media/create-app-visual-studio/vs-designer-grid-rows-columns-label.png" alt-text="A WPF app with the margin set on a grid and a label control in the first row":::

### Control placement

Let's talk about control placement. The label created in the previous section was automatically placed in row 0 and column 0 of the grid. The numbering for rows and columns starts at 0 and increments by 1. The control doesn't know anything about the grid, and the control doesn't define any properties to control its placement within the grid.

How do you tell a control to use a different row or column when the control has no knowledge of the grid? Attached properties! The grid takes advantage of the powerful property system provided by WPF.

The grid control defines new properties that the child controls can attach to themselves. The properties don't actually exist on the control itself, they're available to the control once it's added to the grid.

The grid defines two properties to determine the row and column placement of a child control: `Grid.Row` and `Grid.Column`. If these properties are omitted from the control, it's implied that they have the default values of 0, so, the control is placed in row `0` and column `0` of the grid. Try changing the placement of the `<Label>` control by setting the `Grid.Column` attribute to `1`:

```xaml
<Label Grid.Column="1">Names</Label>
```

Notice that the label moved to the second column. You can use the `Grid.Row` and `Grid.Column` attached properties to place the next controls we'll create. For now though, restore the label to column 0.

## Create the name list box

Now that the grid is correctly sized and the label created, add a list box control on the row below the label.

01. Declare the `<ListBox />` control under the `<Label>` control.
01. Set the `Grid.Row` property to `1`.
01. Set the `x:Name` property to `lstNames`.

    Once a control is named, it can be referenced in the code-behind. The name is assigned to the control with the `x:Name` attribute.

Here's what the XAML should look like:

:::code language="xaml" source="snippets/create-app-visual-studio/csharp/MoreControls1.xaml" range="9-24" highlight="14":::

## Add the remaining controls

The last two controls we'll add are a text box and a button, which the user uses to enter a name to add to the list box. However, instead of trying to create more rows and columns in the grid to arrange these controls, we'll put these controls into the `<StackPanel>` layout control.

The stack panel differs from the grid in how the controls are placed. While you tell the grid where you want the controls to be with the `Grid.Row` and `Grid.Column` attached properties, the stack panel works automatically laying out each of its child controls sequentially. It "stacks" each control after the other.

01. Declare the `<StackPanel>` control under the `<ListBox>` control.
01. Set the `Grid.Row` property to `1`.
01. Set the `Grid.Column` property to `1`.
01. Set the `Margin` to `5,0,0,0`.

    :::code language="xaml" source="snippets/create-app-visual-studio/csharp/MoreControls2.xaml" id="StackPanel1" highlight="14-16":::

    The `Margin` attribute was previously used on the grid, but we only put in a single value, `10`. This margin has a value of `5,0,0,0`, which is very different from `10`. The margin property is a `Thickness` type and can interpret both values. A thickness defines the space around each side of a rectangular frame, **left**, **top**, **right**, **bottom**, respectively. If the value for the margin is a single value, it uses that value for all four sides.

01. Inside of the `<StackPanel>` control, create a `<TextBox />` control.

    01. Set the `x:Name` property to `txtName`.

01. Lastly, after the `<TextBox>`, still inside of the `<StackPanel>`, create a `<Button>` control.

    01. Set the `x:Name` property to `btnAdd`.
    01. Set the `Margin` to `0,5,0,0`.
    01. Set the content to `Add Name`.

Here's what the XAML should look like:

:::code language="xaml" source="snippets/create-app-visual-studio/csharp/MoreControls2.xaml" id="StackPanel2":::

The layout for the window is complete. However, our app doesn't have any logic in it to actually be functional. Next, we need to hook up the control events to code and get the app to actually do something.

## Add code for the Click event

The `<Button>` we created has a `Click` event that is raised when the user presses the button. You can subscribe to this event and add code to add a name to the list box. XAML attributes are used to subscribed to events just like they're used to set properties.

01. Locate the `<Button>` control.
01. Set the `Click` attribute to `ButtonAddName_Click`

    :::code language="xaml" source="snippets/create-app-visual-studio/csharp/MoreControls3.xaml" id="ButtonEvent" highlight="3":::

01. Generate the event handler code. Right-click on `ButtonAddName_Click` and select **Go To Definition**.

    This action generates a method in the code-behind that matches the handler name provided.

    :::code language="csharp" source="snippets/create-app-visual-studio/csharp/MoreControls3.xaml.cs" id="ButtonEvent":::
    :::code language="vb" source="snippets/create-app-visual-studio/vb/MoreControls3.xaml.vb" id="ButtonEvent":::

01. Next, add the following code to do these three steps:

    01. Make sure that the text box contains a name.
    01. Validate that the name entered in the text box doesn't already exist.
    01. Add the name to the list box.

    :::code language="csharp" source="snippets/create-app-visual-studio/csharp/Final.xaml.cs" id="FinalCode":::
    :::code language="vb" source="snippets/create-app-visual-studio/vb/Final.xaml.vb" id="FinalCode":::

## Run the app

Now that the event is handled, run the app. The window is displayed and you can enter a name in the textbox and then add it by clicking the button.

:::image type="content" source="media/create-app-visual-studio/app-finished.png" alt-text="Running a Windows Presentation Foundation (WPF) for .NET app.":::

## Related content

- [Learn more about Windows Presentation Foundation](../overview/index.md)
- [XAML overview](../xaml/index.md)
