---
title: "How to: Inherit Forms Using the Inheritance Picker Dialog Box"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "inheritance [Windows Forms], forms"
  - "Inheritance Picker dialog box"
  - "inherited forms [Windows Forms], creating"
ms.assetid: 969b4c04-12aa-4297-93a2-0ae747447823
---
# How to: Inherit Forms Using the Inheritance Picker

The easiest way to inherit a form or other object is to use the **Inheritance Picker** dialog box. With it, you can take advantage of code or user interfaces (UI) you have already created in other solutions.

> [!NOTE]
> In order to inherit from a form with the **Inheritance Picker** dialog box, the project containing that form must have been built into an executable file or DLL. To build the project, choose **Build Solution** from the **Build** menu.

## Create a Windows Form by using the Inheritance Picker

1. In Visual Studio, from the **Project** menu, choose **Add Windows Form**.

   The **Add New Item** dialog box opens.

2. Search the **Inherited Form** template either from the searchbox or by clicking on the **Windows Forms** category, select it, and name it in the **Name** box. Click the **Add** button to proceed.

   The **Inheritance Picker** dialog box opens. If the current project already contains forms, they are displayed in the **Inheritance Picker** dialog box.

3. To inherit from a form in another assembly, click the **Browse** button.

4. Within the **Select a file which contains a component to inherit from** dialog box, navigate to the project containing the form or module you desire.

5. Click the name of the .exe or .dll file to select it and click the **Open** button.

   This returns you to the **Inheritance Picker** dialog box, where the component is now listed, along with the project in which it is located.

6. Select the component.

   In **Solution Explorer**, the component is added to your project. If it has a UI, controls that are part of the inherited form will be marked with a glyph (![Screenshot of the Visual Basic inheritance symbol.](./media/how-to-inherit-forms-using-the-inheritance-picker-dialog-box/visual-basic-inheritance-glyph.gif)), and, when selected, have a border indicating the level of security that the control has on the superclassed form. The behaviors that correspond to the different security levels are listed in the table below.

    |Security level of control|Available interaction through Designer and Code Editor with Inherited Form|
    |-------------------------------|--------------------------------------------------------------------------------|
    |Public|Standard border with sizing handles: control may be sized and moved. The control can be accessed internally by the class which declares it and externally by other classes.|
    |Protected|Standard border with sizing handles: control may be sized and moved. Can be accessed internally by the class that declares it and any class that inherits from the parent class, but cannot be accessed by external classes.|
    |Protected Internal (Protected Friend in Visual Basic)|Standard border with sizing handles: control may be sized and moved. Can be accessed internally by the class that declares it, by any class that inherits from the parent class, and by other members of the assembly that contains it.|
    |Internal (Friend in Visual Basic)|Standard border with no sizing handles, shown on the form, properties visible in **Properties** window. However, all aspects of the control will be considered read-only. You cannot move or size the control, or change its properties. If the control is a container of other controls, like a group box, new controls cannot be added and existing controls cannot be removed, even if those controls were public. The control can only be accessed by other members of the assembly that contains it.|
    |Private|Standard border with no sizing handles, shown on the form, properties visible in **Properties** window. However, all aspects of the control will be considered read-only. You cannot move or size the control, or change its properties. If the control is a container of other controls, like a group box, new controls cannot be added and existing controls cannot be removed, even if those controls were public. The control can only be accessed by the class that declares it.|

     For information about how to alter a base form's appearance, see [Effects of Modifying a Base Form's Appearance](effects-of-modifying-base-form-appearance.md).

    > [!NOTE]
    > When you combine inherited controls and components with standard controls and components on Windows Forms, you might encounter conflicts with the z-ordering. You can correct this by modifying the z-order, which is done by clicking in the **Format** menu, pointing to **Order**, and then clicking **Bring To Front** or **Send To Back**. For more information about the z-order of controls, see [How to: Layer Objects on Windows Forms](../controls/how-to-layer-objects-on-windows-forms.md).

## See also

- [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md)
- [using](../../../csharp/language-reference/keywords/using.md)
- [Effects of Modifying a Base Form's Appearance](effects-of-modifying-base-form-appearance.md)
- [Windows Forms Visual Inheritance](windows-forms-visual-inheritance.md)
