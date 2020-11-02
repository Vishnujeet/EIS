using System;
using System.Collections.Generic;

namespace EIS.Common
{
    public class EmployeeData
    {
        public List<EmployeeInfo> data { get; set; }

    }
  
    public class EmployeeInfo
    {
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }
    }



}
