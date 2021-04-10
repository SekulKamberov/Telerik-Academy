namespace PrimsAlgorithm
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = 6;
            var m = 6;
            var inputWithWeight =
                @"1 3 5
1 2 4
1 4 9
2 4 2
3 4 20
3 5 7
4 5 8
5 6 12";
            GraphWithSetOfEdgesWeighted graphWithSetOfEdgesWeighted = new GraphWithSetOfEdgesWeighted(n, m, inputWithWeight);
            graphWithSetOfEdgesWeighted.Print();
            Console.WriteLine();
            graphWithSetOfEdgesWeighted.FindMinimumSpanningTree();
        }
    }
}
