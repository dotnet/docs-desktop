using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CodeSampleCsharp
{
    //<EventSuppressionWorkarounds>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //<AddHandler_ToAttachHandler>
            // Attach a Click event handler to a button using the AddHandler method.
            Button1.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
            //</AddHandler_ToAttachHandler>

            //<LanguageSpecificSyntax_ToAttachHandler>
            // Attach a Click event handler to a button using language specific syntax.
            Button1.Click += Button_Click;
            //</LanguageSpecificSyntax_ToAttachHandler>
        }

        //<ButtonsParentHandler>
        private void YesNoCancel_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            switch (feSource.Name)
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

        private void StackPanel1_ButtonClick(object sender, RoutedEventArgs e)
        {
            // Button.Click event logic.
        }
    }
}
