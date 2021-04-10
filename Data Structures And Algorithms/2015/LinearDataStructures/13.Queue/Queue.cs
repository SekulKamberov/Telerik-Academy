namespace _13.Queue
{
    using System;

    public class Queue<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int capacity;
        private int count;
        private int headIndex;
        private int tailIndex;

        public Queue()
        {
            this.items = new T[InitialCapacity];
            this.capacity = InitialCapacity;
            this.count = 0;
            this.headIndex = 0;
            this.tailIndex = 0;
        }

        public int Count 
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T item)
        {
            if (this.count == this.capacity - 1)
            {
                this.IncreaseCapacity();
            }

            this.items[this.tailIndex] = item;
            this.count++;
            this.tailIndex++;
        }

        public T Dequeue()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("No items in the basket!");
            }

            T returnObject = this.items[this.headIndex];
            this.count--;
            this.headIndex++;
            return returnObject;
        }

        public void Clear()
        {
            this.count = 0;
            this.headIndex = 0;
            this.tailIndex = 0;
        }

        public bool Contains(T item)
        {
            for (int i = this.headIndex; i < this.tailIndex; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void TrimExcess()
        {
            var newItems = new T[this.count];
            Array.Copy(this.items, this.headIndex, newItems, 0, this.count);
            this.items = newItems;
            this.capacity = this.count + 1;
            this.headIndex = 0;
            this.tailIndex = this.count;
        }

        public T Peek()
        {
            return this.items[this.headIndex];
        }

        public override string ToString()
        {
            var itemsToDisplay = new T[this.count];
            Array.Copy(this.items, this.headIndex, itemsToDisplay, 0, this.count);
            var valuesMessage = itemsToDisplay.Length != 0 ? string.Join(", ", itemsToDisplay) : "No items";
            return string.Format("Values: {0} \nCapacity: {1} \nCount: {2} \nHeadIndex: {3} \nTailIndex: {4}\n", valuesMessage, this.capacity, this.count, this.headIndex, this.tailIndex);
        }

        private void IncreaseCapacity()
        {
            var newCapacity = this.capacity * 2;
            var newItems = new T[newCapacity];
            Array.Copy(this.items, this.headIndex, newItems, 0, this.count);
            this.items = newItems;
            this.headIndex = 0;
            this.tailIndex = this.count;
            this.capacity = newCapacity;
        }
    }
}
