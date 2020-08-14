---
title: "Walkthrough: Serializing Collections of Standard Types with the DesignerSerializationVisibilityAttribute"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "serialization [Windows Forms], collections"
  - "standard types [Windows Forms], collections"
  - "collections [Windows Forms], serializing"
  - "collections [Windows Forms], standard types"
ms.assetid: 020c9df4-fdc5-4dae-815a-963ecae5668c
author: jillre
ms.author: jillfra
manager: jillfra
---
# Walkthrough: Serialize collections of standard types

Your custom controls will sometimes expose a collection as a property. This walkthrough demonstrates how to use the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute> class to control how a collection is serialized at design time. Applying the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute.Content> value to your collection property ensures that the property will be serialized.

To copy the code in this topic as a single listing, see [How to: Serialize Collections of Standard Types with the DesignerSerializationVisibilityAttribute](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/ms171833(v=vs.120)).

## Prerequisites

You need Visual Studio to complete this walkthrough.

## Create a control with a serializable collection

The first step is to create a control that has a serializable collection as a property. You can edit the contents of this collection using the **Collection Editor**, which you can access from the **Properties** window.

1. In Visual Studio, create a Windows Control Library project, and name it **SerializationDemoControlLib**.

2. Rename `UserControl1` to `SerializationDemoControl`. For more information, see [Rename a code symbol refactoring](/visualstudio/ide/reference/rename).

3. In the **Properties** window, set the value of the <xref:System.Windows.Forms.Padding.All%2A?displayProperty=nameWithType> property to **10**.

4. Place a <xref:System.Windows.Forms.TextBox> control in the `SerializationDemoControl`.

5. Select the <xref:System.Windows.Forms.TextBox> control. In the **Properties** window, set the following properties.

    |Property|Change to|
    |--------------|---------------|
    |**Multiline**|`true`|
    |**Dock**|<xref:System.Windows.Forms.DockStyle.Fill>|
    |**ScrollBars**|<xref:System.Windows.Forms.ScrollBars.Vertical>|
    |**ReadOnly**|`true`|

6. In the **Code Editor**, declare a string array field named `stringsValue` in `SerializationDemoControl`.

     [!code-cpp[System.ComponentModel.DesignerSerializationVisibilityAttribute#4](~/samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/cpp/form1.cpp#4)]
     [!code-csharp[System.ComponentModel.DesignerSerializationVisibilityAttribute#4](~/samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/CS/form1.cs#4)]
     [!code-vb[System.ComponentModel.DesignerSerializationVisibilityAttribute#4](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/VB/form1.vb#4)]

7. Define the `Strings` property on the `SerializationDemoControl`.

   > [!NOTE]
   > The <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute.Content> value is used to enable serialization of the collection.

   [!code-cpp[System.ComponentModel.DesignerSerializationVisibilityAttribute#5](~/samples/snippets/cpp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/cpp/form1.cpp#5)]
   [!code-csharp[System.ComponentModel.DesignerSerializationVisibilityAttribute#5](~/samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/CS/form1.cs#5)]
   [!code-vb[System.ComponentModel.DesignerSerializationVisibilityAttribute#5](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.DesignerSerializationVisibilityAttribute/VB/form1.vb#5)]

8. Press **F5** to build the project and run your control in the **UserControl Test Container**.

9. Find the **Strings** property in the <xref:System.Windows.Forms.PropertyGrid> of the **UserControl Test Container**. Select the **Strings** property, then select the ellipsis (![The Ellipsis button (...) in the Properties window of Visual Studio](./media/visual-studio-ellipsis-button.png)) button to open the **String Collection Editor**.

10. Enter several strings in the **String Collection Editor**. Separate them by pressing the **Enter** key at the end of each string. Click **OK** when you are finished entering strings.

   > [!NOTE]
   > The strings you typed appear in the <xref:System.Windows.Forms.TextBox> of the `SerializationDemoControl`.

## Serialize a collection property

To test the serialization behavior of your control, you will place it on a form and change the contents of the collection with the **Collection Editor**. You can see the serialized collection state by looking at a special designer file into which the **Windows Forms Designer** emits code.

1. Add a Windows Application project to the solution. Name the project `SerializationDemoControlTest`.

2. In the **Toolbox**, find the tab named **SerializationDemoControlLib Components**. In this tab, you will find the `SerializationDemoControl`. For more information, see [Walkthrough: Automatically Populating the Toolbox with Custom Components](walkthrough-automatically-populating-the-toolbox-with-custom-components.md).

3. Place a `SerializationDemoControl` on your form.

4. Find the `Strings` property in the **Properties** window. Click the `Strings` property, then click the ellipsis (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) button to open the **String Collection Editor**.

5. Type several strings in the **String Collection Editor**. Separate them by pressing **Enter** at the end of each string. Click **OK** when you are finished entering strings.

    > [!NOTE]
    > The strings you typed appear in the <xref:System.Windows.Forms.TextBox> of the `SerializationDemoControl`.

6. In **Solution Explorer**, click the **Show All Files** button.

7. Open the **Form1** node. Beneath it is a file called **Form1.Designer.cs** or **Form1.Designer.vb**. This is the file into which the **Windows Forms Designer** emits code representing the design-time state of your form and its child controls. Open this file in the **Code Editor**.

8. Open the region called **Windows Form Designer generated code** and find the section labeled **serializationDemoControl1**. Beneath this label is the code representing the serialized state of your control. The strings you typed in step 5 appear in an assignment to the `Strings` property. The following code examples in C# and Visual Basic, show code similar to what you will see if you typed the strings "red", "orange", and "yellow".

    ```csharp
    this.serializationDemoControl1.Strings = new string[] {
            "red",
            "orange",
            "yellow"};
    ```

    ```vb
    Me.serializationDemoControl1.Strings = New String() {"red", "orange", "yellow"}
    ```

9. In the **Code Editor**, change the value of the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute> on the `Strings` property to <xref:System.ComponentModel.DesignerSerializationVisibility.Hidden>.

    ```csharp
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    ```

    ```vb
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    ```

10. Rebuild the solution and repeat steps 3 and 4.

> [!NOTE]
> In this case, the **Windows Forms Designer** emits no assignment to the `Strings` property.

## Next steps

Once you know how to serialize a collection of standard types, consider integrating your custom controls more deeply into the design-time environment. The following topics describe how to enhance the design-time integration of your custom controls:

- [Design-Time Architecture](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/c5z9s1h4(v=vs.120))

- [Attributes in Windows Forms Controls](attributes-in-windows-forms-controls.md)

- [Designer Serialization Overview](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/ms171834(v=vs.120))

- [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](creating-a-wf-control-design-time-features.md)

## See also

- <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute>
- [Walkthrough: Automatically Populating the Toolbox with Custom Components](walkthrough-automatically-populating-the-toolbox-with-custom-components.md)
