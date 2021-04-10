namespace TopologicalSorting
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 5;
            var m = 5;
            var inputWithWeight =
                   @"2 1 7
2 4 21
4 3 4
3 5 8
1 4 13
1 5 43";
            GraphWithAdjacencyMatrixWeighted graphWithAdjacencyMatrixWeighted = new GraphWithAdjacencyMatrixWeighted(n, m, inputWithWeight);
            graphWithAdjacencyMatrixWeighted.Print();
            Console.WriteLine();
            graphWithAdjacencyMatrixWeighted.SortTopologicaly();
            graphWithAdjacencyMatrixWeighted.PrintTopologicalSort();
        }
    }
}
