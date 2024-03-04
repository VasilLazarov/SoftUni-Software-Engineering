using System;

namespace more_ex._5._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string placeToStay = "";
            string place = "";
            double price = 0;
            if (budget <= 1000)
            {
                placeToStay = "Camp";
                switch (season)
                {
                    case "Summer":
                        place = "Alaska";
                        price = budget * 0.65;
                        break;
                    case "Winter":
                        place = "Morocco";
                        price = budget * 0.45;
                        break;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                placeToStay = "Hut";
                switch (season)
                {
                    case "Summer":
                        place = "Alaska";
                        price = budget * 0.80;
                        break;
                    case "Winter":
                        place = "Morocco";
                        price = budget * 0.60;
                        break;
                }
            }
            else if (budget > 3000)
            {
                placeToStay = "Hotel";
                switch (season)
                {
                    case "Summer":
                        place = "Alaska";
                        price = budget * 0.90;
                        break;
                    case "Winter":
                        place = "Morocco";
                        price = budget * 0.90;
                        break;
                }
            }
            Console.WriteLine($"{place} - {placeToStay} - {price:f2}");
        }
    }
}
