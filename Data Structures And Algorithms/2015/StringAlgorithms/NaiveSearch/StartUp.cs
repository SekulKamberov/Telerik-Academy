namespace NaiveSearch
{
    using System;

    /// <summary>
    /// Test for match at every possible position 
    /// Simple but inefficient 
    /// Quadratic in time (worstcase)
    /// </summary>
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string text = "dwadfrg fefe abc123456 e  da abc123456 e dawd abc123456 efrfgr";
            string pattern = "abc123456";
            NaiveSearch(text, pattern);
            NaiveSearchLongPattern(text, pattern);
        }

        private static void NaiveSearch(string text, string pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;
            int count = 0;

            for (int i = 0; i <= textLength - patternLength; i++)
            {
                count++;
                int matched = 0;

                while (matched < patternLength)
                {
                    if (text[i + matched] != pattern[matched])
                    {
                        break;
                    }

                    matched++;
                }

                if (matched == patternLength)
                {
                    Console.WriteLine("Match at {0}", i);
                }
            }

            Console.WriteLine("Loops count: {0}", count);
        }

        private static void NaiveSearchLongPattern(string text, string pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;
            int i = 0;
            int count = 0;

            while (i <= textLength - patternLength)
            {
                count++;
                int matched = 0;

                while (matched < patternLength)
                {
                    if (text[i + matched] != pattern[matched])
                    {
                        break;
                    }

                    matched++;
                }

                if (matched == patternLength)
                {
                    Console.WriteLine("Match at {0}", i);
                    i += patternLength;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine("Loops count: {0}", count);
        }
    }
}
