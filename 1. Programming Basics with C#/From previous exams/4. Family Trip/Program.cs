using System;

namespace _4._Family_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numOfNights = int.Parse(Console.ReadLine());
            double priceForOneNight = double.Parse(Console.ReadLine());
            int percentageAdditionalCosts = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            if(numOfNights > 7)
            {
                priceForOneNight -= priceForOneNight * 0.05;

            }
            totalPrice = numOfNights * priceForOneNight + budget *(percentageAdditionalCosts/100.0);
            if(budget >= totalPrice)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - totalPrice:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{totalPrice - budget:f2} leva needed.");
            }
        }
    }
}
