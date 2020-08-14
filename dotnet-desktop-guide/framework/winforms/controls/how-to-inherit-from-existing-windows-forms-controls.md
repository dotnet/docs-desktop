---
title: Inherit from Existing Controls
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "inheritance [Windows Forms], Windows Forms custom controls"
  - "custom controls [Windows Forms], inheritance"
ms.assetid: 1e1fc8ea-c615-4cf0-a356-16d6df7444ab
author: jillre
ms.author: jillfra
manager: jillfra
---
# How to: Inherit from Existing Windows Forms Controls

If you want to extend the functionality of an existing control, you can create a control derived from an existing control through inheritance. When inheriting from an existing control, you inherit all of the functionality and visual properties of that control. For example, if you were creating a control that inherited from <xref:System.Windows.Forms.Button>, your new control would look and act exactly like a standard <xref:System.Windows.Forms.Button> control. You could then extend or modify the functionality of your new control through the implementation of custom methods and properties. In some controls, you can also change the visual appearance of your inherited control by overriding its <xref:System.Windows.Forms.Control.OnPaint%2A> method.

## To create an inherited control

1. In Visual Studio, create a new **Windows Forms Application** project.

1. From the **Project** menu, choose **Add New Item**.

    The **Add New Item** dialog box appears.

1. In the **Add New Item** dialog box, double-click **Custom Control**.

    A new custom control is added to your project.

1. If you're using:

    - Visual Basic, at the top of **Solution Explorer**, click **Show All Files**. Expand CustomControl1.vb and then open CustomControl1.Designer.vb in the Code Editor.
    - C#, open CustomControl1.cs in the Code Editor.

1. Locate the class declaration, which inherits from <xref:System.Windows.Forms.Control>.

1. Change the base class to the control that you want to inherit from.

     For example, if you want to inherit from <xref:System.Windows.Forms.Button>, change the class declaration to the following:

    ```vb
    Partial Class CustomControl1
        Inherits System.Windows.Forms.Button
    ```

    ```csharp
    public partial class CustomControl1 : System.Windows.Forms.Button
    ```

1. If you are using Visual Basic, save and close CustomControl1.Designer.vb. Open CustomControl1.vb in the Code Editor.

1. Implement any custom methods or properties that your control will incorporate.

1. If you want to modify the graphical appearance of your control, override the <xref:System.Windows.Forms.Control.OnPaint%2A> method.

    > [!NOTE]
    > Overriding <xref:System.Windows.Forms.Control.OnPaint%2A> will not allow you to modify the appearance of all controls. Those controls that have all of their painting done by Windows (for example, <xref:System.Windows.Forms.TextBox>) never call their <xref:System.Windows.Forms.Control.OnPaint%2A> method, and thus will never use the custom code. Refer to the Help documentation for the particular control you want to modify to see if the <xref:System.Windows.Forms.Control.OnPaint%2A> method is available. For a list of all the Windows Form Controls, see [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md). If a control does not have <xref:System.Windows.Forms.Control.OnPaint%2A> listed as a member method, you cannot alter its appearance by overriding this method. For more information about custom painting, see [Custom Control Painting and Rendering](custom-control-painting-and-rendering.md).

    ```vb
    Protected Overrides Sub OnPaint(ByVal e As _
       System.Windows.Forms.PaintEventArgs)
       MyBase.OnPaint(e)
       ' Insert code to do custom painting.
       ' If you want to completely change the appearance of your control,
       ' do not call MyBase.OnPaint(e).
    End Sub
    ```

    ```csharp
    protected override void OnPaint(PaintEventArgs pe)
    {
       base.OnPaint(pe);
       // Insert code to do custom painting.
       // If you want to completely change the appearance of your control,
       // do not call base.OnPaint(pe).
    }
    ```

1. Save and test your control.

## See also

- [Varieties of Custom Controls](varieties-of-custom-controls.md)
- [How to: Inherit from the Control Class](how-to-inherit-from-the-control-class.md)
- [How to: Inherit from the UserControl Class](how-to-inherit-from-the-usercontrol-class.md)
- [How to: Author Controls for Windows Forms](how-to-author-controls-for-windows-forms.md)
- [Troubleshooting Inherited Event Handlers in Visual Basic](~/docs/visual-basic/programming-guide/language-features/events/troubleshooting-inherited-event-handlers.md)
- [Walkthrough: Inheriting from a Windows Forms Control](walkthrough-inheriting-from-a-windows-forms-control-with-visual-csharp.md)
