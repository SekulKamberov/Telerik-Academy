namespace AdvancedDataStructures
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable
    {
        private const int InitialCapacity = 16;
        private T[] data;
        private int capacity;
        private int count;
        private IComparer<T> comparer;

        public PriorityQueue()
            : this(InitialCapacity)
        {
        }

        public PriorityQueue(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
            this.count = 0;
            this.comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.capacity = InitialCapacity;
            this.data = new T[InitialCapacity];
            this.count = 0;
            this.comparer = comparer;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public void Enqueue(T item)
        {
            this.data[this.count] = item;

            if (this.count != 0)
            {
                this.CompareWithParrent(this.count);
            }

            this.count++;
            if (this.count >= this.capacity - 2)
            {
                this.IncreaseCapacity();
            }
        }

        public T Dequeue()
        {
            var deque = this.data[0];

            if (this.count > 0)
            {
                this.data[0] = this.data[this.count - 1];
                this.count--;
                this.CompareWithChilds(0);
            }

            return deque;
        }

        public override string ToString()
        {
            var copy = new T[this.count];
            Array.Copy(this.data, copy, this.count);
            return string.Format("{0}\nCount: {1}\nCapacity: {2}\n----------------------", string.Join(", ", copy), this.Count, this.Capacity);
        }

        private void CompareWithChilds(int parrentIndex)
        {
            var leftIndex = (parrentIndex * 2) + 1;
            var isLeft = leftIndex < this.count;
            var rightIndex = (parrentIndex * 2) + 2;
            var isRight = rightIndex < this.count;
            var parrent = this.data[parrentIndex];
            if (isLeft && isRight)
            {
                T left = this.data[leftIndex];
                T right = this.data[rightIndex];
                if (this.comparer.Compare(left, right) > 0)
                {
                    if (this.comparer.Compare(right, parrent) < 0)
                    {
                        this.Swap(rightIndex, parrentIndex);
                        this.CompareWithChilds(rightIndex);
                    }
                }                    
                else if (this.comparer.Compare(left, parrent) < 0)
                {
                    this.Swap(leftIndex, parrentIndex);
                    this.CompareWithChilds(leftIndex);
                }
            }
            else if (isLeft)
            {
                T left = this.data[leftIndex];
                if (this.comparer.Compare(left, parrent) < 0)
                {
                    this.Swap(leftIndex, parrentIndex);
                    this.CompareWithChilds(leftIndex);
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        private void CompareWithParrent(int index)
        {
            var parrentIndex = (index - 1) / 2;
            if (this.comparer.Compare(this.data[parrentIndex], this.data[index]) == 1)
            {
                this.Swap(parrentIndex, index);
                if (parrentIndex != 0)
                {
                    this.CompareWithParrent(parrentIndex);
                }
            }
        }

        private void IncreaseCapacity()
        {
            var newCapacity = this.capacity * 2;
            var newData = new T[newCapacity];
            Array.Copy(this.data, newData, this.count);
            this.data = newData;
            this.capacity = newCapacity;
        }
    }
}
