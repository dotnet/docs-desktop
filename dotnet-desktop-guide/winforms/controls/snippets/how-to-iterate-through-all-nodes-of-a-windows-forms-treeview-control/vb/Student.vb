Namespace project
    Public Class Student
        Protected _studentSubjects As ArrayList = New ArrayList()

        Public Sub New(studentName As String)
            Me.StudentName = studentName
        End Sub

        Public Property StudentName As String = ""

        Public ReadOnly Property StudentSubjects As ArrayList
            Get
                Return _studentSubjects
            End Get
        End Property
    End Class
End Namespace
