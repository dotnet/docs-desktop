---
title: "ListBox"
description: Learn about the ListBox control in Windows Presentation Foundation (WPF), which provides users with a selectable lists of items.
ms.date: "01/22/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "ListBox control [WPF]"
  - "controls [WPF], ListBox"
ai-usage: ai-assisted
---
# ListBox

A <xref:System.Windows.Controls.ListBox> control provides users with a list of selectable items.

The following figure illustrates a typical <xref:System.Windows.Controls.ListBox>.

:::image type="content" source="./media/ss-ctl-listbox.gif" alt-text="Screenshot of a typical ListBox control showing a list of selectable items":::

| Title | Description |
|-------|-------------|
| [Bind a ListBox to Data](how-to-bind-a-listbox-to-data.md) | Shows how to bind a ListBox to a data source. |
| [Get a ListBoxItem](how-to-get-a-listboxitem.md) | Shows how to retrieve a specific ListBoxItem from a ListBox. |
| [Improve the Scrolling Performance of a ListBox](how-to-improve-the-scrolling-performance-of-a-listbox.md) | Shows how to optimize scrolling performance in a ListBox with many items. |

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.ListBox> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ListBox> control uses the <xref:System.Windows.Controls.ItemsControl.Items%2A> property as its content property. This property allows you to populate the ListBox with a collection of items that users can select from.

### Parts

The <xref:System.Windows.Controls.ListBox> control does not define any named template parts.

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ListBox>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ListBox>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ListBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but does not have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

#### ListBoxItem Content property

The <xref:System.Windows.Controls.ListBoxItem> control uses the <xref:System.Windows.Controls.ContentControl.Content%2A> property as its content property. This property allows you to specify the content that appears within each list item.

#### ListBoxItem Parts

The <xref:System.Windows.Controls.ListBoxItem> control does not define any named template parts.

#### ListBoxItem States

The following table lists the visual states for the <xref:System.Windows.Controls.ListBoxItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Disabled|CommonStates|The control is disabled.|
|MouseOver|CommonStates|The mouse is over the control.|
|Normal|CommonStates|The control is in its normal state.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Selected|SelectionStates|The control is selected.|
|SelectedUnfocused|SelectionStates|The control is selected but doesn't have keyboard focus.|
|Unselected|SelectionStates|The control is not selected.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

## See also

- [How to: Add Data to an ItemsControl](/previous-versions/dotnet/netframework-3.5/ms743602(v=vs.90))
- <xref:System.Windows.Controls.ListBox>
- <xref:System.Windows.Controls.ListBoxItem>
