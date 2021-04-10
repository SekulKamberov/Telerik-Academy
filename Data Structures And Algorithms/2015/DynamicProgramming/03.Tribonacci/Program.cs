namespace _03.Tribonacci
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            long[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            var n = input[3];
            var data = new long[(n + 1)];
            data[0] = input[0];
            data[1] = input[1];
            data[2] = input[2];

            for (int i = 3; i < n; i++)
            {
                data[i] = data[i - 1] + data[i - 2] + data[i - 3];
            }

            Console.WriteLine(data[n - 1]);
        }
    }
}
