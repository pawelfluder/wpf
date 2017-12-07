using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Pirios.DDesk.Libs.Common.Helpers
{
    public class SelectionList<T> :
    ObservableCollection<SelectionItem<T>>
    {
        #region Properties

        /// <summary>
        /// Returns the selected items in the list
        /// </summary>
        public IEnumerable<T> SelectedItems
        {
            get { return this.Where(x => x.IsSelected).Select(x => x.Item); }
        }

        public IEnumerable<T> UnselectedItems
        {
            get { return this.Where(x => !x.IsSelected).Select(x => x.Item); }
        }

        /// <summary>
        /// Returns all the items in the SelectionList
        /// </summary>
        public IEnumerable<T> AllItems
        {
            get { return this.Select(x => x.Item); }
        }

        #endregion

        #region ctor

        public SelectionList(ObservableCollection<T> col)
            : base(toSelectionItemEnumerable(col))
        {
            col.CollectionChanged += OnObservableCollectionChanged;
        }

        public SelectionList(IEnumerable<T> col)
            : base(toSelectionItemEnumerable(col))
        {
        }

        public SelectionList()
            : this(Enumerable.Empty<T>())
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds the item to the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Insert(0, new SelectionItem<T>(item));
        }

        /// <summary>
        /// Checks if the item exists in the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return AllItems.Contains(item);
        }

        /// <summary>
        /// Selects all the items in the list
        /// </summary>
        public void SelectAll()
        {
            foreach (SelectionItem<T> selectionItem in this)
            {
                selectionItem.IsSelected = true;
            }
        }

        /// <summary>
        /// Unselects all the items in the list
        /// </summary>
        public void UnselectAll()
        {
            foreach (SelectionItem<T> selectionItem in this)
            {
                selectionItem.IsSelected = false;
            }
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Creates an SelectionList from any IEnumerable
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private static IEnumerable<SelectionItem<T>> toSelectionItemEnumerable(IEnumerable<T> items)
        {
            List<SelectionItem<T>> list = new List<SelectionItem<T>>();
            foreach (T item in items)
            {
                SelectionItem<T> selectionItem = new SelectionItem<T>(item);
                list.Add(selectionItem);
            }
            return list;
        }

        private void OnObservableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var collection = sender as ObservableCollection<T>;
            if (collection != null)
            {
                ClearItems();
                foreach (var item in toSelectionItemEnumerable(collection))
                {
                    Add(item);
                }
            }
        }

        #endregion
    }
}
