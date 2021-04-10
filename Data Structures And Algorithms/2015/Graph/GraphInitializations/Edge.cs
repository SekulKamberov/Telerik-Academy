namespace GraphInitializations
{
    public class Edge
    {
        public Edge(int v1, int v2)
        {
            this.V1 = v1;
            this.V2 = v2;
        }

        public int V1 { get; set; }

        public int V2 { get; set; }
    }
}
