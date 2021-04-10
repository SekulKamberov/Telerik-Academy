namespace _11.PermutationsWithRepetition
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var arr = new int[] { 1, 3, 5, 5 };
            PermuteRep(arr, 0, arr.Length);
        }

        private static void PermuteRep(int[] arr, int start, int n)
        {
            Console.WriteLine(string.Join(", ", arr));
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        private static void Swap<T>(ref T param1, ref T param2)
        {
            var temp = param1;
            param1 = param2;
            param2 = temp;
        }
    }
}