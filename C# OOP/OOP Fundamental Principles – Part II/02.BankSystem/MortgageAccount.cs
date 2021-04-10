namespace _02.BankSystem
{
    using System;
    using _02.BankSystem.Abstract;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, double interestRate, double balance)
            : base(customer, interestRate, balance)
        {
        }

        public override double CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid months value.");
            }

            if (this.Customer is Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }

                double interestAmount = this.InterestRate * (months - 6);

                return interestAmount;
            }
            else
            {
                double interestAmount = this.InterestRate * months;

                if (months <= 12)
                {
                    return interestAmount / 2;
                }

                double interestRateForFirstYear = this.InterestRate * 12 / 2;
                interestAmount -= interestRateForFirstYear;

                return interestAmount;
            }
        }
    }
}
