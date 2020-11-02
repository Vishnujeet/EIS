using EIS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIS.ViewModel.ExportToCSV
{
    public static class ExportToCSVHelpers
    {
        public static void ExportCsv(IEnumerable<EmployeeInfo> genericList, string filePath)
        {
            var sb = new StringBuilder();
            var header = "";
            var info = typeof(EmployeeInfo).GetProperties();
            if (!File.Exists(filePath))
            {
                var file = File.Create(filePath);
                file.Close();
                foreach (var prop in typeof(EmployeeInfo).GetProperties())
                {
                    header += prop.Name + "; ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
                TextWriter sw = new StreamWriter(filePath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
                TextWriter sw = new StreamWriter(filePath, true);
                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    }
}
