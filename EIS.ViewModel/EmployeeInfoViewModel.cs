using System;
using EIS.Common;
using ESI.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIS.Utils;
using EIS.ViewModel.Helpers;

namespace EIS.ViewModel
{
    public class EmployeeInfoViewModel:ViewModelBase,IEmployeeInfoViewModel
    {
        protected EISService apiService;
        public EmployeeInfoViewModel()
        {
            apiService=new EISService();
        }
        private IEnumerable<EmployeeInfo> listOfEmployee;
        public IEnumerable<EmployeeInfo> ListOfEmployees
        {
            get => listOfEmployee;
            set
            {
                listOfEmployee = value;
                NotifyPropertyChanged(nameof(ListOfEmployees));
            }
        }
    }
}
