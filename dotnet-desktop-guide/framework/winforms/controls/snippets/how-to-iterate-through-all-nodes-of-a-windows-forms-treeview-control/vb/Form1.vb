Imports project.project

Public Class Form1
    Private studentArray As ArrayList = New ArrayList()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Loading the TreeView with data
        PopulateTreeView()

        'Below method implementations will start printing node values to MessageBoxes and can be time consuming.
        'An alternate way to check is adding two labels and printing the values of the total nodes in each using both the below traversal methods.
         
        'Print all the nodes recursively
        'CallRecursive(trvTest)
        'CallNonRecursive(trvTest)
    End Sub

    '<PrintRecursive>
    Private Sub PrintRecursive(n As TreeNode)
        System.Diagnostics.Debug.WriteLine(n.Text)
        MessageBox.Show(n.Text)
        Dim aNode As TreeNode
        For Each aNode In n.Nodes
            PrintRecursive(aNode)
        Next
    End Sub

    ' Call the procedure using the top nodes of the treeview.  
    Private Sub CallRecursive(aTreeView As TreeView)
        Dim n As TreeNode
        For Each n In aTreeView.Nodes
            PrintRecursive(n)
        Next
    End Sub
    '</PrintRecursive>

    '<PrintNonRecursive>
    Private Sub PrintNonrecursive(n As TreeNode)
        If n IsNot Nothing Then
            Dim staging As Queue(Of TreeNode) = New Queue(Of TreeNode)
            staging.Enqueue(n)
            While staging.Count > 0
                n = staging.Dequeue()

                'Print the node.  
                System.Diagnostics.Debug.WriteLine(n.Text)
                MessageBox.Show(n.Text)

                Dim node As TreeNode
                For Each node In n.Nodes
                    staging.Enqueue(node)
                Next
            End While
        End If
    End Sub

    Private Sub CallNonRecursive(aTreeView As TreeView)
        Dim n As TreeNode
        For Each n In aTreeView.Nodes
            PrintNonrecursive(n)
        Next
    End Sub
    '</PrintNonRecursive>

    Private Sub PopulateTreeView()
        For x As Integer = 0 To 4
            studentArray.Add(New Student("Student " & x.ToString()))
        Next

        For Each student As Student In studentArray

            For y As Integer = 0 To 9
                student.StudentSubjects.Add(New Subject("Subject " & y.ToString()))
            Next
        Next

        Dim _random As Random = New Random()

        For Each student As Student In studentArray

            For Each subject As Subject In student.StudentSubjects
                Dim gen = _random.[Next](1, 10)

                For y As Integer = 0 To gen - 1
                    subject.SubjectTextbooks.Add(New TextBook("TextBook " & y.ToString()))
                Next
            Next
        Next

        trvTest.BeginUpdate()
        trvTest.Nodes.Clear()

        For Each student As Student In studentArray
            trvTest.Nodes.Add(New TreeNode(student.StudentName))

            For Each subject As Subject In student.StudentSubjects
                trvTest.Nodes(studentArray.IndexOf(student)).Nodes.Add(New TreeNode(subject.SubjectID))

                For Each textbook As TextBook In subject.SubjectTextbooks
                    trvTest.Nodes(studentArray.IndexOf(student)).Nodes(student.StudentSubjects.IndexOf(subject)).Nodes.Add(New TreeNode(textbook.TextBookID))
                Next
            Next
        Next

        trvTest.EndUpdate()
    End Sub
End Class
