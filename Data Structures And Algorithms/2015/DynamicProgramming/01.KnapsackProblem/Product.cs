namespace _01.KnapsackProblem
{
    public class Product
    {
        public Product(string name, int weight, int price)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }
    }
}
