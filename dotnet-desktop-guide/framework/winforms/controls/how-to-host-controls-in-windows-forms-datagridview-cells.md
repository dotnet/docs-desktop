---
title: Host Controls in DataGridView Cells
description: Learn how to host controls in Windows Forms DataGridView cells to enable your users to enter and edit values in a variety of ways.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], hosting in cells"
  - "DataGridView control [Windows Forms], hosting controls in cells"
  - "cells [Windows Forms], hosting controls"
ms.assetid: e79a9d4e-64ec-41f5-93ec-f5492633cbb2
---
# How to: Host Controls in Windows Forms DataGridView Cells
The <xref:System.Windows.Forms.DataGridView> control provides several column types, enabling your users to enter and edit values in a variety of ways. If these column types do not meet your data-entry needs, however, you can create your own column types with cells that host controls of your choosing. To do this, you must define classes that derive from <xref:System.Windows.Forms.DataGridViewColumn> and <xref:System.Windows.Forms.DataGridViewCell>. You must also define a class that derives from <xref:System.Windows.Forms.Control> and implements the <xref:System.Windows.Forms.IDataGridViewEditingControl> interface.  
  
 The following code example shows how to create a calendar column. The cells of this column display dates in ordinary text box cells, but when the user edits a cell, a <xref:System.Windows.Forms.DateTimePicker> control appears. In order to avoid having to implement text box display functionality again, the `CalendarCell` class derives from the <xref:System.Windows.Forms.DataGridViewTextBoxCell> class rather than inheriting the <xref:System.Windows.Forms.DataGridViewCell> class directly.  
  
> [!NOTE]
> When you derive from <xref:System.Windows.Forms.DataGridViewCell> or <xref:System.Windows.Forms.DataGridViewColumn> and add new properties to the derived class, be sure to override the `Clone` method to copy the new properties during cloning operations. You should also call the base class's `Clone` method so that the properties of the base class are copied to the new cell or column.  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewCalendarColumn#000](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCalendarColumn/CS/datagridviewcalendarcolumn.cs#000)]
 [!code-vb[System.Windows.Forms.DataGridViewCalendarColumn#000](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewCalendarColumn/VB/datagridviewcalendarcolumn.vb#000)]  
  
## Compiling the Code  
 The following example requires:  
  
- References to the System and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridViewColumn>
- <xref:System.Windows.Forms.DataGridViewCell>
- <xref:System.Windows.Forms.DataGridViewTextBoxCell>
- <xref:System.Windows.Forms.IDataGridViewEditingControl>
- <xref:System.Windows.Forms.DateTimePicker>
- [Customizing the Windows Forms DataGridView Control](customizing-the-windows-forms-datagridview-control.md)
- [DataGridView Control Architecture](datagridview-control-architecture-windows-forms.md)
- [Column Types in the Windows Forms DataGridView Control](column-types-in-the-windows-forms-datagridview-control.md)
