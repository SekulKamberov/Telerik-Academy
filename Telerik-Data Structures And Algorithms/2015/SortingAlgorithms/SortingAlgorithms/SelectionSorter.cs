namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    this.Swap(collection, i, minIndex);
                }
            }
        }

        private void Swap(IList<T> array, int firstElementIndex, int secondElementIndex)
        {
            var temp = array[firstElementIndex];
            array[firstElementIndex] = array[secondElementIndex];
            array[secondElementIndex] = temp;
        }
    }
}