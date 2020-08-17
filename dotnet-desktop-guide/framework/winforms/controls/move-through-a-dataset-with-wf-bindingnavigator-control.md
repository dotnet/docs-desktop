---
title: Move Through a DataSet with BindingNavigator Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "datasets [Windows Forms], moving through"
  - "BindingNavigator control [Windows Forms], moving through datasets"
  - "examples [Windows Forms], BindingNavigator control"
ms.assetid: 146d97be-3d97-400e-accb-860bbf47729d
---
# How to: Move Through a DataSet with the Windows Forms BindingNavigator Control
As you build data-driven applications, you will often need to display collections of data to users. The <xref:System.Windows.Forms.BindingNavigator> control, in conjunction with the <xref:System.Windows.Forms.BindingSource> component, provides a convenient and extensible solution for moving through a collection and displaying items sequentially.  
  
## Example  
 The following code example demonstrates how to use a <xref:System.Windows.Forms.BindingNavigator> control to move through data. The set is contained in a <xref:System.Data.DataView>, which is bound to a <xref:System.Windows.Forms.TextBox> control with a <xref:System.Windows.Forms.BindingSource> component.  
  
> [!NOTE]
> Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../data/adonet/protecting-connection-information.md).  
  
 [!code-csharp[System.Windows.Forms.DataNavigator#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataNavigator/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.DataNavigator#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataNavigator/VB/form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Drawing, System.Windows.Forms and System.Xml assemblies.  
  
## See also

- <xref:System.Windows.Forms.BindingSource>
- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [BindingNavigator Control](bindingnavigator-control-windows-forms.md)
- [BindingSource Component](bindingsource-component.md)
- [How to: Bind a Windows Forms Control to a Type](how-to-bind-a-windows-forms-control-to-a-type.md)
