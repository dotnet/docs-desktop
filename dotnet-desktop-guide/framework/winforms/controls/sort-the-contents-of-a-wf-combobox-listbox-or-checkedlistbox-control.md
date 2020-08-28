---
title: Sort the Contents of ComboBox, ListBox, or CheckedListBox Control
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "CheckedListBox control [Windows Forms], sorting"
  - "ComboBox control [Windows Forms], sorting contents"
  - "combo boxes [Windows Forms], sorting contents"
  - "list boxes [Windows Forms], sorting contents"
  - "ListBox control [Windows Forms], sorting contents"
ms.assetid: c268e387-3d1d-4d86-a940-19f6673c8d06
---
# How to: Sort the Contents of a Windows Forms ComboBox, ListBox, or CheckedListBox Control
Windows Forms controls do not sort when they are data-bound. To display sorted data, use a data source that supports sorting and then have the data source sort it. Data sources that support sorting are data views, data view managers, and sorted arrays.  
  
 If the control is not data-bound, you can sort it.  
  
### To sort the list  
  
1. Set the `Sorted` property to `true`.  
  
     This setting repositions all existing list items in sorted order.  
  
## See also

- <xref:System.Windows.Forms.ComboBox>
- <xref:System.Windows.Forms.ListBox>
- <xref:System.Windows.Forms.CheckedListBox>
- [Windows Forms Data Binding](../windows-forms-data-binding.md)
- [How to: Add and Remove Items from a Windows Forms ComboBox, ListBox, or CheckedListBox Control](add-and-remove-items-from-a-wf-combobox.md)
- [When to Use a Windows Forms ComboBox Instead of a ListBox](when-to-use-a-windows-forms-combobox-instead-of-a-listbox.md)
- [Windows Forms Controls Used to List Options](windows-forms-controls-used-to-list-options.md)
