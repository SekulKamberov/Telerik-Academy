namespace _02.BankSystem
{
    using System;
    using _02.BankSystem.Abstract;
    using _02.BankSystem.Interfaces;

    public class DepositAccount : Account, IDrawable
    {
        public DepositAccount(Customer customer, double interestRate, double balance)
            : base(customer, interestRate, balance)
        {
        }

        public override double CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid months value.");
            }

            if (this.Balance > 1000)
            {
                double interestAmount = this.InterestRate * months;

                return interestAmount;
            }
            else
            {
                return 0;
            }
        }

        public void Draw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount is invalid.");
            }

            if (this.Balance < amount)
            {
                throw new ArgumentOutOfRangeException("Not enough money in tha balance.");
            }

            this.Balance -= amount;
        }
    }
}
