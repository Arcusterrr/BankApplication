using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Domain
{
    public class DepositAccount : Account
    {
        public DepositAccount(decimal sum, int percantage): base( sum, percantage)
        {
        }

        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"Открыт новый депозитный счет! Id счета: {Id}", Sum));
        }

        public override void Put(decimal sum)
        {
            if (Days % 30 == 0)
            {
                base.Put(sum);
            }
            else 
            {
                base.onAdded(new AccountEventArgs("На счет можно положить только после 30ти дневного периода!", 0));
            }
        }

        public override decimal Withdraw(decimal sum)
        {
            if (Days % 30 == 0)
                return base.Withdraw(sum);
            else
                base.onWithDrawed(new AccountEventArgs("Вывести средства можно только после 30ти дневного периода!", 0));
            return 0;
        }

        protected internal override void Calculate()
        {
            if(Days % 30 == 0)
                base.Calculate();
        }
    }
}
