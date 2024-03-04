using System;

namespace _01._Match_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numberPeople = int.Parse(Console.ReadLine());
            double priceForTransport = 0;
            double ticketPrice = 0;
            if (category == "VIP")
            {
                ticketPrice = numberPeople * 499.99;
            }
            else if (category == "Normal")
            {
                ticketPrice = numberPeople * 249.99;
            }


            if (numberPeople >= 1 && numberPeople <= 4)
            {
                priceForTransport = budget * 0.75;
            }
            else if (numberPeople >= 5 && numberPeople <= 9)
            {
                priceForTransport = budget * 0.60;
            }
            else if (numberPeople >= 10 && numberPeople <= 24)
            {
                priceForTransport = budget * 0.50;
            }
            else if (numberPeople >= 25 && numberPeople <= 49)
            {
                priceForTransport = budget * 0.40;
            }
            else if (numberPeople >= 50)
            {
                priceForTransport = budget * 0.25;
            }
            double totalPrice = priceForTransport + ticketPrice;
            if (budget >= totalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - totalPrice:F2} leva left.");

            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:F2} leva.");
            }
        }
    }
}
