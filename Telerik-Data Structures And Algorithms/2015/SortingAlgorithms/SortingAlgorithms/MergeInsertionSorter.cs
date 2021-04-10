namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeInsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            IList<T> sortedCollection = this.MergeSort(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = sortedCollection[i];
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 8)
            {
                var sorter = new InsertionSorter<T>();
                sorter.Sort(collection);
                return collection;
            }

            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = collection.Count / 2;
            IList<T> left = new List<T>();
            for (int index = 0; index < middle; index++)
            {
                left.Add(collection[index]);
            }

            IList<T> right = new List<T>();
            for (int index = middle; index < collection.Count; index++)
            {
                right.Add(collection[index]);
            }

            left = this.MergeSort(left);
            right = this.MergeSort(right);
            return this.Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            IList<T> mergedCollection = new List<T>();
            while (left.Count > leftIndex || right.Count > rightIndex)
            {
                if (left.Count > leftIndex && right.Count > rightIndex)
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                    {
                        mergedCollection.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        mergedCollection.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (right.Count > rightIndex)
                {
                    mergedCollection.Add(right[rightIndex]);
                    rightIndex++;
                }
                else if (left.Count > leftIndex)
                {
                    mergedCollection.Add(left[leftIndex]);
                    leftIndex++;
                }
            }

            return mergedCollection;
        }
    }
}