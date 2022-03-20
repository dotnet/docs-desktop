'<InstanceEventHandling>
Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()

        ' Attach an instance handler on componentWrapper that will be invoked by handled KeyDown events.
        componentWrapper.[AddHandler](KeyDownEvent, New RoutedEventHandler(AddressOf InstanceEventInfo),
                                      handledEventsToo:=True)
    End Sub

    ' The handler attached to componentWrapper in XAML.
    Public Sub HandlerInstanceEventInfo(sender As Object, e As KeyEventArgs)
        InstanceEventInfo(sender, e)
    End Sub

End Class
'</InstanceEventHandling>

'<ClassEventHandling>
Public Class ComponentWrapper
    Inherits ComponentWrapperBase

    Shared Sub New()
        ' Class event handler implemented in the static constructor.
        EventManager.RegisterClassHandler(GetType(ComponentWrapper), KeyDownEvent,
                                          New RoutedEventHandler(AddressOf ClassEventInfo_Static))
    End Sub

    ' Class event handler that overrides a base class virtual method.
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        ClassEventInfo_Override(Me, e)

        ' Call the base OnKeyDown implementation on ComponentWrapperBase.
        MyBase.OnKeyDown(e)
    End Sub

End Class

Public Class ComponentWrapperBase
    Inherits StackPanel

    Shared Sub New()
        ' Class event handler implemented in the static constructor.
        EventManager.RegisterClassHandler(GetType(ComponentWrapperBase), KeyDownEvent,
                                          New RoutedEventHandler(AddressOf ClassEventInfoBase_Static))
    End Sub

    ' Class event handler that overrides a base class virtual method.
    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        ClassEventInfoBase_Override(Me, e)

        e.Handled = True
        Debug.WriteLine("The KeyDown event is marked as handled.")

        ' Call the base OnKeyDown implementation on StackPanel.
        MyBase.OnKeyDown(e)
    End Sub

End Class
'</ClassEventHandling>

' Debug output:
'
' The instance handler attached to componentWrapper was triggered by the PreviewKeyDown routed event raised on componentTextBox.
' The static class handler attached to componentWrapper was triggered by the KeyDown routed event raised on componentTextBox.
' The static class handler attached to componentWrapperBase was triggered by the KeyDown routed event raised on componentTextBox.
' The override class handler attached to componentWrapper was triggered by the KeyDown routed event raised on componentTextBox.
' The override class handler attached to componentWrapperBase was triggered by the KeyDown routed event raised on componentTextBox.
' The KeyDown event is marked as handled.
' The instance handler attached to componentWrapper was triggered by the KeyDown routed event raised on componentTextBox. Parameter handledEventsToo set to true.
