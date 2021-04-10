namespace StatePattern
{
    using System;
    using System.Linq;

    public class GoldState : State
    {
        public GoldState(Customer customer)
            : base(customer)
        {
            this.Discount = 5;
            this.LowerLimit = 1000;
            this.UpperLimit = decimal.MaxValue;
        }

        public override void Buy(string itemName, decimal price)
        {
            var lastMonthOrders = this.CalculateLastMonthOrders();

            if (lastMonthOrders < this.LowerLimit)
            {
                this.ChangeState();
                this.Customer.State.Buy(itemName, price);
            }
            else
            {
                var discount = price * this.Discount / 100;
                var priceWithDiscount = price - discount;
                var newOrder = new Order(itemName, priceWithDiscount);
                this.Customer.Orders.Add(newOrder);
                Console.WriteLine("Item: {0} Price: {1}", newOrder.ItemName, newOrder.Price);
            }
        }

        protected override void ChangeState()
        {
            this.Customer.State = new SilverState(this.Customer);
        }
    }
}
