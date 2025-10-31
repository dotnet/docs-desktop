# TextBox

- **ControlName**: TextBox
- **CodeFile**: System/Windows/Controls/TextBox.cs
- **BaseClass**: TextBoxBase
- **ControlType**: ContentControl
- **ContentProperty**: Text

## Template parts

| Part Name     | Part Type       | Description                                   |
|----------------|------------------|-----------------------------------------------|
| PART_ContentHost | FrameworkElement | The framework element that hosts the text content. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description                                     |
|-----------------|----------------------|-------------------------------------------------|
| Normal          | CommonStates         | The control is in its normal state.             |
| MouseOver       | CommonStates         | The mouse is over the control.                  |
| ReadOnly        | CommonStates         | The control is in read-only mode.                |
| Disabled        | CommonStates         | The control is disabled.                          |
| Focused         | FocusStates          | The control has keyboard focus.                   |
| Unfocused       | FocusStates          | The control doesn't have keyboard focus.         |
| Valid           | ValidationStates    | The control is valid and has no validation errors. |
| InvalidFocused  | ValidationStates    | The control has a validation error and has keyboard focus. |
| InvalidUnfocused| ValidationStates    | The control has a validation error but doesn't have keyboard focus. |
