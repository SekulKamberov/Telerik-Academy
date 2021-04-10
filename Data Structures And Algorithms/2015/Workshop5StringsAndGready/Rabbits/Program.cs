namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var answers = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i));
            var dict = new Dictionary<int, int>();
            foreach (var answer in answers)
            {
                if (!dict.ContainsKey(answer))
                {
                    dict[answer] = 0;
                }

                dict[answer] += 1;
            }

            dict.Remove(-1);

            var rabits = 0;
            if (dict.ContainsKey(0))
            {
                rabits += dict[0];
                dict.Remove(0);
            }

            if (dict.ContainsKey(1))
            {
                var size = 2;
                var numberOfReplies = dict[1];
                rabits += ((numberOfReplies / size) * size) + ((numberOfReplies % size) * size);
                dict.Remove(1);
            }

            foreach (var keyValuePair in dict)
            {
                var reply = keyValuePair.Key; // 2
                var size = reply + 1; // 3
                var numberOfReplies = keyValuePair.Value; // 2
                rabits += ((numberOfReplies / size) * size) + ((numberOfReplies % size) != 0 ? size : 0);                
            }

            Console.WriteLine(rabits);
        }
    }
}
