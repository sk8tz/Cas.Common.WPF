using System;
using Cas.Common.WPF.Interfaces;
using Microsoft.Win32;

namespace Cas.Common.WPF
{
    public class FileDialogService : IFileDialogService
    {
        private FileDialogResult ShowDialog(FileDialog dialog, FileDialogOptions options)
        {
            if (dialog == null) throw new ArgumentNullException(nameof(dialog));

            if (options != null)
            {
                SetDialogProperties(dialog, options);
            }

            bool? result;

            //Try to get the active window
            var owner = WindowUtil.GetActiveWindow();

            if (owner == null)
            {
                result = dialog.ShowDialog();
            }
            else
            {
                result = dialog.ShowDialog(owner);
            }

            if (result == true)
            {
                return new FileDialogResult()
                {
                    FileName = dialog.FileName,
                    FileNames = dialog.FileNames
                };
            }

            return null;
        }

        public FileDialogResult ShowOpenFileDialog(FileDialogOptions options = null)
        {
            return ShowDialog(new OpenFileDialog(), options);
        }

        public FileDialogResult ShowSaveFileDialog(FileDialogOptions options = null)
        {
            return ShowDialog(new SaveFileDialog(), options);
        }

        private void SetDialogProperties(FileDialog dialog, FileDialogOptions options)
        {
            if (dialog == null) throw new ArgumentNullException(nameof(dialog));
            if (options == null) throw new ArgumentNullException(nameof(options));

            dialog.AddExtension = options.AddExtension;
            dialog.CheckFileExists = options.CheckFileExists;
            dialog.CheckPathExists = options.CheckPathExists;
            dialog.DefaultExt = options.DefaultExt;
            dialog.FileName = options.FileName;
            dialog.FilterIndex = options.FilterIndex;
            dialog.InitialDirectory = options.InitialDirectory;
            dialog.Title = options.Title;
            dialog.ValidateNames = options.ValidateNames;
            dialog.Filter = options.Filter;
        }
    }
}