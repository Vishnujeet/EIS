using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using EIS.Common;
using EIS.Service;
using EIS.Utils;
using EIS.ViewModel.Helpers;
using ESI.Service;

namespace EIS.ViewModel.Screen
{
    public class AddEmployeeViewModel : ViewModelBase, IAddEmployeeViewModel
    {
        public event EventHandler OnClose;
        private string name;
        private string email;
        private Sex gender=Sex.Male;
        private Status status= Status.Active;
        private IEISService service;
        readonly Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        public AddEmployeeViewModel()
        {
            service = Container.Resolve<IEISService>();
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
                NotifyPropertyChanged(nameof(HasError));
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                NotifyPropertyChanged(nameof(Email));
                NotifyPropertyChanged(nameof(HasError));
            }
        }
        public Sex Gender
        {
            get => gender;
            set
            {
                gender = value;
                NotifyPropertyChanged(nameof(Gender));
            }
        }
        public Status Status
        {
            get => status;
            set
            {
                status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }

        public IEnumerable<KeyValuePair> GenderEnumVal => EnumValuesToList.GetEnum<Sex>();
        public IEnumerable<KeyValuePair> StatusEnumVal => EnumValuesToList.GetEnum<Status>();

        public ICommand SaveCommand => new RelayCommand(x => SaveEmpData());
      

        private void SaveEmpData()
        {
            var emp=new EmployeeInfo
            {
                email = Email,
                name = Name,
                gender = Gender.ToString(),
                status = Status.ToString()
            };
            service.AsyncPost(emp);
        }

        public ICommand CancelCommand => new RelayCommand(x => Close());
        public bool HasError => !(!string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Email));
        public void Close()
        {
            OnClose?.Invoke(this, null);
        }

        public override string this[string columnName]
        {
            get
            {
                string result = null;              
                if (columnName == nameof(Name))
                    if (string.IsNullOrWhiteSpace(Name))
                        result = "Please enter the name";
                if (columnName == nameof(Email))
                    if (string.IsNullOrWhiteSpace(Email))
                        result = "Please enter the email";
                    else if (!regex.IsMatch(Email))
                        result = "Please enter the valid email";
                return result;
            }
        }
    }
}