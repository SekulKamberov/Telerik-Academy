namespace PrimsAlgorithm
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

        public void FindMinimumSpanningTree()
        {
            SortedSet<EdgeWeighted> priority = new SortedSet<EdgeWeighted>();
            bool[] usedEdges = new bool[this.n + 1];
            List<EdgeWeighted> mpdEdges = new List<EdgeWeighted>();

            // adding edges that connect the node 1 with all the others - 2, 3, 4 ...
            foreach (EdgeWeighted edge in this.edges)
            {
                if (edge.StartNode == this.edges[0].StartNode)
                {
                    priority.Add(edge);
                }
            }

            usedEdges[this.edges[0].StartNode] = true;

            while (priority.Count > 0)
            {
                EdgeWeighted edge = priority.Min;
                priority.Remove(edge);

                if (!usedEdges[edge.EndNode])
                {
                    usedEdges[edge.EndNode] = true; // we "visit" this node
                    mpdEdges.Add(edge);
                    this.AddEdges(edge, this.edges, mpdEdges, priority, usedEdges);
                }
            }

            this.PrintMinimumSpanningTree(mpdEdges);
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