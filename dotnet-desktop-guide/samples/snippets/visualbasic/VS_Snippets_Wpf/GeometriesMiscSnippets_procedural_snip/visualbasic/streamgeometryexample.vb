' <SnippetStreamGeometryExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
    Partial Public Class StreamGeometryExample
        Inherits Page
        Public Sub New()
            ' Create a path to draw a geometry with.
            Dim myPath As New Path()
            myPath.Stroke = Brushes.Black
            myPath.StrokeThickness = 1

            ' Create a StreamGeometry to use to specify myPath.
            Dim theGeometry As StreamGeometry = BuildRegularPolygon(New Point(200, 200), 200, 8, 0)
            theGeometry.FillRule = FillRule.EvenOdd

            ' Freeze the geometry (make it unmodifiable)
            ' for additional performance benefits.
            theGeometry.Freeze()

            ' Use the StreamGeometry returned by the BuildRegularPolygon to 
            ' specify the shape of the path.
            myPath.Data = theGeometry

            ' Add path shape to the UI.
            Dim mainPanel As New StackPanel()
            mainPanel.Children.Add(myPath)
            Me.Content = mainPanel
        End Sub

        Private Function BuildRegularPolygon(ByVal c As Point, ByVal r As Double, ByVal numSides As Integer, ByVal offsetDegree As Double) As StreamGeometry
            ' c is the center, r is the radius,
            ' numSides the number of sides, offsetDegree the offset in Degrees.
            ' Do not add the last point.

            Dim geometry As New StreamGeometry()

            Using ctx As StreamGeometryContext = geometry.Open()

                Dim [step] As Double = 2 * Math.PI / Math.Max(numSides, 3)
                Dim cur As Point = c

                Dim a As Double = Math.PI * offsetDegree / 180.0
                Dim i As Integer = 0

                For i = 0 To numSides - 1
                    cur.X = c.X + r * Math.Cos(a)
                    cur.Y = c.Y + r * Math.Sin(a)
                    If i = 0 Then
                        ctx.BeginFigure(cur, True, True) ' is closed  -  is filled 
                    Else
                        ctx.LineTo(cur, True, False) ' is smooth join  -  is stroked 
                    End If
                    a += [step]
                Next

            End Using

            Return geometry
        End Function
    End Class
End Namespace
' </SnippetStreamGeometryExampleWholePage>
