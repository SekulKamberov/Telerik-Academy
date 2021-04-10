namespace _03.SupperSum
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int[,] memo;

        public static void Main(string[] args)
        {
            SupperSumDynamicPrograming();

            // SupperSumRecursive();
        }

        private static void SupperSumDynamicPrograming()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int k = input[0];
            int n = input[1];
            var matrix = new int[k + 1, n + 1];
            matrix[k, n] = 1;

            for (int i = k; i >= 1; i--)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        for (int l = 1; l <= j; l++)
                        {
                            matrix[i - 1, l] += matrix[i, j];
                        }
                    }
                }
            }

            int sum = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                sum += matrix[0, i] * i;
            }

            Console.WriteLine(sum);
        }

        private static void SupperSumRecursive()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int k = input[0];
            int n = input[1];
            memo = new int[k + 1, n + 1];
            memo[k, n] = 1;
            Console.WriteLine(EvalSum(k, n));
        }

        private static int EvalSum(int k, int n)
        {
            if (k == 0)
            {
                return n;
            }

            int subSum = 0;
            for (int i = 1; i <= n; i++)
            {
                subSum += EvalSum(k - 1, i);
            }

            memo[k, n] = subSum;
            return memo[k, n];
        }
    }
}