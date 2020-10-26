---
title: Set the Text displayed by a Control
description: Learn how to set the text displayed by a Windows Forms control. Set or return the text by using the Text property, or change the font by using the Font property.
ms.date: 10/26/2020
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Windows Forms, captions"
  - "Button control [Windows Forms], button text"
  - "StdFont object and CommandButton caption"
  - "captions [Windows Forms], Windows Forms controls"
  - "Text property [Windows Forms], Windows Forms control"
  - "Button control [Windows Forms], text display"
  - "labels [Windows Forms], adding to CommandButton control"
  - "buttons [Windows Forms], text"
  - "captions [Windows Forms], setting"
  - "text"
  - "examples [Windows Forms], controls"
  - "text [Windows Forms], Windows Forms controls"
  - "controls [Windows Forms], captions"
  - "forms [Windows Forms], captions"
---
# How to: Set the text displayed by a control (Windows Forms .NET)

Windows Forms controls usually display some text that's related to the primary function of the control. For example, a <xref:System.Windows.Forms.Button> control usually displays a caption indicating what action will be performed if the button is clicked. For all controls, you can set or return the text by using the <xref:System.Windows.Forms.Control.Text%2A> property. You can change the font by using the <xref:System.Windows.Forms.Control.Font%2A> property.

You can also set the text by using the [designer](#designer).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Designer

01. In the **Properties** window in Visual Studio, set the **Text** property of the control to an appropriate string.

    To create an underlined shortcut key, include an ampersand (&) before the letter that will be the shortcut key.

    :::image type="content" source="media/how-to-set-the-text-displayed-by-a-windows-forms-control/properties-text.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Text property shown.":::

01. In the **Properties** window, select the ellipsis button (![Ellipsis button (...) in the Properties window of Visual Studio](../media/visual-studio-ellipsis-button.png)) next to the **Font** property.

    :::image type="content" source="media/how-to-set-the-text-displayed-by-a-windows-forms-control/properties-font.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Font property shown.":::

    In the standard font dialog box, adjust the font with settings such as type, size, and style.

    :::image type="content" source="media/how-to-set-the-text-displayed-by-a-windows-forms-control/font-window.png" alt-text="Visual Studio Properties pane for .NET Windows Forms with Font settings window.":::

## Programmatic

01. Set the <xref:System.Windows.Forms.Control.Text%2A> property to a string.

    To create an underlined access key, include an ampersand (&) before the letter that will be the access key.

01. Set the <xref:System.Windows.Forms.Control.Font%2A> property to an object of type <xref:System.Drawing.Font>.

    ```vb
    Button1.Text = "Click here to save changes"
    Button1.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)
    ```

    ```csharp
    button1.Text = "Click here to save changes";
    button1.Font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
    ```

    > [!NOTE]
    > You can use an escape character to display a special character in user-interface elements that would normally interpret them differently, such as menu items. For example, the following line of code sets the menu item's text to read "& Now For Something Completely Different":

    ```vb
    MPMenuItem.Text = "&& Now For Something Completely Different"
    ```

    ```csharp
    mpMenuItem.Text = "&& Now For Something Completely Different";
    ```

## See also

- <xref:System.Windows.Forms.Control.Text%2A?displayProperty=nameWithType>
- [How to: Create Access Keys for Windows Forms Controls](how-to-create-access-keys.md)
