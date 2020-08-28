---
title: Freeze Columns in DataGridView Control Using the Designer
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms, columns"
  - "columns [Windows Forms], freezing"
  - "DataGridView control [Windows Forms], column freezing"
  - "data [Windows Forms], displaying"
ms.assetid: 87412dd2-478f-4751-af87-dafc591fc215
---
# How to: Freeze Columns in the Windows Forms DataGridView Control Using the Designer
When users view data displayed in a Windows Forms <xref:System.Windows.Forms.DataGridView> control, they sometimes need to refer to a single column or set of columns frequently. For example, when you display a table of customer information that contains many columns, it is useful for you to display the customer name at all times while enabling other columns to scroll outside the visible region.

 To achieve this behavior, you can freeze columns in the control. When you freeze a column, all the columns to its left (or to its right in right-to-left language scripts) are frozen as well. Frozen columns remain in place while all other columns can scroll. If column reordering is enabled, the frozen columns are treated as a group distinct from the unfrozen columns. Users can reposition columns in either group, but they cannot move a column from one group to the other.

 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

## To freeze a column using the designer

1. Click the designer actions glyph (![Small black arrow](./media/designer-actions-glyph.gif)) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Edit Columns**.

2. Select a column from the **Selected Columns** list.

3. In the **Column Properties** grid, set the <xref:System.Windows.Forms.DataGridViewColumn.Frozen%2A> property to `true`.

    > [!NOTE]
    > You can also freeze a column when adding it by selecting the **Frozen** box in the **Add Column** dialog box.

## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewColumn.Frozen%2A?displayProperty=nameWithType>
- [How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer](add-and-remove-columns-in-the-datagrid-using-the-designer.md)
- [How to: Enable Column Reordering in the Windows Forms DataGridView Control Using the Designer](enable-column-reordering-in-the-datagrid-using-the-designer.md)
- [How to: Display Right-to-Left Text in Windows Forms for Globalization](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/7d3337xw(v=vs.100))
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
