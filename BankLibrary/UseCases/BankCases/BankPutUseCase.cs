using System;
using BankLibrary.Domain;
using BankLibrary.Infrastructure.AccountStorage;

namespace BankLibrary.UseCases.BankCases
{
    public class BankPutUseCase
    {
        private readonly IAccountStorage _accountStorage;

        public BankPutUseCase(IAccountStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public void Put(Bank bank, decimal sum, int id)
        {
            var account = _accountStorage.Get(bank, id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            account.Put(sum);
        }
    }
}