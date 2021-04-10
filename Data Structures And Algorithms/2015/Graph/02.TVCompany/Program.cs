namespace _02.TVCompany
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
1 5 19
1 4 9
1 6 8
2 4 2
2 3 4
2 5 1
2 5 4
3 4 20
3 5 7
3 5 13
4 5 8
4 6 11
5 6 7";
            GraphWithSetOfEdgesWeighted graphWithSetOfEdgesWeighted = new GraphWithSetOfEdgesWeighted(n, m, inputWithWeight);
            graphWithSetOfEdgesWeighted.Print();
            Console.WriteLine();
            graphWithSetOfEdgesWeighted.FindMinimumSpanningTree();
        }
    }
}
