using System;

namespace more_ex._1._Match_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numOfPeoples = int.Parse(Console.ReadLine());
            double transportPrice = 0;
            double priceForTickets = 0;
            if(numOfPeoples >= 1 && numOfPeoples <= 4)
            {
                transportPrice = budget * 0.75;
            }
            else if(numOfPeoples >= 5 && numOfPeoples <= 9)
            {
                transportPrice = budget * 0.60;
            }
            else if(numOfPeoples >= 10 && numOfPeoples <= 24)
            {
                transportPrice = budget * 0.50;
            }
            else if(numOfPeoples >= 25 && numOfPeoples <= 49)
            {
                transportPrice = budget * 0.40;
            }
            else if(numOfPeoples >= 50)
            {
                transportPrice = budget * 0.25;
            }

            if(category == "VIP")
            {
                priceForTickets = numOfPeoples * 499.99;
            }
            else if(category == "Normal")
            {
                priceForTickets = numOfPeoples * 249.99;
            }

            double totalPrice = transportPrice + priceForTickets;

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
