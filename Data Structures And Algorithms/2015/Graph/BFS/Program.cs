namespace BFS
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 5;
            var m = 5;
            var inputNoWeight =
                @"1 2
1 4
2 3
3 1
5 3
4 5
4 2";

            GraphWithAdjacencyMatrix graphWithAdjacencyMatrix = new GraphWithAdjacencyMatrix(n, m, inputNoWeight);
            graphWithAdjacencyMatrix.Print();
            Console.WriteLine();
            graphWithAdjacencyMatrix.Bfs(0);
            graphWithAdjacencyMatrix.Bfs(1);
            graphWithAdjacencyMatrix.Bfs(2);
            graphWithAdjacencyMatrix.Bfs(3);
            graphWithAdjacencyMatrix.Bfs(4);
        }
    }
}
