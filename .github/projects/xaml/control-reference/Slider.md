# Slider

- **ControlName**: Slider
- **CodeFile**: System/Windows/Controls/Slider.cs
- **BaseClass**: RangeBase
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Track | Track | The track element that contains the thumb and provides the slider's range visualization. |
| PART_SelectionRange | FrameworkElement | The element that displays the selection range on the slider when IsSelectionRangeEnabled is true. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| MouseOver | CommonStates | The mouse is over the control. |
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
