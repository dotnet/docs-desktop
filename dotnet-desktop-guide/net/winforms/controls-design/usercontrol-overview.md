---
title: User control overview
description: Learn about what a user control is in Windows Forms. A user control is a composite control that displays other controls as a group, and is interacted with as a single control.
ms.date: 04/20/2023
ms.topic: overview
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

# User control overview (Windows Forms .NET)

A user control is a collection of Windows Forms controls encapsulated in a common container. This kind of control is referred to as a _composite control_. The contained controls are called _constituent controls_. User controls derive from the <xref:System.Windows.Forms.UserControl> class.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

User controls are designed like Forms, with a visual designer. You create, arrange, and modify, the constituent controls through the visual designer. The control events and logic are written exactly the same way as when you're designing a Form. The user control is placed on a Form just like any other control.

The constituent controls are available to the user control, and the app user can interact with them all individually at runtime, but the properties and methods declared by the constituent controls aren't exposed to the consumer. For example, if you place a `TextBox` and `Button` control on the user control, the button's `Click` event is handled internally by the user control, but not by the Form where the user control is placed.

User controls are usable by the project in which they're created, or in other projects that have reference to the project containing a user control.

## Add a user control to a project

After creating a new project, use the Visual Studio templates to create a user control. The following steps demonstrate how to add a user control to your project:

01. In Visual Studio, find the **Project Explorer** pane. Right-click on the project and choose **Add** > **User Control (Windows Forms)**.

    :::image type="content" source="media/usercontrol-overview/right-click.png" alt-text="Right-click the Visual Studio solution explorer to add a user control to a Windows Forms project":::

01. In the **Name** box, type a name for your user control. Visual Studio provides a default and unique name that you may use. Next, press **Add**.

    :::image type="content" source="media/usercontrol-overview/new-usercontrol-dialog.png" alt-text="Add item dialog in Visual Studio for Windows Forms":::

After the user control is created, Visual Studio opens the designer:

:::image type="content" source="media/usercontrol-overview/designer.png" alt-text="The user control designer in Visual Studio for Windows Forms":::

## Example: Create a clearable text box

In the following example, you'll learn how to create a reusable user control that's both visually appealing and functional. The user control is made up of three controls: a `TextBox`, a `Label`, and a `Button`. The `TextBox` is used for entering text, while the `Button` clears it.

01. Create a new Windows Forms project.
01. [Add a user control to your project](#add-a-user-control-to-a-project). The default name of `UserControl1` is fine.
01. The **UserControl1** designer is shown, and the user control should be the focused object. If it's not, click on the design surface to select it. Set the following properties:

    | Property    | Value      |
    |-------------|------------|
    | MinimumSize | `84, 53`   |
    | Size        | `191, 53`  |

01. Add a **Label** control. Set the following properties:

    | Property  | Value     |
    |----------|------------|
    | Name     | `lblTitle` |
    | Location | `3, 5`     |

01. Add a **TextBox** control. Set the following properties:

    | Property  | Value     |
    |----------|------------|
    | Name     | `txtValue` |
    | Anchor   | `Top, Left, Right` |
    | Location | `3, 23`    |
    | Size     | `148, 23`  |

01. Add a **Button** control. Set the following properties:

    | Property  | Value     |
    |----------|------------|
    | Name     | `btnClear` |
    | Anchor   | `Top, Right` |
    | Location | `157, 23`  |
    | Size     | `31, 23`   |
    | Text     | `↻`        |

    The control should look like the following image:

    :::image type="content" source="./media/usercontrol-overview/example-initial-design.png" alt-text="Visual Studio with Windows Forms, showing the user control that was just designed.":::

01. Press <kbd>F7</kbd> to open the code editor for the `UserControl1` class.
01. Make the following code changes:

    01. Before the `class` declaration, add import the `System.ComponentModel` namespace, and add the `DefaultEvent` attribute to the class. This attribute sets which event is generated by the consumer when the control is double-clicked in the designer.

        :::code language="csharp" source="./snippets/usercontrol-overview/csharp/UserControl1.cs" id="default_event":::

    01. Add an event handler that exposes the [`TextBox.TextChanged`](xref:System.Windows.Forms.Control.TextChanged) event to the consumer:

        :::code language="csharp" source="./snippets/usercontrol-overview/csharp/UserControl1.cs" id="text_changed":::

        Notice that the event has the `Browsable` attribute declared on it. When the `Browsable` attribute is set to `true` and applied to an event or property, that member becomes visible in the **Properties** pane to the consumer when they're using the control in the forms designer.

    01. Add a string property named `Text`, which exposes the [`TextBox.Text`](xref:System.Windows.Forms.Control.Text%2A) property to the consumer:

        :::code language="csharp" source="./snippets/usercontrol-overview/csharp/UserControl1.cs" id="text":::

    01. Add a string property named `Title`, which exposes the [`Label.Text`](xref:System.Windows.Forms.Label.Text%2A) property to the consumer:

        :::code language="csharp" source="./snippets/usercontrol-overview/csharp/UserControl1.cs" id="title":::

01. Switch back to the `UserControl1` designer, and double-click the `btnClear` control to generate a handler for the `Click` event. Add the following code for the handler, which clears the `txtValue` text box:

    :::code language="csharp" source="./snippets/usercontrol-overview/csharp/UserControl1.cs" id="click_event":::

01. Finally, build the project by right-clicking the project in the **Solution Explorer** pane, and selecting **Build**. There shouldn't be any errors, and after the build is finished, the `UserControl1` control will be available for use.

The next step is using the control in a form.

### Sample application

If you created a new project in the last section, you have a blank Form named **Form1**, otherwise, create a new form.

01. In the **Solution Explorer** pane, double-click the **Form1** form to open the designer.
01. Set the form's `Size` property to `432, 315`.
01. Open the **Toolbox** pane, and double-click the **UserControl1** control. This control should be listed under a section named after your project, and in the example being used to write this article, the project's name is **UserControlProject**.
01. Again, double-click on the **UserControl1** control to generate a second control.
01. Move back to the designer and separate the controls so that you can see both of them.
01. Choose one control and set the following properties:

    | Property  | Value         |
    |----------|----------------|
    | Name     | `ctlFirstName` |
    | Location | `12, 12`       |
    | Size     | `191, 53`      |
    | Title    | `First Name`   |

01. Choose the other control and set the following properties:

    | Property  | Value        |
    |----------|---------------|
    | Name     | `ctlLastName` |
    | Location | `12, 71`      |
    | Size     | `191, 53`     |
    | Title    | `Last Name`   |

01. Back in the **Toolbox** pane, add a label control to the form, and set the following properties:

    | Property  | Value        |
    |----------|---------------|
    | Name     | `lblFullName` |
    | Location | `12, 252`     |

01. Next, you need to generate the event handlers for the two user controls. In the designer, double-click on the `ctlFirstName` control. This action generates the event handler for the `TextChanged` event, and opens the code editor.
01. Swap back to the designer and double-click the `ctlLastName` control to generate the second event handler.
01. Swap back to the designer and double-click on the form's title bar. This action generates an event handler for the `Load` event.
01. In the code editor, add a method named `UpdateNameLabel`. This method combines both the first and last names to form a greeting, assigning the text to the `lblFullName` control.

    :::code language="csharp" source="./snippets/usercontrol-overview/csharp/Form1.cs" id="update_label":::

01. For both the `TextChanged` event handlers, call the `UpdateNameLabel` method:

    :::code language="csharp" source="./snippets/usercontrol-overview/csharp/Form1.cs" id="event_handlers":::

01. Finally, call the `UpdateNameLabel` method from the form's `Load` event:

    :::code language="csharp" source="./snippets/usercontrol-overview/csharp/Form1.cs" id="load":::

Run the project and enter a first and last name:

:::image type="content" source="./media/usercontrol-overview/running-app.png" alt-text="A Windows Forms app with two text boxes created from user controls, and a label.":::

Try pressing the `↻` button to reset one of the text boxes.
