using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CodeSampleCsharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //<LanguageSpecificSyntax_ToAttachHandler>
            Button1.Click += Button_Click;
            //</LanguageSpecificSyntax_ToAttachHandler>

            //<AddHandlerToButton>
            Button1.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
            //</AddHandlerToButton>

            //<AddHandlerToStackPanel>
            StackPanel1.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
            //</AddHandlerToStackPanel>
        }

        //<ButtonsParentHandler>
        private void YesNoCancelButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement sourceFrameworkElement = e.Source as FrameworkElement;
            switch (sourceFrameworkElement.Name)
            {
                case "YesButton":
                    // YesButton logic.
                    break;
                case "NoButton":
                    // NoButton logic.
                    break;
                case "CancelButton":
                    // CancelButton logic.
                    break;
            }
            e.Handled = true;
        }
        //</ButtonsParentHandler>

        //<ButtonClickHandler>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Click event logic.
        }
        //</ButtonClickHandler>

        private void ApplyButtonStyle(object sender, RoutedEventArgs e)
        {
            // Logic to apply a button style.
            ((Button)sender).Background = Brushes.Green;
        }
    }
}
