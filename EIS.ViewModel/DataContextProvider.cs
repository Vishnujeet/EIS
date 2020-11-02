using EIS.Service;
using EIS.Utils;
using EIS.ViewModel.ExportToCSV;
using EIS.ViewModel.Screen;
using ESI.Service;
using Microsoft.Practices.Unity;

namespace EIS.ViewModel
{
    public class DataContextProvider:IDataContextProvider
    {

       
        public IViewActivator ViewActivator
        {
            get;
            set;
        }

        public IMainScreenViewModel MainScreenViewModel
        {
            get;
            private set;
        }

        public void CreateStartupDialogViewModels()
        {
            IocConfig();
            MainScreenViewModel = new MainScreenViewModel(this);
        }

        private void IocConfig()
        {
            Container.Instance.RegisterInstance<IDataContextProvider>(this);
            Container.Instance.RegisterType<IMenuToolsViewModel, MenuToolsViewModel>();
            Container.Instance.RegisterType<IEmployeeInfoViewModel, EmployeeInfoViewModel>();
            Container.Instance.RegisterType<IAddEmployeeViewModel, AddEmployeeViewModel>();
            Container.Instance.RegisterType<IEISService, EISService> ();
            Container.Instance.RegisterType<ISaveFileDialogViewModel, SaveFileDialogViewModel> ();
        }
    }
}