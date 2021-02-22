using System;
using BankLibrary.Domain;
using BankLibrary.Domain.Abstractions;
using BankLibrary.Infrastructure.AccountStorage;

namespace BankLibrary.UseCases
{
    public class OpenBankAccountUseCase
    {
        private readonly IAccountStorage _accountStorage;

        public OpenBankAccountUseCase(IAccountStorage accountStorage)
        {
            _accountStorage = accountStorage;
        }

        public void Open(
            AccountType accountType, 
            decimal sum, 
            AccountStateHandler addSumHandler, 
            AccountStateHandler withdrawSumHandler,
            AccountStateHandler calculationHandler, 
            AccountStateHandler closeAccountHandler, 
            AccountStateHandler openAccountHandler
        )
        {
            Account newAccount = accountType switch
            {
                AccountType.Ordinary => new DemandAccount(sum, 1),
                AccountType.Deposit => new DepositAccount(sum, 40),
                _ => throw new ArgumentOutOfRangeException(nameof(accountType))
            };

            _accountStorage.Add(newAccount);

            newAccount.Added += addSumHandler;
            newAccount.Withdrawed += withdrawSumHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Calculated += calculationHandler;

            newAccount.Open();
        }
    }
}
