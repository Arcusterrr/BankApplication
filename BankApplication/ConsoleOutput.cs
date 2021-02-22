using System;
using BankLibrary.Infrastructure.Output;

namespace BankApplication
{
    public class ConsoleOutput: IOutput
    {
        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}