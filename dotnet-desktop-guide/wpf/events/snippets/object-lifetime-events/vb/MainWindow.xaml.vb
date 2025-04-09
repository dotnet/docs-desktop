'<LifetimeEventsCodeBehind>
Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    ' Handler for the Initialized lifetime event (attached in XAML).
    Private Sub InitHandler(sender As Object, e As EventArgs)
        Debug.WriteLine($"Initialized event on {CType(sender, FrameworkElement).Name}.")
    End Sub

    ' Handler for the Loaded lifetime event (attached in XAML).
    Private Sub LoadHandler(sender As Object, e As RoutedEventArgs)
        Debug.WriteLine($"Loaded event on {CType(sender, FrameworkElement).Name}.")
    End Sub

    ' Handler for the Unloaded lifetime event (attached in XAML).
    Private Sub UnloadHandler(sender As Object, e As RoutedEventArgs)
        Debug.WriteLine($"Unloaded event on {CType(sender, FrameworkElement).Name}.")
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' Remove nested controls.
        canvas.Children.Clear()
    End Sub
End Class

' Custom control.
Public Class ComponentWrapper
    Inherits ComponentWrapperBase
End Class

' Custom base control.
Public Class ComponentWrapperBase
    Inherits StackPanel

    Public Sub New()
        ' Attach handlers for the lifetime events.
        AddHandler Initialized, AddressOf InitHandler
        AddHandler Loaded, AddressOf LoadHandler
        AddHandler Unloaded, AddressOf UnloadHandler
    End Sub

    ' Handler for the Initialized lifetime event (attached in code-behind).
    Private Sub InitHandler(sender As Object, e As EventArgs)
        Debug.WriteLine("Initialized event on componentWrapperBase.")
    End Sub

    ' Handler for the Loaded lifetime event (attached in code-behind).
    Private Sub LoadHandler(sender As Object, e As RoutedEventArgs)
        Debug.WriteLine("Loaded event on componentWrapperBase.")
    End Sub

    ' Handler for the Unloaded lifetime event (attached in code-behind).
    Private Sub UnloadHandler(sender As Object, e As RoutedEventArgs)
        Debug.WriteLine("Unloaded event on componentWrapperBase.")
    End Sub
End Class

'Output:
'Initialized event on textBox1.
'Initialized event on textBox2.
'Initialized event on componentWrapperBase.
'Initialized event on componentWrapper.
'Initialized event on outerStackPanel.

'Loaded event on outerStackPanel.
'Loaded event on componentWrapperBase.
'Loaded event on componentWrapper.
'Loaded event on textBox1.
'Loaded event on textBox2.

'Unloaded event on outerStackPanel.
'Unloaded event on componentWrapperBase.
'Unloaded event on componentWrapper.
'Unloaded event on textBox1.
'Unloaded event on textBox2.
'</LifetimeEventsCodeBehind>
