'<bind_controls_using_BindingSource>
Public Class Form1
    Private Sub InitializeControlsAndDataSource()

        ' Add a table and column to DataSet.
        set1.Tables.Add("Menu")
        set1.Tables(0).Columns.Add("Beverages")

        ' Add some rows to the table.
        set1.Tables(0).Rows.Add("coffee")
        set1.Tables(0).Rows.Add("tea")
        set1.Tables(0).Rows.Add("hot chocolate")
        set1.Tables(0).Rows.Add("milk")
        set1.Tables(0).Rows.Add("orange juice")

        ' Set the data source to the DataSet.
        BindingSource1.DataSource = set1

        'Set the DataMember to the Menu table.
        BindingSource1.DataMember = "Menu"

        ' Add the control data bindings.
        DataGridView1.DataSource = BindingSource1
        TextBox1.DataBindings.Add("Text", BindingSource1, "Beverages",
            True, DataSourceUpdateMode.OnPropertyChanged)
        TextBox2.DataBindings.Add("Text", BindingSource1, "Beverages",
            True, DataSourceUpdateMode.OnPropertyChanged)

    End Sub

    Private Sub BindingSource1_BindingComplete(ByVal sender As Object,
        ByVal e As BindingCompleteEventArgs) Handles BindingSource1.BindingComplete

        ' Check if the data source has been updated, and that no error has occurred.
        If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate _
            AndAlso e.Exception Is Nothing Then

            ' If not, end the current edit.
            e.Binding.BindingManagerBase.EndCurrentEdit()
        End If
    End Sub
    '</bind_controls_using_BindingSource>
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeControlsAndDataSource()
    End Sub
End Class
