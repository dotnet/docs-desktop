Imports System.Security
Imports System.Security.Permissions
Imports System.Windows.Controls

Namespace WPFPlatformSecuritySnippet
    Partial Public Class Page1
        Inherits Page
        Public Sub New()
            InitializeComponent()

            ' <PermissionAssert>
            Dim fp As New FileIOPermission(PermissionState.Unrestricted)
            fp.Assert()

            ' Perform operation that uses the assert

            ' Revert the assert when operation is completed
            CodeAccessPermission.RevertAssert()
            ' </PermissionAssert>
        End Sub
    End Class
End Namespace
