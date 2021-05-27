---
title: Set tab order of controls
description: Learn how to set the tab order of controls on your Windows Forms for .NET. Set the tab order with Visual Studio or using the TabIndex property in the Properties window.
ms.date: 05/24/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "tab order [Windows Forms], controls on Windows forms"
  - "Windows Forms controls, setting tab order"
  - "controls [Windows Forms], setting tab order"
  - "Windows Forms, setting tab order"
---
# How to set the tab order on Windows Forms (Windows Forms .NET)

The tab order is the order in which a user moves focus from one control to another by pressing the <kbd>Tab</kbd> key. Each form has its own tab order. By default, the tab order is the same as the order in which you created the controls. Tab-order numbering begins with zero and ascends in value, and is set with the <xref:System.Windows.Forms.Control.TabIndex%2A> property.

You can also set the tab order by using the [designer](#designer).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

Tab order can be set in the **Properties** window of the designer using the <xref:System.Windows.Forms.Control.TabIndex%2A> property. The `TabIndex` property of a control determines where it's positioned in the tab order. By default, the first control added to the designer has a `TabIndex` value of 0, the second has a `TabIndex` of 1, and so on. Once the highest `TabIndex` has been focused, pressing <kbd>Tab</kbd> will cycle and focus the control with the lowest `TabIndex` value.

Container controls, such as a <xref:System.Windows.Forms.GroupBox> control, treat their children as separate from the rest of the form. Each child in the container has its own <xref:System.Windows.Forms.Control.TabIndex%2A> value. Because a container control can't be focused, when the tab order reaches the container control, the child control of the container with the lowest `TabIndex` is focused. As the <kbd>Tab</kbd> is pressed, each child control is focused according to its `TabIndex` value until the last control. When <kbd>Tab</kbd> is pressed on the last control, focus resumes to the next control in the parent of the container, based on the next `TabIndex` value.

Any control of the many on your form can be skipped in the tab order. Usually, pressing <kbd>Tab</kbd> successively at run time selects each control in the tab order. By turning off the <xref:System.Windows.Forms.Control.TabStop%2A> property, a control is passed over in the tab order of the form.

## Designer

Use the Visual Studio designer **Properties** window to set the tab order of a control.

01. Select the control in the designer.

01. In the **Properties** window in Visual Studio, set the **TabIndex** property of the control to an appropriate number.

    :::image type="content" source="media/how-to-set-the-tab-order/properties-tabindex.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with TabIndex property shown.":::

<!-- This heading goes above: ### Use the Properties window

### Use the Tab Order tool

Visual Studio has a Tab Order tool which works in the Visual Designer. Once started, clicking each control set the tab order in the order in which you click them.

01. In Visual Studio, on the **View** menu, select **Tab Order**.

    This activates the tab-order selection mode on the form. A number (representing the <xref:System.Windows.Forms.Control.TabIndex%2A> property) appears in the upper-left corner of each control.

01. Click the controls sequentially to establish the tab order you want.

    > [!NOTE]
    > A control's place within the tab order can be set to any value greater than or equal to 0. When duplicates occur, the z-order of the two controls is evaluated and the control on top is tabbed to first. (The z-order is the visual layering of controls on a form along the form's z-axis [depth]. The z-order determines which controls are in front of other controls.) For more information on z-order, see [Layering Objects on Windows Forms](how-to-layer-objects-on-windows-forms.md).

01. When you have finished, select **Tab Order** on the **View** menu again to leave tab order mode.

    > [!NOTE]
    > Controls that cannot get the focus, as well as disabled and invisible controls, do not have a <xref:System.Windows.Forms.Control.TabIndex%2A> property and are not included in the tab order. As a user presses the Tab key, these controls are skipped.
-->

## Programmatic

01. Set the `TabIndex` property to a numerical value.

    ```vb
    Button1.TabIndex = 1
    ```

    ```csharp
    Button1.TabIndex = 1;
    ```

## Remove a control from the tab order

You can prevent a control from receiving focus when the <kbd>Tab</kbd> key is pressed, by setting the <xref:System.Windows.Forms.Control.TabStop%2A> property to `false`. The control is skipped when you cycle through the controls with the <kbd>Tab</kbd> key. The control doesn't lose its tab order when this property is set to `false`.

> [!NOTE]
> A radio button group has a single tab stop at run-time. The selected button, the button with its <xref:System.Windows.Forms.RadioButton.Checked%2A> property set to `true`, has its <xref:System.Windows.Forms.Control.TabStop%2A> property automatically set to `true`. Other buttons in the radio button group have their `TabStop` property set to `false`.<!-- LINK For more information about grouping <xref:System.Windows.Forms.RadioButton> controls, see [Grouping Windows Forms RadioButton Controls to Function as a Set](how-to-group-windows-forms-radiobutton-controls-to-function-as-a-set.md). -->

### Set TabStop with the designer

01. Select the control in the designer.

01. In the **Properties** window in Visual Studio, set the **TabStop** property to `False`.

    :::image type="content" source="media/how-to-set-the-tab-order/properties-tabstop.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with TabStop property shown.":::

### Set TabStop programmatically

01. Set the `TabStop` property to `false`.

    ```csharp
    Button1.TabStop = false;
    ```

    ```vb
    Button1.TabStop = False
    ```

## See also

- [Add a control to a form](how-to-add-to-a-form.md)
- <xref:System.Windows.Forms.Control.TabIndex%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.TabStop%2A?displayProperty=fullName>
