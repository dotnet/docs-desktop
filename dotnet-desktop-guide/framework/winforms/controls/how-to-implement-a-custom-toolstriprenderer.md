---
title: "How to: Implement a Custom ToolStripRenderer"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "toolbars [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
ms.assetid: c66fd3f7-2377-4553-8f1b-006527f08f32
---
# How to: Implement a Custom ToolStripRenderer
You can customize the appearance of a <xref:System.Windows.Forms.ToolStrip> control by implementing a class that derives from <xref:System.Windows.Forms.ToolStripRenderer>. This gives you the flexibility to create an appearance that differs from the appearance provided the <xref:System.Windows.Forms.ToolStripProfessionalRenderer> and <xref:System.Windows.Forms.ToolStripSystemRenderer> classes.  
  
## Example  
 The following code example demonstrates how to implement a custom <xref:System.Windows.Forms.ToolStripRenderer> class. In this example, the `GridStrip` control implements a sliding-tile puzzle, which allows the user to move tiles in a table layout to form an image. A custom <xref:System.Windows.Forms.ToolStrip> control arranges its <xref:System.Windows.Forms.ToolStripButton> controls in a grid layout. The layout contains one empty cell, into which the user can slide an adjacent tile by using a drag-and-drop operation. Tiles that the user can move are highlighted.  
  
 The `GridStripRenderer` class customizes three aspects of the `GridStrip` control's appearance:  
  
- `GridStrip` border  
  
- <xref:System.Windows.Forms.ToolStripButton> border  
  
- <xref:System.Windows.Forms.ToolStripButton> image  
  
 [!code-csharp[System.Windows.Forms.ToolStrip.GridStrip#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.GridStrip/CS/GridStrip.cs#1)]
 [!code-vb[System.Windows.Forms.ToolStrip.GridStrip#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.GridStrip/VB/GridStrip.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.MenuStrip>
- <xref:System.Windows.Forms.ToolStrip>
- <xref:System.Windows.Forms.ToolStripRenderer>
- <xref:System.Windows.Forms.ToolStripProfessionalRenderer>
- <xref:System.Windows.Forms.ToolStripSystemRenderer>
- <xref:System.Windows.Forms.StatusStrip>
- [ToolStrip Control](toolstrip-control-windows-forms.md)
