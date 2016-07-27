using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Cas.Common.WPF
{
    /// <summary>
    /// Specialized version of the ObservableCollection that facilitates editing an ordered list of items.
    /// </summary>
    /// <typeparam name="TItemType"></typeparam>
    public class OrderedListViewModel<TItemType> : ObservableCollection<TItemType>
        where TItemType : class
    {
        private readonly Func<TItemType> _newItemFactory;
        private readonly Action<TItemType> _addedAction;
        private readonly Action<TItemType> _deletedAction;
        private readonly Func<TItemType, bool> _canDelete;
        private IList _selectedItems;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newItemFactory">Creates a new item for the list.</param>
        /// <param name="items">Optionally pass in an initial list of items</param>
        /// <param name="addedAction">Action to perform when an item is added.</param>
        /// <param name="deletedAction">Action to perform when an item is deleted.</param>
        /// <param name="canDelete">Determines if an item can be deleted. This is called once before the deletion operation is performed.</param>
        public OrderedListViewModel(
            Func<TItemType> newItemFactory, 
            IEnumerable<TItemType> items = null, 
            Action<TItemType> addedAction = null, 
            Action<TItemType> deletedAction = null,
            Func<TItemType, bool> canDelete = null)
        {
            if (newItemFactory == null) throw new ArgumentNullException(nameof(newItemFactory));

            if (items != null)
            {
                foreach (var item in items)
                {
                    Add(item);
                }
            }

            _newItemFactory = newItemFactory;
            _addedAction = addedAction;
            _deletedAction = deletedAction;
            _canDelete = canDelete;

            MoveUpCommand = new RelayCommand(MoveUp, CanMoveUp);
            MoveDownCommand = new RelayCommand(MoveDown, CanMoveDown);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            MoveToTopCommand = new RelayCommand(MoveToTop, CanMoveToTop);
            MoveToBottomCommand = new RelayCommand(MoveToBottom, CanMoveToBottom);
            InsertAboveCommand = new RelayCommand(InsertAbove, CanInsertAbove);
            InsertBelowCommand = new RelayCommand(InsertBelow, CanInsertBelow);
        }
       
        /// <summary>
        /// Handles the collection changing.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:

                    if (_addedAction != null)
                    {
                        foreach (var item in e.NewItems.Cast<TItemType>())
                        {
                            _addedAction(item);
                        }
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:

                    if (_deletedAction != null)
                    {
                        foreach (var item in e.OldItems.Cast<TItemType>())
                        {
                            _deletedAction(item);
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Moves the selected items up.
        /// </summary>
        public ICommand MoveUpCommand { get; private set; }

        /// <summary>
        /// Moves the selected items down.
        /// </summary>
        public ICommand MoveDownCommand { get; private set; }

        /// <summary>
        /// Deletes the selected items.
        /// </summary>
        public ICommand DeleteCommand { get; private set; }

        /// <summary>
        /// Moves the selected items to the top.
        /// </summary>
        public ICommand MoveToTopCommand { get; private set; }

        /// <summary>
        /// Moves the selected items to the bottom
        /// </summary>
        public ICommand MoveToBottomCommand { get; private set; }

        /// <summary>
        /// Inserts a new item above the selected items.
        /// </summary>
        public ICommand InsertAboveCommand { get; private set; }

        /// <summary>
        /// Inserts a new item below the selected items.
        /// </summary>
        public ICommand InsertBelowCommand { get; private set; }

        private TItemType CreateNewEntry()
        {
            return _newItemFactory();
        }

        private bool CanMoveToTop()
        {
            return CanMoveUp();
        }

        private void MoveToTop()
        {
            var newIndex = 0;

            foreach (var entry in SelectedEntries)
            {
                //Get where the item is right now
                var oldIndex = IndexOf(entry);

                //Move the entry
                Move(oldIndex, newIndex);

                newIndex++;
            }
        }

        private bool CanMoveToBottom()
        {
            return CanMoveDown();
        }

        private void MoveToBottom()
        {
            foreach (var entry in SelectedEntries)
            {
                var oldIndex = IndexOf(entry);

                Move(oldIndex, Count - 1);
            }
        }

        private bool CanInsertAbove()
        {
            return SelectedEntries.Length == 1;
        }

        private void InsertAbove()
        {
            var firstSelected = SelectedEntries.FirstOrDefault();

            if (firstSelected == null)
                return;

            var index = IndexOf(firstSelected);

            Insert(index, CreateNewEntry());
        }

        private bool CanInsertBelow()
        {
            return true;
        }

        private void InsertBelow()
        {
            var lastSelected = SelectedEntries.LastOrDefault();

            var entry = CreateNewEntry();

            if (lastSelected == null)
            {
                Add(entry);
            }
            else
            {
                var index = IndexOf(lastSelected);

                Insert(index + 1, entry);
            }
        }

        private bool CanDelete()
        {
            return SelectedEntries.Length > 0;
        }

        private void Delete()
        {
            var selectedEntries = SelectedEntries;

            foreach (var entry in selectedEntries)
            {
                if (_canDelete == null || _canDelete(entry))
                {
                    Remove(entry);
                }
            }
        }

        private void MoveUp()
        {
            foreach (var row in SelectedEntries)
            {
                var index = IndexOf(row);

                Move(index, index - 1);
            }
        }

        private bool CanMoveUp()
        {
            var selectedEntries = SelectedEntries;

            if (selectedEntries.Length == 0)
                return false;

            if (selectedEntries.Any(entry => IndexOf(entry) == 0))
                return false;

            return true;
        }

        private void MoveDown()
        {
            foreach (var row in SelectedEntries.Reverse())
            {
                var index = IndexOf(row);

                Move(index, index + 1);
            }
        }

        private bool CanMoveDown()
        {
            var selectedEntries = SelectedEntries.ToArray();

            if (selectedEntries.Length == 0)
                return false;

            if (selectedEntries.Any(entry => IndexOf(entry) >= Count - 1))
                return false;

            return true;
        }

        /// <summary>
        /// Use this to bind the selected items in the data grid.
        /// </summary>
        public IList SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                _selectedItems = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedItems)));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedEntries)));
            }
        }

        /// <summary>
        /// Gets a typed collection of the selected entries.
        /// </summary>
        public TItemType[] SelectedEntries
        {
            get
            {
                //Make sure that we have something to work with here.
                if (SelectedItems == null)
                    return new TItemType[] { };

                //We use .OfType so that we avoid grabbing the "new line" row.
                return SelectedItems.OfType<TItemType>().OrderBy(IndexOf).ToArray();
            }
        }
    }
}