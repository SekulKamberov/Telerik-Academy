namespace CombinationsWithoutRepetitions
{
    using System;

    /// <summary>
    /// (0, 1, 2) --> ( banana apple orange )
    /// (0, 1, 3) --> ( banana apple strawberry )
    /// (0, 1, 4) --> ( banana apple raspberry )
    /// (0, 2, 3) --> ( banana orange strawberry )
    /// (0, 2, 4) --> ( banana orange raspberry )
    /// (0, 3, 4) --> ( banana strawberry raspberry )
    /// (1, 2, 3) --> ( apple orange strawberry )
    /// (1, 2, 4) --> ( apple orange raspberry )
    /// (1, 3, 4) --> ( apple strawberry raspberry )
    /// (2, 3, 4) --> ( orange strawberry raspberry )
    /// </summary>
    public class CombinationsGeneratorNoReps
    {
        private const int N = 5;
        private const int K = 2;
        private static string[] objects = new string[N] { "banana", "apple", "orange", "strawberry", "raspberry" };
        private static int[] arr = new int[K];

        private static void Main()
        {
            GenerateCombinationsNoRepetitions(0, 0);
        }

        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= K)
            {
                PrintVariations();
            }
            else
            {
                //for (int i = N - 1; i >= start; i--)
                //{
                //    arr[index] = i;
                //    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                //}
                for (int i = start; i < N; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        private static void PrintVariations()
        {
            Console.Write("(" + string.Join(", ", arr) + ") --> ( ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }

            Console.WriteLine(")");
        }
    }
}
