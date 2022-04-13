Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()

        TestExistingWeakEventManager()
        TestGenericWeakEventManager()
        TestCustomWeakEventManager()
    End Sub

    Private Sub TestExistingWeakEventManager()
        Dim source As New TextBox()

        '<AddExistingStrongEventHandler>
        AddHandler source.LostFocus, New RoutedEventHandler(AddressOf Source_LostFocus)
        '</AddExistingStrongEventHandler>

        '<RemoveExistingStrongEventHandler>
        RemoveHandler source.LostFocus, New RoutedEventHandler(AddressOf Source_LostFocus)
        '</RemoveExistingStrongEventHandler>

        '<AddExistingWeakEventHandler>
        LostFocusEventManager.AddHandler(
            source, New EventHandler(Of RoutedEventArgs)(AddressOf Source_LostFocus))
        '</AddExistingWeakEventHandler>

        '<RemoveExistingWeakEventHandler>
        LostFocusEventManager.RemoveHandler(
            source, New EventHandler(Of RoutedEventArgs)(AddressOf Source_LostFocus))
        '</RemoveExistingWeakEventHandler>
    End Sub

    Private Sub TestGenericWeakEventManager()
        Dim source As New SomeEventSource()

        '<AddGenericStrongEventHandler>
        AddHandler source.SomeEvent, New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent)
        '</AddGenericStrongEventHandler>

        '<RemoveGenericStrongEventHandler>
        RemoveHandler source.SomeEvent, New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent)
        '</RemoveGenericStrongEventHandler>

        '<AddGenericWeakEventHandler>
        WeakEventManager(Of SomeEventSource, SomeEventArgs).AddHandler(
            source, "SomeEvent", New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent))
        '</AddGenericWeakEventHandler>

        '<RemoveGenericWeakEventHandler>
        WeakEventManager(Of SomeEventSource, SomeEventArgs).RemoveHandler(
            source, "SomeEvent", New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent))
        '</RemoveGenericWeakEventHandler>
    End Sub

    Private Sub TestCustomWeakEventManager()
        Dim source As New SomeEventSource()

        '<AddCustomStrongEventHandler>
        AddHandler source.SomeEvent, New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent)
        '</AddCustomStrongEventHandler>

        '<RemoveCustomStrongEventHandler>
        RemoveHandler source.SomeEvent, New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent)
        '</RemoveCustomStrongEventHandler>

        '<AddCustomWeakEventHandler>
        SomeEventWeakEventManager.AddHandler(
            source, New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent))
        '</AddCustomWeakEventHandler>

        '<RemoveCustomWeakEventHandler>
        SomeEventWeakEventManager.RemoveHandler(
            source, New EventHandler(Of SomeEventArgs)(AddressOf Source_SomeEvent))
        '</RemoveCustomWeakEventHandler>
    End Sub

    Private Sub Source_LostFocus(sender As Object, e As RoutedEventArgs)
        Debug.WriteLine("Source_LostFocus")
    End Sub

    Private Sub Source_SomeEvent(sender As Object, e As SomeEventArgs)
        Debug.WriteLine("Source_SomeEvent")
    End Sub
End Class
