namespace GraphInitializations
{
    public class EdgeWeighted
    {
        public EdgeWeighted(int v1, int v2, int weight)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.Weight = weight;
        }

        public int V1 { get; set; }

        public int V2 { get; set; }

        public int Weight { get; set; }
    }
}
