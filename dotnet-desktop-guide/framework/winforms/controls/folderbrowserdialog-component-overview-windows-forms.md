---
title: "FolderBrowserDialog Component Overview"
ms.date: "03/30/2017"
f1_keywords:
  - "FolderBrowserDialog"
helpviewer_keywords:
  - "FolderBrowserDialog component [Windows Forms], about FolderBrowserDialog"
  - "directories [Windows Forms], enabling browsing in applications"
  - "folders [Windows Forms], enabling browsing in applications"
ms.assetid: 796b622c-3ba9-4356-93bb-e217fc52f2c7
---
# FolderBrowserDialog Component Overview (Windows Forms)

The Windows Forms <xref:System.Windows.Forms.FolderBrowserDialog> component is a modal dialog box that is used for browsing and selecting folders. New folders can also be created from within the <xref:System.Windows.Forms.FolderBrowserDialog> component.

> [!NOTE]
> To select files, instead of folders, use the [OpenFileDialog](openfiledialog-component-windows-forms.md) component.

The <xref:System.Windows.Forms.FolderBrowserDialog> component is displayed at run time using the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method. Set the <xref:System.Windows.Forms.FolderBrowserDialog.RootFolder%2A> property to determine the top-most folder and any subfolders that will appear within the tree view of the dialog box. Once the dialog box has been shown, you can use the <xref:System.Windows.Forms.FolderBrowserDialog.SelectedPath%2A> property to get the path of the folder that was selected.

When it is added to a form, the <xref:System.Windows.Forms.FolderBrowserDialog> component appears in the tray at the bottom of the Windows Forms Designer in Visual Studio.

## See also

- <xref:System.Windows.Forms.FolderBrowserDialog>
- [How to: Choose Folders with the Windows Forms FolderBrowserDialog Component](how-to-choose-folders-with-the-windows-forms-folderbrowserdialog-component.md)
- [FolderBrowserDialog Component](folderbrowserdialog-component-windows-forms.md)
