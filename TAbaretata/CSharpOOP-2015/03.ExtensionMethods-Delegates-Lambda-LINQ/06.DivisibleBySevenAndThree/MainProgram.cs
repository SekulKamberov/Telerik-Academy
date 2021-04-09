namespace _06.DivisibleBySevenAndThree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainProgram
    {
        public static IEnumerable<int> LambdaExpressionResult(IList<int> arr)
        {
            var lambdaResult = arr.Where(n => n % 3 == 0 && n % 7 == 0);
            return lambdaResult;
        }

        public static IEnumerable<int> LinqQueryResult(IList<int> arr)
        {
            var linqQueryResult =
                    from n in arr
                    where n % 3 == 0 && n % 7 == 0
                    select n;

            return linqQueryResult;
        }

        public static void Print(IEnumerable<int> arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            int[] arr = new[] { 5, 3, 7, 15, 35, 45, 70, 140, 340, 459, 700, 1010, 66, 21, 63 };

            Console.WriteLine("Numbers divisible by 3 and 7 at the same time. \r\nLambda expression results: ");

            Print(LambdaExpressionResult(arr));

            Console.WriteLine("Linq query results: ");

            Print(LinqQueryResult(arr));
        }
    }
}
