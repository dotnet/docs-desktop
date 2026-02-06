---
title: "StatusBar"
description: Learn how to use a StatusBar to display status information in a horizontal bar in an application window.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], StatusBar"
  - "StatusBar control [WPF]"
ai-usage: ai-assisted
---
# StatusBar

A <xref:System.Windows.Controls.Primitives.StatusBar> is a horizontal area at the bottom of a window where an application can display status information.

The following illustration shows an example of a <xref:System.Windows.Controls.Primitives.StatusBar>.

:::image type="content" source="./media/ss-ctl-statusbar.GIF" alt-text="Screenshot of a StatusBar control showing status information at the bottom of a window.":::

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.Primitives.StatusBar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.Primitives.StatusBar> control uses the <xref:System.Windows.Controls.ItemsControl.Items> property as its content property. This property contains the collection of <xref:System.Windows.Controls.Primitives.StatusBarItem> objects that are displayed in the status bar.

### Parts

The <xref:System.Windows.Controls.Primitives.StatusBar> control does not define any named parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.StatusBar> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

#### StatusBarItem parts

The <xref:System.Windows.Controls.Primitives.StatusBarItem> control does not define any named parts.

#### StatusBarItem visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.StatusBarItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but does not have keyboard focus.|

## See also

- <xref:System.Windows.Controls.Primitives.StatusBar>
- <xref:System.Windows.Controls.Primitives.StatusBarItem>
