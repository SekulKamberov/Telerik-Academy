namespace Extension_Methods_Delegates_Lambda_LINQ
{
    using System;
    using System.Linq;

    public class PrintFromArray
    {
        // 06. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
        // Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
        public static void PrintNumberDivisibleByUseLambda(int[] numbers, int firstDivider, int secondDivider)
        {
            int[] divisibleNumbers = Array.FindAll(numbers, num => num % firstDivider == 0 && num % secondDivider == 0);

            foreach (var number in divisibleNumbers)
            {
                Console.WriteLine(number);
            }
        }

        public static void PrintNumberDivisibleByUseLinq(int[] numbers, int firstDivider, int secondDivider)
        {
            var divisibleNumbers =
                from number in numbers
                where number % firstDivider == 0 && number % secondDivider == 0
                select number;
            
            foreach (int number in divisibleNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
