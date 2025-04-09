'<control>
Public Class CustomControl1

    '<counter>
    Private _counter As Integer = 0
    '</counter>

    '<onpaint>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        ' Draw the control
        MyBase.OnPaint(e)

        ' Paint our string on top of it
        e.Graphics.DrawString($"Clicked {_counter} times", Font, Brushes.Purple, New PointF(3, 3))

    End Sub
    '</onpaint>

    '<onclick>
    Protected Overrides Sub OnClick(e As EventArgs)

        ' Increase the counter and redraw the control
        _counter += 1
        Invalidate()

        ' Call the base method to invoke the Click event
        MyBase.OnClick(e)

    End Sub
    '</onclick>

End Class
'</control>
