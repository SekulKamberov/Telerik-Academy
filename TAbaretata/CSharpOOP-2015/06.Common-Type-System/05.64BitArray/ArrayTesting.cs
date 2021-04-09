/*
 * Problem 5: Define a class BitArray64 to hold 64 bit values inside an ulong value.
    Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
 */

namespace _05._64BitArray
{
    using System;

    public class ArrayTesting
    {
        public static void Main()
        {
            var longNum = new BitArray64();

            longNum[20] = 1;
            longNum[4] = 1;
            longNum[31] = 1;
            longNum[55] = 1;

            Console.WriteLine(longNum);
        }
    }
}
