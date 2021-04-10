namespace LongestSequence
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new int[] { 3, 1, 5, 7, 7, 7, 2, 4, 6, 1, 8 };
            var sequenceOfNumbers = new Sequence(numbers);

            var sequenceCount = sequenceOfNumbers.LongestIncreasingSet();
            Console.WriteLine("\nLongest Increasing Subset");
            Console.WriteLine("Numbers:  " + string.Join(", ", numbers));
            Console.WriteLine("Sequence: " + string.Join(", ", sequenceCount));

            sequenceCount = sequenceOfNumbers.LongestIncreasingSetWithEquals();
            Console.WriteLine("\nLongest Increasing Subset (with equals)");
            Console.WriteLine("Numbers:  " + string.Join(", ", numbers));
            Console.WriteLine("Sequence: " + string.Join(", ", sequenceCount));

            sequenceCount = sequenceOfNumbers.LongestDecreasingSet();
            Console.WriteLine("\nLongest Decreasing Subset");
            Console.WriteLine("Numbers:  " + string.Join(", ", numbers));
            Console.WriteLine("Sequence: " + string.Join(", ", sequenceCount));

            sequenceCount = sequenceOfNumbers.LongestDecreasingSetWithEquals();
            Console.WriteLine("\nLongest Decreasing Subset (with equals)");
            Console.WriteLine("Numbers:  " + string.Join(", ", numbers));
            Console.WriteLine("Sequence: " + string.Join(", ", sequenceCount));

            Console.WriteLine();
            numbers = new int[] { 33, 11, 55, 55, 22, 77 };
            sequenceOfNumbers = new Sequence(numbers);

            Console.WriteLine("\nLongest Increasing Set And Path");
            var sequenceCountAndPath = sequenceOfNumbers.LongestIncreasingSetAndPath();
            PrintSetAndPath(sequenceCountAndPath, numbers);

            Console.WriteLine("\nLongest Increasing Set And Path (with equals)");
            sequenceCountAndPath = sequenceOfNumbers.LongestIncreasingSetAndPathWithEquals();
            PrintSetAndPath(sequenceCountAndPath, numbers);

            Console.WriteLine("\nLongest Decreasing Set And Path");
            sequenceCountAndPath = sequenceOfNumbers.LongestDecreasingSetAndPath();
            PrintSetAndPath(sequenceCountAndPath, numbers);

            Console.WriteLine("\nLongest Decreasing Set And Path (with equals)");
            sequenceCountAndPath = sequenceOfNumbers.LongestDecreasingSetAndPathWithEquals();
            PrintSetAndPath(sequenceCountAndPath, numbers);
        }

        private static void PrintSetAndPath(int[,] sequenceCountAndPath, int[] numbers)
        {
            Console.Write("index          | ");
            for (int i = 0; i < sequenceCountAndPath.GetLength(0); i++)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.Write("number         | ");
            Console.WriteLine(string.Join("\t", numbers));
            Console.WriteLine("-------------------------------------------");

            for (int i = 0; i < sequenceCountAndPath.GetLength(1); i++)
            {
                if (i == 0)
                {
                    Console.Write("length         | ");
                }
                else
                {
                    Console.Write("previous index | ");
                }

                for (int j = 0; j < sequenceCountAndPath.GetLength(0); j++)
                {
                    Console.Write(sequenceCountAndPath[j, i] + "\t");
                }

                Console.WriteLine();
                Console.WriteLine("-------------------------------------------");
            }

            Console.WriteLine();
        }
    }
}
