namespace SubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var positiveNumbers = new int[] { 0, 1, 7, 3, 11, 44 };
            var possibleSums = SubsetsSumEvaluator.FindPossibleSums(positiveNumbers);
            Console.WriteLine(string.Join(", ", possibleSums));

            var numbers = new int[] { -100, -50, -25, -1, 2, 15, 90 };
            possibleSums = SubsetsSumEvaluator.FindPossibleSumsWithNegative(numbers);
            Console.WriteLine(string.Join(", ", possibleSums));
        }

        /// <summary>
        /// Evaluates all possible subset sums. Negative numbers not allowed.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static IEnumerable<int> FindPossibleSums(int[] numbers)
        {
            int maxPossibleSum = numbers.Sum();
            bool[] possibleSums = new bool[maxPossibleSum + 1];
            possibleSums[0] = true;
            bool hasZero = false;
            int minSum = 0;
            int maxSum = 0;
            int tempMaxSum = 0;

            foreach (var number in numbers)
            {
                if (!hasZero && number == 0)
                {
                    hasZero = true;
                }

                for (int i = maxSum; i >= minSum; i--)
                {
                    if (possibleSums[i])
                    {
                        var currentNumber = i + number;

                        if (tempMaxSum < currentNumber)
                        {
                            tempMaxSum = currentNumber;
                        }

                        possibleSums[currentNumber] = true;
                    }
                }

                maxSum = tempMaxSum;
            }

            var sums = new List<int>();
            if (hasZero)
            {
                sums.Add(0);
            }

            for (int i = 1; i < possibleSums.Length; i++)
            {
                if (possibleSums[i])
                {
                    sums.Add(i);
                }
            }

            return sums;
        }

        /// <summary>
        /// Evaluates all possible subset sums. Negative numbers allowed.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static IEnumerable<int> FindPossibleSumsWithNegative(int[] numbers)
        {
            // var possitiveNumbers = new List<int>();
            // var negativeNumbers = new List<int>();
            int minPossibleSum = 0;
            int maxPossibleSum = 0;
            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    // possitiveNumbers.Add(number);
                    maxPossibleSum += number;
                }
                else
                {
                    // negativeNumbers.Add(number);
                    minPossibleSum += number;
                }
            }

            int offset = -1 * minPossibleSum;
            bool[] possibleSums = new bool[maxPossibleSum + offset + 1];
            possibleSums[offset] = true;
            bool hasZero = false;
            int minSum = offset;
            int maxSum = offset;
            int tempMinSum = offset;
            int tempMaxSum = offset;

            foreach (var number in numbers.Where(n => n >= 0))
            {
                if (!hasZero && number == 0)
                {
                    hasZero = true;
                }

                tempMaxSum = maxSum;
                for (int i = maxSum; i >= minSum; i--)
                {
                    if (possibleSums[i])
                    {
                        var currentNumber = i + number;

                        if (tempMaxSum < currentNumber)
                        {
                            tempMaxSum = currentNumber;
                        }

                        possibleSums[currentNumber] = true;
                    }
                }

                maxSum = tempMaxSum;
            }

            foreach (var number in numbers.Where(n => n < 0))
            {
                tempMinSum = minSum;
                for (int i = minSum; i <= maxSum; i++)
                {
                    if (possibleSums[i])
                    {
                        var currentNumber = i + number;
                        if (!hasZero && currentNumber == offset)
                        {
                            hasZero = true;
                        }

                        if (tempMinSum > currentNumber)
                        {
                            tempMinSum = currentNumber;
                        }

                        possibleSums[currentNumber] = true;
                    }
                }

                minSum = tempMinSum;
            }

            var sums = new List<int>();

            for (int i = 0; i < offset; i++)
            {
                if (possibleSums[i])
                {
                    sums.Add(i - offset);
                }
            }

            if (hasZero)
            {
                sums.Add(0);
            }

            for (int i = offset + 1; i < possibleSums.Length; i++)
            {
                if (possibleSums[i])
                {
                    sums.Add(i - offset);
                }
            }

            return sums;
        }

        // /// <summary>
        // /// Evaluates all possible subset sums. Slower Implementation.
        // /// </summary>
        // /// <param name="numbers"></param>
        // /// <returns></returns>
        // private static IEnumerable<int> FindPossibleSumsTest(int[] numbers)
        // {
        // int maxPossibleSum = numbers.Sum();
        // bool[] possibleSums = new bool[maxPossibleSum + 1];
        // int minSum = 0;
        // int maxSum = 0;
        // int tempMinSum = 0;
        // int tempMaxSum = 0;
        // foreach (var number in numbers)
        // {
        // bool justAddedd = false;
        // if (possibleSums[number] == false)
        // {
        // justAddedd = true;
        // if (minSum > number)
        // {
        // minSum = number;
        // }
        // else if (maxSum < number)
        // {
        // maxSum = number;
        // }
        // }
        // possibleSums[number] = true;
        // int justAddIndex = number;
        // tempMinSum = minSum;
        // tempMaxSum = maxSum;
        // for (int i = maxSum; i >= minSum; i--)
        // {
        // if (i == justAddIndex && justAddedd)
        // {
        // justAddedd = false;
        // continue;
        // }
        // if (possibleSums[i])
        // {
        // var currentNumber = i + number;
        // if (tempMinSum > currentNumber)
        // {
        // tempMinSum = currentNumber;
        // }
        // else if (tempMaxSum < currentNumber)
        // {
        // tempMaxSum = currentNumber;
        // }
        // possibleSums[currentNumber] = true;
        // }
        // }
        // minSum = tempMinSum;
        // maxSum = tempMaxSum;
        // }
        // var sums = new List<int>();
        // for (int i = 0; i < possibleSums.Length; i++)
        // {
        // if (possibleSums[i])
        // {
        // sums.Add(i);
        // }
        // }
        // return sums;
        // }
    }
}
