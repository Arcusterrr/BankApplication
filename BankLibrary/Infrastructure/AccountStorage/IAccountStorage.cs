using BankLibrary.Domain;
using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Infrastructure.AccountStorage
{
    public interface IAccountStorage
    {
        public void Add(Bank bank, Account account);
        public Account? Get(Bank bank, int id);
        public void Remove(Bank bank, Account account);
    }
}