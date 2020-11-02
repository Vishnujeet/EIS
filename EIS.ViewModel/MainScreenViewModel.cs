using EIS.ViewModel.Helpers;
using EIS.ViewModel.Screen;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Container = EIS.Utils.Container;

namespace EIS.ViewModel
{
    public class MainScreenViewModel : ViewModelBase, IMainScreenViewModel
    {
        private IMenuToolsViewModel iMenuToolsViewModel;
        private IEmployeeInfoViewModel iEmployeeInfoViewModel;
        private IAddEmployeeViewModel addEmployeeViewModel;

        public IEmployeeInfoViewModel EmployeeInfoViewModel
        {
            get => iEmployeeInfoViewModel;
            set
            {
                iEmployeeInfoViewModel = value;
                NotifyPropertyChanged(nameof(EmployeeInfoViewModel));
            }
        }

        public IMenuToolsViewModel MenuToolsViewModel
        {
            get=>iMenuToolsViewModel;
            set
            {
                iMenuToolsViewModel = value;
                NotifyPropertyChanged(nameof(MenuToolsViewModel));
            }

        }
        public IAddEmployeeViewModel AddEmployeeViewModel
        {
            get => addEmployeeViewModel;
            set
            {
                addEmployeeViewModel = value;
                NotifyPropertyChanged(nameof(AddEmployeeViewModel));
            }
        }
        
        private readonly IDataContextProvider mDataContextProvider;

        public MainScreenViewModel(IDataContextProvider dataContextProvider)
        {
            mDataContextProvider = dataContextProvider;
            Initialize();
        }

        internal void Initialize()
        {
            MenuToolsViewModel =Container.Instance.Resolve<IMenuToolsViewModel>();
            EmployeeInfoViewModel = Container.Instance.Resolve<IEmployeeInfoViewModel>();
            AddEmployeeViewModel = Container.Instance.Resolve<IAddEmployeeViewModel>();
        }

    }
}