---
title: "How to: Author Composite Controls"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UserControl class [Windows Forms], creating composite controls"
  - "user controls [Windows Forms], creating"
  - "user controls [Windows Forms], inheriting from"
  - "composite controls [Windows Forms], creating"
ms.assetid: 79c9cf05-5ab6-4a18-886d-88a64748b098
author: jillre
ms.author: jillfra
manager: jillfra
---
# How to: Author composite controls

Composite controls can be employed in many ways. You can author them as part of a Windows desktop application project, and use them only on forms in the project. Or you can author them in a Windows Control Library project, compile the project into an assembly, and use the controls in other projects. You can even inherit from them and use visual inheritance to customize them quickly for special purposes.

## To author a composite control

1. In Visual Studio, create a new **Windows Application** project, and name it **DemoControlHost**.

2. On the **Project** menu, click **Add User Control**.

3. In the **Add New Item** dialog box, give the class file (.vb or .cs file) the name you want the composite control to have.

4. Select the **Add** button to create the class file for the composite control.

5. Add controls from the **Toolbox** to the composite control surface.

6. Place code in event procedures, to handle events raised by the composite control or by its constituent controls.

7. Close the designer for the composite control, and save the file when you are prompted.

8. On the **Build** menu, click **Build Solution**.

     The project must be built in order for custom controls to appear in the **Toolbox**.

9. Use the **DemoControlHost** tab of the **Toolbox** to add instances of your control to `Form1`.

## To author a control class library

1. Open a new **Windows Control Library** project.

     By default, the project contains a composite control.

2. Add controls and code as described in the procedure above.

3. Choose a control you do not want inheriting classes to change, and set the **Modifiers** property of this control to **Private**.

4. Build the DLL.

## To inherit from a composite control in a control class library

1. On the **File** menu, point to **Add** and select **New Project** to add a new **Windows Application** project to the solution.

2. In **Solution Explorer**, right-click the **References** folder for the new project and choose **Add Reference** to open the **Add Reference** dialog box.

3. Select the **Projects** tab and double-click your control library project.

4. On the **Build** menu, click **Build Solution**.

5. In **Solution Explorer**, right-click your control library project and select **Add New Item** from the shortcut menu.

6. Select the **Inherited User Control** template from the **Add New Item** dialog box.

7. In the **Inheritance Picker** dialog box, double-click the control you want to inherit from.

     A new control is added to your project.

8. Open the visual designer for the new control and add additional constituent controls.

     You can see the constituent controls that were inherited from the composite control in your DLL, and you can alter the properties of controls whose **Modifiers** property is **Public**. You cannot change the properties of the control whose **Modifiers** property is **Private**.

## See also

- [Walkthrough: Authoring a Composite Control](walkthrough-authoring-a-composite-control-with-visual-csharp.md)
- [Walkthrough: Inheriting from a Windows Forms Control](walkthrough-inheriting-from-a-windows-forms-control-with-visual-csharp.md)
- [Control Type Recommendations](control-type-recommendations.md)
- [How to: Author Controls for Windows Forms](how-to-author-controls-for-windows-forms.md)
- [Varieties of Custom Controls](varieties-of-custom-controls.md)
