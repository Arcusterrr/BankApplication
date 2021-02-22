using System.Collections.Generic;
using System.Linq;
using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Infrastructure.AccountStorage
{
    public class SimpleAccountStorage: IAccountStorage
    {
        private static readonly List<Account> Accounts = new List<Account>();

        public void Add(Account account) => Accounts.Add(account);
        public Account? Get(int id) => Accounts.FirstOrDefault(x => x.Id == id);
        public void Remove(Account account) => Accounts.Remove(account);
    }
}