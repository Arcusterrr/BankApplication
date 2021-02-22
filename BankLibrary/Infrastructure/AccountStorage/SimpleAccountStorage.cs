using System.Collections.Generic;
using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Infrastructure.AccountStorage
{
    public class SimpleAccountStorage: IAccountStorage
    {
        private static List<Account> _accounts = new List<Account>();

        public void Add(Account account) => _accounts.Add(account);
    }
}