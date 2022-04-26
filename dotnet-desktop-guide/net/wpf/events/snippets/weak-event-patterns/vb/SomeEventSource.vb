Public Class SomeEventSource
    Public Event SomeEvent As EventHandler(Of SomeEventArgs)

    Public Sub RaiseDoEvent()
        OnSomeEvent(New SomeEventArgs())
    End Sub

    Protected Sub OnSomeEvent(e As SomeEventArgs)
        RaiseEvent SomeEvent(Me, e)
    End Sub
End Class
