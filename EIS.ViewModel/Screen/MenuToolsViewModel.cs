using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using EIS.Common;
using EIS.Service;
using EIS.Utils;
using EIS.ViewModel.ExportToCSV;
using EIS.ViewModel.Helpers;
using ESI.Service;

namespace EIS.ViewModel.Screen
{
    public class MenuToolsViewModel : ViewModelBase, IMenuToolsViewModel
    {
        protected IEISService apiService;
        private readonly IDataContextProvider dataContextProvider = Container.Resolve<IDataContextProvider>();
        private IAddEmployeeViewModel addEmployeeViewModel;

        public ICommand LoadEmployeeData => new RelayCommand( x =>  GetEmployees());
        public ICommand AddCommand => new RelayCommand(x => OpenAddWindows());
        public ICommand SearchCommand => new RelayCommand(Search);
        public ICommand ExportCommand => new RelayCommand(x => ExportToCSV());
        public bool CanSave => !dataContextProvider.MainScreenViewModel.AddEmployeeViewModel.HasError;
        public MenuToolsViewModel()
        {
            apiService = Container.Resolve<IEISService>();
        }
        public async Task GetEmployees()
        {
            var result = await apiService.GetEmployees();
            dataContextProvider.MainScreenViewModel.EmployeeInfoViewModel.ListOfEmployees =
                result.data.ToList();
        }

        private async void Search( object firstName)
        {
            var result = await apiService.SearchEmployees(firstName.ToString());
            dataContextProvider.MainScreenViewModel.EmployeeInfoViewModel.ListOfEmployees =
                result.data.ToList();
        }

        private void OpenAddWindows()
        {
            addEmployeeViewModel = new AddEmployeeViewModel();
            
            
            Container.Resolve<IDataContextProvider>().ViewActivator.AddEmployee(addEmployeeViewModel);
        }
        private void ExportToCSV()
        {
            var saveFileDialog = Container.Resolve<ISaveFileDialogViewModel>();
            saveFileDialog.FileTypeFilter = @"CSV-File | *.csv";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var filePath = saveFileDialog.FileName;
            ExportToCSVHelpers.ExportCsv(dataContextProvider.MainScreenViewModel.EmployeeInfoViewModel.ListOfEmployees, filePath);
        }
        
    }
}


