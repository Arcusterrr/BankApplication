using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Domain
{
    public class DemandAccount : Account
    {
        public DemandAccount(decimal sum, int percantage) 
            : base(sum, percantage) { }


        public override string OpenText => $"Открыт новый счет до востребования! Id счета: {Id}";
        public override string? ValidateWithdraw(decimal sum) => Sum < sum ? $"На счету {Id} недостаточно средств" : null;
        
    }
}
