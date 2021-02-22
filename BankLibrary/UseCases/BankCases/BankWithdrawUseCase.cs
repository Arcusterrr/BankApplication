using System;
using BankLibrary.Domain;
using BankLibrary.Infrastructure.AccountStorage;
using BankLibrary.Infrastructure.Output;

namespace BankLibrary.UseCases.BankCases
{
    public class BankWithdrawUseCase
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IOutput _output;

        public BankWithdrawUseCase(IAccountStorage accountStorage, IOutput output)
        {
            _accountStorage = accountStorage;
            _output = output;
        }

        public void Withdraw(Bank bank, decimal sum, int id)
        {
            var account = _accountStorage.Get(bank, id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var withDrawValidationMessage = account.ValidateWithdraw(sum);

            if (withDrawValidationMessage is null)
            {
                account.SubtractSum(sum);
                _output.OutputMessage($"Со счета {account.Id} было снято: {sum}");
            }
            else
            {
                _output.OutputMessage(withDrawValidationMessage);
            }
        }
    }
}
