using System;

namespace _5._Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = 0;
            double money = 0;
            double spMoney = 0;
            while (name != "End")
            {
                budget = double.Parse(Console.ReadLine());
                while(money < budget)
                {
                    spMoney = double.Parse(Console.ReadLine());
                    money += spMoney;
                }
                Console.WriteLine($"Going to {name}!");
                money = 0;
                name = Console.ReadLine();
            }
        }
    }
}
