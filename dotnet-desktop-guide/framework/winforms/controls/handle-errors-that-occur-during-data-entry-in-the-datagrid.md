---
title: Handle Errors That Occur During Data Entry in DataGridView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "error handling [Windows Forms], dataGridView control"
  - "data grids [Windows Forms], error handling"
  - "DataGridView control [Windows Forms], error handling"
  - "data entry [Windows Forms], error handling"
  - "error handling [Windows Forms], data entry"
ms.assetid: 9004e72f-fdec-4264-a37d-2c99764efc13
---
# How to: Handle Errors That Occur During Data Entry in the Windows Forms DataGridView Control
The following code example demonstrates how to use the <xref:System.Windows.Forms.DataGridView> control to report data entry errors to the user.  
  
 For a complete explanation of this code example, see [Walkthrough: Handling Errors that Occur During Data Entry in the Windows Forms DataGridView Control](handling-errors-that-occur-during-data-entry-in-the-datagrid.md).  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridView.DataError#00](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.DataError/CS/errorhandling.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridView.DataError#00](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.DataError/VB/errorhandling.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Windows.Forms, and System.XML assemblies.  
  
## .NET Framework Security  
 Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../data/adonet/protecting-connection-information.md).  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [Walkthrough: Handling Errors that Occur During Data Entry in the Windows Forms DataGridView Control](handling-errors-that-occur-during-data-entry-in-the-datagrid.md)
- [Data Entry in the Windows Forms DataGridView Control](data-entry-in-the-windows-forms-datagridview-control.md)
- [Walkthrough: Validating Data in the Windows Forms DataGridView Control](walkthrough-validating-data-in-the-windows-forms-datagridview-control.md)
- [Protecting Connection Information](../../data/adonet/protecting-connection-information.md)
