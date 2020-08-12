---
title: Add and Remove Columns in DataGridView Control Using the Designer
ms.date: "03/30/2017"
f1_keywords:
  - "vs.DataGridViewAddColumnDialog"
helpviewer_keywords:
  - "DataGridView control [Windows Forms], adding columns"
  - "DataGridView control [Windows Forms], removing columns"
ms.assetid: 9e709f35-0a8c-4e7e-b4c4-bacb7a834077
---
# How to: Add and Remove Columns in the Windows Forms DataGridView Control Using the Designer
The Windows Forms <xref:System.Windows.Forms.DataGridView> control must contain columns in order to display data. If you plan to populate the control manually, you must add the columns yourself. Alternately, you can bind the control to a data source, which generates and populates the columns automatically. If the data source contains more columns than you want to display, you can remove the unwanted columns.

 The following procedures require a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGridView> control. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

## To add a column using the designer

1. Click the designer actions glyph (![Small black arrow](./media/designer-actions-glyph.gif)) on the upper-right corner of the <xref:System.Windows.Forms.DataGridView> control, and then select **Add Column**.

2. In the **Add Column** dialog box, choose the **Databound Column** option and select a column from the data source, or choose the **Unbound Column** option and define the column using the fields provided.

3. Click the **Add** button to add the column, causing it to appear in the designer if the existing columns do not already fill the control display area.

    > [!NOTE]
    > You can modify column properties in the **Edit Columns** dialog box, which you can access from the control's smart tag.

## To remove a column using the designer

1. Choose **Edit Columns** from the control's smart tag.

2. Select a column from the **Selected Columns** list.

3. Click the **Remove** button to delete the column, causing it to disappear from the designer.

## See also

- <xref:System.Windows.Forms.DataGridView>
- [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project)
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
