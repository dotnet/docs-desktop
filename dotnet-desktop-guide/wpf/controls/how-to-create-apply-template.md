---
title: How to create a template
description: Learn how to create and reference a control template in Windows Presentation Foundation and .NET. Templates can be implemented in a resource dictionary.
author: adegeo
ms.author: adegeo
ms.date: 03/20/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
no-loc: ["<Window>", "<ControlTemplate>", "<Ellipse>", "<ContentPresenter>", "<Trigger>", "<Setter>", "<PropertyTrigger>", "<Grid>", "<VisualStateManager.VisualStateGroups>", "<VisualStateGroup>", "<VisualState>", "<Storyboard>", "SizeToContent", "MinWidth", "TargetType", "Title"]
ms.topic: how-to
ms.custom: update-template
helpviewer_keywords:
  - "control contract [WPF]"
  - "controls [WPF], visual structure changes"
  - "ControlTemplate [WPF], customizing for existing controls"
  - "skinning controls [WPF]"
  - "controls [WPF], appearance specified by state"
  - "templates [WPF], custom for existing controls"

#customer intent: As a developer I want to create a template to a control.

---

# How to create a template for a control (WPF.NET)

With Windows Presentation Foundation (WPF), you can customize an existing control's visual structure and behavior with your own reusable template. Templates can be applied globally to your application, windows and pages, or directly to controls. Most scenarios that require you to create a new control can be covered by instead creating a new template for an existing control.

In this article, you explore creating a new <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Button> control.

## When to create a ControlTemplate

Controls have many properties, such as <xref:System.Windows.Controls.Border.Background%2A>, <xref:System.Windows.Controls.Control.Foreground%2A>, and <xref:System.Windows.Controls.Control.FontFamily%2A>. These properties control different aspects of the control's appearance, but the changes that you can make by setting these properties are limited. For example, you can set the <xref:System.Windows.Controls.Control.Foreground%2A> property to blue and <xref:System.Windows.Controls.Control.FontStyle%2A> to italic on a <xref:System.Windows.Controls.CheckBox>. When you want to customize the control's appearance beyond what setting the other properties on the control can do, you create a <xref:System.Windows.Controls.ControlTemplate>.

In most user interfaces, a button has the same general appearance: a rectangle with some text. If you want to create a rounded button, you could create a new control that inherits from the button or recreates the functionality of the button. In addition, the new user control provides the circular visual.

You can avoid creating new controls by customizing the visual layout of an existing control. For a rounded button, you create a <xref:System.Windows.Controls.ControlTemplate> with the desired visual layout.

On the other hand, if you need a control with new functionality, different properties, and new settings, you create a new <xref:System.Windows.Controls.UserControl>.

## Prerequisites

Create a new WPF application. In *MainWindow.xaml* (or another window of your choice), set the following properties on the **\<Window>** element:

| Property          | Value                   |
|-------------------|-------------------------|
| **Title**         | `Template Intro Sample` |
| **SizeToContent** | `WidthAndHeight`        |
| **MinWidth**      | `250`                   |

Set the content of the **\<Window>** element to the following XAML:

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window1.xaml" id="Initial":::

At the end, the *MainWindow.xaml* file should look similar to the following XAML:

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window1.xaml" id="InitialWhole":::

If you run the application, it looks like the following image:

:::image type="content" source="media/how-to-create-apply-template/unstyled-button.png" alt-text="WPF window with two unstyled buttons":::

## Create a ControlTemplate

The most common way to declare a <xref:System.Windows.Controls.ControlTemplate> is as a resource in the `Resources` section in a XAML file. Because templates are resources, they follow the same scoping rules as all resources. Where you declare a template affects where you can apply it. For example, if you declare the template in the root element of your application definition XAML file, you can use the template anywhere in your application. If you define the template in a window, only the controls in that window can use the template.

To start, add a `Window.Resources` element to your *MainWindow.xaml* file:

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window2.xaml" id="WindowResStart":::

Create a new **\<ControlTemplate>** and set the following properties:

| Property       | Value         |
|----------------|---------------|
| **x:Key**      | `roundbutton` |
| **TargetType** | `Button`      |

This control template is simple:

- a root element for the control, a <xref:System.Windows.Controls.Grid>
- an <xref:System.Windows.Shapes.Ellipse> to draw the rounded appearance of the button
- a <xref:System.Windows.Controls.ContentPresenter> to display the user-specified button content

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window3.xaml" id="ControlTemplate":::

### TemplateBinding

When you create a new <xref:System.Windows.Controls.ControlTemplate>, you might still want to use the public properties to change the control's appearance. The [TemplateBinding](../advanced/templatebinding-markup-extension.md) markup extension binds a property of an element that is in the <xref:System.Windows.Controls.ControlTemplate> to a public property that the control defines. When you use a [TemplateBinding](../advanced/templatebinding-markup-extension.md), you enable properties on the control to act as parameters to the template. When you set a property on a control, the value passes to the element that has the [TemplateBinding](../advanced/templatebinding-markup-extension.md).

### Ellipse

The **Fill** and **Stroke** properties of the **\<Ellipse>** element bind to the control's <xref:System.Windows.Controls.Control.Foreground> and <xref:System.Windows.Controls.Control.Background> properties.

### ContentPresenter

The template also includes a [\<ContentPresenter>](xref:System.Windows.Controls.ContentPresenter) element. Because this template is designed for a button, remember that the button inherits from <xref:System.Windows.Controls.ContentControl>. The button displays the content of the element. You can set anything inside the button, such as plain text or even another control. Both of the following examples are valid buttons:

```xaml
<Button>My Text</Button>

<!-- and -->

<Button>
    <CheckBox>Checkbox in a button</CheckBox>
</Button>
```

In both of the previous examples, the text and the checkbox are set as the [Button.Content](xref:System.Windows.Controls.ContentControl.Content) property. Whatever is set as the content can be presented through a **\<ContentPresenter>**, which is what the template does.

If you apply the <xref:System.Windows.Controls.ControlTemplate> to a <xref:System.Windows.Controls.ContentControl> type, such as a `Button`, the template looks for a <xref:System.Windows.Controls.ContentPresenter> in the element tree. If it finds the `ContentPresenter`, the template automatically binds the control's <xref:System.Windows.Controls.ContentControl.Content> property to the `ContentPresenter`.

## Use the template

Find the buttons that you declared at the start of this article.

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window1.xaml" id="Initial":::

Set the second button's <xref:System.Windows.Controls.Control.Template> property to the `roundbutton` resource:

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window3.xaml" id="StyledButton":::

If you run the project and look at the result, you see that the button has a rounded background.

:::image type="content" source="media/how-to-create-apply-template/styled-button.png" alt-text="WPF window with one template oval button":::

You might notice that the button isn't a circle but is skewed. Because of the way the **\<Ellipse>** element works, it always expands to fill the available space. Make the circle uniform by changing the button's  **:::no-loc text="width":::** and **:::no-loc text="height":::** properties to the same value:

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window3.xaml" id="StyledButtonSize":::

:::image type="content" source="media/how-to-create-apply-template/styled-uniform-button.png" alt-text="WPF window with one template circular button":::

## Add a trigger

Even though a button with a template applied looks different, it behaves the same as any other button. If you press the button, the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event fires. However, you might notice that when you move your mouse over the button, the button's visuals don't change. The template defines these visual interactions.

By using the dynamic event and property systems that WPF provides, you can watch a specific property for a value and then restyle the template when appropriate. In this example, you watch the button's <xref:System.Windows.UIElement.IsMouseOver> property. When the mouse is over the control, style the **\<Ellipse>** with a new color. This type of trigger is known as a *PropertyTrigger*.

For this feature to work, you need to add a name to the **\<Ellipse>** that you can reference. Give it the name of **backgroundElement**.

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window4.xaml" id="EllipseName":::

Next, add a new <xref:System.Windows.Trigger> to the [ControlTemplate.Triggers](xref:System.Windows.Controls.ControlTemplate.Triggers) collection. The trigger watches the `IsMouseOver` event for the value `true`.

[!code-xaml[ControlTemplate](./snippets/how-to-create-apply-template/csharp/Window4.xaml?name=ControlTemplate&highlight=6-10)]

Next, add a **\<Setter>** to the **\<Trigger>** that changes the **Fill** property of the **\<Ellipse>** to a new color.

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window5.xaml" id="MouseOver":::

Run the project. When you move the mouse over the button, the color of the **\<Ellipse>** changes.

:::image type="content" source="media/how-to-create-apply-template/mouse-move-over-button.gif" alt-text="mouse moves over WPF button to change the fill color":::

## Use a VisualState

Visual states are defined and triggered by a control. For example, when you move the mouse over the control, the control triggers the `CommonStates.MouseOver` state. You can animate property changes based on the current state of the control. In the previous section, you used a **\<PropertyTrigger>** to change the background of the button to `AliceBlue` when the `IsMouseOver` property was `true`. Instead, create a visual state that animates the change of this color, providing a smooth transition. For more information about *VisualStates*, see [Styles and templates in WPF](styles-templates-overview.md#visual-states).

To convert the **\<PropertyTrigger>** to an animated visual state, remove the **\<ControlTemplate.Triggers>** element from your template.

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window5.xaml" id="CleanTemplate":::

Next, in the **\<Grid>** root of the control template, add the **\<VisualStateManager.VisualStateGroups>** element with a **\<VisualStateGroup>** for `CommonStates`. Define two states, `Normal` and `MouseOver`.

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window6.xaml" id="VisualState":::

Apply any animations you define in a **\<VisualState>** when that state is triggered. Create animations for each state. Put animations inside of a **\<Storyboard>** element. For more information about storyboards, see [Storyboards Overview](../graphics-multimedia/storyboards-overview.md).

- Normal

  This state animates the ellipse fill, restoring it to the control's `Background` color.

  :::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window6.xaml" id="NormalState":::

- MouseOver

  This state animates the ellipse `Background` color to a new color: `Yellow`.

  :::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window6.xaml" id="MouseOverState":::

The **\<ControlTemplate>** should now look like the following code.

:::code language="xaml" source="./snippets/how-to-create-apply-template/csharp/Window7.xaml" id="FinalTemplate":::

Run the project. When you move the mouse over the button, the color of the **\<Ellipse>** animates.

:::image type="content" source="media/how-to-create-apply-template/mouse-move-over-button-visualstate.gif" alt-text="mouse moves over WPF button to change the fill color with a visual state":::

## Next steps

- [Create a style for a control](how-to-create-apply-style.md)
- [Styles and templates](styles-templates-overview.md)
- [Overview of XAML resources](../systems/xaml-resources-overview.md)
