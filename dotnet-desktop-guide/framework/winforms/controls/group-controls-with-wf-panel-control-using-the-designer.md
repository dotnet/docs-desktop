---
title: Group Controls with Panel Control Using the Designer
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Panel control [Windows Forms], grouping controls"
  - "controls [Windows Forms], grouping"
  - "Windows Forms controls, grouping"
ms.assetid: 7e1cd708-fdb1-49d8-9ca2-5640b276bf2e
---
# How to: Group Controls with the Windows Forms Panel Control Using the Designer
Windows Forms <xref:System.Windows.Forms.Panel> controls are used to group other controls. There are three reasons to group controls. One is visual grouping of related form elements for a clear user interface; another is programmatic grouping, of radio buttons for example; the last is for moving the controls as a unit at design time.

## To create a group of controls

1. Drag a <xref:System.Windows.Forms.Panel> control from the **Windows Forms** tab of the Toolbox onto a form.

2. Add other controls to the panel, drawing each inside the panel.

     If you have existing controls that you want to enclose in a panel, you can select all the controls, cut them to the Clipboard, select the <xref:System.Windows.Forms.Panel> control, and then paste them into the panel. You can also drag them into the panel.

3. (Optional) If you want to add a border to a panel, set its <xref:System.Windows.Forms.BorderStyle> property. There are three choices: <xref:System.Windows.Forms.BorderStyle.Fixed3D>, <xref:System.Windows.Forms.BorderStyle.FixedSingle>, and <xref:System.Windows.Forms.BorderStyle.None>.

## See also

- [Panel Control](panel-control-windows-forms.md)
- [Panel Control Overview](panel-control-overview-windows-forms.md)
- [How to: Set the Background of a Panel](how-to-set-the-background-of-a-windows-forms-panel.md)
