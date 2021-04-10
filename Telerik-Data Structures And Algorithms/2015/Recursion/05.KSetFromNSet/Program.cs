namespace _05.KSetFromNSet
{
    using System;

    public class Program
    {
        private static string[] values;
        private static string[] bytes;
        private static int n;
        private static int k;

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("N = ");
                n = int.Parse(Console.ReadLine());
                Console.Write("K = ");
                k = int.Parse(Console.ReadLine());
                Console.WriteLine();
                values = new string[n];
                bytes = new string[k];
                for (int i = 0; i < n; i++)
                {
                    Console.Write("n[{0}] = ", i);
                    values[i] = Console.ReadLine();
                }

                GenerateVariations(0);
            }
        }

        private static void GenerateVariations(int index)
        {
            if (index >= k)
            {
                Console.WriteLine("[{0}]", string.Join(", ", bytes));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    bytes[index] = values[i];
                    GenerateVariations(index + 1);
                }
            }
        }
    }
}
