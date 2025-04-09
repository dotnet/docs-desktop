'<WeakEventManagerTemplate>
Class SomeEventWeakEventManager
    Inherits WeakEventManager

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Add a handler for the given source's event.
    ''' </summary>
    Public Shared Sub [AddHandler](source As SomeEventSource,
                                   handler As EventHandler(Of SomeEventArgs))
        If source Is Nothing Then Throw New ArgumentNullException(NameOf(source))
        If handler Is Nothing Then Throw New ArgumentNullException(NameOf(handler))
        CurrentManager.ProtectedAddHandler(source, handler)
    End Sub

    ''' <summary>
    ''' Remove a handler for the given source's event.
    ''' </summary>
    Public Shared Sub [RemoveHandler](source As SomeEventSource,
                                      handler As EventHandler(Of SomeEventArgs))
        If source Is Nothing Then Throw New ArgumentNullException(NameOf(source))
        If handler Is Nothing Then Throw New ArgumentNullException(NameOf(handler))
        CurrentManager.ProtectedRemoveHandler(source, handler)
    End Sub

    ''' <summary>
    ''' Get the event manager for the current thread.
    ''' </summary>
    Private Shared ReadOnly Property CurrentManager As SomeEventWeakEventManager
        Get
            Dim managerType As Type = GetType(SomeEventWeakEventManager)
            Dim manager As SomeEventWeakEventManager =
                CType(GetCurrentManager(managerType), SomeEventWeakEventManager)

            If manager Is Nothing Then
                manager = New SomeEventWeakEventManager()
                SetCurrentManager(managerType, manager)
            End If

            Return manager
        End Get
    End Property

    ''' <summary>
    ''' Return a new list to hold listeners to the event.
    ''' </summary>
    Protected Overrides Function NewListenerList() As ListenerList
        Return New ListenerList(Of SomeEventArgs)()
    End Function

    ''' <summary>
    ''' Listen to the given source for the event.
    ''' </summary>
    Protected Overrides Sub StartListening(source As Object)
        Dim typedSource As SomeEventSource = CType(source, SomeEventSource)
        AddHandler typedSource.SomeEvent, New EventHandler(Of SomeEventArgs)(AddressOf OnSomeEvent)
    End Sub

    ''' <summary>
    ''' Stop listening to the given source for the event.
    ''' </summary>
    Protected Overrides Sub StopListening(source As Object)
        Dim typedSource As SomeEventSource = CType(source, SomeEventSource)
        AddHandler typedSource.SomeEvent, New EventHandler(Of SomeEventArgs)(AddressOf OnSomeEvent)
    End Sub

    ''' <summary>
    ''' Event handler for the SomeEvent event.
    ''' </summary>
    Private Sub OnSomeEvent(sender As Object, e As SomeEventArgs)
        DeliverEvent(sender, e)
    End Sub
End Class
'</WeakEventManagerTemplate>
