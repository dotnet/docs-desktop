using System;
using System.ComponentModel;

namespace ArticleSample
{
    public class Employee : INotifyPropertyChanged
    {
        private decimal _salary;
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }

        public decimal Salary
        {
            get => _salary;
            set
            {
                _salary = value;

                // Support TwoWay binding
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary)));
            }
        }
    }
}
