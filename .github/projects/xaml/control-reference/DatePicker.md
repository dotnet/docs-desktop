# DatePicker

- **ControlName**: DatePicker
- **CodeFile**: System/Windows/Controls/DatePicker.cs
- **BaseClass**: Control
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Root | Grid | The root panel that contains the date picker layout. |
| PART_TextBox | DatePickerTextBox | The text box that displays the selected date text. |
| PART_Button | Button | The drop-down button that opens the calendar popup. |
| PART_Popup | Popup | The popup that contains the calendar for date selection. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| Disabled | CommonStates | The control is disabled. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
