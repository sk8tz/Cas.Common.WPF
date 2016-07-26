namespace Cas.Common.WPF
{
    public class FileDialogOptions
    {
        public FileDialogOptions()
        {
            AddExtension = true;
            CheckFileExists = true;
            CheckPathExists = true;
            ValidateNames = true;
            FilterIndex = 1;
        }

        public bool AddExtension { get; set; }

        public bool CheckFileExists { get; set; }

        public bool CheckPathExists { get; set; }

        public string DefaultExt { get; set; } 

        public string Filename { get; set; }

        public string Filter { get; set; }

        public int FilterIndex { get; set; }

        public string InitialDirectory { get; set; }

        public string Title { get; set; }

        public bool ValidateNames { get; set; }

    }
}