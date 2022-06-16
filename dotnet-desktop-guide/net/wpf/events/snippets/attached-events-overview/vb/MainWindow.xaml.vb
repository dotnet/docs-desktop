Imports WpfControlVb

Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub RaiseCleanEvent_Click(sender As Object, e As RoutedEventArgs)
        ' Raise the Clean routed event.
        '<RaiseAttachedEvent>
        aquarium1.[RaiseEvent](New RoutedEventArgs(AquariumFilter.CleanEvent))
        '</RaiseAttachedEvent>
    End Sub

    ' The Clean attached event handler.
    Private Sub AquariumFilter_Clean(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = CType(sender, FrameworkElement).Name
        Dim sourceName As String = CType(e.Source, FrameworkElement).Name
        Dim eventName As String = e.RoutedEvent.Name
        MessageBox.Show($"Handler attached to {senderName} " & $"was triggered by the {eventName} routed event raised on {sourceName}")
    End Sub
End Class
