Friend Module Handler
    Sub InstanceEventInfo(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = (CType(sender, FrameworkElement)).Name
        Dim sourceName As String = (CType(e.Source, FrameworkElement)).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"The instance handler attached to {senderName} " & $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}")
    End Sub

    Sub ClassEventInfo_Static(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = (CType(sender, FrameworkElement)).Name
        Dim sourceName As String = (CType(e.Source, FrameworkElement)).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"The static class handler attached to {senderName} " & $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}")
    End Sub

    Sub ClassEventInfo_Override(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = (CType(sender, FrameworkElement)).Name
        Dim sourceName As String = (CType(e.Source, FrameworkElement)).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"The override class handler attached to {senderName} " & $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}")
    End Sub

    Sub ClassEventInfoBase_Static(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = (CType(sender, FrameworkElement)).Name & "Base"
        Dim sourceName As String = (CType(e.Source, FrameworkElement)).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"The static class handler attached to {senderName} " & $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}")
    End Sub

    Sub ClassEventInfoBase_Override(sender As Object, e As RoutedEventArgs)
        Dim senderName As String = (CType(sender, FrameworkElement)).Name & "Base"
        Dim sourceName As String = (CType(e.Source, FrameworkElement)).Name
        Dim eventName As String = e.RoutedEvent.Name
        Dim handledEventsToo As String = If(e.Handled, " Parameter handledEventsToo set to true.", "")
        Debug.WriteLine($"The override class handler attached to {senderName} " & $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}")
    End Sub
End Module
