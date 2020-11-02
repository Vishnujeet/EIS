using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIS.Common;

namespace EIS.ViewModel
{
    
    public interface IEmployeeInfoViewModel
    {
        IEnumerable<EmployeeInfo> ListOfEmployees { get; set; }
    }
}
