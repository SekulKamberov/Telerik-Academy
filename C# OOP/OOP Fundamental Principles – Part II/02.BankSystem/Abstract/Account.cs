namespace _02.BankSystem.Abstract
{
    using System;
    using _02.BankSystem.Interfaces;

    public abstract class Account : IDepositable, IRateCalculatable
    {
        private Customer customer;
        private double interestRate;
        private double balance;

        public Account(Customer customer, double interestRate, double balance)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.balance = balance;
        }

        public double Balance
        {
            get 
            {
                return this.balance; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance can not be negative.");
                }

                this.balance = value; 
            }
        }

        public double InterestRate
        {
            get
            {
                return this.interestRate; 
            }

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate can not be negative.");
                }

                this.interestRate = value; 
            }
        }

        public Customer Customer
        {
            get 
            {
                return this.customer; 
            }

            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer value is null.");
                }

                this.customer = value;
            }
        }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount is incorect.");
            }

            this.Balance += amount;
        }

        public virtual double CalculateInterestAmount(int months)
        {
            return this.interestRate * months;
        }
    }
}
