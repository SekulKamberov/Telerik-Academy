/*
 Task from 5 to 7
*/

namespace _05.GenericList
{
    using System;

    class MainProgram
    {
        static void Main()
        {
            GenericList<int> arr = new GenericList<int>();

            arr.Add(5);
            arr.Add(10);
            arr.Add(14);

            arr.Remove(1);

            arr.Insert(3, 1);

            Console.WriteLine(arr);
            Console.WriteLine("Element with value {0} is at position {1}", 10, arr.ElementByValue(10));
            Console.WriteLine("Max element: {0}", arr.Max<int>());
            Console.WriteLine("Min element: {0}", arr.Min<int>());

            arr.Clear();
            Console.WriteLine("Cleared arr: {0}", arr);

            arr.Add(5);
            arr.Add(10);
            arr.Add(14);
            Console.WriteLine();
            Console.WriteLine("New filled GenericList:");
            Console.WriteLine(arr);
        }
    }
}
