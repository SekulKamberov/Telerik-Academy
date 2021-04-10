namespace Labirint
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] matrix = new char[,]
            { 
                { 's', ' ', ' ', ' ', ' ', ' ' },
                { ' ', 'x', 'x', 'x', 'x', ' ' },
                { ' ', ' ', 'e', ' ', 'x', ' ' },
                { ' ', 'x', 'x', ' ', 'x', ' ' },
                { ' ', 'x', 'x', ' ', 'x', ' ' },
                { ' ', 'x', 'x', ' ', ' ', ' ' },
            };

            var lab = new Labirint(matrix);
            lab.FindPaths(0, 0, 'S');
        }
    }
}
