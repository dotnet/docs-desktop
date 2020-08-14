---
title: Group Controls with GroupBox Control
description: Learn how to group controls with the Windows Forms GroupBox control so that you can create a visual grouping of related elements.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "controls [Windows Forms], grouping"
  - "GroupBox control [Windows Forms], grouping controls"
  - "Windows Forms controls, grouping"
ms.assetid: 0bda316d-bd2a-43aa-ac73-342453303169
---
# How to: Group Controls with the Windows Forms GroupBox Control
Windows Forms <xref:System.Windows.Forms.GroupBox> controls are used to group other controls. There are three reasons to group controls:  
  
- To create a visual grouping of related form elements for a clear user interface.  
  
- To create programmatic grouping (of radio buttons, for example).  
  
- For moving the controls as a unit at design time.  
  
### To create a group of controls  
  
1. Draw a <xref:System.Windows.Forms.GroupBox> control on a form.  
  
2. Add other controls to the group box, drawing each inside the group box.  
  
     If you have existing controls that you want to enclose in a group box, you can select all the controls, cut them to the Clipboard, select the <xref:System.Windows.Forms.GroupBox> control, and then paste them into the group box. You can also drag them into the group box.  
  
3. Set the <xref:System.Windows.Forms.GroupBox.Text%2A> property of the group box to an appropriate caption.  
  
## See also

- <xref:System.Windows.Forms.GroupBox>
- [GroupBox Control](groupbox-control-windows-forms.md)
