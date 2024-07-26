//<full>
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SDKSamples
{
    public partial class MainWindow : Window
    {
        public MainWindow() =>
            InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        //<handler>
        private void textBox1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textBlock1.Text = $"You Entered: {textBox1.Text}";
            }
        }
        //</handler>
    }
}
//</full>
