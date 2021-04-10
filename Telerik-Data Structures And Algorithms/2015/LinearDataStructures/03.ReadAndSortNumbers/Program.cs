namespace _03.ReadAndSortNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

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
                    if (isNumber)
                    {
                        numbers.Add(number);
                    }
                }
            }

            numbers.Sort();
            Console.WriteLine("Sorted numbers: {0}", string.Join(", ", numbers));
        }
    }
}
