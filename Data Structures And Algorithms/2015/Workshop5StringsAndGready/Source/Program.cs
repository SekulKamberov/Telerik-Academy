namespace Source
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static string text;
        private static string pattern;
        private static List<int> offsets = new List<int>();
        private static int pmatches = 0;
        private static int patternLastIndex;

        public static void Main(string[] args)
        {
            ReadInput();
            CountPMatches();
            Console.WriteLine(pmatches);

            // Console.WriteLine(offsetsSum);
            Console.WriteLine(string.Join(" ", offsets));
        }

        private static void CountPMatches()
        {
            if (PatternHasOnlyTokens())
            {
                var index = FindIndexOfPatternFirstCharachterInText(0);

                while (index != -1 && index + pattern.Length < text.Length)
                {
                    if (IsPatternMatchingWhenOnlyTokens(index))
                    {
                        pmatches++;
                        offsets.Add(index + 1);
                    }

                    index = FindIndexOfPatternFirstCharachterInText(index + 1);
                }

                return;
            }

            int patternFirstTokenIndex = FindPatternFirstTokenIndex();
            if (patternFirstTokenIndex != -1)
            {
                int textTokenIndex;
                int startIndex = 0;
                do
                {
                    textTokenIndex = FindTextTokenIndex(pattern[patternFirstTokenIndex], startIndex);
                    if (textTokenIndex != -1)
                    {
                        if (IsPMatch(textTokenIndex, patternFirstTokenIndex))
                        {
                            pmatches += 1;
                            var offset = CalculateOffset(textTokenIndex, patternFirstTokenIndex);
                            offsets.Add(offset + 1);
                        }
                    }

                    startIndex = textTokenIndex;
                }
                while (textTokenIndex != -1);
            }
            else
            {
                for (int i = 0; i < text.Length - pattern.Length + 1; i++)
                {
                    if (IsPMatchWhenNoTokens(i))
                    {
                        pmatches += 1;
                        offsets.Add(i + 1);
                    }
                }
            }
        }

        private static bool IsPatternMatchingWhenOnlyTokens(int index)
        {
            int patternIndex = 0;
            for (int i = index; i < index + pattern.Length; i++)
            {
                if (text[i] != pattern[patternIndex])
                {
                    return false;
                }

                patternIndex++;
            }

            return true;

            // var substringOfText = text.Substring(index, pattern.Length);
            // if (substringOfText == pattern)
            // {
            // return true;
            // }
            // else
            // {
            // return false;
            // }
        }

        private static bool IsPMatchWhenNoTokens(int textIndex)
        {
            // TODO should create dictionary on every invoke or have static saved when pmatch is met
            var patternIndex = 0;
            var corespondingMatches = new Dictionary<char, char>();
            var usedValues = new HashSet<char>();
            while (patternIndex < pattern.Length)
            {
                var textChar = text[textIndex];
                var patternChar = pattern[patternIndex];
                if (corespondingMatches.ContainsKey(textChar))
                {
                    if (corespondingMatches[textChar] != patternChar)
                    {
                        return false;
                    }
                }
                else if (!usedValues.Contains(patternChar))
                {
                    corespondingMatches.Add(textChar, patternChar);
                    usedValues.Add(patternChar);
                }
                else
                {
                    return false;
                }

                patternIndex++;
                textIndex++;
            }

            return true;
        }

        private static int CalculateOffset(int textTokenIndex, int patternFirstTokenIndex)
        {
            var offset = textTokenIndex - patternFirstTokenIndex;
            return offset;
        }

        private static bool IsPMatch(int textTokenIndex, int patternTokenIndex)
        {
            if (textTokenIndex < patternTokenIndex)
            {
                return false;
            }

            if (textTokenIndex + pattern.Length - patternTokenIndex > text.Length)
            {
                return false;
            }

            var corespondingMatches = new Dictionary<char, char>();
            var usedValues = new HashSet<char>();
            var startIndex = textTokenIndex - patternTokenIndex;
            var patternIndex = -1;
            for (int i = startIndex; i < startIndex + pattern.Length; i++)
            {
                patternIndex++;
                var textChar = text[i];
                var patternChar = pattern[patternIndex];
                bool isTextCharUpper = char.IsUpper(textChar);
                bool isPatternCharUpper = char.IsUpper(patternChar);
                if (isTextCharUpper && isPatternCharUpper)
                {
                    if (textChar == patternChar)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (isTextCharUpper || isPatternCharUpper)
                {
                    return false;
                }
                else if (corespondingMatches.ContainsKey(textChar))
                {
                    if (corespondingMatches[textChar] != patternChar)
                    {
                        return false;
                    }
                }
                else if (!usedValues.Contains(patternChar))
                {
                    corespondingMatches.Add(textChar, patternChar);
                    usedValues.Add(patternChar);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static int FindTextTokenIndex(char token, int startIndex)
        {
            for (int i = startIndex; i < text.Length; i++)
            {
                if (text[i] == token)
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool HasTokens()
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (char.IsUpper(pattern[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private static int FindPatternFirstTokenIndex()
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (char.IsUpper(pattern[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool PatternHasOnlyTokens()
        {
            foreach (var character in pattern)
            {
                if (char.IsUpper(character) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static int FindIndexOfPatternFirstCharachterInText(int textStartIndex)
        {
            for (int i = textStartIndex; i < text.Length - pattern.Length; i++)
            {
                if (text[i] == pattern[0])
                {
                    var lastIndex = i + patternLastIndex;
                    if (text[lastIndex] == pattern[patternLastIndex])
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private static void ReadInput()
        {
            pattern = Console.ReadLine();
            patternLastIndex = pattern.Length - 1;
            text = Console.ReadLine();
        }
    }
}
