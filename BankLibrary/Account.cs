﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        protected internal event AccountStateHandler Withdrawed;
        protected internal event AccountStateHandler Added;
        protected internal event AccountStateHandler Opened;
        protected internal event AccountStateHandler Closed;
        protected internal event AccountStateHandler Calculated;

        static int counter = 0;
        protected int _days = 0;

        #region свойства
        public decimal Sum { get; private set; }
        public int Percantage { get; private set; }
        public int Id { get; private set; }
        #endregion


        public Account(decimal _sum, int _percantage)
        {
            Sum = _sum;
            Percantage = _percantage;
            Id = ++counter;
        }

        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (e != null)
            {
                handler?.Invoke(this, e);
            }
        }

        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }

        protected virtual void onWithDrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }

        protected virtual void onAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }

        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }

        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }

        public virtual void Put(decimal sum)
        {
            Sum += sum;
            onAdded(new AccountEventArgs("На счет поступило:" + sum, sum));
        } 

        public virtual decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if(Sum >= sum)
            {
                Sum -= sum;
                result = sum;
                onWithDrawed(new AccountEventArgs($"Со счета {Id} было снято: {sum}", sum));
            }
            else
            {
                onWithDrawed(new AccountEventArgs($"На счету {Id} недостаточно средств", 0));
            }
            return result;
        }

        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"Открыт новый счет! Id счёта: {Id}", Sum));
        }

        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Счет {Id} закрыт. Итоговая сумма: {Sum}", Sum));
        }

        protected internal void IncrementDays()
        {
            _days++;
        }

        protected internal virtual void Calculate()
        {
            decimal increment = Sum * Percantage / 100;
            Sum = Sum + increment;
            OnCalculated(new AccountEventArgs($"На счет зачислены проценты в размере: {increment}", Sum));
        }

    }
}