namespace VisitorPattern
{
    public class CreditAccount : Account
    {
        public CreditAccount(string holder, decimal balance = 0, decimal limit = 100)
            : base(holder, balance)
        {
            this.Limit = limit;
        }

        public decimal Limit { get; set; }

        public override bool Withdraw(decimal amount)
        {
            if (amount > 0 && (amount + this.Balance < this.Limit))
            {
                this.Balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
