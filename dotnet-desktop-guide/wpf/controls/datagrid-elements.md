---
title: "DataGrid Elements"
description: Learn about the DataGrid element types including DataGridCell, DataGridRow, DataGridRowHeader, DataGridColumnHeader, and DataGridColumnHeadersPresenter and how they work together to form the DataGrid control.
ms.date: 01/30/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "DataGridCell [WPF]"
  - "DataGridRow [WPF]"
  - "DataGridRowHeader [WPF]"
  - "DataGridColumnHeader [WPF]"
  - "DataGridColumnHeadersPresenter [WPF]"
  - "controls [WPF], DataGrid elements"
---

# DataGrid Elements

The <xref:System.Windows.Controls.DataGrid> control is composed of several specialized component types that work together to display and manage tabular data. Understanding these components and their relationship to the <xref:System.Windows.Controls.DataGrid> helps you customize the appearance and behavior of the data grid to meet your specific needs.

## Element overview

The <xref:System.Windows.Controls.DataGrid> consists of the following primary elements:

- **<xref:System.Windows.Controls.DataGridCell>** - Represents an individual cell within the grid that displays a single data value.
- **<xref:System.Windows.Controls.DataGridRow>** - Represents a row of data within the grid, containing multiple cells.
- **<xref:System.Windows.Controls.Primitives.DataGridRowHeader>** - Provides the row header area at the left side of each row, typically used for row selection indicators.
- **<xref:System.Windows.Controls.Primitives.DataGridColumnHeader>** - Represents the header of a column, typically displaying the column title and providing sorting functionality.
- **<xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter>** - Contains and presents all column headers in a row at the top of the grid.

These elements are arranged hierarchically within the <xref:System.Windows.Controls.DataGrid> to create the familiar tabular layout. The <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> displays column headers at the top, while each <xref:System.Windows.Controls.DataGridRow> contains multiple <xref:System.Windows.Controls.DataGridCell> elements along with a <xref:System.Windows.Controls.Primitives.DataGridRowHeader>.

## Customizing elements

You can customize each element by applying styles or modifying templates. For example:

- Style the <xref:System.Windows.Controls.DataGridCell> to change cell appearance using the <xref:System.Windows.Controls.DataGrid.CellStyle%2A> property.
- Style the <xref:System.Windows.Controls.DataGridRow> to change row appearance using the <xref:System.Windows.Controls.DataGrid.RowStyle%2A> property.
- Style the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> to customize row headers using the <xref:System.Windows.Controls.DataGrid.RowHeaderStyle%2A> property.
- Style the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> to customize column headers using the <xref:System.Windows.Controls.DataGrid.ColumnHeaderStyle%2A> property.

For more information about styling and templating, see [Styling and Templating](styles-templates-overview.md).

## DataGridCell

The <xref:System.Windows.Controls.DataGridCell> element represents an individual cell within the data grid and responds to user interactions such as selection and editing.

### Parts

The <xref:System.Windows.Controls.DataGridCell> element doesn't define any named template parts.

### States

The following table lists the visual states for the <xref:System.Windows.Controls.DataGridCell> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the cell.|
|Focused|FocusStates|The cell has focus.|
|Unfocused|FocusStates|The cell doesn't have focus.|
|Current|CurrentStates|The cell is the current cell.|
|Regular|CurrentStates|The cell isn't the current cell.|
|Display|InteractionStates|The cell is in display mode.|
|Editing|InteractionStates|The cell is in edit mode.|
|Selected|SelectionStates|The cell is selected.|
|Unselected|SelectionStates|The cell isn't selected.|
|InvalidFocused|ValidationStates|The cell isn't valid and has focus.|
|InvalidUnfocused|ValidationStates|The cell isn't valid and doesn't have focus.|
|Valid|ValidationStates|The cell is valid.|

## DataGridRow

The <xref:System.Windows.Controls.DataGridRow> element represents a row of data within the grid. Each row contains multiple cells and a row header.

### Parts

The <xref:System.Windows.Controls.DataGridRow> element doesn't define any named template parts.

### States

The following table lists the visual states for the <xref:System.Windows.Controls.DataGridRow> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the row.|
|MouseOver_Editing|CommonStates|The mouse pointer is positioned over the row and the row is in edit mode.|
|MouseOver_Selected|CommonStates|The mouse pointer is positioned over the row and the row is selected.|
|MouseOver_Unfocused_Editing|CommonStates|The mouse pointer is positioned over the row, the row is in edit mode, and doesn't have focus.|
|MouseOver_Unfocused_Selected|CommonStates|The mouse pointer is positioned over the row, the row is selected, and doesn't have focus.|
|Normal_AlternatingRow|CommonStates|The row is an alternating row.|
|Normal_Editing|CommonStates|The row is in edit mode.|
|Normal_Selected|CommonStates|The row is selected.|
|Unfocused_Editing|CommonStates|The row is in edit mode and doesn't have focus.|
|Unfocused_Selected|CommonStates|The row is selected and doesn't have focus.|
|InvalidFocused|ValidationStates|The control isn't valid and has focus.|
|InvalidUnfocused|ValidationStates|The control isn't valid and doesn't have focus.|
|Valid|ValidationStates|The control is valid.|

## DataGridRowHeader

The <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element appears at the left side of each row and typically displays row selection indicators or row numbers.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element.

|Part|Type|Description|
|-|-|-|
|PART_TopHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the row header from the top.|
|PART_BottomHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the row header from the bottom.|

### States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the row.|
|MouseOver_CurrentRow|CommonStates|The mouse pointer is positioned over the row and the row is the current row.|
|MouseOver_CurrentRow_Selected|CommonStates|The mouse pointer is positioned over the row, and the row is current and selected.|
|MouseOver_EditingRow|CommonStates|The mouse pointer is positioned over the row and the row is in edit mode.|
|MouseOver_Selected|CommonStates|The mouse pointer is positioned over the row and the row is selected.|
|MouseOver_Unfocused_CurrentRow_Selected|CommonStates|The mouse pointer is positioned over the row, the row is current and selected, and doesn't have focus.|
|MouseOver_Unfocused_EditingRow|CommonStates|The mouse pointer is positioned over the row, the row is in edit mode, and doesn't have focus.|
|MouseOver_Unfocused_Selected|CommonStates|The mouse pointer is positioned over the row, the row is selected, and doesn't have focus.|
|Normal_CurrentRow|CommonStates|The row is the current row.|
|Normal_CurrentRow_Selected|CommonStates|The row is the current row and is selected.|
|Normal_EditingRow|CommonStates|The row is in edit mode.|
|Normal_Selected|CommonStates|The row is selected.|
|Unfocused_CurrentRow_Selected|CommonStates|The row is the current row, is selected, and doesn't have focus.|
|Unfocused_EditingRow|CommonStates|The row is in edit mode and doesn't have focus.|
|Unfocused_Selected|CommonStates|The row is selected and doesn't have focus.|
|InvalidFocused|ValidationStates|The control isn't valid and has focus.|
|InvalidUnfocused|ValidationStates|The control isn't valid and doesn't have focus.|
|Valid|ValidationStates|The control is valid.|

## DataGridColumnHeadersPresenter

The <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element contains all column headers and displays them in a row at the top of the data grid.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element.

|Part|Type|Description|
|-|-|-|
|PART_FillerColumnHeader|<xref:System.Windows.Controls.Primitives.DataGridColumnHeader>|The placeholder for column headers.|

### States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|InvalidFocused|ValidationStates|The cell isn't valid and has focus.|
|InvalidUnfocused|ValidationStates|The cell isn't valid and doesn't have focus.|
|Valid|ValidationStates|The cell is valid.|

## DataGridColumnHeader

The <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element represents the header of a column. Column headers typically display the column title and provide sorting functionality when clicked.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element.

|Part|Type|Description|
|-|-|-|
|PART_LeftHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the column header from the left.|
|PART_RightHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the column header from the right.|

### States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Pressed|CommonStates|The control is pressed.|
|SortAscending|SortStates|The column is sorted in ascending order.|
|SortDescending|SortStates|The column is sorted in descending order.|
|Unsorted|SortStates|The column isn't sorted.|
|InvalidFocused|ValidationStates|The control isn't valid and has focus.|
|InvalidUnfocused|ValidationStates|The control isn't valid and doesn't have focus.|
|Valid|ValidationStates|The control is valid.|

## See also

- [DataGrid](datagrid.md)
- <xref:System.Windows.Controls.DataGrid>
- <xref:System.Windows.Controls.DataGridCell>
- <xref:System.Windows.Controls.DataGridRow>
- <xref:System.Windows.Controls.Primitives.DataGridRowHeader>
- <xref:System.Windows.Controls.Primitives.DataGridColumnHeader>
- <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter>
- [Styling and Templating](styles-templates-overview.md)
- [Creating a template for a control](how-to-create-apply-template.md)
