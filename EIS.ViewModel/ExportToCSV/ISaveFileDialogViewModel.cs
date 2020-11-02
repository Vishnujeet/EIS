using System.Windows.Forms;
namespace EIS.ViewModel.ExportToCSV
{
    public interface ISaveFileDialogViewModel
    {
        SaveFileDialog SaveFileDialogWindow { get; set; }
        string FileTypeFilter { get; set; }
        string FileName { get; set; }
        DialogResult ShowDialog();
        string InitialDirectory { get; set; }
    }
}
