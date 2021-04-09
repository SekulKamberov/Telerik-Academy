/*
 * Problem 20: By using delegates develop an universal static method to calculate the sum of infinite 
    convergent series with given precision depending on a function of its term. By using proper functions 
    for the term calculate with a 2-digit precision the sum of the infinite series:
 
        Example 1: 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
        Example 2: 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
        Example 3: 1 + 1/2 - 1/4 + 1/8 - 1/16 + …
 */

namespace _20.InfiniteConvergentSeries
{
    using System;
    using System.Linq;

    public class CalculateSum
    {
        public static void Main()
        {
            Console.WriteLine(Sum(m => 1 / (decimal)Math.Pow(2, m - 1)));                    //Example 1
            Console.WriteLine(Sum(m => 1m / Enumerable.Range(1,m).Aggregate((a,b) => a*b)));    //Example 2
            Console.WriteLine(Sum(m => -1 / (decimal)Math.Pow(-2,m-1)));                            //Example 3
        }

        private static decimal Sum(Func<int, decimal> function)
        {
            decimal sum = 1;

            for (int i = 2; Math.Abs(function(i)) > 0.001m; i++)
            {
                sum += function(i);
            }

            return sum;
        }
    }
}