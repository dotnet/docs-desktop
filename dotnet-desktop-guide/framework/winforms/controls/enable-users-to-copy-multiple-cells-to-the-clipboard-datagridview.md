---
title: Enable Users to Copy Multiple Cells to the Clipboard from DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "cells [Windows Forms], copying to Clipboard"
  - "DataGridView control [Windows Forms], copying multiple cells"
  - "data grids [Windows Forms], copying multiple cells"
  - "Clipboard [Windows Forms], copying multiple cells"
ms.assetid: fd0403b2-d0e3-4ae0-839c-0f737e1eb4a9
---
# How to: Enable Users to Copy Multiple Cells to the Clipboard from the Windows Forms DataGridView Control
When you enable cell copying, you make the data in your <xref:System.Windows.Forms.DataGridView> control easily accessible to other applications through the <xref:System.Windows.Forms.Clipboard>. The values of the selected cells are converted to strings and added to the Clipboard as tab-delimited text values for pasting into applications like Notepad and Excel, and as an HTML-formatted table for pasting into applications like Word.  
  
 You can configure cell copying to copy cell values only, to include row and column header text in the Clipboard data, or to include header text only when users select entire rows or columns.  
  
 Depending on the selection mode, users can select multiple disconnected groups of cells. When a user copies cells to the Clipboard, rows and columns with no selected cells are not copied. All other rows or columns become rows and columns in the table of data copied to the Clipboard. Unselected cells in these rows or columns are copied as blank placeholders to the Clipboard.  
  
### To enable cell copying  
  
- Set the <xref:System.Windows.Forms.DataGridView.ClipboardCopyMode%2A?displayProperty=nameWithType> property.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewClipboardDemo#15](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewClipboardDemo/CS/datagridviewclipboarddemo.cs#15)]
     [!code-vb[System.Windows.Forms.DataGridViewClipboardDemo#15](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewClipboardDemo/VB/datagridviewclipboarddemo.vb#15)]  
  
## Example  
 The following complete code example demonstrates how cells are copied to the Clipboard. This example includes a button that copies the selected cells to the Clipboard using the <xref:System.Windows.Forms.DataGridView.GetClipboardContent%2A?displayProperty=nameWithType> method and displays the Clipboard contents in a text box.  
  
 [!code-csharp[System.Windows.Forms.DataGridViewClipboardDemo#00](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewClipboardDemo/CS/datagridviewclipboarddemo.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewClipboardDemo#00](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewClipboardDemo/VB/datagridviewclipboarddemo.vb#00)]  
  
## Compiling the Code  
 This code requires:  
  
- References to the N:System and N:System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.ClipboardCopyMode%2A>
- <xref:System.Windows.Forms.DataGridView.GetClipboardContent%2A>
- [Selection and Clipboard Use with the Windows Forms DataGridView Control](selection-and-clipboard-use-with-the-windows-forms-datagridview-control.md)
