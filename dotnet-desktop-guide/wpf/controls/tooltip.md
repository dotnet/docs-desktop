---
title: "ToolTip"
description: Learn about ToolTip, a small pop-up window that appears when a user pauses the mouse pointer over an element, including how to create and customize tooltip content.
ms.date: "01/28/2026"
ms.service: dotnet-desktop
update-cycle: 365-days
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "ToolTip control [WPF]"
  - "controls [WPF], ToolTip"
  - "popups [WPF]"
  - "ToolTip control [WPF], about ToolTip control"
ai-usage: ai-assisted
---
# ToolTip

A tooltip is a small pop-up window that appears when a user pauses the mouse pointer over an element, such as over a <xref:System.Windows.Controls.Button>. When a user moves the mouse pointer over an element that has a tooltip, a window that contains tooltip content (for example, text content that describes the function of a control) appears for a specified amount of time. If the user moves the mouse pointer away from the control, the window disappears because the tooltip content can't receive focus.

The following illustration shows a mouse pointer that points to the **Close** <xref:System.Windows.Controls.Button>, which displays its identifying <xref:System.Windows.Controls.ToolTip>.

Close button with its tooltip displayed

:::image type="content" source="./media/shared/tooltip.png" alt-text="A tooltip shown when hovering over a checkbox control in WPF.":::

The content of a tooltip can contain one or more lines of text, images, shapes, or other visual content. You define a tooltip for a control by setting one of the following properties to the tooltip content:

- <xref:System.Windows.FrameworkContentElement.ToolTip%2A?displayProperty=nameWithType>
- <xref:System.Windows.FrameworkElement.ToolTip%2A?displayProperty=nameWithType>

Which property you use depends on whether the control that defines the tooltip inherits from the <xref:System.Windows.FrameworkContentElement> or <xref:System.Windows.FrameworkElement> class.

## Create a ToolTip

The following example shows how to create a simple tooltip by setting the <xref:System.Windows.FrameworkElement.ToolTip%2A> property for a <xref:System.Windows.Controls.Button> control to a text string.

:::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/GroupBoxSnippet/CS/Window1.xaml" id="ToolTipString":::

You can also define a tooltip as a <xref:System.Windows.Controls.ToolTip> object. The following example uses XAML to specify a <xref:System.Windows.Controls.ToolTip> object as the tooltip of a <xref:System.Windows.Controls.TextBox> element. The example specifies the <xref:System.Windows.Controls.ToolTip> by setting the <xref:System.Windows.FrameworkElement.ToolTip%2A?displayProperty=nameWithType> property.

:::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/ToolTipSimple/CSharp/Pane1.xaml" id="ToolTip":::

The following example uses code to generate a <xref:System.Windows.Controls.ToolTip> object. The example creates a <xref:System.Windows.Controls.ToolTip> (`tt`) and associates it with a <xref:System.Windows.Controls.Button>.

:::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_Wpf/ToolTipSimple/CSharp/Pane1.xaml.cs" id="2":::
:::code language="vb" source="~/samples/snippets/visualbasic/VS_Snippets_Wpf/ToolTipSimple/VisualBasic/Window1.xaml.vb" id="2":::

You can also create tooltip content that isn't defined as a <xref:System.Windows.Controls.ToolTip> object by enclosing the tooltip content in a layout element, such as a <xref:System.Windows.Controls.DockPanel>. The following example shows how to set the <xref:System.Windows.FrameworkElement.ToolTip%2A> property of a <xref:System.Windows.Controls.TextBox> to content that's enclosed in a <xref:System.Windows.Controls.DockPanel> control.

:::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/GroupBoxSnippet/CS/Window1.xaml" id="ToolTipDockPanel":::

## Customize a ToolTip

You can customize tooltip content by setting visual properties and applying styles. If you define the tooltip content as a <xref:System.Windows.Controls.ToolTip> object, you can set the visual properties of the <xref:System.Windows.Controls.ToolTip> object. Otherwise, you must set equivalent attached properties on the <xref:System.Windows.Controls.ToolTipService> class.

For an example of how to set properties in order to specify the position of tooltip content by using the <xref:System.Windows.Controls.ToolTip> and <xref:System.Windows.Controls.ToolTipService> properties, see [Position a ToolTip](how-to-position-a-tooltip.md).

### Time interval properties

The <xref:System.Windows.Controls.ToolTipService> class provides the following properties for you to set tooltip display times: <xref:System.Windows.Controls.ToolTipService.InitialShowDelay%2A>, <xref:System.Windows.Controls.ToolTipService.BetweenShowDelay%2A>, and <xref:System.Windows.Controls.ToolTipService.ShowDuration%2A>.

Use the <xref:System.Windows.Controls.ToolTipService.InitialShowDelay%2A> and <xref:System.Windows.Controls.ToolTipService.ShowDuration%2A> properties to specify a delay, typically brief, before a <xref:System.Windows.Controls.ToolTip> appears and also to specify how long a <xref:System.Windows.Controls.ToolTip> remains visible. For more information, see [How to: Delay the Display of a ToolTip](/previous-versions/dotnet/netframework-3.5/ms747264(v=vs.90)).

The <xref:System.Windows.Controls.ToolTipService.BetweenShowDelay%2A> property determines if tooltips for different controls appear without an initial delay when you move the mouse pointer quickly between them. For more information about the <xref:System.Windows.Controls.ToolTipService.BetweenShowDelay%2A> property, see [Use the BetweenShowDelay Property](how-to-use-the-betweenshowdelay-property.md).

The following example shows how to set these properties for a tooltip.

:::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/ToolTipService/CSharp/Pane1.xaml" id="ToolTip":::

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.ToolTip> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Style a ToolTip

You can style a <xref:System.Windows.Controls.ToolTip> by defining a custom <xref:System.Windows.Style>. The following example defines a <xref:System.Windows.Style> called `Simple` that shows how to offset the placement of the <xref:System.Windows.Controls.ToolTip> and change its appearance by setting the <xref:System.Windows.Controls.Control.Background%2A>, <xref:System.Windows.Controls.Control.Foreground%2A>, <xref:System.Windows.Controls.Control.FontSize%2A>, and <xref:System.Windows.Controls.Control.FontWeight%2A>.

:::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/ToolTipSimple/CSharp/Pane1.xaml" id="Style":::

### Content property

The <xref:System.Windows.Controls.ContentControl.Content?displayProperty=nameWithType> property is the content property of the <xref:System.Windows.Controls.ToolTip> control. You can set this property directly in XAML without explicitly specifying the property name.

### Parts

This control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ToolTip> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Closed|OpenStates|The tooltip is closed and not visible.|
|Open|OpenStates|The tooltip is open and visible.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- <xref:System.Windows.Controls.Primitives.Popup>
- <xref:System.Windows.Controls.ToolTip>
- <xref:System.Windows.Controls.ToolTipEventArgs>
- <xref:System.Windows.Controls.ToolTipEventHandler>
- <xref:System.Windows.Controls.ToolTipService>
- [Popup](popup.md)
