using System;

namespace _4._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numOfFishermen = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            int rentalPrice = 0;
            switch (season)
            {
                case "Spring":
                    rentalPrice = 3000;
                    break;
                case "Summer":
                    rentalPrice = 4200;
                    break;
                case "Autumn":
                    rentalPrice = 4200;
                    break;
                case "Winter":
                    rentalPrice = 2600;
                    break;
            }

            totalPrice = rentalPrice;
            if(numOfFishermen <= 6)
            {
                totalPrice -= totalPrice * 0.10;
            }
            else if(numOfFishermen >= 7 && numOfFishermen <= 11)
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if(numOfFishermen > 11)
            {
                totalPrice -= totalPrice * 0.25;
            }

            if(numOfFishermen % 2 == 0 && season != "Autumn")
            {
                totalPrice -= totalPrice * 0.05;
            }

            if(budget >= totalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva.");
            }
        }
    }
}
