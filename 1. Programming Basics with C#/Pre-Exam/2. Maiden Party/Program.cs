using System;

namespace _2._Maiden_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            int numL = int.Parse(Console.ReadLine());
            int numR = int.Parse(Console.ReadLine());
            int numKeyRings = int.Parse(Console.ReadLine());
            int numC = int.Parse(Console.ReadLine());
            int numGL = int.Parse(Console.ReadLine());
            int numOfAll = numL + numR + numKeyRings + numC + numGL;
            double totalPrice = numL * 0.60 + numR * 7.20 + numKeyRings * 3.60 + numC * 18.20 + numGL * 22;
            if (numOfAll >= 25)
            {
                totalPrice -= totalPrice * 0.35;
            }
            totalPrice -= totalPrice * 0.10;
            if(totalPrice >= price)
            {
                Console.WriteLine($"Yes! {totalPrice - price:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {price - totalPrice:f2} lv needed.");
            }
        }
    }
}
