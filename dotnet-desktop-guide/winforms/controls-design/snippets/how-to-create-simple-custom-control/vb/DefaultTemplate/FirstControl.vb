Imports System.ComponentModel

Namespace DefaultTemplate

    ' <template>
    Public Class FirstControl

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            'Add your custom paint code here
        End Sub

    End Class
    ' </template>

    Public Class SomethingElse : Inherits System.Windows.Forms.Control
        Private _textAlignment As HorizontalAlignment = HorizontalAlignment.Left


#Disable Warning WFO1000 ' Missing code serialization configuration for property content
        ' <property>
        Public Property TextAlignment As HorizontalAlignment
            Get
                Return _textAlignment
            End Get

            Set(value As HorizontalAlignment)
                _textAlignment = value
                Invalidate()
            End Set
        End Property
        ' </property>
#Enable Warning WFO1000 ' Missing code serialization configuration for property content
    End Class

End Namespace
