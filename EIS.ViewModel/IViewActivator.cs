using EIS.ViewModel.Screen;

namespace EIS.ViewModel
{
    public interface IViewActivator
    {
        void ActivateMainScreen();
        void CloseMainScreen();
        void AddEmployee(IAddEmployeeViewModel addEmployee);
    }
}