namespace PermutationsWithoutRepetitions
{
    using System;

    /// <summary>
    /// apple, banana, orange
    /// apple, orange, banana
    /// banana, apple, orange
    /// banana, orange, apple
    /// orange, banana, apple
    /// orange, apple, banana
    /// </summary>
    public class PermutationsGenerator
    {
        public static void Main()
        {
            string[] arr = { "apple", "banana", "orange" };
            GeneratePermutations(arr, 0);
        }

        private static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
