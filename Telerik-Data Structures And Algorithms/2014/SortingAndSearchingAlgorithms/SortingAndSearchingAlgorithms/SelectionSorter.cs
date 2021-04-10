namespace SortingHomework
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
            var len = collection.Count;
            for (int i = 0; i < len - 1; i++)
            {
                int iMin = i;
                for (int j = i + 1; j < len; j++)
                {
                    int bigger = collection[iMin].CompareTo(collection[j]);
                    if (bigger == 1)
                    {
                        iMin = j;
                    }
                }
                //SWAP
                if (iMin != i)
                {
                    var helper = collection[i];
                    collection[i] = collection[iMin];
                    collection[iMin] = helper;
                }
            }
        }
    }
}
