namespace StatePattern
{
    using System;
    using System.Linq;

    public class SilverState : State
    {
        public SilverState(Customer customer)
            : base(customer)
        {
            this.Discount = 0;
            this.UpperLimit = 1000;
        }

        public override void Buy(string itemName, decimal price)
        {
            var newOrder = new Order(itemName, price);
            this.Customer.Orders.Add(newOrder);
            Console.WriteLine("Item: {0} Price: {1}", newOrder.ItemName, newOrder.Price);
            var lastMonthOrders = this.CalculateLastMonthOrders();

            if (lastMonthOrders >= this.UpperLimit)
            {
                this.ChangeState();
            }
        }

        protected override void ChangeState()
        {
            this.Customer.State = new GoldState(this.Customer);
        }
    }
}
