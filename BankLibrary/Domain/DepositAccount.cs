using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Domain
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal sum, int percantage)
            : base( sum, percantage) { }

        public override string OpenText => $"Открыт новый депозитный счет! Id счета: {Id}";

        private bool Check => Days % 30 != 0;

        public override string? ValidateWithdraw(decimal sum) =>
            Check ? "Вывести средства можно только после 30ти дневного периода!" : null;

        public override string? ValidatePut(decimal sum) =>
            Check ? "На счет можно положить только после 30ти дневного периода!" : null;
    }
}
