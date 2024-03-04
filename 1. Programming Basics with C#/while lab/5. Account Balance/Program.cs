using System;

namespace _5._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string money = Console.ReadLine();
            double totalMoney = 0;
            double moneyPlus = 0;
            while(money != "NoMoreMoney")
            {
                moneyPlus = double.Parse(money);
                if (moneyPlus < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                totalMoney += moneyPlus;
                Console.WriteLine($"Increase: {moneyPlus:f2}");
                money = Console.ReadLine();
            }
            Console.WriteLine($"Total: {totalMoney:f2}");
        }
    }
}
