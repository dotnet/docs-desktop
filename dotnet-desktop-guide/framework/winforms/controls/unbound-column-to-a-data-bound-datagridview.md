---
title: Add an Unbound Column to a Data-Bound DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "columns [Windows Forms], unbound data"
  - "data grids [Windows Forms], adding unbound columns"
  - "DataGridView control [Windows Forms], unbound data"
ms.assetid: f7bdc4d8-ba8e-421b-ad62-82d936f01372
---
# How to: Add an Unbound Column to a Data-Bound Windows Forms DataGridView Control
The data you display in the <xref:System.Windows.Forms.DataGridView> control will normally come from a data source of some kind, but you might want to display a column of data that does not come from the data source. This kind of column is called an unbound column. Unbound columns can take many forms. Frequently, they are used to provide access to the details of a data row.  
  
 The following code example demonstrates how to create an unbound column of **Details** buttons to display a child table related to a particular row in a parent table when you implement a master/detail scenario. To respond to button clicks, implement a <xref:System.Windows.Forms.DataGridView.CellClick?displayProperty=nameWithType> event handler that displays a form containing the child table.  
  
 There is support for this task in Visual Studio.  Also see [How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer](add-and-remove-columns-in-the-datagrid-using-the-designer.md).  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewMisc#010](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#010)]
 [!code-vb[System.Windows.Forms.DataGridViewMisc#010](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#010)]  
  
## Compiling the Code  
 This example requires:  
  
- A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1`.  
  
- References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- [Displaying Data in the Windows Forms DataGridView Control](displaying-data-in-the-windows-forms-datagridview-control.md)
- [Data Display Modes in the Windows Forms DataGridView Control](data-display-modes-in-the-windows-forms-datagridview-control.md)
