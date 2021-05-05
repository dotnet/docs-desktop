---
title: Iterate Through All Nodes of TreeView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "examples [Windows Forms], TreeView control"
  - "TreeView control [Windows Forms], iterating through nodes"
  - "tree nodes in TreeView control [Windows Forms], iterating through"
ms.assetid: 427f8928-ebcf-4beb-887f-695b905d5134
---
# How to: Iterate Through All Nodes of a Windows Forms TreeView Control

It is sometimes useful to examine every node in a Windows Forms <xref:System.Windows.Forms.TreeView> control in order to perform some calculation on the node values. This operation can be done using a recursive procedure (recursive method in C# and C++) that iterates through each node in each collection of the tree.  
  
 Each <xref:System.Windows.Forms.TreeNode> object in a tree view has properties that you can use to navigate the tree view: <xref:System.Windows.Forms.TreeNode.FirstNode%2A>, <xref:System.Windows.Forms.TreeNode.LastNode%2A>, <xref:System.Windows.Forms.TreeNode.NextNode%2A>, <xref:System.Windows.Forms.TreeNode.PrevNode%2A>, and <xref:System.Windows.Forms.TreeNode.Parent%2A>. The value of the <xref:System.Windows.Forms.TreeNode.Parent%2A> property is the parent node of the current node. The child nodes of the current node, if there are any, are listed in its <xref:System.Windows.Forms.TreeNode.Nodes%2A> property. The <xref:System.Windows.Forms.TreeView> control itself has the <xref:System.Windows.Forms.TreeView.TopNode%2A> property, which is the root node of the entire tree view.  
  
## Recursive approach
  
1. Create a recursive procedure (recursive method in C# and C++) that tests each node.  
  
2. Call the procedure.  
  
     The following example shows how to print each <xref:System.Windows.Forms.TreeNode> object's <xref:System.Windows.Forms.TreeNode.Text%2A> property:  
  
    :::code languauge="csharp" source="snippets/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control/cs/Form1.cs" id="PrintRecursive":::
  
    :::code languauge="vb" source="snippets/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control/vb/Form1.vb" id="PrintRecursive":::  
  
    :::code languauge="cpp" source="snippets/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control/cpp/MyForm.h" id="PrintRecursive":::  
  
## Non-recursive approach

Recursive code may lead to stack overflow errors or out of memory exceptions due to there being too many frames on the stack.

The following example is an alternate iterative approach to traversing the nodes of the tree using a <xref:System.Collections.Generic.Queue%601> data structure. This approach does not follow any ordering and only ensures all the nodes are printed. If we wish to follow a pre-order or post-order approach then we can use a <xref:System.Collections.Generic.Stack%601> data structure to ensure that a node and its children are processed before subsequent nodes.

:::code languauge="csharp" source="snippets/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control/cs/Form1.cs" id="PrintNonRecursive":::

:::code languauge="vb" source="snippets/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control/vb/Form1.vb" id="PrintNonRecursive":::

:::code languauge="cpp" source="snippets/how-to-iterate-through-all-nodes-of-a-windows-forms-treeview-control/cpp/MyForm.h" id="PrintNonRecursive":::

## See also

- [TreeView Control](treeview-control-windows-forms.md)
- [Recursive Procedures](/dotnet/visual-basic/programming-guide/language-features/procedures/recursive-procedures)
