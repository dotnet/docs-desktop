---
title: Programmatically Resize Cells to Fit Content in DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "data grids [Windows Forms], resizing cells to fit content"
  - "cells [Windows Forms], resizing to fit contents"
  - "DataGridView control [Windows Forms], resizing cells"
  - "grids [Windows Forms], resizing cells to fit content"
ms.assetid: 63d770dc-b3f5-462b-901a-3125b2753792
---
# How to: Programmatically Resize Cells to Fit Content in the Windows Forms DataGridView Control
You can use the <xref:System.Windows.Forms.DataGridView> control methods to resize rows, columns, and headers so that they display their entire values without truncation. You can use these methods to resize <xref:System.Windows.Forms.DataGridView> elements at times of your choosing. Alternately, you can configure the control to resize these elements automatically whenever content changes. This can be inefficient, however, when you are working with large data sets or when your data changes frequently. For more information, see [Sizing Options in the Windows Forms DataGridView Control](sizing-options-in-the-windows-forms-datagridview-control.md).  
  
 Typically, you will programmatically adjust <xref:System.Windows.Forms.DataGridView> elements to fit their content only when you load new data from a data source or when the user has edited a value. This is useful to optimize performance, but it is also useful when you want to enable your users to manually resize rows and columns with the mouse.  
  
 The following code example demonstrates the options available to you for programmatic resizing.  
  
## Example  
 [!code-cpp[System.Windows.Forms.DataGridView.ProgrammaticResizing#0](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.ProgrammaticResizing/CPP/programmaticsizing.cpp#0)]
 [!code-csharp[System.Windows.Forms.DataGridView.ProgrammaticResizing#0](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.ProgrammaticResizing/CS/programmaticsizing.cs#0)]
 [!code-vb[System.Windows.Forms.DataGridView.ProgrammaticResizing#0](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.ProgrammaticResizing/VB/programmaticsizing.vb#0)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing, and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.AutoResizeColumn%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.AutoResizeColumnHeadersHeight%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.AutoResizeRow%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.AutoResizeRows%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.AutoResizeRowHeadersWidth%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridViewAutoSizeRowMode>
- <xref:System.Windows.Forms.DataGridViewAutoSizeRowsMode>
- <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode>
- <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode>
- <xref:System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode>
- <xref:System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode>
- [Resizing Columns and Rows in the Windows Forms DataGridView Control](resizing-columns-and-rows-in-the-windows-forms-datagridview-control.md)
- [Sizing Options in the Windows Forms DataGridView Control](sizing-options-in-the-windows-forms-datagridview-control.md)
- [How to: Automatically Resize Cells When Content Changes in the Windows Forms DataGridView Control](automatically-resize-cells-when-content-changes-in-the-datagrid.md)
