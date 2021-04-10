namespace _12.Stack
{
    using System;

    public class Stack<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int capacity;
        private int count;

        public Stack()
        {
            this.items = new T[4];
            this.capacity = InitialCapacity;
            this.count = 0;
        }

        public int Count 
        {
            get
            {
                return this.count;
            }
        }

        public void Push(T item)
        {
            if (this.count == this.capacity)
            {
                this.IncreaseCapacity();
            }

            this.items[this.count] = item;
            this.count++;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("No items in the basket!");
            }

            this.count--;
            return this.items[this.count];
        }

        public void Clear()
        {
            this.count = 0;
        }

        public bool Contains(T item)
        {
            if (this.count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.count; i++)
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
            Array.Copy(this.items, newItems, this.count);
            this.items = newItems;
            this.capacity = this.count;
        }

        public T Peek()
        {
            return this.items[this.count - 1];
        }

        public override string ToString()
        {
            var itemsToDisplay = new T[this.count];
            Array.Copy(this.items, itemsToDisplay, this.count);
            var valuesMessage = itemsToDisplay.Length != 0 ? string.Join(", ", itemsToDisplay) : "No items";
            return string.Format("Values: {0} \nCapacity: {1} \nCount: {2}\n", valuesMessage, this.capacity, this.count);
        }

        private void IncreaseCapacity()
        {
            var newCapacity = this.capacity * 2;
            var newItems = new T[newCapacity];
            Array.Copy(this.items, newItems, this.capacity);
            this.items = newItems;
            this.capacity = newCapacity;
        }
    }
}
