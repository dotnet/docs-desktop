# TabControl

- **ControlName**: TabControl
- **CodeFile**: System/Windows/Controls/TabControl.cs
- **BaseClass**: Selector
- **ControlType**: ItemsControl
- **ContentProperty**: Items

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_SelectedContentHost | ContentPresenter | The content presenter that displays the content of the selected tab item. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| Disabled | CommonStates | The control is disabled. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
