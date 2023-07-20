Imports System.ComponentModel

Public Class CompassRose

    '<defaultvalue>
    <DefaultValue(GetType(Directions), "North")>
    Public Property PointerDirection As Directions = Directions.North

    <DefaultValue(10)>
    Public Property DistanceInFeet As Integer = 10
    '</defaultvalue>

    '<browsable>
    <Browsable(False)>
    Public Property IsSelected As Boolean
    '</browsable>

    '<shouldserialize_reset>
    Public Property Direction As Directions = Directions.None

    Private Sub ResetDirection()
        Direction = Directions.None
    End Sub

    Private Function ShouldSerializeDirection() As Boolean
        Return Direction <> Directions.None
    End Function
    '</shouldserialize_reset>
End Class
