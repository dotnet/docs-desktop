# FlowDocumentScrollViewer

- **ControlName**: FlowDocumentScrollViewer
- **CodeFile**: System/Windows/Controls/FlowDocumentScrollViewer.cs
- **BaseClass**: Control
- **ControlType**: Control
- **ContentProperty**: Document

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_ContentHost | ScrollViewer | The scrolling host for the flow document content. |
| PART_FindToolBarHost | Decorator | The host for the find toolbar. |
| PART_ToolBarHost | Decorator | The host for the toolbar. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
