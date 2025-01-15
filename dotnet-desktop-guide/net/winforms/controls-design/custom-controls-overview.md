---
title: Custom user-drawn controls
description: ""
author: 
ms.topic: overview #Don't change
ms.date: 01/07/2025

#customer intent: As a developer, I want create a custom control so that I can control how it's drawn.

---

# What is a custom control?

This article introduces you to custom controls, how they differ from user controls, and why you would want to create them. Custom controls don't provide a visual design surface and rely on code to draw them. This is different from user controls which provide a visual design surface to group multiple controls into a single reusable unit.

Custom controls are used when an existing control or user control doesn't come close to providing the UI or interactivity that you require. They require more effort on your part to fully implement. Keyboard and mouse handling is still provided by Windows Forms, but any behaviors are left up to you to implement. There isn't a design surface provided with a custom control, because all drawing is done through code in the the <xref:System.Windows.Forms.Control.OnPaint> method. Components, such as a <xref:System.Windows.Forms.Timer> can still be added through the non-visual design surface.

## Base class

There are two base classes to choose from when creating a custom control:

- <xref:System.Windows.Forms.Control?displayProperty=fullName>

  This is the same base class used by other Windows Forms controls. You control the input and output of the control directly.

- <xref:System.Windows.Forms.ScrollableControl?displayProperty=fullName>

  This class extends `Control` by adding the ability to scroll.

Unless you require scrolling the contents of the custom control, use `Control` as your base class.

## Inherited capabilities

Since the base class of a custom control is <xref:System.Windows.Forms.Control>, you automatically inherit a lot of Windows Forms functionality that is shared by all controls, such as:

- Keyboard an mouse input.
- Layout behaviors, such as anchoring and docking.
- Support for tabbing.
- Size minimum and maximum.

## Painting

<!-- I don't like the second half of this para -->
Painting, which means to draw the control's visual, can be done in two ways, subscribe to the Paint event or override the OnPaint method. You would use the Paint event only when customizing a control provided by Windows Forms or a control where you want to do auxiliary painting on top of if. Otherwise, you override the OnPaint method in your control. For more information about how painting is used by controls, see [Painting and drawing on controls](../controls/custom-painting-drawing.md).

When you create a new custom control using the Visual Studio templates, you'll see the following code:

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

A custom control is painted through the <xref:System.Windows.Forms.Control.OnPaint%2A> method. The single argument of this method is a <xref:System.Windows.Forms.PaintEventArgs> object, which provides all of the information and functionality required to render your control. `PaintEventArgs` provides two properties that is used in rendering your control:

- <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A?displayProperty=nameWithType> &mdash; The rectangle that represents the part of the control that will be drawn. This can be the entire control, or part of the control depending on how the control is drawn.

- <xref:System.Drawing.Graphics> &mdash; Represents the graphical surface of your control. It provides several graphics-oriented objects and methods that provide the functionality necessary to draw your control.

The `OnPaint` is called whenever the control is drawn or refreshed on the screen, and the `PaintEventArgs.ClipRectangle` object represents the rectangle in which painting takes place. If the entire control needs to be refreshed, `PaintEventArgs.ClipRectangle` represents the size of the entire control. If only part of the control needs to be refreshed, it represents only the region that needs to be redrawn. An example of such a case would be when a control was partially obscured by something else in the user interface.

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

The code in the <xref:System.Windows.Forms.Control.OnPaint%2A> method of your control runs when the control is first drawn, and whenever it's refreshed. To ensure that your control is redrawn every time it's resized, add the following line to the constructor of your control:
  
```csharp
SetStyle(ControlStyles.ResizeRedraw, true);
```

```vb
SetStyle(ControlStyles.ResizeRedraw, True)
```

### Background

Take a look again at the control generated by the example in the previous section:

:::image type="content" source="./media/custom-controls-overview/custom-control-onpaint-example.png" alt-text="A custom control as rendered in Visual Studio. The control is an empty box with different colors bordering it. Each color is offset by a single pixel.":::

Notice that the background is painted with the <xref:System.Drawing.SystemColors.Control?displayProperty=nameWithType> color, even though the `OnPaint` code doesn't clear or fill the control with a color. The background is painted by the <xref:System.Windows.Forms.Control.OnPaintBackground(System.Windows.Forms.PaintEventArgs)> method before `OnPaint` is called. Override `OnPaintBackground` to handle drawing the background of your control. The default implementation of this method is to handle drawing the color and image set by the <xref:System.Windows.Forms.Form.BackColor> and <xref:System.Windows.Forms.Control.BackgroundImage> properties, respectively.

### Template

#### Base template

```csharp
namespace TextBoxResettable;

public partial class TextBoxResettable : Control
{
    public TextBoxResettable()
    {
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
    }
}
```

## Related content

- [Related article title](link.md)
- [Related article title](link.md)
- [Related article title](link.md)

<!-- Optional: Related content - H2

Consider including a "Related content" H2 section that 
lists links to 1 to 3 articles the user might find helpful.

-->

<!--

Remove all comments except the customer intent
before you sign off or merge to the main branch.

-->