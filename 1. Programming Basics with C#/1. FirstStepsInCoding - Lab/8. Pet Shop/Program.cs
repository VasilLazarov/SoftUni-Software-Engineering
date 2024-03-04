using System;

namespace _8._Pet_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFoodNum = int.Parse(Console.ReadLine());
            int catFoodNum = int.Parse(Console.ReadLine());
            double price = (dogFoodNum * 2.50) + (catFoodNum * 4);
            Console.WriteLine($"{price} lv.");
        }
    }
}
