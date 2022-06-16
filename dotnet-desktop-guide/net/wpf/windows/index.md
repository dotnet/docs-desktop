---
title: Windows in WPF overview
description: Learn about the basics of how Window objects work in WPF. Learn how to create and manage a window for a Windows Presentation Foundation (WPF) app.
ms.date: "03/11/2021"
ms.topic: overview
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "XAML [WPF], displaying content via"
  - "XAML pages [WPF], displaying"
  - "content [WPF], displaying via XAML"
  - "window objects [WPF]"
  - "hosting [WPF], applications"
  - "managing windows [WPF]"
  - "dialog boxes [WPF]"
  - "Page object [WPF]"
  - "NavigationWindow objects [WPF]"
  - "applications [WPF], hosting"
  - "content [WPF], displaying"
  - "events [WPF]"
  - "content [WPF], displaying via procedural code"
  - "modal windows [WPF]"
  - "procedural code [WPF], displaying content via"
  - "displaying content via procedural code [WPF]"
  - "window management [WPF]"
  - "displaying content [WPF]"
  - "window events [WPF]"
  - "windows [WPF]"
  - "modal dialog boxes [WPF]"
  - "displaying XAML pages [WPF]"
---

# Overview of WPF windows (WPF .NET)

Users interact with Windows Presentation Foundation (WPF) applications through windows. The primary purpose of a window is to host content that visualizes data and enables users to interact with data. WPF applications provide their own windows by using the <xref:System.Windows.Window> class. This article introduces <xref:System.Windows.Window> before covering the fundamentals of creating and managing windows in applications.

> [!IMPORTANT]
> This article uses XAML generated from a **C#** project. If you're using **Visual Basic**, the XAML may look slightly different. These differences are typically present on `x:Class` attribute values. C# includes the root namespace for the project while Visual Basic doesn't.
>
> The project templates for C# create an `App` type contained in the _app.xaml_ file. In Visual Basic, the type is named `Application` and the file is named `Application.xaml`.

## The Window class

In WPF, a window is encapsulated by the <xref:System.Windows.Window> class that you use to do the following:

- Display a window.
- Configure the size, position, and appearance of a window.
- Host application-specific content.
- Manage the lifetime of a window.

The following figure illustrates the constituent parts of a window:

:::image type="content" source="./media/index/window-parts.png" alt-text="Screenshot that shows parts of a WPF window.":::

A window is divided into two areas: the non-client area and client area.

The _non-client area_ of a window is implemented by WPF and includes the parts of a window that are common to most windows, including the following:

- A title bar (1-5).
- An icon (1).
- Title (2).
- Minimize (3), Maximize (4), and Close (5) buttons.
- System menu (6) with menu items. Appears when clicking on the icon (1).
- Border (7).

The _client area_ of a window is the area within a window's non-client area and is used by developers to add application-specific content, such as menu bars, tool bars, and controls.

- Client area (8).
- Resize grip (9). This is a control added to the Client area (8).

## Implementing a window

The implementation of a typical window includes both appearance and behavior, where _appearance_ defines how a window looks to users and _behavior_ defines the way a window functions as users interact with it. In WPF, you can implement the appearance and behavior of a window using either code or XAML markup.

In general, however, the appearance of a window is implemented using XAML markup, and its behavior is implemented using code-behind, as shown in the following example.

```xaml
<Window x:Class="WindowsOverview.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WindowsOverview"
        >

    <!-- Client area containing the content of the window -->
    
</Window>
```

The following code is the code-behind for the XAML.

```csharp
using System.Windows;

namespace WindowsOverview
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
    }
}
```

```vb
Public Class Window1

End Class
```

To enable a XAML markup file and code-behind file to work together, the following are required:

- In markup, the `Window` element must include the `x:Class` attribute. When the application is built, the existence of `x:Class` attribute causes Microsoft build engine (MSBuild) to generate a `partial` class that derives from <xref:System.Windows.Window> with the name that is specified by the `x:Class` attribute. This requires the addition of an XML namespace declaration for the XAML schema (`xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`). The generated `partial` class implements the `InitializeComponent` method, which is called to register the events and set the properties that are implemented in markup.

- In code-behind, the class must be a `partial` class with the same name that is specified by the `x:Class` attribute in markup, and it must derive from <xref:System.Windows.Window>. This allows the code-behind file to be associated with the `partial` class that is generated for the markup file when the application is built, for more information, see [Compile a WPF Application](../../../framework/wpf/app-development/building-a-wpf-application-wpf.md).

- In code-behind, the <xref:System.Windows.Window> class must implement a constructor that calls the `InitializeComponent` method. `InitializeComponent` is implemented by the markup file's generated `partial` class to register events and set properties that are defined in markup.

> [!NOTE]
> When you add a new <xref:System.Windows.Window> to your project by using Visual Studio, the <xref:System.Windows.Window> is implemented using both markup and code-behind, and includes the necessary configuration to create the association between the markup and code-behind files as described here.

With this configuration in place, you can focus on defining the appearance of the window in XAML markup and implementing its behavior in code-behind. The following example shows a window with a button that defines an event handler for the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event. This is implemented in the XAML and the handler is implemented in code-behind.

```xaml
<Window x:Class="WindowsOverview.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WindowsOverview"
        >

    <!-- Client area containing the content of the window -->

    <Button Click="Button_Click">Click This Button</Button>
    
</Window>
```

The following code is the code-behind for the XAML.

```csharp
using System.Windows;

namespace WindowsOverview
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button was clicked.");
        }
    }
}
```

```vb
Public Class Window1

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Button was clicked.")
    End Sub

End Class
```

### Configuring a window for MSBuild

How you implement your window determines how it's configured for MSBuild. For a window that is defined using both XAML markup and code-behind:

- XAML markup files are configured as MSBuild `Page` items.
- Code-behind files are configured as MSBuild `Compile` items.

.NET SDK projects automatically import the correct `Page` and `Compile` items for you and you don't need to do declare these. When the project is configured for WPF, the XAML markup files are automatically imported as `Page` items, and the corresponding code-behind file is imported as `Compile`.

MSBuild projects won't automatically import the types and you must declare them yourself:

```xml
<Project>
    ...
    <Page Include="MarkupAndCodeBehindWindow.xaml" />
    <Compile Include=" MarkupAndCodeBehindWindow.xaml.cs" />
    ...
</Project>
```

For information about building WPF applications, see [Compile a WPF Application](../../../framework/wpf/app-development/building-a-wpf-application-wpf.md).

## Window lifetime

As with any class, a window has a lifetime that begins when it's first instantiated, after which it's opened, activated/deactivated, and eventually closed.

### Opening a window

To open a window, you first create an instance of it, which is demonstrated in the following example:

:::code language="csharp" source="snippets/index_2/csharp/App.xaml.cs":::
:::code language="vb" source="snippets/index_2/vb/Application.xaml.vb":::

In this example `Window1` is instantiated when the application starts, which occurs when the <xref:System.Windows.Application.Startup> event is raised. For more information about the startup window, see [How to get or set the main application window](how-to-get-set-main-application-window.md).

When a window is instantiated, a reference to it's automatically added to a [list of windows](xref:System.Windows.Application.Windows%2A) that is managed by the <xref:System.Windows.Application> object. The first window to be instantiated is automatically set by <xref:System.Windows.Application> as the [main application window](xref:System.Windows.Application.MainWindow%2A).

The window is finally opened by calling the <xref:System.Windows.Window.Show%2A> method as shown in the following image:

:::image type="content" source="./media/index/window-with-button.png" alt-text="WPF Window with a single button inside.":::

A window that is opened by calling <xref:System.Windows.Window.Show%2A> is a _modeless_ window, and the application doesn't prevent users from interacting with other windows in the application. Opening a window with <xref:System.Windows.Window.ShowDialog%2A> opens a window as _modal_ and restricts user interaction to the specific window. For more information, see [Dialog Boxes Overview](dialog-boxes-overview.md).

When <xref:System.Windows.Window.Show%2A> is called, a window does initialization work before it's shown to establish infrastructure that allows it to receive user input. When the window is initialized, the <xref:System.Windows.Window.SourceInitialized> event is raised and the window is shown.

For more information, see [How to open a window or dialog box](how-to-open-window-dialog-box.md).

#### Startup window

The previous example used the `Startup` event to run code that displayed the initial application window. As a shortcut, instead use <xref:System.Windows.Application.StartupUri%2A> to specify the path to a XAML file in your application. The application automatically creates and displays the window specified by that property.

:::code language="xaml" source="snippets/index/csharp/App.xaml" highlight="5":::

#### Window ownership

A window that is opened by using the <xref:System.Windows.Window.Show%2A> method doesn't have an implicit relationship with the window that created it. Users can interact with either window independently of the other, which means that either window can do the following:

- Cover the other (unless one of the windows has its <xref:System.Windows.Window.Topmost%2A> property set to `true`).
- Be minimized, maximized, and restored without affecting the other.

Some windows require a relationship with the window that opens them. For example, an Integrated Development Environment (IDE) application may open property windows and tool windows whose typical behavior is to cover the window that creates them. Furthermore, such windows should always close, minimize, maximize, and restore in concert with the window that created them. Such a relationship can be established by making one window _own_ another, and is achieved by setting the <xref:System.Windows.Window.Owner%2A> property of the _owned window_ with a reference to the _owner window_. This is shown in the following example.

:::code language="csharp" source="snippets/index/csharp/ChildWindow1.xaml.cs" range="12-18":::
:::code language="vb" source="snippets/index/vb/ChildWindow1.xaml.vb" range="2-7":::

After ownership is established:

- The owned window can reference its owner window by inspecting the value of its <xref:System.Windows.Window.Owner%2A> property.
- The owner window can discover all the windows it owns by inspecting the value of its <xref:System.Windows.Window.OwnedWindows%2A> property.

### Window activation

When a window is first opened, it becomes the active window. The _active window_ is the window that is currently capturing user input, such as key strokes and mouse clicks. When a window becomes active, it raises the <xref:System.Windows.Window.Activated> event.

> [!NOTE]
> When a window is first opened, the <xref:System.Windows.FrameworkElement.Loaded> and <xref:System.Windows.Window.ContentRendered> events are raised only after the <xref:System.Windows.Window.Activated> event is raised. With this in mind, a window can effectively be considered opened when <xref:System.Windows.Window.ContentRendered> is raised.

After a window becomes active, a user can activate another window in the same application, or activate another application. When that happens, the currently active window becomes deactivated and raises the <xref:System.Windows.Window.Deactivated> event. Likewise, when the user selects a currently deactivated window, the window becomes active again and <xref:System.Windows.Window.Activated> is raised.

One common reason to handle <xref:System.Windows.Window.Activated> and <xref:System.Windows.Window.Deactivated> is to enable and disable functionality that can only run when a window is active. For example, some windows display interactive content that requires constant user input or attention, including games and video players. The following example is a simplified video player that demonstrates how to handle <xref:System.Windows.Window.Activated> and <xref:System.Windows.Window.Deactivated> to implement this behavior.

:::code language="xaml" source="snippets/index/csharp/CustomMediaPlayerWindow.xaml":::

The following code is the code-behind for the XAML.

:::code language="csharp" source="snippets/index/csharp/CustomMediaPlayerWindow.xaml.cs":::
:::code language="vb" source="snippets/index/vb/CustomMediaPlayerWindow.xaml.vb":::

Other types of applications may still run code in the background when a window is deactivated. For example, a mail client may continue polling the mail server while the user is using other applications. Applications like these often provide different or extra behavior while the main window is deactivated. For a mail program, this may mean both adding the new mail item to the inbox and adding a notification icon to the system tray. A notification icon need only be displayed when the mail window isn't active, which is determined by inspecting the <xref:System.Windows.Window.IsActive%2A> property.

If a background task completes, a window may want to notify the user more urgently by calling <xref:System.Windows.Window.Activate%2A> method. If the user is interacting with another application activated when <xref:System.Windows.Window.Activate%2A> is called, the window's taskbar button flashes. However, if a user is interacting with the current application, calling <xref:System.Windows.Window.Activate%2A> will bring the window to the foreground.

> [!NOTE]
> You can handle application-scope activation using the <xref:System.Windows.Application.Activated?displayProperty=nameWithType> and <xref:System.Windows.Application.Deactivated?displayProperty=nameWithType> events.

#### Preventing window activation

There are scenarios where windows shouldn't be activated when shown, such as conversation windows of a chat application or notification windows of an email application.

If your application has a window that shouldn't be activated when shown, you can set its <xref:System.Windows.Window.ShowActivated%2A> property to `false` before calling the <xref:System.Windows.Window.Show%2A> method for the first time. As a consequence:

- The window isn't activated.
- The window's <xref:System.Windows.Window.Activated> event isn't raised.
- The currently activated window remains activated.

 The window will become activated, however, as soon as the user activates it by clicking either the client or non-client area. In this case:

- The window is activated.
- The window's <xref:System.Windows.Window.Activated> event is raised.
- The previously activated window is deactivated.
- The window's <xref:System.Windows.Window.Deactivated> and <xref:System.Windows.Window.Activated> events are then raised as expected in response to user actions.

### Closing a window

The life of a window starts coming to an end when a user closes it. Once a window is closed, it can't be reopened. A window can be closed by using elements in the non-client area, including the following:

- The **Close** item of the **System** menu.
- Pressing <kbd>ALT + F4</kbd>.
- Pressing the **Close** button.
- Pressing <kbd>ESC</kbd> when a button has the <xref:System.Windows.Controls.Button.IsCancel%2A> property set to `true` on a modal window.

 You can provide more mechanisms to the client area to close a window, the more common of which include the following:

- An **Exit** item in the **File** menu, typically for main application windows.
- A **Close** item in the **File** menu, typically on a secondary application window.
- A **Cancel** button, typically on a modal dialog box.
- A **Close** button, typically on a modeless dialog box.

To close a window in response to one of these custom mechanisms, you need to call the <xref:System.Windows.Window.Close%2A> method. The following example implements the ability to close a window by choosing **Exit** from a **File** menu.

:::code language="xaml" source="snippets/index/csharp/ClosingWindow.xaml":::

The following code is the code-behind for the XAML.

:::code language="csharp" source="snippets/index/csharp/ClosingWindow.xaml.cs":::
:::code language="vb" source="snippets/index/vb/ClosingWindow.xaml.vb":::

> [!NOTE]
> An application can be configured to shut down automatically when either the main application window closes (see <xref:System.Windows.Application.MainWindow%2A>) or the last window closes. For more information, see <xref:System.Windows.Application.ShutdownMode%2A>.

While a window can be explicitly closed through mechanisms provided in the non-client and client areas, a window can also be implicitly closed as a result of behavior in other parts of the application or Windows, including the following:

- A user logs off or shuts down Windows.
- A window's <xref:System.Windows.Window.Owner%2A> closes.
- The main application window is closed and <xref:System.Windows.Application.ShutdownMode%2A> is <xref:System.Windows.ShutdownMode.OnMainWindowClose>.
- <xref:System.Windows.Application.Shutdown%2A> is called.

> [!IMPORTANT]
> A window can't be reopened after it's closed.

#### Cancel window closure

When a window closes, it raises two events: <xref:System.Windows.Window.Closing> and <xref:System.Windows.Window.Closed>.

<xref:System.Windows.Window.Closing> is raised before the window closes, and it provides a mechanism by which window closure can be prevented. One common reason to prevent window closure is if window content contains modified data. In this situation, the <xref:System.Windows.Window.Closing> event can be handled to determine whether data is dirty and, if so, to ask the user whether to either continue closing the window without saving the data or to cancel window closure. The following example shows the key aspects of handling <xref:System.Windows.Window.Closing>.

:::code language="xaml" source="snippets/index/csharp/DataWindow.xaml":::

The following code is the code-behind for the XAML.

:::code language="csharp" source="snippets/index/csharp/DataWindow.xaml.cs":::
:::code language="vb" source="snippets/index/vb/DataWindow.xaml.vb":::

The <xref:System.Windows.Window.Closing> event handler is passed a <xref:System.ComponentModel.CancelEventArgs>, which implements the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property that you set to `true` to prevent a window from closing.

If <xref:System.Windows.Window.Closing> isn't handled, or it's handled but not canceled, the window will close. Just before a window actually closes, <xref:System.Windows.Window.Closed> is raised. At this point, a window can't be prevented from closing.

### Window lifetime events

The following illustration shows the sequence of the principal events in the lifetime of a window:

:::image type="content" source="./media/index/window-lifetime-events.png" alt-text="Diagram that shows events in a window's lifetime.":::

The following illustration shows the sequence of the principal events in the lifetime of a window that is shown without activation (<xref:System.Windows.Window.ShowActivated%2A> is set to `false` before the window is shown):

:::image type="content" source="./media/index/window-lifetime-no-activation.png" alt-text="Diagram that shows events in a window's lifetime without activation.":::

## Window location

While a window is open, it has a location in the x and y dimensions relative to the desktop. This location can be determined by inspecting the <xref:System.Windows.Window.Left%2A> and <xref:System.Windows.Window.Top%2A> properties, respectively. Set these properties to change the location of the window.

You can also specify the initial location of a <xref:System.Windows.Window> when it first appears by setting the <xref:System.Windows.Window.WindowStartupLocation%2A> property with one of the following <xref:System.Windows.WindowStartupLocation> enumeration values:

- <xref:System.Windows.WindowStartupLocation.CenterOwner> (default)
- <xref:System.Windows.WindowStartupLocation.CenterScreen>
- <xref:System.Windows.WindowStartupLocation.Manual>

If the startup location is specified as <xref:System.Windows.WindowStartupLocation.Manual>, and the <xref:System.Windows.Window.Left%2A> and <xref:System.Windows.Window.Top%2A> properties have not been set, <xref:System.Windows.Window> will ask the operating system for a location to appear in.

### Topmost windows and z-order

Besides having an x and y location, a window also has a location in the z dimension, which determines its vertical position with respect to other windows. This is known as the window's z-order, and there are two types: **normal** z-order and **topmost** z-order. The location of a window in the _normal z-order_ is determined by whether it's currently active or not. By default, a window is located in the normal z-order. The location of a window in the _topmost z-order_ is also determined by whether it's currently active or not. Furthermore, windows in the topmost z-order are always located above windows in the normal z-order. A window is located in the topmost z-order by setting its <xref:System.Windows.Window.Topmost%2A> property to `true`.

Within each z-order type, the currently active window appears above all other windows in the same z-order.

## Window size

Besides having a desktop location, a window has a size that is determined by several properties, including the various width and height properties and <xref:System.Windows.Window.SizeToContent%2A>.

<xref:System.Windows.FrameworkElement.MinWidth%2A>, <xref:System.Windows.FrameworkElement.Width%2A>, and <xref:System.Windows.FrameworkElement.MaxWidth%2A> are used to manage the range of widths that a window can have during its lifetime.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    MinWidth="300" Width="400" MaxWidth="500">
</Window>
```

Window height is managed by <xref:System.Windows.FrameworkElement.MinHeight%2A>, <xref:System.Windows.FrameworkElement.Height%2A>, and <xref:System.Windows.FrameworkElement.MaxHeight%2A>.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    MinHeight="300" Height="400" MaxHeight="500">
</Window>
```

Because the various width values and height values each specify a range, it's possible for the width and height of a resizable window to be anywhere within the specified range for the respective dimension. To detect its current width and height, inspect <xref:System.Windows.FrameworkElement.ActualWidth%2A> and <xref:System.Windows.FrameworkElement.ActualHeight%2A>, respectively.

 If you'd like the width and height of your window to have a size that fits to the size of the window's content, you can use the <xref:System.Windows.Window.SizeToContent%2A> property, which has the following values:

- [SizeToContent.Manual](xref:System.Windows.SizeToContent.Manual)\
No effect (default).
- [SizeToContent.Width](xref:System.Windows.SizeToContent.Width)\
Fit to content width, which has the same effect as setting both <xref:System.Windows.FrameworkElement.MinWidth%2A> and <xref:System.Windows.FrameworkElement.MaxWidth%2A> to the width of the content.
- [SizeToContent.Height](xref:System.Windows.SizeToContent.Height)\
Fit to content height, which has the same effect as setting both <xref:System.Windows.FrameworkElement.MinHeight%2A> and <xref:System.Windows.FrameworkElement.MaxHeight%2A> to the height of the content.
- [SizeToContent.WidthAndHeight](xref:System.Windows.SizeToContent.WidthAndHeight)\
Fit to content width and height, which has the same effect as setting both <xref:System.Windows.FrameworkElement.MinHeight%2A> and <xref:System.Windows.FrameworkElement.MaxHeight%2A> to the height of the content, and setting both <xref:System.Windows.FrameworkElement.MinWidth%2A> and <xref:System.Windows.FrameworkElement.MaxWidth%2A> to the width of the content.

The following example shows a window that automatically sizes to fit its content, both vertically and horizontally, when first shown.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    SizeToContent="WidthAndHeight">
</Window>
```

The following example shows how to set the <xref:System.Windows.Window.SizeToContent%2A> property in code to specify how a window resizes to fit its content    .

```csharp
// Manually alter window height and width
this.SizeToContent = SizeToContent.Manual;

// Automatically resize width relative to content
this.SizeToContent = SizeToContent.Width;

// Automatically resize height relative to content
this.SizeToContent = SizeToContent.Height;

// Automatically resize height and width relative to content
this.SizeToContent = SizeToContent.WidthAndHeight;
```

```vb
' Manually alter window height and width
Me.SizeToContent = SizeToContent.Manual

' Automatically resize width relative to content
Me.SizeToContent = SizeToContent.Width

' Automatically resize height relative to content
Me.SizeToContent = SizeToContent.Height

' Automatically resize height and width relative to content
Me.SizeToContent = SizeToContent.WidthAndHeight
```

## Order of precedence for sizing properties

Essentially, the various sizes properties of a window combine to define the range of width and height for a resizable window. To ensure a valid range is maintained, <xref:System.Windows.Window> evaluates the values of the size properties using the following orders of precedence.

**For Height Properties:**

01. <xref:System.Windows.FrameworkElement.MinHeight%2A?displayProperty=nameWithType>
01. <xref:System.Windows.FrameworkElement.MaxHeight%2A?displayProperty=nameWithType>
01. <xref:System.Windows.SizeToContent.Height?displayProperty=nameWithType> / <xref:System.Windows.SizeToContent.WidthAndHeight?displayProperty=nameWithType>
01. <xref:System.Windows.FrameworkElement.Height%2A?displayProperty=nameWithType>

**For Width Properties:**

01. <xref:System.Windows.FrameworkElement.MinWidth%2A?displayProperty=nameWithType>
01. <xref:System.Windows.FrameworkElement.MaxWidth%2A?displayProperty=nameWithType>
01. <xref:System.Windows.SizeToContent.Width?displayProperty=nameWithType> / <xref:System.Windows.SizeToContent.WidthAndHeight?displayProperty=nameWithType>
01. <xref:System.Windows.FrameworkElement.Width%2A?displayProperty=nameWithType>

The order of precedence can also determine the size of a window when it's maximized, which is managed with the <xref:System.Windows.Window.WindowState%2A> property.

## Window state

During the lifetime of a resizable window, it can have three states: normal, minimized, and maximized. A window with a _normal_ state is the default state of a window. A window with this state allows a user to move and resize it by using a resize grip or the border, if it's resizable.

A window with a _minimized_ state collapses to its task bar button if <xref:System.Windows.Window.ShowInTaskbar%2A> is set to `true`; otherwise, it collapses to the smallest possible size it can be and moves itself to the bottom-left corner of the desktop. Neither type of minimized window can be resized using a border or resize grip, although a minimized window that isn't shown in the task bar can be dragged around the desktop.

A window with a _maximized_ state expands to the maximum size it can be, which will only be as large as its <xref:System.Windows.FrameworkElement.MaxWidth%2A>, <xref:System.Windows.FrameworkElement.MaxHeight%2A>, and <xref:System.Windows.Window.SizeToContent%2A> properties dictate. Like a minimized window, a maximized window can't be resized by using a resize grip or by dragging the border.

> [!NOTE]
> The values of the <xref:System.Windows.Window.Top%2A>, <xref:System.Windows.Window.Left%2A>, <xref:System.Windows.FrameworkElement.Width%2A>, and <xref:System.Windows.FrameworkElement.Height%2A> properties of a window always represent the values for the normal state, even when the window is currently maximized or minimized.

 The state of a window can be configured by setting its <xref:System.Windows.Window.WindowState%2A> property, which can have one of the following <xref:System.Windows.WindowState> enumeration values:

- <xref:System.Windows.WindowState.Normal> (default)
- <xref:System.Windows.WindowState.Maximized>
- <xref:System.Windows.WindowState.Minimized>

The following example shows how to create a window that is shown as maximized when it opens.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    WindowState="Maximized">
</Window>
```

In general, you should set <xref:System.Windows.Window.WindowState%2A> to configure the initial state of a window. Once a _resizable_ window is shown, users can press the minimize, maximize, and restore buttons on the window's title bar to change the window state.

## Window appearance

You change the appearance of the client area of a window by adding window-specific content to it, such as buttons, labels, and text boxes. To configure the non-client area, <xref:System.Windows.Window> provides several properties, which include <xref:System.Windows.Window.Icon%2A> to set a window's icon and <xref:System.Windows.Window.Title%2A> to set its title.

You can also change the appearance and behavior of non-client area border by configuring a window's resize mode, window style, and whether it appears as a button in the desktop task bar.

### Resize mode

Depending on the <xref:System.Windows.Window.WindowStyle%2A> property, you can control if, and how, users resize the window. The window style affects the following:

- Allow or disallow resizing by dragging the window border with the mouse.
- Whether the **Minimize**, **Maximize**, and **Close** buttons appear on the non-client area.
- Whether the **Minimize**, **Maximize**, and **Close** buttons are enabled.

You can configure how a window resizes by setting its <xref:System.Windows.Window.ResizeMode%2A> property, which can be one of the following <xref:System.Windows.ResizeMode> enumeration values:

- <xref:System.Windows.ResizeMode.NoResize>
- <xref:System.Windows.ResizeMode.CanMinimize>
- <xref:System.Windows.ResizeMode.CanResize> (default)
- <xref:System.Windows.ResizeMode.CanResizeWithGrip>

As with <xref:System.Windows.Window.WindowStyle%2A>, the resize mode of a window is unlikely to change during its lifetime, which means that you'll most likely set it from XAML markup.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    ResizeMode="CanResizeWithGrip">
</Window>
```

Note that you can detect whether a window is maximized, minimized, or restored by inspecting the <xref:System.Windows.Window.WindowState%2A> property.

### Window style

The border that is exposed from the non-client area of a window is suitable for most applications. However, there are circumstances where different types of borders are needed, or no borders are needed at all, depending on the type of window.

To control what type of border a window gets, you set its <xref:System.Windows.Window.WindowStyle%2A> property with one of the following values of the <xref:System.Windows.WindowStyle> enumeration:

- <xref:System.Windows.WindowStyle.None>
- <xref:System.Windows.WindowStyle.SingleBorderWindow> (default)
- <xref:System.Windows.WindowStyle.ThreeDBorderWindow>
- <xref:System.Windows.WindowStyle.ToolWindow>

The effect of applying a window style is illustrated in the following image:

:::image type="content" source="./media/index/window-styles.png" alt-text="Screenshot that shows how WindowStyle affects a window in WPF.":::

Notice that the image above doesn't show any noticeable difference between `SingleBorderWindow` and `ThreeDBorderWindow`. Back in Windows XP, `ThreeDBorderWindow` did affect how the window was drawn, adding a 3D border to the client area. Starting with Windows 7, the differences between the two styles are minimal.

You can set <xref:System.Windows.Window.WindowStyle%2A> using either XAML markup or code. Because it's unlikely to change during the lifetime of a window, you'll most likely configure it using XAML markup.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    WindowStyle="ToolWindow">
</Window>
```

#### Non-rectangular window style

There are also situations where the border styles that <xref:System.Windows.Window.WindowStyle%2A> allows you to have aren't sufficient. For example, you may want to create an application with a non-rectangular border, like Microsoft Windows Media Player uses.

For example, consider the speech bubble window shown in the following image:

:::image type="content" source="./media/index/window-transparent.png" alt-text="Screenshot of a WPF window that has a clipped area and custom shape.":::

This type of window can be created by setting the <xref:System.Windows.Window.WindowStyle%2A> property to <xref:System.Windows.WindowStyle.None>, and by using special support that <xref:System.Windows.Window> has for transparency.

:::code language="xaml" source="snippets/index/csharp/ClippedWindow.xaml":::

This combination of values instructs the window to render transparent. In this state, the window's non-client area adornment buttons can't be used and you need to provide your own.

### Task bar presence

The default appearance of a window includes a taskbar button. Some types of windows don't have a task bar button, such as message boxes, [dialog boxes](dialog-boxes-overview.md), or windows with the <xref:System.Windows.Window.WindowStyle%2A> property set to <xref:System.Windows.WindowStyle.ToolWindow>. You can control whether the task bar button for a window is shown by setting the <xref:System.Windows.Window.ShowInTaskbar%2A> property, which is `true` by default.

```xaml
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    ShowInTaskbar="False">
</Window>
```

## Other types of windows

<xref:System.Windows.Navigation.NavigationWindow> is a window that is designed to host navigable content.<!-- For more information, see [Navigation Overview](navigation-overview.md)).-->

Dialog boxes are windows that are often used to gather information from a user to complete a function. For example, when a user wants to open a file, the **Open File** dialog box is displayed by an application to get the file name from the user. For more information, see [Dialog Boxes Overview](dialog-boxes-overview.md).

## See also

- [Dialog boxes overview](dialog-boxes-overview.md)
- [How to open a window or dialog box](how-to-open-window-dialog-box.md)
- [How to open a common dialog box](how-to-open-common-system-dialog-box.md)
- [How to open a message box](how-to-open-message-box.md)
- [How to close a window or dialog box](how-to-close-window-dialog-box.md)
- <xref:System.Windows.Window?displayProperty=fullName>
- <xref:System.Windows.MessageBox?displayProperty=fullName>
- <xref:System.Windows.Navigation.NavigationWindow?displayProperty=fullName>
- <xref:System.Windows.Application?displayProperty=fullName>
