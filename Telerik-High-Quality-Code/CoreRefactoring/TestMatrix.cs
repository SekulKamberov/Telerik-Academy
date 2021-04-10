namespace GameFifteen
{
    using System;
    using Homework;

    public class TestMatrix
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a positive number ");
                string input = Console.ReadLine();
                int size = 0;

                while (!int.TryParse(input, out size) || size < 0 || 100 < size)
                {
                    Console.WriteLine("You haven't entered a correct positive number");
                    input = Console.ReadLine();
                }

                new RotationMatrix(size).Print();
            }
        }
    }
}
