using System;

namespace a26._Movie_Destination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int numOfDays = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            if(destination == "Dubai")
            {
                switch (season)
                {
                    case "Winter":
                        totalPrice = numOfDays * 45000.00;
                        break;
                    case "Summer":
                        totalPrice = numOfDays * 40000.00;
                        break;
                }
                totalPrice -= totalPrice * 0.30;
            }
            else if(destination == "Sofia")
            {
                switch (season)
                {
                    case "Winter":
                        totalPrice = numOfDays * 17000.00;
                        break;
                    case "Summer":
                        totalPrice = numOfDays * 12500.00;
                        break;
                }
                totalPrice += totalPrice * 0.25;
            }
            else if(destination == "London")
            {
                switch (season)
                {
                    case "Winter":
                        totalPrice = numOfDays * 24000.00;
                        break;
                    case "Summer":
                        totalPrice = numOfDays * 20250.00;
                        break;
                }
            }

            if(budget > totalPrice)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {Math.Round(budget - totalPrice, 2):f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {Math.Round(totalPrice - budget, 2):f2} leva more!");
            }
        }
    }
}
