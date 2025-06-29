---
title: How to create a user control
description: This article teaches you how to create a user control, known as a composite control, that you can add to other forms.
ms.date: 04/02/2025
ms.service: dotnet-desktop
ms.topic: how-to
no-loc: ["UserControl", "UserControl1", "UserControlProject", "Label", "Button", "Form", "TextBox"]
dev_langs:
  - "csharp"
  - "vb"
f1_keywords:
  - "UserControl"
helpviewer_keywords:
  - "controls [Windows Forms], user controls"
  - "controls [Windows Forms], types of"
  - "composite controls [Windows Forms]"
  - "extended controls [Windows Forms]"
  - "controls [Windows Forms], extended"
  - "user controls [Windows Forms]"
  - "custom controls [Windows Forms]"
  - "controls [Windows Forms], composite"
---

# How to create a user control

This article teaches you how to add a user control to your project and then add that user control to a form. You'll create a reusable user control that's both visually appealing and functional. The new control groups a <xref:System.Windows.Forms.TextBox> control with a <xref:System.Windows.Forms.Button> control. When the user selects the button, the text in the text box is cleared. For more information about user controls, see [User control overview](usercontrol-overview.md).

## Understanding user control consumers

Throughout this article, the term **consumer** refers to any code that uses your user control. This includes:

- **Forms** that contain your user control.
- **Other controls** that host your user control.
- **Applications** that reference your user control library.

When you create a user control, you're building a reusable component. The consumer is whoever uses that component by placing it on a form, setting its properties, or responding to its events. The consumer doesn't need to know about the internal controls (like the `TextBox` and `Button`) that make up your user control—they only interact with the properties and events you choose to expose.

## Essential code pattern for user controls

Before adding the detailed implementation, it's helpful to understand the minimum viable code pattern for a user control. At its core, a user control needs:

- **Event forwarding** - Pass events from internal controls to the consumer.
- **Property exposure** - Allow the consumer to access internal control properties.
- **Logical behavior** - Handle interactions between internal controls.

The following code demonstrates these patterns. You don't need all of this code for a basic user control, but these patterns help create a professional, reusable component that integrates well with the designer and consumer applications.

## Add a new user control

After opening your Windows Forms project in Visual Studio, use the Visual Studio templates to create a user control:

01. In Visual Studio, find the **Solution Explorer** window. Right-click on the project and choose **Add** > **User Control (Windows Forms)**.

    :::image type="content" source="./media/how-to-create-usercontrol/right-click.png" alt-text="Right-click the Visual Studio solution explorer to add a user control to a Windows Forms project":::

01. Set the **Name** of the control to **ClearableTextBox**, and press **Add**.

    :::image type="content" source="./media/how-to-create-usercontrol/new-usercontrol-dialog.png" alt-text="Add item dialog in Visual Studio for Windows Forms":::

After the user control is created, Visual Studio opens the designer:

:::image type="content" source="./media/how-to-create-usercontrol/designer.png" alt-text="The user control designer in Visual Studio for Windows Forms":::

## Design the clearable text box

The user control is made up of _constituent controls_, which are the controls you [create on the design surface](../controls/how-to-add-to-a-form.md), just like how you design a form. Follow these steps to add and configure the user control and its constituent controls:

01. With the designer open, the user control design surface should be the selected object. If it's not, click on the design surface to select it. Set the following properties in the **Properties** window:

    > [!div class="mx-tableNormal"]
    >
    > | Property    | Value      |
    > |-------------|------------|
    > | MinimumSize | `84, 53`   |
    > | Size        | `191, 53`  |

01. Add a **Label** control. Set the following properties:

    > [!div class="mx-tableNormal"]
    >
    > | Property  | Value     |
    > |----------|------------|
    > | Name     | `lblTitle` |
    > | Location | `3, 5`     |

01. Add a **TextBox** control. Set the following properties:

    > [!div class="mx-tableNormal"]
    >
    > | Property  | Value     |
    > |----------|------------|
    > | Name     | `txtValue` |
    > | Anchor   | `Top, Left, Right` |
    > | Location | `3, 23`    |
    > | Size     | `148, 23`  |

01. Add a **Button** control. Set the following properties:

    > [!div class="mx-tableNormal"]
    >
    > | Property  | Value     |
    > |----------|------------|
    > | Name     | `btnClear` |
    > | Anchor   | `Top, Right` |
    > | Location | `157, 23`  |
    > | Size     | `31, 23`   |
    > | Text     | `↻`        |

    The control should look like the following image:

    :::image type="content" source="./media/how-to-create-usercontrol/example-initial-design.png" alt-text="Visual Studio with Windows Forms, showing the user control that was just designed.":::

01. Press <kbd>F7</kbd> to open the code editor for the `ClearableTextBox` class.

01. Make the following code changes:

    01. At the top of the code file, import the `System.ComponentModel` namespace.
    01. Add the `DefaultEvent` attribute to the class. This attribute sets which event is generated when the consumer (the form or application using this control) double-clicks the control in the designer. For more information about attributes, see [Attributes (C#)](/dotnet/csharp/programming-guide/concepts/attributes/index) or [Attributes overview (Visual Basic)](/dotnet/visual-basic/programming-guide/concepts/attributes/index).

        :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/ClearableTextBox.cs" id="default_event":::
        :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/ClearableTextBox.vb" id="default_event":::

    01. Add an event handler that forwards the [`TextBox.TextChanged`](xref:System.Windows.Forms.Control.TextChanged) event to consumers of your user control:

        :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/ClearableTextBox.cs" id="text_changed":::
        :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/ClearableTextBox.vb" id="text_changed":::

        Notice that the event has the `Browsable` attribute declared on it. When the `Browsable` is applied to an event or property, it controls whether or not the item is visible in the **Properties** window when the control is selected in the designer. In this case, `true` is passed as a parameter to the attribute indicating that the event should be visible.

    01. Add a string property named `Text`, which exposes the [`TextBox.Text`](xref:System.Windows.Forms.Control.Text%2A) property to consumers of your user control:

        :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/ClearableTextBox.cs" id="text":::
        :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/ClearableTextBox.vb" id="text":::

    01. Add a string property named `Title`, which exposes the [`Label.Text`](xref:System.Windows.Forms.Label.Text%2A) property to consumers of your user control:

        :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/ClearableTextBox.cs" id="title":::
        :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/ClearableTextBox.vb" id="title":::

01. Switch back to the `ClearableTextBox` designer and double-click the `btnClear` control to generate a handler for the `Click` event. Add the following code for the handler, which clears the `txtValue` text box:

    :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/ClearableTextBox.cs" id="click_event":::
    :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/ClearableTextBox.vb" id="click_event":::

01. Finally, build the project by right-clicking the project in the **Solution Explorer** window, and selecting **Build**. There shouldn't be any errors, and after the build is finished, the `ClearableTextBox` control appears in the toolbox for use.

The next step is using the control in a form.

### Sample application

If you created a new project in the last section, you have a blank Form named **Form1**, otherwise, create a new form.

01. In the **Solution Explorer** window, double-click the form to open the designer. The form's design surface should be selected.
01. Set the form's `Size` property to `432, 315`.
01. Open the **Toolbox** window, and double-click the **ClearableTextBox** control. This control should be listed under a section named after your project.
01. Again, double-click on the **ClearableTextBox** control to generate a second control.
01. Move back to the designer and separate the controls so that you can see both of them.
01. Select one control and set the following properties:

    > [!div class="mx-tableNormal"]
    >
    > | Property  | Value         |
    > |----------|----------------|
    > | Name     | `ctlFirstName` |
    > | Location | `12, 12`       |
    > | Size     | `191, 53`      |
    > | Title    | `First Name`   |

01. Select the other control and set the following properties:

    > [!div class="mx-tableNormal"]
    >
    > | Property  | Value        |
    > |----------|---------------|
    > | Name     | `ctlLastName` |
    > | Location | `12, 71`      |
    > | Size     | `191, 53`     |
    > | Title    | `Last Name`   |

01. Back in the **Toolbox** window, add a label control to the form, and set the following properties:

    > [!div class="mx-tableNormal"]
    >
    > | Property  | Value        |
    > |----------|---------------|
    > | Name     | `lblFullName` |
    > | Location | `12, 252`     |

01. Next, you need to generate the event handlers for the two user controls. In the designer, double-click on the `ctlFirstName` control. This action generates the event handler for the `TextChanged` event, and opens the code editor.
01. Swap back to the designer and double-click the `ctlLastName` control to generate the second event handler.
01. Swap back to the designer and double-click on the form's title bar. This action generates an event handler for the `Load` event.
01. In the code editor, add a method named `UpdateNameLabel`. This method combines both names to create a message, and assigns the message to the `lblFullName` control.

    :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/Form1.cs" id="update_label":::
    :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/Form1.vb" id="update_label":::

01. For both `TextChanged` event handlers, call the `UpdateNameLabel` method:

    :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/Form1.cs" id="event_handlers":::
    :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/Form1.vb" id="event_handlers":::

01. Finally, call the `UpdateNameLabel` method from the form's `Load` event:

    :::code language="csharp" source="./snippets/how-to-create-usercontrol/csharp/Form1.cs" id="load":::
    :::code language="vb" source="./snippets/how-to-create-usercontrol/vb/Form1.vb" id="load":::

Run the project and enter a first and last name:

:::image type="content" source="./media/how-to-create-usercontrol/running-app.png" alt-text="A Windows Forms app with two text boxes created from user controls, and a label.":::

Try pressing the `↻` button to reset one of the text boxes.
