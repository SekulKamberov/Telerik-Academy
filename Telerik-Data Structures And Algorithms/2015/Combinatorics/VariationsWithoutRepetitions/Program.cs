namespace VariationsWithoutRepetitions
{
    using System;

    /// <summary>
    /// (0, 1, 2) --> ( banana apple orange )
    /// (0, 1, 3) --> ( banana apple strawberry )
    /// (0, 2, 1) --> ( banana orange apple )
    /// (0, 2, 3) --> ( banana orange strawberry )
    /// (0, 3, 1) --> ( banana strawberry apple )
    /// (0, 3, 2) --> ( banana strawberry orange )
    /// (1, 0, 2) --> ( apple banana orange )
    /// (1, 0, 3) --> ( apple banana strawberry )
    /// (1, 2, 0) --> ( apple orange banana )
    /// (1, 2, 3) --> ( apple orange strawberry )
    /// (1, 3, 0) --> ( apple strawberry banana )
    /// (1, 3, 2) --> ( apple strawberry orange )
    /// (2, 0, 1) --> ( orange banana apple )
    /// (2, 0, 3) --> ( orange banana strawberry )
    /// (2, 1, 0) --> ( orange apple banana )
    /// (2, 1, 3) --> ( orange apple strawberry )
    /// (2, 3, 0) --> ( orange strawberry banana )
    /// (2, 3, 1) --> ( orange strawberry apple )
    /// (3, 0, 1) --> ( strawberry banana apple )
    /// (3, 0, 2) --> ( strawberry banana orange )
    /// (3, 1, 0) --> ( strawberry apple banana )
    /// (3, 1, 2) --> ( strawberry apple orange )
    /// (3, 2, 0) --> ( strawberry orange banana )
    /// (3, 2, 1) --> ( strawberry orange apple )
    /// </summary>
    public class VariationsGeneratorNoReps
    {
        private const int N = 4;
        private const int K = 3;
        private static string[] objects = new string[N] { "banana", "apple", "orange", "strawberry" };
        private static int[] arr = new int[K];
        private static bool[] used = new bool[N];

        public static void Main()
        {
            GenerateVariationsNoRepetitions(0);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= K)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
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
