using System;

namespace a21._World_Snooker_Championship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int numOfTickets = int.Parse(Console.ReadLine());
            char photo = char.Parse(Console.ReadLine());
            double totalPrice = 0;
            switch (stage)
            {
                case "Quarter final":
                    switch (ticketType)
                    {
                        case "Standard":
                            totalPrice = numOfTickets * 55.50;
                            break;
                        case "Premium":
                            totalPrice = numOfTickets * 105.20;
                            break;
                        case "VIP":
                            totalPrice = numOfTickets * 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (ticketType)
                    {
                        case "Standard":
                            totalPrice = numOfTickets * 75.88;
                            break;
                        case "Premium":
                            totalPrice = numOfTickets * 125.22;
                            break;
                        case "VIP":
                            totalPrice = numOfTickets * 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (ticketType)
                    {
                        case "Standard":
                            totalPrice = numOfTickets * 110.10;
                            break;
                        case "Premium":
                            totalPrice = numOfTickets * 160.66;
                            break;
                        case "VIP":
                            totalPrice = numOfTickets * 400.00;
                            break;
                    }
                    break;
                
            }

            if (totalPrice > 4000)
            {
                totalPrice -= totalPrice * 0.25;
            }
            else if (totalPrice > 2500 && totalPrice <= 4000)
            {
                totalPrice -= totalPrice * 0.10;
                if (photo == 'Y')
                {
                    totalPrice += numOfTickets * 40;
                }
            }
            else if (totalPrice <= 2500)
            {
                if (photo == 'Y')
                {
                    totalPrice += numOfTickets * 40;
                }
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
