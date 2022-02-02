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

            ' Create a new button and specify button properties.
            Dim ButtonCreatedByCode As New Button With {
                .Name = "ButtonCreatedByCode",
                .Content = "New button and event handler created in code",
                .Background = Brushes.Yellow
            }

            ' Add the new button to the StackPanel.
            StackPanel1.Children.Add(ButtonCreatedByCode)

            ' Assign an event handler to the new button using the AddHandler statement.
            AddHandler ButtonCreatedByCode.Click, AddressOf ButtonCreatedByCode_Click

            ' Assign an event handler to the new button using the AddHandler method.
            ' ButtonCreatedByCode.AddHandler(ButtonBase.ClickEvent, New RoutedEventHandler(AddressOf ButtonCreatedByCode_Click))

            ' Assign an event handler to the StackPanel using the AddHandler method.
            StackPanel1.AddHandler(ButtonBase.ClickEvent, New RoutedEventHandler(AddressOf ButtonCreatedByCode_Click))

        End Sub

        ' The Click event handler for the new button 'ButtonCreatedByCode'.
        Private Sub ButtonCreatedByCode_Click(sender As Object, e As RoutedEventArgs)

            Dim sourceName As String = CType(e.Source, FrameworkElement).Name
            Dim senderName As String = CType(sender, FrameworkElement).Name

            Debug.WriteLine($"Routed event handler attached to {senderName}, " +
                $"triggered by the Click routed event raised by {sourceName}.")

        End Sub
        '</ButtonEventHandlers>

        ' Debug output when ButtonCreatedByCode is clicked:
        ' Routed event handler attached to ButtonCreatedByCode, triggered by the Click routed event raised by ButtonCreatedByCode.
        ' Routed event handler attached to StackPanel1, triggered by the Click routed event raised by ButtonCreatedByCode.
    End Class

End Namespace
