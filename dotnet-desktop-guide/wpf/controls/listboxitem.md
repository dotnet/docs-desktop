---
title: "ListBoxItem"
description: Learn about the ListBoxItem control in Windows Presentation Foundation (WPF), which represents individual selectable items within a ListBox control.
ms.date: "01/23/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
ai-usage: ai-assisted
---
# ListBoxItem

A <xref:System.Windows.Controls.ListBoxItem> represents an individual selectable item within a <xref:System.Windows.Controls.ListBox> control. When you add items to a ListBox collection, WPF automatically wraps each item in a ListBoxItem container.

The ListBoxItem control provides visual and behavioral properties for individual list items, including:

- **Selection behavior** - Handles how the item responds to user selection.
- **Visual states** - Manages appearance changes when the item is hovered, selected, or focused.
- **Content presentation** - Displays the actual data or content for that specific item.

You can customize the appearance and behavior of ListBoxItem containers by styling the ListBoxItem directly or by defining a custom ItemContainerStyle on the parent ListBox.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.ListBoxItem> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ListBoxItem> control uses the <xref:System.Windows.Controls.ContentControl.Content%2A> property as its content property. This property determines what displays within each list item and supports various content types including text, images, and complex UI elements.

### Parts

The <xref:System.Windows.Controls.ListBoxItem> control doesn't define any named template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ListBoxItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Selected|SelectionStates|The control is selected.|
|SelectedUnfocused|SelectionStates|The control is selected but doesn't have keyboard focus.|
|Unselected|SelectionStates|The control is not selected.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

## See also

- <xref:System.Windows.Controls.ListBox>
- <xref:System.Windows.Controls.ListBoxItem>
- [ListBox](listbox.md)