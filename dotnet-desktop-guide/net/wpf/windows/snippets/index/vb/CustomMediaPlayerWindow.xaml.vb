Public Class CustomMediaPlayerWindow
    Private Sub Window_Activated(sender As Object, e As EventArgs)
        ' Continue playing media if window Is activated
        mediaElement.Play()
    End Sub

    Private Sub Window_Deactivated(sender As Object, e As EventArgs)
        ' Pause playing if media is being played and window is deactivated
        mediaElement.Pause()
    End Sub
End Class
