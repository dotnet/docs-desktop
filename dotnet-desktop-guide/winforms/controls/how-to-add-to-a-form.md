---
title: Add Controls to a Form
description: Learn how to add a control a form in Windows Forms for .NET
ms.date: 03/31/2025
ms.service: dotnet-desktop
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Windows Forms controls, adding to form"
  - "controls [Windows Forms], adding"
---

# Add a control to a form

Most forms are designed by adding controls to the surface of the form to define a user interface (UI). A *control* is a component on a form used to display information or accept user input.<!-- TODO For more information about controls, see [Forms overview](..\forms\overview.md). -->

The primary way a control is added to a form is through the Visual Studio Designer, but you can also manage the controls on a form at run time through code.

## Add with Designer

Visual Studio uses the Forms Designer to design forms. There's a **Toolbox** window that lists all the controls available to your app. You can add controls from this window in two ways:

### Add the control by double-clicking

When a control is double-clicked, it's automatically added to the current open form with default settings.

:::image type="content" source="media/how-to-add-to-a-form/toolbox-double-click.gif" alt-text="Double-click a control in the toolbox on visual studio for .NET Windows Forms":::

### Add the control by drawing

Select the control by clicking on it. In your form, drag-select a region. The control is placed in the region you selected.

:::image type="content" source="media/how-to-add-to-a-form/toolbox-drag-draw.gif" alt-text="Drag-select and draw a control from the toolbox on visual studio for .NET Windows Forms":::

## Add with code

Controls are created and added to a form at run time with the form's <xref:System.Windows.Forms.Control.Controls%2A> collection. This collection is also used to remove controls from a form.

The following code adds and positions two controls, a [Label](xref:System.Windows.Forms.Label) and a [TextBox](xref:System.Windows.Forms.TextBox):

:::code language="csharp" source="snippets/how-to-add-to-a-form/cs/Form1.cs" id="CreateControl":::

:::code language="vb" source="snippets/how-to-add-to-a-form/vb/Form1.vb" id="CreateControl":::

## See also

- [Set the Text Displayed by a Windows Forms Control](how-to-set-the-display-text.md)
- [Add an access key shortcut to a control](how-to-create-access-keys.md)
- <xref:System.Windows.Forms.Label?displayProperty=fullName>
- <xref:System.Windows.Forms.TextBox?displayProperty=fullName>
- <xref:System.Windows.Forms.Button?displayProperty=fullName>
