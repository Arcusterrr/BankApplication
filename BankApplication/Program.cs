using System;
using BankLibrary;
using BankLibrary.Domain;
using BankLibrary.Domain.Abstractions;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank<Account>("ЮнитБанк");
            var alive = true;
            while (alive)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Открыть счет \t 2. Вывести средства  \t 3. Добавить на счет");
                Console.WriteLine("4. Закрыть счет \t 5. Пропустить день \t 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта: ");
                Console.ForegroundColor = color;

                try
                {
                    var command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            OpenAccount(bank);
                            break;
                        case 2:
                            Withdraw(bank);
                            break;
                        case 3:
                            Put(bank);
                            break;
                        case 4:
                            CloseAccount(bank);
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;

                    }
                }
                catch(Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }

            }
        
            
            void OpenAccount(Bank<Account> bank)
            {
                Console.WriteLine("Укажите сумму для создания счета: ");

                var sum = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Выберите тип счета: 1. До востребования 2. Депозит");

                var type = Convert.ToInt32(Console.ReadLine());

                var accountType = type == 2 ? AccountType.Deposit : AccountType.Ordinary;

                bank.Open(accountType, sum, AddSumHandler, WithdrawSumHandler, (o, e) => Console.WriteLine(e.Message), CloseAccountHandler, OpenAccountHandler);
            }

            static void Withdraw(Bank<Account> bank)
            {
                Console.WriteLine("Укажите сумму для снятия со счета:");

                var sum = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Введите Id счета: ");
                var id = Convert.ToInt32(Console.ReadLine());

                bank.Withdraw(sum, id);
            }

            static void Put(Bank<Account> bank)
            {
                Console.WriteLine("Укажите сумму, чтобы положить на счет:");

                var sum = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Укажите Id счета: ");
                var id = Convert.ToInt32(Console.ReadLine());

                bank.Put(sum, id);
            }

            static void CloseAccount(Bank<Account> bank)
            {
                Console.WriteLine("Укажите Id счета, который хотите закрыть: ");
                var id = Convert.ToInt32(Console.ReadLine());

                bank.Close(id);
            }

            #region Обработчики событий
            static void OpenAccountHandler(object sender, AccountEventArgs e)
            {
                Console.WriteLine(e.Message);
            }

            static void AddSumHandler(object sender, AccountEventArgs e)
            {
                Console.WriteLine(e.Message);
            }

            static void WithdrawSumHandler(object sender, AccountEventArgs e)
            {
                Console.WriteLine(e.Message);
                if (e.Sum > 0)
                    Console.WriteLine("Идем тратить деньги");
            }

            static void CloseAccountHandler(object sender, AccountEventArgs e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

        }
    }
}
