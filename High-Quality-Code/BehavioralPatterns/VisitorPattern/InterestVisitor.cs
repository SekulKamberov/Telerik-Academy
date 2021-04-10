namespace VisitorPattern
{
    using System;

    public class InterestVisitor : IVisitor
    {
        public InterestVisitor(decimal interestRate)
        {
            if (interestRate < 0)
            {
                throw new ArgumentOutOfRangeException("Interest Rate cant be negative!");
            }

            this.InterestRate = interestRate;
        }

        public decimal InterestRate { get; set; }

        public void Visit(IAccount bankAccount)
        {
            if (bankAccount != null)
            {
                bankAccount.InterestRate = this.InterestRate;
            }
        }
    }
}
