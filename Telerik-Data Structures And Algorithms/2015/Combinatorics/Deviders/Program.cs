namespace Deviders
{
    using System;
    using System.Text;

    public class Program
    {
        private static int n;
        private static int[] numbers;
        private static int k;
        private static int[] arr;
        private static bool[] used;
        private static int minDividers = int.MaxValue;
        private static int minNumber = int.MaxValue;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = n;
            arr = new int[k];
            numbers = new int[n];
            used = new bool[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            GenerateVariationsNoRepetitions(0);
            Console.WriteLine(minNumber);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k)
            {
                CheckDevidersCount();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void CheckDevidersCount()
        {
            int number = ParseToNumber();
            int countDividers = CountDividers(number);
            if (minDividers > countDividers)
            {
                minDividers = countDividers;
                minNumber = number;
            }
            else if (minDividers == countDividers && minNumber > number)
            {
                minNumber = number;
            }
        }

        private static int CountDividers(int number)
        {
            var counter = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int ParseToNumber()
        {
            var stringBuilder = new StringBuilder(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                stringBuilder.Append(numbers[arr[i]]);
            }

            return int.Parse(stringBuilder.ToString());
        }
    }
}
