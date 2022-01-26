using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CodeSampleCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //<ButtonEventHandlers>
        // The click event handler for the existing button 'ButtonCreatedByXaml'.
        private void ButtonCreatedByXaml_Click(object sender, RoutedEventArgs e)
        {
            // Create a new button.
            Button ButtonCreatedByCode = new();

            // Specify the button text and background color.
            ButtonCreatedByCode.Content = "New button and event handler created in code";
            ButtonCreatedByCode.Background = Brushes.Yellow;

            // Add the new button to the StackPanel.
            stackPanel.Children.Add(ButtonCreatedByCode);

            // Assign an event handler to the new button using the '+=' operator.
            ButtonCreatedByCode.Click += new RoutedEventHandler(ButtonCreatedByCode_Click);

            // Assign an event handler to the new button using the AddHandler method.
            // AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonCreatedByCode_Click);

            // Assign an event handler to the StackPanel using the AddHandler method.
            // stackPanel.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonCreatedByCode_Click));
        }

        // The click event handler for the new button 'ButtonCreatedByCode'.
        private void ButtonCreatedByCode_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click event handler");
        }
        //</ButtonEventHandlers>
    }
}
