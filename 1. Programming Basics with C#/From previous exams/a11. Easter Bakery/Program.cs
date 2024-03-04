using System;

namespace a11._Easter_Bakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourKg = double.Parse(Console.ReadLine());
            double sugarKg = double.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int mayPacks = int.Parse(Console.ReadLine());
            double moneyForFLour = flourPrice * flourKg;
            double moneyForSugar = sugarKg * (flourPrice * 0.75);
            double moneyForEggs = eggs * (flourPrice + flourPrice * 0.10);
            double moneyForMay = mayPacks * ((flourPrice * 0.75) * 0.20);
            double totalPrice = moneyForFLour + moneyForSugar + moneyForEggs + moneyForMay;
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
