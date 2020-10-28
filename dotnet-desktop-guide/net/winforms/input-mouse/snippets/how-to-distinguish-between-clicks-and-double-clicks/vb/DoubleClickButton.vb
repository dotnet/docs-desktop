Imports System.Windows.Forms

'<DoubleClickButton>
Public Class DoubleClickButton : Inherits Button

    Public Sub New()
        SetStyle(ControlStyles.StandardClick Or ControlStyles.StandardDoubleClick, True)
    End Sub

End Class
'</DoubleClickButton>
