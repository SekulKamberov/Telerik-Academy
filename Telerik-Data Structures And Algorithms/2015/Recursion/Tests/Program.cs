namespace Tests
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var length = 2;
            var bytes = new int[length];

            // IterateVector(bytes, 0);
            // VectorCombinations(bytes, 0, 3, 8);
            var numbers = new int[] { 1, 3, 5, 7, 9 };
            ArrayCombinations(bytes, numbers, 0, 0);
        }

        private static void IterateVector(int[] bytes, int index)
        {
            if (index == bytes.Length)
            {
                Console.WriteLine(string.Join(string.Empty, bytes));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                bytes[index] = i;
                IterateVector(bytes, index + 1);
            }
        }

        private static void VectorCombinations(int[] bytes, int index, int start, int end)
        {
            if (index == bytes.Length)
            {
                Console.WriteLine(string.Join(string.Empty, bytes));
                return;
            }

            for (int i = start; i <= end; i++)
            {
                bytes[index] = i;
                VectorCombinations(bytes, index + 1, i + 1, end);
            }
        }

        private static void ArrayCombinations(int[] bytes, int[] elements, int index, int setIndex)
        {
            if (index == bytes.Length)
            {
                Console.WriteLine(string.Join(string.Empty, bytes));
                return;
            }

            for (int i = setIndex; i < elements.Length; i++)
            {
                bytes[index] = elements[i];
                ArrayCombinations(bytes, elements, index + 1, i + 1);
            }
        }
    }
}
