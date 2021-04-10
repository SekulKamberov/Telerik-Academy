namespace Dijkstra
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

        public GraphWithAdjacencyMatrixWeighted(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.matrix = new int[n, m];
            this.ParseMatrix(n, m, input);
        }

        // Dijkstra
        public int CalculateShortestPath(int startNode, int endNode)
        {
            int[] distance = new int[this.matrix.GetLength(0)];
            HashSet<int> nodes = new HashSet<int>();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                distance[i] = int.MaxValue;
                nodes.Add(i);
            }

            distance[startNode] = 0;

            while (nodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in nodes)
                {
                    if (minNode > distance[node])
                    {
                        minNode = node;
                    }
                }

                nodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    break;
                }

                for (int i = 0; i < this.matrix.GetLength(0); i++)
                {
                    if (this.matrix[minNode, i] > 0)
                    {
                        int potentialDistance = distance[minNode] + this.matrix[minNode, i];
                        if (potentialDistance < distance[i])
                        {
                            distance[i] = potentialDistance;
                        }
                    }
                }
            }

            return distance[endNode];
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
                this.matrix[v2, v1] = weight;
            }
        }
    }
}