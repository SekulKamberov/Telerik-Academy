namespace KnuthMorrisPratt
{
    using System;

    /// <summary>
    /// Makes use of previous match info 
    /// "Partial match" table is precomputed 
    /// Linear in time 
    /// Unneeded checks are skipped 
    /// Linear in time
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            string text = "dwadfrg fefe abc123456 e  da abc123456 e dawd abc123456 efrfgr";
            string pattern = "abc123456";

            int textLength = text.Length;
            int patternLength = pattern.Length;

            if (patternLength > textLength)
            {
                return;
            }

            // precompute
            int[] fl = new int[patternLength + 1];
            fl[0] = -1;

            for (int i = 1; i < patternLength; i++)
            {
                int j = fl[i];
                while (j >= 0 && pattern[j] != pattern[i])
                {
                    j = fl[j];
                }

                fl[i + 1] = j + 1;
            }

            // search 
            int matched = 0;
            for (int i = 0; i < textLength; i++)
            {
                while (matched >= 0 && text[i] != pattern[matched])
                {
                    matched = fl[matched];
                }

                matched++;

                if (matched == patternLength)
                {
                    Console.WriteLine("Matched at {0}", i - patternLength + 1);
                    matched = fl[matched];
                }
            }
        }
    }
}
