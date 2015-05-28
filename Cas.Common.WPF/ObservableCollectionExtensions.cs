using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cas.Common.WPF
{
    /// <summary>
    /// Extension methods for the ObservableCollection class.
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Sets the count of an obervable collection.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="newCount"></param>
        /// <param name="itemFactory"></param>
        /// <typeparam name="T"></typeparam>
        public static void SetCount<T>(this ObservableCollection<T> collection, int newCount, Func<int, T> itemFactory)
        {
            while (collection.Count < newCount)
            {
                //Create the new item
                var newItem = itemFactory(collection.Count);

                //Add it to the list
                collection.Add(newItem);
            }

            while (collection.Count > newCount)
            {
                //Remove the last item
                collection.RemoveAt(collection.Count - 1);
            }
        }

        /// <summary>
        /// Adds a range of items to the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
