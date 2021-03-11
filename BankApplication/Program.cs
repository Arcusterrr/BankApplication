using System;
using System.Collections.Generic;
using System.Linq;
using BankLibrary.Domain;
using BankLibrary.Infrastructure.AccountStorage;
using BankLibrary.Infrastructure.Output;
using BankLibrary.UseCases.BankCases;

namespace BankApplication
{
    class Program
    {
        private static readonly List<Bank> StartBanks = new List<Bank>
        {
            new Bank("ЮнитБанк")
        };
        private static readonly IOutput Output = new ConsoleOutput();
        
        private static readonly IAccountStorage AccountStorage = new SimpleAccountStorage(StartBanks);
        private static readonly OpenBankAccountUseCase OpenBankAccountUseCase = new OpenBankAccountUseCase(AccountStorage, Output);
        private static readonly CloseBankAccountUseCase CloseBankAccountUseCase = new CloseBankAccountUseCase(AccountStorage, Output);
        private static readonly BankPutUseCase BankPutUseCase = new BankPutUseCase(AccountStorage, Output);
        private static readonly BankWithdrawUseCase BankWithdrawCase = new BankWithdrawUseCase(AccountStorage, Output);
        
        static void Main(string[] args)
        {
            var bank = StartBanks.First();
            
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
        
            void OpenAccount(Bank bank)
            {
                var sum = GetDecimalInput("Укажите сумму для создания счета: ");
                var type = GetIntInput("Выберите тип счета: 1. До востребования 2. Депозит");

                var accountType = type == 2 ? AccountType.Deposit : AccountType.Ordinary;

                OpenBankAccountUseCase.Open(bank, accountType, sum);
            }

            static void Withdraw(Bank bank)
            {
                var sum = GetDecimalInput("Укажите сумму для снятия со счета:");
                var id = GetIntInput("Введите Id счета: ");

                BankWithdrawCase.Withdraw(bank, sum, id);
            }

            static void Put(Bank bank)
            {
                var sum = GetDecimalInput("Укажите сумму, чтобы положить на счет:");
                var id = GetIntInput("Укажите Id счета: ");

                BankPutUseCase.Put(bank, sum, id);
            }

            static void CloseAccount(Bank bank)
            {
                var id = GetIntInput("Укажите Id счета, который хотите закрыть: ");

                CloseBankAccountUseCase.Close(bank, id);
            }
        }

        private static decimal GetDecimalInput(string message)
        {
            Console.WriteLine(message);
            return Convert.ToDecimal(Console.ReadLine());
        }

        private static int GetIntInput(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
