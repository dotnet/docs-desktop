﻿using System;
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
using System.Windows.Shapes;

namespace index
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        // <RemoveControl>
        private void RemoveThis_Click(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)e.Source;
            
            if (buttonContainer.Children.Contains(element))
                buttonContainer.Children.Remove(element);
        }
        // </RemoveControl>
    }
}
