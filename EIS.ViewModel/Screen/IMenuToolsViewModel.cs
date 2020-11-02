using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using EIS.Common;

namespace EIS.ViewModel.Screen
{
    public interface IMenuToolsViewModel
    {
        ICommand LoadEmployeeData { get; }
        ICommand AddCommand { get; }
        ICommand SearchCommand { get; }
        ICommand ExportCommand { get; }
        bool CanSave { get; }
        Task GetEmployees();
    }
}