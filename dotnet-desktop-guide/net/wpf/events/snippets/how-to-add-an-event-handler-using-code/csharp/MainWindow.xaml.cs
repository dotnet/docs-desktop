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

            // Specify button properties.
            ButtonCreatedByCode.Name = "ButtonCreatedByCode";
            ButtonCreatedByCode.Content = "New button and event handler created in code";
            ButtonCreatedByCode.Background = Brushes.Yellow;

            // Add the new button to the StackPanel.
            StackPanel1.Children.Add(ButtonCreatedByCode);

            // Assign an event handler to the new button using the '+=' operator.
            ButtonCreatedByCode.Click += new RoutedEventHandler(ButtonCreatedByCode_Click);

            // Assign an event handler to the new button using the AddHandler method.
            // AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonCreatedByCode_Click);

            // Assign an event handler to the StackPanel using the AddHandler method.
            StackPanel1.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonCreatedByCode_Click));
        }

        // The Click event handler for the new button 'ButtonCreatedByCode'.
        private void ButtonCreatedByCode_Click(object sender, RoutedEventArgs e)
        {
            string sourceName = ((FrameworkElement)e.Source).Name;
            string senderName = ((FrameworkElement)sender).Name;

            Debug.WriteLine($"Routed event handler attached to {senderName}, " +
                $"triggered by the Click routed event raised by {sourceName}.");
        }
        //</ButtonEventHandlers>

        // Debug output when ButtonCreatedByCode is clicked:
        // Routed event handler attached to ButtonCreatedByCode, triggered by the Click routed event raised by ButtonCreatedByCode.
        // Routed event handler attached to StackPanel1, triggered by the Click routed event raised by ButtonCreatedByCode.
    }
}
