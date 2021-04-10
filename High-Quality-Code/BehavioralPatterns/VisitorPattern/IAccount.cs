namespace VisitorPattern
{
    public interface IAccount
    {
        string Holder { get; }

        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        bool Deposit(decimal amount);

        bool Withdraw(decimal amount);

        void Accept(IVisitor visitor);
    }
}
