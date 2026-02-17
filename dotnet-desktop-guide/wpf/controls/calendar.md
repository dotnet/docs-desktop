---
title: "Calendar"
description: Learn about the Calendar control in this article, which enables a user to select a date by using a visual calendar display.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "controls [WPF], Calendar"
  - "Calendar control [WPF]"
---
# Calendar

A calendar enables a user to select a date by using a visual calendar display.

A <xref:System.Windows.Controls.Calendar> control can be used on its own, or as a drop-down part of a <xref:System.Windows.Controls.DatePicker> control. For more information, see <xref:System.Windows.Controls.DatePicker>.

:::image type="content" source="./media/shared/calendar.png" alt-text="Screenshot showing three Calendar controls, one showing a month, another showing the year, and another showing a year range.":::

## Common tasks

The following table provides information about tasks that are typically associated with the <xref:System.Windows.Controls.Calendar>.

|Task|Implementation|
|----------|--------------------|
|Specify dates that cannot be selected.|Use the <xref:System.Windows.Controls.Calendar.BlackoutDates%2A> property.|
|Have the <xref:System.Windows.Controls.Calendar> display a month, an entire year, or a decade.|Set the <xref:System.Windows.Controls.Calendar.DisplayMode%2A> property to Month, Year, or Decade.|
|Specify whether the user can select a date, a range of dates, or multiple ranges of dates.|Use the <xref:System.Windows.Controls.Calendar.SelectionMode%2A>.|
|Specify the range of dates that the <xref:System.Windows.Controls.Calendar> displays.|Use the <xref:System.Windows.Controls.Calendar.DisplayDateStart%2A> and <xref:System.Windows.Controls.Calendar.DisplayDateEnd%2A> properties.|
|Specify whether the current date is highlighted.|Use the <xref:System.Windows.Controls.Calendar.IsTodayHighlighted%2A> property. By default, <xref:System.Windows.Controls.Calendar.IsTodayHighlighted%2A> is `true`.|
|Change the size of the <xref:System.Windows.Controls.Calendar>.|Use a <xref:System.Windows.Controls.Viewbox> or set the <xref:System.Windows.FrameworkElement.LayoutTransform%2A> property to a <xref:System.Windows.Media.ScaleTransform>. Note that if you set the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties of a <xref:System.Windows.Controls.Calendar>, the actual calendar does not change its size.|

## Keyboard navigation

The <xref:System.Windows.Controls.Calendar> control provides basic navigation using either the mouse or keyboard. The following table summarizes keyboard navigation.

|Key Combination|<xref:System.Windows.Controls.Calendar.DisplayMode%2A>|Action|
|---------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|------------|
|ARROW|<xref:System.Windows.Controls.CalendarMode.Month>|Changes the <xref:System.Windows.Controls.Calendar.SelectedDate%2A> property if the <xref:System.Windows.Controls.Calendar.SelectionMode%2A> property is not set to <xref:System.Windows.Controls.CalendarSelectionMode.None>.|
|ARROW|<xref:System.Windows.Controls.CalendarMode.Year>|Changes the month of the <xref:System.Windows.Controls.Calendar.DisplayDate%2A> property. Note that the <xref:System.Windows.Controls.Calendar.SelectedDate%2A> does not change.|
|ARROW|<xref:System.Windows.Controls.CalendarMode.Decade>|Changes the year of the <xref:System.Windows.Controls.Calendar.DisplayDate%2A>. Note that the <xref:System.Windows.Controls.Calendar.SelectedDate%2A> does not change.|
|SHIFT+ARROW|<xref:System.Windows.Controls.CalendarMode.Month>|If <xref:System.Windows.Controls.Calendar.SelectionMode%2A> is not set to <xref:System.Windows.Controls.CalendarSelectionMode.SingleDate> or <xref:System.Windows.Controls.CalendarSelectionMode.None>, extends the range of selected dates.|
|HOME|<xref:System.Windows.Controls.CalendarMode.Month>|Changes the <xref:System.Windows.Controls.Calendar.SelectedDate%2A> to the first day of the current month.|
|HOME|<xref:System.Windows.Controls.CalendarMode.Year>|Changes the month of the <xref:System.Windows.Controls.Calendar.DisplayDate%2A> to the first month of the year. The <xref:System.Windows.Controls.Calendar.SelectedDate%2A> does not change.|
|HOME|<xref:System.Windows.Controls.CalendarMode.Decade>|Changes the year of the <xref:System.Windows.Controls.Calendar.DisplayDate%2A> to the first year of the decade. The <xref:System.Windows.Controls.Calendar.SelectedDate%2A> does not change.|
|END|<xref:System.Windows.Controls.CalendarMode.Month>|Changes the <xref:System.Windows.Controls.Calendar.SelectedDate%2A> to the last day of the current month.|
|END|<xref:System.Windows.Controls.CalendarMode.Year>|Changes the month of the <xref:System.Windows.Controls.Calendar.DisplayDate%2A> to the last month of the year. The <xref:System.Windows.Controls.Calendar.SelectedDate%2A> does not change.|
|END|<xref:System.Windows.Controls.CalendarMode.Decade>|Changes the year of the <xref:System.Windows.Controls.Calendar.DisplayDate%2A> to the last year of the decade. The <xref:System.Windows.Controls.Calendar.SelectedDate%2A> does not change.|
|CTRL+UP ARROW|Any|Switches to the next larger <xref:System.Windows.Controls.Calendar.DisplayMode%2A>. If <xref:System.Windows.Controls.Calendar.DisplayMode%2A> is already <xref:System.Windows.Controls.CalendarMode.Decade>, no action.|
|CTRL+DOWN ARROW|Any|Switches to the next smaller <xref:System.Windows.Controls.Calendar.DisplayMode%2A>. If <xref:System.Windows.Controls.Calendar.DisplayMode%2A> is already <xref:System.Windows.Controls.CalendarMode.Month>, no action.|
|SPACEBAR or ENTER|<xref:System.Windows.Controls.CalendarMode.Year> or <xref:System.Windows.Controls.CalendarMode.Decade>|Switches <xref:System.Windows.Controls.Calendar.DisplayMode%2A> to the <xref:System.Windows.Controls.CalendarMode.Month> or <xref:System.Windows.Controls.CalendarMode.Year> represented by focused item.|

## Styles and templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.Calendar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control does not define a content property.

### Parts  

The following table lists the named parts for the <xref:System.Windows.Controls.Calendar> control.

|Part|Type|Description|
|-|-|-|
|PART_CalendarItem|<xref:System.Windows.Controls.Primitives.CalendarItem>|The currently displayed month or year on the <xref:System.Windows.Controls.Calendar>.|
|PART_Root|<xref:System.Windows.Controls.Panel>|The panel that contains the <xref:System.Windows.Controls.Primitives.CalendarItem>.|

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Calendar> control.

|VisualState Name|VisualStateGroup Name|Description|
|---|---|---|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control does not have focus.|

### CalendarItem parts and states

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.CalendarItem> control.

|Part|Type|Description|
|-|-|-|
|DayTitleTemplate|<xref:System.Windows.DataTemplate>|The data template used for day title headers.|
|PART_DisabledVisual|<xref:System.Windows.FrameworkElement>|The element that provides visual feedback when the control is disabled.|
|PART_HeaderButton|<xref:System.Windows.Controls.Button>|The header button used to navigate between calendar views.|
|PART_MonthView|<xref:System.Windows.Controls.Grid>|The grid that contains the month view layout.|
|PART_NextButton|<xref:System.Windows.Controls.Button>|The button used to navigate to the next time period.|
|PART_PreviousButton|<xref:System.Windows.Controls.Button>|The button used to navigate to the previous time period.|
|PART_Root|<xref:System.Windows.FrameworkElement>|The root element that contains the calendar item layout.|
|PART_YearView|<xref:System.Windows.Controls.Grid>|The grid that contains the year view layout.|

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.CalendarItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|Disabled|CommonStates|The control is disabled.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but does not have keyboard focus.|

### CalendarDayButton parts and states

The <xref:System.Windows.Controls.Primitives.CalendarDayButton> control does not have any named parts.

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.CalendarDayButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Active|ActiveStates|The day is within the currently displayed month.|
|Inactive|ActiveStates|The day is outside the currently displayed month.|
|Today|DayStates|The day represents today's date.|
|RegularDay|DayStates|The day represents a regular date.|
|Selected|SelectionStates|The day is selected.|
|Unselected|SelectionStates|The day is not selected.|
|BlackoutDay|BlackoutDayStates|The day is blacked out and cannot be selected.|
|NormalDay|BlackoutDayStates|The day is available for selection.|
|CalendarButtonFocused|CalendarButtonFocusStates|The calendar button has keyboard focus.|
|CalendarButtonUnfocused|CalendarButtonFocusStates|The calendar button doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

### CalendarButton parts and states

The <xref:System.Windows.Controls.Primitives.CalendarButton> control does not have any named parts.

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.CalendarButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Selected|SelectionStates|The calendar button represents a date range with selected dates.|
|Unselected|SelectionStates|The calendar button doesn't represent a date range with selected dates.|
|Active|ActiveStates|The calendar button represents a month in the current year or a year in the current decade.|
|Inactive|ActiveStates|The calendar button represents a month outside the current year or a year outside the current decade.|
|CalendarButtonFocused|CalendarButtonFocusStates|The calendar button has keyboard focus.|
|CalendarButtonUnfocused|CalendarButtonFocusStates|The calendar button doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- [Controls](index.md)
- [Styling and Templating](styles-templates-overview.md)
