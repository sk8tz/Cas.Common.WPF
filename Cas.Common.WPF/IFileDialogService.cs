namespace Cas.Common.WPF
{
    public interface IFileDialogService
    {
        FileDialogResult ShowOpenFileDialog(FileDialogOptions options = null);
        FileDialogResult ShowSaveFileDialog(FileDialogOptions options = null);
    }
}