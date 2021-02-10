using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    interface IAccount
    {
        void Put(decimal sum);

        void Withdraw(decimal sum);
    }
}
