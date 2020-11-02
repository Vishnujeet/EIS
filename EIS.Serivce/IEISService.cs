using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIS.Common;

namespace EIS.Service
{
    public interface IEISService
    {
        Task<EmployeeData> GetEmployees();
        Task<EmployeeData> SearchEmployees(string firstName);
        Task AsyncPost(EmployeeInfo employeeInfo);
    }
}
