namespace GraphInitializations
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 4;
            var m = 4;
            var inputNoWeight =
                @"1 2
1 4
2 3
3 1
4 2";
            var inputWithWeight =
                @"1 2 7
1 4 21
2 3 4
3 1 31
4 2 43";

            GraphWithAdjacencyMatrix graphWithAdjacencyMatrix = new GraphWithAdjacencyMatrix(n, m, inputNoWeight);
            graphWithAdjacencyMatrix.Print();
            Console.WriteLine();

            GraphWithAdjacencyMatrixWeighted graphWithAdjacencyMatrixWeighted = new GraphWithAdjacencyMatrixWeighted(n, m, inputWithWeight);
            graphWithAdjacencyMatrixWeighted.Print();
            Console.WriteLine();

            GraphWithAdjacencyList graphWithAdjacencyList = new GraphWithAdjacencyList(n, m, inputNoWeight);
            graphWithAdjacencyList.Print();
            Console.WriteLine();

            GraphWithAdjacencyListWeighted graphWithAdjacencyListWeighted = new GraphWithAdjacencyListWeighted(n, m, inputWithWeight);
            graphWithAdjacencyListWeighted.Print();
            Console.WriteLine();

            GraphWithSetOfEdges graphWithSetOfEdges = new GraphWithSetOfEdges(n, m, inputNoWeight);
            graphWithSetOfEdges.Print();
            Console.WriteLine();

            GraphWithSetOfEdgesWeighted graphWithSetOfEdgesWeighted = new GraphWithSetOfEdgesWeighted(n, m, inputWithWeight);
            graphWithSetOfEdgesWeighted.Print();
            Console.WriteLine();
        }
    }
}
