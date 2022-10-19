---
title: "Position and resize a form"
description: "Learn how to set the size and position of a form in .NET Windows Forms and Visual Studio. The size and location can either be set in the Visual Studio designer or through code."
ms.date: 10/26/2020
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "positioning Windows Forms"
  - "resizing Windows Forms"
  - "Windows Forms, location"
  - "Windows Forms, size"
---

# How to position and size a form (Windows Forms .NET)

When a form is created, the size and location is initially set to a default value. The default size of a form is generally a width and height of _800x500_ pixels. The initial location, when the form is displayed, depends on a few different settings.

You can change the size of a form at design time with Visual Studio, and at run time with code.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Resize with the designer

After [adding a new form](how-to-add.md) to the project, the size of a form is set in two different ways. First, you can set it is with the size grips in the designer. By dragging either the right edge, bottom edge, or the corner, you can resize the form.

:::image type="content" source="media/how-to-position-and-resize/designer-grips.png" alt-text="Right click solution explorer to add new form to windows forms project with grips":::

The second way you can resize the form while the designer is open, is through the properties pane. Select the form, then find the **Properties** pane in Visual Studio. Scroll down to **size** and expand it. You can set the **Width** and **Height** manually.

:::image type="content" source="media/how-to-position-and-resize/designer-properties-size.png" alt-text="Right click solution explorer to add new form to windows forms project":::

## Resize in code

Even though the designer sets the starting size of a form, you can resize it through code. Using code to resize a form is useful when something about your application determines that the default size of the form is insufficient.

To resize a form, change the <xref:System.Windows.Forms.Form.Size%2A>, which represents the width and height of the form.

### Resize the current form

You can change the size of the current form as long as the code is running within the context of the form. For example, if you have `Form1` with a button on it, that when clicked invokes the `Click` event handler to resize the form:

```csharp
private void button1_Click(object sender, EventArgs e) =>
    Size = new Size(250, 200);
```

```vb
Private Sub Button1_Click(sender As Object, e As EventArgs)
    Size = New Drawing.Size(250, 200)
End Sub
```

### Resize a different form

You can change the size of another form after it's created by using the variable referencing the form. For example, let's say you have two forms, `Form1` (the startup form in this example) and `Form2`. `Form1` has a button that when clicked, invokes the `Click` event. The handler of this event creates a new instance of the `Form2` form, sets the size, and then displays it:

```csharp
private void button1_Click(object sender, EventArgs e)
{
    Form2 form = new Form2();
    form.Size = new Size(250, 200);
    form.Show();
}
```

```vb
Private Sub Button1_Click(sender As Object, e As EventArgs)
    Dim form = New Form2 With {
        .Size = New Drawing.Size(250, 200)
    }
    form.Show()
End Sub
```

If the `Size` isn't manually set, the form's default size is what it was set to during design-time.

## Position with the designer

When a form instance is created and displayed, the initial location of the form is determined by the <xref:System.Windows.Forms.Form.StartPosition%2A> property. The <xref:System.Windows.Forms.Form.Location%2A> property holds the current location the form. Both properties can be set through the designer.

:::image type="content" source="media/how-to-position-and-resize/startposition.png" alt-text="visual studio properties pane with start position highlighted":::

| FormStartPosition Enum | Description                                                                                                      |
|------------------------|------------------------------------------------------------------------------------------------------------------|
| CenterParent           | The form is centered within the bounds of its parent form.                                                       |
| CenterScreen           | The form is centered on the current display.                                                                     |
| Manual                 | The position of the form is determined by the [Location](xref:System.Windows.Forms.Form.Location%2A) property.   |
| WindowsDefaultBounds   | The form is positioned at the Windows default location and is resized to the default size determined by Windows. |
| WindowsDefaultLocation | The form is positioned at the Windows default location and isn't resized.                                        |

The [CenterParent](xref:System.Windows.Forms.FormStartPosition.CenterParent) value only works with forms that are either a multiple document interface (MDI) child form, or a normal form that is displayed with the <xref:System.Windows.Window.ShowDialog%2A> method. `CenterParent` has no affect on a normal form that is displayed with the <xref:System.Windows.Window.Show%2A> method. To center a form (`form` variable) to another form (`parentForm` variable), use the following code:

```csharp
form.StartPosition = FormStartPosition.Manual;
form.Location = new Point(parentForm.Width / 2 - form.Width / 2 + parentForm.Location.X,
                          parentForm.Height / 2 - form.Height / 2 + parentForm.Location.Y);
form.Show();
```

```vb
form.StartPosition = Windows.Forms.FormStartPosition.CenterParent.Manual
form.Location = New Drawing.Point(parentForm.Width / 2 - form.Width / 2 + parentForm.Location.X,
                                  parentForm.Height / 2 - form.Height / 2 + parentForm.Location.Y)

form.Show()
```

## Position with code

Even though the designer can be used to set the starting location of a form, you can use code either change the starting position mode or set the location manually. Using code to position a form is useful if you need to manually position and size a form in relation to the screen or other forms.

### Move the current form

You can move the current form as long as the code is running within the context of the form. For example, if you have `Form1` with a button on it, that when clicked invokes the `Click` event handler. The handler in this example changes the location of the form to the top-left of the screen by setting the <xref:System.Windows.Forms.Form.Location%2A> property:

```csharp
private void button1_Click(object sender, EventArgs e) =>
    Location = new Point(0, 0);
```

```vb
Private Sub Button1_Click(sender As Object, e As EventArgs)
    Location = New Drawing.Point(0, 0)
End Sub
```

### Position a different form

You can change the location of another form after it's created by using the variable referencing the form. For example, let's say you have two forms, `Form1` (the startup form in this example) and `Form2`. `Form1` has a button that when clicked, invokes the `Click` event. The handler of this event creates a new instance of the `Form2` form and sets the location:

```csharp
private void button1_Click(object sender, EventArgs e)
{
    Form2 form = new Form2();
    form.Location = new Point(0, 0);
    form.Show();
}
```

```vb
Private Sub Button1_Click(sender As Object, e As EventArgs)
    Dim form = New Form2 With {
        .Location = New Drawing.Point(0, 0)
    }
    form.Show()
End Sub
```

If the `Location` isn't set, the form's default position is based on what the `StartPosition` property was set to at design-time.

## See also

- [How to add a form to a project (Windows Forms .NET)](how-to-add.md)
- [Events overview (Windows Forms .NET)](events.md)
- [Position and layout of controls (Windows Forms .NET)](../controls/layout.md)
