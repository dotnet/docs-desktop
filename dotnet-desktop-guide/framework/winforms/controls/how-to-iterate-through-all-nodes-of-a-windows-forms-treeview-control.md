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
  
    ```vb  
    Private Sub PrintRecursive(ByVal n As TreeNode)  
       System.Diagnostics.Debug.WriteLine(n.Text)  
       MessageBox.Show(n.Text)  
       Dim aNode As TreeNode  
       For Each aNode In n.Nodes  
          PrintRecursive(aNode)  
       Next  
    End Sub  
  
    ' Call the procedure using the top nodes of the treeview.  
    Private Sub CallRecursive(ByVal aTreeView As TreeView)  
       Dim n As TreeNode  
       For Each n In aTreeView.Nodes  
          PrintRecursive(n)  
       Next  
    End Sub  
    ```  
  
    ```csharp  
    private void PrintRecursive(TreeNode treeNode)  
    {  
       // Print the node.  
       System.Diagnostics.Debug.WriteLine(treeNode.Text);  
       MessageBox.Show(treeNode.Text);  
       // Print each node recursively.  
       foreach (TreeNode tn in treeNode.Nodes)  
       {  
          PrintRecursive(tn);  
       }  
    }  
  
    // Call the procedure using the TreeView.  
    private void CallRecursive(TreeView treeView)  
    {  
       // Print each node recursively.  
       TreeNodeCollection nodes = treeView.Nodes;  
       foreach (TreeNode n in nodes)  
       {  
          PrintRecursive(n);  
       }  
    }  
    ```  
  
    ```cpp  
    private:  
       void PrintRecursive( TreeNode^ treeNode )  
       {  
          // Print the node.  
          System::Diagnostics::Debug::WriteLine( treeNode->Text );  
          MessageBox::Show( treeNode->Text );  
  
          // Print each node recursively.  
          System::Collections::IEnumerator^ myNodes = (safe_cast<System::Collections::IEnumerable^>(treeNode->Nodes))->GetEnumerator();  
          try  
          {  
             while ( myNodes->MoveNext() )  
             {  
                TreeNode^ tn = safe_cast<TreeNode^>(myNodes->Current);  
                PrintRecursive( tn );  
             }  
          }  
          finally  
          {  
             IDisposable^ disposable = dynamic_cast<System::IDisposable^>(myNodes);  
             if ( disposable != nullptr )  
                      disposable->Dispose();  
          }  
       }  
  
       // Call the procedure using the TreeView.  
       void CallRecursive( TreeView^ treeView )  
       {  
          // Print each node recursively.  
          TreeNodeCollection^ nodes = treeView->Nodes;  
          System::Collections::IEnumerator^ myNodes = (safe_cast<System::Collections::IEnumerable^>(nodes))->GetEnumerator();  
          try  
          {  
             while ( myNodes->MoveNext() )  
             {  
                TreeNode^ n = safe_cast<TreeNode^>(myNodes->Current);  
                PrintRecursive( n );  
             }  
          }  
          finally  
          {  
             IDisposable^ disposable = dynamic_cast<System::IDisposable^>(myNodes);  
             if ( disposable != nullptr )  
                      disposable->Dispose();  
          }  
       }  
    ```  
  
## Non-recursive approach

Recursive code may lead to stack overflow errors or out of memory exceptions due to there being too many frames on the stack.

The following example is an alternate iterative approach to traversing the nodes of the tree using a <xref:System.Collections.Generic.Queue> data structure. This approach does not follow any ordering and only ensures all the nodes are printed. If we wish to follow a pre-order or post-order approach then we can use a <xref:System.Collections.Generic.Stack> data structure to ensure that a node and its children are processed before subsequent nodes.

```csharp  
private void PrintNodeValues(TreeNode treeNode)
{ 
    if (treeNode != null)
    {
        Queue<TreeNode> staging = new Queue<TreeNode>();
        staging.Enqueue(treeNode);

        while(staging.Count>0)
        {  
            treeNode = staging.Dequeue();
              
            // Print the node.  
            System.Diagnostics.Debug.WriteLine(treeNode.Text);
            MessageBox.Show(treeNode.Text);

            foreach(TreeNode node in treeNode.Nodes)
            {
                staging.Enqueue(node);
            }
        }
    }
}

// Call the procedure using the TreeView.  
private void CallProc(TreeView treeView)
{
    // Print each node.  
    TreeNodeCollection nodes = treeView.Nodes;
    foreach (TreeNode n in nodes)
    {
        PrintNodeValues(n);
    }
}
```

## See also

- [TreeView Control](treeview-control-windows-forms.md)
- [Recursive Procedures](/dotnet/visual-basic/programming-guide/language-features/procedures/recursive-procedures)
