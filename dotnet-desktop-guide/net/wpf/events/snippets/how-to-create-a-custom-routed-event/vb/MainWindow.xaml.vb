Namespace CodeSampleVb
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Assign an event handler to CustomButton using the AddHandler statement.
            '   AddHandler customButton.ConditionalClick, AddressOf Handler_ConditionalClick

            ' Assign an event handler to CustomButton using the AddHandler method.
            ' customButton.[AddHandler](WpfControlVb.CustomButton.ConditionalClickEvent,
            '   New RoutedEventHandler(AddressOf Handler_ConditionalClick))

            ' Assign an event handler to StackPanel1 using the AddHandler method.
            ' StackPanel1.[AddHandler](WpfControlVb.CustomButton.ConditionalClickEvent,
            '   New RoutedEventHandler(AddressOf Handler_ConditionalClick))
        End Sub

        '<EventHandler>
        ' The ConditionalClick event handler.
        Private Sub Handler_ConditionalClick(sender As Object, e As RoutedEventArgs)

            Dim sourceName As String = CType(e.Source, FrameworkElement).Name
            Dim senderName As String = CType(sender, FrameworkElement).Name

            Debug.WriteLine($"Routed event handler attached to {senderName}, " +
                $"triggered by the ConditionalClick routed event raised on {sourceName}.")

        End Sub

        ' Debug output when CustomButton is clicked:
        ' Routed event handler attached to CustomButton,
        '     triggered by the ConditionalClick routed event raised on CustomButton.
        ' Routed event handler attached to StackPanel1,
        '     triggered by the ConditionalClick routed event raised on CustomButton.
        '</EventHandler>
    End Class
End Namespace
