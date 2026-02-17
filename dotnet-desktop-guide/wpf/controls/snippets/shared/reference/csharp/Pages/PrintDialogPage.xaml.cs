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
    /// Interaction logic for PrintDialogPage.xaml
    /// </summary>
    public partial class PrintDialogPage : Page
    {
        public PrintDialogPage()
        {
            InitializeComponent();
        }

        private void ShowPrintDialogButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                bool? result = printDialog.ShowDialog();
                
                if (result == true)
                {
                    PrintStatusText.Text = "Print dialog was accepted. Ready to print.";
                }
                else
                {
                    PrintStatusText.Text = "Print dialog was cancelled.";
                }
            }
            catch (Exception ex)
            {
                PrintStatusText.Text = $"Error: {ex.Message}";
            }
        }
    }
}
