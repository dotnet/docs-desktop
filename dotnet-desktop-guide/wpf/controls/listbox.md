---
title: "ListBox"
description: Learn about the ListBox control in Windows Presentation Foundation (WPF), which provides users with a selectable list of items.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "ListBox control [WPF]"
  - "controls [WPF], ListBox"
ai-usage: ai-assisted
---
# ListBox

A <xref:System.Windows.Controls.ListBox> control displays a collection of items that users can select from. The ListBox supports single or multiple selections and provides keyboard navigation, scrolling capabilities, and data binding functionality. It's commonly used in forms and applications where users need to choose from predefined options.

:::image type="content" source="./media/shared/listbox.png" alt-text="Screenshot of a typical ListBox control showing a list of selectable items":::

| Title | Description |
|-------|-------------|
| [Bind a ListBox to Data](how-to-bind-a-listbox-to-data.md) | Shows how to bind a ListBox to a data source. |
| [Get a ListBoxItem](how-to-get-a-listboxitem.md) | Shows how to retrieve a specific ListBoxItem from a ListBox. |
| [Improve the Scrolling Performance of a ListBox](how-to-improve-the-scrolling-performance-of-a-listbox.md) | Shows how to optimize scrolling performance in a ListBox with many items. |

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.ListBox> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ListBox>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ListBox>, and the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control. If the <xref:System.Windows.Controls.ItemsPresenter> isn't the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name `ItemsPresenter`.

### Content property

The <xref:System.Windows.Controls.ListBox> control uses the <xref:System.Windows.Controls.ItemsControl.Items%2A> property as its content property. This property represents the collection of items displayed in the ListBox and supports data binding to various data sources.

### Parts

The <xref:System.Windows.Controls.ListBox> control doesn't define any named template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ListBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

## See also

- [How to: Add Data to an ItemsControl](/previous-versions/dotnet/netframework-3.5/ms743602(v=vs.90))
- [ListBoxItem](listboxitem.md)
- <xref:System.Windows.Controls.ListBox>
- <xref:System.Windows.Controls.ListBoxItem>
