using System;

namespace a12._Easter_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfGuests = int.Parse(Console.ReadLine());
            double priceForOneGuest = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double cakePrice = budget * 0.10;
            if (numOfGuests > 20)
            {
                priceForOneGuest -= priceForOneGuest * 0.25;
            }
            else if(numOfGuests <= 20 && numOfGuests > 15)
            {
                priceForOneGuest -= priceForOneGuest * 0.20;
            }
            else if(numOfGuests <= 15 && numOfGuests >= 10)
            {
                priceForOneGuest -= priceForOneGuest * 0.15;
            }

            double totalPrice = numOfGuests * priceForOneGuest + cakePrice;
            if(budget >= totalPrice)
            {
                Console.WriteLine($"It is party time! {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {totalPrice - budget:f2} leva needed.");
            }

        }
    }
}
