# FlowDocumentPageViewer

- **ControlName**: FlowDocumentPageViewer
- **CodeFile**: System/Windows/Controls/SinglePageViewer.cs
- **BaseClass**: DocumentViewerBase
- **ControlType**: Control
- **ContentProperty**: Document

## Template parts

| Part Name            | Part Type | Description                             |
|----------------------|-----------|-----------------------------------------|
| PART_FindToolBarHost | Decorator | The decorator that hosts the find toolbar. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description                                    |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
