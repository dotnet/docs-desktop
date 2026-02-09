using System;
using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
            MainCalendar.SelectedDate = DateTime.Today;
        }
    }
}
