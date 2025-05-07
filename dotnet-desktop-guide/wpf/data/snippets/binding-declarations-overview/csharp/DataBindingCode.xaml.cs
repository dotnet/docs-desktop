using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ArticleExample
{
    /// <summary>
    /// Interaction logic for DataBindingCode.xaml
    /// </summary>
    public partial class DataBindingCode : Window
    {
        // <Converter>
        private class NameConverter : IValueConverter
        {
            private static NameConverter _instance = new();

            public static NameConverter Instance => _instance;

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
                $"[[ {value} ]]";

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
                value.ToString().Trim('[', ']', ' ');
        }
        // </Converter>

        public DataBindingCode()
        {
            InitializeComponent();
        }

        // <SetBinding>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Make a new data source object
            var personDetails = new Person()
            {
                Name = "John",
                Birthdate = DateTime.Parse("2001-02-03")
            };

            // New binding object using the path of 'Name' for whatever source object is used
            var nameBindingObject = new Binding("Name");

            // Configure the binding
            nameBindingObject.Mode = BindingMode.OneWay;
            nameBindingObject.Source = personDetails;
            nameBindingObject.Converter = NameConverter.Instance;
            nameBindingObject.ConverterCulture = new CultureInfo("en-US");

            // Set the binding to a target object. The TextBlock.Name property on the NameBlock UI element
            BindingOperations.SetBinding(NameBlock, TextBlock.TextProperty, nameBindingObject);
        }
        // </SetBinding>
    }
}
