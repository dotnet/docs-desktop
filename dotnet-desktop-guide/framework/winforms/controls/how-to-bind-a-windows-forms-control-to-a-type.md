---
title: Bind Control to a Type
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], binding to a type"
  - "BindingSource component [Windows Forms], binding to a type"
  - "types [Windows Forms], binding controls to"
ms.assetid: 94faeebb-d2bc-45d6-86d7-96a42661b43d
---
# How to: Bind a Windows Forms Control to a Type
When you are building controls that interact with data, you will sometimes find it necessary to bind a control to a type, rather than an object. This situation arises especially at design time, when data may not be available, but your data-bound controls still need to display information from a type's public interface. For example, you may bind a <xref:System.Windows.Forms.DataGridView> control to an object exposed by a Web service and want the <xref:System.Windows.Forms.DataGridView> control to label its columns at design time with the member names of a custom type.  
  
 You can easily bind a control to a type with the <xref:System.Windows.Forms.BindingSource> component.  
  
## Example  
 The following code example demonstrates how to bind a <xref:System.Windows.Forms.DataGridView> control to a custom type by using a <xref:System.Windows.Forms.BindingSource> component. When you run the example, you'll notice the <xref:System.Windows.Forms.DataGridView> has labeled columns that reflect the properties of a `Customer` object, before the control is populated with data. The example has an Add Customer button to add data to the <xref:System.Windows.Forms.DataGridView> control. When you click the button, a new `Customer` object is added to the <xref:System.Windows.Forms.BindingSource>. In a real-world scenario, the data might be obtained by a call to a Web service or other data source.  
  
 [!code-csharp[System.Windows.Forms.DataConnector.BindingToType#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.BindingToType/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.DataConnector.BindingToType#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.BindingToType/VB/form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.BindingNavigator>
- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [BindingSource Component](bindingsource-component.md)
