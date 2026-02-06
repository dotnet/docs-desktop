---
title: "TreeView"
description: Learn how the TreeView control displays information in a hierarchical structure by using collapsible nodes.
ms.date: 02/05/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "TreeView control [WPF]"
  - "controls [WPF], TreeView"
  - "hierarchical structure [WPF], TreeView control"
ms.assetid: 805c235c-0a0e-4e34-8d96-9dc3865cf2df
ai-usage: ai-assisted
---
# TreeView

The <xref:System.Windows.Controls.TreeView> control displays information in a hierarchical structure by using collapsible nodes. This article introduces the <xref:System.Windows.Controls.TreeView> and <xref:System.Windows.Controls.TreeViewItem> controls, and provides examples of their use.

The following illustration is an example of a <xref:System.Windows.Controls.TreeView> control that has nested <xref:System.Windows.Controls.TreeViewItem> controls:

:::image type="content" source="./media/shared/treeview.png" alt-text="A screenshot of a treeview control in WPF.":::

## What is a TreeView?

<xref:System.Windows.Controls.TreeView> is an <xref:System.Windows.Controls.ItemsControl> that nests the items by using <xref:System.Windows.Controls.TreeViewItem> controls. The following example creates a <xref:System.Windows.Controls.TreeView>.

[!code-xaml[TreeViewSnips#EmbeddedTVIs](~/samples/snippets/csharp/VS_Snippets_Wpf/TreeViewSnips/CSharp/Window1.xaml#embeddedtvis)]

## Create a TreeView

The <xref:System.Windows.Controls.TreeView> control contains a hierarchy of <xref:System.Windows.Controls.TreeViewItem> controls. A <xref:System.Windows.Controls.TreeViewItem> control is a <xref:System.Windows.Controls.HeaderedItemsControl> that has a <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> and an <xref:System.Windows.Controls.ItemsControl.Items%2A> collection.

If you're defining a <xref:System.Windows.Controls.TreeView> by using Extensible Application Markup Language (XAML), you can explicitly define the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> content of a <xref:System.Windows.Controls.TreeViewItem> control and the items that make up its collection. The previous illustration demonstrates this method.

You can also specify an <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> as a data source and then specify a <xref:System.Windows.Controls.HeaderedItemsControl.HeaderTemplate%2A> and <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> to define the <xref:System.Windows.Controls.TreeViewItem> content.

To define the layout of a <xref:System.Windows.Controls.TreeViewItem> control, you can also use <xref:System.Windows.HierarchicalDataTemplate> objects. For more information and an example, see [Use SelectedValue, SelectedValuePath, and SelectedItem](how-to-use-selectedvalue-selectedvaluepath-and-selecteditem.md).

If an item isn't a <xref:System.Windows.Controls.TreeViewItem> control, it's automatically enclosed by a <xref:System.Windows.Controls.TreeViewItem> control when the <xref:System.Windows.Controls.TreeView> control is displayed.

## Expand and collapse a TreeViewItem

If the user expands a <xref:System.Windows.Controls.TreeViewItem>, the <xref:System.Windows.Controls.TreeViewItem.IsExpanded%2A> property is set to `true`. You can also expand or collapse a <xref:System.Windows.Controls.TreeViewItem> without any direct user action by setting the <xref:System.Windows.Controls.TreeViewItem.IsExpanded%2A> property to `true` (expand) or `false` (collapse). When this property changes, an <xref:System.Windows.Controls.TreeViewItem.Expanded> or <xref:System.Windows.Controls.TreeViewItem.Collapsed> event occurs.

When the <xref:System.Windows.FrameworkElement.BringIntoView%2A> method is called on a <xref:System.Windows.Controls.TreeViewItem> control, the <xref:System.Windows.Controls.TreeViewItem> and its parent <xref:System.Windows.Controls.TreeViewItem> controls expand. If a <xref:System.Windows.Controls.TreeViewItem> isn't visible or partially visible, the <xref:System.Windows.Controls.TreeView> scrolls to make it visible.

## Select a TreeViewItem

When a user clicks a <xref:System.Windows.Controls.TreeViewItem> control to select it, the <xref:System.Windows.Controls.TreeViewItem.Selected> event occurs, and its <xref:System.Windows.Controls.TreeViewItem.IsSelected%2A> property is set to `true`. The <xref:System.Windows.Controls.TreeViewItem> also becomes the <xref:System.Windows.Controls.TreeView.SelectedItem%2A> of the <xref:System.Windows.Controls.TreeView> control. Conversely, when the selection changes from a <xref:System.Windows.Controls.TreeViewItem> control, its <xref:System.Windows.Controls.TreeViewItem.Unselected> event occurs and its <xref:System.Windows.Controls.TreeViewItem.IsSelected%2A> property is set to `false`.

The <xref:System.Windows.Controls.TreeView.SelectedItem%2A> property on the <xref:System.Windows.Controls.TreeView> control is a read-only property, so you can't explicitly set it. The <xref:System.Windows.Controls.TreeView.SelectedItem%2A> property is set if the user clicks on a <xref:System.Windows.Controls.TreeViewItem> control or when the <xref:System.Windows.Controls.TreeViewItem.IsSelected%2A> property is set to `true` on the <xref:System.Windows.Controls.TreeViewItem> control.

Use the <xref:System.Windows.Controls.TreeView.SelectedValuePath%2A> property to specify a <xref:System.Windows.Controls.TreeView.SelectedValue%2A> of a <xref:System.Windows.Controls.TreeView.SelectedItem%2A>. For more information, see [Use SelectedValue, SelectedValuePath, and SelectedItem](how-to-use-selectedvalue-selectedvaluepath-and-selecteditem.md).

You can register an event handler on the <xref:System.Windows.Controls.TreeView.SelectedItemChanged> event to determine when a selected <xref:System.Windows.Controls.TreeViewItem> changes. The <xref:System.Windows.RoutedPropertyChangedEventArgs%601> that's provided to the event handler specifies the <xref:System.Windows.RoutedPropertyChangedEventArgs%601.OldValue%2A>, which is the previous selection, and the <xref:System.Windows.RoutedPropertyChangedEventArgs%601.NewValue%2A>, which is the current selection. Either value can be `null` if the application or user hasn't made a previous or current selection.

## Style a TreeView

The default style for a <xref:System.Windows.Controls.TreeView> control places it inside a <xref:System.Windows.Controls.StackPanel> object that contains a <xref:System.Windows.Controls.ScrollViewer> control. When you set the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties for a <xref:System.Windows.Controls.TreeView>, these values are used to size the <xref:System.Windows.Controls.StackPanel> object that displays the <xref:System.Windows.Controls.TreeView>. If the content to display is larger than the display area, a <xref:System.Windows.Controls.ScrollViewer> automatically displays so that the user can scroll through the <xref:System.Windows.Controls.TreeView> content.

To customize the appearance of a <xref:System.Windows.Controls.TreeViewItem> control, set the <xref:System.Windows.FrameworkElement.Style%2A> property to a custom <xref:System.Windows.Style>.

The following example shows how to set the <xref:System.Windows.Controls.Control.Foreground%2A> and <xref:System.Windows.Controls.Control.FontSize%2A> property values for a <xref:System.Windows.Controls.TreeViewItem> control by using a <xref:System.Windows.FrameworkElement.Style%2A>.

[!code-xaml[TreeViewSimple#8](~/samples/snippets/csharp/VS_Snippets_Wpf/TreeViewSimple/CS/Window1.xaml#8)]

## Add images and other content to TreeView items

You can include more than one object in the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> content of a <xref:System.Windows.Controls.TreeViewItem>. To include multiple objects in <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> content, enclose the objects inside a layout control, such as a <xref:System.Windows.Controls.Panel> or <xref:System.Windows.Controls.StackPanel>.

The following example shows how to define the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> of a <xref:System.Windows.Controls.TreeViewItem> as a <xref:System.Windows.Controls.CheckBox> and <xref:System.Windows.Controls.TextBlock> that are both enclosed in a <xref:System.Windows.Controls.DockPanel> control.

[!code-xaml[TreeViewSnips#TVIHeader](~/samples/snippets/csharp/VS_Snippets_Wpf/TreeViewSnips/CSharp/Window1.xaml#tviheader)]

The following example shows how to define a <xref:System.Windows.DataTemplate> that contains an <xref:System.Windows.Controls.Image> and a <xref:System.Windows.Controls.TextBlock> that are enclosed in a <xref:System.Windows.Controls.DockPanel> control. You can use a <xref:System.Windows.DataTemplate> to set the <xref:System.Windows.Controls.HeaderedItemsControl.HeaderTemplate%2A> or <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> for a <xref:System.Windows.Controls.TreeViewItem>.

[!code-xaml[TreeViewDataBinding#6](~/samples/snippets/csharp/VS_Snippets_Wpf/TreeViewDataBinding/CSharp/Window1.xaml#6)]

## Common tasks

The following table lists common tasks for working with the TreeView control:

| Title | Description |
|-------|-------------|
| [Create Simple or Complex TreeViews](how-to-create-simple-or-complex-treeviews.md) | Learn how to create TreeView controls with different structures. |
| [Use SelectedValue, SelectedValuePath, and SelectedItem](how-to-use-selectedvalue-selectedvaluepath-and-selecteditem.md) | Learn how to work with selection properties in a TreeView. |
| [Bind a TreeView to Data That Has an Indeterminable Depth](how-to-bind-a-treeview-to-data-that-has-an-indeterminable-depth.md) | Learn how to bind a TreeView to hierarchical data with unknown depth. |
| [Improve the Performance of a TreeView](how-to-improve-the-performance-of-a-treeview.md) | Learn how to optimize TreeView performance. |
| [Find a TreeViewItem in a TreeView](how-to-find-a-treeviewitem-in-a-treeview.md) | Learn how to locate a specific TreeViewItem within a TreeView. |

## Related sections

[Data Binding Overview](../data/index.md)

[Data Templating Overview](../data/data-templating-overview.md)

## Reference

<xref:System.Windows.Controls.TreeView>
  <xref:System.Windows.Controls.TreeViewItem>

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.TreeView> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Parts

The <xref:System.Windows.Controls.TreeView> control does not have any named parts.

When you create a <xref:System.Windows.Controls.ControlTemplate> for an <xref:System.Windows.Controls.TreeView>, your template might contain a <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.TreeView>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.TreeView> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control does not have focus.|

#### TreeViewItem Parts

The following table lists the named parts for the <xref:System.Windows.Controls.TreeViewItem> control.

|Part|Type|Description|
|----------|----------|-----------------|
|PART_Header|<xref:System.Windows.FrameworkElement>|A visual element that contains the header content of the <xref:System.Windows.Controls.TreeView> control.|

#### TreeViewItem States

The following table lists the visual states for <xref:System.Windows.Controls.TreeViewItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|----------------------|---------------------------|-----------------|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the <xref:System.Windows.Controls.TreeViewItem>.|
|Disabled|CommonStates|The <xref:System.Windows.Controls.TreeViewItem> is disabled.|
|Focused|FocusStates|The <xref:System.Windows.Controls.TreeViewItem> has focus.|
|Unfocused|FocusStates|The <xref:System.Windows.Controls.TreeViewItem> does not have focus.|
|Expanded|ExpansionStates|The <xref:System.Windows.Controls.TreeViewItem> control is expanded.|
|Collapsed|ExpansionStates|The <xref:System.Windows.Controls.TreeViewItem> control is collapsed.|
|HasItems|HasItemsStates|The <xref:System.Windows.Controls.TreeViewItem> has items.|
|NoItems|HasItemsStates|The <xref:System.Windows.Controls.TreeViewItem> does not have items.|
|Selected|SelectionStates|The <xref:System.Windows.Controls.TreeViewItem> is selected.|
|SelectedInactive|SelectionStates|The <xref:System.Windows.Controls.TreeViewItem> is selected but not active.|
|Unselected|SelectionStates|The <xref:System.Windows.Controls.TreeViewItem> is not selected.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|

## Related Sections

[Data Binding Overview](../data/index.md)
  [Data Templating Overview](../data/data-templating-overview.md)
