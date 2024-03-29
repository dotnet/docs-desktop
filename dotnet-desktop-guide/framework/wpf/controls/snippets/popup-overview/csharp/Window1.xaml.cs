﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Popup_Properties_Sample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // Sample event handler:
        private void DisplayPopup(object sender, RoutedEventArgs e)
        {
            myPopupText.Text = myTextBox.Text;
            myPopup.IsOpen = true;
            myPopup.StaysOpen = false;
        }

        // Used in UIElement.IsFocused.
        //<SnippetIsFocused>
        private void setColors(object sender, RoutedEventArgs e)
        {
            if (myTextBox.IsFocused) myTextBox.Foreground = Brushes.Brown;
        }
        //</SnippetIsFocused>

        //<CreatePopup>
        private void CreatePopup(object sender, RoutedEventArgs e)
        {
            Popup codePopup = new Popup();
            TextBlock popupText = new()
            {
                Text = "Popup Text",
                Background = Brushes.LightBlue,
                Foreground = Brushes.Blue
            };
            codePopup.Child = popupText;
            ButtonContentContainer.Children.Add(codePopup);
            codePopup.IsOpen = true;
        }
        //</CreatePopup>
    }
}
