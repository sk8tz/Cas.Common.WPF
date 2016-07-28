using System;
using Cas.Common.WPF;

namespace OrderedListExample.ViewModel
{
    public class MainViewModel
    {
        private readonly OrderedListViewModel<ItemViewModel> _items;

        public MainViewModel()
        {
            _items = new OrderedListViewModel<ItemViewModel>(
                () => new ItemViewModel(),
                addedAction: item => Console.WriteLine($"Item '{item.Text}' added"),
                deletedAction: item => Console.WriteLine($"Item '{item.Text}' deleted"))
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