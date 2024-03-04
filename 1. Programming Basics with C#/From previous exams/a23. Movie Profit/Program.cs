using System;

namespace a23._Movie_Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int numOfDays =int.Parse(Console.ReadLine());
            int numOfTickets = int.Parse(Console.ReadLine());
            double priceForTicket = double.Parse(Console.ReadLine());
            int percentageForCinema = int.Parse(Console.ReadLine());
            double totalPrice = numOfDays * numOfTickets * priceForTicket;
            double profit = totalPrice - totalPrice * percentageForCinema / 100;
            Console.WriteLine($"The profit from the movie {filmName} is {profit:f2} lv.");
        }
    }
}
