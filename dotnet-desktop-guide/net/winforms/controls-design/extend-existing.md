---
title: Customize an existing control
description: Learn how to inherit from existing controls so that another control has all of its functionality and visual properties.
ms.date: 04/24/2023
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "inheritance [Windows Forms], Windows Forms custom controls"
  - "custom controls [Windows Forms], inheritance"
---
# Extend an existing control

If you want to add more features to an existing control, you can create a control that inherits from an existing control. The new control contains all of the capabilities and visual aspect of the base control, but gives you opportunity to extend it. For example, if you created a control that inherits <xref:System.Windows.Forms.Button>, your new control would look and act exactly like a button. You could create new methods and properties to customize the behavior of the control. Some controls allow you to override the <xref:System.Windows.Forms.Control.OnPaint%2A> method to change the way the control looks.

## Add a custom control to a project

After creating a new project, use the Visual Studio templates to create a user control. The following steps demonstrate how to add a user control to your project:

01. In Visual Studio, find the **Project Explorer** pane. Right-click on the project and choose **Add** > **User Control (Windows Forms)**.

    :::image type="content" source="media/extend-existing/right-click.png" alt-text="Right-click the Visual Studio solution explorer to add a user control to a Windows Forms project":::

01. In the **Name** box, type a name for your user control. Visual Studio provides a default and unique name that you may use. Next, press **Add**.

    :::image type="content" source="media/extend-existing/new-customcontrol-dialog.png" alt-text="Add item dialog in Visual Studio for Windows Forms":::

After the user control is created, Visual Studio opens the code-editor for the control.

## Example: Extend the button control

TODO: redo intro paragraph and show a gif of the control.

In the following example, you'll learn how to extend the button control. The new control counts each time the button is clicked and writes the number on top of the control.

01. Create a new Windows Forms project or open an existing project.
01. [Add a custom control to a project](#add-a-custom-control-to-a-project). The default name of `CustomControl1` is fine.
01. The control designer opens up, which lets you add components to your control. Press <kbd>F7</kbd> or right-click on the designer window and select **View Code**.
01. In the code-editor, you should see a class definition:

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl2.cs" id="control":::
    :::code language="csharp" source="./snippets/extend-existing/vb/CustomControl2.vb" id="control":::

01. First, add a class-scoped variable named `_counter`.

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="counter":::
    :::code language="csharp" source="./snippets/extend-existing/vb/CustomControl1.vb" id="counter":::

01. Override the `OnPaint` method. This method draws the control. The control should draw a string on top of the button, so you must call the base class' `OnPaint` method first, then draw a string.

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="onpaint":::
    :::code language="csharp" source="./snippets/extend-existing/vb/CustomControl1.vb" id="onpaint":::

01. Lastly, override the `OnClick` method. This method is called everytime the control is pressed. The code is going to increase the counter, and then call the `Invalidate` method which forces the control to redraw itself.

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="onclick":::
    :::code language="csharp" source="./snippets/extend-existing/vb/CustomControl1.vb" id="onclick":::

    The final code should look like the following snippet:

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="control":::
    :::code language="csharp" source="./snippets/extend-existing/vb/CustomControl1.vb" id="control":::

Now that the control is created, compile the project to populate the **Toolbox** window with the new control. Open a form designer and drag the control to the form. When you run the project and click the button, you'll see that it counts the clicks and paints the text on top of the button.
