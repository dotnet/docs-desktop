using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class PasswordBoxPage : Page
    {
        public PasswordBoxPage()
        {
            InitializeComponent();
            // Set a sample password for demonstration
            DefaultPassword.Password = "sample123";
        }
    }
}
