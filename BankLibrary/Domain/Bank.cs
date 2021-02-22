namespace BankLibrary.Domain
{
    public enum AccountType
    {
        Ordinary,
        Deposit
    }
    public class Bank
    {
        public Bank(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
