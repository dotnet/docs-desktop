---
title: Reflect Data Source Updates in Control with BindingSource
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "data binding [Windows Forms], updating"
  - "BindingSource component [Windows Forms], updating data binding"
  - "examples [Windows Forms], BindingSource component"
  - "data sources [Windows Forms], updating"
  - "BindingSource component [Windows Forms], examples"
ms.assetid: bd8bd9b2-af8a-4f11-a3d5-54eecbe2400b
---
# How to: Reflect Data Source Updates in a Windows Forms Control with the BindingSource
When you use data-bound controls, you sometimes have to respond to changes in the data source when the data source does not raise list-changed events. When you use the <xref:System.Windows.Forms.BindingSource> component to bind your data source to a Windows Forms control, you can notify the control that your data source has changed by calling the <xref:System.Windows.Forms.BindingSource.ResetBindings%2A> method.  
  
## Example  
 The following code example demonstrates using the <xref:System.Windows.Forms.BindingSource.ResetBindings%2A> method to notify a bound control about an update in the data source.  
  
 [!code-cpp[System.Windows.Forms.DataConnector.ResetBindings#1](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.ResetBindings/CPP/form1.cpp#1)]
 [!code-csharp[System.Windows.Forms.DataConnector.ResetBindings#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.ResetBindings/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.DataConnector.ResetBindings#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataConnector.ResetBindings/VB/form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.BindingNavigator>
- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [BindingSource Component](bindingsource-component.md)
- [How to: Bind a Windows Forms Control to a Type](how-to-bind-a-windows-forms-control-to-a-type.md)
