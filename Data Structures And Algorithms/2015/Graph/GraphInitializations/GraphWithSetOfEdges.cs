namespace GraphInitializations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithSetOfEdges
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private int m;
        private List<Edge> edges;

        public GraphWithSetOfEdges(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.edges = new List<Edge>();
            this.ParseEdges(n, m, input);
        }

        public void Print()
        {
            var lastEdgeIndex = this.edges.Count - 1;
            for (int vertex = 0; vertex < this.edges.Count; vertex++)
            {
                var edge = this.edges[vertex];
                Console.Write("{{{0}, {1}}}{2}", edge.V1, edge.V2, vertex != lastEdgeIndex ? " " : string.Empty);
            }

            Console.WriteLine();
        }

        private void ParseEdges(int n, int m, string input)
        {
            var edgesString = input.Split(this.edgesSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var edgeString in edgesString)
            {
                var edge = edgeString.Split(this.edgeSeparators, StringSplitOptions.RemoveEmptyEntries);
                var v1 = int.Parse(edge[0]);
                var v2 = int.Parse(edge[1]);

                this.edges.Add(new Edge(v1, v2));

                // not oriented graph                   
                // edges.Add(new Edge(v2, v1));
            }
        }
    }
}