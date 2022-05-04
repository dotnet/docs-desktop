Imports System.Windows.Controls.Primitives

Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()

        '<LanguageSpecificSyntax_ToAttachHandler>
        AddHandler Button1.Click, AddressOf Button_Click
        '</LanguageSpecificSyntax_ToAttachHandler>

        '<AddHandlerToButton>
        Button1.[AddHandler](ButtonBase.ClickEvent, New RoutedEventHandler(AddressOf Button_Click))
        '</AddHandlerToButton>

        '<AddHandlerToStackPanel>
        StackPanel1.[AddHandler](ButtonBase.ClickEvent, New RoutedEventHandler(AddressOf Button_Click))
        '</AddHandlerToStackPanel>
    End Sub

    '<ButtonsParentHandler>
    Private Sub YesNoCancelButton_Click(sender As Object, e As RoutedEventArgs)
        Dim frameworkElementSource As FrameworkElement = TryCast(e.Source, FrameworkElement)

        Select Case frameworkElementSource.Name
            Case "YesButton"
                ' YesButton logic.
            Case "NoButton"
                ' NoButton logic.
            Case "CancelButton"
                ' CancelButton logic.
        End Select

        e.Handled = True
    End Sub
    '</ButtonsParentHandler>

    '<ButtonClickHandler>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' Click event logic.
    End Sub
    '</ButtonClickHandler>

    Private Sub ApplyButtonStyle(sender As Object, e As RoutedEventArgs)
        ' Logic to apply a button style.
        CType(sender, Button).Background = Brushes.Green
    End Sub
End Class
