namespace InternetNeighbourhood
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Console.Write("Insert number of Houses: ");
            int numberOfHouses = int.Parse(Console.ReadLine());
            Console.Write("Insert number of Roads: ");
            int numberOfRoads = int.Parse(Console.ReadLine());
            List<Edge> edges = new List<Edge>();

            InitializeGraph(edges, numberOfRoads);

            edges.Sort();

            int[] tree = new int[numberOfRoads + 1]; //we start from 1, not from 0
            var mpd = new List<Edge>();
            int treesCount = 1;

            treesCount = FindMinimumSpanningTree(edges, tree, mpd, treesCount);

            PrintMinimumSpanningTree(mpd);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
            return treesCount;
        }

        private static void PrintMinimumSpanningTree(IEnumerable<Edge> usedEdges)
        {
            int sum = 0;
            foreach (var edge in usedEdges)
            {
                sum += edge.Weight;
                Console.WriteLine(edge);
            }

            Console.WriteLine("Minimum cable length: " + sum);
        }

        private static void InitializeGraph(List<Edge> edges, int numberOfNodes)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                Console.Write("Start node (House): ", i + 1);
                int startNode = int.Parse(Console.ReadLine());
                Console.Write("End node (House): ", i + 1);
                int endNode = int.Parse(Console.ReadLine());
                Console.Write("Distance: ", i + 1);
                int distance = int.Parse(Console.ReadLine());
                edges.Add(new Edge(startNode, endNode, distance));
            }
        }
    }
}