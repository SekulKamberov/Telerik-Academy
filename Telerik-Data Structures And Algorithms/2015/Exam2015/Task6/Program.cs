namespace Task6
{
    using System;

    public class StartUp
    {
        private static int combinationsCount = 0;

        public static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            combinationsCount += CountMatches(word, text);

            for (int i = 1; i < word.Length; i++)
            {
                var left = word.Substring(0, i);
                var right = word.Substring(i);
                var leftCombinations = CountMatches(left, text);
                var rightCombinations = CountMatches(right, text);
                combinationsCount += leftCombinations * rightCombinations;
            }

            Console.WriteLine(combinationsCount);
        }

        private static int CountMatches(string word, string text)
        {
            int textLength = text.Length;
            int patternLength = word.Length;

            if (patternLength > textLength)
            {
                return 0;
            }

            // precompute
            int[] fl = new int[patternLength + 1];
            fl[0] = -1;

            for (int i = 1; i < patternLength; i++)
            {
                int j = fl[i];
                while (j >= 0 && word[j] != word[i])
                {
                    j = fl[j];
                }

                fl[i + 1] = j + 1;
            }

            // search 
            int matched = 0;
            int counter = 0;
            for (int i = 0; i < textLength; i++)
            {
                while (matched >= 0 && text[i] != word[matched])
                {
                    matched = fl[matched];
                }

                matched++;

                if (matched == patternLength)
                {
                    counter++;
                    matched = fl[matched];
                }
            }

            return counter;
        }
    }
}
