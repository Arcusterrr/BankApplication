using System;
using BankLibrary.Domain;
using BankLibrary.Infrastructure.AccountStorage;

namespace BankLibrary.UseCases.BankCases
{
    public class CloseBankAccountUseCase
    {
        private readonly IAccountStorage _accountStorage;

        public CloseBankAccountUseCase(IAccountStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public void Close(Bank bank, int id)
        {
            var account = _accountStorage.Get(bank, id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            account.Close();

            _accountStorage.Remove(bank, account);
        }
    }
}