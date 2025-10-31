# Calendar

- **ControlName**: Calendar
- **CodeFile**: System/Windows/Controls/Calendar.cs
- **BaseClass**: Control
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Root | Panel | The root panel that contains the calendar layout. |
| PART_CalendarItem | CalendarItem | The calendar item that displays the month, year, or decade view. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
