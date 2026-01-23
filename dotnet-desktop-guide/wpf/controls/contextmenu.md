---
title: "ContextMenu"
description: Learn about the ContextMenu, which allows a control to display a Menu that is specific to the context of the control.
ms.date: "10/29/2025"
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "ContextMenu control [WPF]"
  - "menus [WPF], context"
  - "controls [WPF], ContextMenu"
ai-usage: ai-assisted
---
# ContextMenu

The <xref:System.Windows.Controls.ContextMenu> class represents the element that exposes functionality by using a context-specific <xref:System.Windows.Controls.Menu>. A <xref:System.Windows.Controls.ContextMenu> is attached to a specific control and enables you to present users with a list of items that specify commands or options associated with a particular control, such as a <xref:System.Windows.Controls.Button>.

Typically, users expose the <xref:System.Windows.Controls.ContextMenu> in the user interface (UI) through the right mouse button. When users right-click the control, the menu appears. Clicking a <xref:System.Windows.Controls.MenuItem> typically opens a submenu or causes an application to execute a command.

:::image type="content" source="./media/shared/contextmenu.png" alt-text="Screenshot showing a ContextMenu in default and open states.":::

## Creating a ContextMenu

You can create a <xref:System.Windows.Controls.ContextMenu> either by declaring it in XAML or by building it programmatically in code.

The following example shows how to declare a context menu in XAML:

:::code language="xaml" source="./snippets/contextmenu/net/csharp/MainWindow.xaml" id="BasicContextMenu":::

The next example demonstrates how to create a context menu programmatically in code:

:::code language="csharp" source="./snippets/contextmenu/net/csharp/MainWindow.xaml.cs" id="ProgrammaticContextMenu":::
:::code language="vb" source="./snippets/contextmenu/net/vb/MainWindow.xaml.vb" id="ProgrammaticContextMenu":::

## Applying styles to a ContextMenu

By using a control <xref:System.Windows.Style>, you can dramatically change the appearance and behavior of a <xref:System.Windows.Controls.ContextMenu> without writing a custom control. You can set visual properties and apply styles to parts of a control. For example, you can change the behavior of parts of the control by using properties, or you can add parts to, or change the layout of, a <xref:System.Windows.Controls.ContextMenu>. The following examples show several ways to add styles to <xref:System.Windows.Controls.ContextMenu> controls.

The first example defines a style called `SimpleSysResources`, which shows how to use current system settings in your style. The example assigns <xref:System.Windows.SystemColors.MenuHighlightBrushKey%2A> as the <xref:System.Windows.Controls.Control.Background%2A> color and <xref:System.Windows.SystemColors.MenuTextBrushKey%2A> as the <xref:System.Windows.Controls.Control.Foreground%2A> color of the <xref:System.Windows.Controls.ContextMenu>.

```xaml
<Style x:Key="SimpleSysResources" TargetType="{x:Type MenuItem}">
  <Setter Property = "Background" Value=
    "{DynamicResource {x:Static SystemColors.MenuHighlightBrushKey}}"/>
  <Setter Property = "Foreground" Value=
    "{DynamicResource {x:Static SystemColors.MenuTextBrushKey}}"/>
</Style>
```

The following example uses the <xref:System.Windows.Trigger> element to change the appearance of a <xref:System.Windows.Controls.Menu> in response to events raised on the <xref:System.Windows.Controls.ContextMenu>. When a user moves the mouse over the menu, the appearance of the <xref:System.Windows.Controls.ContextMenu> items changes.

```xaml
<Style x:Key="Triggers" TargetType="{x:Type MenuItem}">
  <Style.Triggers>
    <Trigger Property="MenuItem.IsMouseOver" Value="true">
      <Setter Property = "FontSize" Value="16"/>
      <Setter Property = "FontStyle" Value="Italic"/>
      <Setter Property = "Foreground" Value="Red"/>
    </Trigger>
  </Style.Triggers>
</Style>
```

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.ContextMenu> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Styles and templates](styles-templates-overview.md) and [Create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ContextMenu> control uses the <xref:System.Windows.Controls.ItemsControl.Items%2A> property as its content property, which contains the menu items displayed in the context menu.

### Parts

The <xref:System.Windows.Controls.ContextMenu> control doesn't define any named template parts.

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ContextMenu>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ContextMenu>, and the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control. If the <xref:System.Windows.Controls.ItemsPresenter> isn't the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ContextMenu> control.

| Visual state name | Visual state group name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## See also

- <xref:System.Windows.Controls.ContextMenu>
- <xref:System.Windows.Controls.Menu>
- <xref:System.Windows.Controls.MenuItem>
- <xref:System.Windows.Style>
- [WPF Controls Gallery Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Getting%20Started/ControlsAndLayout)
