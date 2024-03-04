using System;

namespace a14._Easter_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numOfNights = int.Parse(Console.ReadLine());
            int totalPrice = 0;
            switch (dates)
            {
                case "21-23":
                    switch (destination)
                    {
                        case "France":
                            totalPrice = numOfNights * 30;
                            break;
                        case "Italy":
                            totalPrice = numOfNights * 28;
                            break;
                        case "Germany":
                            totalPrice = numOfNights * 32;
                            break;
                    }
                    break;
                case "24-27":
                    switch (destination)
                    {
                        case "France":
                            totalPrice = numOfNights * 35;
                            break;
                        case "Italy":
                            totalPrice = numOfNights * 32;
                            break;
                        case "Germany":
                            totalPrice = numOfNights * 37;
                            break;
                    }
                    break;
                case "28-31":
                    switch (destination)
                    {
                        case "France":
                            totalPrice = numOfNights * 40;
                            break;
                        case "Italy":
                            totalPrice = numOfNights * 39;
                            break;
                        case "Germany":
                            totalPrice = numOfNights * 43;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"Easter trip to {destination} : {totalPrice:f2} leva.");
        }
    }
}
