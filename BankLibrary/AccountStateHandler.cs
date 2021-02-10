using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public decimal Sum { get; private set; }

        public AccountEventArgs(string _message, decimal _sum)
        {
            Message = _message;
            Sum = _sum;
        }
    }
}
