using System;

namespace _3._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sumDeposit = double.Parse(Console.ReadLine());
            int term = int.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine());
            double sumWithLihva = sumDeposit + (term * ((sumDeposit * (rate/100)) / 12));
            Console.WriteLine(sumWithLihva);
        }
    }
}
