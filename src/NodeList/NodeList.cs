using System.Collections;

namespace NodeList
{
    public class NodeList<T> : IEnumerable<T>, ICollection<T>, IList<T>
    {
        private Node<T>? _first;
        private Node<T>? _last;
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => GetElementByIndex(index);
            set => SetElementByIndex(index, value);
        }

        public NodeList()
        {
            Clear();
        }

        public NodeList(IEnumerable<T> values)
        {
            ArgumentNullException.ThrowIfNull(values);

            Clear();

            foreach (T value in values)
            {
                Add(value);
            }
        }

        public void Add(T item)
        {
            if (Count == 0)
            {
                _first = _last = new(item);
            }
            else
            {
                _last!.Next = new(item);
                _last = _last.Next;
            }

            Count++;
        }

        public void Clear()
        {
            _first = _last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (Count == 0)
                return false;

            var comparer = EqualityComparer<T>.Default;

            foreach (T current in this)
            {
                if (comparer.Equals(current, item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);

            ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex);

            if (array.Rank > 1)
                throw new ArgumentException(
                    "Array is multidimensional; it must be a single-dimensional array.",
                    nameof(array)
                );

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException(
                    "The number of elements in the source NodeList is greater than the available space from the index to the end of the destination array.",
                    nameof(array)
                );

            int i = 0;
            foreach (T item in this)
            {
                array[i + arrayIndex] = item;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = _first;

            while (current is not null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public int IndexOf(T item)
        {
            int index = 0;
            var comparer = EqualityComparer<T>.Default;

            foreach (T value in this)
            {
                if (comparer.Equals(item, value))
                    return index;

                index++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Count++;

            if (index == 0)
            {
                if (_first is null)
                {
                    _first = _last = new(item);
                }
                else
                {
                    _first = new(item, _first);
                }
                
                return;
            }

            if (index + 1 == Count)
            {
                if (Count == 1)
                {
                    _first = _last = new(item);
                }

                _last!.Next = new(item);
                _last = _last?.Next;
                return;
            }

            Node<T> current = GetNodeByIndex(index - 1);
            Node<T> newItem = new(item, current.Next);
            current.Next = newItem;
        }

        public bool Remove(T item)
        {
            if (_first is null)
                return false;

            var comparer = EqualityComparer<T>.Default;

            if (comparer.Equals(item, _first.Value))
            {
                if (Count == 1)
                {
                    Clear();
                    return true;
                }

                _first = _first.Next;
                Count--;
                return true;
            }

            Node<T>? current = _first;

            while (current?.Next is not null)
            {
                if (comparer.Equals(item, current.Next.Value))
                {
                    if (ReferenceEquals(current.Next, _last))
                    {
                        _last = current;
                    }

                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }

                current = current?.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            Count--;

            if (index == 0)
            {
                if (Count == 0)
                {
                    _first = _first = null;
                    return;
                }

                _first = _first?.Next;
                return;
            }

            Node<T> node = GetNodeByIndex(index - 1);

            if (index == Count)
            {
                _last = node;
            }

            node.Next = node.Next?.Next;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T GetElementByIndex(int index)
        {
            CheckIndex(index);
            var node = GetNodeByIndex(index);
            return node.Value;
        }

        private T SetElementByIndex(int index, T value)
        {
            CheckIndex(index);
            var node = GetNodeByIndex(index);
            node.Value = value;
            return value;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        private Node<T> GetNodeByIndex(int index)
        {
            int currentIndex = 0;
            Node<T>? current = _first;

            while (current is not null)
            {
                if (currentIndex == index)
                {
                    break;
                }

                currentIndex++;
                current = current.Next;
            }

            return current!;
        }
    }
}
