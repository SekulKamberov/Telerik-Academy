namespace VisitorPattern
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string holder, decimal balance = 0)
            : base(holder, balance)
        {
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount < 0 || this.Balance < amount)
            {
                return false;
            }
            else
            {
                this.Balance -= amount;
                return true;
            }
        }

        public override bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
