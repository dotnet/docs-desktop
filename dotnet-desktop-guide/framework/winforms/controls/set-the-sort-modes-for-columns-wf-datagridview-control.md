---
title: Set the Sort Modes for Columns in DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "sorting [Windows Forms], data grids"
  - "DataGridView control [Windows Forms], sort mode"
  - "data grids [Windows Forms], sorting data"
ms.assetid: 57dfed60-a608-40d5-86f9-d65686ffb325
---
# How to: Set the Sort Modes for Columns in the Windows Forms DataGridView Control
In the <xref:System.Windows.Forms.DataGridView> control, text box columns use automatic sorting by default, while other column types are not sorted automatically. Sometimes you will want to override these defaults. For example, you can display images in place of text, numbers, or enumeration cell values. While the images cannot be sorted, the underlying values that they represent can be sorted.  
  
 In the <xref:System.Windows.Forms.DataGridView> control, the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> property value of a column determines its sorting behavior.  
  
 The following procedure shows the `Priority` column from [How to: Customize Data Formatting in the Windows Forms DataGridView Control](how-to-customize-data-formatting-in-the-windows-forms-datagridview-control.md). This column is an image column and is not sortable by default. It contains actual cell values that are strings, however, so it can be sorted automatically.  
  
### To set the sort mode for a column  
  
- Set the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A?displayProperty=nameWithType> property.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#066](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#066)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#066](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#066)]  
  
## Compiling the Code  
 This example requires:  
  
- A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1` that contains a column named `Priority`.  
  
- References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A?displayProperty=nameWithType>
- [Sorting Data in the Windows Forms DataGridView Control](sorting-data-in-the-windows-forms-datagridview-control.md)
- [Column Sort Modes in the Windows Forms DataGridView Control](column-sort-modes-in-the-windows-forms-datagridview-control.md)
- [How to: Customize Sorting in the Windows Forms DataGridView Control](how-to-customize-sorting-in-the-windows-forms-datagridview-control.md)
