using System;
using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class DatePickerPage : Page
    {
        public DatePickerPage()
        {
            InitializeComponent();
            PreselectedDatePicker.SelectedDate = DateTime.Today;
        }
    }
}
