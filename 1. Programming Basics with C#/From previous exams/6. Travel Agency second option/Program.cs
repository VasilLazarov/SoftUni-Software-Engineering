using System;

namespace _6._Travel_Agency_second_option
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfTheCity = Console.ReadLine();
            string packageType = Console.ReadLine();
            string vipDiscount = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            int paymentDays = 0;
            bool invalidInputs = false;
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            if (days > 7)
            {
                paymentDays = days - 1;
            }
            else
            {
                paymentDays = days;
            }
            if (nameOfTheCity == "Bansko" || nameOfTheCity == "Borovets")
            {
                switch (packageType)
                {
                    case "noEquipment":
                        totalPrice = paymentDays * 80.00;
                        if (vipDiscount == "yes")
                        {
                            totalPrice -= totalPrice * 0.05;
                        }
                        break;
                    case "withEquipment":
                        totalPrice = paymentDays * 100.00;
                        if (vipDiscount == "yes")
                        {
                            totalPrice -= totalPrice * 0.10;
                        }
                        break;
                    default:
                        invalidInputs = true;
                        break;
                }
            }
            else if (nameOfTheCity == "Varna" || nameOfTheCity == "Burgas")
            {
                switch (packageType)
                {
                    case "noBreakfast":
                        totalPrice = paymentDays * 100.00;
                        if (vipDiscount == "yes")
                        {
                            totalPrice -= totalPrice * 0.07;
                        }
                        break;
                    case "withBreakfast":
                        totalPrice = paymentDays * 130.00;
                        if (vipDiscount == "yes")
                        {
                            totalPrice -= totalPrice * 0.12;
                        }
                        break;
                    default:
                        invalidInputs = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid input!");
                return;
            }
            if (invalidInputs == false)
            {
                Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
            }
            else
            {
                Console.WriteLine($"Invalid input!");
            }
        }
    }
}
        
