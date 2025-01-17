'<firstcontrol>
Public Class FirstControl

    '<field>
    Private _textAlignment As HorizontalAlignment = HorizontalAlignment.Left
    '</field>

    '<attributes>
    <System.ComponentModel.Category("Alignment"),
    System.ComponentModel.Description("Specifies the alignment of text."),
    System.ComponentModel.DefaultValue(HorizontalAlignment.Left)>
    Public Property TextAlignment As HorizontalAlignment
    '</attributes>
        Get
            Return _textAlignment
        End Get

        Set(value As HorizontalAlignment)
            _textAlignment = value
            Invalidate()
        End Set
    End Property

    '<ontextchanged>
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
    '</ontextchanged>

    '<onpaint>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        '<stringformat>
        Dim style As New StringFormat
        '</stringformat>

        '<alignment>
        'Map the HorizontalAlignment enum to the StringAlignment enum
        Select Case TextAlignment
            Case HorizontalAlignment.Left
                style.Alignment = StringAlignment.Near
            Case HorizontalAlignment.Right
                style.Alignment = StringAlignment.Far
            Case HorizontalAlignment.Center
                style.Alignment = StringAlignment.Center
        End Select
        '</alignment>

        '<drawstring>
        'Create the brush and automatically dispose it.
        Using foreBrush As New SolidBrush(ForeColor)
            'Call the DrawString method to write text.
            'Text, Font, and ClientRectangle are inherited properties.
            e.Graphics.DrawString(Text, Font, foreBrush, ClientRectangle, style)
        End Using
        '</drawstring>
        '<base_onpaint>
        MyBase.OnPaint(e)
        '</base_onpaint>
    End Sub
    '</onpaint>

End Class
'</firstcontrol>
