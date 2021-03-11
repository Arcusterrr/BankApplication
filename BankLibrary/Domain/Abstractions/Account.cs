namespace BankLibrary.Domain.Abstractions
{
    public abstract class Account
    {
        private static int _counter;
        protected int Days;

        public decimal Sum { get; private set; }
        public int Percantage { get; private set; }
        public int Id { get; private set; }

        public abstract string OpenText { get; }
        public abstract string? ValidateWithdraw(decimal sum);
        public virtual string? ValidatePut(decimal sum) => null;
        
        protected Account(decimal sum, int percantage)
        {
            Sum = sum;
            Percantage = percantage;
            Id = ++_counter;
        }

        protected internal void IncrementDays()
        {
            Days++;
        }

        public void SubtractSum(in decimal sum)
        {
            Sum -= sum;
        }

        public void AddSum(decimal sum)
        {
            Sum += sum;
        }
    }
}
