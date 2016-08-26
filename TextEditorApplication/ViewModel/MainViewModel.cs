using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Autofac;
using Cas.Common.WPF;
using Cas.Common.WPF.Behaviors;
using Cas.Common.WPF.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TextEditorApplication.Interfaces;

namespace TextEditorApplication.ViewModel
{
    public class MainViewModel : ViewModelBase, ICloseableViewModel
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IDirtyService _dirtyService;
        private readonly IViewService _viewService;
        private readonly ILifetimeScope _lifetimeScope;
        private string _text;
        private string _path;

        private const string Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

        public MainViewModel(IFileDialogService fileDialogService, IMessageBoxService messageBoxService, IDirtyService dirtyService, IViewService viewService, ILifetimeScope lifetimeScope)
        {
            if (fileDialogService == null) throw new ArgumentNullException(nameof(fileDialogService));
            if (messageBoxService == null) throw new ArgumentNullException(nameof(messageBoxService));
            if (dirtyService == null) throw new ArgumentNullException(nameof(dirtyService));
            if (viewService == null) throw new ArgumentNullException(nameof(viewService));
            if (lifetimeScope == null) throw new ArgumentNullException(nameof(lifetimeScope));
            

            _fileDialogService = fileDialogService;
            _messageBoxService = messageBoxService;
            _dirtyService = dirtyService;
            _viewService = viewService;
            _lifetimeScope = lifetimeScope;
            

            dirtyService.PropertyChanged += DirtyService_PropertyChanged;

            NewCommand = new RelayCommand(New);
            OpenCommand = new RelayCommand(Open);
            SaveCommand = new RelayCommand(() => Save(), CanSave);
            SaveAsComand = new RelayCommand(() => SaveAs());
            ExitCommand = new RelayCommand(Exit);
            AboutCommand = new RelayCommand(About);
        }

        private void DirtyService_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(Title));
        }

        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsComand { get; }
        public ICommand NewCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand AboutCommand { get; }

        private void About()
        {
            var viewModel = _lifetimeScope.Resolve<IAboutViewModel>();

            _viewService.ShowDialog(viewModel);
        }

        private void Exit()
        {
            if (SaveIfDirty())
            {
                Close?.Invoke(this, new CloseEventArgs(true));
            }
        }

        private void Open()
        {
            if (!SaveIfDirty())
                return;

            var options = new FileDialogOptions()
            {
                Filter = Filter
            };

            var result = _fileDialogService.ShowOpenFileDialog(options);

            if (result != null)
            {
                Path = result.FileName;
                Text = File.ReadAllText(result.FileName);

                _dirtyService.MarkClean();
            }
        }

        /// <summary>
        /// Returns true if the file was saved, false otherwise.
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(Path))
            {
                return SaveAs();
            }

            File.WriteAllText(Path, Text);
            _dirtyService.MarkClean();

            return true;
        }

        private bool CanSave()
        {
            return _dirtyService.IsDirty;
        }

        private bool SaveAs()
        {
            var options = new FileDialogOptions()
            {
                Filter = Filter
            };

            var result = _fileDialogService.ShowSaveFileDialog(options);

            if (result == null)
                return false;

            File.WriteAllText(result.FileName, Text);
            Path = result.FileName;
            _dirtyService.MarkClean();

            return true;
        }

        private void New()
        {
            if (!SaveIfDirty())
                return;

            Path = null;
            Text = null;

            _dirtyService.MarkClean();
        }

        /// <summary>
        /// Return true if the user can continue to the next operation.
        /// </summary>
        private bool SaveIfDirty()
        {
            //Easy case - nothing needs to be saved.
            if (!_dirtyService.IsDirty)
            {
                return true;
            }

            //Prompt the user
            var result = _messageBoxService.Show("Save changes?", "Save", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    return Save();

                case MessageBoxResult.No:
                    return true;

               default:
                    return false;
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                _path = value; 
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Title));
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value; 
                RaisePropertyChanged();
                _dirtyService.MarkDirty();
            }
        }

        public string Title
        {
            get
            {
                string title = string.IsNullOrWhiteSpace(Path) ? "Untitled" : Path;

                if (_dirtyService.IsDirty)
                {
                    title += "*";
                }

                return title;
            }
        }

        public event EventHandler<CloseEventArgs> Close;

        public bool CanClose()
        {
            return SaveIfDirty();
        }

        public void Closed()
        {
        }
    }
}