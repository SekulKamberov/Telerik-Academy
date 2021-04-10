namespace TopologicalSorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithAdjacencyMatrixWeighted
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private int m;
        private int[,] matrix;
        private bool[] visitedEdges;
        private List<int> sortedEdges;

        public GraphWithAdjacencyMatrixWeighted(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.matrix = new int[n, m];
            this.ParseMatrix(n, m, input);
        }

        public void SortTopologicaly()
        {
            this.visitedEdges = new bool[this.n];
            this.sortedEdges = new List<int>();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                if (this.visitedEdges[i] == false)
                {
                    this.FindNodeWithoutIncomingEdgesDFS(i);
                }
            }

            this.sortedEdges.Reverse();
        }

        public void PrintTopologicalSort()
        {
            if (this.sortedEdges != null)
            {
                foreach (int node in this.sortedEdges)
                {
                    Console.Write("{0} ", node + 1);
                }
            }
        }

        public void Print()
        {
            Console.Write("\t");
            for (int i = 0; i < this.n; i++)
            {
                Console.Write("{0}\t", i + 1);
            }

            Console.WriteLine();

            for (int v1 = 0; v1 < this.matrix.GetLength(0); v1++)
            {
                Console.Write("{0}|\t", v1 + 1);
                for (int v2 = 0; v2 < this.matrix.GetLength(1); v2++)
                {
                    Console.Write("{0}\t", this.matrix[v1, v2]);
                }

                Console.WriteLine();
            }
        }
        
        private void FindNodeWithoutIncomingEdgesDFS(int startIndex)
        {
            this.visitedEdges[startIndex] = true;

            for (int k = 0; k < this.matrix.GetLength(0); k++)
            {
                if ((this.matrix[startIndex, k] != 0) && (this.visitedEdges[k] == false))
                {
                    this.FindNodeWithoutIncomingEdgesDFS(k);
                }
            }

            this.sortedEdges.Add(startIndex);
        }

        private void ParseMatrix(int n, int m, string input)
        {
            var edgesString = input.Split(this.edgesSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var edgeString in edgesString)
            {
                var edge = edgeString.Split(this.edgeSeparators, StringSplitOptions.RemoveEmptyEntries);
                var v1 = int.Parse(edge[0]) - 1;
                var v2 = int.Parse(edge[1]) - 1;
                var weight = int.Parse(edge[2]);
                this.matrix[v1, v2] = weight;
            }
        }
    }
}
