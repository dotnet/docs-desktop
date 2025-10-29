---
title: "DataGrid"
description: Learn how the DataGrid control lets you display and edit data from different sources, such as a database, LINQ query, or any other bindable data source.
ms.date: "03/30/2017"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "DataGrid column types [WPF]"
  - "DataGrid scenarios [WPF]"
  - "DataGrid control [WPF]"
  - "controls [WPF], DataGrid"
  - "DataGrid [WPF], common tasks for"
  - "DataGrid [WPF], customizing the appearance of"
  - "DataGrid columns [WPF], using"
ms.assetid: bf89ea63-79b6-422b-bc9f-0485ad803216
---
# DataGrid

The <xref:System.Windows.Controls.DataGrid> control enables you to display and edit data from many different sources, such as from a SQL database, LINQ query, or any other bindable data source. For more information, see [Binding Sources Overview](../data/binding-sources-overview.md).

Columns can display text, controls, such as a <xref:System.Windows.Controls.ComboBox>, or any other WPF content, such as images, buttons, or any content contained in a template. You can use a <xref:System.Windows.Controls.DataGridTemplateColumn> to display data defined in a template. The following table lists the column types that are provided by default.

|Generated Column Type|Data Type|
|---------------------------|---------------|
|<xref:System.Windows.Controls.DataGridTextColumn>|<xref:System.String>|
|<xref:System.Windows.Controls.DataGridCheckBoxColumn>|<xref:System.Boolean>|
|<xref:System.Windows.Controls.DataGridComboBoxColumn>|<xref:System.Enum>|
|<xref:System.Windows.Controls.DataGridHyperlinkColumn>|<xref:System.Uri>|

<xref:System.Windows.Controls.DataGrid> can be customized in appearance, such as cell font, color, and size. <xref:System.Windows.Controls.DataGrid> supports all styling and templating functionality of other WPF controls. <xref:System.Windows.Controls.DataGrid> also includes default and customizable behaviors for editing, sorting, and validation.

The following table lists some of the common tasks for <xref:System.Windows.Controls.DataGrid> and how to accomplish them. By viewing the related API, you can find more information and sample code.

|Scenario|Approach|
|--------------|--------------|
|Alternating background colors|Set the <xref:System.Windows.Controls.ItemsControl.AlternationCount%2A> property to 2 or more, and then assign a <xref:System.Windows.Media.Brush> to the <xref:System.Windows.Controls.DataGrid.RowBackground%2A> and <xref:System.Windows.Controls.DataGrid.AlternatingRowBackground%2A> properties.|
|Define cell and row selection behavior|Set the <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> and <xref:System.Windows.Controls.DataGrid.SelectionUnit%2A> properties.|
|Customize the visual appearance of headers, cells, and rows|Apply a new <xref:System.Windows.Style> to the <xref:System.Windows.Controls.DataGrid.ColumnHeaderStyle%2A>, <xref:System.Windows.Controls.DataGrid.RowHeaderStyle%2A>, <xref:System.Windows.Controls.DataGrid.CellStyle%2A>, or <xref:System.Windows.Controls.DataGrid.RowStyle%2A> properties.|
|Set sizing options|Set the <xref:System.Windows.FrameworkElement.Height%2A>, <xref:System.Windows.FrameworkElement.MaxHeight%2A>, <xref:System.Windows.FrameworkElement.MinHeight%2A>, <xref:System.Windows.FrameworkElement.Width%2A>, <xref:System.Windows.FrameworkElement.MaxWidth%2A>, or <xref:System.Windows.FrameworkElement.MinWidth%2A> properties. For more information, see [Sizing Options in the DataGrid Control](sizing-options-in-the-datagrid-control.md).|
|Access selected items|Check the <xref:System.Windows.Controls.DataGrid.SelectedCells%2A> property to get the selected cells and the <xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems%2A> property to get the selected rows. For more information, see <xref:System.Windows.Controls.DataGrid.SelectedCells%2A>.|
|Customize end-user interactions|Set the <xref:System.Windows.Controls.DataGrid.CanUserAddRows%2A>, <xref:System.Windows.Controls.DataGrid.CanUserDeleteRows%2A>, <xref:System.Windows.Controls.DataGrid.CanUserReorderColumns%2A>, <xref:System.Windows.Controls.DataGrid.CanUserResizeColumns%2A>, <xref:System.Windows.Controls.DataGrid.CanUserResizeRows%2A>, and <xref:System.Windows.Controls.DataGrid.CanUserSortColumns%2A> properties.|
|Cancel or change auto-generated columns|Handle the <xref:System.Windows.Controls.DataGrid.AutoGeneratingColumn> event.|
|Freeze a column|Set the <xref:System.Windows.Controls.DataGrid.FrozenColumnCount%2A> property to 1 and move the column to the left-most position by setting the <xref:System.Windows.Controls.DataGridColumn.DisplayIndex%2A> property to 0.|
|Use XML data as the data source|Bind the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> on the <xref:System.Windows.Controls.DataGrid> to the XPath query that represents the collection of items. Create each column in the <xref:System.Windows.Controls.DataGrid>. Bind each column by setting the XPath on the binding to the query that gets the property on the item source. For an example, see <xref:System.Windows.Controls.DataGridTextColumn>.|

## Related Topics

|Title|Description|
|-----------|-----------------|
|[Walkthrough: Display Data from a SQL Server Database in a DataGrid Control](walkthrough-display-data-from-a-sql-server-database-in-a-datagrid-control.md)|Describes how to set up a new WPF project, add an Entity Framework Element, set the source, and display the data in a <xref:System.Windows.Controls.DataGrid>.|
|[How to: Add Row Details to a DataGrid Control](how-to-add-row-details-to-a-datagrid-control.md)|Describes how to create row details for a <xref:System.Windows.Controls.DataGrid>.|
|[How to: Implement Validation with the DataGrid Control](how-to-implement-validation-with-the-datagrid-control.md)|Describes how to validate values in <xref:System.Windows.Controls.DataGrid> cells and rows, and display validation feedback.|
|[Default Keyboard and Mouse Behavior in the DataGrid Control](default-keyboard-and-mouse-behavior-in-the-datagrid-control.md)|Describes how to interact with the <xref:System.Windows.Controls.DataGrid> control by using the keyboard and mouse.|
|[How to: Group, Sort, and Filter Data in the DataGrid Control](how-to-group-sort-and-filter-data-in-the-datagrid-control.md)|Describes how to view data in a <xref:System.Windows.Controls.DataGrid> in different ways by grouping, sorting, and filtering the data.|
|[Sizing Options in the DataGrid Control](sizing-options-in-the-datagrid-control.md)|Describes how to control absolute and automatic sizing in the <xref:System.Windows.Controls.DataGrid>.|

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.DataGrid> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.DataGrid> control.

|Part|Type|Description|
|-|-|-|
|PART_ColumnHeadersPresenter|<xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter>|The row that contains the column headers.|

When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.DataGrid>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.DataGrid>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.

The default template for the <xref:System.Windows.Controls.DataGrid> contains a <xref:System.Windows.Controls.ScrollViewer> control. For more information about the parts defined by the <xref:System.Windows.Controls.ScrollViewer>, see [ScrollViewer Styles and Templates](scrollviewer-styles-and-templates.md).

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.DataGrid> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|Disabled|CommonStates|The control is disabled.|
|InvalidFocused|ValidationStates|The control is not valid and has focus.|
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|
|Valid|ValidationStates|The control is valid.|

#### DataGridCell Parts

The <xref:System.Windows.Controls.DataGridCell> element does not have any named parts.

#### DataGridCell States

The following table lists the visual states for the <xref:System.Windows.Controls.DataGridCell> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the cell.|
|Focused|FocusStates|The cell has focus.|
|Unfocused|FocusStates|The cell does not have focus|
|Current|CurrentStates|The cell is the current cell.|
|Regular|CurrentStates|The cell is not the current cell.|
|Display|InteractionStates|The cell is in display mode.|
|Editing|InteractionStates|The cell is in edit mode.|
|Selected|SelectionStates|The cell is selected.|
|Unselected|SelectionStates|The cell is not selected.|
|InvalidFocused|ValidationStates|The cell is not valid and has focus.|
|InvalidUnfocused|ValidationStates|The cell is not valid and does not have focus.|
|Valid|ValidationStates|The cell is valid.|

#### DataGridRow Parts

The <xref:System.Windows.Controls.DataGridRow> element does not have any named parts.

#### DataGridRow States

The following table lists the visual states for the <xref:System.Windows.Controls.DataGridRow> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the row.|
|MouseOver_Editing|CommonStates|The mouse pointer is positioned over the row and the row is in edit mode.|
|MouseOver_Selected|CommonStates|The mouse pointer is positioned over the row and the row is selected.|
|MouseOver_Unfocused_Editing|CommonStates|The mouse pointer is positioned over the row, the row is in edit mode, and does not have focus.|
|MouseOver_Unfocused_Selected|CommonStates|The mouse pointer is positioned over the row, the row is selected, and does not have focus.|
|Normal_AlternatingRow|CommonStates|The row is an alternating row.|
|Normal_Editing|CommonStates|The row is in edit mode.|
|Normal_Selected|CommonStates|The row is selected.|
|Unfocused_Editing|CommonStates|The row is in edit mode and does not have focus.|
|Unfocused_Selected|CommonStates|The row is selected and does not have focus.|
|InvalidFocused|ValidationStates|The control is not valid and has focus.|
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|
|Valid|ValidationStates|The control is valid.|

#### DataGridRowHeader Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element.

|Part|Type|Description|
|-|-|-|
|PART_TopHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the row header from the top.|
|PART_BottomHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the row header from the bottom.|

#### DataGridRowHeader States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the row.|
|MouseOver_CurrentRow|CommonStates|The mouse pointer is positioned over the row and the row is the current row.|
|MouseOver_CurrentRow_Selected|CommonStates|The mouse pointer is positioned over the row, and the row is current and selected.|
|MouseOver_EditingRow|CommonStates|The mouse pointer is positioned over the row and the row is in edit mode.|
|MouseOver_Selected|CommonStates|The mouse pointer is positioned over the row and the row is selected.|
|MouseOver_Unfocused_CurrentRow_Selected|CommonStates|The mouse pointer is positioned over the row, the row is current and selected, and does not have focus.|
|MouseOver_Unfocused_EditingRow|CommonStates|The mouse pointer is positioned over the row, the row is in edit mode, and does not have focus.|
|MouseOver_Unfocused_Selected|CommonStates|The mouse pointer is positioned over the row, the row is selected, and does not have focus.|
|Normal_CurrentRow|CommonStates|The row is the current row.|
|Normal_CurrentRow_Selected|CommonStates|The row is the current row and is selected.|
|Normal_EditingRow|CommonStates|The row is in edit mode.|
|Normal_Selected|CommonStates|The row is selected.|
|Unfocused_CurrentRow_Selected|CommonStates|The row is the current row, is selected, and does not have focus.|
|Unfocused_EditingRow|CommonStates|The row is in edit mode and does not have focus.|
|Unfocused_Selected|CommonStates|The row is selected and does not have focus.|
|InvalidFocused|ValidationStates|The control is not valid and has focus.|
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|
|Valid|ValidationStates|The control is valid.|

#### DataGridColumnHeadersPresenter Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element.

|Part|Type|Description|
|-|-|-|
|PART_FillerColumnHeader|<xref:System.Windows.Controls.Primitives.DataGridColumnHeader>|The placeholder for column headers.|

#### DataGridColumnHeadersPresenter States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|InvalidFocused|ValidationStates|The cell is not valid and has focus.|
|InvalidUnfocused|ValidationStates|The cell is not valid and does not have focus.|
|Valid|ValidationStates|The cell is valid.|

#### DataGridColumnHeader Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element.

|Part|Type|Description|
|-|-|-|
|PART_LeftHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the column header from the left.|
|PART_RightHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the column header from the right.|

#### DataGridColumnHeader States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Pressed|CommonStates|The control is pressed.|
|SortAscending|SortStates|The column is sorted in ascending order.|
|SortDescending|SortStates|The column is sorted in descending order.|
|Unsorted|SortStates|The column is not sorted.|
|InvalidFocused|ValidationStates|The control is not valid and has focus.|
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|
|Valid|ValidationStates|The control is valid.|

#### DataGrid ControlTemplate Example

The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.DataGrid> control and its associated types.

[!code-xaml[ControlTemplateExamples#DataGrid](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/datagrid.xaml#datagrid)]

The preceding example uses one or more of the following resources.

[!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]

For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).

## See also

- <xref:System.Windows.Controls.DataGrid>
- [Styling and Templating](styles-templates-overview.md)
- [Data Binding Overview](../data/index.md)
- [Data Templating Overview](../data/data-templating-overview.md)
- [Controls](index.md)
- [WPF Content Model](wpf-content-model.md)
