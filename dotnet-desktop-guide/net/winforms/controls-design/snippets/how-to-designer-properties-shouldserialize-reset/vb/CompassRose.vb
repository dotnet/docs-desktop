'<control>
Public Class CompassRose

    '<property>
    Public Property Direction As Directions = Directions.None
    '</property>

    '<reset>
    Private Sub ResetDirection()
        Direction = Directions.None
    End Sub
    '</reset>

    '<shouldserialize>
    Private Function ShouldSerializeDirection() As Boolean
        Return Direction <> Directions.None
    End Function
    '</shouldserialize>

End Class
'</control>
