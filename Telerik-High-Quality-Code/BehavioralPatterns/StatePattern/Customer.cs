namespace StatePattern
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer(string fullName)
        {
            this.FullName = fullName;
            this.Orders = new List<Order>();
            this.State = new SilverState(this);
        }

        public string FullName { get; set; }

        public State State { get; set; }

        public IList<Order> Orders { get; set; }

        public void Buy(string itemName, decimal price)
        {
            this.State.Buy(itemName, price);
        }
    }
}
