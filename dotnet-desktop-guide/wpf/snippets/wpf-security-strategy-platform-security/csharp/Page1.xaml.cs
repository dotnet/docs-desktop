using System.Security;
using System.Security.Permissions;
using System.Windows.Controls;

namespace WPFPlatformSecuritySnippet
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            // <PermissionAssert>
            FileIOPermission fp = new FileIOPermission(PermissionState.Unrestricted);
            fp.Assert();

            // Perform operation that uses the assert

            // Revert the assert when operation is completed
            CodeAccessPermission.RevertAssert();
            // </PermissionAssert>
        }
    }
}
