Imports System.Windows
Imports System.Windows.Controls

'<CustomButton>
Public Class CustomButton
    Inherits Button

    ' Register a custom routed event with the Bubble routing strategy.
    Public Shared ReadOnly ConditionalClickEvent As RoutedEvent = EventManager.RegisterRoutedEvent(
        name:="ConditionalClick",
        routingStrategy:=RoutingStrategy.Bubble,
        handlerType:=GetType(RoutedEventHandler),
        ownerType:=GetType(CustomButton))

    ' Provide CLR accessors to support event handler assignment.
    Public Custom Event ConditionalClick As RoutedEventHandler

        AddHandler(value As RoutedEventHandler)
            [AddHandler](ConditionalClickEvent, value)
        End AddHandler

        RemoveHandler(value As RoutedEventHandler)
            [RemoveHandler](ConditionalClickEvent, value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RoutedEventArgs)
            [RaiseEvent](e)
        End RaiseEvent

    End Event

    Private Sub RaiseCustomRoutedEvent()

        ' Create a RoutedEventArgs instance.
        Dim routedEventArgs As New RoutedEventArgs(routedEvent:=ConditionalClickEvent)

        ' Raise the event, which will bubble up through the element tree.
        [RaiseEvent](routedEventArgs)

    End Sub

    ' For demo purposes, we use the Click event as a trigger.
    Protected Overrides Sub OnClick()

        ' Some condition combined with the Click event will trigger the ConditionalClick event.
        If Date.Now > New DateTime() Then RaiseCustomRoutedEvent()

        ' Call the base class OnClick() method so Click event subscribers are notified.
        MyBase.OnClick()

    End Sub
End Class
'</CustomButton>
