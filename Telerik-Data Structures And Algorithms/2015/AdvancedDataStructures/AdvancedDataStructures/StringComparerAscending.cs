namespace AdvancedDataStructures
{
    using System.Collections.Generic;

    public class StringComparerAscending : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y);
        }
    }
}