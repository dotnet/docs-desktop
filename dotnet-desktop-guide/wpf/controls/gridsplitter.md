---
title: "GridSplitter"
description: Learn about the GridSplitter, which redistributes space between columns or rows of a Grid control, via helpful links.
ms.date: 01/28/2026
ms.service: dotnet-framework
ms.update-cycle: 1825-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "controls [WPF], GridSplitter"
  - "GridSplitter control [WPF]"
  - "content [WPF], GridSplitter control"
---
# GridSplitter

The <xref:System.Windows.Controls.GridSplitter> redistributes space between columns or rows of a <xref:System.Windows.Controls.Grid> control.

:::image type="content" source="./media/shared/gridsplitter.png" alt-text="Screenshot of a vertical GridSplitter control separating two grid columns.":::

| Title | Description |
|-------|-------------|
| [Resize Rows with a GridSplitter](how-to-resize-rows-with-a-gridsplitter.md) | Shows how to resize rows in a grid using a GridSplitter control. |
| [Resize Columns with a GridSplitter](how-to-resize-columns-with-a-gridsplitter.md) | Shows how to resize columns in a grid using a GridSplitter control. |
| [Make Sure That a GridSplitter Is Visible](how-to-make-sure-that-a-gridsplitter-is-visible.md) | Shows how to make sure a GridSplitter control isn't hidden by other controls. |

## Styles and templates

The GridSplitter control supports customization of its appearance through styles and templates. For information about modifying a control's visual structure and visual behavior, see [Control styles and templates](/dotnet/desktop/wpf/controls/control-styles-and-templates).

### Content property

This control doesn't define a content property.

### Parts

This control doesn't define any template parts.

### Visual states

The GridSplitter control defines the following visual states:

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| MouseOver | CommonStates | The mouse is over the control. |
| Pressed | CommonStates | The control is pressed. |
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## See also

- <xref:System.Windows.Controls.Grid>
- <xref:System.Windows.Controls.GridSplitter>
