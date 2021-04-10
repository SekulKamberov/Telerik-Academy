namespace _01.FriendsOfPeshoDijkstra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithAdjacencyMatrixWeighted
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int buildingsCount;
        private int streetsCount;
        private int hospitalsCount;
        private int[,] matrix;
        private HashSet<int> hospitalsIndexes;

        public GraphWithAdjacencyMatrixWeighted(int buildingsCount, int streetsCount, int hospitalsCount)
        {
            this.hospitalsIndexes = new HashSet<int>();
            this.buildingsCount = buildingsCount;
            this.streetsCount = streetsCount;
            this.hospitalsCount = hospitalsCount;
            this.matrix = new int[buildingsCount, buildingsCount];
            this.ParseData();
        }

        public void Print()
        {
            Console.Write("\t");
            for (int i = 0; i < this.buildingsCount; i++)
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

        public long MinimumDistance()
        {
            long min = long.MaxValue;
            foreach (var hospitalIndex in this.hospitalsIndexes)
            {
                long tempDistance = 0;
                for (int homeIndex = 0; homeIndex < this.buildingsCount; homeIndex++)
                {
                    if (hospitalIndex != homeIndex && !this.hospitalsIndexes.Contains(homeIndex))
                    {
                        tempDistance += this.CalculateShortestPath(hospitalIndex, homeIndex);
                    }
                }

                if (tempDistance < min)
                {
                    min = tempDistance;
                }
            }

            return min;
        }

        // Dijkstra
        private int CalculateShortestPath(int startNode, int endNode)
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

        private void ParseData()
        {
            var hospitalsArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i));
            foreach (var hospital in hospitalsArray)
            {
                var hospitalIndex = hospital - 1;
                this.hospitalsIndexes.Add(hospitalIndex);
            }

            for (int i = 0; i < this.streetsCount; i++)
            {
                var street = Console.ReadLine().Split(this.edgeSeparators, StringSplitOptions.RemoveEmptyEntries);
                var v1 = int.Parse(street[0]) - 1;
                var v2 = int.Parse(street[1]) - 1;
                var weight = int.Parse(street[2]);
                this.matrix[v1, v2] = weight;
                this.matrix[v2, v1] = weight;
            }
        }
    }
}