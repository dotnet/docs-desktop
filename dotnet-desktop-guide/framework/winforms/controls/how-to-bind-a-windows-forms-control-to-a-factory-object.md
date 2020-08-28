---
title: Bind Control to a Factory Object
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "controls [Windows Forms], binding"
  - "factory objects [Windows Forms], binding to"
  - "BindingSource component [Windows Forms], binding to a factory object"
  - "BindingSource component [Windows Forms], examples"
ms.assetid: 7d59af89-ff82-41d8-a48a-f1fbae788b0d
---
# How to: Bind a Windows Forms Control to a Factory Object
When you are building controls that interact with data, you will sometimes find it necessary to bind a control to an object or method that generates other objects. Such an object or method is called a factory. Your data source might be, for example, the return value from a method call, instead of an object in memory or a type. You can bind a control to this kind of data source as long as the source returns a collection.  
  
 You can easily bind a control to a factory object by using the <xref:System.Windows.Forms.BindingSource> control.  
  
## Example  
 The following example demonstrates how to bind a <xref:System.Windows.Forms.DataGridView> control to a factory method by using a <xref:System.Windows.Forms.BindingSource> control. The factory method is named `GetOrdersByCustomerId`, and it returns all the orders for a given customer in the Northwind database.  
  
 [!code-cpp[System.Windows.Forms.DataConnector.BindToFactory#1](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.BindToFactory/CPP/form1.cpp#1)]
 [!code-csharp[System.Windows.Forms.DataConnector.BindToFactory#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.BindToFactory/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.DataConnector.BindToFactory#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.BindToFactory/VB/form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.BindingNavigator>
- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [BindingSource Component](bindingsource-component.md)
- [How to: Bind a Windows Forms Control to a Type](how-to-bind-a-windows-forms-control-to-a-type.md)
