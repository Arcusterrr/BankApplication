using System;
using BankLibrary.Infrastructure.AccountStorage;

namespace BankLibrary.UseCases
{
    public class CloseBankAccountUseCase
    {
        private readonly IAccountStorage _accountStorage;

        public CloseBankAccountUseCase(IAccountStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public void Close(int id)
        {
            var account = _accountStorage.Get(id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            account.Close();

            _accountStorage.Remove(account);
        }
    }
}