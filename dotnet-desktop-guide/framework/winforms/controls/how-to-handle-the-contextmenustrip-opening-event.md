---
title: "How to: Handle the ContextMenuStrip Opening Event"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ContextMenuStrip control [Windows Forms]"
  - "context menus [Windows Forms], event handling"
  - "ToolStrip control [Windows Forms]"
  - "event handling [Windows Forms], context menus"
  - "shortcut menus [Windows Forms], event handling"
ms.assetid: b661b3dd-7815-4cc2-a1aa-a9a391ab3427
---
# How to: Handle the ContextMenuStrip Opening Event
You can customize the behavior of your <xref:System.Windows.Forms.ContextMenuStrip> control by handling the <xref:System.Windows.Forms.ToolStripDropDown.Opening> event.  
  
## Example  
 The following code example demonstrates how to handle the <xref:System.Windows.Forms.ToolStripDropDown.Opening> event. The event handler adds items dynamically to a <xref:System.Windows.Forms.ContextMenuStrip> control. For the complete code example, see [How to: Add ToolStrip Items Dynamically](how-to-add-toolstrip-items-dynamically.md).  
  
 [!code-csharp[System.Windows.Forms.ToolStrip.Misc#42](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.Misc/CS/Program.cs#42)]
 [!code-vb[System.Windows.Forms.ToolStrip.Misc#42](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.Misc/VB/Program.vb#42)]  
  
 Set the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A?displayProperty=nameWithType> property to `true` to prevent the menu from opening.  
  
## See also

- <xref:System.Windows.Forms.ContextMenuStrip>
- <xref:System.ComponentModel.CancelEventArgs.Cancel%2A>
- <xref:System.Windows.Forms.ToolStripDropDown>
- [ToolStrip Control](toolstrip-control-windows-forms.md)
