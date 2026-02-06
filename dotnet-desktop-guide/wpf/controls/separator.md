---
title: "Separator"
description: Learn how to use a Separator control to draw a horizontal or vertical line between items in controls.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], Separator"
  - "Separator control [WPF]"
ai-usage: ai-assisted
---
# Separator

A <xref:System.Windows.Controls.Separator> control draws a line, horizontal or vertical, between items in controls, such as <xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.Menu>, and <xref:System.Windows.Controls.ToolBar>.

:::image type="content" source="./media/shared/separator.png" alt-text="A screenshot of WPF separators visually separating controls.":::

## Styles and templates

The <xref:System.Windows.Controls.Separator> control provides styling information through template parts and visual states.

### Content property

This control doesn't define a content property.

### Parts

This control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Separator> control.

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## See also

- <xref:System.Windows.Controls.Separator>
