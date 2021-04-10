namespace _07.PathsBetweenPoints
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] matrix = new char[,]
            { 
                { '*', '*', '*', '*', '*', '*' },
                { '*', 'x', 'x', '*', 'x', '*' },
                { '*', '*', '*', '*', 'x', '*' },
                { '*', 'x', 'x', '*', 'x', '*' },
                { '*', 'x', 'x', '*', 'x', '*' },
                { '*', '*', '*', '*', '*', '*' },
            };

            while (true)
            {
                var lab = new Labirint(matrix);
                int startRow;
                Console.Write("Start row: ");
                startRow = int.Parse(Console.ReadLine());
                int startCol;
                Console.Write("Start col: ");
                startCol = int.Parse(Console.ReadLine());
                int endRow;
                Console.Write("End row: ");
                endRow = int.Parse(Console.ReadLine());
                int endCol;
                Console.Write("End col: ");
                endCol = int.Parse(Console.ReadLine());
                lab.FindPaths(startRow, startCol, endRow, endCol, 'S');
            }
        }
    }
}
