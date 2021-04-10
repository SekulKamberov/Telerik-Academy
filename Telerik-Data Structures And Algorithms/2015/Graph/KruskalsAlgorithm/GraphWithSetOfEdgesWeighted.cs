namespace KruskalsAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithSetOfEdgesWeighted
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private int m;
        private List<EdgeWeighted> edges;

        public GraphWithSetOfEdgesWeighted(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.edges = new List<EdgeWeighted>();
            this.ParseEdges(n, m, input);
        }

        public void Print()
        {
            var lastEdgeIndex = this.edges.Count - 1;
            for (int vertex = 0; vertex < this.edges.Count; vertex++)
            {
                var edge = this.edges[vertex];
                Console.Write("{{{0}, {1}({2})}}{3}", edge.StartNode, edge.EndNode, edge.Weight, vertex != lastEdgeIndex ? " " : string.Empty);
            }

            Console.WriteLine();
        }

        public int FindMinimumSpanningTree()
        {
            this.edges.Sort();
            int[] visitedEdges = new int[this.n + 1]; // we start from 1, not from 0
            var mpdEdges = new List<EdgeWeighted>();
            int treesCount = 1;

            foreach (var edge in this.edges)
            { 
                // not visited
                if (visitedEdges[edge.StartNode] == 0)
                {
                    // both ends are not visited
                    if (visitedEdges[edge.EndNode] == 0)
                    {
                        visitedEdges[edge.StartNode] = visitedEdges[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        visitedEdges[edge.StartNode] = visitedEdges[edge.EndNode];
                    }

                    mpdEdges.Add(edge);
                }
                else
                {
                    // the start is part of a tree
                    if (visitedEdges[edge.EndNode] == 0)
                    {
                        // attach the end node to the tree;
                        visitedEdges[edge.EndNode] = visitedEdges[edge.StartNode];
                        mpdEdges.Add(edge);
                    }
                    else if (visitedEdges[edge.EndNode] != visitedEdges[edge.StartNode])
                    {
                        // combine the trees
                        int oldTreeNumber = visitedEdges[edge.EndNode];

                        for (int i = 0; i < visitedEdges.Length; i++)
                        {
                            if (visitedEdges[i] == oldTreeNumber)
                            {
                                visitedEdges[i] = visitedEdges[edge.StartNode];
                            }
                        }

                        mpdEdges.Add(edge);
                    }
                }
            }

            this.PrintMinimumSpanningTree(mpdEdges);

            return treesCount;
        }

        private void PrintMinimumSpanningTree(IEnumerable<EdgeWeighted> mpdNodes)
        {
            foreach (EdgeWeighted edge in mpdNodes)
            {
                Console.WriteLine("{0}", edge);
            }
        }

        private void AddEdges(EdgeWeighted edge, List<EdgeWeighted> edges, List<EdgeWeighted> mpd, SortedSet<EdgeWeighted> priority, bool[] used)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (!mpd.Contains(edges[i]))
                {
                    if (edge.EndNode == edges[i].StartNode && !used[edges[i].EndNode])
                    {
                        priority.Add(edges[i]);
                    }
                }
            }
        }

        private void ParseEdges(int n, int m, string input)
        {
            var edgesString = input.Split(this.edgesSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var edgeString in edgesString)
            {
                var edge = edgeString.Split(this.edgeSeparators, StringSplitOptions.RemoveEmptyEntries);
                var v1 = int.Parse(edge[0]);
                var v2 = int.Parse(edge[1]);
                var weight = int.Parse(edge[2]);

                this.edges.Add(new EdgeWeighted(v1, v2, weight));

                // not oriented graph                   
                // edges.Add(new EdgeWeighted(v2, v1, weight));
            }
        }
    }
}