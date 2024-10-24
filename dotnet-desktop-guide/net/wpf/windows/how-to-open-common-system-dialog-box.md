---
title: How to open a common dialog box
description: Learn about how to show a system dialog box in Windows Foundation Presentation (WPF). System dialog boxes prompt users for information.
ms.date: 10/24/2024
ms.custom: update-template
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "system dialog boxes [WPF]"
  - "dialog boxes [WPF]"
  - "modal dialog boxes [WPF]"
---

# How to open a common dialog box (WPF .NET)

This article demonstrates how you can display a common system dialog box in Windows Presentation Foundation (WPF). Windows implements different kinds of reusable dialog boxes that are common to all applications, including dialog boxes for selecting files and printing.

Since these dialog boxes are provided by the operating system, they're shared among all the applications that run on the operating system. These dialog boxes provide a consistent user experience, and are known as *common dialog boxes*. As a user uses a common dialog box in one application, they don't need to learn how to use that dialog box in other applications.

A message box is another common dialog box. For more information, see [How to open a message box](how-to-open-message-box.md).

## Open File dialog box

The open file dialog box is used by file opening functionality to retrieve the name of a file to open.

:::image type="content" source="media/how-to-open-common-system-dialog-box/open-file-dialog-box.png" alt-text="An Open dialog box showing the location to retrieve the file shown from a WPF application.":::

The common open file dialog box is implemented as the <xref:Microsoft.Win32.OpenFileDialog> class and is located in the <xref:Microsoft.Win32> namespace. The following code shows how to create, configure, and show the dialog.

:::code language="csharp" source="snippets/how-to-open-common-system-dialog-box/csharp/Window1.xaml.cs" id="OpenFile":::
:::code language="vb" source="snippets/how-to-open-common-system-dialog-box/vb/Window1.xaml.vb" id="OpenFile":::

For more information on the open file dialog box, see <xref:Microsoft.Win32.OpenFileDialog?displayProperty=nameWithType>.

## Save File dialog box

The save file dialog box is used by file saving functionality to retrieve the name of a file to save.

:::image type="content" source="media/how-to-open-common-system-dialog-box/save-file-dialog-box.png" alt-text="A Save As dialog box showing the location to save the file shown from a WPF application.":::

The common save file dialog box is implemented as the <xref:Microsoft.Win32.SaveFileDialog> class, and is located in the <xref:Microsoft.Win32> namespace. The following code shows how to create, configure, and show the dialog.

:::code language="csharp" source="snippets/how-to-open-common-system-dialog-box/csharp/Window1.xaml.cs" id="SaveFile":::
:::code language="vb" source="snippets/how-to-open-common-system-dialog-box/vb/Window1.xaml.vb" id="SaveFile":::

For more information on the save file dialog box, see <xref:Microsoft.Win32.SaveFileDialog?displayProperty=nameWithType>.

## Open Folder dialog box

> [!IMPORTANT]
> The Open Folder dialog box is available in .NET 8.0 and later.

The Open Folder dialog box is used by the user to select one or more folders, and return them to the program. For example, if your program displayed information about a folder, such as the amount of files and the file names in the folder, you can use the Open Folder dialog to let the user choose the folder.

:::image type="content" source="media/how-to-open-common-system-dialog-box/open-folder-dialog-box.png" alt-text="An Open Folder dialog box showing the Pictures folder with the Camera Roll folder selected, shown from a WPF application.":::

The common open folder dialog box is implemented as the <xref:Microsoft.Win32.OpenFolderDialog> class, and is located in the <xref:Microsoft.Win32> namespace. The following code shows how to create, configure, and show the dialog.

:::code language="csharp" source="snippets/how-to-open-common-system-dialog-box/csharp/Window1.xaml.cs" id="OpenFolder":::
:::code language="vb" source="snippets/how-to-open-common-system-dialog-box/vb/Window1.xaml.vb" id="OpenFolder":::

For more information on the open folder dialog box, see <xref:Microsoft.Win32.OpenFolderDialog?displayProperty=nameWithType>.

## Print dialog box

The print dialog box is used by printing functionality to choose and configure the printer that a user wants to print data to.

:::image type="content" source="media/how-to-open-common-system-dialog-box/print-data-dialog-box-win11.png" alt-text="A print dialog box shown from a WPF application.":::

The common print dialog box is implemented as the <xref:System.Windows.Controls.PrintDialog> class, and is located in the <xref:System.Windows.Controls> namespace. The following code shows how to create, configure, and show one.

:::code language="csharp" source="snippets/how-to-open-common-system-dialog-box/csharp/Window1.xaml.cs" id="Print":::
:::code language="vb" source="snippets/how-to-open-common-system-dialog-box/vb/Window1.xaml.vb" id="Print":::

For more information on the print dialog box, see <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType>. For detailed discussion of printing in WPF, see [Printing overview](../documents/printing-overview.md).

## See also

- [How to open a message box](how-to-open-message-box.md)
- [Dialog boxes overview](dialog-boxes-overview.md)
- [Overview of WPF windows](index.md)
- <xref:Microsoft.Win32.OpenFileDialog?displayProperty=fullName>
- <xref:Microsoft.Win32.SaveFileDialog?displayProperty=fullName>
- <xref:System.Windows.Controls.PrintDialog?displayProperty=fullName>
