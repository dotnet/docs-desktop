---
title: Group RadioButton Controls to Function as a Set
description: Learn how to how to group Windows Forms RadioButton controls to function independently of other sets.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "radio buttons [Windows Forms], grouping"
  - "controls [Windows Forms], grouping"
  - "Windows Forms controls, grouping"
  - "RadioButton control [Windows Forms], grouping"
ms.assetid: 58f8fe34-50b7-49d8-a2be-c271be3c6b32
---
# How to: Group Windows Forms RadioButton Controls to Function as a Set
Windows Forms <xref:System.Windows.Forms.RadioButton> controls are designed to give users a choice among two or more settings, of which only one can be assigned to a procedure or object. For example, a group of <xref:System.Windows.Forms.RadioButton> controls may display a choice of package carriers for an order, but only one of the carriers will be used. Therefore only one <xref:System.Windows.Forms.RadioButton> at a time can be selected, even if it is a part of a functional group.  
  
 You group radio buttons by drawing them inside a container such as a <xref:System.Windows.Forms.Panel> control, a <xref:System.Windows.Forms.GroupBox> control, or a form. All radio buttons that are added directly to a form become one group. To add separate groups, you must place them inside panels or group boxes. For more information about panels or group boxes, see [Panel Control Overview](panel-control-overview-windows-forms.md) or [GroupBox Control Overview](groupbox-control-overview-windows-forms.md).  
  
### To group RadioButton controls as a set to function independently of other sets  
  
1. Drag a <xref:System.Windows.Forms.GroupBox> or <xref:System.Windows.Forms.Panel> control from the **Windows Forms** tab on the **Toolbox** onto the form.  
  
2. Draw <xref:System.Windows.Forms.RadioButton> controls on the <xref:System.Windows.Forms.GroupBox> or <xref:System.Windows.Forms.Panel> control.  
  
## See also

- <xref:System.Windows.Forms.RadioButton>
- [RadioButton Control Overview](radiobutton-control-overview-windows-forms.md)
- [Panel Control Overview](panel-control-overview-windows-forms.md)
- [GroupBox Control Overview](groupbox-control-overview-windows-forms.md)
- [CheckBox Control Overview](checkbox-control-overview-windows-forms.md)
- [RadioButton Control](radiobutton-control-windows-forms.md)
