using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Cas.Common.WPF.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Cas.Common.WPF.Test.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewService _viewService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFileDialogService _fileDialogService;
        private bool _isFocused;
        private bool _isEditorVisible;

        private readonly ObservableCollection<RowViewModel> _rows = new ObservableCollection<RowViewModel>()
        {
            new RowViewModel() {Name = "One", Value = "1"},
            new RowViewModel() {Name = "Two", Value = "2"},
            new RowViewModel() {Name = "Three", Value = "3"},
            new RowViewModel() {Name = "Four", Value = "4"},
            new RowViewModel() {Name = "Five", Value = "5"},
            new RowViewModel() {Name = "Six", Value = "6"},
            new RowViewModel() {Name = "Seven", Value = "7"},
            new RowViewModel() {Name = "Eight", Value = "8"},
        };

        public MainViewModel(IViewService viewService, IMessageBoxService messageBoxService, IFileDialogService fileDialogService)
        {
            if (viewService == null) throw new ArgumentNullException(nameof(viewService));
            if (messageBoxService == null) throw new ArgumentNullException(nameof(messageBoxService));
            if (fileDialogService == null) throw new ArgumentNullException(nameof(fileDialogService));

            _viewService = viewService;
            _messageBoxService = messageBoxService;
            _fileDialogService = fileDialogService;
            MoveUpCommand = new RelayCommand(MoveUp, CanMoveUp);
            SelectTwoCommand = new RelayCommand(SelectTwo);
            FocusCommand = new RelayCommand(Focus);
            LaunchSampleDialogCommand = new RelayCommand(LaunchSampleDialog);
            OpenFileCommand = new RelayCommand(OpenFile);
        }

        public ICommand FocusCommand { get; private set; }
        public ICommand MoveUpCommand { get; private set; }
        public ICommand SelectTwoCommand { get; private set; }
        public ICommand LaunchSampleDialogCommand { get; }
        public ICommand OpenFileCommand { get; }

        private void OpenFile()
        {
            var result = _fileDialogService.ShowOpenFileDialog();

            if (result != null)
            {
                _messageBoxService.ShowMessageBox(result.Filename, "Selected Filename");
            }
        }

        private void LaunchSampleDialog()
        {
            var viewModel = new SampleDialogViewModel(_messageBoxService)
            {
                Title = "Hello"
            };

            _viewService.ShowDialog(viewModel);
        }

        private void Focus()
        {
            IsEditorVisible = false;
            IsEditorVisible = true;
            IsFocused = false;
            IsFocused = true;
        }

        private void SelectTwo()
        {
            this.SelectedRows = Rows.Take(2).ToArray();
        }

        private void MoveUp()
        {
            foreach (var row in SelectedRowViewModels)
            {
                var index = Rows.IndexOf(row);

                Rows.Move(index, index - 1);    
            }
        }

        private bool CanMoveUp()
        {
            foreach (var row in SelectedRowViewModels)
            {
                var index = Rows.IndexOf(row);

                if (index == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public ObservableCollection<RowViewModel> Rows
        {
            get { return _rows; }
        }

        private IList _selectedItems;
        public IList SelectedRows
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value;
                RaisePropertyChanged();
            }
        }

        protected RowViewModel[] SelectedRowViewModels
        {
            get
            {
                if (SelectedRows == null)
                    return new RowViewModel[]{};

                var rows = SelectedRows.OfType<RowViewModel>();

                return rows.OrderBy(r => Rows.IndexOf(r)).ToArray();
            }
        }

        public bool IsFocused
        {
            get { return _isFocused; }
            set
            {
                _isFocused = value; 
                RaisePropertyChanged();
            }
        }

        public bool IsEditorVisible
        {
            get { return _isEditorVisible; }
            set
            {
                _isEditorVisible = value; 
                RaisePropertyChanged();
            }
        }
    }
}
