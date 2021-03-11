using System;
using BankLibrary.Domain;
using BankLibrary.Infrastructure.AccountStorage;
using BankLibrary.Infrastructure.Output;

namespace BankLibrary.UseCases.BankCases
{
    public class CloseBankAccountUseCase
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IOutput _output;

        public CloseBankAccountUseCase(IAccountStorage accountStorage, IOutput output)
        {
            _accountStorage = accountStorage;
            _output = output;
        }

        public void Close(Bank bank, int id)
        {
            var account = _accountStorage.Get(bank, id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            _output.OutputMessage($"Счет {account.Id} закрыт. Итоговая сумма: {account.Sum}");

            _accountStorage.Remove(bank, account);
        }
    }
}