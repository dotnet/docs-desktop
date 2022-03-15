---
title: Host a Windows Forms control in WPF
description: Learn how to host Windows Forms controls in Windows Presentation Foundation, which already provides many controls with a rich feature set.
titleSuffix: ""
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "hosting Windows Forms control in WPF [WPF]"
ms.assetid: 9cb88415-39b0-4c46-80c4-ff325b674286
---
# Walkthrough: Hosting a Windows Forms Control in WPF

WPF provides many controls with a rich feature set. However, you may sometimes want to use Windows Forms controls on your WPF pages. For example, you may have a substantial investment in existing Windows Forms controls, or you may have a Windows Forms control that provides unique functionality.

This walkthrough shows you how to host a Windows Forms <xref:System.Windows.Forms.MaskedTextBox?displayProperty=nameWithType> control on a WPF page by using code.

For a complete code listing of the tasks shown in this walkthrough, see [Hosting a Windows Forms Control in WPF Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Migration%20and%20Interoperability/HostingWfInWPF).

## Prerequisites

You need Visual Studio to complete this walkthrough.

## Hosting the Windows Forms Control

### To host the MaskedTextBox control

1. Create a WPF Application project named `HostingWfInWpf`.

2. Add references to the following assemblies.

    - WindowsFormsIntegration

    - System.Windows.Forms

3. Open MainWindow.xaml in the WPF Designer.

4. Name the <xref:System.Windows.Controls.Grid> element `grid1`.

     [!code-xaml[HostingWfInWPF#1](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingWfInWPF/CSharp/HostingWfInWPF/Window1.xaml#1)]

5. In Design view or XAML view, select the <xref:System.Windows.Window> element.

6. In the Properties window, click the **Events** tab.

7. Double-click the <xref:System.Windows.FrameworkElement.Loaded> event.

8. Insert the following code to handle the <xref:System.Windows.FrameworkElement.Loaded> event.

     [!code-csharp[HostingWfInWPF#10](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingWfInWPF/CSharp/HostingWfInWPF/Window1.xaml.cs#10)]
     [!code-vb[HostingWfInWPF#10](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HostingWfInWPF/VisualBasic/HostingWfInWpf/Window1.xaml.vb#10)]

9. At the top of the file, add the following `Imports` or `using` statement.

     [!code-csharp[HostingWfInWPF#11](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingWfInWPF/CSharp/HostingWfInWPF/Window1.xaml.cs#11)]
     [!code-vb[HostingWfInWPF#11](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HostingWfInWPF/VisualBasic/HostingWfInWpf/Window1.xaml.vb#11)]

10. Press **F5** to build and run the application.

## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
- [Walkthrough: Hosting a Windows Forms Control in WPF by Using XAML](walkthrough-hosting-a-windows-forms-control-in-wpf-by-using-xaml.md)
- [Walkthrough: Hosting a Windows Forms Composite Control in WPF](walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)
- [Walkthrough: Hosting a WPF Composite Control in Windows Forms](walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
- [Windows Forms Controls and Equivalent WPF Controls](windows-forms-controls-and-equivalent-wpf-controls.md)
- [Hosting a Windows Forms Control in WPF Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Migration%20and%20Interoperability/HostingWfInWPF)
