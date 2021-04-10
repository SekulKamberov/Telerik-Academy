using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> set = new Set<int>();
            set.Add(2);
            Console.WriteLine(set.Find(2));
            set.Remove(2);
            Console.WriteLine(set.Find(2));
            set.Add(2);
            set.Add(2);
            Console.WriteLine(set.Find(2));
            Console.WriteLine(set.Count());
            //set.Remove(1);
            set.Clear();
            Console.WriteLine(set.Find(2));
            Console.WriteLine(set.Count());
            set.Add(1);
            set.Add(2);
            set.Add(4);
            set.Add(6);
            Set<int> set2 = new Set<int>();
            set2.Add(2);
            set2.Add(4);
            set2.Add(5);
            Console.WriteLine();

            Console.Write("Set 1: ");
            foreach (var item in set.values)
            {
                Console.Write(item.Key + " ");
            }
            Console.WriteLine();

            Console.Write("Set 2: ");
            foreach (var item in set2.values)
            {
                Console.Write(item.Key + " ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Set<int> set3 = set.Union(set2);
            Console.WriteLine("---UNION---");
            foreach (var item in set3.values)
            {
                Console.WriteLine(item.Key);   
            }

            Console.WriteLine();
            Set<int> set4 = set.Intersects(set2);
            Console.WriteLine("---Intersect---");
            foreach (var item in set4.values)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
