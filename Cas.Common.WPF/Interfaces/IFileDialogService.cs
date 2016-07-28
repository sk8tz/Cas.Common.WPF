namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// Mockable service for displaying Open/SaveFileDialog in an MVVM environment.
    /// </summary>
    public interface IFileDialogService
    {
        /// <summary>
        /// Display a save file dialog.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        FileDialogResult ShowOpenFileDialog(FileDialogOptions options = null);

        /// <summary>
        /// Display a save file dialog.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        FileDialogResult ShowSaveFileDialog(FileDialogOptions options = null);
    }
}