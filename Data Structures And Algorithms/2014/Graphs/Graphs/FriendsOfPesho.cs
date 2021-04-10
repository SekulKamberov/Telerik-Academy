namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FriendsOfPesho
    {
        public static int Dijkstra(int[,] graph, int startNode, int endNode)
        {
            int[] Distance = new int[graph.GetLength(0)];
            HashSet<int> SetOfNodes = new HashSet<int>();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Distance[i] = int.MaxValue;
                SetOfNodes.Add(i);
            }

            Distance[startNode] = 0;

            while (SetOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in SetOfNodes)
                {
                    if (minNode > Distance[node])
                    {
                        minNode = node;
                    }
                }

                SetOfNodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    break;
                }

                int[] a = Distance;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potentialDistance = Distance[minNode] + graph[minNode, i];
                        if (potentialDistance < Distance[i])
                        {
                            Distance[i] = potentialDistance;
                        }
                    }
                }
            }

            return Distance[endNode];
        }


        static void Main(string[] args)
        {
            char[] separator = { ' ' };
            string[] firstLine = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            int N = int.Parse(firstLine[0]); // nodes
            int M = int.Parse(firstLine[1]); // edges
            int H = int.Parse(firstLine[2]); // hospitals

            string[] hospitalsInput = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

            HashSet<int> hosp = new HashSet<int>();

            for (int i = 0; i < hospitalsInput.Length; i++)
            {
                hosp.Add(int.Parse(hospitalsInput[i]));
            }

            int[,] dijkstraGraph = new int[N, N];

            for (int i = 0; i < M; i++)
            {
                string[] line = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                int node1 = int.Parse(line[0]);
                int node2 = int.Parse(line[1]);
                int edge = int.Parse(line[2]);

                dijkstraGraph[node1 - 1, node2 - 1] = edge;
                dijkstraGraph[node2 - 1, node1 - 1] = edge;
            }

            int MIN = int.MaxValue;
            for (int i = 0; i < H; i++)
            {
                int countMinRoad = 0;
                Console.WriteLine("Hospital {0} : ", i + 1);
                for (int j = H; j < N; j++)
                {
                    int min = Dijkstra(dijkstraGraph, i, j);
                    countMinRoad += min;
                    Console.WriteLine("MIN {0} : {1}", j + 1, min);
                }
                Console.WriteLine("Hospital minimum: " + countMinRoad);
                if (MIN > countMinRoad)
                {
                    MIN = countMinRoad;
                }

            }
            Console.WriteLine();
            Console.WriteLine("THE MIN: " + MIN);
        }
    }
}
