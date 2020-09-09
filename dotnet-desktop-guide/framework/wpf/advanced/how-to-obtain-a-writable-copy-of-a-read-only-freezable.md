---
title: "How to: Obtain a Writable Copy of a Read-Only Freezable"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "cloning Freezable objects [WPF]"
  - "Freezable objects [WPF], modifiable clones"
ms.assetid: d028de61-bbe9-4d62-b656-8fe3b1b2ca24
---
# How to: Obtain a Writable Copy of a Read-Only Freezable
This example shows how to use the <xref:System.Windows.Freezable.Clone%2A> method to create a writable copy of a read-only <xref:System.Windows.Freezable>.  
  
 After a <xref:System.Windows.Freezable> object is marked as read-only ("frozen"), you cannot modify it. However, you can use the <xref:System.Windows.Freezable.Clone%2A> method to create a modifiable clone of the frozen object.  
  
## Example  
 The following example creates a modifiable clone of a frozen <xref:System.Windows.Media.SolidColorBrush> object.  
  
 [!code-csharp[freezablesample_procedural#CloneExample](~/samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#cloneexample)]
 [!code-vb[freezablesample_procedural#CloneExample](~/samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#cloneexample)]  
  
 For more information about <xref:System.Windows.Freezable> objects, see the [Freezable Objects Overview](freezable-objects-overview.md).  
  
## See also

- <xref:System.Windows.Freezable>
- <xref:System.Windows.Freezable.CloneCurrentValue%2A>
- [Freezable Objects Overview](freezable-objects-overview.md)
- [How-to Topics](base-elements-how-to-topics.md)
