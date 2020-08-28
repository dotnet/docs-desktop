---
title: Enable Column Reordering in DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], column order"
  - "data grids [Windows Forms], reordering columns"
  - "columns [Windows Forms], reordering"
ms.assetid: cc20eae3-e4db-493f-95ce-a4215e29472a
---
# How to: Enable Column Reordering in the Windows Forms DataGridView Control
When you enable column reordering in the <xref:System.Windows.Forms.DataGridView> control, users can move a column to a new position by dragging the column header with the mouse. In the <xref:System.Windows.Forms.DataGridView> control, the <xref:System.Windows.Forms.DataGridView.AllowUserToOrderColumns%2A?displayProperty=nameWithType> property value determines whether users can move columns to different positions.  
  
 There is support for this task in Visual Studio.  Also see [How to: Enable Column Reordering in the Windows Forms DataGridView Control Using the Designer](enable-column-reordering-in-the-datagrid-using-the-designer.md).  
  
### To enable column reordering programmatically  
  
- Set the <xref:System.Windows.Forms.DataGridView.AllowUserToOrderColumns%2A?displayProperty=nameWithType> property to `true`.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#060](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#060)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#060](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#060)]  
  
## Compiling the Code  
 This example requires:  
  
- A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1`.  
  
- References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.AllowUserToOrderColumns%2A?displayProperty=nameWithType>
- [Basic Column, Row, and Cell Features in the Windows Forms DataGridView Control](basic-column-row-and-cell-features-wf-datagridview-control.md)
- [How to: Freeze Columns in the Windows Forms DataGridView Control](how-to-freeze-columns-in-the-windows-forms-datagridview-control.md)
