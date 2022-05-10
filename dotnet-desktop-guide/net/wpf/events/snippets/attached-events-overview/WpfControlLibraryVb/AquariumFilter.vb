Imports System.Windows

'<AddRemoveHandlersForAttachedEvent>
Public Class AquariumFilter

    ' Register a custom routed event using the bubble routing strategy.
    Public Shared ReadOnly CleanEvent As RoutedEvent = EventManager.RegisterRoutedEvent(
        "Clean", RoutingStrategy.Bubble, GetType(RoutedEventHandler), GetType(AquariumFilter))

    ' Provide an add handler accessor method for the Clean event.
    Public Shared Sub AddCleanHandler(dependencyObject As DependencyObject, handler As RoutedEventHandler)
        Dim uiElement As UIElement = TryCast(dependencyObject, UIElement)

        If uiElement IsNot Nothing Then
            uiElement.[AddHandler](CleanEvent, handler)
        End If
    End Sub

    ' Provide a remove handler accessor method for the Clean event.
    Public Shared Sub RemoveCleanHandler(dependencyObject As DependencyObject, handler As RoutedEventHandler)
        Dim uiElement As UIElement = TryCast(dependencyObject, UIElement)

        If uiElement IsNot Nothing Then
            uiElement.[RemoveHandler](CleanEvent, handler)
        End If
    End Sub

End Class
'</AddRemoveHandlersForAttachedEvent>
