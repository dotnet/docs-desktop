---
title: "ListView"
description: Learn about the ListView control in Windows Presentation Foundation (WPF), which provides the infrastructure to display data items in different layouts or views.
ms.date: "01/28/2026"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "controls [WPF], ListView"
  - "ListView control [WPF]"
  - "ListView controls [WPF], about ListView control"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
---
# ListView

The <xref:System.Windows.Controls.ListView> control provides the infrastructure to display a set of data items using a different layout or view. For example, you might want to display data items in a table and also sort its columns.

:::image type="content" source="./media/shared/listview.png" alt-text="Screenshot showing a ListView with GridView output displaying file information.":::

> [!NOTE]
> The types referenced in this article are available in the [Code reference](#code-reference) section.

The following table lists common tasks for working with the ListView control:

| Title | Description |
|-------|-------------|
| [Sort a GridView Column When a Header Is Clicked](how-to-sort-a-gridview-column-when-a-header-is-clicked.md) | Learn how to sort a GridView column when a header is clicked. |
| [Create a Custom View Mode for a ListView](how-to-create-a-custom-view-mode-for-a-listview.md) | Learn how to create a custom view mode for a ListView. |
| [Use Templates to Style a ListView That Uses GridView](how-to-use-templates-to-style-a-listview-that-uses-gridview.md) | Learn how to use templates to style a ListView that uses GridView. |
| [Create a Style for a Dragged GridView Column Header](how-to-create-a-style-for-a-dragged-gridview-column-header.md) | Learn how to create a style for a dragged GridView column header. |
| [Display ListView Contents by Using a GridView](how-to-display-listview-contents-by-using-a-gridview.md) | Learn how to display ListView contents using a GridView. |
| [Use Triggers to Style Selected Items in a ListView](how-to-use-triggers-to-style-selected-items-in-a-listview.md) | Learn how to use triggers to style selected items in a ListView. |
| [Create ListViewItems with a CheckBox](how-to-create-listviewitems-with-a-checkbox.md) | Learn how to create ListViewItems with a CheckBox. |
| [Display Data by Using GridViewRowPresenter](how-to-display-data-by-using-gridviewrowpresenter.md) | Learn how to display data using GridViewRowPresenter. |
| [Group Items in a ListView That Implements a GridView](how-to-group-items-in-a-listview-that-implements-a-gridview.md) | Learn how to group items in a ListView that implements a GridView. |
| [Style a Row in a ListView That Implements a GridView](how-to-style-a-row-in-a-listview-that-implements-a-gridview.md) | Learn how to style a row in a ListView that implements a GridView. |
| [Change the Horizontal Alignment of a Column in a ListView](how-to-change-the-horizontal-alignment-of-a-column-in-a-listview.md) | Learn how to change the horizontal alignment of a column in a ListView. |
| [Handle the MouseDoubleClick Event for Each Item in a ListView](how-to-handle-the-mousedoubleclick-event-for-each-item-in-a-listview.md) | Learn how to handle the MouseDoubleClick event for each item in a ListView. |

## What is a ListView?

The <xref:System.Windows.Controls.ListView> derives from <xref:System.Windows.Controls.ListBox>. Typically, its items are members of a data collection and are represented as <xref:System.Windows.Controls.ListViewItem> objects. A <xref:System.Windows.Controls.ListViewItem> is a <xref:System.Windows.Controls.ContentControl> and can contain only a single child element. However, that child element can be any visual element.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ListView> control uses the <xref:System.Windows.Controls.ItemsControl.Items%2A> property as its content property. This property allows you to specify the items displayed in the control.

### Parts

The <xref:System.Windows.Controls.ListView> control doesn't define any named template parts.

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ListView>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ListView>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control. If the <xref:System.Windows.Controls.ItemsPresenter> isn't the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ListView> control.

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

The following table lists the states for the <xref:System.Windows.Controls.ListViewItem> control.

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The default state. |
| Disabled | CommonStates | The control is disabled. |
| MouseOver | CommonStates | The mouse pointer is over the control. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Selected | SelectionStates | The item is currently selected. |
| Unselected | SelectionStates | The item isn't selected. |
| SelectedUnfocused | SelectionStates | The item is selected but doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## View modes

To specify a view mode for the content of a <xref:System.Windows.Controls.ListView> control, set the <xref:System.Windows.Controls.ListView.View%2A> property. One view mode that Windows Presentation Foundation (WPF) provides is <xref:System.Windows.Controls.GridView>, which displays a collection of data items in a table that has customizable columns.

The following example shows how to define a <xref:System.Windows.Controls.GridView> for a <xref:System.Windows.Controls.ListView> control that displays employee information.

[!code-xaml[ListViewCode#ListViewEmployee](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#listviewemployee)]

You can create a custom view mode by defining a class that inherits from the <xref:System.Windows.Controls.ViewBase> class. The <xref:System.Windows.Controls.ViewBase> class provides the infrastructure you need to create a custom view. For more information about how to create a custom view, see [Create a Custom View Mode for a ListView](how-to-create-a-custom-view-mode-for-a-listview.md).

### Sharing view modes

Two <xref:System.Windows.Controls.ListView> controls can't share the same view mode at the same time. If you try to use the same view mode with more than one <xref:System.Windows.Controls.ListView> control, an exception occurs. To specify a view mode that can be simultaneously used by more than one <xref:System.Windows.Controls.ListView>, use templates or styles.

## Data binding

Use the <xref:System.Windows.Controls.ItemsControl.Items%2A> and <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> properties to specify items for a <xref:System.Windows.Controls.ListView> control. The following example sets the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property to a data collection called `EmployeeInfoDataSource`.

[!code-xaml[ListViewCode#ItemsSource](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#itemssource)]

In a <xref:System.Windows.Controls.GridView>, <xref:System.Windows.Controls.GridViewColumn> objects bind to specified data fields. The following example binds a <xref:System.Windows.Controls.GridViewColumn> object to a data field by specifying a <xref:System.Windows.Data.Binding> for the <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A> property.

[!code-csharp[ListViewCode#GridViewColumnProperties](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml.cs#gridviewcolumnproperties)]
[!code-vb[ListViewCode#GridViewColumnProperties](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ListViewCode/visualbasic/window1.xaml.vb#gridviewcolumnproperties)]
[!code-xaml[ListViewCode#GridViewColumnProperties](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#gridviewcolumnproperties)]

You can also specify a <xref:System.Windows.Data.Binding> as part of a <xref:System.Windows.DataTemplate> definition that you use to style the cells in a column. In the following example, the <xref:System.Windows.DataTemplate> identified with a <xref:System.Windows.ResourceKey> sets the <xref:System.Windows.Data.Binding> for a <xref:System.Windows.Controls.GridViewColumn>. Note that this example doesn't define the <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A> because doing so takes precedence over <xref:System.Windows.Controls.GridViewColumn.CellTemplate%2A>.

[!code-xaml[ListViewTemplate#GridViewCellTemplate](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewTemplate/CS/window1.xaml#gridviewcelltemplate)]

[!code-xaml[ListViewTemplate#CellTemplateProperty](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewTemplate/CS/window1.xaml#celltemplateproperty)]

## Styling ListView controls

The <xref:System.Windows.Controls.ListView> control contains <xref:System.Windows.Controls.ListViewItem> objects, which represent the data items that are displayed. You can use the following properties to define the content and style of data items:

- On the <xref:System.Windows.Controls.ListView> control, use the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A>, <xref:System.Windows.Controls.ItemsControl.ItemTemplateSelector%2A>, and <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> properties.
- On the <xref:System.Windows.Controls.ListViewItem> control, use the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> and <xref:System.Windows.Controls.ContentControl.ContentTemplateSelector%2A> properties.

To avoid alignment issues between cells in a <xref:System.Windows.Controls.GridView>, don't use the <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> to set properties or add content that affects the width of an item in a <xref:System.Windows.Controls.ListView>. For example, an alignment issue can occur when you set the <xref:System.Windows.FrameworkElement.Margin%2A> property in the <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A>. To specify properties or define content that affects the width of items in a <xref:System.Windows.Controls.GridView>, use the properties of the <xref:System.Windows.Controls.GridView> class and its related classes, such as <xref:System.Windows.Controls.GridViewColumn>. For more information about how to use <xref:System.Windows.Controls.GridView> and its supporting classes, see [GridView Overview](gridview-overview.md).

If you define an <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> for a <xref:System.Windows.Controls.ListView> control and also define an <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A>, you must include a <xref:System.Windows.Controls.ContentPresenter> in the style in order for the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> to work correctly.

Don't use the <xref:System.Windows.Controls.Control.HorizontalContentAlignment%2A> and <xref:System.Windows.Controls.Control.VerticalContentAlignment%2A> properties for <xref:System.Windows.Controls.ListView> content displayed by a <xref:System.Windows.Controls.GridView>. To specify the alignment of content in a column of a <xref:System.Windows.Controls.GridView>, define a <xref:System.Windows.Controls.GridViewColumn.CellTemplate%2A>.

## Code reference

The following objects are referenced in this article:

- `EmployeeInfoDataSource` data collection. If you're using Visual Basic .NET, the `Window` element is declared slightly different from what you see in the example code:

  :::code language="xaml" source="~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml" range="1-8" highlight="4,6-8" :::

- `EmployeeInfo` class, which is used as the type for the `EmployeeInfoDataSource` data collection.

  :::code language="csharp" source="~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml.cs" range="66-96" :::
  :::code language="vb" source="~/samples/snippets/visualbasic/VS_Snippets_Wpf/ListViewCode/visualbasic/window1.xaml.vb" range="63-100" :::

## See also

- <xref:System.Windows.Controls.GridView>
- <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A>
- <xref:System.Windows.Controls.ItemsControl.Items%2A>
- <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A>
- <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A>
- <xref:System.Windows.Controls.ItemsControl.ItemTemplateSelector%2A>
- <xref:System.Windows.Controls.ListView>
- <xref:System.Windows.Controls.ListViewItem>
- <xref:System.Windows.Controls.ViewBase>
- <xref:System.Windows.Data.Binding>
- [Controls](../advanced/optimizing-performance-controls.md)
- [Create a Custom View Mode for a ListView](how-to-create-a-custom-view-mode-for-a-listview.md)
- [Data Binding Overview](../data/index.md)
- [Data Templating Overview](../data/data-templating-overview.md)
- [GridView Overview](gridview-overview.md)
