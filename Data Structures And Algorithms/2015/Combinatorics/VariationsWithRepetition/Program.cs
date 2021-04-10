namespace VariationsWithRepetition
{
    using System;

    /// <summary>
    /// (0, 0, 0) --> ( banana banana banana )
    /// (0, 0, 1) --> ( banana banana apple )
    /// (0, 0, 2) --> ( banana banana orange )
    /// (0, 0, 3) --> ( banana banana melon )
    /// (0, 1, 0) --> ( banana apple banana )
    /// (0, 1, 1) --> ( banana apple apple )
    /// (0, 1, 2) --> ( banana apple orange )
    /// (0, 1, 3) --> ( banana apple melon )
    /// (0, 2, 0) --> ( banana orange banana )
    /// (0, 2, 1) --> ( banana orange apple )
    /// (0, 2, 2) --> ( banana orange orange )
    /// (0, 2, 3) --> ( banana orange melon )
    /// (0, 3, 0) --> ( banana melon banana )
    /// (0, 3, 1) --> ( banana melon apple )
    /// (0, 3, 2) --> ( banana melon orange )
    /// (0, 3, 3) --> ( banana melon melon )
    /// (1, 0, 0) --> ( apple banana banana )
    /// (1, 0, 1) --> ( apple banana apple )
    /// (1, 0, 2) --> ( apple banana orange )
    /// (1, 0, 3) --> ( apple banana melon )
    /// (1, 1, 0) --> ( apple apple banana )
    /// (1, 1, 1) --> ( apple apple apple )
    /// (1, 1, 2) --> ( apple apple orange )
    /// (1, 1, 3) --> ( apple apple melon )
    /// (1, 2, 0) --> ( apple orange banana )
    /// (1, 2, 1) --> ( apple orange apple )
    /// (1, 2, 2) --> ( apple orange orange )
    /// (1, 2, 3) --> ( apple orange melon )
    /// (1, 3, 0) --> ( apple melon banana )
    /// (1, 3, 1) --> ( apple melon apple )
    /// (1, 3, 2) --> ( apple melon orange )
    /// (1, 3, 3) --> ( apple melon melon )
    /// (2, 0, 0) --> ( orange banana banana )
    /// (2, 0, 1) --> ( orange banana apple )
    /// (2, 0, 2) --> ( orange banana orange )
    /// (2, 0, 3) --> ( orange banana melon )
    /// (2, 1, 0) --> ( orange apple banana )
    /// (2, 1, 1) --> ( orange apple apple )
    /// (2, 1, 2) --> ( orange apple orange )
    /// (2, 1, 3) --> ( orange apple melon )
    /// (2, 2, 0) --> ( orange orange banana )
    /// (2, 2, 1) --> ( orange orange apple )
    /// (2, 2, 2) --> ( orange orange orange )
    /// (2, 2, 3) --> ( orange orange melon )
    /// (2, 3, 0) --> ( orange melon banana )
    /// (2, 3, 1) --> ( orange melon apple )
    /// (2, 3, 2) --> ( orange melon orange )
    /// (2, 3, 3) --> ( orange melon melon )
    /// (3, 0, 0) --> ( melon banana banana )
    /// (3, 0, 1) --> ( melon banana apple )
    /// (3, 0, 2) --> ( melon banana orange )
    /// (3, 0, 3) --> ( melon banana melon )
    /// (3, 1, 0) --> ( melon apple banana )
    /// (3, 1, 1) --> ( melon apple apple )
    /// (3, 1, 2) --> ( melon apple orange )
    /// (3, 1, 3) --> ( melon apple melon )
    /// (3, 2, 0) --> ( melon orange banana )
    /// (3, 2, 1) --> ( melon orange apple )
    /// (3, 2, 2) --> ( melon orange orange )
    /// (3, 2, 3) --> ( melon orange melon )
    /// (3, 3, 0) --> ( melon melon banana )
    /// (3, 3, 1) --> ( melon melon apple )
    /// (3, 3, 2) --> ( melon melon orange )
    /// (3, 3, 3) --> ( melon melon melon )
    /// </summary>
    public class VariationsGenerator
    {
        private const int N = 4;
        private const int K = 3;
        private static string[] objects = new string[N] { "banana", "apple", "orange", "melon" };
        private static int[] arr = new int[K];

        private static void Main()
        {
            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= K)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
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
