using System;
using BankLibrary.Domain.Abstractions;

namespace BankLibrary.Domain
{
    public enum AccountType
    {
        Ordinary,
        Deposit
    }
    public class Bank<T> where T : Account
    {
        private T[] _accounts;

        public string Name { get; private set; }

        public Bank(string name)
        {
            Name = name;
        }

        public void Put(decimal sum, int id)
        {
            var account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Put(sum);
        }

        public void Withdraw(decimal sum, int id)
        {
            var account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Withdraw(sum);
        }

        public void Close(int id)
        {
            var account = FindAccount(id, out var index);
            if (account == null)
                throw new Exception("Счет не найден");

            account.Close();

            if(_accounts.Length <= 1)
            {
                _accounts = null;
            }
            else
            {
                var tempAccounts = new T[_accounts.Length - 1];
                for(int i = 0, j = 0; i < _accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = _accounts[i];
                }
                _accounts = tempAccounts;
            }
        }

        public void CalculatePercantage()
        {
            if(_accounts == null)
            {
                return;
            }

            foreach (var t in _accounts)
            {
                t.IncrementDays();
                t.Calculate();
            }
        }

        public T FindAccount(int id)
        {
            for(int i = 0; i < _accounts.Length; i++)
            {
                if(_accounts[i].Id == id)
                {
                    return _accounts[i];
                }
            }
            return null;
        }
        public T FindAccount(int id, out int index)
        {
            for(var i = 0; i < _accounts.Length; i++)
            {
                if (_accounts[i].Id != id) continue;
                index = i;
                return _accounts[i];
            }
            index = -1;
            return null;
        }
    }
}
