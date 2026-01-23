---
title: "ComboBox"
description: Learn about the ComboBox control, which presents users with a list of options. The list is shown and hidden as the control expands and collapses.
ms.date: "10/29/2025"
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], ComboBox"
  - "ComboBox control [WPF]"
ai-usage: ai-assisted
---
# ComboBox

The <xref:System.Windows.Controls.ComboBox> control presents users with a list of options. The list is shown and hidden as the control expands and collapses. In its default state, the list is collapsed, displaying only one choice. The user clicks a button to see the complete list of options.

The following illustration shows a <xref:System.Windows.Controls.ComboBox> in different states.

:::image type="content" source="./media/shared/combobox.png" alt-text="A ComboBox control shown in disabled, collapsed, and expanded states.":::

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.ComboBox> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ItemsControl.Items%2A> property is the content property for the <xref:System.Windows.Controls.ComboBox> control. This property contains the list of items that the ComboBox displays.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.ComboBox> control.

|Part|Type|Description|
|-|-|-|
|PART_EditableTextBox|<xref:System.Windows.Controls.TextBox>|The editable text box part used when <xref:System.Windows.Controls.ComboBox.IsEditable%2A> is `true`.|
|PART_Popup|<xref:System.Windows.Controls.Primitives.Popup>|The popup that contains the dropdown list of items.|

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ComboBox>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ComboBox>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the states for the <xref:System.Windows.Controls.ComboBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Disabled|CommonStates|The control is disabled.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Focused|FocusStates|The control has keyboard focus.|
|FocusedDropDown|FocusStates|The control has keyboard focus and the dropdown is open.|
|Editable|EditStates|The control is in editable mode.|
|Uneditable|EditStates|The control is in non-editable mode.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

### ComboBoxItem parts

The <xref:System.Windows.Controls.ComboBoxItem> control does not have any named parts.

### ComboBoxItem visual states

The following table lists the states for the <xref:System.Windows.Controls.ComboBoxItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|Disabled|CommonStates|The control is disabled.|
|MouseOver|CommonStates|The mouse pointer is over the <xref:System.Windows.Controls.ComboBoxItem> control.|
|Focused|FocusStates|The control has focus.|
|Unfocused|FocusStates|The control does not have focus.|
|Selected|SelectionStates|The item is currently selected.|
|Unselected|SelectionStates|The item is not selected.|
|SelectedUnfocused|SelectionStates|The item is selected, but does not have focus.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control does not have focus.|

## See also

<xref:System.Windows.Controls.ComboBox>
