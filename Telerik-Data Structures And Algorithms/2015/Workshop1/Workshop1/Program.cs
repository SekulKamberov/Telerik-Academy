namespace Workshop1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] jedies = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var jediesOrdered = new SortedSet<string>(new JediComparerer());
            foreach (var jedi in jedies)
            {
                jediesOrdered.Add(jedi);
            }

            Console.WriteLine(string.Join(" ", jediesOrdered));
        }
    }

    public class JediComparerer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x[0] == 'm' && y[0] == 'm')
            {
                return 1;
            }
            else if (x[0] == 'm')
            {
                return -1;
            }
            else if (y[0] == 'm')
            {
                return 1;
            }
            else if (x[0] == 'k' && y[0] == 'k')
            {
                return 1;
            }
            else if (x[0] == 'k')
            {
                return -1;
            }
            else if (y[0] == 'k')
            {
                return 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
