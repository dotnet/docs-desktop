---
title: "TabControl"
description: Learn how to use TabControl elements to display content on distinct pages accessed by selecting the appropriate tab.
ms.date: "01/26/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "TabControl control [WPF]"
  - "controls [WPF], TabControl"
ai-usage: ai-assisted
---
# TabControl

The <xref:System.Windows.Controls.TabControl> displays content on discrete pages that you access by selecting the appropriate tab. The TabControl serves as a container that manages a collection of <xref:System.Windows.Controls.TabItem> objects. Each <xref:System.Windows.Controls.TabItem> represents both the clickable tab header and its associated content page.

:::image type="content" source="./media/ss-ctl-tabcontrol.gif" alt-text="A TabControl with three tabs showing the middle tab selected and displaying its content":::

## Key concepts

The TabControl and TabItem controls work together to create a tabbed interface:

- **TabControl**: Acts as the container that manages tab selection, layout, and presentation. It handles user interactions like clicking tabs and displays the content of the currently selected tab.
- **TabItem**: Represents an individual tab within the TabControl. Each TabItem contains a header (the visible tab text or content) and content (what displays when you select the tab).
- **Relationship**: The TabControl's <xref:System.Windows.Controls.ItemsControl.Items> collection contains TabItem objects. When you select a TabItem, the TabControl displays that item's content and updates the visual state to show which tab is active.

For detailed information about individual tabs, see [TabItem](tabitem.md).

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.TabControl> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Styles and templates overview](styles-templates-overview.md) and [Create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.TabControl> uses the <xref:System.Windows.Controls.ItemsControl.Items> property as its content property. This property contains the collection of <xref:System.Windows.Controls.TabItem> objects that represent the individual tabs and their associated content. When you add TabItem objects to this collection, they appear as selectable tabs in the TabControl interface.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.TabControl> control.

|Part|Type|Description|
|-|-|-|
|PART_SelectedContentHost|<xref:System.Windows.Controls.ContentPresenter>|The object that shows the content of the currently selected <xref:System.Windows.Controls.TabItem>.|

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.TabControl>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.TabControl>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.TabControl> control.

|VisualState Name|VisualStateGroup Name|Description|
|----------------------|---------------------------|-----------------|
|Normal|CommonStates|The default state.|
|Disabled|CommonStates|The control is disabled.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|

## See also

- <xref:System.Windows.Controls.TabControl>
- <xref:System.Windows.Controls.TabItem>
- [Styles and templates overview](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
- [TabItem](tabitem.md)
