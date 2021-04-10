namespace BFS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithAdjacencyMatrix
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private int m;
        private bool[,] matrix;

        public GraphWithAdjacencyMatrix(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.matrix = new bool[n, m];
            this.ParseMatrix(n, m, input);
        }

        public void Bfs(int node)
        {
            bool[] visited = new bool[this.n];
            var nodes = new Queue<int>();
            nodes.Enqueue(node);
            visited[node] = true;
            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();
                Console.WriteLine(currentNode + 1);

                for (int i = 0; i < this.matrix.GetLength(0); i++)
                {
                    if (this.matrix[currentNode, i] == true && !visited[i])
                    {
                        nodes.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }

            Console.WriteLine();
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
                    Console.Write("{0}\t", this.matrix[v1, v2] == true ? 1 : 0);
                }

                Console.WriteLine();
            }
        }

        private void ParseMatrix(int n, int m, string input)
        {
            var edgesString = input.Split(this.edgesSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var edgeString in edgesString)
            {
                var edge = edgeString.Split(this.edgeSeparators, StringSplitOptions.RemoveEmptyEntries);
                var v1 = int.Parse(edge[0]) - 1;
                var v2 = int.Parse(edge[1]) - 1;
                this.matrix[v1, v2] = true;

                // not oriented graph
                // matrix[v2, v1] = true;
            }
        }
    }
}
