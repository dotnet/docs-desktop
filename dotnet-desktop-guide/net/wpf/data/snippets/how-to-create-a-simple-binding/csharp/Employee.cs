using System;
using System.ComponentModel;

namespace ArticleSample
{
    public class Employee : INotifyPropertyChanged
    {
        private decimal _salary;
        public event PropertyChangedEventHandler? PropertyChanged;

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Title { get; set; }
        public required DateTime HireDate { get; set; }

        public required decimal Salary
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
