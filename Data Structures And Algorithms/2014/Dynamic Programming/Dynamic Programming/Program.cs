using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Programming
{
    static class Extensions
    {
        //public static void ForEach<T>(this IEnumerable<T> collection,
        //    Action<T> action)
        //{
        //    foreach (var item in collection)
        //    {
        //        action(item);
        //    }
        //}
    }
    class Program
    {
        

        static void Main(string[] args)
        {
            int[] numbers = {-3, 2, 5, 3};
            //int[] weight = {1, 2, 3, 4 };
            //string[] names = {"A", "B", "C", "D" };
            var sums = CalculateSums(numbers);
            //var sumsW = CalculateSums(weight);

            foreach (var sum in sums)
            {
                Console.WriteLine(sum);
            }

            //foreach (var sum in sumsW)
            //{
            //    Console.WriteLine("Weigth: " + sum);
            //}
        }

        private static IEnumerable<int> CalculateSums(int[] numbers)
        {
            // with negative numbers
            int minSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    minSum += numbers[i];
                }
            }

            int maxSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    maxSum += numbers[i];
                }
            }

            //or int maxSum = numbers.Where(n => n > 0).Sum();

            int offset = (-1 * minSum) ;

            bool[] possibleSums = new bool[maxSum + offset + 1];

            possibleSums[offset] = true;

            var isZeroPresent = false;
            int currentMaxSum = 0;
            int currentMinSum = 0;
            int currentMinSumWithNumber;
            int currentMaxSumWithNumber;

            foreach (var number in numbers)
            {
                if (!isZeroPresent && number == 0)
                {
                    isZeroPresent = true;
                }

                currentMaxSumWithNumber = currentMaxSum;
                currentMinSumWithNumber = currentMinSum;

                List<int> toAdd = new List<int>();

                for (int i = currentMaxSum; i >= currentMinSum; i--)
                {
                    if (possibleSums[offset + i])
                    {
                        if (currentMinSumWithNumber > i + number)
                        {
                            currentMinSumWithNumber = i + number;
                        }

                        if (currentMaxSumWithNumber < i + number)
                        {
                            currentMaxSumWithNumber = i + number;
                        }

                        if(number >= 0)
                        {
                            possibleSums[offset + i + number] = true;
                            if ((number + i == 0))
                            {
                                isZeroPresent = true;
                            }
                        }
                        else
                        {
                            // if i == 0 && !isZeroPresent nothing adds
                            if(isZeroPresent || i != 0)
                            {
                                toAdd.Add(i + number);
                            }
                            else if(number < 0 && i == 0)
                            {
                                toAdd.Add(i + number);
                            }
                        }

                    }
                    else
                    {
                        if ((number + i == 0))
                        {
                            isZeroPresent = true;
                        }
                    }
                }

                foreach (var num in toAdd)
                {
                    possibleSums[num + offset] = true;
                    if ((num)== 0)
                    {
                        isZeroPresent = true;
                    }
                }

                currentMinSum = currentMinSumWithNumber;
                currentMaxSum = currentMaxSumWithNumber;
            }

            var sums = new List<int>();

            for (int i = 0; i < possibleSums.Length; i++)
            {
                if (possibleSums[i])
                {
                    if ((i - offset) == 0 && isZeroPresent == false)
                    {

                    }
                    else
                    {
                        sums.Add(i - offset);
                    }
                }
            }

            return sums;
        }
    }
}
