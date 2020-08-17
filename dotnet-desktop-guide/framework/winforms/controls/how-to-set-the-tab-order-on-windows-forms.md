---
title: Set tab order of controls
description: Learn how to set the tab order of controls on your Windows Forms. Set the tab order with Visual Studio or using the TabIndex property in the Properties window.
ms.date: "03/30/2017"
f1_keywords:
  - "TabStop"
  - "TabIndex"
helpviewer_keywords:
  - "tab order [Windows Forms], controls on Windows forms"
  - "Windows Forms controls, setting tab order"
  - "controls [Windows Forms], setting tab order"
  - "Windows Forms, setting tab order"
ms.assetid: 71fa8e76-0472-414b-ad3c-0f90166e0ad7
author: jillre
ms.author: jillfra
manager: jillfra
---
# How to: Set the tab order on Windows Forms

The tab order is the order in which a user moves focus from one control to another by pressing the Tab key. Each form has its own tab order. By default, the tab order is the same as the order in which you created the controls. Tab-order numbering begins with zero.

## To set the tab order of a control

1. In Visual Studio, on the **View** menu, select **Tab Order**.

   This activates the tab-order selection mode on the form. A number (representing the <xref:System.Windows.Forms.Control.TabIndex%2A> property) appears in the upper-left corner of each control.

2. Click the controls sequentially to establish the tab order you want.

   > [!NOTE]
   > A control's place within the tab order can be set to any value greater than or equal to 0. When duplicates occur, the z-order of the two controls is evaluated and the control on top is tabbed to first. (The z-order is the visual layering of controls on a form along the form's z-axis [depth]. The z-order determines which controls are in front of other controls.) For more information on z-order, see [Layering Objects on Windows Forms](how-to-layer-objects-on-windows-forms.md).

3. When you have finished, select **Tab Order** on the **View** menu again to leave tab order mode.

   > [!NOTE]
   > Controls that cannot get the focus, as well as disabled and invisible controls, do not have a <xref:System.Windows.Forms.Control.TabIndex%2A> property and are not included in the tab order. As a user presses the Tab key, these controls are skipped.

Alternatively, tab order can be set in the Properties window using the <xref:System.Windows.Forms.Control.TabIndex%2A> property. The <xref:System.Windows.Forms.Control.TabIndex%2A> property of a control determines where it is positioned in the tab order. By default, the first control drawn has a <xref:System.Windows.Forms.Control.TabIndex%2A> value of 0, the second has a <xref:System.Windows.Forms.Control.TabIndex%2A> of 1, and so on.

Additionally, by default, a <xref:System.Windows.Forms.GroupBox> control has its own <xref:System.Windows.Forms.Control.TabIndex%2A> value, which is a whole number. A <xref:System.Windows.Forms.GroupBox> control itself cannot have focus at run time. Thus, each control within a <xref:System.Windows.Forms.GroupBox> has its own decimal <xref:System.Windows.Forms.Control.TabIndex%2A> value, beginning with .0. Naturally, as the <xref:System.Windows.Forms.Control.TabIndex%2A> of a <xref:System.Windows.Forms.GroupBox> control is incremented, the controls within it will be incremented accordingly. If you changed a <xref:System.Windows.Forms.Control.TabIndex%2A> value from 5 to 6, the <xref:System.Windows.Forms.Control.TabIndex%2A> value of the first control in its group automatically changes to 6.0, and so on.

Finally, any control of the many on your form can be skipped in the tab order. Usually, pressing Tab successively at run time selects each control in the tab order. By turning off the <xref:System.Windows.Forms.Control.TabStop%2A> property, you can make a control be passed over in the tab order of the form.

## To remove a control from the tab order

Set the control's <xref:System.Windows.Forms.Control.TabStop%2A> property to **false** in the **Properties** window.

A control whose <xref:System.Windows.Forms.Control.TabStop%2A> property has been set to `false` still maintains its position in the tab order, even though the control is skipped when you cycle through the controls with the Tab key.

> [!NOTE]
> A radio button group has a single tab stop at run time. The selected button (that is, the button with its <xref:System.Windows.Forms.RadioButton.Checked%2A> property set to `true`) has its <xref:System.Windows.Forms.Control.TabStop%2A> property automatically set to `true`, while the other buttons have their <xref:System.Windows.Forms.Control.TabStop%2A> property set to `false`. For more information about grouping <xref:System.Windows.Forms.RadioButton> controls, see [Grouping Windows Forms RadioButton Controls to Function as a Set](how-to-group-windows-forms-radiobutton-controls-to-function-as-a-set.md).

## See also

- [Windows Forms Controls](index.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)
- [Windows Forms Controls by Function](windows-forms-controls-by-function.md)
