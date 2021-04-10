namespace StatePattern
{
    using System;

    public class Order
    {
        public Order(string itemName, decimal price)
        {
            this.ItemName = itemName;
            this.Price = price;
            this.Date = DateTime.Now;
        }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public string ItemName { get; set; }
    }
}
