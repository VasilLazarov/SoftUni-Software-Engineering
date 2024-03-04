using System;

namespace more_ex._6._Truck_Driver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = int.Parse(Console.ReadLine());
            double profit = 0;
            if(kmPerMonth <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        profit = kmPerMonth * 0.75 * 4;
                        break;
                    case "Summer":
                        profit = kmPerMonth * 0.90 * 4;
                        break;
                    case "Winter":
                        profit = kmPerMonth * 1.05 * 4;
                        break;
                }
            }
            else if(kmPerMonth > 5000 && kmPerMonth <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        profit = kmPerMonth * 0.95 * 4;
                        break;
                    case "Summer":
                        profit = kmPerMonth * 1.10 * 4;
                        break;
                    case "Winter":
                        profit = kmPerMonth * 1.25 * 4;
                        break;
                }
            }
            else if(kmPerMonth > 10000 && kmPerMonth <= 20000)
            {
                profit = kmPerMonth * 1.45 * 4;
            }

            profit -= profit * 0.10;
            Console.WriteLine($"{profit:f2}");
        }
    }
}
