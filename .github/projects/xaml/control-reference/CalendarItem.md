# CalendarItem

- **ControlName**: CalendarItem
- **CodeFile**: System/Windows/Controls/Primitives/CalendarItem.cs
- **BaseClass**: Control
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Root | FrameworkElement | The root element that contains the calendar item layout. |
| PART_HeaderButton | Button | The header button used to navigate between calendar views. |
| PART_PreviousButton | Button | The button used to navigate to the previous time period. |
| PART_NextButton | Button | The button used to navigate to the next time period. |
| DayTitleTemplate | DataTemplate | The data template used for day title headers. |
| PART_MonthView | Grid | The grid that contains the month view layout. |
| PART_YearView | Grid | The grid that contains the year view layout. |
| PART_DisabledVisual | FrameworkElement | The element that provides visual feedback when the control is disabled. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| Disabled | CommonStates | The control is disabled. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
