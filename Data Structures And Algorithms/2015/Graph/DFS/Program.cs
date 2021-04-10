namespace DFS
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
            graphWithAdjacencyMatrix.Dfs(0);
            graphWithAdjacencyMatrix.Dfs(1);
            graphWithAdjacencyMatrix.Dfs(2);
            graphWithAdjacencyMatrix.Dfs(3);
            graphWithAdjacencyMatrix.Dfs(4);
        }
    }
}
