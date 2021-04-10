namespace _02.BankSystem
{
    using System;
    using _02.BankSystem.Abstract;

    public class LoanAccount : Account
    {
        private const double MonthsWithNoRateForIndividuals = 3;
        private const double MonthsWithNoRateForCompanies = 2;

        public LoanAccount(Customer customer, double interestRate, double balance)
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
                double interestAmount = this.InterestRate * (months - MonthsWithNoRateForIndividuals);

                if (interestAmount < 0)
                {
                    return 0;
                }
                else
                {
                    return interestAmount;
                }
            }
            else
            {
                double interestAmount = this.InterestRate * (months - MonthsWithNoRateForCompanies);

                if (interestAmount < 0)
                {
                    return 0;
                }
                else
                {
                    return interestAmount;
                }
            }
        }
    }
}
