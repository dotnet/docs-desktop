using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllTemplatesCS.Pages
{
    /// <summary>
    /// Interaction logic for StatusBarPage.xaml
    /// </summary>
    public partial class StatusBarPage : Page
    {
        private Random random = new Random();

        public StatusBarPage()
        {
            InitializeComponent();
        }

        private void UpdateStatusButton_Click(object sender, RoutedEventArgs e)
        {
            string[] messages = { "Processing...", "Complete", "Error occurred", "Loading data...", "Saving file..." };
            StatusText.Text = messages[random.Next(messages.Length)];
            StatusProgressBar.Value = random.Next(0, 101);
        }
    }
}
