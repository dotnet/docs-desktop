---
title: Display an image on a control
description: Learn how to display an image on a Windows Form control. Many controls, such as the PictureBox, can display an image.
ms.date: 10/26/2020
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Button control [Windows Forms], images"
  - "Windows Forms controls, images"
  - "controls [Windows Forms], images"
  - "images [Windows Forms], Windows Forms contr ols"
  - "examples [Windows Forms], controls"
---

# How to display an image on a control (Windows Forms .NET)

Several Windows Forms controls can display images. These images can be icons that clarify the purpose of the control, such as a diskette icon on a button denoting the Save command. Alternatively, the icons can be background images to give the control the appearance and behavior you want.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Display an image - designer

In Visual Studio, use the Visual Designer to display an image.

01. Open the Visual Designer of the form containing the control to change.
01. Select the control.
01. In the **Properties** pane, select the **Image** or **BackgroundImage** property of the control.
01. Select the ellipsis (:::image type="icon" source="../media/shared/visual-studio-ellipsis-button.png" border="false":::) to display the **Select Resource** dialog box and then select the image you want to display.

    :::image type="content" source="media/how-to-add-a-picture-to-a-control/properties-image.png" alt-text="Properties dialog with image property selected":::

## Display an image - code

Set the control's `Image` or `BackgroundImage` property to an object of type <xref:System.Drawing.Image>. Generally, you'll load the image from a file by using the <xref:System.Drawing.Image.FromFile%2A> method.

In the following code example, the path set for the location of the image is the **My Pictures** folder. Most computers running the Windows operating system include this directory. This also enables users with minimal system access levels to run the application safely. The following code example requires that you already have a form with a <xref:System.Windows.Forms.PictureBox> control added.

```csharp
// Replace the image named below with your own icon.
// Note the escape character used (@) when specifying the path.
pictureBox1.Image = Image.FromFile
   (System.Environment.GetFolderPath
   (System.Environment.SpecialFolder.MyPictures)
   + @"\Image.gif");
```

```vb
' Replace the image named below with your own icon.
PictureBox1.Image = Image.FromFile _
   (System.Environment.GetFolderPath _
   (System.Environment.SpecialFolder.MyPictures) _
   & "\Image.gif")
```

## See also

- <xref:System.Drawing.Image.FromFile%2A?displayProperty=fullName>
- <xref:System.Drawing.Image?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.BackgroundImage%2A?displayProperty=fullName>
