Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation

Public Class MainWindow

    Public Sub New()
        CreateInlineExample()
        CreateTypographyExample()
    End Sub

    Private Sub CreateInlineExample()
        ' <InlineCode>
        Dim textBlock As New TextBlock()
        textBlock.Inlines.Add(New Bold(New Run("Important:")))
        textBlock.Inlines.Add(New Run(" This is a message."))
        ' </InlineCode>

        InlineExamplePanel.Children.Add(textBlock)
    End Sub

    Private Sub CreateTypographyExample()
        ' <TypographyCode>
        Dim textBlock As New TextBlock()
        textBlock.Text = "Typography Features"
        Typography.SetKerning(textBlock, True)
        Typography.SetCapitals(textBlock, FontCapitals.SmallCaps)
        ' </TypographyCode>

        TypographyExamplePanel.Children.Add(textBlock)
    End Sub

    ' <HyperlinkHandler>
    Private Sub Hyperlink_RequestNavigate(sender As Object, e As RequestNavigateEventArgs)
        Process.Start(New ProcessStartInfo With {
                .FileName = e.Uri.AbsoluteUri,
                .UseShellExecute = True
            })
        e.Handled = True
    End Sub
    ' </HyperlinkHandler>

End Class
