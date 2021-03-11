using System.Collections.Generic;
using System.Linq;
using BankLibrary.Domain;
using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Infrastructure.AccountStorage
{
    public class SimpleAccountStorage: IAccountStorage
    {
        private static readonly IDictionary<Bank, List<Account>> BankToAccounts = new Dictionary<Bank, List<Account>>();

        public SimpleAccountStorage(List<Bank> banks)
        {
            banks.ForEach(bank =>
            {
                BankToAccounts.Add(bank, new List<Account>());
            });
        }

        public void Add(Bank bank, Account account)
        {
            BankToAccounts.TryGetValue(bank, out var bankAccounts);
            bankAccounts!.Add(account);
        }

        public Account? Get(Bank bank, int id)
        {
            BankToAccounts.TryGetValue(bank, out var bankAccounts);
            return bankAccounts!.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Bank bank, Account account)
        {
            BankToAccounts.TryGetValue(bank, out var bankAccounts);
            bankAccounts!.Remove(account);
        }
    }
}