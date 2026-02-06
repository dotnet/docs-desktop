---
title: "DatePicker"
description: Learn about the DatePicker control, which allows the user to select a date by either typing it into a text field or by using a drop-down Calendar control.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], DatePicker"
  - "DatePicker control [WPF]"
ai-usage: ai-assisted
---
# DatePicker

The <xref:System.Windows.Controls.DatePicker> control allows the user to select a date by either typing it into a text field or by using a drop-down <xref:System.Windows.Controls.Calendar> control.

The following illustration shows a <xref:System.Windows.Controls.DatePicker>.

:::image type="content" source="./media/shared/datepicker.png" alt-text="DatePicker control in different states.":::

Many of a <xref:System.Windows.Controls.DatePicker> control's properties are for managing its built-in <xref:System.Windows.Controls.Calendar>, and function identically to the equivalent property in <xref:System.Windows.Controls.Calendar>. In particular, the <xref:System.Windows.Controls.DatePicker.IsTodayHighlighted%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.DatePicker.FirstDayOfWeek%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.DatePicker.BlackoutDates%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.DatePicker.DisplayDateStart%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.DatePicker.DisplayDateEnd%2A?displayProperty=nameWithType>, <xref:System.Windows.Controls.DatePicker.DisplayDate%2A?displayProperty=nameWithType>, and <xref:System.Windows.Controls.DatePicker.SelectedDate%2A?displayProperty=nameWithType> properties function identically to their <xref:System.Windows.Controls.Calendar> counterparts. For more information, see <xref:System.Windows.Controls.Calendar>.

Users can type a date directly into a text field, which sets the <xref:System.Windows.Controls.DatePicker.Text%2A> property. If the <xref:System.Windows.Controls.DatePicker> cannot convert the entered string to a valid date, the <xref:System.Windows.Controls.DatePicker.DateValidationError> event will be raised. By default, this causes an exception, but an event handler for <xref:System.Windows.Controls.DatePicker.DateValidationError> can set the <xref:System.Windows.Controls.DatePickerDateValidationErrorEventArgs.ThrowException%2A> property to `false` and prevent an exception from being raised.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.DatePicker> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control does not define a content property.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.DatePicker> control.

|Part|Type|Description|
|-|-|-|
|PART_Button|<xref:System.Windows.Controls.Button>|The drop-down button that opens the calendar popup.|
|PART_Popup|<xref:System.Windows.Controls.Primitives.Popup>|The popup that contains the calendar for date selection.|
|PART_Root|<xref:System.Windows.Controls.Grid>|The root panel that contains the date picker layout.|
|PART_TextBox|<xref:System.Windows.Controls.Primitives.DatePickerTextBox>|The text box that displays the selected date text.|

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.DatePicker> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Disabled|CommonStates|The control is disabled.|
|Normal|CommonStates|The control is in its normal state.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

## DatePickerTextBox

<xref:System.Windows.Controls.Primitives.DatePickerTextBox> is the text box control used within the <xref:System.Windows.Controls.DatePicker>.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DatePickerTextBox> control.

|Part|Type|Description|
|-|-|-|
|PART_ContentElement|<xref:System.Windows.FrameworkElement>|A visual element that can contain a <xref:System.Windows.FrameworkElement>. The text of the <xref:System.Windows.Controls.TextBox> is displayed in this element.|
|PART_Watermark|<xref:System.Windows.Controls.ContentControl>|The element that contains the initial text in the <xref:System.Windows.Controls.DatePicker>.|

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DatePickerTextBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Disabled|CommonStates|The <xref:System.Windows.Controls.Primitives.DatePickerTextBox> is disabled.|
|MouseOver|CommonStates|The mouse pointer is positioned over the <xref:System.Windows.Controls.Primitives.DatePickerTextBox>.|
|Normal|CommonStates|The default state.|
|ReadOnly|CommonStates|The user cannot change the text in the <xref:System.Windows.Controls.Primitives.DatePickerTextBox>.|
|Focused|FocusStates|The control has focus.|
|Unfocused|FocusStates|The control does not have focus.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control does not have focus.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|Unwatermarked|WatermarkStates|The user has entered text into the <xref:System.Windows.Controls.Primitives.DatePickerTextBox> or selected a date in the <xref:System.Windows.Controls.DatePicker>.|
|Watermarked|WatermarkStates|The control displays its initial text. The <xref:System.Windows.Controls.Primitives.DatePickerTextBox> is in this state when the user has not entered text or selected a date.|

## See also

- [Calendar](calendar.md)
- [Controls](index.md)
- [How to create a template for a control](how-to-create-apply-template.md)
- [Styling and Templating](styles-templates-overview.md)
- [What are styles and templates?](styles-templates-overview.md)
