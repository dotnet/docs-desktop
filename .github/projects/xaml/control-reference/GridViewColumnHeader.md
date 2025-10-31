# GridViewColumnHeader

- **ControlName**: GridViewColumnHeader
- **CodeFile**: System\Windows\Controls\GridViewColumnHeader.cs
- **BaseClass**: ButtonBase
- **ControlType**: ContentControl
- **ContentProperty**: Content

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_HeaderGripper | Thumb | The gripper thumb control used for resizing the column header. |
| PART_FloatingHeaderCanvas | Canvas | The canvas used to display the floating header during drag operations. |

## Visual states

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
