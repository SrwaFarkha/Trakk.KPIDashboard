using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakk.Utils.Helpers
{
    public class CircularArray<T>
    {
        private readonly T[] _array;
        private readonly int _size;
        private int _headIndex;
        private int _count = 0;

        public CircularArray(int size)
        {
            _size = size;
            _array = new T[size];
        }
        public CircularArray(params T[] objects)
        {
            _size = objects.Length;
            _array = objects;
        }

        public T this[int index]
        {
            get => _array[(_headIndex + index) % _size];
            set => _array[(_headIndex + index) % _size] = value;
        }

        public void Add(T tail)
        {
            _array[_headIndex] = tail;
            _headIndex = (_headIndex + 1) % _size;
            if (_count < _size)
                _count++;
        }

        public void AddRange(params T[] arr) => AddRange((IEnumerable<T>)arr);
        public void AddRange(IEnumerable<T> arr)
        {
            foreach (var o in arr)
            {
                Add(o);
            }
        }

        public void MoveNext() => _headIndex = (_headIndex + 1) % _size;
        public void MovePrevious() => _headIndex = (_headIndex - 1) % _size;
        public int CurrentIndex => _headIndex;

        public T Next() => this[_headIndex = (_headIndex + 1) % _size];
        public void Reset() => _headIndex = 0;
        public T Current => _array[_headIndex];

        public T TakeHeadAndAdd(T tail)
        {
            var head = _array[_headIndex];
            _array[_headIndex] = tail;
            _headIndex = (_headIndex + 1) % _size;
            return head;
        }

        public T[] ToArray()
        {
            var newArr = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                newArr[i] = this[i];
            }

            return newArr;
        }

        public int Length => _array.Length;
    }
}
