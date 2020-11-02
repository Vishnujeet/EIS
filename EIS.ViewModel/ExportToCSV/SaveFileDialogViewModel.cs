using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIS.ViewModel.ExportToCSV
{
    public class SaveFileDialogViewModel : ISaveFileDialogViewModel
    {
        public SaveFileDialogViewModel() => SaveFileDialogWindow = new SaveFileDialog();

        public SaveFileDialog SaveFileDialogWindow { get; set; }

        public string FileTypeFilter
        {
            get => SaveFileDialogWindow.Filter;
            set => SaveFileDialogWindow.Filter = value;
        }

        public string FileName
        {
            get => SaveFileDialogWindow.FileName;
            set => SaveFileDialogWindow.FileName = value;
        }

        public DialogResult ShowDialog() => SaveFileDialogWindow.ShowDialog();

        public string InitialDirectory
        {
            get => SaveFileDialogWindow.InitialDirectory;
            set => SaveFileDialogWindow.InitialDirectory = value;
        }
    }
}
