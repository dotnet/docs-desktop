---
title: "How to: Edit Columns and Rows in a TableLayoutPanel Control"
description: Learn how to use the Column and Row Styles dialog box to edit the rows and columns of your Windows Forms controls.
ms.date: "03/30/2017"
f1_keywords:
  - "net.ComponentModel.StyleCollectionEditor"
helpviewer_keywords:
  - "columns [Windows Forms], editing"
  - "TableLayoutPanel control [Windows Forms], editing"
  - "rows [Windows Forms], editing"
ms.assetid: c367ed43-40dc-49eb-9e0f-ba70e83dfec0
---
# How to: Edit Columns and Rows in a TableLayoutPanel Control

You can use the collection editor of the <xref:System.Windows.Forms.TableLayoutPanel> control, called the **Column and Row Styles** dialog box, to edit the rows and columns of your controls.

> [!NOTE]
> If you want a control to span multiple rows or columns, set the `RowSpan` and `ColumnSpan` properties on the control. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md).
>
> If you want to align a control within a cell, or if you want a control to stretch within a cell, use the control's <xref:System.Windows.Forms.Control.Anchor%2A> property. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md).

## To edit rows and columns

1. Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.

2. Click the <xref:System.Windows.Forms.TableLayoutPanel> control's designer actions glyph (![Small black arrow](./media/designer-actions-glyph.gif)) and select **Edit Rows and Columns** to open the **Column and Row Styles** dialog box. You can also right click on the <xref:System.Windows.Forms.TableLayoutPanel> control and select **Edit Rows and Columns** from the shortcut menu.

3. To add or remove columns, select **Columns** from the **Member type** drop-down list box.

4. To add or remove rows, select **Rows** from the **Member type** drop-down list box.

5. Click the **Add** button to add a row or column to the end of the **Member** list.

6. Click the **Insert** button to add a row or column before the currently selected item in the list.

7. If you are adding a row or column, select the **Size Type** for the new row or column. For more information, see <xref:System.Windows.Forms.SizeType>.

8. To remove a row or column, click the **Remove** button to delete the currently selected item in the **Member** list.

## See also

- <xref:System.Windows.Forms.SizeType>
- [TableLayoutPanel Control](tablelayoutpanel-control-windows-forms.md)
