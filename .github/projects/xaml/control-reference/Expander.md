# Expander

- **ControlName**: Expander
- **CodeFile**: System/Windows/Controls/Expander.cs
- **BaseClass**: HeaderedContentControl
- **ControlType**: HeaderedContentControl
- **ContentProperty**: Content

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| HeaderSite | ToggleButton | The toggle button that expands and collapses the expander. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| MouseOver | CommonStates | The mouse is over the control. |
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Expanded | ExpansionStates | The control is expanded. |
| Collapsed | ExpansionStates | The control is collapsed. |
| ExpandDown | ExpandDirectionStates | The control expands downward. |
| ExpandUp | ExpandDirectionStates | The control expands upward. |
| ExpandLeft | ExpandDirectionStates | The control expands to the left. |
| ExpandRight | ExpandDirectionStates | The control expands to the right. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
