namespace OnlineStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        private const string NoProductsFoundMessage = "No products found";
        private static Dictionary<string, Bag<Product>> productsByName = new Dictionary<string, Bag<Product>>();
        private static Dictionary<string, Bag<Product>> productsByProducer = new Dictionary<string, Bag<Product>>();
        private static Dictionary<string, Bag<Product>> productsByNameAndProducer = new Dictionary<string, Bag<Product>>();
        private static Dictionary<decimal, Bag<Product>> productsByPrice = new Dictionary<decimal, Bag<Product>>();
        
        private static StringBuilder output = new StringBuilder();

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();
                ReadCommand(command);
            }

            Console.WriteLine(output.ToString());
        }

        private static void ReadCommand(string input)
        {
            var firstEmptySpaceIndex = input.IndexOf(' ');
            var command = input.Substring(0, firstEmptySpaceIndex);
            var parametars = input.Substring(firstEmptySpaceIndex + 1);
            var paramsSeparated = parametars.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (command.Equals("AddProduct"))
            {
                AddProduct(paramsSeparated[0], decimal.Parse(paramsSeparated[1]), paramsSeparated[2]);
            }
            else if (command.Equals("FindProductsByName"))
            {
                FindProductByName(paramsSeparated[0]);
            }
            else if (command.Equals("FindProductsByProducer"))
            {
                FindProductsByProducer(paramsSeparated[0]);
            }
            else if (command.Equals("FindProductsByPriceRange"))
            {
                FindProductsByPriceRange(decimal.Parse(paramsSeparated[0]), decimal.Parse(paramsSeparated[1]));
            }

            else if (command.Equals("DeleteProducts"))
            {
                DeleteProducts(paramsSeparated);
            }
        }

        private static void AddProduct(string name, decimal price, string producer)
        {
            var productToAdd = new Product(name, price, producer);
            if (!productsByName.ContainsKey(productToAdd.Name))
            {
                productsByName[productToAdd.Name] = new Bag<Product>();
            }

            productsByName[productToAdd.Name].Add(productToAdd);

            if (!productsByProducer.ContainsKey(productToAdd.Producer))
            {
                productsByProducer[productToAdd.Producer] = new Bag<Product>();
            }

            productsByProducer[productToAdd.Producer].Add(productToAdd);

            var nameProducerKey = productToAdd.Name + ";" + productToAdd.Producer;
            if (!productsByNameAndProducer.ContainsKey(nameProducerKey))
            {
                productsByNameAndProducer[nameProducerKey] = new Bag<Product>();
            }

            productsByNameAndProducer[nameProducerKey].Add(productToAdd);

            if (!productsByPrice.ContainsKey(productToAdd.Price))
            {
                productsByPrice[productToAdd.Price] = new Bag<Product>();
            }

            productsByPrice[productToAdd.Price].Add(productToAdd);

            output.AppendLine("Product added");
        }

        private static void DeleteProducts(string [] parameters)
        {
            if (parameters.Length == 1)
            {
                if (productsByProducer.ContainsKey(parameters[0]))
                {
                    output.AppendLine(productsByProducer[parameters[0]].Count + " products deleted");

                    foreach (var product in productsByProducer[parameters[0]])
                    {
                        productsByName[product.Name].Remove(product);
                        productsByNameAndProducer[product.Name + ";" + product.Producer].Remove(product);
                        productsByPrice[product.Price].Remove(product);
                    }

                    productsByProducer.Remove(parameters[0]);
                }
                else
                {
                    output.AppendLine(NoProductsFoundMessage);
                }
            }
            else
            {
                var nameProducerKey = parameters[0] + ";" + parameters[1];
                if (productsByNameAndProducer.ContainsKey(nameProducerKey))
                {
                    output.AppendLine(productsByNameAndProducer[nameProducerKey].Count + " products deleted");

                    foreach (var product in productsByNameAndProducer[nameProducerKey])
                    {
                        productsByName[product.Name].Remove(product);
                        productsByPrice[product.Price].Remove(product);
                        productsByProducer[product.Producer].Remove(product);
                    }

                    productsByNameAndProducer.Remove(nameProducerKey);
                }
                else
                {
                    output.AppendLine(NoProductsFoundMessage);
                }
            }
        }

        private static void FindProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var products = productsByPrice.Where(x => x.Key >= minPrice && x.Key <= maxPrice).SelectMany(x => x.Value);

            PrintProducts(products);
        }

        private static void FindProductsByProducer(string producer)
        {
            var products = new Bag<Product>();

            if (productsByProducer.ContainsKey(producer))
            {
                products = productsByProducer[producer];
            }

            PrintProducts(products);
        }

        private static void FindProductByName(string name)
        {
            var products = new Bag<Product>();
            if (productsByName.ContainsKey(name))
            {
                products = productsByName[name];
            }

            PrintProducts(products);
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            var orderedProducts = products.OrderBy(x => x.ToString());

            if (products.Any())
            {
                foreach (var product in orderedProducts)
                {
                    output.AppendLine(product.ToString());
                }
            }
            else
            {
                output.AppendLine(NoProductsFoundMessage);
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string product)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = product;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
        }

        public int CompareTo(Product other)
        {
            return this.ToString().CompareTo(other.ToString());
        }

        public override bool Equals(object obj)
        {
            var otherProduct = obj as Product;
            if (otherProduct == null)
            {
                return false;
            }

            if (this.Name.Equals(otherProduct.Name) 
                && this.Price.Equals(otherProduct.Price)
                && this.Producer.Equals(otherProduct.Producer))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() << 17 ^ this.Price.GetHashCode() << 3 ^ this.Producer.GetHashCode() >> 23;
        }
    }
}
