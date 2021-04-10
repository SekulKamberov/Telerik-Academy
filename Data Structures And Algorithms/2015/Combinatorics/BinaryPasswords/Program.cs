namespace BinaryPasswords
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class Program
    {
        private const int N = 2;
        private const string OneCombinationStringForamat = "Единствената възможна парола е {0}";
        private const string ManyPasswordsStringFormat = "Възможните пароли са: {0}.";
        private static char searchedChar = '*';
        private static string input;
        private static string[] variants = new string[N] { "0", "1" };
        private static int k;
        private static int[] arr;
        private static List<string> passwordVariations = new List<string>();

        public static void Main(string[] args)
        {
            input = Console.ReadLine();
            var starsCount = CountChar(input, searchedChar);
            Console.WriteLine(PowerOf(2, starsCount));

            k = starsCount; 
            arr = new int[k];

            GenerateVariationsWithRepetitions(0);
            PrintVariatins();
        }

        private static void PrintVariatins()
        {
            if (k == 0)
            {
                Console.WriteLine(string.Format(OneCombinationStringForamat, input));
            }
            else
            {
                Console.WriteLine(string.Format(ManyPasswordsStringFormat, string.Join(", ", passwordVariations)));
            }
        }

        private static BigInteger PowerOf(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else
            {
                return number * PowerOf(number, power - 1);
            }
        }

        private static int CountChar(string input, char character)
        {
            var count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == character)
                {
                    count++;
                }
            }

            return count;
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                AddVariation(arr);
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

        private static void AddVariation(int[] arr)
        {
            var counter = 0;
            var stringBuilder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    stringBuilder.Append(arr[counter]);
                    counter++;
                }
                else
                {
                    stringBuilder.Append(input[i]);
                }
            }

            passwordVariations.Add(stringBuilder.ToString());
        }
    }
}
