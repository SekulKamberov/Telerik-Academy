namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 5, -1, 54, -23, 233, 41, -3 };
            numbers = numbers.Where(n => n >= 0).ToList();
            Console.WriteLine("Positive numbers: {0}", string.Join(", ", numbers));
        }
    }
}
