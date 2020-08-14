---
title: Access Specific Items in ComboBox, ListBox, or CheckedListBox Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "ComboBox control [Windows Forms], accessing items"
  - "ListBox control [Windows Forms], returning item information"
  - "list boxes [Windows Forms], accessing items"
  - "ListBox control [Windows Forms], accessing items"
  - "combo boxes [Windows Forms], accessing items"
  - "CheckedListBox control [Windows Forms], accessing items"
ms.assetid: 1216742f-bcf9-4ff8-8a62-d7c9053c2b96
---
# How to: Access Specific Items in a Windows Forms ComboBox, ListBox, or CheckedListBox Control
Accessing specific items in a Windows Forms combo box, list box, or checked list box is an essential task. It enables you to programmatically determine what is in a list, at any given position.  
  
### To access a specific item  
  
1. Query the `Items` collection using the index of the specific item:  
  
    ```vb  
    Private Function GetItemText(i As Integer) As String  
       ' Return the text of the item using the index:  
       Return ComboBox1.Items(i).ToString  
    End Function  
    ```  
  
    ```csharp  
    private string GetItemText(int i)  
    {  
       // Return the text of the item using the index:  
       return (comboBox1.Items[i].ToString());  
    }  
    ```  
  
    ```cpp  
    private:  
       String^ GetItemText(int i)  
       {  
          // Return the text of the item using the index:  
          return (comboBox1->Items->Item[i]->ToString());  
       }  
    ```  
  
## See also

- <xref:System.Windows.Forms.ComboBox>
- <xref:System.Windows.Forms.ListBox>
- <xref:System.Windows.Forms.CheckedListBox>
- [Windows Forms Controls Used to List Options](windows-forms-controls-used-to-list-options.md)
