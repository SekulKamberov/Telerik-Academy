namespace _02.BankSystem
{
    using System;
    using System.Collections.Generic;
    using _02.BankSystem.Abstract;
    using _02.BankSystem.Interfaces;

    public class Bank : IBank
    {
        private IList<Account> accounts;
        private string name;

        public Bank(string name, IList<Account> accounts)
        {
            this.Name = name;
            this.Accounts = accounts;
        }

        public IList<Account> Accounts
        {
            get
            {
                return this.accounts;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Accounts value is null.");
                }

                this.accounts = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Bank name is invalid!");
                }

                this.name = value;
            }
        }
    }
}
