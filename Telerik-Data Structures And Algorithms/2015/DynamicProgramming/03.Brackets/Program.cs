namespace _03.Brackets
{
    using System;
    using System.Text;

    public class Program
    {
        private const int N = 2;
        private static int k;
        private static bool[] brakets;
        private static int[] arr;
        private static bool[] constantBrackets;
        private static int[] constrantBracketsIndexes;
        private static string input;
        private static int length;
        private static int count;

        public static void Main(string[] args)
        {
            ReadInputValues();
            GenerateVariationsWithRepetitions(0);
            Console.WriteLine(count);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                CheckBracketsVariations();
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void CheckBracketsVariations()
        {
            var bracketIndex = 0;

            for (int i = 1; i < length - 1; i++)
            {
                if (constantBrackets[i] == false)
                {
                    brakets[i] = arr[bracketIndex] == 0 ? true : false;
                    bracketIndex++;
                }
            }

            CheckBracketsCorrectness();
        }

        private static void CheckBracketsCorrectness()
        {
            var openingBracketsCount = 0;
            var closingBraketsCount = 0;
            for (int i = 0; i < length; i++)
            {
                if (brakets[i] == true)
                {
                    openingBracketsCount++;
                }
                else if (brakets[i] == false)
                {
                    closingBraketsCount++;
                }

                if (closingBraketsCount > openingBracketsCount)
                {
                    return;
                }
            }

            if (openingBracketsCount == closingBraketsCount)
            {
                count++;
            }
        }
        
        private static void ReadInputValues()
        {
            input = Console.ReadLine();
            length = input.Length;

            brakets = new bool[length];
            brakets[0] = true;
            brakets[length - 1] = false;

            constantBrackets = new bool[length];
            constantBrackets[0] = true;
            constantBrackets[length - 1] = true;

            k = 0;
            for (int i = 1; i < brakets.Length - 1; i++)
            {
                if (input[i] == '?')
                {
                    k += 1;
                }
                else
                {
                    if (input[i] == '(')
                    {
                        brakets[i] = true;
                    }

                    constantBrackets[i] = true;
                }
            }

            arr = new int[k];
        }
    }
}
