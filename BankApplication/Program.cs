using System;
using BankLibrary;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank<Account> bank = new Bank<Account>("ЮнитБанк");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Открыть счет \t 2. Вывести средства  \t 3. Добавить на счет");
                Console.WriteLine("4. Закрыть счет \t 5. Пропустить день \t 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта: ");
                Console.ForegroundColor = color;

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            
                            
                    }
                }

            }
        
            
            public void OpenAccount(Bank<Account> bank)
            {
                Console.WriteLine("Укажите сумму для создания счета: ");

                decimal sum = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Выберите тип счета: 1. До востребования 2. Депозит");
                AccountType accountType;

            }

        }
    }
}
