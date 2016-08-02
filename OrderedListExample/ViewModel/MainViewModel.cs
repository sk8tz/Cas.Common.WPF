using System;
using System.Windows;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace OrderedListExample.ViewModel
{
    public class MainViewModel
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly OrderedListViewModel<ItemViewModel> _items;

        public MainViewModel(IMessageBoxService messageBoxService)
        {
            if (messageBoxService == null) throw new ArgumentNullException(nameof(messageBoxService));
            _messageBoxService = messageBoxService;
            _items = new OrderedListViewModel<ItemViewModel>(
                //() => new ItemViewModel(),
                () => null,
                addedAction: item => Console.WriteLine($"Item '{item?.Text}' added"),
                deleted: item => _messageBoxService.Show($"Delete '{item.Text}'", button:MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                new ItemViewModel() {Value = 1, Text = "One"},
                new ItemViewModel() {Value = 2, Text = "Two"},
                new ItemViewModel() {Value = 3, Text = "Three"},
                new ItemViewModel() {Value = 4, Text = "Four"},
                new ItemViewModel() {Value = 5, Text = "Five"}
            };
        }

        public OrderedListViewModel<ItemViewModel> Items
        {
            get { return _items; }
        }
    }
}