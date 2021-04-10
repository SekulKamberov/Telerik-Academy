namespace AdvancedDataStructures
{
    using System.Collections.Generic;

    public class StringComparerDescending : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(y, x);
        }
    }
}