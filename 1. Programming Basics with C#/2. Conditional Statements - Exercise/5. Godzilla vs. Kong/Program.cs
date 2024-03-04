using System;

namespace _5._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int peoples = int.Parse(Console.ReadLine());
            double priceForClothesForOnePeople = double.Parse(Console.ReadLine());
            double decor = budget * 0.10;
            double priceForAllClothes = peoples * priceForClothesForOnePeople;
            if(peoples > 150)
            {
                priceForAllClothes -= priceForAllClothes * 0.10;
            }
            double priceForMovie = decor + priceForAllClothes;
            if(priceForMovie > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {priceForMovie - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - priceForMovie:f2} leva left.");
            }

        }
    }
}
