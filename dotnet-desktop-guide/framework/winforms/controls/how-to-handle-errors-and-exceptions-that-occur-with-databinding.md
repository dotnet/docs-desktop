---
title: "How to: Handle Errors and Exceptions that Occur with Databinding"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "error handling [Windows Forms], examples"
  - "data binding [Windows Forms], examples"
  - "examples [Windows Forms], error handling"
  - "error handling [Windows Forms], data binding"
  - "data binding [Windows Forms], error handling"
  - "BindingSource component [Windows Forms], handling errors and exceptions"
ms.assetid: eddc5bad-9513-47df-ab28-f02d8dff7892
---
# How to: Handle Errors and Exceptions that Occur with Databinding
Oftentimes exceptions and errors occur on the underlying business objects when you bind them to controls. You can intercept these errors and exceptions and then either recover or pass the error information to the user by handling the <xref:System.Windows.Forms.Binding.BindingComplete> event for a particular <xref:System.Windows.Forms.Binding>, <xref:System.Windows.Forms.BindingSource>, or <xref:System.Windows.Forms.CurrencyManager> component.  
  
## Example  
 This code example demonstrates how to handle errors and exceptions that occur during a data-binding operation. It demonstrates how to intercept errors by handling the <xref:System.Windows.Forms.Binding.BindingComplete?displayProperty=nameWithType> event of the <xref:System.Windows.Forms.Binding> objects. In order to intercept errors and exceptions by handling this event, you must enable formatting for the binding. You can enable formatting when the binding is constructed or added to the binding collection, or by setting the <xref:System.Windows.Forms.Binding.FormattingEnabled%2A> property to `true`.  
  
 [!code-cpp[System.Windows.Forms.DataConnectorBindingComplete#3](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataConnectorBindingComplete/CPP/form1.cpp#3)]
 [!code-csharp[System.Windows.Forms.DataConnectorBindingComplete#3](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataConnectorBindingComplete/CS/form1.cs#3)]
 [!code-vb[System.Windows.Forms.DataConnectorBindingComplete#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataConnectorBindingComplete/VB/form1.vb#3)]  
  
 When the code is running and an empty string is entered for the part name or a value less than 100 is entered for the part number, a message box appears. This is a result of handling the <xref:System.Windows.Forms.Binding.BindingComplete?displayProperty=nameWithType> event for these textbox bindings.  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.Binding.BindingComplete?displayProperty=nameWithType>
- <xref:System.Windows.Forms.BindingSource.BindingComplete?displayProperty=nameWithType>
- [BindingSource Component](bindingsource-component.md)
