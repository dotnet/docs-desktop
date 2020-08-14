---
title: "How to: Create a Professionally Styled ToolStrip Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "toolbars [Windows Forms]"
  - "ToolStripProfessionalRenderer class [Windows Forms]"
  - "ToolStripRenderer class [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
ms.assetid: c208b2f6-8105-474b-9075-d582e1792870
---
# How to: Create a Professionally Styled ToolStrip Control
You can give your application’s <xref:System.Windows.Forms.ToolStrip> controls a professional appearance and behavior (look and feel) by writing your own class derived from the <xref:System.Windows.Forms.ToolStripProfessionalRenderer> type.  
  
 There is extensive support for this feature in Visual Studio.  
  
 See [Walkthrough: Creating a Professionally Styled ToolStrip Control](walkthrough-creating-a-professionally-styled-toolstrip-control.md).  
  
## Example  
 The following code example demonstrates how to use <xref:System.Windows.Forms.ToolStrip> controls to create a composite control that mimics the **Navigation Pane** provided by Microsoft® Outlook®.  
  
 [!code-csharp[System.Windows.Forms.ToolStrip.StackView#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#1)]
 [!code-vb[System.Windows.Forms.ToolStrip.StackView#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.MenuStrip>
- <xref:System.Windows.Forms.ToolStrip>
- <xref:System.Windows.Forms.StatusStrip>
- [ToolStrip Control](toolstrip-control-windows-forms.md)
- [How to: Provide Standard Menu Items to a Form](how-to-provide-standard-menu-items-to-a-form.md)
