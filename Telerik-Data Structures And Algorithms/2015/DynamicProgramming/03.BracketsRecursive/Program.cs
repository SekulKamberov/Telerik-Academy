namespace _03.BracketsRecursive
{
    using System;

    public class Program
    {
        private static bool[] brackets;
        private static bool[] constantBrackets;
        private static string input;
        private static int length;
        private static int count;

        public static void Main(string[] args)
        {
            ReadInput();
            Calculate(0, true);
            Console.WriteLine(count);
        }

        private static void Calculate(int index, bool isOpeningBracket)
        {
            if (index >= length - 1)
            {
                IsValid();
                return;
            }

            if (constantBrackets[index] == false)
            {
                brackets[index] = isOpeningBracket;
            }

            while (index < length - 1 && constantBrackets[index + 1] == true)
            {
                index++;
            }

            if (index >= length - 1)
            {
                IsValid();
                return;
            }

            Calculate(index + 1, true);
            Calculate(index + 1, false);
        }

        private static void IsValid()
        {
            var openingBracketsCount = 0;
            var closingBraketsCount = 0;
            for (int i = 0; i < length; i++)
            {
                if (brackets[i] == true)
                {
                    openingBracketsCount++;
                }
                else
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

        private static void ReadInput()
        {
            input = Console.ReadLine();
            length = input.Length;

            brackets = new bool[length];
            brackets[0] = true;

            constantBrackets = new bool[length];
            constantBrackets[0] = true;
            constantBrackets[length - 1] = true;

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] == '(')
                {
                    brackets[i] = true;
                    constantBrackets[i] = true;
                }
                else if (input[i] == ')')
                {
                    constantBrackets[i] = true;
                }
            }
        }
    }
}
