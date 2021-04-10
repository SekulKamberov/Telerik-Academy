namespace Friends
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            GraphWithAdjacencyMatrixWeighted graphWithAdjacencyMatrixWeighted = new GraphWithAdjacencyMatrixWeighted();
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath());
        }
    }
}
