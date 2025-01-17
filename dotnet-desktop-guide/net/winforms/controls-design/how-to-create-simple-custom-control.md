---
title: Create a simple custom control
description: "Learn how to create a custom control that displays a string with a horizontal alignment."
ms.topic: how-to
ms.date: 01/15/2025
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "inheritance [Windows Forms], Windows Forms custom controls"
  - "custom controls [Windows Forms], inheritance"

#customer intent: As a developer, I want to create a simple control so that I can learn more about how they're structured and designed.

---
# Create a simple custom control (Windows Forms .NET)

This article teaches you the key steps for authoring a custom Windows Forms control. The simple control developed in this article prints the <xref:System.Windows.Forms.Control.Text> to the left, center, or right of the control. The alignment of the text can be changed. It doesn't raise or handle events.

In this article you learn how to:

- Add a property and field to handle the horizontal alignment setting of the text.
- Use `OnTextChanged` to invalidate the control.
- Provide code in the `OnPaint` method to draw text on the control's surface.

## Add a custom control

The first step is to add a custom control to your project.

01. In Visual Studio, find the **Solution Explorer** window. Right-click on the project and choose **Add** > **New Item**.

    :::image type="content" source="../media/shared/visual-studio-right-click-project-add.png" alt-text="An image of Visual Studio. In the Solution Explorer window, the project was right-clicked showing a menu. Highlighted in the menu is the 'Add' menu item, which is expanded showing a sub menu. In the sub menu, the'New Item' menu item is highlighted.":::

01. Search for **Custom Control** and select it.
01. Set the file name to **FirstControl** and select **Add**.
01. In **Design** mode of the control, press <kbd>F7</kbd> or select the **switch to code view** link.

    > [!TIP]
    > You can also right-click the file in the **Solution Explorer** window and select **View Code**.

You should now be looking at the source code for the custom control, which looks similar to the following code snippet:

:::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/DefaultTemplate/FirstControl.cs" id="template":::
:::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/DefaultTemplate/FirstControl.vb" id="template":::

## Add a property

The `TextAlignment` property controls how the text is painted on the control. It's backed by a field named `_textAlignment`, which is a <xref:System.Windows.Forms.HorizontalAlignment> enumeration.

With the `FirstControl` class, perform the following steps:

01. Add a field named `_textAlignment` of the type `HorizontalAlignment`.

    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="field":::
    :::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="field":::

01. Wrap the field in a property named `TextAlignment`. When setting the property, call the `Invalidate` method to force `OnPaint` to run.

    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/DefaultTemplate/FirstControl.cs" id="property":::
    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/vb/DefaultTemplate/FirstControl.vb" id="property":::

01. Add the following attributes to the property to integrate it with the **Properties** window in Visual Studio.

    - `Category`&mdash;The category applied to the property.
    - `Description`&mdash;The description of the property.
    - `DefaultValue`&mdash;A default value for the property to enable resetting the property and help serialization of the property.

    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="attributes":::
    :::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="attributes":::

## Handle text changed

The `TextAlignment` property calls `Invalidate` so that the control repaints itself with the latest value, using the `Text` of the control. However, if the `Text` property changes, nothing is updated. The `Text` property doesn't call `Invalidate`. However, it does call the `OnTextChanged` method, which you can override to force repainting.

With the `FirstControl` class, perform the following steps:

01. Override the `OnTextChanged` method.
01. Call `base.OnTextChanged` to ensure that the `TextChanged` event is raised.
01. Call the `Invalidate` method to force repainting.

Your code should look like the following snippet:

:::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="ontextchanged":::
:::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="ontextchanged":::

## Paint the control

The last part of the custom control is painting. With the `FirstControl` class, perform the following steps:

01. Locate the `OnPaint` method generated by the template. If it's missing, override it from the base class.
01. Create a new `StringFormat` variable named `style`.

    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="stringformat":::
    :::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="stringformat":::

01. Based on `_textAlignment`, set the `style.Alignment` property to the appropriate value.

    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="alignment":::
    :::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="alignment":::

01. Draw the `Text` property with `Graphics.DrawString`.

    :::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="drawstring":::
    :::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="drawstring":::

    > [!IMPORTANT]
    > The `Graphics.DrawString` method uses a `Brush` for the color of the text. `Brushes` must be disposed of after use.

01. Call `base.OnPaint` to ensure that the `Paint` event is raised.
01. Save the code file and compile the project. After the project compiles, Visual Studio adds the custom control to the **Toolbox** window.

Your code should look like the following snippet:

:::code language="csharp" source="./snippets/how-to-create-simple-custom-control/csharp/FirstControl.cs" id="firstcontrol":::
:::code language="vb" source="./snippets/how-to-create-simple-custom-control/vb/FirstControl.vb" id="firstcontrol":::

The previous code uses the `_textAlignment` field to determine how to align the text of the control, then paints the text accordingly. The painting code uses the <xref:System.Drawing.StringFormat?displayProperty=fullName> type, which encapsulates text layout information and provides access to alignment. The <xref:System.Drawing.Graphics.DrawString*?displayProperty=nameWithType> method uses text, a font, color, and formatting options to draw a string.

## Related content

-  [Custom controls](overview.md)
-  <xref:System.Drawing.Graphics.DrawString*?displayProperty=fullName>
-  <xref:System.Windows.Forms.HorizontalAlignment?displayProperty=nameWithType>
-  <xref:System.Windows.Forms.Control.OnPaint(System.Windows.Forms.PaintEventArgs)?displayProperty=fullName>
