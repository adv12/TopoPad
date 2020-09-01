using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Ardalis.GuardClauses;

namespace TopoPad.Core
{
    public class ReadOnlyObservableCollectionReverser<T> : IReadOnlyList<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ObservableCollection<T> m_Collection;

        public T this[int index] => m_Collection[Count - 1 - index];

        public int Count => m_Collection.Count;

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public ReadOnlyObservableCollectionReverser(ObservableCollection<T> collection)
        {
            Guard.Against.Null(collection, nameof(collection));
            m_Collection = collection;
            m_Collection.CollectionChanged += Collection_CollectionChanged;
            ((INotifyPropertyChanged)m_Collection).PropertyChanged += Collection_PropertyChanged;
        }

        private void Collection_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = m_Collection.Count - 1; i >= 0; i--)
            {
                yield return m_Collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
