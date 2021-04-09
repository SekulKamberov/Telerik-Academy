/*
 * Problem 2: Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
            sum, product, min, max, average.
*/
namespace _02.IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableT
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            //if collection is empty .FirstOrDefault throws an exception
            T result = collection.FirstOrDefault();

            //first element is checked so we skip it 
            foreach (var item in collection.Skip(1))
            {
                result += (dynamic)item;
            }

            return result;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            T result = collection.FirstOrDefault();

            foreach (var item in collection.Skip(1))
            {
                result *= (dynamic)item;
            }

            return result;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T firstElement = collection.FirstOrDefault();

            foreach (var item in collection.Skip(1))
            {
                if (firstElement.CompareTo(item) == -1)
                {
                    firstElement = item;
                }
            }

            return firstElement;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T firstElement = collection.FirstOrDefault();

            foreach (var item in collection.Skip(1))
            {
                if (firstElement.CompareTo(item) == 1)
                {
                    firstElement = item;
                }
            }

            return firstElement;
        }

        public static T Average<T>(this IEnumerable<T> collection)
        {
            T result = collection.FirstOrDefault();

            int count = 1;
            foreach (var item in collection.Skip(1))
            {
                result += (dynamic)item;
                count++;
            }

            return (dynamic)result / count;
        }

        public class Test
        {
            public static void Main()
            {
                IEnumerable<double> numbers = new double[] { 2.0, 3.5, 4.2, 5.1 };

                Console.Write("Collection: ");
                foreach (var item in numbers)
                {
                    Console.Write("{0:F1} ", item);
                }
                Console.WriteLine();
                Console.WriteLine("Sum: {0:F1}", IEnumerableT.Sum<double>(numbers));
                Console.WriteLine("Product: {0:F1}", IEnumerableT.Product<double>(numbers));
                Console.WriteLine("Min: {0:F1}", IEnumerableT.Min<double>(numbers));
                Console.WriteLine("Max: {0:F1}", IEnumerableT.Max<double>(numbers));
                Console.WriteLine("Average: {0:F1}", IEnumerableT.Average<double>(numbers));
            }
        }
    }
}
