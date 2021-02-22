using System;
using BankLibrary.Domain;
using BankLibrary.Domain.Abstractions;
using BankLibrary.Infrastructure.AccountStorage;
using BankLibrary.Infrastructure.Output;

namespace BankLibrary.UseCases.BankCases
{
    public class OpenBankAccountUseCase
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IOutput _output;

        public OpenBankAccountUseCase(IAccountStorage accountStorage, IOutput output)
        {
            _accountStorage = accountStorage;
            _output = output;
        }

        public void Open(Bank bank, AccountType accountType, decimal sum)
        {
            Account newAccount = accountType switch
            {
                AccountType.Ordinary => new DemandAccount(sum, 1),
                AccountType.Deposit => new DepositAccount(sum, 40),
                _ => throw new ArgumentOutOfRangeException(nameof(accountType))
            };

            _accountStorage.Add(bank, newAccount);

            _output.OutputMessage(newAccount.OpenText);
        }
    }
}
