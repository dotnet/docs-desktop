---
title: Customize Data Formatting in DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], formatting data"
  - "DataGridView control [Windows Forms], cell styles"
  - "cells [Windows Forms], changing colors in DataGridView control [Windows Forms]"
  - "colors [Windows Forms], changing in DataGridView control [Windows Forms]"
  - "data [Windows Forms], formatting in DataGridView control"
  - "DataGridView control [Windows Forms], cell customization"
  - "DataGridView control [Windows Forms], changing cell colors"
  - "Windows Forms, changing colors of DataGridView cells"
  - "DataGridView control [Windows Forms], substituting cell values for display"
  - "data grids [Windows Forms], formatting data"
ms.assetid: a6e72c70-ce18-425f-828d-d57be6f96ab6
---
# How to: Customize Data Formatting in the Windows Forms DataGridView Control
The following code example demonstrates how to implement a handler for the <xref:System.Windows.Forms.DataGridView.CellFormatting?displayProperty=nameWithType> event that changes how cells are displayed depending on their columns and values.  
  
 Cells in the `Balance` column that contain negative numbers are given a red background. You can also format these cells as currency to display parentheses around negative values. For more information, see [How to: Format Data in the Windows Forms DataGridView Control](how-to-format-data-in-the-windows-forms-datagridview-control.md).  
  
 Cells in the `Priority` column display images in place of corresponding textual cell values. The <xref:System.Windows.Forms.ConvertEventArgs.Value%2A> property of the <xref:System.Windows.Forms.DataGridViewCellFormattingEventArgs> is used both to get the textual cell value and to set the corresponding image display value.  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewCustomizeDataFormatting#00](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCustomizeDataFormatting/cs/customFormatting.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewCustomizeDataFormatting#00](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCustomizeDataFormatting/vb/customFormatting.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing, and System.Windows.Forms assemblies.  
  
- <xref:System.Drawing.Bitmap> images named `highPri.bmp`, `mediumPri.bmp`, and `lowPri.bmp` residing in the same directory as the executable file.  
  
## See also

- <xref:System.Windows.Forms.DataGridView.DefaultCellStyle%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridViewBand.DefaultCellStyle%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewCellStyle>
- <xref:System.Drawing.Bitmap>
- [Displaying Data in the Windows Forms DataGridView Control](displaying-data-in-the-windows-forms-datagridview-control.md)
- [How to: Format Data in the Windows Forms DataGridView Control](how-to-format-data-in-the-windows-forms-datagridview-control.md)
- [Cell Styles in the Windows Forms DataGridView Control](cell-styles-in-the-windows-forms-datagridview-control.md)
- [Data Formatting in the Windows Forms DataGridView Control](data-formatting-in-the-windows-forms-datagridview-control.md)
