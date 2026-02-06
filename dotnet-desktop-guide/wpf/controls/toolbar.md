---
title: "ToolBar"
description: Learn about how the ToolBar control is a container for a group of commands or controls that are typically related in their function.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], ToolBar"
  - "ToolBar control [WPF]"
ai-usage: ai-assisted
---
# ToolBar

The <xref:System.Windows.Controls.ToolBar> control is a container for a group of commands or controls that are typically related in their function. It usually contains buttons that invoke commands and arranges them in a bar-like layout into a single row or column.

:::image type="content" source="./media/shared/toolbar.png" alt-text="A screenshot of a horizontal toolbar in WPF.":::

The <xref:System.Windows.Controls.ToolBar> control provides an overflow mechanism that places items that don't fit within a size-constrained toolbar into a special overflow area. You typically use <xref:System.Windows.Controls.ToolBar> controls with the related <xref:System.Windows.Controls.ToolBarTray> control, which provides special layout behavior and supports user-initiated sizing and arranging of toolbars.

## Position ToolBars in a ToolBarTray

Use the <xref:System.Windows.Controls.ToolBar.Band%2A> and <xref:System.Windows.Controls.ToolBar.BandIndex%2A> properties to position the <xref:System.Windows.Controls.ToolBar> in the <xref:System.Windows.Controls.ToolBarTray>. The <xref:System.Windows.Controls.ToolBar.Band%2A> property indicates the position where the <xref:System.Windows.Controls.ToolBar> is placed within its parent <xref:System.Windows.Controls.ToolBarTray>. The <xref:System.Windows.Controls.ToolBar.BandIndex%2A> property indicates the order where the <xref:System.Windows.Controls.ToolBar> is placed within its band. The following example shows how to use these properties to place <xref:System.Windows.Controls.ToolBar> controls inside a <xref:System.Windows.Controls.ToolBarTray>.

[!code-xaml[ToolBarExample#2](~/samples/snippets/csharp/VS_Snippets_Wpf/ToolBarExample/CS/Pane1.xaml#2)]

## Handle overflow items

A <xref:System.Windows.Controls.ToolBar> control often contains more items than can fit into the toolbar's size. When this happens, the toolbar displays an overflow button. To see the overflow items, click the overflow button and the items appear in a pop-up window below the toolbar. The following image shows a toolbar with overflow items.

:::image type="content" source="./media/shared/toolbar.png" alt-text="A screenshot of a horizontal toolbar in WPF with the overflow items showing.":::

Control when an item on a toolbar is placed on the overflow panel by setting the <xref:System.Windows.Controls.ToolBar.OverflowMode%2A?displayProperty=nameWithType> attached property to <xref:System.Windows.Controls.OverflowMode.Always?displayProperty=nameWithType>, <xref:System.Windows.Controls.OverflowMode.Never?displayProperty=nameWithType>, or <xref:System.Windows.Controls.OverflowMode.AsNeeded?displayProperty=nameWithType>. The following example specifies that the last four buttons on the toolbar should always be on the overflow panel.

[!code-xaml[ToolBarExample#3](../../samples/snippets/csharp/VS_Snippets_Wpf/ToolBarExample/CS/Pane1.xaml#3)]

The <xref:System.Windows.Controls.ToolBar> uses a <xref:System.Windows.Controls.Primitives.ToolBarPanel> and a <xref:System.Windows.Controls.Primitives.ToolBarOverflowPanel> in its <xref:System.Windows.Controls.ControlTemplate>. The <xref:System.Windows.Controls.Primitives.ToolBarPanel> handles the layout of the items on the toolbar. The <xref:System.Windows.Controls.Primitives.ToolBarOverflowPanel> handles the layout of the items that don't fit on the toolbar.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ToolBar> control uses the <xref:System.Windows.Controls.ItemsControl.Items%2A> property as its content property. This property allows you to add child items to the toolbar, which are typically buttons or other controls that invoke commands.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.ToolBar> control.

|Part|Type|Description|
|-|-|-|
|PART_ToolBarOverflowPanel|<xref:System.Windows.Controls.Primitives.ToolBarOverflowPanel>|The object that contains the controls that are in the overflow area of the toolbar.|
|PART_ToolBarPanel|<xref:System.Windows.Controls.Primitives.ToolBarPanel>|The object that contains the controls on the toolbar.|

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ToolBar>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the toolbar, and the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control. If the <xref:System.Windows.Controls.ItemsPresenter> isn't the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name `ItemsPresenter`.

### Visual states

This control doesn't define any visual states.

## See also

- [Style controls on a toolbar](how-to-style-controls-on-a-toolbar.md)
- [WPF Controls Gallery Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Getting%20Started/ControlsAndLayout)
- <xref:System.Windows.Controls.Primitives.ToolBarOverflowPanel>
- <xref:System.Windows.Controls.Primitives.ToolBarPanel>
- <xref:System.Windows.Controls.ToolBar>
- <xref:System.Windows.Controls.ToolBarTray>
