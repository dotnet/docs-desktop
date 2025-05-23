---
title: "PictureBox Control Overview"
description: This article provides an overview of the PictureBox control in Windows Forms, which is used to display graphics in bitmap, GIF, JPEG, metafile, or icon format.
ms.date: 06/12/2024
ms.service: dotnet-framework
f1_keywords:
  - "PictureBox"
helpviewer_keywords:
  - "PictureBox control [Windows Forms], about PictureBox controls"
  - "picture controls [Windows Forms], about picture controls"
  - "image controls [Windows Forms], about image controls"
ms.assetid: e5befee7-dc29-4888-a7c4-3b177e394112
---
# PictureBox Control Overview (Windows Forms)

The Windows Forms <xref:System.Windows.Forms.PictureBox> control is used to display graphics in bitmap, GIF, JPEG, metafile, or icon format.

## Key Properties and Methods

The picture that is displayed is determined by the <xref:System.Windows.Forms.PictureBox.Image%2A> property, which can be set at run time or at design time. You can alternatively specify the image by setting the <xref:System.Windows.Forms.PictureBox.ImageLocation%2A> property and then load the image synchronously using the <xref:System.Windows.Forms.PictureBox.Load%2A> method or asynchronously using the <xref:System.Windows.Forms.PictureBox.LoadAsync%2A> method. The <xref:System.Windows.Forms.PictureBox.SizeMode%2A> property controls how the image and control fit with each other. For more information, see [How to: Modify the Size or Placement of a Picture at Run Time](how-to-modify-the-size-or-placement-of-a-picture-at-run-time-windows-forms.md).

## Transparent images

The following image formats are supported for transparency:

- 32-bit PNG
- 8-bit PNG
- 32-bit BMP
- 32-bit TIFF
- GIF

Image transparency doesn't show other controls behind the `PictureBox` control. It only shows the background of the control.

## See also

- <xref:System.Windows.Forms.PictureBox>
- [How to: Load a Picture Using the Designer](how-to-load-a-picture-using-the-designer-windows-forms.md)
- [How to: Modify the Size or Placement of a Picture at Run Time](how-to-modify-the-size-or-placement-of-a-picture-at-run-time-windows-forms.md)
- [How to: Set Pictures at Run Time](how-to-set-pictures-at-run-time-windows-forms.md)
- [PictureBox Control](picturebox-control-windows-forms.md)
