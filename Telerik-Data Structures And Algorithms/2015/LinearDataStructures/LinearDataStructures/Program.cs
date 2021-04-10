namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> possitiveNumbers = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();
                int number;
                bool isNumber = false;
                if (input == string.Empty)
                {
                    break;
                }
                else
                {
                    isNumber = int.TryParse(input, out number);
                    if (isNumber && number >= 0)
                    {
                        possitiveNumbers.Add(number);
                    }
                }                
            }

            Console.WriteLine("Sum: {0}", possitiveNumbers.Sum());
            Console.WriteLine("Avg: {0}", possitiveNumbers.Count != 0 ? possitiveNumbers.Average().ToString() : "No numbers added!");
        }
    }
}
