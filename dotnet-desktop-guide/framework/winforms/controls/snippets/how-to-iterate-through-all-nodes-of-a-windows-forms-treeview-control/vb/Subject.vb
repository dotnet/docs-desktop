Namespace project
    Public Class Subject
        Protected _subjectTextbooks As ArrayList = New ArrayList()

        Public Sub New(ByVal subjectID As String)
            Me.SubjectID = subjectID
        End Sub

        Public Property SubjectID As String = ""

        Public ReadOnly Property SubjectTextbooks As ArrayList
            Get
                Return _subjectTextbooks
            End Get
        End Property
    End Class
End Namespace
