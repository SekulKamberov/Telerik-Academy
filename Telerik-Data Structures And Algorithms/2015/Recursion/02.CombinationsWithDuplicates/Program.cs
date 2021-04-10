namespace _02.CombinationsWithDuplicates
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("N = ");
                var n = int.Parse(Console.ReadLine());
                Console.Write("K = ");
                var k = int.Parse(Console.ReadLine());
                Console.WriteLine();
                var numbers = new int[k];
                ArrayCombinations(numbers, n, 0);
            }
        }

        private static void ArrayCombinations(int[] numbers, int n, int index)
        {
            if (index == numbers.Length)
            {
                Console.WriteLine(string.Join(string.Empty, numbers));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                numbers[index] = i;
                if (index == 0 || numbers[index - 1] <= numbers[index])
                {
                    ArrayCombinations(numbers, n, index + 1);
                }
            }
        }
    }
}
