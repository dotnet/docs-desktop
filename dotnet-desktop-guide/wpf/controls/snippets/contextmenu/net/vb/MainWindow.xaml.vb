Imports System.Windows
Imports System.Windows.Controls

Namespace ContextMenuExample

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Menu_OnOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
            cmButton.Content = "The ContextMenu Opened"
        End Sub

        Private Sub Menu_OnClosed(ByVal sender As Object, ByVal e As RoutedEventArgs)
            cmButton.Content = "The ContextMenu Closed"
        End Sub

        '<ProgrammaticContextMenu>
        Private Sub CreateContextMenuProgrammatically()
            Dim button As New Button() With {.Content = "Created with Visual Basic"}
            Dim contextMenu As New ContextMenu()
            button.ContextMenu = contextMenu

            Dim fileMenuItem As New MenuItem() With {.Header = "File"}
            Dim newMenuItem As New MenuItem() With {.Header = "New"}
            fileMenuItem.Items.Add(newMenuItem)

            Dim openMenuItem As New MenuItem() With {.Header = "Open"}
            fileMenuItem.Items.Add(openMenuItem)

            Dim recentlyOpenedMenuItem As New MenuItem() With {.Header = "Recently Opened"}
            openMenuItem.Items.Add(recentlyOpenedMenuItem)

            Dim textFileMenuItem As New MenuItem() With {.Header = "Text.xaml"}
            recentlyOpenedMenuItem.Items.Add(textFileMenuItem)

            contextMenu.Items.Add(fileMenuItem)

            ' Add the button to your container (implementation depends on your layout)
            ' containerPanel.Children.Add(button)
        End Sub
        '</ProgrammaticContextMenu>

    End Class

End Namespace