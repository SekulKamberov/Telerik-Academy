namespace _02.FindProductsInRange
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}\t-\tPrice: {1}", this.Name, this.Price);
        }

        public int CompareTo(Product otherPerson)
        {
            return this.Price.CompareTo(otherPerson.Price);
        }
    }
}
