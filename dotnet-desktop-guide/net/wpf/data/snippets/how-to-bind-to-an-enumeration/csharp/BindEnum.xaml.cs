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
using System.Windows.Shapes;

namespace ArticleExample
{
    /// <summary>
    /// Interaction logic for BindEnum.xaml
    /// </summary>
    public partial class BindEnum : Window
    {
        public BindEnum()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //<EnumGetValues>
            var enumDataSource = System.Enum.GetValues(typeof(System.Windows.HorizontalAlignment));
            //</EnumGetValues>
        }
    }
}
