using System;

namespace _7._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());
            int priceForVideoCard = 250;
            double priceForCpu = (videoCards * priceForVideoCard) * 0.35;
            double priceForRam = (videoCards * priceForVideoCard) * 0.10;
            double price = videoCards * priceForVideoCard + cpu * priceForCpu + ram * priceForRam;
            if (videoCards > cpu)
            {
                price -= price * 0.15;
            }

            if(budget >= price)
            {
                Console.WriteLine($"You have {budget - price:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva more!");
            }
        }
    }
}
