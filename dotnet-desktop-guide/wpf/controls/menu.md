---
title: "Menu"
description: Learn about the Menu control in Windows Presentation Foundation (WPF), which allows hierarchical organization of elements associated with commands and event handlers.
ms.date: 01/28/2026
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "Menu control [WPF]"
  - "controls [WPF], Menu"
ai-usage: ai-assisted
---
# Menu

The <xref:System.Windows.Controls.Menu> class enables you to organize elements associated with commands and event handlers in a hierarchical order. Each <xref:System.Windows.Controls.Menu> element contains a collection of <xref:System.Windows.Controls.MenuItem> elements.

:::image type="content" source="./media/shared/menu-menuitem.png" alt-text="Screenshot showing a Menu control with multiple MenuItem controls.":::

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.Menu> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.Menu> control uses the <xref:System.Windows.Controls.ItemsControl.Items%2A> property as its content property. This property allows you to populate the `Menu` with a collection of [`MenuItem`](menuitem.md) elements that users can interact with.

### Parts

The <xref:System.Windows.Controls.Menu> control doesn't have any named parts.

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.Menu>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.Menu>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control. If the <xref:System.Windows.Controls.ItemsPresenter> isn't the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Menu> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control doesn't have focus.|

## Key concepts

The following concepts are important when working with the <xref:System.Windows.Controls.Menu> control.

### MenuItems with keyboard shortcuts

Keyboard shortcuts are character combinations that can be entered with the keyboard to invoke <xref:System.Windows.Controls.Menu> commands. For example, the shortcut for **Copy** is CTRL+C. There are two properties to use with keyboard shortcuts and menu items—<xref:System.Windows.Controls.MenuItem.InputGestureText%2A> or <xref:System.Windows.Controls.MenuItem.Command%2A>.

### InputGestureText

Use the <xref:System.Windows.Controls.MenuItem.InputGestureText%2A> property to assign keyboard shortcut text to <xref:System.Windows.Controls.MenuItem> controls. This only places the keyboard shortcut in the menu item. It doesn't associate the command with the <xref:System.Windows.Controls.MenuItem>. The application must handle the user's input to carry out the action.

### Command

Use the <xref:System.Windows.Controls.MenuItem.Command%2A> property to associate commands like **Open** and **Save** with <xref:System.Windows.Controls.MenuItem> controls. The command property not only associates a command with a <xref:System.Windows.Controls.MenuItem>, but it also supplies the input gesture text to use as a shortcut.

The <xref:System.Windows.Controls.MenuItem> class also has a <xref:System.Windows.Controls.MenuItem.CommandTarget%2A> property, which specifies the element where the command occurs. If <xref:System.Windows.Controls.MenuItem.CommandTarget%2A> isn't set, the element that has keyboard focus receives the command. For more information about commands, see [Commanding Overview](../advanced/commanding-overview.md).

## Examples

The following examples demonstrate how to use the <xref:System.Windows.Controls.Menu> control in different scenarios.

### Creating menus

The <xref:System.Windows.Controls.Menu> control presents a list of items that specify commands or options for an application. Typically, clicking a <xref:System.Windows.Controls.MenuItem> opens a submenu or causes an application to carry out a command.

The following example creates a <xref:System.Windows.Controls.Menu> to manipulate text in a <xref:System.Windows.Controls.TextBox>. The <xref:System.Windows.Controls.Menu> contains <xref:System.Windows.Controls.MenuItem> objects that use the <xref:System.Windows.Controls.MenuItem.Command%2A>, <xref:System.Windows.Controls.MenuItem.IsCheckable%2A>, and <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> properties and the <xref:System.Windows.Controls.MenuItem.Checked>, <xref:System.Windows.Controls.MenuItem.Unchecked>, and <xref:System.Windows.Controls.MenuItem.Click> events.

[!code-xaml[MenuItemCommandsAndEvents#1](../../samples/snippets/csharp/VS_Snippets_Wpf/MenuItemCommandsAndEvents/CSharp/Window1.xaml#1)]

[!code-csharp[MenuItemCommandsAndEvents#2](../../samples/snippets/csharp/VS_Snippets_Wpf/MenuItemCommandsAndEvents/CSharp/Window1.xaml.cs#2)]
[!code-vb[MenuItemCommandsAndEvents#2](../../samples/snippets/visualbasic/VS_Snippets_Wpf/MenuItemCommandsAndEvents/VisualBasic/Window1.xaml.vb#2)]

### Using InputGestureText with MenuItems

The following example shows how to use the <xref:System.Windows.Controls.MenuItem.InputGestureText%2A> property to assign keyboard shortcut text to <xref:System.Windows.Controls.MenuItem> controls:

[!code-xaml[MenuEvent#6](../../samples/snippets/csharp/VS_Snippets_Wpf/MenuEvent/CSharp/Pane1.xaml#6)]

### Using Command property with MenuItems

The following example shows how to use the <xref:System.Windows.Controls.MenuItem.Command%2A> property to associate the **Open** and **Save** commands with <xref:System.Windows.Controls.MenuItem> controls:

[!code-xaml[MenuEvent#8](../../samples/snippets/csharp/VS_Snippets_Wpf/MenuEvent/CSharp/Pane1.xaml#8)]

## See also

- [MenuItem](menuitem.md)
- [WPF Controls Gallery Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Getting%20Started/ControlsAndLayout)
- <xref:System.Windows.Controls.Menu>
- <xref:System.Windows.Controls.MenuItem>
- <xref:System.Windows.Controls.ContextMenu>
- <xref:System.Windows.Controls.Primitives.MenuBase>
