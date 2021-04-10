namespace StatePattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customer = new Customer("Pesho");
            customer.Buy("Bike", 100);
            customer.Buy("Phone", 200);
            customer.Buy("Drugs", 300);
            customer.Buy("Car", 400);
            customer.Buy("TV", 100);
            customer.Buy("EyePhone", 100);
            customer.Buy("Pear", 100);
        }
    }
}
