Imports System.Windows.Controls.Primitives

Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<ButtonEventHandlers>
        ' The click event handler for the existing button 'ButtonCreatedByXaml'.
        Private Sub ButtonCreatedByXaml_Click(sender As Object, e As RoutedEventArgs)

            ' Create a new button and specify the button text and background color.
            Dim ButtonCreatedByCode As New Button With {
                .Content = "New button and event handler created in code",
                .Background = Brushes.Yellow
            }

            ' Add the new button to the StackPanel.
            stackPanel.Children.Add(ButtonCreatedByCode)

            ' Assign an event handler to the new button using the AddHandler statement.
            AddHandler ButtonCreatedByCode.Click, AddressOf ButtonCreatedByCode_Click

            ' Assign an event handler to the new button using the AddHandler method.
            ' ButtonCreatedByCode.AddHandler(ButtonBase.ClickEvent, New RoutedEventHandler(AddressOf ButtonCreatedByCode_Click))

            ' Assign an event handler to the StackPanel using the AddHandler method.
            ' stackPanel.AddHandler(ButtonBase.ClickEvent, New RoutedEventHandler(AddressOf ButtonCreatedByCode_Click))

        End Sub

        ' The click event handler for the new button 'ButtonCreatedByCode'.
        Private Sub ButtonCreatedByCode_Click(sender As Object, e As RoutedEventArgs)
            MessageBox.Show("Click event handler")
        End Sub
        '</ButtonEventHandlers>

    End Class

End Namespace
