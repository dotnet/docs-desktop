Public Class UserControl1

    '<property_changed>
    'The event
    Public Event AllowInteractionChanged As EventHandler

    'The backing field for the property
    Private _allowInteraction As Boolean

    'The property
    Public Property AllowInteraction() As Boolean
        Get
            Return _allowInteraction
        End Get
        Set(value As Boolean)
            _allowInteraction = value
            OnAllowInteractionChanged()
        End Set
    End Property

    'Raises the event
    Public Overridable Sub OnAllowInteractionChanged()
        RaiseEvent AllowInteractionChanged(Me, EventArgs.Empty)
    End Sub
    '</property_changed>

    '<eventargs>
    Public Class ProgressReportEventArgs
        Inherits EventArgs

        Public ReadOnly Value As Integer
        Public ReadOnly Maximum As Integer

        Public Sub New(value As Integer, maximum As Integer)
            Me.Value = value
            Me.Maximum = maximum
        End Sub
    End Class

    Public Event ProgressChanged As EventHandler(Of ProgressReportEventArgs)

    Public Overridable Sub OnProgressChanged(value As Integer, maximum As Integer)
        RaiseEvent ProgressChanged(Me, New ProgressReportEventArgs(value, maximum))
    End Sub
    '</eventargs>
End Class
