namespace Cas.Common.WPF
{
    /// <summary>
    /// The result of a FileDialog operation.
    /// </summary>
    public class FileDialogResult
    {
        /// <summary>
        /// Gets or sets the filenane that was found in the dialog.
        /// </summary>
        public string FileName { get; set; } 

        /// <summary>
        /// Gets or sets the filesnames that were selected in the dialog.
        /// </summary>
        public string[] FileNames { get; set; }
    }
}