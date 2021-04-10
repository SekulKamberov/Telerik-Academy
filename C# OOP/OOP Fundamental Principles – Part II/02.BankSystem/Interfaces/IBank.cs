namespace _02.BankSystem.Interfaces
{
    using System.Collections.Generic;
    using _02.BankSystem.Abstract;

    public interface IBank
    {
        string Name { get; set; }

        IList<Account> Accounts { get; set; }
    }
}
