namespace RepeatingPattern
{
    using System;
    using System.Collections.Generic;

    public class Program 
    {
        // private static char[] text;
        private static string text;
        private static int minLength;

        public static void Main(string[] args)
        {
            // text = Console.ReadLine().ToCharArray(); 
            text = Console.ReadLine();
            minLength = text.Length;
            List<int> factors = GetFactors(text.Length);
            FindSmallestFactor(factors);

            // Console.WriteLine(new string(text, 0, minLength));
            Console.WriteLine(text.Substring(0, minLength));
        }

        private static void FindSmallestFactor(List<int> factors)
        {
            for (int i = factors.Count - 2; i >= 0; i--)
            {
                var f = factors[i];
                if (factors[i] < minLength)
                {
                    CheckString(factors[i]);
                }
            }
        }

        private static void CheckString(int substringLength)
        {
            for (int i = substringLength; i < text.Length; i += substringLength)
            {
                if (CompareChars(substringLength, i) == false)
                {
                    return;
                } 
            }

            minLength = substringLength;

            var factors = GetFactors(minLength);
            FindSmallestFactor(factors);
        }

        private static bool CompareChars(int length, int currentStringStartIndex)
        {
            for (int i = 0; i < length; i++)
            {
                var a = text[i];
                var b = text[currentStringStartIndex + i];
                if (text[i] != text[currentStringStartIndex + i])
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> GetFactors(int number)
        {
            var factors = new List<int>();
            int max = (int)Math.Sqrt(number);
            for (int factor = 1; factor <= max; ++factor)
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor)
                    {
                        factors.Add(number / factor);
                    }
                }
            }

            factors.Sort();
            return factors;
        }
    }
}
