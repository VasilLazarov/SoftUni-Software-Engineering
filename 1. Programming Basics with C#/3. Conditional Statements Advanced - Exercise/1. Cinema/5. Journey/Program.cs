using System;

namespace _5._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = "";
            double price = 0;

            if (budget <= 100)
            {
                switch (season)
                {
                    case "summer":
                        place = "Camp";
                        price = budget * 0.30;
                        break;
                    case "winter":
                        place = "Hotel";
                        price = budget * 0.70;
                        break;
                }
                Console.WriteLine("Somewhere in Bulgaria");
            }
            else if (budget > 100 && budget <= 1000)
            {
                switch (season)
                {
                    case "summer":
                        place = "Camp";
                        price = budget * 0.40;
                        break;
                    case "winter":
                        place = "Hotel";
                        price = budget * 0.80;
                        break;
                }
                Console.WriteLine("Somewhere in Balkans");
            }
            else if(budget > 1000)
            {
                switch (season)
                {
                    case "summer":
                    case "winter":
                        place = "Hotel";
                        price = budget * 0.90;
                        break;
                }
                Console.WriteLine("Somewhere in Europe");
            }
            Console.WriteLine($"{place} - {Math.Round(price, 2):f2}");
        }
    }
}
