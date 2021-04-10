namespace CombinationsWithrepetition
{
    using System;
    
    /// <summary>
    /// (0, 0, 0) --> ( banana banana banana )
    /// (0, 0, 1) --> ( banana banana apple )
    /// (0, 0, 2) --> ( banana banana orange )
    /// (0, 0, 3) --> ( banana banana strawberry )
    /// (0, 0, 4) --> ( banana banana raspberry )
    /// (0, 1, 1) --> ( banana apple apple )
    /// (0, 1, 2) --> ( banana apple orange )
    /// (0, 1, 3) --> ( banana apple strawberry )
    /// (0, 1, 4) --> ( banana apple raspberry )
    /// (0, 2, 2) --> ( banana orange orange )
    /// (0, 2, 3) --> ( banana orange strawberry )
    /// (0, 2, 4) --> ( banana orange raspberry )
    /// (0, 3, 3) --> ( banana strawberry strawberry )
    /// (0, 3, 4) --> ( banana strawberry raspberry )
    /// (0, 4, 4) --> ( banana raspberry raspberry )
    /// (1, 1, 1) --> ( apple apple apple )
    /// (1, 1, 2) --> ( apple apple orange )
    /// (1, 1, 3) --> ( apple apple strawberry )
    /// (1, 1, 4) --> ( apple apple raspberry )
    /// (1, 2, 2) --> ( apple orange orange )
    /// (1, 2, 3) --> ( apple orange strawberry )
    /// (1, 2, 4) --> ( apple orange raspberry )
    /// (1, 3, 3) --> ( apple strawberry strawberry )
    /// (1, 3, 4) --> ( apple strawberry raspberry )
    /// (1, 4, 4) --> ( apple raspberry raspberry )
    /// (2, 2, 2) --> ( orange orange orange )
    /// (2, 2, 3) --> ( orange orange strawberry )
    /// (2, 2, 4) --> ( orange orange raspberry )
    /// (2, 3, 3) --> ( orange strawberry strawberry )
    /// (2, 3, 4) --> ( orange strawberry raspberry )
    /// (2, 4, 4) --> ( orange raspberry raspberry )
    /// (3, 3, 3) --> ( strawberry strawberry strawberry
    /// (3, 3, 4) --> ( strawberry strawberry raspberry )
    /// (3, 4, 4) --> ( strawberry raspberry raspberry )
    /// (4, 4, 4) --> ( raspberry raspberry raspberry )
    /// </summary>
    public class CombinationsGeneratorWithReps
    {
        private const int N = 5;
        private const int K = 3;
        private static string[] objects = new string[N] { "banana", "apple", "orange", "strawberry", "raspberry" };
        private static int[] arr = new int[K];

        private static void Main()
        {
            GenerateCombinationsWithRepetitions(0, 0);
        }

        private static void GenerateCombinationsWithRepetitions(int index, int start)
        {
            if (index >= K)
            {
                PrintVariations();
            }
            else
            {
                for (int i = start; i < N; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsWithRepetitions(index + 1, i);
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
