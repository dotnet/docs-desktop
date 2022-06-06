Public Class SomeEventArgs
    Inherits EventArgs

    Public Property TimeStamp As String

    Public Sub New()
        TimeStamp = Date.Now.ToLongTimeString()
    End Sub
End Class
