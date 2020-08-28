---
title: Add Controls
description: Learn how to draw a control on a Windows Form. A control is a component on a form you can use to display information or accept user input.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "Windows Forms controls, adding to form"
  - "controls [Windows Forms], adding"
ms.assetid: 2af86001-9d62-4154-87fb-66db2c3cd9fd
---
# How to: Add Controls to Windows Forms

Most forms are designed by adding controls to the surface of the form to define a user interface (UI). A *control* is a component on a form used to display information or accept user input. For more information about controls, see [Windows Forms Controls](index.md).

## To draw a control on a form

1. Open the form. For more information, see [How to: Display Windows Forms in the Designer](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/w5yd62ts(v=vs.100)).

2. In the **Toolbox**, click the control you want to add to your form.

3. On the form, click where you want the upper-left corner of the control to be located, and drag to where you want the lower-right corner of the control to be located.

    The control is added to the form with the specified location and size.

    > [!NOTE]
    > Each control has a default size defined. You can add a control to your form in the control's default size by dragging it from the **Toolbox** to the form.

## To drag a control to a form

1. Open the form. For more information, see [How to: Display Windows Forms in the Designer](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/w5yd62ts(v=vs.100)).

2. In the **Toolbox**, click the control you want and drag it to your form.

    The control is added to the form at the specified location in its default size.

    > [!NOTE]
    > You can double-click a control in the **Toolbox** to add it to the upper-left corner of the form in its default size.

    You can also add controls dynamically to a form at run time. In the following code example, a <xref:System.Windows.Forms.TextBox> control will be added to the form when a <xref:System.Windows.Forms.Button> control is clicked.

    > [!NOTE]
    > The following procedure requires the existence of a form with a **Button** control, `Button1`, already placed on it.

## To add a control to a form programmatically

1. In the method that handles the button's `Click` event within your form's class, insert code similar to the following to add a reference to your control variable, set the control's `Location`, and add the control.

    ```vb
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       Dim MyText As New TextBox()
       MyText.Location = New Point(25, 25)
       Me.Controls.Add(MyText)
    End Sub
    ```

    ```csharp
    private void button1_Click(object sender, System.EventArgs e)
    {
       TextBox myText = new TextBox();
       myText.Location = new Point(25,25);
       this.Controls.Add (myText);
    }
    ```

    ```cpp
    private:
      System::Void button1_Click(System::Object ^  sender,
        System::EventArgs ^  e)
      {
        TextBox ^ myText = gcnew TextBox();
        myText->Location = Point(25,25);
        this->Controls->Add(myText);
      }
    ```

    > [!NOTE]
    > You can also add code to initialize other properties of the control.

    > [!IMPORTANT]
    > You might expose your local computer to a security risk through the network by referencing a malicious `UserControl`. This would only be a concern in the case of a malicious person creating a damaging custom control, followed by you mistakenly adding it to your project.

## See also

- [Windows Forms Controls](index.md)
- [How to: Resize Controls on Windows Forms](how-to-resize-controls-on-windows-forms.md)
- [How to: Set the Text Displayed by a Windows Forms Control](how-to-set-the-text-displayed-by-a-windows-forms-control.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)
