Imports System.Windows.Controls.Primitives

Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()

            InitializeComponent()

            ' Add the new button to the StackPanel.
            StackPanel1.Children.Add(CodeButton)

            ' Remove a handler.
            ' RemoveHandler XamlButton.Click, AddressOf XamlButton_Click

        End Sub

        '<Window_Loaded>
        ' Loaded event handler attached to the XAML page root using Handles.
        Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

            ' Handler logic.
            Debug.WriteLine($"Loaded event handler attached to Window using Handles.")

        End Sub
        '</Window_Loaded>

        '<CodeButton_Click>
        ' Declare a new button using WithEvents.
        Dim WithEvents CodeButton As New Button With {
            .Content = "New button",
            .Background = Brushes.Yellow
        }

        ' Click event handler attached to CodeButton using Handles.
        Private Sub CodeButton_Click(sender As Object, e As RoutedEventArgs) Handles CodeButton.Click

            ' Handler logic.
            Debug.WriteLine($"Click event handler attached to CodeButton using Handles.")

        End Sub
        '</CodeButton_Click>

        '<XamlButton_Click>
        ' Click event handler attached to XamlButton using Handles.
        Private Sub XamlButton_Click(sender As Object, e As RoutedEventArgs) Handles XamlButton.Click

            ' Handler logic.
            Debug.WriteLine($"Click event handler attached to XamlButton using Handles.")

        End Sub
        '</XamlButton_Click>

    End Class

End Namespace
