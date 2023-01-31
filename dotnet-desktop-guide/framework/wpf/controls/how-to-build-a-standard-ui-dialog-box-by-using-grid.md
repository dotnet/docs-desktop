---
title: "How to: Build a Standard UI Dialog Box by Using Grid"
description: Learn how to build or create a standard user interface (UI) dialog box by using the Grid element via code examples in C# and Visual Basic.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dialog boxes [WPF], creating"
  - "Grid control [WPF], creating [WPF], dialog box"
ms.assetid: d6ac3d51-844b-4d29-96d8-81a696a7b960
---
# How to: Build a Standard UI Dialog Box by Using Grid

This example shows how to create a standard user interface (UI) dialog box by using the <xref:System.Windows.Controls.Grid> element.  
  
## Example  

 The following example creates a dialog box like the **Run** dialog box in the Windows operating system.  
  
 The example creates a <xref:System.Windows.Controls.Grid> and uses the <xref:System.Windows.Controls.ColumnDefinition> and <xref:System.Windows.Controls.RowDefinition> classes to define five columns and four rows.  
  
 The example then adds and positions an <xref:System.Windows.Controls.Image>, `RunIcon.png`, to represent the image that is found in the dialog box. The image is placed in the first column and row of the <xref:System.Windows.Controls.Grid> (the upper-left corner).  
  
 Next, the example adds a <xref:System.Windows.Controls.TextBlock> element to the first column, which spans the remaining columns of the first row. It adds another <xref:System.Windows.Controls.TextBlock> element to the second row in the first column, to represent the **Open** text box. A <xref:System.Windows.Controls.TextBlock> follows, which represents the data entry area.  
  
 Finally, the example adds three <xref:System.Windows.Controls.Button> elements to the final row, which represent the **OK**, **Cancel**, and **Browse** events.  
  
 [!code-csharp[GridRunDialog#1](~/samples/snippets/csharp/VS_Snippets_Wpf/GridRunDialog/CSharp/window1.xaml.cs#1)]
 [!code-vb[GridRunDialog#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/GridRunDialog/VisualBasic/grid_vb.vb#1)]  
  
## See also

- <xref:System.Windows.Controls.Grid>
- <xref:System.Windows.GridUnitType>
- [Panels Overview](panels-overview.md)
- [How-to Topics](grid-how-to-topics.md)
