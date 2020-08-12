---
title: "How to: Enable Check Margins and Image Margins in ContextMenuStrip Controls"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "toolbars [Windows Forms]"
  - "ShowCheckMargin property [Windows Forms]"
  - "ShowImageMargin property [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
  - "MenuStrip control [Windows Forms]"
ms.assetid: eb584e71-59da-4012-aaca-dbe1c7c7a156
---
# How to: Enable Check Margins and Image Margins in ContextMenuStrip Controls
You can customize the <xref:System.Windows.Forms.ToolStripMenuItem> objects in your <xref:System.Windows.Forms.MenuStrip> control with check marks and custom images.  
  
## Example  
 The following code example demonstrates how to create menu items that have check marks and custom images.  
  
 [!code-csharp[System.Windows.Forms.ToolStrip.Misc#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.Misc/CS/Program.cs#1)]
 [!code-vb[System.Windows.Forms.ToolStrip.Misc#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.Misc/VB/Program.vb#1)]  
[!code-csharp[System.Windows.Forms.ToolStrip.Misc#60](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.Misc/CS/Program.cs#60)]
[!code-vb[System.Windows.Forms.ToolStrip.Misc#60](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.Misc/VB/Program.vb#60)]  
  
 Set the <xref:System.Windows.Forms.ToolStripDropDownMenu.ShowCheckMargin%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.ToolStripDropDownMenu.ShowImageMargin%2A?displayProperty=nameWithType> properties to specify when check marks and custom images appear in your menu items.  
  
## Compiling the Code  
 This example requires:  
  
- References to the System.Design, System.Drawing, and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.ToolStripMenuItem>
- <xref:System.Windows.Forms.ToolStripDropDownMenu>
- <xref:System.Windows.Forms.MenuStrip>
- <xref:System.Windows.Forms.ToolStrip>
- [ToolStrip Control](toolstrip-control-windows-forms.md)
