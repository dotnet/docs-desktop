# ScrollViewer

- **ControlName**: ScrollViewer
- **CodeFile**: System/Windows/Controls/ScrollViewer.cs
- **BaseClass**: ContentControl
- **ControlType**: ContentControl
- **ContentProperty**: Content

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_HorizontalScrollBar | ScrollBar | The horizontal scroll bar used to scroll content horizontally. |
| PART_VerticalScrollBar | ScrollBar | The vertical scroll bar used to scroll content vertically. |
| PART_ScrollContentPresenter | ScrollContentPresenter | The content presenter that displays the scrollable content. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
