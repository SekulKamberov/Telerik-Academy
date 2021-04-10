namespace BinaryTrees
{
    using System;
    using System.Numerics;

    public class Program
    {
        private static long[] nodesVariations;
        private static int[] lettersCount = new int[26];

        public static void Main()
        {
            var input = Console.ReadLine();
            CountLetters(input);
            int n = input.Length;
            nodesVariations = new long[n + 1];
            var factoriels = EvaluateFactoriels(n);
            long factoriel = factoriels[n];
            foreach (var letterCount in lettersCount)
            {
                factoriel /= factoriels[letterCount];
            }

            BigInteger result = factoriel;
            result *= CountTreeVariations(n);
            Console.WriteLine(result);
        }

        private static long CountTreeVariations(int nodes)
        {
            if (nodes == 0)
            {
                return 1;
            }

            if (nodesVariations[nodes] > 0)
            {
                return nodesVariations[nodes];
            }

            long result = 0;
            for (int i = 0; i < nodes; i++)
            {
                result += CountTreeVariations(i) * CountTreeVariations(nodes - 1 - i);
            }

            nodesVariations[nodes] = result;
            return result;
        }

        private static void CountLetters(string input)
        {
            foreach (var ball in input)
            {
                lettersCount[ball - 'A']++;
            }
        }

        private static long[] EvaluateFactoriels(int n)
        {
            var factoriels = new long[n + 1];
            factoriels[0] = 1;
            for (int i = 0; i < n; i++)
            {
                factoriels[i + 1] = factoriels[i] * (i + 1);
            }

            return factoriels;
        }
    }
}
