---
title: Host an ActiveX control in WPF
titleSuffix: ""
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "ActiveX controls [WPF interoperability]"
  - "hosting ActiveX controls [WPF]"
ms.assetid: 1931d292-0dd1-434f-963c-dcda7638d75a
description: Learn how to host the Microsoft Windows Media Player as a control on a Windows Presentation Foundation page.
---
# Walkthrough: Hosting an ActiveX Control in WPF

To enable improved interaction with browsers, you can use Microsoft ActiveX controls in your WPF-based application. This walkthrough demonstrates how you can host the Microsoft Windows Media Player as a control on a WPF page.

 Tasks illustrated in this walkthrough include:

- Creating the project.

- Creating the ActiveX control.

- Hosting the ActiveX control on a WPF Page.

 When you have completed this walkthrough, you will understand how to use Microsoft ActiveX controls in your WPF-based application.

## Prerequisites

 You need the following components to complete this walkthrough:

- Microsoft Windows Media Player installed on the computer where Visual Studio is installed.

- Visual Studio 2010.

## Creating the Project

### To create and set up the project

1. Create a WPF Application project named `HostingAxInWpf`.

2. Add a Windows Forms Control Library project to the solution, and name the project `WmpAxLib`.

3. In the WmpAxLib project, add a reference to the Windows Media Player assembly, which is named wmp.dll.

4. Open the **Toolbox**.

5. Right-click in the **Toolbox**, and then click **Choose Items**.

6. Click the **COM Components** tab, select the **Windows Media Player** control, and then click **OK**.

     The Windows Media Player control is added to the **Toolbox**.

7. In Solution Explorer, right-click the **UserControl1** file, and then click **Rename**.

8. Change the name to `WmpAxControl.vb` or `WmpAxControl.cs`, depending on the language.

9. If you are prompted to rename all references, click **Yes**.

## Creating the ActiveX Control

Visual Studio automatically generates an <xref:System.Windows.Forms.AxHost> wrapper class for a Microsoft ActiveX control when the control is added to a design surface. The following procedure creates a managed assembly named AxInterop.WMPLib.dll.

### To create the ActiveX control

1. Open WmpAxControl.vb or WmpAxControl.cs in the Windows Forms Designer.

2. From the **Toolbox**, add the Windows Media Player control to the design surface.

3. In the Properties window, set the value of the Windows Media Player control's <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.

4. Build the WmpAxLib control library project.

## Hosting the ActiveX Control on a WPF Page

### To host the ActiveX control

1. In the HostingAxInWpf project, add a reference to the generated ActiveX interoperability assembly.

     This assembly is named AxInterop.WMPLib.dll and was added to the Debug folder of the WmpAxLib project when you imported the Windows Media Player control.

2. Add a reference to the WindowsFormsIntegration assembly, which is named WindowsFormsIntegration.dll.

3. Add a reference to the Windows Forms assembly, which is named System.Windows.Forms.dll.

4. Open MainWindow.xaml in the WPF Designer.

5. Name the <xref:System.Windows.Controls.Grid> element `grid1`.

     [!code-xaml[HostingAxInWpf#1](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingAxInWpf/CSharp/HostingAxInWpf/window1.xaml#1)]

6. In Design view or XAML view, select the <xref:System.Windows.Window> element.

7. In the Properties window, click the **Events** tab.

8. Double-click the <xref:System.Windows.FrameworkElement.Loaded> event.

9. Insert the following code to handle the <xref:System.Windows.FrameworkElement.Loaded> event.

     This code creates an instance of the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control and adds an instance of the `AxWindowsMediaPlayer` control as its child.

     [!code-csharp[HostingAxInWpf#11](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingAxInWpf/CSharp/HostingAxInWpf/window1.xaml.cs#11)]
     [!code-vb[HostingAxInWpf#11](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HostingAxInWpf/VisualBasic/HostingAxInWpf/window1.xaml.vb#11)]  
  
10. Press F5 to build and run the application.  
  
## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
- [Walkthrough: Hosting a Windows Forms Composite Control in WPF](walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)
- [Walkthrough: Hosting a WPF Composite Control in Windows Forms](walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
