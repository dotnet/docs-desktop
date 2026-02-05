---
title: "Popup"
description: Learn how to use the Popup control to display content in a separate window that floats over the current application window.
ms.date: "02/05/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "Popup control [WPF]"
  - "content [WPF], Popup control"
  - "popups [WPF]"
  - "controls [WPF], Popup"
ai-usage: ai-assisted
---
# Popup

The <xref:System.Windows.Controls.Primitives.Popup> control provides a way to display content in a separate window that floats over the current application window relative to a designated element or screen coordinate.

The following illustration shows a <xref:System.Windows.Controls.Primitives.Popup> control that is positioned with respect to a <xref:System.Windows.Controls.Button> that is its parent:

:::image type="content" source="./media/popup/popup-picture-button.jpg" alt-text="A Popup control positioned relative to a Button control.":::

The following table lists common tasks for working with the Popup control:

| Title | Description |
|-------|-------------|
| [Animate a Popup](how-to-animate-a-popup.md) | Learn how to animate a popup using storyboards and animations. |
| [Popup Placement Behavior](popup-placement-behavior.md) | Learn about the different placement modes and how to position a popup relative to elements or screen coordinates. |
| [Specify a Custom Popup Position](how-to-specify-a-custom-popup-position.md) | Learn how to define custom placement logic for precise popup positioning. |

## What is a Popup?

A <xref:System.Windows.Controls.Primitives.Popup> control displays content in a separate window relative to an element or point on the screen. When the <xref:System.Windows.Controls.Primitives.Popup> is visible, the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property is set to `true`.

> [!NOTE]
> A <xref:System.Windows.Controls.Primitives.Popup> doesn't automatically open when the mouse pointer moves over its parent object. If you want a <xref:System.Windows.Controls.Primitives.Popup> to automatically open, use the <xref:System.Windows.Controls.ToolTip> or <xref:System.Windows.Controls.ToolTipService> class. For more information, see [ToolTip](tooltip.md).

## Creating a Popup

The following example defines a <xref:System.Windows.Controls.Primitives.Popup> control as the child element of a <xref:System.Windows.Controls.Primitives.ToggleButton> control. Because a `ToggleButton` can have only one child element, this example places the text for the `ToggleButton` and the `Popup` controls in a <xref:System.Windows.Controls.StackPanel>. The popup's <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property uses data binding to synchronize with the button's <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> property. When you click the button, the popup automatically opens or closes. The content displays in a separate window that floats over the application window near the button.

:::code language="xaml" source="./snippets/popup/csharp/Window1.xaml" id="ToggleButtonCodeless":::

## Controls that implement a Popup

You can build <xref:System.Windows.Controls.Primitives.Popup> controls into other controls. The following controls implement the <xref:System.Windows.Controls.Primitives.Popup> control for specific uses:

- <xref:System.Windows.Controls.ToolTip>. If you want to create a tooltip for an element, use the <xref:System.Windows.Controls.ToolTip> and <xref:System.Windows.Controls.ToolTipService> classes. For more information, see [ToolTip](tooltip.md).

- <xref:System.Windows.Controls.ContextMenu>. If you want to create a context menu for an element, use the <xref:System.Windows.Controls.ContextMenu> control. For more information, see [ContextMenu](contextmenu.md).

- <xref:System.Windows.Controls.ComboBox>. If you want to create a selection control that has a drop-down list box that can be shown or hidden, use the <xref:System.Windows.Controls.ComboBox> control.

- <xref:System.Windows.Controls.Expander>. If you want to create a control that displays a header with a collapsible area that displays content, use the <xref:System.Windows.Controls.Expander> control. For more information, see [Expander](expander.md).

## Styles and templates

The <xref:System.Windows.Controls.Primitives.Popup> control provides XAML styling properties that allow you to customize its appearance. The control doesn't define a default template with template parts or visual states, but you can customize its behavior. For more information, see the [Popup behavior and appearance](#popup-behavior-and-appearance) section.

### Content property

This control uses the <xref:System.Windows.Controls.Primitives.Popup.Child%2A> property as its content property. The `Child` property represents the single child element that is displayed in the popup window.

### Parts

This control doesn't define any template parts.

### Visual states

This control doesn't define any visual states.

## Popup behavior and appearance

The <xref:System.Windows.Controls.Primitives.Popup> control provides functionality that enables you to customize its behavior and appearance. For example, you can set open and close behavior, animation, opacity and bitmap effects, and <xref:System.Windows.Controls.Primitives.Popup> size and position.

### Open and close behavior

A <xref:System.Windows.Controls.Primitives.Popup> control displays its content when the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property is set to `true`. By default, <xref:System.Windows.Controls.Primitives.Popup> stays open until the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property is set to `false`. However, you can change the default behavior by setting the <xref:System.Windows.Controls.Primitives.Popup.StaysOpen%2A> property to `false`. When you set this property to `false`, the <xref:System.Windows.Controls.Primitives.Popup> content window has mouse capture. The <xref:System.Windows.Controls.Primitives.Popup> loses mouse capture and the window closes when a mouse event occurs outside the <xref:System.Windows.Controls.Primitives.Popup> window.

The <xref:System.Windows.Controls.Primitives.Popup.Opened> and <xref:System.Windows.Controls.Primitives.Popup.Closed> events are raised when the <xref:System.Windows.Controls.Primitives.Popup> content window is open or closed.

### Animation

The <xref:System.Windows.Controls.Primitives.Popup> control has built-in support for the animations that are typically associated with behaviors like fade-in and slide-in. You can turn on these animations by setting the <xref:System.Windows.Controls.Primitives.Popup.PopupAnimation%2A> property to a <xref:System.Windows.Controls.Primitives.PopupAnimation> enumeration value. For <xref:System.Windows.Controls.Primitives.Popup> animations to work correctly, you must set the <xref:System.Windows.Controls.Primitives.Popup.AllowsTransparency%2A> property to `true`.

You can also apply animations like <xref:System.Windows.Media.Animation.Storyboard> to the <xref:System.Windows.Controls.Primitives.Popup> control.

### Opacity and bitmap effects

The <xref:System.Windows.UIElement.Opacity%2A> property for a <xref:System.Windows.Controls.Primitives.Popup> control has no effect on its content. By default, the <xref:System.Windows.Controls.Primitives.Popup> content window is opaque. To create a transparent <xref:System.Windows.Controls.Primitives.Popup>, set the <xref:System.Windows.Controls.Primitives.Popup.AllowsTransparency%2A> property to `true`.

The content of a <xref:System.Windows.Controls.Primitives.Popup> doesn't inherit bitmap effects, such as <xref:System.Windows.Media.Effects.DropShadowBitmapEffect>, that you directly set on the <xref:System.Windows.Controls.Primitives.Popup> control or on any other element in the parent window. For bitmap effects to appear on the content of a <xref:System.Windows.Controls.Primitives.Popup>, you must set the bitmap effect directly on its content. For example, if the child of a <xref:System.Windows.Controls.Primitives.Popup> is a <xref:System.Windows.Controls.StackPanel>, set the bitmap effect on the <xref:System.Windows.Controls.StackPanel>.

### Popup size

By default, a <xref:System.Windows.Controls.Primitives.Popup> is automatically sized to its content. When auto-sizing occurs, some bitmap effects might be hidden because the default size of the screen area that is defined for the <xref:System.Windows.Controls.Primitives.Popup> content doesn't provide enough space for the bitmap effects to display.

<xref:System.Windows.Controls.Primitives.Popup> content can also be obscured when you set a <xref:System.Windows.UIElement.RenderTransform%2A> on the content. In this scenario, some content might be hidden if the content of the transformed <xref:System.Windows.Controls.Primitives.Popup> extends beyond the area of the original <xref:System.Windows.Controls.Primitives.Popup>. If a bitmap effect or transform requires more space, you can define a margin around the <xref:System.Windows.Controls.Primitives.Popup> content to provide more area for the control.

## Defining the Popup position

You can position a popup by setting the <xref:System.Windows.Controls.Primitives.Popup.PlacementTarget%2A>, <xref:System.Windows.Controls.Primitives.Popup.PlacementRectangle%2A>, <xref:System.Windows.Controls.Primitives.Popup.Placement%2A>, <xref:System.Windows.Controls.Primitives.Popup.HorizontalOffset%2A>, and <xref:System.Windows.Controls.Primitives.Popup.VerticalOffsetProperty> properties. For more information, see [Popup Placement Behavior](popup-placement-behavior.md). When <xref:System.Windows.Controls.Primitives.Popup> is displayed on the screen, it doesn't reposition itself if its parent is repositioned.

### Customizing Popup placement

You can customize the placement of a <xref:System.Windows.Controls.Primitives.Popup> control by specifying a set of coordinates that are relative to the <xref:System.Windows.Controls.Primitives.Popup.PlacementTarget%2A> where you want the <xref:System.Windows.Controls.Primitives.Popup> to appear.

To customize placement, set the <xref:System.Windows.Controls.Primitives.Popup.Placement%2A> property to <xref:System.Windows.Controls.Primitives.PlacementMode.Custom>. Then define a <xref:System.Windows.Controls.Primitives.CustomPopupPlacementCallback> delegate that returns a set of possible placement points and primary axes (in order of preference) for the <xref:System.Windows.Controls.Primitives.Popup>. The point that shows the largest part of the <xref:System.Windows.Controls.Primitives.Popup> is automatically selected. For an example, see [Specify a Custom Popup Position](how-to-specify-a-custom-popup-position.md).

## Popup and the visual tree

A <xref:System.Windows.Controls.Primitives.Popup> control doesn't have its own visual tree; it instead returns a size of 0 (zero) when the <xref:System.Windows.Controls.Primitives.Popup.MeasureOverride%2A> method for <xref:System.Windows.Controls.Primitives.Popup> is called. However, when you set the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property of <xref:System.Windows.Controls.Primitives.Popup> to `true`, a new window with its own visual tree is created. The new window contains the <xref:System.Windows.Controls.Primitives.Popup.Child%2A> content of <xref:System.Windows.Controls.Primitives.Popup>. The width and height of the new window can't be larger than 75 percent of the width or height of the screen.

The <xref:System.Windows.Controls.Primitives.Popup> control maintains a reference to its <xref:System.Windows.Controls.Primitives.Popup.Child%2A> content as a logical child. When the new window is created, the content of <xref:System.Windows.Controls.Primitives.Popup> becomes a visual child of the window and remains the logical child of <xref:System.Windows.Controls.Primitives.Popup>. Conversely, <xref:System.Windows.Controls.Primitives.Popup> remains the logical parent of its <xref:System.Windows.Controls.Primitives.Popup.Child%2A> content.

## See also

- <xref:System.Windows.Controls.ContextMenu>
- <xref:System.Windows.Controls.Primitives.CustomPopupPlacement>
- <xref:System.Windows.Controls.Primitives.CustomPopupPlacementCallback>
- <xref:System.Windows.Controls.Primitives.PlacementMode>
- <xref:System.Windows.Controls.Primitives.Popup>
- <xref:System.Windows.Controls.Primitives.PopupPrimaryAxis>
- <xref:System.Windows.Controls.ToolTip>
- <xref:System.Windows.Controls.ToolTipService>
- [Popup Placement Behavior](popup-placement-behavior.md)
- [ToolTip](tooltip.md)
