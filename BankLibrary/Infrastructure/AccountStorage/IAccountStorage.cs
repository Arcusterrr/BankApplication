using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Infrastructure.AccountStorage
{
    public interface IAccountStorage
    {
        public void Add(Account account);
        public Account? Get(int id);
        public void Remove(Account account);
    }
}