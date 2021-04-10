namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UpgradedSelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection to sort cannot be null!");
            }

            int length = collection.Count;
            
            for (int i = 0; i < length - 1; i++)
            {
                int minIndex = i;
                int startMaxIndex = length - 1 - i;
                int maxIndex = startMaxIndex;
                for (int j = i; j <= startMaxIndex; j++)
                {
                    if (collection[j].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = j;
                    }

                    if (collection[j].CompareTo(collection[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    this.Swap(collection, i, minIndex);
                }
                
                if (maxIndex != startMaxIndex)
                {
                    if (i == maxIndex && minIndex != i)
                    {
                        this.Swap(collection, startMaxIndex, minIndex);
                    }
                    else
                    {
                        this.Swap(collection, startMaxIndex, maxIndex);
                    }
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