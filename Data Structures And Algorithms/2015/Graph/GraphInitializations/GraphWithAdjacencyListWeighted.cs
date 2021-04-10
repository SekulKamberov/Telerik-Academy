namespace GraphInitializations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithAdjacencyListWeighted
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private int m;
        private List<Node>[] vertices;

        public GraphWithAdjacencyListWeighted(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.vertices = new List<Node>[n + 1];
            this.ParseLists(n, m, input);
        }

        public void Print()
        {
            for (int vertex = 1; vertex < this.vertices.Length; vertex++)
            {
                var neightbours = this.vertices[vertex];
                Console.Write("{0} -> ", vertex);
                for (int v2 = 0; v2 < neightbours.Count; v2++)
                {
                    Console.Write("{0}({1}){2}", neightbours[v2].Vertex, neightbours[v2].Weight, v2 != neightbours.Count - 1 ? ", " : string.Empty);
                }

                Console.WriteLine();
            }
        }

        private void ParseLists(int n, int m, string input)
        {
            var edgesString = input.Split(this.edgesSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var edgeString in edgesString)
            {
                var edge = edgeString.Split(this.edgeSeparators, StringSplitOptions.RemoveEmptyEntries);
                var v1 = int.Parse(edge[0]);
                var v2 = int.Parse(edge[1]);
                var weight = int.Parse(edge[2]);

                if (this.vertices[v1] == null)
                {
                    this.vertices[v1] = new List<Node>();
                }

                this.vertices[v1].Add(new Node(v2, weight));

                // not oriented graph
                // if (this.vertices[v2] == null)
                // {
                //     this.vertices[v2] = new List<Node>();
                // }

                // vertices[v2].Add(new Node(v1, weight));
            }
        }
    }
}
