using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Domain
{
    public class DemandAccount : Account
    {
        public DemandAccount(decimal sum, int percantage) : base(sum, percantage)
        {

        }

        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"Открыт новый счет до востребования! Id счета: {this.Id}", this.Sum));
        }
    }
}
