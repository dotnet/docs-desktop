---
title: Customize an existing control
description: Learn how to inherit from existing controls so that another control has all of its functionality and visual properties.
ms.date: 01/14/2025
ms.service: dotnet-desktop
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "inheritance [Windows Forms], Windows Forms custom controls"
  - "custom controls [Windows Forms], inheritance"

#customer intent: As a developer, I want to extend an existing control so that I can use its functionality while slightly customizing it.

---

# How to extend an existing control

If you want to add more features to an existing control, you can create a control that inherits from an existing control. The new control contains all of the capabilities and visual aspect of the base control, but gives you opportunity to extend it. For example, if you created a control that inherits <xref:System.Windows.Forms.Button>, your new control would look and act exactly like a button. You could create new methods and properties to customize the behavior of the control. Some controls allow you to override the <xref:System.Windows.Forms.Control.OnPaint%2A> method to change the way the control looks.

## Add a custom control to a project

After creating a new project, use the Visual Studio templates to create a user control. The following steps demonstrate how to add a user control to your project:

01. In Visual Studio, find the **Project Explorer** pane. Right-click on the project and choose **Add** > **User Control**.

    :::image type="content" source="media/extend-existing/right-click.png" alt-text="Right-click the Visual Studio solution explorer to add a user control to a Windows Forms project":::

01. Select the **Custom Control (Windows Forms)** item.

01. In the **Name** box, type a name for your user control. Visual Studio provides a default and unique name that you may use. Next, press **Add**.

    :::image type="content" source="media/extend-existing/new-customcontrol-dialog.png" alt-text="Add item dialog in Visual Studio for Windows Forms":::

01. In **Design** mode of the control, press <kbd>F7</kbd> or click the **switch to code view** link.

    > [!TIP]
    > You can also right-click the file in the **Solution Explorer** window and select **View Code**.

## Change the custom control to a button

In this section, you learn how to change a custom control into a button that counts and displays the number of times it's clicked.

:::image type="content" source="media/extend-existing/control-preview.gif" alt-text="A Windows Forms for .NET custom control":::

After [you add a custom control to your project](#add-a-custom-control-to-a-project) named `CustomControl1`, the control designer should be opened. If it's not, double-click on the control in the **Solution Explorer**. Follow these steps to convert the custom control into a control that inherits from `Button` and extends it:

01. With the control designer opened, press <kbd>F7</kbd> or right-click on the designer window and select **View Code**.
01. In the code-editor, you should see a class definition:

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl2.cs" id="control":::
    :::code language="vb" source="./snippets/extend-existing/vb/CustomControl2.vb" id="control":::

01. Change the base class from `Control` to `Button`.

    > [!IMPORTANT]
    > If you're using **Visual Basic**, the base class is defined in the _\*.designer.vb_ file of your control. The base class to use in Visual Basic is `System.Windows.Forms.Button`.

01. Add a class-scoped variable named `_counter`.

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="counter":::
    :::code language="vb" source="./snippets/extend-existing/vb/CustomControl1.vb" id="counter":::

01. Override the `OnPaint` method. This method draws the control. The control should draw a string on top of the button, so you must call the base class' `OnPaint` method first, then draw a string.

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="onpaint":::
    :::code language="vb" source="./snippets/extend-existing/vb/CustomControl1.vb" id="onpaint":::

01. Lastly, override the `OnClick` method. This method is called every time the control is pressed. The code is going to increase the counter, and then call the `Invalidate` method, which forces the control to redraw itself.

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="onclick":::
    :::code language="vb" source="./snippets/extend-existing/vb/CustomControl1.vb" id="onclick":::

    The final code should look like the following snippet:

    :::code language="csharp" source="./snippets/extend-existing/csharp/CustomControl1.cs" id="control":::
    :::code language="vb" source="./snippets/extend-existing/vb/CustomControl1.vb" id="control":::

Now that the control is created, compile the project to populate the **Toolbox** window with the new control. Open a form designer and drag the control to the form. Run the project and press the button. Each press increases the number of clicks by one. The total clicks are printed as text on top of the button.

:::image type="content" source="media/extend-existing/toolbox.png" alt-text="Visual Studio Toolbox window for Windows Forms showing a custom control.":::
