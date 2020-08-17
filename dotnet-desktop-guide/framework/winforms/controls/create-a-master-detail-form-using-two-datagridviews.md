---
title: Create a Master-Detail Form Using Two DataGridView Controls
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], master/detail form"
  - "parent-child tables [Windows Forms], displaying on Windows Forms"
  - "master-details lists [Windows Forms], creating"
ms.assetid: 99f6e876-3f7f-4139-9063-e36587c95b02
---
# How to: Create a Master/Detail Form Using Two Windows Forms DataGridView Controls
The following code example creates a master/detail form using two <xref:System.Windows.Forms.DataGridView> controls bound to two <xref:System.Windows.Forms.BindingSource> components. The data source is a <xref:System.Data.DataSet> that contains the `Customers` and `Orders` tables from the Northwind SQL Server sample database along with a <xref:System.Data.DataRelation> that relates the two through the `CustomerID` column.  
  
 One <xref:System.Windows.Forms.BindingSource> is bound to the parent `Customers` table in the data set. This data is displayed in the master <xref:System.Windows.Forms.DataGridView> control. The other <xref:System.Windows.Forms.BindingSource> is bound to the first data connector. The <xref:System.Windows.Forms.BindingSource.DataMember%2A> property of the second <xref:System.Windows.Forms.BindingSource> is set to the <xref:System.Data.DataRelation> name. This causes the associated detail <xref:System.Windows.Forms.DataGridView> control to display the rows of the child `Orders` table that correspond to the current row in the master <xref:System.Windows.Forms.DataGridView> control.  
  
 For a complete explanation of this code example, see [Walkthrough: Creating a Master/Detail Form Using Two Windows Forms DataGridView Controls](creating-a-master-detail-form-using-two-datagridviews.md).  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewMasterDetails#00](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/CS/masterdetails.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewMasterDetails#00](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/VB/masterdetails.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
 References to the System, System.Data, System.Windows.Forms, and System.XML assemblies.  
  
## .NET Framework Security  
 Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../data/adonet/protecting-connection-information.md).  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [Walkthrough: Creating a Master/Detail Form Using Two Windows Forms DataGridView Controls](creating-a-master-detail-form-using-two-datagridviews.md)
- [Displaying Data in the Windows Forms DataGridView Control](displaying-data-in-the-windows-forms-datagridview-control.md)
- [Protecting Connection Information](../../data/adonet/protecting-connection-information.md)
