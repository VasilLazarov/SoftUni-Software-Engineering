using System;

namespace _6._Travel_Agency
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
            if(days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            if(days > 7)
            {
                paymentDays = days - 1;
            }
            else
            {
                paymentDays=days;
            }
            if(nameOfTheCity == "Bansko" || nameOfTheCity == "Borovets")
            {
                if(packageType == "noEquipment")
                { 
                        totalPrice = paymentDays * 80.00;
                        if(vipDiscount == "yes")
                        {
                            totalPrice -= totalPrice * 0.05;
                        }    
                }
                else if(packageType == "withEquipment")
                {
                        totalPrice = paymentDays * 100.00;
                    if (vipDiscount == "yes")
                    {
                        totalPrice -= totalPrice * 0.10;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                    return;
                }
            }
            else if(nameOfTheCity == "Varna" || nameOfTheCity == "Burgas")
            {
                if (packageType == "noBreakfast")
                {
                    totalPrice = paymentDays * 100.00;
                    if (vipDiscount == "yes")
                    {
                        totalPrice -= totalPrice * 0.07;
                    }
                }
                else if (packageType == "withBreakfast")
                {
                    totalPrice = paymentDays * 130.00;
                    if (vipDiscount == "yes")
                    {
                        totalPrice -= totalPrice * 0.12;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Invalid input!");
                return;
            }
            Console.WriteLine($"The price is {totalPrice:f2}lv! Have a nice time!");
        }
    }
}
