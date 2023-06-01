---
title: What is Windows Presentation Foundation
description: This article gives an overview of WPF with .NET.
ms.date: 02/15/2023
ms.topic: overview
dev_langs: 
  - "csharp"
  - "vb"
#Customer intent: As a developer, I want to understand the components of WPF so that I can understand the overall picture of WPF.
---

# Desktop Guide (WPF .NET)

Welcome to the Desktop Guide for Windows Presentation Foundation (WPF), a UI framework that is resolution-independent and uses a vector-based rendering engine, built to take advantage of modern graphics hardware. WPF provides a comprehensive set of application-development features that include Extensible Application Markup Language (XAML), controls, data binding, layout, 2D and 3D graphics, animation, styles, templates, documents, media, text, and typography. WPF is part of .NET, so you can build applications that incorporate other elements of the .NET API.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

There are two implementations of WPF:

01. **.NET** version (this guide):

    An open-source implementation of WPF hosted on [GitHub](https://github.com/dotnet/wpf), which runs on .NET. The XAML designer requires, at a minimum, [Visual Studio 2019 version 16.8](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+desktopguide+wpf). But depending on your version of .NET, you may be required to use a newer version of Visual Studio.

    Even though .NET is a cross-platform technology, WPF only runs on Windows.

01. **.NET Framework 4** version:

    The .NET Framework implementation of WPF that's supported by Visual Studio 2019 and Visual Studio 2017.

    .NET Framework 4 is a Windows-only version of .NET and is considered a Windows Operating System component. This version of WPF is distributed with .NET Framework. For more information about the .NET Framework version of WPF, see [Introduction to WPF for .NET Framework](../../../framework/wpf/introduction-to-wpf.md?view=netframeworkdesktop-4.8&preserve-view=true).

This overview is intended for newcomers and covers the key capabilities and concepts of WPF. To learn how to create a WPF app, see [Tutorial: Create a new WPF app](../get-started/create-app-visual-studio.md).

## Why upgrade from .NET Framework

When you are upgrading your application from .NET Framework to .NET, you will benefit from:

- Better performance
- New .NET APIs
- The latest language improvements
- Improved accessibility and reliability
- Updated tooling and more

To learn how to upgrade your application, see [How to upgrade a WPF desktop app to .NET 7](../migration/index.md).

## Program with WPF

WPF exists as a subset of .NET types that are, mostly located in the <xref:System.Windows> namespace. If you have previously built applications with .NET with frameworks like ASP.NET and Windows Forms, the fundamental WPF programming experience should be familiar, you:

- Instantiate classes
- Set properties
- Call methods
- Handle events

WPF includes more programming constructs that enhance properties and events: [dependency properties](../properties/dependency-properties-overview.md) and [routed events](../events/routed-events-overview.md).

## Markup and code-behind

WPF lets you develop an application using both *markup* and *code-behind*, an experience with which ASP.NET developers should be familiar. You generally use XAML markup to implement the appearance of an application while using managed programming languages (code-behind) to implement its behavior. This separation of appearance and behavior has the following benefits:

- Development and maintenance costs are reduced because appearance-specific markup isn't tightly coupled with behavior-specific code.

- Development is more efficient because designers can implement an application's appearance simultaneously with developers who are implementing the application's behavior.

- [Globalization and localization](../../../framework/wpf/advanced/wpf-globalization-and-localization-overview.md) for WPF applications is simplified.

### Markup

XAML is an XML-based markup language that implements an application's appearance declaratively. You typically use it to define windows, dialog boxes, pages, and user controls, and to fill them with controls, shapes, and graphics.

The following example uses XAML to implement the appearance of a window that contains a single button:

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    Title="Window with Button"
    Width="250" Height="100">

  <!-- Add button to window -->
  <Button Name="button">Click Me!</Button>

</Window>
```

Specifically, this XAML defines a window and a button by using the `Window` and `Button` elements. Each element is configured with attributes, such as the `Window` element's `Title` attribute to specify the window's title-bar text. At run time, WPF converts the elements and attributes that are defined in markup to instances of WPF classes. For example, the `Window` element is converted to an instance of the <xref:System.Windows.Window> class whose <xref:System.Windows.Window.Title%2A> property is the value of the `Title` attribute.

The following figure shows the user interface (UI) that is defined by the XAML in the previous example:

:::image type="content" source="media/index/markup-window-button.png" alt-text="A window that contains a button":::

Since XAML is XML-based, the UI that you compose with it's assembled in a hierarchy of nested elements that is known as an [element tree](../../../framework/wpf/advanced/trees-in-wpf.md). The element tree provides a logical and intuitive way to create and manage UIs.

### Code-behind

The main behavior of an application is to implement the functionality that responds to user interactions. For example clicking a menu or button, and calling business logic and data access logic in response. In WPF, this behavior is implemented in code that is associated with markup. This type of code is known as code-behind. The following example shows the updated markup from the previous example and the code-behind:

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.AWindow"
    Title="Window with Button"
    Width="250" Height="100">

  <!-- Add button to window -->
  <Button Name="button" Click="button_Click">Click Me!</Button>

</Window>
```

The updated markup defines the `xmlns:x` namespace and maps it to the schema that adds support for the code-behind types. The `x:Class` attribute is used to associate a code-behind class to this specific XAML markup. Considering this attribute is declared on the `<Window>` element, the code-behind class must inherit from the `Window` class.

```csharp
using System.Windows;

namespace SDKSample
{
    public partial class AWindow : Window
    {
        public AWindow()
        {
            // InitializeComponent call is required to merge the UI
            // that is defined in markup with this class, including  
            // setting properties and registering event handlers
            InitializeComponent();
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Show message box when button is clicked.
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}
```

```vb
Namespace SDKSample

    Partial Public Class AWindow
        Inherits System.Windows.Window

        Public Sub New()

            ' InitializeComponent call is required to merge the UI
            ' that is defined in markup with this class, including  
            ' setting properties and registering event handlers
            InitializeComponent()

        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Show message box when button is clicked.
            MessageBox.Show("Hello, Windows Presentation Foundation!")

        End Sub

    End Class

End Namespace
```

`InitializeComponent` is called from the code-behind class's constructor to merge the UI that is defined in markup with the code-behind class. (`InitializeComponent` is generated for you when your application is built, which is why you don't need to implement it manually.) The combination of `x:Class` and `InitializeComponent` ensure that your implementation is correctly initialized whenever it's created.

Notice that in the markup the `<Button>` element defined a value of `button_click` for the `Click` attribute. With the markup and code-behind initialized and working together, the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event for the button is automatically mapped to the `button_click` method. When the button is clicked, the event handler is invoked and a message box is displayed by calling the <xref:System.Windows.MessageBox.Show%2A?displayProperty=fullName> method.

The following figure shows the result when the button is clicked:

:::image type="content" source="media/index/markup-window-button-clicked.png" alt-text="A MessageBox":::

## Input and commands

Controls most often detect and respond to user input. The WPF input system uses both direct and routed events to support text input, focus management, and mouse positioning.

Applications often have complex input requirements. WPF provides a command system that separates user-input actions from the code that responds to those actions. The command system allows for multiple sources to invoke the same command logic. For example, take the common editing operations used by different applications: **Copy**, **Cut**, and **Paste**. These operations can be invoked by using different user actions if they're implemented by using commands.

## Controls

The user experiences that are delivered by the application model are constructed controls. In WPF, *control* is an umbrella term that applies to a category of WPF classes that have the following characteristics:

- Hosted in either a window or a page.
- Have a user interface.
- Implement some behavior.

For more information, see [Controls](../../../framework/wpf/controls/index.md).

### WPF controls by function

The built-in WPF controls are listed here:

- **Buttons**: <xref:System.Windows.Controls.Button> and <xref:System.Windows.Controls.Primitives.RepeatButton>.

- **Data Display**: <xref:System.Windows.Controls.DataGrid>, <xref:System.Windows.Controls.ListView>, and <xref:System.Windows.Controls.TreeView>.

- **Date Display and Selection**: <xref:System.Windows.Controls.Calendar> and <xref:System.Windows.Controls.DatePicker>.

- **Dialog Boxes**: <xref:Microsoft.Win32.OpenFileDialog>, <xref:System.Windows.Controls.PrintDialog>, and <xref:Microsoft.Win32.SaveFileDialog>.

- **Digital Ink**: <xref:System.Windows.Controls.InkCanvas> and <xref:System.Windows.Controls.InkPresenter>.

- **Documents**: <xref:System.Windows.Controls.DocumentViewer>, <xref:System.Windows.Controls.FlowDocumentPageViewer>, <xref:System.Windows.Controls.FlowDocumentReader>, <xref:System.Windows.Controls.FlowDocumentScrollViewer>, and <xref:System.Windows.Controls.StickyNoteControl>.

- **Input**: <xref:System.Windows.Controls.TextBox>, <xref:System.Windows.Controls.RichTextBox>, and <xref:System.Windows.Controls.PasswordBox>.

- **Layout**: <xref:System.Windows.Controls.Border>, <xref:System.Windows.Controls.Primitives.BulletDecorator>, <xref:System.Windows.Controls.Canvas>, <xref:System.Windows.Controls.DockPanel>, <xref:System.Windows.Controls.Expander>, <xref:System.Windows.Controls.Grid>, <xref:System.Windows.Controls.GridView>, <xref:System.Windows.Controls.GridSplitter>, <xref:System.Windows.Controls.GroupBox>, <xref:System.Windows.Controls.Panel>, <xref:System.Windows.Controls.Primitives.ResizeGrip>, <xref:System.Windows.Controls.Separator>, <xref:System.Windows.Controls.Primitives.ScrollBar>, <xref:System.Windows.Controls.ScrollViewer>, <xref:System.Windows.Controls.StackPanel>, <xref:System.Windows.Controls.Primitives.Thumb>, <xref:System.Windows.Controls.Viewbox>, <xref:System.Windows.Controls.VirtualizingStackPanel>, <xref:System.Windows.Window>, and <xref:System.Windows.Controls.WrapPanel>.

- **Media**: <xref:System.Windows.Controls.Image>, <xref:System.Windows.Controls.MediaElement>, and <xref:System.Windows.Controls.SoundPlayerAction>.

- **Menus**: <xref:System.Windows.Controls.ContextMenu>, <xref:System.Windows.Controls.Menu>, and <xref:System.Windows.Controls.ToolBar>.

- **Navigation**: <xref:System.Windows.Controls.Frame>, <xref:System.Windows.Documents.Hyperlink>, <xref:System.Windows.Controls.Page>, <xref:System.Windows.Navigation.NavigationWindow>, and <xref:System.Windows.Controls.TabControl>.

- **Selection**: <xref:System.Windows.Controls.CheckBox>, <xref:System.Windows.Controls.ComboBox>, <xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.RadioButton>, and <xref:System.Windows.Controls.Slider>.

- **User Information**: <xref:System.Windows.Controls.AccessText>, <xref:System.Windows.Controls.Label>, <xref:System.Windows.Controls.Primitives.Popup>, <xref:System.Windows.Controls.ProgressBar>, <xref:System.Windows.Controls.Primitives.StatusBar>, <xref:System.Windows.Controls.TextBlock>, and <xref:System.Windows.Controls.ToolTip>.

## Layout

When you create a user interface, you arrange your controls by location and size to form a layout. A key requirement of any layout is to adapt to changes in window size and display settings. Rather than forcing you to write the code to adapt a layout in these circumstances, WPF provides a first-class, extensible layout system for you.

The cornerstone of the layout system is relative positioning, which increases the ability to adapt to changing window and display conditions. The layout system also manages the negotiation between controls to determine the layout. The negotiation is a two-step process: first, a control tells its parent what location and size it requires. Second, the parent tells the control what space it can have.

The layout system is exposed to child controls through base WPF classes. For common layouts such as grids, stacking, and docking, WPF includes several layout controls:

- <xref:System.Windows.Controls.Canvas>: Child controls provide their own layout.

- <xref:System.Windows.Controls.DockPanel>: Child controls are aligned to the edges of the panel.

- <xref:System.Windows.Controls.Grid>: Child controls are positioned by rows and columns.

- <xref:System.Windows.Controls.StackPanel>: Child controls are stacked either vertically or horizontally.

- <xref:System.Windows.Controls.VirtualizingStackPanel>: Child controls are virtualized and arranged on a single line that is either horizontally or vertically oriented.

- <xref:System.Windows.Controls.WrapPanel>: Child controls are positioned in left-to-right order and wrapped to the next line when there isn't enough space on the current line.

The following example uses a <xref:System.Windows.Controls.DockPanel> to lay out several <xref:System.Windows.Controls.TextBox> controls:

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.LayoutWindow"
    Title="Layout with the DockPanel" Height="143" Width="319">
  
  <!--DockPanel to layout four text boxes--> 
  <DockPanel>
    <TextBox DockPanel.Dock="Top">Dock = "Top"</TextBox>
    <TextBox DockPanel.Dock="Bottom">Dock = "Bottom"</TextBox>
    <TextBox DockPanel.Dock="Left">Dock = "Left"</TextBox>
    <TextBox Background="White">This TextBox "fills" the remaining space.</TextBox>
  </DockPanel>

</Window>
```

The <xref:System.Windows.Controls.DockPanel> allows the child <xref:System.Windows.Controls.TextBox> controls to tell it how to arrange them. To do this, the <xref:System.Windows.Controls.DockPanel> implements a `Dock` attached property that is exposed to the child controls to allow each of them to specify a dock style.

> [!NOTE]
> A property that's implemented by a parent control for use by child controls is a WPF construct called an [attached property](../properties/attached-properties-overview.md).

The following figure shows the result of the XAML markup in the preceding example:

:::image type="content" source="media/index/dockpanel-page.png" alt-text="DockPanel page":::

## Data binding

Most applications are created to provide users with the means to view and edit data. For WPF applications, the work of storing and accessing data is already provided for by many different .NET data access libraries such as SQL and Entity Framework Core. After the data is accessed and loaded into an application's managed objects, the hard work for WPF applications begins. Essentially, this involves two things:

01. Copying the data from the managed objects into controls, where the data can be displayed and edited.

01. Ensuring that changes made to data by using controls are copied back to the managed objects.

To simplify application development, WPF provides a powerful data binding engine to automatically handle these steps. The core unit of the data binding engine is the <xref:System.Windows.Data.Binding> class, whose job is to bind a control (the binding target) to a data object (the binding source). This relationship is illustrated by the following figure:

:::image type="content" source="media/index/databinding-basic-diagram.png" alt-text="Basic data binding diagram":::

WPF supports declaring bindings in the XAML markup directly. For example, the following XAML code binds the <xref:System.Windows.Controls.TextBox.Text%2A> property of the <xref:System.Windows.Controls.TextBox> to the `Name` property of an object using the "`{Binding ... }`" XAML syntax. This assumes there's a data object set to the <xref:System.Windows.FrameworkElement.DataContext%2A> property of the `Window` with a `Name` property.

```xaml
 <Window
     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
     x:Class="SDKSample.DataBindingWindow">

   <!-- Bind the TextBox to the data source (TextBox.Text to Person.Name) -->
   <TextBox Name="personNameTextBox" Text="{Binding Path=Name}" />

 </Window>
```

The WPF data binding engine provides more than just binding, it provides validation, sorting, filtering, and grouping. Furthermore, data binding supports the use of data templates to create custom user interface for bound data.

For more information, see [Data binding overview](../data/index.md).

## Graphics & animation

WPF provides an extensive and flexible set of graphics features that have the following benefits:

- **Resolution-independent and device-independent graphics**. The basic unit of measurement in the WPF graphics system is the device-independent pixel, which is 1/96th of an inch, and provides the foundation for resolution-independent and device-independent rendering. Each device-independent pixel automatically scales to match the dots-per-inch (dpi) setting of the system it renders on.

- **Improved precision**. The WPF coordinate system is measured with double-precision floating-point numbers rather than single-precision. Transformations and opacity values are also expressed as double-precision. WPF also supports a wide color gamut (scRGB) and provides integrated support for managing inputs from different color spaces.

- **Advanced graphics and animation support**. WPF simplifies graphics programming by managing animation scenes for you; there's no need to worry about scene processing, rendering loops, and bilinear interpolation. Additionally, WPF provides hit-testing support and full alpha-compositing support.

- **Hardware acceleration**. The WPF graphics system takes advantage of graphics hardware to minimize CPU usage.

### 2D graphics

WPF provides a library of common vector-drawn 2D shapes, such as the rectangles and ellipses. The shapes aren't just for display; shapes implement many of the features that you expect from controls, including keyboard and mouse input.

The 2D shapes provided by WPF cover the standard set of basic shapes. However, you may need to create custom shapes to help the design of a customized user interface. WPF provides geometries to create a custom shape that can be drawn directly, used as a brush, or used to clip other shapes and controls.

For more information, see [Geometry overview](../../../framework/wpf/graphics-multimedia/geometry-overview.md).

A subset of WPF 2D capabilities includes visual effects, such as gradients, bitmaps, drawings, painting with videos, rotation, scaling, and skewing. These effects are all achieved with brushes. The following figure shows some examples:

:::image type="content" source="media/index/graphics-brushes.png" alt-text="Illustration of different brushes":::

For more information, see [WPF brushes overview](../../../framework/wpf/graphics-multimedia/wpf-brushes-overview.md).

### 3D rendering

WPF also includes 3D rendering capabilities that integrate with 2D graphics to allow the creation of more exciting and interesting user interfaces. For example, the following figure shows 2D images rendered onto 3D shapes:

:::image type="content" source="media/index/graphics-3d.png" alt-text="Visual3D sample screen shot":::

For more information, see [3D graphics overview](../../../framework/wpf/graphics-multimedia/3-d-graphics-overview.md).

### Animation

WPF animation support lets you make controls grow, shake, spin, and fade, to create interesting page transitions, and more. You can animate most WPF classes, even custom classes. The following figure shows a simple animation in action:

:::image type="content" source="media/index/animation-cube.gif" alt-text="Images of an animated cube":::

For more information, see [Animation overview](../../../framework/wpf/graphics-multimedia/animation-overview.md).

## Text and typography

To provide high-quality text rendering, WPF offers the following features:

- OpenType font support.
- ClearType enhancements.
- High performance that takes advantage of hardware acceleration.
- Integration of text with media, graphics, and animation.
- International font support and fallback mechanisms.

As a demonstration of text integration with graphics, the following figure shows the application of text decorations:

:::image type="content" source="media/index/text.png" alt-text="Text with various text decorations":::

For more information, see [Typography in Windows Presentation Foundation](../../../framework/wpf/advanced/typography-in-wpf.md).

## Customize WPF apps

Up to this point, you've seen the core WPF building blocks for developing applications:

- You use the application model to host and deliver application content, which consists mainly of controls.
- To simplify the arrangement of controls in a user interface, you use the WPF layout system.
- You use data binding to reduce the work of integrating your user interface with data.
- To enhance the visual appearance of your application, you use the comprehensive range of graphics, animation, and media support provided by WPF.

Often, though, the basics aren't enough for creating and managing a truly distinct and visually stunning user experience. The standard WPF controls might not integrate with the desired appearance of your application. Data might not be displayed in the most effective way. Your application's overall user experience may not be suited to the default look and feel of Windows themes.

For this reason, WPF provides various mechanisms for creating unique user experiences.

### Content Model

The main purpose of most of the WPF controls is to display content. In WPF, the type and number of items that can constitute the content of a control is referred to as the control's *content model*. Some controls can contain a single item and type of content. For example, the content of a <xref:System.Windows.Controls.TextBox> is a string value that is assigned to the <xref:System.Windows.Controls.TextBox.Text%2A> property.

Other controls, however, can contain multiple items of different types of content; the content of a <xref:System.Windows.Controls.Button>, specified by the <xref:System.Windows.Controls.ContentControl.Content%2A> property, can contain various items including layout controls, text, images, and shapes.

For more information on the kinds of content that is supported by various controls, see [WPF content model](../../../framework/wpf/controls/wpf-content-model.md).

### Triggers

Although the main purpose of XAML markup is to implement an application's appearance, you can also use XAML to implement some aspects of an application's behavior. One example is the use of triggers to change an application's appearance based on user interactions. For more information, see [Styles and templates](../controls/styles-templates-overview.md).

### Templates

The default user interfaces for WPF controls are typically constructed from other controls and shapes. For example, a <xref:System.Windows.Controls.Button> is composed of both <xref:Microsoft.Windows.Themes.ButtonChrome> and <xref:System.Windows.Controls.ContentPresenter> controls. The <xref:Microsoft.Windows.Themes.ButtonChrome> provides the standard button appearance, while the <xref:System.Windows.Controls.ContentPresenter> displays the button's content, as specified by the <xref:System.Windows.Controls.ContentControl.Content%2A> property.

Sometimes the default appearance of a control may conflict with the overall appearance of an application. In this case, you can use a <xref:System.Windows.Controls.ControlTemplate> to change the appearance of the control's user interface without changing its content and behavior.

For example, a <xref:System.Windows.Controls.Button> raises the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event when it's clicked. By changing the template of a button to display an <xref:System.Windows.Shapes.Ellipse> shape, the visual of the aspect of the control has changed, but the functionality hasn't. You can still click on the visual aspect of the control and the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event is raised as expected.

:::image type="content" source="media/index/template-button.png" alt-text="An elliptical button and a second window":::

### Data templates

Whereas a control template lets you specify the appearance of a control, a data template lets you specify the appearance of a control's content. Data templates are frequently used to enhance how bound data is displayed. The following figure shows the default appearance for a <xref:System.Windows.Controls.ListBox> that is bound to a collection of `Task` objects, where each task has a name, description, and priority:

:::image type="content" source="media/index/data-template-listbox-normal.png" alt-text="A list box with the default appearance":::

The default appearance is what you would expect from a <xref:System.Windows.Controls.ListBox>. However, the default appearance of each task contains only the task name. To show the task name, description, and priority, the default appearance of the <xref:System.Windows.Controls.ListBox> control's bound list items must be changed by using a <xref:System.Windows.DataTemplate>. Here is an example of applying a data template that was created for the `Task` object.

:::image type="content" source="media/index/data-template-listbox-applied.png" alt-text="List box that uses a data template":::

The <xref:System.Windows.Controls.ListBox> retains its behavior and overall appearance and only the appearance of the content being displayed by the list box has changed.

For more information, see [Data templating overview](../../../framework/wpf/data/data-templating-overview.md).

### Styles

Styles enable developers and designers to standardize on a particular appearance for their product. WPF provides a strong style model, the foundation of which is the <xref:System.Windows.Style> element. Styles can apply property values to types. They can be applied automatically to the everything according to the type or individual objects when referenced. The following example creates a style that sets the background color for every <xref:System.Windows.Controls.Button> on the window to `Orange`:

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.StyleWindow"
    Title="Styles">

    <Window.Resources>
        <!-- Style that will be applied to all buttons for this window -->
        <Style TargetType="{x:Type Button}">
            <Setter Property="Background" Value="Orange" />
            <Setter Property="BorderBrush" Value="Crimson" />
            <Setter Property="FontSize" Value="20" />
            <Setter Property="FontWeight" Value="Bold" />
            <Setter Property="Margin" Value="5" />
        </Style>
    </Window.Resources>
    <StackPanel>

        <!-- This button will have the style applied to it -->
        <Button>Click Me!</Button>

        <!-- This label will not have the style applied to it -->
        <Label>Don't Click Me!</Label>

        <!-- This button will have the style applied to it -->
        <Button>Click Me!</Button>
        
    </StackPanel>
</Window>
```

Because this style targets all <xref:System.Windows.Controls.Button> controls, the style is automatically applied to all the buttons in the window, as shown in the following figure:

:::image type="content" source="media/index/styles-buttons.png" alt-text="Two orange buttons":::

For more information, see [Styles and templates](../controls/styles-templates-overview.md).

### Resources

Controls in an application should share the same appearance, which can include anything from fonts and background colors to control templates, data templates, and styles. You can use WPF's support for user interface resources to encapsulate these resources in a single location for reuse.

The following example defines a common background color that is shared by a <xref:System.Windows.Controls.Button> and a <xref:System.Windows.Controls.Label>:

```xaml
<Window
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Class="SDKSample.ResourcesWindow"
    Title="Resources Window">

  <!-- Define window-scoped background color resource -->
  <Window.Resources>
    <SolidColorBrush x:Key="defaultBackground" Color="Red" />
  </Window.Resources>

  <!-- Button background is defined by window-scoped resource -->
  <Button Background="{StaticResource defaultBackground}">One Button</Button>

  <!-- Label background is defined by window-scoped resource -->
  <Label Background="{StaticResource defaultBackground}">One Label</Label>
</Window>
```

For more information, see [How to define and reference a WPF resource](../systems/xaml-resources-how-to-define-and-reference.md).

### Custom controls

Although WPF provides a host of customization support, you may encounter situations where existing WPF controls do not meet the needs of either your application or its users. This can occur when:

- The user interface that you require cannot be created by customizing the look and feel of existing WPF implementations.
- The behavior that you require isn't supported (or not easily supported) by existing WPF implementations.

At this point, however, you can take advantage of one of three WPF models to create a new control. Each model targets a specific scenario and requires your custom control to derive from a particular WPF base class. The three models are listed here:

- **User Control Model**\
A custom control derives from <xref:System.Windows.Controls.UserControl> and is composed of one or more other controls.

- **Control Model**
A custom control derives from <xref:System.Windows.Controls.Control> and is used to build implementations that separate their behavior from their appearance using templates, much like most WPF controls. Deriving from <xref:System.Windows.Controls.Control> allows you more freedom for creating a custom user interface than user controls, but it may require more effort.

- **Framework Element Model**.\
A custom control derives from <xref:System.Windows.FrameworkElement> when its appearance is defined by custom rendering logic (not templates).

For more information on custom controls, see [Control authoring overview](../../../framework/wpf/controls/control-authoring-overview.md).

## See also

- [Tutorial: Create a new WPF app](../get-started/create-app-visual-studio.md)
- [Migrate a WPF app to .NET](../migration/convert-project-from-net-framework.md)
- [Overview of WPF windows](../windows/index.md)
- [Data binding overview](../data/index.md)
- [XAML overview](../xaml/index.md)
