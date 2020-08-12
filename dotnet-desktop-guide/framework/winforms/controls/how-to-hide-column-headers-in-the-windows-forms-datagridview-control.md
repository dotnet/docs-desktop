---
title: Hide Column Headers in DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "columns [Windows Forms], hiding column headers"
  - "column headers [Windows Forms], hiding"
  - "DataGridView control [Windows Forms], column headers"
ms.assetid: e4ad5f68-50d2-4b9e-93ee-9d622423a8ab
---
# How to: Hide Column Headers in the Windows Forms DataGridView Control
Sometimes you will want to display a <xref:System.Windows.Forms.DataGridView> without column headers. In the <xref:System.Windows.Forms.DataGridView> control, the <xref:System.Windows.Forms.DataGridView.ColumnHeadersVisible%2A> property value determines whether the column headers are displayed.  
  
### To hide the column headers  
  
- Set the <xref:System.Windows.Forms.DataGridView.ColumnHeadersVisible%2A?displayProperty=nameWithType> property to `false`.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMisc#062](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/CS/datagridviewmisc.cs#062)]
     [!code-vb[System.Windows.Forms.DataGridViewMisc#062](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMisc/VB/datagridviewmisc.vb#062)]  
  
## Compiling the Code  
 This example requires:  
  
- A <xref:System.Windows.Forms.DataGridView> control named `dataGridView1`.  
  
- References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.ColumnHeadersVisible%2A?displayProperty=nameWithType>
- [Basic Column, Row, and Cell Features in the Windows Forms DataGridView Control](basic-column-row-and-cell-features-wf-datagridview-control.md)
