using System;

namespace _3._Santas_Holiday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string PN = Console.ReadLine();
            int nights = days - 1;
            double totalPrice = 0;
            if(days < 10)
            {
                switch (typeRoom)
                {
                    case "room for one person":
                        totalPrice = nights * 18.00;
                        break;
                    case "apartment":
                        totalPrice = nights * 25.00;
                        totalPrice -= totalPrice * 0.30;
                        break;
                    case "president apartment":
                        totalPrice = nights * 35.00;
                        totalPrice -= totalPrice * 0.10;
                        break;
                }
            }
            else if(days >= 10 && days <= 15)
            {
                switch (typeRoom)
                {
                    case "room for one person":
                        totalPrice = nights * 18.00;
                        break;
                    case "apartment":
                        totalPrice = nights * 25.00;
                        totalPrice -= totalPrice * 0.35;
                        break;
                    case "president apartment":
                        totalPrice = nights * 35.00;
                        totalPrice -= totalPrice * 0.15;
                        break;
                }
            }
            else if(days > 15)
            {
                switch (typeRoom)
                {
                    case "room for one person":
                        totalPrice = nights * 18.00;
                        break;
                    case "apartment":
                        totalPrice = nights * 25.00;
                        totalPrice -= totalPrice * 0.50;
                        break;
                    case "president apartment":
                        totalPrice = nights * 35.00;
                        totalPrice -= totalPrice * 0.20;
                        break;
                }
            }
            if(PN == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else
            {
                totalPrice -= totalPrice * 0.10;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
