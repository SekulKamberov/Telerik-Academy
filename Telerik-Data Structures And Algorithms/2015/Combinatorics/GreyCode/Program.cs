namespace GreyCode
{
    using System;

    public class GrayCodeGenerator
    {
        private const int N = 4;
        private static int[] arr = new int[N];

        public static void Main()
        {
            ForwardGray(N - 1);
        }

        private static void ForwardGray(int k)
        {
            if (k < 0)
            {
                Print();
                return;
            }

            arr[k] = 0;
            ForwardGray(k - 1);
            arr[k] = 1;
            BackwardGray(k - 1);
        }

        private static void BackwardGray(int k)
        {
            if (k < 0)
            {
                Print();
                return;
            }

            arr[k] = 1;
            ForwardGray(k - 1);
            arr[k] = 0;
            BackwardGray(k - 1);
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
