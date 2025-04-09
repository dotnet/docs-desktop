using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace snippets;

public class Company: ObservableObject, IDisposable
{
    int _employeeCount = 10;
    //Bitmap _icon = SystemIcons.GetStockIcon(StockIconId.Warning, StockIconOptions.Default).ToBitmap();
    Bitmap _icon = SystemIcons.Warning.ToBitmap();

    public Bitmap CompanyImage => _icon;

    public int EmployeeCount
    {
        get => _employeeCount;
        set => SetProperty(ref _employeeCount, value);
    }

    public ICommand IncreaseEmployeeCommand { get; }

    ~Company()
    {
        Dispose();
    }

    public Company()
    {
        IncreaseEmployeeCommand = new RelayCommand<int>(IncreaseEmployeeCount, (i) => EmployeeCount < 20);
    }

    private void IncreaseEmployeeCount(int count)
    {
        EmployeeCount += count;
        ((RelayCommand<int>)IncreaseEmployeeCommand).NotifyCanExecuteChanged();
    }

    public void Dispose()
    {
        _icon.Dispose();
    }
}
