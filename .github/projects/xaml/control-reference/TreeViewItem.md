# TreeViewItem

- **ControlName**: TreeViewItem
- **CodeFile**: System/Windows/Controls/TreeViewItem.cs
- **BaseClass**: HeaderedItemsControl
- **ControlType**: HeaderedItemsControl
- **ContentProperty**: Items

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Header | FrameworkElement | The header element of the TreeViewItem. |
| ItemsHost | ItemsPresenter | The items presenter that hosts the child items. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| MouseOver | CommonStates | The mouse is over the control. |
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Expanded | ExpansionStates | The TreeViewItem is expanded to show its child items. |
| Collapsed | ExpansionStates | The TreeViewItem is collapsed and child items are hidden. |
| HasItems | HasItemsStates | The TreeViewItem has child items. |
| NoItems | HasItemsStates | The TreeViewItem has no child items. |
| Selected | SelectionStates | The TreeViewItem is selected and the selection is active. |
| SelectedInactive | SelectionStates | The TreeViewItem is selected but the selection is inactive. |
| Unselected | SelectionStates | The TreeViewItem is not selected. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
