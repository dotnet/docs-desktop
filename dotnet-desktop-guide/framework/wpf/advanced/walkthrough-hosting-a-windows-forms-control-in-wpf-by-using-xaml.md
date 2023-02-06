---
title: Host a Windows Forms control in WPF using XAML
titleSuffix: ""
ms.date: "03/30/2017"
helpviewer_keywords:
  - "hosting Windows Forms control in WPF [WPF]"
ms.assetid: 1aef42cb-4cfb-44b4-9a7a-c02632d3d9c7
description: Learn how to host a Windows Forms MaskedTextBox control on a Windows Presentation Foundation page by using XAML.
---
# Walkthrough: Hosting a Windows Forms Control in WPF by Using XAML

WPF provides many controls with a rich feature set. However, you may sometimes want to use Windows Forms controls on your WPF pages. For example, you may have a substantial investment in existing Windows Forms controls, or you may have a Windows Forms control that provides unique functionality.  
  
 This walkthrough shows you how to host a Windows Forms <xref:System.Windows.Forms.MaskedTextBox?displayProperty=nameWithType> control on a WPF page by using XAML.  
  
 For a complete code listing of the tasks shown in this walkthrough, see [Hosting a Windows Forms Control in WPF by Using XAML Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Migration%20and%20Interoperability/HostingWfInWpfWithXaml).
  
## Prerequisites  

You need Visual Studio to complete this walkthrough.  
  
## Hosting the Windows Forms Control  
  
#### To host the MaskedTextBox control  
  
1. Create a WPF Application project named `HostingWfInWpfWithXaml`.  
  
2. Add references to the following assemblies.  
  
    - WindowsFormsIntegration  
  
    - System.Windows.Forms  
  
3. Open MainWindow.xaml in the WPF Designer.  
  
4. In the <xref:System.Windows.Window> element, add the following namespace mapping. The `wf` namespace mapping establishes a reference to the assembly that contains the Windows Forms control.  
  
    ```xaml  
    xmlns:wf="clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms"  
    ```  
  
5. In the <xref:System.Windows.Controls.Grid> element add the following XAML.  
  
     The <xref:System.Windows.Forms.MaskedTextBox> control is created as a child of the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control.  
  
     [!code-xaml[HostingWfInWpfWithXaml#3](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingWfInWpfWithXaml/CSharp/HostingWfInWpf/Window1.xaml#3)]  
  
6. Press F5 to build and run the application.  
  
## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
- [Walkthrough: Hosting a Windows Forms Control in WPF](walkthrough-hosting-a-windows-forms-control-in-wpf.md)
- [Walkthrough: Hosting a Windows Forms Composite Control in WPF](walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)
- [Walkthrough: Hosting a WPF Composite Control in Windows Forms](walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
- [Windows Forms Controls and Equivalent WPF Controls](windows-forms-controls-and-equivalent-wpf-controls.md)
- [Hosting a Windows Forms Control in WPF by Using XAML Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Migration%20and%20Interoperability/HostingWfInWpfWithXaml)
