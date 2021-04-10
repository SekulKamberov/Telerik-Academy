namespace _09.PrintMembersOfTheSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 2;
            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(n);
            int counter = 0;
            while (counter <= 50)
            {
                counter++;
                int currentNumber = numbers.Dequeue();
                Console.WriteLine(currentNumber);
                numbers.Enqueue(currentNumber + 1);
                numbers.Enqueue((2 * currentNumber) + 1);
                numbers.Enqueue(currentNumber + 2);
            }
        }
    }
}
