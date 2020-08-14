---
title: "DomainUpDown Control Overview"
ms.date: "03/30/2017"
f1_keywords: 
  - "DomainUpDown"
helpviewer_keywords: 
  - "spin button control [Windows Forms], about spin button"
  - "DomainUpDown control [Windows Forms], about DomainUpDown control"
ms.assetid: 3f40f9c1-20ad-4331-b9b5-b0127eb36eb3
---
# DomainUpDown Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.DomainUpDown> control is essentially a combination of a text box and a pair of buttons for moving up or down through a list. The control displays and sets a text string from a list of choices. The user can select the string by clicking up and down buttons to move through a list, by pressing the UP and DOWN ARROW keys, or by typing a string that matches an item in the list. One possible use for this control is for selecting items from an alphabetically sorted list of names.  
  
> [!NOTE]
> To sort the list, set the <xref:System.Windows.Forms.DomainUpDown.Sorted%2A> property to `true`.  
  
 The function of this control is very similar to the list box or combo box, but it takes up very little space.  
  
## Key Properties  
 The key properties of the control are <xref:System.Windows.Forms.DomainUpDown.Items%2A>, <xref:System.Windows.Forms.UpDownBase.ReadOnly%2A>, and <xref:System.Windows.Forms.DomainUpDown.Wrap%2A>. The <xref:System.Windows.Forms.DomainUpDown.Items%2A> property contains the list of objects whose text values are displayed in the control. If <xref:System.Windows.Forms.UpDownBase.ReadOnly%2A> is set to `false`, the control automatically completes text that the user types and matches it to a value in the list. If <xref:System.Windows.Forms.DomainUpDown.Wrap%2A> is set to `true`, scrolling past the last item will take you to the first item in the list and vice versa. The key methods of the control are <xref:System.Windows.Forms.DomainUpDown.UpButton%2A> and <xref:System.Windows.Forms.DomainUpDown.DownButton%2A>.  
  
 This control displays only text strings. If you want a control that displays numeric values, use the <xref:System.Windows.Forms.NumericUpDown> control. For more information, see [NumericUpDown Control Overview](numericupdown-control-overview-windows-forms.md).  
  
## See also

- <xref:System.Windows.Forms.DomainUpDown>
- [DomainUpDown Control](domainupdown-control-windows-forms.md)
