---
title: "How to: Share Bound Data Across Forms Using the BindingSource Component"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "examples [Windows Forms], BindingSource component"
  - "data binding [Windows Forms], sharing data across forms"
  - "BindingSource component [Windows Forms], examples"
  - "BindingSource [Windows Forms], using with multiple forms"
ms.assetid: a1a49630-db9c-4485-b888-1f62a373a4f7
---
# How to: Share Bound Data Across Forms Using the BindingSource Component
You can easily share data across forms using the <xref:System.Windows.Forms.BindingSource> component. For example, you may want to display one read-only form that summarizes the data-source data and another editable form that contains detailed information about the currently selected item in the data source. This example demonstrates this scenario.  
  
## Example  
 The following code example demonstrates how to share a <xref:System.Windows.Forms.BindingSource> and its bound data across forms. In this example, the shared <xref:System.Windows.Forms.BindingSource> is passed to the constructor of the child form. The child form allows the user to edit the data for the currently selected item in the main form.  
  
> [!NOTE]
> The <xref:System.Windows.Forms.BindingSource.BindingComplete> event for the <xref:System.Windows.Forms.BindingSource> component is handled in the example to ensure that the two forms remain synchronized. For more information about why this is done, see [How to: Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized](../multiple-controls-bound-to-data-source-synchronized.md).  
  
 [!code-csharp[System.Windows.Forms.BindingSourceMultipleForms#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BindingSourceMultipleForms/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.BindingSourceMultipleForms#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BindingSourceMultipleForms/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Windows.Forms, System.Drawing, System.Data, and System.Xml assemblies.  
  
## See also

- [BindingSource Component](bindingsource-component.md)
- [Windows Forms Data Binding](../windows-forms-data-binding.md)
- [How to: Handle Errors and Exceptions that Occur with Databinding](how-to-handle-errors-and-exceptions-that-occur-with-databinding.md)
