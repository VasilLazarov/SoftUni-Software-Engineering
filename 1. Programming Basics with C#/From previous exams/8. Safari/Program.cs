using System;

namespace _8._Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelLiters = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            int priceForGuide = 100;
            double totalPrice = fuelLiters * 2.10 + priceForGuide;
            if(day == "Saturday")
            {
                totalPrice -= totalPrice * 0.10;
            }
            else if(day == "Sunday")
            {
                totalPrice -= totalPrice * 0.20;
            }
            if(budget >= totalPrice)
            {
                Console.WriteLine($"Safari time! Money left: {budget - totalPrice:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {totalPrice - budget:f2} lv.");
            }
        }
    }
}
