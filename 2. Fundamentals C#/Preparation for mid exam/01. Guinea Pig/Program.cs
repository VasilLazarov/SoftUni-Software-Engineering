using System;

namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal quantityFood = decimal.Parse(Console.ReadLine());
            decimal quantityHay = decimal.Parse(Console.ReadLine());
            decimal quantityCover = decimal.Parse(Console.ReadLine());
            decimal pigsWeight = decimal.Parse(Console.ReadLine());

            for (int i = 1; i <= 30; i++)
            {
                quantityFood -= 0.3m;
                if(i % 2 == 0)
                {
                    quantityHay -= 0.05m * quantityFood;
                }
                if(i % 3 == 0)
                {
                    quantityCover -= pigsWeight / 3;
                }
                if(quantityFood <= 0 || quantityCover <= 0 || quantityHay <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }
            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityFood:f2}, Hay: {quantityHay:f2}, Cover: {quantityCover:f2}.");
        }
    }
}
