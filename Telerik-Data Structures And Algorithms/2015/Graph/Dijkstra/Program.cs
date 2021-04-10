namespace Dijkstra
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 5;
            var m = 5;
            var inputWithWeight =
                @"1 2 7
1 4 21
2 3 4
3 1 31
4 5 12
3 5 14
4 2 43";
            GraphWithAdjacencyMatrixWeighted graphWithAdjacencyMatrixWeighted = new GraphWithAdjacencyMatrixWeighted(n, m, inputWithWeight);
            graphWithAdjacencyMatrixWeighted.Print();
            Console.WriteLine();
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(0, 1));
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(0, 2));
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(0, 3));
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(0, 4)); 
            Console.WriteLine();

            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(1, 2));
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(1, 3));
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(1, 4));
            Console.WriteLine();

            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(2, 3));
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(2, 4));
            Console.WriteLine();

            Console.WriteLine(graphWithAdjacencyMatrixWeighted.CalculateShortestPath(3, 4));
            Console.WriteLine();
        }
    }
}
