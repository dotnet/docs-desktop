Class Application

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs)
        '<MainWindowDirect>
        Application.Current.MainWindow = New Window2()

        Application.Current.MainWindow.Show()
        '</MainWindowDirect>

        '<MainWindowIndirect>
        Dim appWindow As New Window2()

        appWindow.Show()
        '</MainWindowIndirect>
    End Sub

End Class
