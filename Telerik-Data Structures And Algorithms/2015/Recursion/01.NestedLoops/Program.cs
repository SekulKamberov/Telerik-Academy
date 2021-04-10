namespace _01.NestedLoops
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
                Console.WriteLine();
                var array = new int[n];
                SimulateNestedLoops(array, 0);
            }
        }

        private static void SimulateNestedLoops(int[] numbers, int i)
        {
            if (i == numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int j = 1; j <= numbers.Length; j++)
            {
                numbers[i] = j; 
                SimulateNestedLoops(numbers, i + 1);
            }
        }
    }
}
