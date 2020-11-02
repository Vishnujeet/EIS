using System;
using EIS.ViewModel.Screen;

namespace EIS.ViewModel
{
    public interface IMainScreenViewModel : IDisposable
    {
        IEmployeeInfoViewModel EmployeeInfoViewModel { get; set; }
        IMenuToolsViewModel MenuToolsViewModel { get; set; }
        IAddEmployeeViewModel AddEmployeeViewModel { get; set; }
    }
}