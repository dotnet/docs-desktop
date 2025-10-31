# ProgressBar

- **ControlName**: ProgressBar
- **CodeFile**: System/Windows/Controls/ProgressBar.cs
- **BaseClass**: RangeBase
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name   | Part Type         | Description                                             |
|-------------|-------------------|---------------------------------------------------------|
| PART_Track  | FrameworkElement  | The track that represents the full range of the progress bar. |
| PART_Indicator | FrameworkElement  | The indicator that shows the current progress value.        |
| PART_GlowRect | FrameworkElement  | The glow element used for indeterminate progress animation.  |

## Visual states

| VisualState Name | VisualStateGroup Name | Description                                               |
|------------------|----------------------|-----------------------------------------------------------|
| Determinate      | CommonStates        | The control shows determinate progress with a specific value. |
| Indeterminate    | CommonStates        | The control shows indeterminate progress with animated indicator. |
| Valid             | ValidationStates     | The control is valid and has no validation errors.          |
| InvalidFocused    | ValidationStates     | The control has a validation error and has keyboard focus.   |
| InvalidUnfocused  | ValidationStates     | The control has a validation error but does not have keyboard focus. |
