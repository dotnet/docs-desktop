---
title: Custom user-drawn controls
description: "Learn about how custom controls differ from user controls by not providing a visual design surface and relying on user-supplied code for drawing."
author: adegeo
ms.topic: overview #Don't change
ms.date: 01/15/2025

#customer intent: As a developer, I want create a custom control so that I can control how it's drawn.

---

# What is a custom control?

This article introduces you to custom controls, how they differ from user controls, and why you would want to create them. Custom controls don't provide a visual design surface and rely on user-supplied code to draw themselves. This is different from user controls which provide a visual design surface to group multiple controls into a single reusable unit.

Custom controls are used when an existing control or user control doesn't come close to providing the UI or interactivity that you require. They require more effort on your part to fully implement. Keyboard and mouse handling is still provided by Windows Forms, but any behaviors are left up to you to implement. There isn't a design surface provided with a custom control, because all drawing is done through code in the <xref:System.Windows.Forms.Control.OnPaint%2A> method. Components, such as a <xref:System.Windows.Forms.Timer> can still be added through the nonvisual design surface.

## Base class

There are two base classes to choose from when creating a custom control:

- <xref:System.Windows.Forms.Control?displayProperty=fullName>

  This is the same base class used by other Windows Forms controls. You control the input and output of the control directly.

- <xref:System.Windows.Forms.ScrollableControl?displayProperty=fullName>

  This class extends `Control` by adding the ability to scroll.

Unless you require scrolling the contents of the custom control, use `Control` as your base class.

## Inherited capabilities

Since the base class of a custom control is <xref:System.Windows.Forms.Control>, you automatically inherit Windows Forms functionality shared by all controls, such as:

- Keyboard a mouse input.
- Layout behaviors, such as anchoring and docking.
- Support for tabbing.
- Minimum and maximum size restrictions.

## Painting

<!-- I don't like the second half of this para -->
Painting, which means to draw the control's visual, is accomplished by overriding the <xref:System.Windows.Forms.Control.OnPaint%2A> method. For more information about how painting is used by controls, see [Painting and drawing on controls](../controls/custom-painting-drawing.md).

When you create a custom control using the Visual Studio templates, the `OnPaint` method is automatically overridden for you. The template does this because you're required to write the code to draw your control. Here's an example of what the template generates:

```csharp
public partial class CustomControl1 : Control
{
    public CustomControl1()
    {
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
    }
}
```

A custom control is painted with the <xref:System.Windows.Forms.Control.OnPaint%2A> method. The single argument of this method is a <xref:System.Windows.Forms.PaintEventArgs> object, which provides all of the information and functionality required to render your control. `PaintEventArgs` provides two properties that are used in rendering your control:

- <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A?displayProperty=nameWithType>&mdash;Represents the part of the control needs to be redrawn. This can be the entire control or part of the control.

- <xref:System.Drawing.Graphics>&mdash;Represents the graphical surface of your control. It provides several graphics-oriented objects and methods that provide the functionality necessary to draw your control.

The `OnPaint` is called whenever the control is drawn or refreshed on the screen, and the `PaintEventArgs.ClipRectangle` object represents the rectangle in which painting takes place. If the entire control needs to be refreshed, `PaintEventArgs.ClipRectangle` represents the size of the entire control. If only part of the control needs to be refreshed, it represents only the region that needs to be redrawn. An example of such a case would be when a control is partially obscured by something else in the user interface, and that other object is moved away from the control. The newly exposed portion of the control must be redrawn.

The following code snippet is a custom control that renders multiple colored rectangles around the edge of the control.

```csharp
protected override void OnPaint(PaintEventArgs pe)
{
    Rectangle rect = this.ClientRectangle;

    // Bring the width/height in by 1 pixel so the rectangle is drawn inside the control.
    rect.Width -= 1;
    rect.Height -= 1;

    Pen[] colorPens = new Pen[] { Pens.Blue, Pens.BlueViolet,
                                  Pens.AliceBlue, Pens.CornflowerBlue,
                                  Pens.Cyan, Pens.DarkCyan };

    foreach (Pen pen in colorPens)
    {
        pe.Graphics.DrawRectangle(pen, rect);
        rect.Inflate(-1, -1);
    }

    // Raise the Paint event so users can custom paint if they want.
    base.OnPaint(pe);
}
```

The previous code creates a control that looks like the following image:

:::image type="content" source="./media/custom-controls-overview/custom-control-onpaint-example.png" alt-text="A custom control as rendered in Visual Studio. The control is an empty box with different colors bordering it. Each color is inset by a single pixel.":::

The code in the <xref:System.Windows.Forms.Control.OnPaint%2A> method of your control runs when the control is first drawn, and whenever it's invalidated. To ensure that your control is redrawn every time it's resized, add the following line to the constructor of your control:
  
```csharp
SetStyle(ControlStyles.ResizeRedraw, true);
```

```vb
SetStyle(ControlStyles.ResizeRedraw, True)
```

### Background

Take a look at the control generated by the example in the previous section:

:::image type="content" source="./media/custom-controls-overview/custom-control-onpaint-example.png" alt-text="A custom control as rendered in Visual Studio. The control is an empty box with different colors bordering it. Each color is offset by a single pixel.":::

Notice that the background is painted with the <xref:System.Drawing.SystemColors.Control?displayProperty=nameWithType> color, even though the `OnPaint` code doesn't clear or fill the control with a color. The background is actually painted by the <xref:System.Windows.Forms.Control.OnPaintBackground(System.Windows.Forms.PaintEventArgs)> method before `OnPaint` is called. Override `OnPaintBackground` to handle drawing the background of your control. The default implementation of this method is to handle drawing the color and image set by the <xref:System.Windows.Forms.Form.BackColor> and <xref:System.Windows.Forms.Control.BackgroundImage> properties, respectively.

## Related content

- [Create a simple custom control](how-to-create-simple-custom-control.md)
- [Custom controls overview](overview.md)