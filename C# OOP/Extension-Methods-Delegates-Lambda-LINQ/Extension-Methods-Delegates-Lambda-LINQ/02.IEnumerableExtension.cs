namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        // 02. Implement a set of extension methods for IEnumerable<T> that implement the following group functions: 
        //     sum, product, min, max, average.
        public static T Sum<T>(this IEnumerable<T> list)
        {
            dynamic sum = 0;
            bool isEmpty = true;

            foreach (var item in list)
            {
                isEmpty = false;
                sum += item;
            }

            if (isEmpty)
            {
                throw new ArgumentException("Collection is empty.");
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> list)
        {
            dynamic product = 1;
            bool isEmpty = true;

            foreach (var item in list)
            {
                isEmpty = false;
                product *= item;
            }

            if (isEmpty)
            {
                throw new ArgumentException("Collection is empty.");
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> list)
            where T : IComparable<T>
        {
            IEnumerator<T> enumerator = list.GetEnumerator();
            bool isEmpty = enumerator.MoveNext();

            if (!isEmpty)
            {
                throw new ArgumentException("Collection is empty.");
            }

            T min = enumerator.Current;

            foreach (var item in list)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> list)
            where T : IComparable<T>
        {
            IEnumerator<T> enumerator = list.GetEnumerator();
            bool isEmpty = enumerator.MoveNext();

            if (!isEmpty)
            {
                throw new ArgumentException("Collection is empty.");
            }

            T max = enumerator.Current;

            foreach (var item in list)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> list)
        {
            IEnumerator<T> enumerator = list.GetEnumerator();
            bool isEmpty = enumerator.MoveNext();

            if (!isEmpty)
            {
                throw new ArgumentException("Collection is empty.");
            }

            dynamic sum = list.Sum();
            int count = 1;

            while (enumerator.MoveNext() == true)
            {
                count += 1;
            }

            return sum / count;
        }     
    }
}
