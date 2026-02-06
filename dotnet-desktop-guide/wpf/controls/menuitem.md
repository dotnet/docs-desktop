---
title: "MenuItem"
description: Learn about the MenuItem control in Windows Presentation Foundation (WPF), which represents individual selectable items within Menu and ContextMenu controls.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "MenuItem control [WPF]"
  - "controls [WPF], MenuItem"
ai-usage: ai-assisted
---
# MenuItem

The <xref:System.Windows.Controls.MenuItem> control represents individual selectable items within a <xref:System.Windows.Controls.Menu> or <xref:System.Windows.Controls.ContextMenu>. MenuItem is the fundamental building block of menu systems in WPF applications, providing the interactive elements that users click or select to perform actions.

:::image type="content" source="./media/shared/menu-menuitem.png" alt-text="Screenshot showing a Menu control with multiple MenuItem controls.":::

For examples on using menus, see [Menu: Exmaples](menu.md#examples).

## MenuItem and Menu relationship

A <xref:System.Windows.Controls.Menu> serves as a container for <xref:System.Windows.Controls.MenuItem> objects, establishing a parent-child relationship where:

- The Menu control provides the overall structure and layout for organizing menu items.
- Each MenuItem represents a specific command, option, or submenu within that structure.
- MenuItems can contain other MenuItems as children, creating hierarchical submenus of unlimited depth.
- MenuItems inherit the styling and behavioral properties from their parent Menu unless explicitly overridden.

This hierarchical relationship allows you to create complex navigation structures, from simple flat menus to deeply nested submenu systems.

## MenuItem types and behaviors

MenuItems support several different types of behaviors:

**Command items**: MenuItems that execute specific commands when clicked. These are typically used for actions like **File > Open** or **Edit > Copy**.

**Checkable items**: MenuItems that can be toggled on and off, similar to checkboxes. Set the <xref:System.Windows.Controls.MenuItem.IsCheckable%2A> property to `true` to enable this behavior.

**Separator items**: Use <xref:System.Windows.Controls.Separator> controls within a Menu to visually group related MenuItems.

**Submenu items**: MenuItems that contain other MenuItems as children. When clicked or hovered, they display a submenu with additional options.

## MenuItem properties and events

Key properties of MenuItem include:

- <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A>: The content displayed in the menu item.
- <xref:System.Windows.Controls.MenuItem.Command%2A>: The command to execute when the item is selected.
- <xref:System.Windows.Controls.MenuItem.IsCheckable%2A>: Whether the item can be checked and unchecked.
- <xref:System.Windows.Controls.MenuItem.IsChecked%2A>: The current checked state of a checkable item.
- <xref:System.Windows.Controls.MenuItem.InputGestureText%2A>: Text that represents the keyboard shortcut for the item.
- <xref:System.Windows.Controls.MenuItem.Icon%2A>: An icon to display alongside the menu item text.

Important events include <xref:System.Windows.Controls.MenuItem.Click>, <xref:System.Windows.Controls.MenuItem.Checked>, and <xref:System.Windows.Controls.MenuItem.Unchecked>.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.MenuItem> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control doesn't define a content property.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.MenuItem> control.

| Part       | Type                                            | Description                                |
|------------|-------------------------------------------------|--------------------------------------------|
| PART_Popup | <xref:System.Windows.Controls.Primitives.Popup> | The popup that contains the submenu items. |

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.MenuItem>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.MenuItem>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control. If the <xref:System.Windows.Controls.ItemsPresenter> isn't the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.MenuItem> control.

| VisualState Name | VisualStateGroup Name | Description                                                         |
|------------------|-----------------------|---------------------------------------------------------------------|
| Valid            | ValidationStates      | The control is valid and has no validation errors.                  |
| InvalidFocused   | ValidationStates      | The control has a validation error and has keyboard focus.          |
| InvalidUnfocused | ValidationStates      | The control has a validation error but doesn't have keyboard focus. |

## See also

- <xref:System.Windows.Controls.ContextMenu>
- <xref:System.Windows.Controls.Menu>
- <xref:System.Windows.Controls.MenuItem>
- <xref:System.Windows.Controls.Primitives.MenuBase>
- [Menu](menu.md)
