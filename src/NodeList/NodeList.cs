using System.Collections;
using System.Linq.Expressions;

namespace NodeList
{
    public class NodeList<T> : IQueryable<T>, ICollection<T>, IList<T>
    {
        private Node<T>? _first;
        private Node<T>? _last;

        public NodeList()
        {
            Clear();
        }

        public NodeList(params IEnumerable<T> values)
        {
            Count = 0;
            Node<T>? current;

            foreach (T value in values)
            {
                current = new(value);

                if (Count == 0)
                {
                    _first = current;
                }

                _last = current;
                current = current.Next;
                Count++;
            }
        }

        public T this[int index]
        {
            get => GetElementByIndex(index);
            set => SetElementByIndex(index);
        }

        public Type ElementType => typeof(T);

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _last!.Next = new(item);
            _last = _last.Next;
            Count++;
        }

        public void Clear()
        {
            _first = _last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (_first is null) return false;
            if (item is null) throw new ArgumentNullException(nameof(item));

            Node<T>? current = _first;

            while (current is not null)
            {
                if (item.Equals(current.Value))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T GetElementByIndex(int index)
        {
            CheckIndex(index);
            throw new NotImplementedException();
        }

        private T SetElementByIndex(int index)
        {
            CheckIndex(index);
            throw new NotImplementedException();
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}
