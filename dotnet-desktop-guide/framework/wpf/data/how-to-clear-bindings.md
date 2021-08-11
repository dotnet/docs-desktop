---
title: "How to: Clear Bindings"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "bindings [WPF], clearing"
  - "clearing bindings [WPF]"
  - "data binding [WPF], clearing bindings"
ms.assetid: 73962a93-32a9-4bcd-9240-bcfbb239093a
---
# How to: Clear Bindings
This example shows how to clear bindings from an object.  
  
## Example  
 To clear a binding from an individual property on an object, call <xref:System.Windows.Data.BindingOperations.ClearBinding%2A> as shown in the following example. The following example removes the binding from the <xref:System.Windows.Controls.TextBlock.TextProperty> of *mytext*, a <xref:System.Windows.Controls.TextBlock> object.  
  
 [!code-csharp[CodeOnlyBinding#ClearBinding](~/samples/snippets/csharp/VS_Snippets_Wpf/CodeOnlyBinding/CSharp/binding.cs#clearbinding)]
 [!code-vb[CodeOnlyBinding#ClearBinding](~/samples/snippets/visualbasic/VS_Snippets_Wpf/CodeOnlyBinding/VisualBasic/App.vb#clearbinding)]  
  
 Clearing the binding removes the binding so that the value of the dependency property is changed to whatever it would have been without the binding. This value could be a default value, an inherited value, or a value from a data template binding.  
  
 To clear bindings from all possible properties on an object, use <xref:System.Windows.Data.BindingOperations.ClearAllBindings%2A>.  
  
## See also

- <xref:System.Windows.Data.BindingOperations>
- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
