using System;

namespace more_ex._4._Vegetable_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int kVegetables = int.Parse(Console.ReadLine());
            int kFruits = int.Parse(Console.ReadLine());
            double price = ((priceVegetables * kVegetables) + (priceFruits* kFruits))/1.94;
            Console.WriteLine($"{price:f2}");
        }
    }
}
