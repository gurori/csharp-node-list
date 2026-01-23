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

        public void Add(T item)
        {
            if (Count == 0)
            {
                _first = _last = new(item);
                Count++;
                return;
            }

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
            if (Count == 0)
                return false;

            foreach (T current in this)
            {
                if (item.Equals(current))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

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

            foreach (T value in this)
            {
                if (value is not null && value.Equals(item))
                    return index;

                index++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            Count++;

            if (index == 0)
            {
                _first = new(item, _first);
                return;
            }

            if (index + 1 == Count)
            {
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

            if (item.Equals(_first.Value))
            {
                _first = _first.Next;
                Count--;
                return true;
            }

            Node<T>? current = _first;

            while (current is not null)
            {
                if (current.Next is not null && item.Equals(current.Next.Value))
                {
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
                _first = _first?.Next;
                return;
            }

            Node<T> node = GetNodeByIndex(index - 1);
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
