'<EventSuppressionWorkarounds>
Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
        InitializeComponent()

        ' Attach a handler on outerStackPanel that will be invoked by handled KeyDown events.
        outerStackPanel.[AddHandler](KeyDownEvent, New RoutedEventHandler(AddressOf Handler_PrintEventInfo),
                                     handledEventsToo:=True)
    End Sub

    Private Sub ComponentWrapper_KeyDown(sender As Object, e As KeyEventArgs)
        Handler_PrintEventInfo(sender, e)
        Debug.WriteLine("KeyDown event marked as handled on componentWrapper." &
                        vbCrLf & "CustomKey event raised on componentWrapper.")

        ' Mark the event as handled.
        e.Handled = True

        ' Raise the custom click event.
        componentWrapper.RaiseCustomRoutedEvent()
    End Sub

    Private Sub Handler_PrintEventInfo(sender As Object, e As KeyEventArgs)
        Dim senderName As String = CType(sender, FrameworkElement).Name
        Dim sourceName As String = CType(e.Source, FrameworkElement).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"Handler attached to {senderName} " &
                        $"triggered by {eventName} event raised on {sourceName}.{handledEventsToo}")
    End Sub

    Private Sub Handler_PrintEventInfo(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = CType(sender, FrameworkElement).Name
        Dim sourceName As String = CType(e.Source, FrameworkElement).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"Handler attached to {senderName} " &
                        $"triggered by {eventName} event raised on {sourceName}.{handledEventsToo}")
    End Sub

    ' Debug output
    '
    ' Handler attached to outerStackPanel triggered by PreviewKeyDown event raised on componentTextBox.
    ' Handler attached to componentTextBox triggered by KeyDown event raised on componentTextBox.
    ' Handler attached to componentWrapper triggered by KeyDown event raised on componentTextBox.
    ' KeyDown event marked as handled on componentWrapper.
    ' CustomKey event raised on componentWrapper.
    ' Handler attached to componentWrapper triggered by CustomKey event raised on componentWrapper.
    ' Handler attached to outerStackPanel triggered by CustomKey event raised on componentWrapper.
    ' Handler attached to outerStackPanel triggered by KeyDown event raised on componentTextBox. Parameter handledEventsToo set to true.
End Class

    Public Class ComponentWrapper
        Inherits StackPanel

        ' Register a custom routed event with the Bubble routing strategy.
        Public Shared ReadOnly CustomKeyEvent As RoutedEvent =
            EventManager.RegisterRoutedEvent(
                name:="CustomKey",
                routingStrategy:=RoutingStrategy.Bubble,
                handlerType:=GetType(RoutedEventHandler),
                ownerType:=GetType(ComponentWrapper))

        ' Provide CLR accessors to support event handler assignment.
        Public Custom Event CustomKey As RoutedEventHandler

            AddHandler(value As RoutedEventHandler)
                [AddHandler](CustomKeyEvent, value)
            End AddHandler

            RemoveHandler(value As RoutedEventHandler)
                [RemoveHandler](CustomKeyEvent, value)
            End RemoveHandler

            RaiseEvent(sender As Object, e As RoutedEventArgs)
                [RaiseEvent](e)
            End RaiseEvent

        End Event

    Public Sub RaiseCustomRoutedEvent()
        ' Create a RoutedEventArgs instance & raise the event,
        ' which will bubble up through the element tree.
        Dim routedEventArgs As New RoutedEventArgs(routedEvent:=CustomKeyEvent)
            [RaiseEvent](routedEventArgs)
        End Sub
    End Class
'</EventSuppressionWorkarounds>
