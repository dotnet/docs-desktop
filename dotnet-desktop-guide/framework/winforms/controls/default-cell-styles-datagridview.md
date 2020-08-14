---
title: Set Default Cell Styles and Data Formats for DataGridView Control Using the Designer
ms.date: "03/30/2017"
helpviewer_keywords:
  - "DataGridView control [Windows Forms], cell styles"
  - "cells [Windows Forms], setting styles"
  - "data formats"
  - "data [Windows Forms], setting formats"
ms.assetid: fc6da49f-8942-41da-b49f-b2afc38cc656
---
# How to: Set Default Cell Styles and Data Formats for the Windows Forms DataGridView Control Using the Designer

The <xref:System.Windows.Forms.DataGridView> control lets you specify default cell styles and cell data formats for the entire control, for specific columns, for row and column headers, and for alternating rows to create a ledger effect. Default styles set for the entire control are overridden by default styles set for columns and alternating rows. Additionally, styles that you set in code for individual rows and cells override the default styles.

For more information about cell styles, see [Cell Styles in the Windows Forms DataGridView Control](cell-styles-in-the-windows-forms-datagridview-control.md). To set styles for alternating rows, see [How to: Set Alternating Row Styles for the Windows Forms DataGridView Control Using the Designer](set-alternating-row-styles-for-the-datagrid-using-the-designer.md).

You can also set styles using the <xref:System.Windows.Forms.DataGridView.RowTemplate%2A> property to affect all rows that will be added to the control. For more information about the row template, see [How to: Use the Row Template to Customize Rows in the Windows Forms DataGridView Control](use-the-row-template-to-customize-rows-in-the-datagrid.md).

The following procedures require a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

### To set default styles for all cells in the control

1. Select the <xref:System.Windows.Forms.DataGridView> control in the designer.

2. In the **Properties** window, click the ellipsis button (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) next to the <xref:System.Windows.Forms.DataGridView.DefaultCellStyle%2A>, <xref:System.Windows.Forms.DataGridView.ColumnHeadersDefaultCellStyle%2A>, or <xref:System.Windows.Forms.DataGridView.RowHeadersDefaultCellStyle%2A> property. The **CellStyle Builder** dialog box appears.

3. Define the style by setting the properties, using the **Preview** pane to confirm your choices.

> [!NOTE]
> If visual styles are enabled, the row and column headers (except for the <xref:System.Windows.Forms.DataGridView.TopLeftHeaderCell%2A>) are automatically styled by the current theme, overriding the <xref:System.Windows.Forms.DataGridView.ColumnHeadersDefaultCellStyle%2A> and <xref:System.Windows.Forms.DataGridView.RowHeadersDefaultCellStyle%2A> property values.
>
> You can set cell styles for multiple selected <xref:System.Windows.Forms.DataGridView> controls using the designer, but only if they have identical values for the cell style property you want to modify. If any cell styles differ for that property, the **Properties** windows of the **CellStyle Builder** dialog box will be blank.

### To set default styles for cells in individual columns

1. Right-click the <xref:System.Windows.Forms.DataGridView> control in the designer and choose **Edit Columns**.

2. Select a column from the **Selected Columns** list.

3. In the **Column Properties** grid, click the ellipsis button (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) next to the <xref:System.Windows.Forms.DataGridViewColumn.DefaultCellStyle%2A> property. The **CellStyle Builder** dialog box appears.

4. Define the style by setting the properties, using the **Preview** pane to confirm your choices.

### To format data in cells

1. Use one of the preceding procedures to display a **CellStyle Builder** dialog box related to a default cell style property.

2. In the **CellStyle Builder** dialog box, click the ellipsis button (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) next to the <xref:System.Windows.Forms.DataGridViewCellStyle.Format%2A> property. The **Format String** dialog box appears.

3. Select a format type, then modify the details of the type (such as the number of decimal places to display), using the **Sample** box to confirm your choices.

4. If you are binding the <xref:System.Windows.Forms.DataGridView> control to a data source that is likely to contain null values, fill in the **Null Value** text box. This value is displayed when the cell value is equal to a null reference (`Nothing` in Visual Basic) or <xref:System.DBNull.Value?displayProperty=nameWithType>.

## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewCellStyle>
- <xref:System.Windows.Forms.DataGridView.DefaultCellStyle%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.RowsDefaultCellStyle%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridViewColumn.DefaultCellStyle%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridViewCellStyle.Format%2A?displayProperty=nameWithType>
- [Cell Styles in the Windows Forms DataGridView Control](cell-styles-in-the-windows-forms-datagridview-control.md)
- [How to: Set Alternating Row Styles for the Windows Forms DataGridView Control Using the Designer](set-alternating-row-styles-for-the-datagrid-using-the-designer.md)
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
