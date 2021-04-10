namespace GraphInitializations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphWithAdjacencyList
    {
        private char[] edgesSeparators = new char[] { '\n', '\r' };
        private char[] edgeSeparators = new char[] { ' ' };
        private int n;
        private int m;
        private List<int>[] vertices;

        public GraphWithAdjacencyList(int n, int m, string input)
        {
            this.n = n;
            this.m = m;
            this.vertices = new List<int>[n + 1];
            this.ParseLists(n, m, input);
        }

        public void Print()
        {
            // Console.Write("\t");
            // for (int i = 0; i < n; i++)
            // {
            // Console.Write("{0}\t", i + 1);
            // }
            // Console.WriteLine();
            // for (int v1 = 0; v1 < vertices.Length; v1++)
            // {
            // var row = vertices[v1];
            // Console.Write("{0}|\t", v1 + 1);
            // for (int v2 = 0; v2 < m; v2++)
            // {
            // if (row.Contains(v2))
            // {
            // Console.Write("1\t");
            // }
            // else
            // {
            // Console.Write("0\t");
            // }
            // }
            // Console.WriteLine();
            // }
            for (int vertex = 1; vertex < this.vertices.Length; vertex++)
            {
                var neightbours = this.vertices[vertex];
                Console.WriteLine("{0} -> {1}", vertex, string.Join(", ", neightbours));
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

                if (this.vertices[v1] == null)
                {
                    this.vertices[v1] = new List<int>();   
                }

                this.vertices[v1].Add(v2);

                // not oriented graph
                // if (this.vertices[v2] == null)
                // {
                //     this.vertices[v2] = new List<int>();
                // }
                   
                // vertices[v2].Add(v1);
            }
        }
    }
}
