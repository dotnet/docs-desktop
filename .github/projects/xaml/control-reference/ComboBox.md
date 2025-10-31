# ComboBox

- **ControlName**: ComboBox
- **CodeFile**: System/Windows/Controls/ComboBox.cs
- **BaseClass**: Selector
- **ControlType**: ItemsControl
- **ContentProperty**: Items

## Template parts

| Part Name           | Part Type | Description                                                                  |
|---------------------|-----------|------------------------------------------------------------------------------|
| PART_EditableTextBox| TextBox   | The editable text box part used when IsEditable is true.                   |
| PART_Popup          | Popup     | The popup that contains the dropdown list of items.                         |

## Visual states

| VisualState Name   | VisualStateGroup Name | Description                                              |
|-|-|-|
| Normal             | CommonStates         | The control is in its normal state.                   |
| MouseOver          | CommonStates         | The mouse is over the control.                        |
| Disabled            | CommonStates         | The control is disabled.                             |
| Unfocused          | FocusStates          | The control doesn't have keyboard focus.           |
| Focused            | FocusStates          | The control has keyboard focus.                       |
| FocusedDropDown    | FocusStates          | The control has keyboard focus and the dropdown is open. |
| Editable            | EditStates           | The control is in editable mode.                       |
| Uneditable          | EditStates           | The control is in non-editable mode.                   |
| Valid              | ValidationStates     | The control is valid and has no validation errors.    |
| InvalidFocused       | ValidationStates     | The control has a validation error and has keyboard focus.  |
| InvalidUnfocused     | ValidationStates     | The control has a validation error but doesn't have keyboard focus.  |
