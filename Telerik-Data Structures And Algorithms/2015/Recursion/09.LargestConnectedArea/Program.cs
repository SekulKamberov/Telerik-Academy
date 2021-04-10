namespace _09.LargestConnectedArea
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] matrix = new char[,]
            { 
                { '*', 'x', '*', 'x', '*', '*' },
                { 'x', 'x', '*', 'x', 'x', '*' },
                { '*', 'x', 'x', 'x', '*', 'x' },
                { '*', 'x', '*', 'x', '*', 'x' },
                { '*', 'x', '*', 'x', '*', '*' },
                { '*', 'x', '*', 'x', '*', '*' },
            };

            var lab = new Labirint(matrix);
            lab.FindLargestConnectedArea();
        }
    }
}
