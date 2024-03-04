using System;

namespace _4._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            int numberOfToys = puzzle + dolls + bears + minions + trucks;
            double moneyFromOrder = puzzle * 2.60 + dolls * 3 + bears * 4.10 + minions * 8.20 + trucks * 2;
            if(numberOfToys >= 50)
            {
                moneyFromOrder -= moneyFromOrder * 0.25;
            }
            double profit = moneyFromOrder - moneyFromOrder * 0.10;
            if(profit >= excursionPrice)
            {
                Console.WriteLine($"Yes! {profit - excursionPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {excursionPrice - profit:f2} lv needed.");
            }
        }
    }
}
