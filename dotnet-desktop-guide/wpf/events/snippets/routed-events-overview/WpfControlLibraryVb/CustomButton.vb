Imports System.Windows
Imports System.Windows.Controls

Public Class CustomButton
    Inherits Button

    '<RegisterRouteEventAndClrAccessors>
    ' Register a custom routed event using the Bubble routing strategy.
    Public Shared ReadOnly TapEvent As RoutedEvent = EventManager.RegisterRoutedEvent(
        name:="Tap",
        routingStrategy:=RoutingStrategy.Bubble,
        handlerType:=GetType(RoutedEventHandler),
        ownerType:=GetType(CustomButton))

    ' Provide CLR accessors for adding and removing an event handler.
    Public Custom Event Tap As RoutedEventHandler
        AddHandler(value As RoutedEventHandler)
            [AddHandler](TapEvent, value)
        End AddHandler

        RemoveHandler(value As RoutedEventHandler)
            [RemoveHandler](TapEvent, value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RoutedEventArgs)
            [RaiseEvent](e)
        End RaiseEvent
    End Event
    '</RegisterRouteEventAndClrAccessors>

    Private Sub RaiseCustomRoutedEvent()
        Dim routedEventArgs As New RoutedEventArgs(routedEvent:=TapEvent)
        [RaiseEvent](routedEventArgs)
    End Sub

    Protected Overrides Sub OnClick()
        RaiseCustomRoutedEvent()
        MyBase.OnClick()
    End Sub
End Class
