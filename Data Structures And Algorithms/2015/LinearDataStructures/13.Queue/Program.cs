namespace _13.Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
            Console.WriteLine(numbers);
            numbers.Enqueue(1);
            Console.WriteLine(numbers);

            // numbers.Dequeue();
            // Console.WriteLine(numbers);
            // numbers.Dequeue();
            // Console.WriteLine(numbers);
            numbers.Enqueue(2);
            Console.WriteLine(numbers);
            numbers.Dequeue();
            Console.WriteLine(numbers);
            numbers.Enqueue(1);
            Console.WriteLine(numbers);
            numbers.Enqueue(3);
            Console.WriteLine(numbers);
            numbers.Enqueue(4);
            Console.WriteLine(numbers);
            numbers.Enqueue(5);
            Console.WriteLine(numbers);
            numbers.Enqueue(6);
            Console.WriteLine(numbers);

            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers);

            numbers.TrimExcess();
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers);
            
            // numbers.Enqueue(6);
            // Console.WriteLine(numbers);
        }
    }
}
