using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MultiSelectorExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public readonly ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
        private IList _selectedItems;

        public MainViewModel()
        {
            _items.Add(new ItemViewModel() { Value = 1, Text = "One" });
            _items.Add(new ItemViewModel() { Value = 2, Text = "Two" });
            _items.Add(new ItemViewModel() { Value = 3, Text = "Three" });
            _items.Add(new ItemViewModel() { Value = 4, Text = "Four" });
            _items.Add(new ItemViewModel() { Value = 5, Text = "Five" });
        }

        public IEnumerable<ItemViewModel> Items
        {
            get { return _items; }
        }

        /// <summary>
        /// Bind the behavior to this property.
        /// </summary>
        public IList SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value; 
                OnPropertyChanged();
                OnPropertyChanged(nameof(Selected));
            }
        }

        /// <summary>
        /// This provides a typed accessor for the selected items.
        /// </summary>
        public IEnumerable<ItemViewModel> Selected
        {
            get
            {
                var selected = SelectedItems;
                
                if (selected == null)
                    return new ItemViewModel[] {};

                return selected.Cast<ItemViewModel>();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}