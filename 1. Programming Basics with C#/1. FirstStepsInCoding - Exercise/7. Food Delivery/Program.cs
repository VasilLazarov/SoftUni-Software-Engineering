using System;

namespace _7._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int vegetarianMenus = int.Parse(Console.ReadLine());
            double priceOfAllMenus = (chickenMenus * 10.35) + (fishMenus * 12.40) + (vegetarianMenus * 8.15);
            double priceOfDesserts = priceOfAllMenus * 0.2;
            double deliveryPrice = 2.50;
            double totalPrice = priceOfAllMenus + priceOfDesserts + deliveryPrice;
            Console.WriteLine(totalPrice);
        }
    }
}
