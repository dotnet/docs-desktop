---
title: "Expander"
description: Learn about an Expander, which allows a user to view a header and expand that header to see further details, or to collapse a section up to a header.
ms.date: "10/30/2025"
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "expanding headers [WPF]"
  - "controls [WPF], Expander"
  - "headers [WPF]"
  - "Expander control [WPF]"
  - "collapsing headers [WPF]"
---
# Expander

An <xref:System.Windows.Controls.Expander> allows a user to view a header and expand that header to see further details, or collapse a section up to a header. The <xref:System.Windows.Controls.Expander> control provides a way to present content in an expandable area that resembles a window and includes a header.

:::image type="content" source="./media/expander/expander-control-example.jpg" alt-text="Expander control in its expanded position with header and content area visible":::

| Title | Description |
|-------|-------------|
| [Create an Expander with a ScrollViewer](how-to-create-an-expander-with-a-scrollviewer.md) | Learn how to create an Expander control that contains complex content with a ScrollViewer. |

## Setting the direction of the expanding content area

You can set the content area of an <xref:System.Windows.Controls.Expander> control to expand in one of four directions: <xref:System.Windows.Controls.ExpandDirection.Down>, <xref:System.Windows.Controls.ExpandDirection.Up>, <xref:System.Windows.Controls.ExpandDirection.Left>, or <xref:System.Windows.Controls.ExpandDirection.Right> by using the <xref:System.Windows.Controls.ExpandDirection> property. When the content area is collapsed, only the <xref:System.Windows.Controls.Expander> header and its toggle button appear. A <xref:System.Windows.Controls.Button> control that displays a directional arrow is used as a toggle button to expand or collapse the content area. When expanded, the <xref:System.Windows.Controls.Expander> tries to display all of its content in a window-like area.

## Controlling the size of an Expander in a panel

If an <xref:System.Windows.Controls.Expander> control is inside a layout control that inherits from <xref:System.Windows.Controls.Panel>, such as <xref:System.Windows.Controls.StackPanel>, don't specify a <xref:System.Windows.FrameworkElement.Height%2A> on the <xref:System.Windows.Controls.Expander> when the <xref:System.Windows.Controls.Expander.ExpandDirection%2A> property is set to <xref:System.Windows.Controls.ExpandDirection.Down> or <xref:System.Windows.Controls.ExpandDirection.Up>. Similarly, don't specify a <xref:System.Windows.FrameworkElement.Width%2A> on the <xref:System.Windows.Controls.Expander> when the <xref:System.Windows.Controls.Expander.ExpandDirection%2A> property is set to <xref:System.Windows.Controls.ExpandDirection.Left> or <xref:System.Windows.Controls.ExpandDirection.Right>.

When you set a size dimension on an <xref:System.Windows.Controls.Expander> control in the direction that the expanded content is displayed, the <xref:System.Windows.Controls.Expander> takes control of the area that is used by the content and displays a border around it. The border shows even when the content is collapsed. To set the size of the expanded content area, set size dimensions on the content of the <xref:System.Windows.Controls.Expander>, or if you want scrolling capability, on the <xref:System.Windows.Controls.ScrollViewer> that encloses the content.

When an <xref:System.Windows.Controls.Expander> control is the last element in a <xref:System.Windows.Controls.DockPanel>, Windows Presentation Foundation (WPF) automatically sets the <xref:System.Windows.Controls.Expander> dimensions to equal the remaining area of the <xref:System.Windows.Controls.DockPanel>. To prevent this default behavior, set the <xref:System.Windows.Controls.DockPanel.LastChildFill%2A> property on the <xref:System.Windows.Controls.DockPanel> object to `false`, or make sure that the <xref:System.Windows.Controls.Expander> is not the last element in a <xref:System.Windows.Controls.DockPanel>.

## Creating scrollable content

If the content is too large for the size of the content area, you can wrap the content of an <xref:System.Windows.Controls.Expander> in a <xref:System.Windows.Controls.ScrollViewer> to provide scrollable content. The <xref:System.Windows.Controls.Expander> control doesn't automatically provide scrolling capability.

:::image type="content" source="./media/expander-overview/expander-scrollbar-control.jpg" alt-text="Expander control containing a ScrollViewer with a scroll bar":::

When you place an <xref:System.Windows.Controls.Expander> control in a <xref:System.Windows.Controls.ScrollViewer>, set the <xref:System.Windows.Controls.ScrollViewer> dimension property that corresponds to the direction in which the <xref:System.Windows.Controls.Expander> content opens to the size of the <xref:System.Windows.Controls.Expander> content area. For example, if you set the <xref:System.Windows.Controls.Expander.ExpandDirection%2A> property on the <xref:System.Windows.Controls.Expander> to <xref:System.Windows.Controls.ExpandDirection.Down> (the content area opens down), set the <xref:System.Windows.FrameworkElement.Height%2A> property on the <xref:System.Windows.Controls.ScrollViewer> control to the required height for the content area. If you instead set the height dimension on the content itself, <xref:System.Windows.Controls.ScrollViewer> doesn't recognize this setting and therefore doesn't provide scrollable content.

## Using the alignment properties

You can align content by setting the <xref:System.Windows.Controls.Control.HorizontalContentAlignment%2A> and <xref:System.Windows.Controls.Control.VerticalContentAlignment%2A> properties on the <xref:System.Windows.Controls.Expander> control. When you set these properties, the alignment applies to the header and also to the expanded content.

## Styles and templates

You can modify the styles and templates for the <xref:System.Windows.Controls.Expander> control to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The content property of the <xref:System.Windows.Controls.Expander> is <xref:System.Windows.Controls.ContentControl.Content%2A>, which represents the content displayed in the expanded area of the control.

### Parts

The <xref:System.Windows.Controls.Expander> control has the following named part:

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| HeaderSite | ToggleButton | The toggle button that expands and collapses the expander. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Expander> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Expanded|ExpansionStates|The control is expanded.|
|Collapsed|ExpansionStates|The control is collapsed.|
|ExpandDown|ExpandDirectionStates|The control expands downward.|
|ExpandUp|ExpandDirectionStates|The control expands upward.|
|ExpandLeft|ExpandDirectionStates|The control expands to the left.|
|ExpandRight|ExpandDirectionStates|The control expands to the right.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- <xref:System.Windows.Controls.Expander>
- <xref:System.Windows.Controls.ExpandDirection>
- [What are styles and templates?](styles-templates-overview.md)
- [How to create a template for a control](how-to-create-apply-template.md)
