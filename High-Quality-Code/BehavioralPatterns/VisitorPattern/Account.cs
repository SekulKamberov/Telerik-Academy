namespace VisitorPattern
{
    public abstract class Account : IAccount
    {
        public Account(string holder, decimal balance = 0, decimal interestRate = 10)
        {
            this.Holder = holder;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public string Holder { get; private set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; set; }

        public abstract bool Deposit(decimal amount);

        public abstract bool Withdraw(decimal amount);

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
