using System;

namespace a25._Film_Premiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string package = Console.ReadLine();
            int numOfTickets = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            switch (name)
            {
                case "John Wick":
                    switch (package)
                    {
                        case "Drink":
                            totalPrice = numOfTickets * 12;
                            break;
                        case "Popcorn":
                            totalPrice = numOfTickets * 15;
                            break;
                        case "Menu":
                            totalPrice = numOfTickets * 19;
                            break;
                    }
                    break;
                case "Star Wars":
                    switch (package)
                    {
                        case "Drink":
                            totalPrice = numOfTickets * 18;
                            if(numOfTickets >= 4)
                            {
                                totalPrice -= totalPrice * 0.30;
                            }
                            break;
                        case "Popcorn":
                            totalPrice = numOfTickets * 25;
                            if (numOfTickets >= 4)
                            {
                                totalPrice -= totalPrice * 0.30;
                            }
                            break;
                        case "Menu":
                            totalPrice = numOfTickets * 30;
                            if (numOfTickets >= 4)
                            {
                                totalPrice -= totalPrice * 0.30;
                            }
                            break;
                    }
                    break;
                case "Jumanji":
                    switch (package)
                    {
                        case "Drink":
                            totalPrice = numOfTickets * 9;
                            if (numOfTickets == 2)
                            {
                                totalPrice -= totalPrice * 0.15;
                            }
                            break;
                        case "Popcorn":
                            totalPrice = numOfTickets * 11;

                            if (numOfTickets == 2)
                            {
                                totalPrice -= totalPrice * 0.15;
                            }
                            break;
                        case "Menu":
                            totalPrice = numOfTickets * 14;
                            if (numOfTickets == 2)
                            {
                                totalPrice -= totalPrice * 0.15;
                            }
                            break;
                    }
                    break;
            }
            totalPrice = Math.Round(totalPrice, 2);
            Console.WriteLine($"Your bill is {totalPrice:f2} leva.");
        }
    }
}
