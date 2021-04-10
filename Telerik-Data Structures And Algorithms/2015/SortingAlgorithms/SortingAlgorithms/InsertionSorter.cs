namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            this.InsertionSort(collection);
        }

        private void InsertionSort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (collection[j - 1].CompareTo(collection[j]) > 0)
                    {
                        T temp = collection[j - 1];
                        collection[j - 1] = collection[j];
                        collection[j] = temp;
                    }
                }
            }
        }
    }
}
