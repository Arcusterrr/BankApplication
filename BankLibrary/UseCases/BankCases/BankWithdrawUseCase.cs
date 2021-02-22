using System;
using BankLibrary.Infrastructure.AccountStorage;

namespace BankLibrary.UseCases.BankCases
{
    public class BankWithdrawUseCase
    {
        private readonly IAccountStorage _accountStorage;

        public BankWithdrawUseCase(IAccountStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public void Withdraw(decimal sum, int id)
        {
            var account = _accountStorage.Get(id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            
            account.Withdraw(sum);
        }
    }
}