namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int partitionIndex = this.Partition(collection, startIndex, endIndex);
            this.QuickSort(collection, startIndex, partitionIndex - 1);
            this.QuickSort(collection, partitionIndex + 1, endIndex);
        }

        private int Partition(IList<T> collection, int startIndex, int endIndex)
        {
            T pivot = collection[endIndex];
            int partitionIndex = startIndex - 1;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    partitionIndex++;
                    T temp = collection[partitionIndex];
                    collection[partitionIndex] = collection[i];
                    collection[i] = temp;
                }
            }

            T tempValue = collection[partitionIndex + 1];
            collection[partitionIndex + 1] = collection[endIndex];
            collection[endIndex] = tempValue;
            return partitionIndex + 1;
        }
    }
}
