using System;

namespace a28._Agency_Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numOfTicketsForAdults = int.Parse(Console.ReadLine());
            int numOfTicketsForKids = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double servicePrice = double.Parse(Console.ReadLine());
            double kidsTicketPrice = adultTicketPrice * 0.30;
            int numOfAllTickets = numOfTicketsForKids + numOfTicketsForAdults;
            double totalPrice = numOfTicketsForAdults * adultTicketPrice + numOfTicketsForKids * kidsTicketPrice + numOfAllTickets * servicePrice;
            double profit = totalPrice * 0.20;
            Console.WriteLine($"The profit of your agency from {name} tickets is {profit:f2} lv.");
        }
    }
}
