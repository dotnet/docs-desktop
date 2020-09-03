---
title: "Walkthrough: Localizing a Hybrid Application"
ms.date: 08/18/2018
helpviewer_keywords:
  - "localization [WPF interoperability]"
  - "hybrid applications [WPF interoperability]"
ms.assetid: fbc0c54e-930a-4c13-8e9c-27b83665010a
---
# Walkthrough: Localizing a Hybrid Application

This walkthrough shows you how to localize [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] elements in a Windows Forms-based hybrid application.

Tasks illustrated in this walkthrough include:

- Creating the Windows Forms host project.

- Adding localizable content.

- Enabling localization.

- Assigning resource identifiers.

- Using the LocBaml tool to produce a satellite assembly.

For a complete code listing of the tasks illustrated in this walkthrough, see [Localizing a Hybrid Application Sample](https://go.microsoft.com/fwlink/?LinkID=160015).

When you are finished, you will have a localized hybrid application.

## Prerequisites

You need the following components to complete this walkthrough:

- Visual Studio 2017

## Creating the Windows Forms Host Project

The first step is to create the Windows Forms application project and add a [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] element with content that you will localize.

### To create the host project

1. Create a **WPF App** project named `LocalizingWpfInWf`.  (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **WPF Application**).

2. Add a [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)]<xref:System.Windows.Controls.UserControl> element called `SimpleControl` to the project.

3. Use the <xref:System.Windows.Forms.Integration.ElementHost> control to place a `SimpleControl` element on the form. For more information, see [Walkthrough: Hosting a 3D WPF Composite Control in Windows Forms](walkthrough-hosting-a-3-d-wpf-composite-control-in-windows-forms.md).

## Adding Localizable Content

Next, you will add a Windows Forms label control and set the [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] element's content to a localizable string.

### To add localizable content

1. In **Solution Explorer**, double-click **SimpleControl.xaml** to open it in the WPF Designer.

2. Set the content of the <xref:System.Windows.Controls.Button> control using the following code.

     [!code-xaml[LocalizingWpfInWf#10](~/samples/snippets/csharp/VS_Snippets_Wpf/LocalizingWpfInWf/CSharp/SimpleControl0.xaml#10)]

3. In **Solution Explorer**, double-click **Form1** to open it in the Windows Forms Designer.

4. Open the **Toolbox** and double-click **Label** to add a label control to the form. Set the value of its <xref:System.Windows.Forms.Control.Text%2A> property to `"Hello"`.

5. Press **F5** to build and run the application.

     Both the `SimpleControl` element and the label control display the text **"Hello"**.

## Enabling Localization

The Windows Forms Designer provides settings for enabling localization in a satellite assembly.

### To enable localization

1. In **Solution Explorer**, double-click **Form1.cs** to open it in the Windows Forms Designer.

2. In the **Properties** window, set the value of the form's **Localizable** property to `true`.

3. In the **Properties** window, set the value of the **Language** property to **Spanish (Spain)**.

4. In the Windows Forms Designer, select the label control.

5. In the **Properties** window, set the value of the <xref:System.Windows.Forms.Control.Text%2A> property to `"Hola"`.

     A new resource file named Form1.es-ES.resx is added to the project.

6. In **Solution Explorer**, right-click **Form1.cs** and click **View Code** to open it in the Code Editor.

7. Copy the following code into the `Form1` constructor, preceding the call to `InitializeComponent`.

     [!code-csharp[LocalizingWpfInWf#2](~/samples/snippets/csharp/VS_Snippets_Wpf/LocalizingWpfInWf/CSharp/Form1.cs#2)]

8. In **Solution Explorer**, right-click **LocalizingWpfInWf** and click **Unload Project**.

     The project name is labeled **(unavailable)**.

9. Right-click **LocalizingWpfInWf**, and click **Edit LocalizingWpfInWf.csproj**.

     The project file opens in the Code Editor.

10. Copy the following line into the first `PropertyGroup` in the project file.

    ```xml
    <UICulture>en-US</UICulture>
    ```

11. Save the project file and close it.

12. In **Solution Explorer**, right-click **LocalizingWpfInWf** and click **Reload Project**.

## Assigning Resource Identifiers

You can map your localizable content to resource assemblies by using resource identifiers. The MsBuild.exe application automatically assigns resource identifiers when you specify the `updateuid` option.

### To assign resource identifiers

1. From the Start Menu, open the Developer Command Prompt for Visual Studio.

2. Use the following command to assign resource identifiers to your localizable content.

    ```console
    msbuild -t:updateuid LocalizingWpfInWf.csproj
    ```

3. In **Solution Explorer**, double-click **SimpleControl.xaml** to open it in the Code Editor. You will see that the `msbuild` command has added the `Uid` attribute to all the elements. This facilitates localization through the assignment of resource identifiers.

     [!code-xaml[LocalizingWpfInWf#20](~/samples/snippets/csharp/VS_Snippets_Wpf/LocalizingWpfInWf/CSharp/SimpleControl.xaml#20)]

4. Press **F6** to build the solution.

## Using LocBaml to Produce a Satellite Assembly

Your localized content is stored in a resource-only *satellite assembly*. Use the command-line tool LocBaml.exe to produce a localized assembly for your [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] content.

### To produce a satellite assembly

1. Copy LocBaml.exe to your project's obj\Debug folder. For more information, see [Localize an Application](how-to-localize-an-application.md).

2. In the Command Prompt window, use the following command to extract resource strings into a temporary file.

    ```console
    LocBaml /parse LocalizingWpfInWf.g.en-US.resources /out:temp.csv
    ```

3. Open the temp.csv file with Visual Studio or another text editor. Replace the string `"Hello"` with its Spanish translation, `"Hola"`.

4. Save the temp.csv file.

5. Use the following command to generate the localized resource file.

    ```console
    LocBaml /generate /trans:temp.csv LocalizingWpfInWf.g.en-US.resources /out:. /cul:es-ES
    ```

     The LocalizingWpfInWf.g.es-ES.resources file is created in the obj\Debug folder.

6. Use the following command to build the localized satellite assembly.

    ```console
    Al.exe /out:LocalizingWpfInWf.resources.dll /culture:es-ES /embed:LocalizingWpfInWf.Form1.es-ES.resources /embed:LocalizingWpfInWf.g.es-ES.resources
    ```

     The LocalizingWpfInWf.resources.dll file is created in the obj\Debug folder.

7. Copy the LocalizingWpfInWf.resources.dll file to the project's bin\Debug\es-ES folder. Replace the existing file.

8. Run LocalizingWpfInWf.exe, which is located in your project's bin\Debug folder. Do not rebuild the application or the satellite assembly will be overwritten.

     The application shows the localized strings instead of the English strings.

## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Localize an Application](how-to-localize-an-application.md)
- [Walkthrough: Localizing Windows Forms](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/y99d1cd3(v=vs.100))
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
