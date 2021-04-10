namespace Rabits
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> replies = new Dictionary<int, int>();
            for (int i = 0; i < count; i++)
            {
                var reply = int.Parse(Console.ReadLine());
                if (!replies.ContainsKey(reply))
                {
                    replies[reply] = 0;
                }

                replies[reply] += 1;
            }

            int answer = CountMinimumRabits(replies);
            Console.WriteLine(answer);
        }

        private static int CountMinimumRabits(Dictionary<int, int> replies)
        {
            int minCount = 0;
            foreach (var reply in replies)
            {
                var key = reply.Key;
                var value = reply.Value;
                if (key == 0)
                {
                    minCount += value;
                }
                else if (key == 1)
                {
                    minCount += value;
                    if (value % 2 != 0)
                    {
                        minCount += 1;
                    }
                }
                else
                {
                    minCount += (int)Math.Ceiling((double)value / (key + 1)) * (key + 1);
                }
            }
            
            return minCount;
        }
    }
}
