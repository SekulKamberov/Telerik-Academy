namespace Recursion
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        private static int[] memo;

        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int n = 40;
            sw.Start();
            Console.WriteLine(Fibonacci(n));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            memo = new int[n + 1];
            Console.WriteLine(FibonacciMemoization(n));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            Console.WriteLine(FibonacciDynamic(n));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static int FibonacciMemoization(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            memo[n] = FibonacciMemoization(n - 1) + FibonacciMemoization(n - 2);
            return memo[n];
        }

        private static int FibonacciDynamic(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int[] memo = new int[n + 1];
            memo[0] = 0;
            memo[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[n];
        }
    }
}
