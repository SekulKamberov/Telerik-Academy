namespace Stools
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            ulong first = 0;
            ulong second = 1;
            ulong fibonaci = 1;

            for (ulong i = 1; i < n; i++)
            {
                fibonaci = first + second;
                first = second;
                second = fibonaci;
                if (fibonaci >= 1000000007)
                {
                    fibonaci %= 1000000007;
                    first %= 1000000007;
                    second %= 1000000007;
                }
            }

            Console.WriteLine(fibonaci);
        }
    }
}