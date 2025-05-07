---
title: Controls
description: This article introduces WPF controls, detailing their creation, styling, templating, events, and rich content support via XAML or code.
ms.date: 02/19/2025
ms.service: dotnet-desktop
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "controls [WPF], about WPF controls"

#customer intent: As a developer, I want to understand WPF controls so that I know their capabilities, especially in ways they compare to other desktop technologies.
---
# What are controls?

Windows Presentation Foundation (WPF) ships with many of the common UI components that are used in almost every Windows app, such as <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.Label>, <xref:System.Windows.Controls.TextBox>, <xref:System.Windows.Controls.Menu>, and <xref:System.Windows.Controls.ListBox>. Historically, these objects are referred to as controls. The term "control" is used loosely to mean any class that represents a visible object in an app. It's important to note that a class doesn't need to inherit from the <xref:System.Windows.Controls.Control> class to have a visible presence. Classes that inherit from the `Control` class contain a <xref:System.Windows.Controls.ControlTemplate>, which allows the consumer of a control to radically change the control's appearance without having to create a new subclass. This article discusses how controls (both those that do inherit from the `Control` class and those that don't) are commonly used in WPF.

## Create an instance of a control

You can add a control to an app by using either Extensible Application Markup Language (XAML) or code. For example, consider the following image of a WPF window that asks a user for their name and address:

:::image type="content" source="./media/index/xaml-example.png" alt-text="A screenshot of a WPF app with two text boxes labeled name and address. Two buttons are visible. One button is named 'Reset' and the other 'Submit.'":::

This window has six controls: two labels, two text boxes, and two buttons. XAML is used to create these controls, as demonstrated in the following snippet:

:::code language="xaml" source="./snippets/index/csharp/ExampleApp.xaml":::

All controls can be created similarly in XAML. The same window can be created in code:

:::code language="csharp" source="./snippets/index/csharp/MainWindow.xaml.cs" id="ExampleAppCode":::
:::code language="vb" source="./snippets/index/vb/MainWindow.xaml.vb" id="ExampleAppCode":::

## Subscribe to events

You can subscribe to a control's event by using either XAML or code, but you can only handle an event in code.

In XAML, the event is set as an attribute on the element. You can't use the `<Element.Event>handler<Element.Event>` notation for events. The following snippet shows how to subscribe to the `Click` event of a <xref:System.Windows.Controls.Button>:

:::code language="xaml" source="./snippets/index/csharp/ButtonClickEventExample.xaml" id="Event":::

And here's how to do the same in code:

:::code language="csharp" source="./snippets/index/csharp/MainWindow.xaml.cs" id="Event":::
:::code language="vb" source="./snippets/index/vb/MainWindow.xaml.vb" id="Event":::

The following snippet handles the `Click` event of a <xref:System.Windows.Controls.Button>:

:::code language="csharp" source="./snippets/index/csharp/ButtonClickEventExample.xaml.cs" id="ClickHandler":::
:::code language="vb" source="./snippets/index/vb/ButtonClickEventExample.xaml.vb" id="ClickHandler":::

## Change the appearance of a control

It's common to change the appearance of a control to fit the look and feel of your app. You can change the appearance of a control by doing one of the following, depending on what you want to accomplish:

- Change the value of a property of the control.
- Create a <xref:System.Windows.Style> for the control.
- Create a new <xref:System.Windows.Controls.ControlTemplate> for the control.

### Change a control's property

Many controls have properties that allow you to change how the control appears, such as a button's background. You can set the value properties in both XAML and code. The following example sets the <xref:System.Windows.Controls.Control.Background%2A>, <xref:System.Windows.Controls.Control.FontSize%2A>, and <xref:System.Windows.Controls.Control.FontWeight%2A> properties on a `Button` in XAML:

:::code language="xaml" source="./snippets/index/csharp/ButtonPropertyWindow.xaml" id="Properties":::

And here's how to do the same in code:

:::code language="csharp" source="./snippets/index/csharp/MainWindow.xaml.cs" id="Properties":::
:::code language="vb" source="./snippets/index/vb/MainWindow.xaml.vb" id="Properties":::

The example window now looks like the following image:

:::image type="content" source="./media/index/xaml-example-property.png" alt-text="A screenshot of a WPF app with two text boxes labeled name and address. Two buttons are visible. One button is named 'Reset' and the other 'Submit.' The 'Submit' button has a gradient background that transitions from a blue to a lighter blue.":::

### Create a style for a control

WPF gives you extensive ability to specify the appearance of controls by creating a <xref:System.Windows.Style>, instead of setting properties on each control. `Style` definitions are typically defined in XAML in a <xref:System.Windows.ResourceDictionary>, such as the <xref:System.Windows.FrameworkElement.Resources%2A> property of a control or Window. Resources are applied to the scope in which they're declared. For more information, see [Overview of XAML resources](../systems/xaml-resources-overview.md).

The following example applies a `Style` to every <xref:System.Windows.Controls.Button> contained in the same `Grid` that defines the style:

:::code language="xaml" source="./snippets/index/csharp/ButtonStyleWindow.xaml" id="Style":::

And here's how to do the same in code:

:::code language="csharp" source="./snippets/index/csharp/MainWindow.xaml.cs" id="Style":::
:::code language="vb" source="./snippets/index/vb/MainWindow.xaml.vb" id="Style":::

The following image shows the style applied to the grid of the window, which changes the appearance of the two buttons:

:::image type="content" source="./media/index/xaml-example-style.png" alt-text="A screenshot of a WPF app with two text boxes labeled name and address. Two buttons are visible. One button is named 'Reset' and the other 'Submit.' Both buttons feature a gradient background that transitions from a blue to a lighter blue.":::

Instead of applying the style to all controls of a specific type, they can also be assigned to specific controls by adding a key to the style in the resource dictionary, and referencing that key in the `Style` property of the control. For more information about styles, see [Styling and Templating](styles-templates-overview.md).

### Create a ControlTemplate

A `Style` allows you to set properties on multiple controls at a time, but sometimes you might want to customize the appearance of a control beyond what you can do with a <xref:System.Windows.Style>. Classes that inherit from the <xref:System.Windows.Controls.Control> class have a <xref:System.Windows.Controls.ControlTemplate>, which defines the structure and appearance of a control.

Consider the <xref:System.Windows.Controls.Button> control, a common control used by almost every app. The primary behavior of a button is to enable an app to take some action when the user selects the button. By default, the button in WPF appears as a raised rectangle. While developing an app, you might want to take advantage of the behavior of a button&mdash;that is, how the user interacts with the button, which raises a `Click` event&mdash;but you might change the button's appearance beyond what you can do by changing the button's properties. In this case, you can create a new <xref:System.Windows.Controls.ControlTemplate>.

The following example creates a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.Button>. The `ControlTemplate` creates a visual for the `Button` that presents a border with rounded corners and a gradient background.

:::code language="xaml" source="./snippets/index/csharp/ButtonTemplateWindow.xaml" id="Template":::

> [!NOTE]
> The <xref:System.Windows.Controls.Control.Background%2A> property of the <xref:System.Windows.Controls.Button> must be set to a <xref:System.Windows.Media.SolidColorBrush> for the example to work properly.

And here's how to do the same in code. The following code creates a XAML string and parses it to generate a template that can be applied, which is the supported way to generate a template at run-time.

:::code language="csharp" source="./snippets/index/csharp/MainWindow.xaml.cs" id="Template":::
:::code language="vb" source="./snippets/index/vb/MainWindow.xaml.vb" id="Template":::

The following image shows what the template looks like when applied:

:::image type="content" source="./media/index/xaml-example-template.png" alt-text="A screenshot of a WPF app with two text boxes labeled name and address. Two buttons are visible. One button is named 'Reset' and the other 'Submit.' The 'Submit' button has rounded corners and a peach color applied to it.":::

In the previous example, the `ControlTemplate` is applied to a single button. However, a `ControlTemplate` can be assigned to a `Style` and applied to all buttons, like what was demonstrated in the [Create a style for a control](#create-a-style-for-a-control) section.

For more information about how to take advantage of the unique features a template provides, see [Styling and Templating](styles-templates-overview.md).

## Rich content in controls

Most classes that inherit from the <xref:System.Windows.Controls.Control> class have the capacity to contain rich content. For example, a <xref:System.Windows.Controls.Label> can contain any object, such as a string, an <xref:System.Windows.Controls.Image>, or a <xref:System.Windows.Controls.Panel>. The following classes provide support for rich content and act as base classes for most of the controls in WPF:

- <xref:System.Windows.Controls.ContentControl>&mdash;Some examples of classes that inherit from this class are <xref:System.Windows.Controls.Label>, <xref:System.Windows.Controls.Button>, and <xref:System.Windows.Controls.ToolTip>.

- <xref:System.Windows.Controls.ItemsControl>&mdash;Some examples of classes that inherit from this class are <xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.Menu>, and <xref:System.Windows.Controls.Primitives.StatusBar>.

- <xref:System.Windows.Controls.HeaderedContentControl>&mdash;Some examples of classes that inherit from this class are <xref:System.Windows.Controls.TabItem>, <xref:System.Windows.Controls.GroupBox>, and <xref:System.Windows.Controls.Expander>.

- <xref:System.Windows.Controls.HeaderedItemsControl>&mdash;Some examples of classes that inherit from this class are <xref:System.Windows.Controls.MenuItem>, <xref:System.Windows.Controls.TreeViewItem>, and <xref:System.Windows.Controls.ToolBar>.

<!--For more information about these base classes, see [WPF Content Model](wpf-content-model.md).-->

## Related content

- [Styling and Templating](styles-templates-overview.md)
- [Data binding overview](../data/index.md)
