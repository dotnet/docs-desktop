---
title: Display Subitems in Columns with ListView Control
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "list items"
  - "Details view"
  - "ListView control [Windows Forms], adding ListSubItems"
  - "subitems"
ms.assetid: e465f044-cde7-4fd9-a687-788a73a0f554
---
# How to: Display Subitems in Columns with the Windows Forms ListView Control
The Windows Forms <xref:System.Windows.Forms.ListView> control can display additional text, or subitems, for each item in the Details view. The first column displays the item text, for example an employee number. The second, third, and subsequent columns display the first, second, and subsequent associated subitems.  
  
### To add subitems to a list item  
  
1. Add any columns needed. Because the first column will display the item's <xref:System.Windows.Forms.ListView.Text%2A> property, you need one more column than there are subitems. For more information on adding columns, see [How to: Add Columns to the Windows Forms ListView Control](how-to-add-columns-to-the-windows-forms-listview-control.md).  
  
2. Call the <xref:System.Windows.Forms.ListViewItem.ListViewSubItemCollection.Add%2A> method of the collection returned by the <xref:System.Windows.Forms.ListViewItem.SubItems%2A> property of an item. The code example below sets the employee name and department for a list item.  
  
     [!code-csharp[System.Windows.Forms.ListViewLegacyTopics#61](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/CS/Class1.cs#61)]
     [!code-vb[System.Windows.Forms.ListViewLegacyTopics#61](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ListViewLegacyTopics/VB/Class1.vb#61)]  
  
## See also

- [ListView Control Overview](listview-control-overview-windows-forms.md)
- [How to: Add and Remove Items with the Windows Forms ListView Control](how-to-add-and-remove-items-with-the-windows-forms-listview-control.md)
- [How to: Add Columns to the Windows Forms ListView Control](how-to-add-columns-to-the-windows-forms-listview-control.md)
- [How to: Display Icons for the Windows Forms ListView Control](how-to-display-icons-for-the-windows-forms-listview-control.md)
- [How to: Add Custom Information to a TreeView or ListView Control (Windows Forms)](add-custom-information-to-a-treeview-or-listview-control-wf.md)
