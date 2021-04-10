namespace Palindromize
{
    using System;
    using System.Linq;

    public class Program
    {
        private static char[] inputAsChars;

        public static void Main(string[] args)
        {
            // FindPalindromeWithSubstrings();
            FindPalindromeWithCharArray();
        }

        private static void FindPalindromeWithCharArray()
        {
            inputAsChars = Console.ReadLine().ToCharArray();
            if (AreOrderedAsPalindroms())
            {
                Console.WriteLine(inputAsChars);
                return;
            }
            else
            {
                for (int i = 1; i < inputAsChars.Length - 1; i++)
                {
                    if (IsPalindrom(i))
                    {
                        PrintPalindrom(i);
                        return;
                    }
                }

                PrintPalindrom(inputAsChars.Length - 1);
            }
        }

        private static void PrintPalindrom(int length)
        {
            for (int i = 0; i < inputAsChars.Length; i++)
            {
                Console.Write(inputAsChars[i]);
            }

            for (int i = length - 1; i >= 0; i--)
            {
                Console.Write(inputAsChars[i]);
            }
        }

        private static bool IsPalindrom(int length)
        {
            for (int i = length; i < (inputAsChars.Length + length) / 2; i++)
            {
                if (length - i <= 0 && inputAsChars[i] != inputAsChars[inputAsChars.Length - i + length - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AreOrderedAsPalindroms()
        {
            for (int i = 0; i < inputAsChars.Length / 2; i++)
            {
                if (inputAsChars[i] != inputAsChars[inputAsChars.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPalindrom(string palindromeCandidate)
        {
            for (int i = 0; i < palindromeCandidate.Length / 2; i++)
            {
                if (palindromeCandidate[i] != palindromeCandidate[palindromeCandidate.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void FindPalindromeWithSubstrings()
        {
            string input = Console.ReadLine();
            string reversed = string.Join(string.Empty, input.Reverse());

            if (IsPalindrom(input))
            {
                Console.WriteLine(input);
                return;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                var palindromeCandidate = input + reversed.Substring(input.Length - 1 - i, 1 + i);
                if (IsPalindrom(palindromeCandidate))
                {
                    Console.WriteLine(palindromeCandidate);
                    return;
                }
            }
        }
    }
}
