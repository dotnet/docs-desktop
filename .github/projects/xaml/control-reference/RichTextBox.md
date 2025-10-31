# RichTextBox

- **ControlName**: RichTextBox
- **CodeFile**: System/Windows/Controls/RichTextBox.cs
- **BaseClass**: TextBoxBase
- **ControlType**: Control
- **ContentProperty**: Document

## Template parts

| Part Name      | Part Type         | Description                                       |
|----------------|-------------------|---------------------------------------------------|
| PART_ContentHost| FrameworkElement  | The framework element that contains the content of the text box. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description                                       |
|-|-|-|
| Normal            | CommonStates        | The control is in its normal state.                |
| MouseOver        | CommonStates        | The mouse is over the control.                    |
| Disabled          | CommonStates        | The control is disabled.                          |
| ReadOnly          | CommonStates        | The control is read-only.                        |
| Focused           | FocusStates         | The control has keyboard focus.                  |
| Unfocused         | FocusStates         | The control doesn't have keyboard focus.          |
| Valid             | ValidationStates    | The control is valid and has no validation errors.|
| InvalidFocused    | ValidationStates    | The control has a validation error and has keyboard focus. |
| InvalidUnfocused  | ValidationStates    | The control has a validation error but doesn't have keyboard focus. |
