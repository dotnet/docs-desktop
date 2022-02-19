---
title: Keyboard and mouse behavior in DataGridView control
description: Describes how the keyboard and mouse interacts with the DataGridView control in Windows Forms, including accessibility keyboard shortcuts.
ms.date: "02/08/2022"
helpviewer_keywords: 
  - "data grids [Windows Forms], mouse handling"
  - "DataGridView control [Windows Forms], navigation keys"
  - "keyboards [Windows Forms], default handling in DataGridView control"
  - "DataGridView control [Windows Forms], keyboard handling"
  - "mouse [Windows Forms], default handling in DataGridView control"
  - "DataGridView control [Windows Forms], mouse handling"
  - "navigation keys [Windows Forms], DataGridView control"
ms.assetid: 4519b928-bfc8-4e8b-bb9c-b1e76a0ca552
---
# Default keyboard and mouse behavior with the DataGridView control

The following tables describe how users can interact with the <xref:System.Windows.Forms.DataGridView> control through a keyboard and a mouse.  
  
> [!NOTE]
> To customize keyboard behavior, you can handle standard keyboard events such as <xref:System.Windows.Forms.Control.KeyDown>. In edit mode, however, the hosted editing control receives the keyboard input and the keyboard events do not occur for the <xref:System.Windows.Forms.DataGridView> control. To handle editing control events, attach your handlers to the editing control in an <xref:System.Windows.Forms.DataGridView.EditingControlShowing> event handler. Alternatively, you can customize keyboard behavior in a <xref:System.Windows.Forms.DataGridView> subclass by overriding the <xref:System.Windows.Forms.DataGridView.ProcessDialogKey%2A> and <xref:System.Windows.Forms.DataGridView.ProcessDataGridViewKey%2A> methods.  
  
## Default keyboard handling  
  
### Basic navigation and entry keys  
  
| Key or key combination                              | Description                                                                                                      |
|-----------------------------------------------------|------------------------------------------------------------------------------------------------------------------|
| <kbd>Down arrow</kbd>                               | Moves the focus to the cell directly below the current cell. If the focus is in the last row, does nothing.      |
| <kbd>Left arrow</kbd>                               | Moves the focus to the previous cell in the row. If the focus is in the first cell in the row, does nothing.     |
| <kbd>Right arrow</kbd>                              | Moves the focus to the next cell in the row. If the focus is in the last cell in the row, does nothing.          |
| <kbd>Up arrow</kbd>                                 | Moves the focus to the cell directly above the current cell. If the focus is in the first row, does nothing.     |
| <kbd>Home</kbd>                                     | Moves the focus to the first cell in the current row.                                                            |
| <kbd>End</kbd>                                      | Moves the focus to the last cell in the current row.                                                             |
| <kbd>Page down</kbd>                                | Scrolls the control downward by the number of rows that are fully displayed. Moves the focus to the last fully displayed row without changing columns.                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| <kbd>Page up</kbd>                                  | Scrolls the control upward by the number of rows that are fully displayed. Moves focus to the first displayed row without changing columns.                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| <kbd>Tab</kbd>                                      | If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `false`, moves the focus to the next cell in the current row. If the focus is already in the last cell of the row, moves the focus to the first cell in the next row. If the focus is in the last cell in the control, moves the focus to the next control in the tab order of the parent container.<br /><br /> If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `true`, moves the focus to the next control in the tab order of the parent container.                  |
| <kbd>Shift</kbd> + <kbd>Tab</kbd>                   | If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `false`, moves the focus to the previous cell in the current row. If the focus is already in the first cell of the row, moves the focus to the last cell in the previous row. If the focus is in the first cell in the control, moves the focus to the previous control in the tab order of the parent container.<br /><br /> If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `true`, moves the focus to the previous control in the tab order of the parent container. |
| <kbd>Ctrl</kbd> + <kbd>Tab</kbd>                    | If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `false`, moves the focus to the next control in the tab order of the parent container.<br /><br /> If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `true`, moves the focus to the next cell in the current row. If the focus is already in the last cell of the row, moves the focus to the first cell in the next row. If the focus is in the last cell in the control, moves the focus to the next control in the tab order of the parent container.                  |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Tab</kbd> | If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `false`, moves the focus to the previous control in the tab order of the parent container.<br /><br /> If the <xref:System.Windows.Forms.DataGridView.StandardTab%2A> property value is `true`, moves the focus to the previous cell in the current row. If the focus is already in the first cell of the row, moves the focus to the last cell in the previous row. If the focus is in the first cell in the control, moves the focus to the previous control in the tab order of the parent container. |
| <kbd>Ctrl</kbd> + <kbd>arrow</kbd>                  | Moves the focus to the farthest cell in the direction of the arrow.                                              |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd>                   | Moves the focus to the first cell in the control.                                                                |
| <kbd>Ctrl</kbd> + <kbd>End</kbd>                    | Moves the focus to the last cell in the control.                                                                 |
| <kbd>Ctrl</kbd> + <kbd>Page down/up</kbd>           | Same as <kbd>Page down</kbd> or <kbd>Page up</kbd>.                                                              |
| <kbd>F2</kbd>                                       | Puts the current cell into cell edit mode if the <xref:System.Windows.Forms.DataGridView.EditMode%2A> property value is <xref:System.Windows.Forms.DataGridViewEditMode.EditOnF2> or <xref:System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2>.                                                                                                                                                                                                                                                                                                                                |
| <kbd>F3</kbd>                                       | Sorts the current column if the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A?displayProperty=nameWithType> property value is <xref:System.Windows.Forms.DataGridViewColumnSortMode.Automatic>. It's the same as clicking the current column header. Available since .NET Framework 4.7.2. To enable this feature, applications must target .NET Framework 4.7.2 or later versions or explicitly opt into accessibility improvements using AppContext switches.                                                                                                               |
| <kbd>F4</kbd>                                       | If the current cell is a <xref:System.Windows.Forms.DataGridViewComboBoxCell>, puts the cell into edit mode and displays the drop-down list.                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| <kbd>Alt</kbd> + <kbd>Up/Down arrow</kbd>           | If the current cell is a <xref:System.Windows.Forms.DataGridViewComboBoxCell>, puts the cell into edit mode and displays the drop-down list.                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| <kbd>Alt</kbd> + <kbd>Left/Right arrow</kbd>        | Increases or decreases the width of the current cell's column.                                                   |
| <kbd>Space</kbd>                                    | If the current cell is a <xref:System.Windows.Forms.DataGridViewButtonCell>, <xref:System.Windows.Forms.DataGridViewLinkCell>, or <xref:System.Windows.Forms.DataGridViewCheckBoxCell>, raises the <xref:System.Windows.Forms.DataGridView.CellClick> and <xref:System.Windows.Forms.DataGridView.CellContentClick> events. If the current cell is a <xref:System.Windows.Forms.DataGridViewButtonCell>, also presses the button. If the current cell is a <xref:System.Windows.Forms.DataGridViewCheckBoxCell>, also changes the check state.                                            |
| <kbd>Enter</kbd>                                    | Commits any changes to the current cell and row and moves the focus to the cell directly below the current cell. If the focus is in the last row, commits any changes without moving the focus.                                                                                                                                                                                                                                                                                                                                                                                           |
| <kbd>Esc</kbd>                                      | If the control is in edit mode, cancels the edit. If the control is not in edit mode, reverts any changes that have been made to the current row if the control is bound to a data source that supports editing or virtual mode has been implemented with row-level commit scope.                                                                                                                                                                                                                                                                                                         |
| <kbd>Backspace</kbd>                                | Deletes the character before the insertion point when editing a cell.                                            |
| <kbd>Delete</kbd>                                   | Deletes the character after the insertion point when editing a cell.                                             |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd>                  | Commits any changes to the current cell without moving the focus. Also commits any changes to the current row if the control is bound to a data source that supports editing or virtual mode has been implemented with row-level commit scope.                                                                                                                                                                                                                                                                                                                                            |
| <kbd>Ctrl</kbd> + <kbd>0</kbd>                      | Enters a <xref:System.DBNull.Value?displayProperty=nameWithType> value into the current cell if the cell can be edited. By default, the display value for a <xref:System.DBNull> cell value is the value of the <xref:System.Windows.Forms.DataGridViewCellStyle.NullValue%2A> property of the <xref:System.Windows.Forms.DataGridViewCellStyle> in effect for the current cell.                                                                                                                                                                                                          |

### Selection keys

 If the <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> property is set to `false` and the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> property is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.CellSelect>, changing the current cell by using the navigation keys changes the selection to the new cell. The <kbd>Shift</kbd>, <kbd>Ctrl</kbd>, and <kbd>Alt</kbd> keys do not affect this behavior.  
  
 If the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect>, the same behavior occurs but with the following additions.  
  
| Key or key combination                                                                          | Description                                                                                                                                                                |
|-------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <kbd>Shift</kbd> + <kbd>Spacebar</kbd>                                                          | Selects the full row or column (the same as clicking the row or column header).                                                                                            |
| navigation key (<kbd>arrow key</kbd>, <kbd>Page up/down</kbd>, <kbd>Home</kbd>, <kbd>End</kbd>) | If a full row or column is selected, changing the current cell to a new row or column moves the selection to the full new row or column (depending on the selection mode). |
  
 If <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> is set to `false` and <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect>, changing the current cell to a new row or column by using the keyboard moves the selection to the full new row or column. The <kbd>Shift</kbd>, <kbd>Ctrl</kbd>, and <kbd>Alt</kbd> keys do not affect this behavior.  
  
 If <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> is set to `true`, the navigation behavior does not change, but navigating with the keyboard while pressing <kbd>Shift</kbd> (including <kbd>Ctrl</kbd> + <kbd>Shift</kbd>) will modify a multi-cell selection. Before navigation begins, the control marks the current cell as an anchor cell. When you navigate while pressing <kbd>Shift</kbd>, the selection includes all cells between the anchor cell and the current cell. Other cells in the control will remain selected if they were already selected, but they may become unselected if the keyboard navigation temporarily puts them between the anchor cell and the current cell.  
  
 If <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> is set to `true` and <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect>, the behavior of the anchor cell and current cell is the same, but only full rows or columns become selected or unselected.  
  
## Default mouse handling
  
### Basic mouse handling
  
> [!NOTE]
> Clicking a cell with the left mouse button always changes the current cell. Clicking a cell with the right mouse button opens a shortcut menu, when one is available.  
  
| Mouse action                                             | Description                                                                                                                                                                                 |
|----------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Left mouse button down                                   | Makes the clicked cell the current cell, and raises the <xref:System.Windows.Forms.DataGridView.CellMouseDown?displayProperty=nameWithType> event.                                          |
| Left mouse button up                                     | Raises the <xref:System.Windows.Forms.DataGridView.CellMouseUp?displayProperty=nameWithType> event                                                                                          |
| Left mouse button click                                  | Raises the <xref:System.Windows.Forms.DataGridView.CellClick?displayProperty=nameWithType> and <xref:System.Windows.Forms.DataGridView.CellMouseClick?displayProperty=nameWithType> events  |
| Left mouse button down, and drag on a column header cell | If the <xref:System.Windows.Forms.DataGridView.AllowUserToOrderColumns%2A?displayProperty=nameWithType> property is `true`, moves the column so that it can be dropped into a new position. |
  
### Mouse selection

 No selection behavior is associated with the middle mouse button or the mouse wheel.  
  
 If the <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> property is set to `false` and the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> property is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.CellSelect>, the following behavior occurs.  
  
| Mouse action | Description                                                                                                               |
|--------------|---------------------------------------------------------------------------------------------------------------------------|
| Click        | Selects only the current cell if the user clicks a cell. No selection behavior if the user clicks a row or column header. |
| Right-click  | Displays a shortcut menu if one is available.                                                                             |
  
 The same behavior occurs when the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect>, except that, depending on the selection mode, clicking a row or column header will select the full row or column and set the current cell to the first cell in the row or column.  
  
 If <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect>, clicking any cell in a row or column will select the full row or column.  
  
 If <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> is set to `true`, clicking a cell while pressing <kbd>Ctrl</kbd> or <kbd>Shift</kbd> will modify a multi-cell selection.  
  
 When you click a cell while pressing <kbd>Ctrl</kbd>, the cell will change its selection state while all other cells retain their current selection state.  
  
 When you click a cell or a series of cells while pressing <kbd>Shift</kbd>, the selection includes all cells between the current cell and an anchor cell located at the position of the current cell before the first click. When you click and drag the pointer across multiple cells, the anchor cell is the cell clicked at the beginning of the drag operation. Subsequent clicks while pressing <kbd>Shift</kbd> change the current cell, but not the anchor cell. Other cells in the control will remain selected if they were already selected, but they may become unselected if mouse navigation temporarily puts them between the anchor cell and the current cell.  
  
 If <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> is set to `true` and <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect>, clicking a row or column header (depending on the selection mode) while pressing <kbd>Shift</kbd> will modify an existing selection of full rows or columns if such a selection exists. Otherwise, it will clear the selection and start a new selection of full rows or columns. Clicking a row or column header while pressing <kbd>Ctrl</kbd>, however, will add or remove the clicked row or column from the current selection without otherwise modifying the current selection.  
  
 If <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> is set to `true` and <xref:System.Windows.Forms.DataGridView.SelectionMode%2A> is set to <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect> or <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect>, clicking a cell while pressing <kbd>Shift</kbd> or <kbd>Ctrl</kbd> behaves the same way except that only full rows and columns are affected.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- [DataGridView Control](datagridview-control-windows-forms.md)
