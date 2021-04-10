﻿namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static Random random = new Random();
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int startIndex = 0;
            int endIndex = this.items.Count - 1;
            int searchedIndex = -1;
            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                if (item.CompareTo(this.items[middleIndex]) < 0)
                {
                    endIndex = middleIndex - 1;
                }
                else if (item.CompareTo(this.items[middleIndex]) > 0)
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    searchedIndex = middleIndex;
                    break;
                }
            }

            return searchedIndex != -1;
        }

        /// <summary>
        /// Fisher and Yates (The modern algorithm)
        /// </summary>
        public void Shuffle()
        {
            var length = this.items.Count;

            for (int i = length - 1; i >= 1; i--)
            {
                var newPosition = random.Next(0, i + 1);
                this.Swap(i, newPosition);
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        public SortableCollection<T> GetCopy()
        {
            var copy = new SortableCollection<T>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                copy.Items.Add(this.Items[i]);
            }

            return copy;
        }

        private void Swap(int currentIndex, int newIndex)
        {
            var temp = this.items[currentIndex];
            this.items[currentIndex] = this.items[newIndex];
            this.items[newIndex] = temp;
        }
    }
}
