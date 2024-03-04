using System;

namespace _9._Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string evaluation = Console.ReadLine();
            int overnightStays = days - 1;
            double totalPrice = 0;
            switch (type)
            {
                case "room for one person":
                    totalPrice = overnightStays * 18.00;
                    break;
                case "apartment":
                    totalPrice = overnightStays * 25.00;
                    if (overnightStays < 10)
                    {
                        totalPrice -= totalPrice * 0.30;
                    }
                    else if(overnightStays >= 10 && overnightStays <= 15)
                    {
                        totalPrice -= totalPrice * 0.35;
                    }
                    else if(overnightStays > 15)
                    {
                        totalPrice -= totalPrice * 0.50;
                    }
                    break;
                case "president apartment":
                    totalPrice = overnightStays * 35.00;
                    if (overnightStays < 10)
                    {
                        totalPrice -= totalPrice * 0.10;
                    }
                    else if (overnightStays >= 10 && overnightStays <= 15)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    else if (overnightStays > 15)
                    {
                        totalPrice -= totalPrice * 0.20;
                    }
                    break;
            }
            if (evaluation == "positive")
            {
                totalPrice += totalPrice * 0.25;
            }
            else if(evaluation == "negative")
            {
                totalPrice -= totalPrice * 0.10;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
