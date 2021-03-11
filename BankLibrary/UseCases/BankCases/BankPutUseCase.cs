using System;
using BankLibrary.Domain;
using BankLibrary.Infrastructure.AccountStorage;
using BankLibrary.Infrastructure.Output;

namespace BankLibrary.UseCases.BankCases
{
    public class BankPutUseCase
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IOutput _output;

        public BankPutUseCase(IAccountStorage accountStorage, IOutput output)
        {
            _accountStorage = accountStorage;
            _output = output;
        }

        public void Put(Bank bank, decimal sum, int id)
        {
            var account = _accountStorage.Get(bank, id);
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var putValidationMessage = account.ValidatePut(sum);

            if (putValidationMessage is null)
            {
                account.AddSum(sum);
                _output.OutputMessage($"На счёт {account.Id} добавлено {sum}. Итоговая сумма - {account.Sum}");
            }
            else
            {
                _output.OutputMessage(putValidationMessage);
            }
        }
    }
}