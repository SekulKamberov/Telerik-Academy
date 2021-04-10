namespace _01.Salaries
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            GraphWithAdjacencyMatrixWeighted graphWithAdjacencyMatrixWeighted = new GraphWithAdjacencyMatrixWeighted(n);
            graphWithAdjacencyMatrixWeighted.Print();
            Console.WriteLine(graphWithAdjacencyMatrixWeighted.SumOfSalaries());

            // graphWithAdjacencyMatrixWeighted.PrintTopologicalSort();
        }
    }
}
