---
title: Host Direct3D9 content in WPF
titleSuffix: ""
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Direct3D9 [WPF interoperability], hosting Direct3D9 content"
  - "WPF [WPF], hosting Direct3D9 content"
ms.assetid: 60983736-0ab5-42cc-8b16-e9fbde261a43
---
# Walkthrough: Hosting Direct3D9 Content in WPF

This walkthrough shows how to host Direct3D9 content in a Windows Presentation Foundation (WPF) application.

In this walkthrough, you perform the following tasks:

- Create a WPF project to host the Direct3D9 content.

- Import the Direct3D9 content.

- Display the Direct3D9 content by using the <xref:System.Windows.Interop.D3DImage> class.

 When you are finished, you will know how to host Direct3D9 content in a WPF application.

## Prerequisites

You need the following components to complete this walkthrough:

- Visual Studio.

- DirectX SDK 9 or later.

- A DLL that contains Direct3D9 content in a WPF-compatible format. For more information, see [WPF and Direct3D9 Interoperation](wpf-and-direct3d9-interoperation.md) and [Walkthrough: Creating Direct3D9 Content for Hosting in WPF](walkthrough-creating-direct3d9-content-for-hosting-in-wpf.md).

## Creating the WPF Project

The first step is to create the project for the WPF application.

### To create the WPF project

Create a new WPF Application project in Visual C# named `D3DHost`. For more information, see [Walkthrough: My first WPF desktop application](../getting-started/walkthrough-my-first-wpf-desktop-application.md).

MainWindow.xaml opens in the WPF Designer.

## Importing the Direct3D9 Content

You import the Direct3D9 content from an unmanaged DLL by using the `DllImport` attribute.

### To import Direct3D9 content

1. Open MainWindow.xaml.cs in the Code Editor.

2. Replace the automatically generated code with the following code.

    [!code-csharp[System.Windows.Interop.D3DImage#1](~/samples/snippets/csharp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/CS/window1.xaml.cs#1)]

## Hosting the Direct3D9 Content

Finally, use the <xref:System.Windows.Interop.D3DImage> class to host the Direct3D9 content.

### To host the Direct3D9 content

1. In MainWindow.xaml, replace the automatically generated XAML with the following XAML.

    [!code-xaml[System.Windows.Interop.D3DImage#10](~/samples/snippets/csharp/VS_Snippets_Wpf/System.Windows.Interop.D3DImage/CS/window1.xaml#10)]

2. Build the project.

3. Copy the DLL that contains the Direct3D9 content to the bin/Debug folder.

4. Press F5 to run the project.

    The Direct3D9 content appears within the WPF application.

## See also

- <xref:System.Windows.Interop.D3DImage>
- [Performance Considerations for Direct3D9 and WPF Interoperability](performance-considerations-for-direct3d9-and-wpf-interoperability.md)
