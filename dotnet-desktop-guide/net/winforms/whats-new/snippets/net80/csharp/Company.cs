using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace snippets;

public class Company: ObservableObject
{
    int _employeeCount = 10;

    public int EmployeeCount
    {
        get => _employeeCount;
        set => SetProperty(ref _employeeCount, value);
    }

    public ICommand IncreaseEmployeeCommand { get; }

    public Company()
    {
        IncreaseEmployeeCommand = new RelayCommand<int>(IncreaseEmployeeCount, (i) => EmployeeCount < 20);
    }

    private void IncreaseEmployeeCount(int count)
    {
        EmployeeCount += count;
        ((RelayCommand<int>)IncreaseEmployeeCommand).NotifyCanExecuteChanged();
    }
}
