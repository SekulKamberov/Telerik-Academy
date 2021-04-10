namespace _01.FriendsOfPeshoDijkstra
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var nmh = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i))
                .ToArray();
            var n = nmh[0];
            var m = nmh[1];
            var h = nmh[2];

            GraphWithAdjacencyMatrixWeighted graphWithAdjacencyMatrixWeighted = new GraphWithAdjacencyMatrixWeighted(n, m, h);

            // graphWithAdjacencyMatrixWeighted.Print();
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.MinimumDistance());
        }
    }
}
