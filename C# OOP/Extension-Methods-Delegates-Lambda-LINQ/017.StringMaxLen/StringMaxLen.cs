namespace _017.StringMaxLen
{
    using System;
    using System.Linq;

    public class StringMaximumLength
    {
        // 17. Write a program to return the string with maximum length from an array of strings. Use LINQ.
        public static void Main()
        {
            Console.Write("Enter string sequence length: ");
            int length = int.Parse(Console.ReadLine());

            string[] stringSequence = new string[length];
            for (int i = 0; i < length; i++)
            {
                stringSequence[i] = Console.ReadLine();
            }

            // sort strings by length in descending order and then get the first one.
            // var stringWithMaximalLength = stringSequence.OrderByDescending(x => x.Length).First();
            // Console.WriteLine("Max length: " + stringWithMaximalLength);
            var maxLen = stringSequence.Max(x => x.Length);
            Console.WriteLine("Max length: " + maxLen);

            var stringWithMaximalLength = stringSequence
                .Aggregate((max, current) => max.Length > current.Length ? max : current);

            Console.WriteLine("Max: " + stringWithMaximalLength);
        }    
    }
}
