namespace GraphInitializations
{
    public class Node
    {
        public Node(int vertex, int weight)
        {
            this.Vertex = vertex;
            this.Weight = weight;
        }

        public int Vertex { get; set; }

        public int Weight { get; set; }
    }
}
