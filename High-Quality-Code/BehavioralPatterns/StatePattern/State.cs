namespace StatePattern
{
    using System;
    using System.Linq;

    public abstract class State
    {
        public State(Customer customer)
        {
            this.Customer = customer;
            this.NotifyStateState();
        }

        public Customer Customer { get; set; }

        public decimal Discount { get; set; }

        public decimal LowerLimit { get; set; }

        public decimal UpperLimit { get; set; }

        public abstract void Buy(string itemName, decimal price);

        protected abstract void ChangeState();

        protected decimal CalculateLastMonthOrders()
        {
            var lastMonthOrders = this.Customer.Orders
                .Where(order => order.Date >= DateTime.Now.AddMonths(-1))
                .Select(order => order.Price)
                .Sum();

            return lastMonthOrders;
        }

        protected void NotifyStateState()
        {
            Console.WriteLine("Your state is " + this.GetType().Name);
        }
    }
}
