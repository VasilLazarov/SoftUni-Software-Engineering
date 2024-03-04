using System;

namespace _7._Fruit_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasQuantity = double.Parse(Console.ReadLine());
            double orangesQuantity = double.Parse(Console.ReadLine());
            double raspberriesQuantity = double.Parse(Console.ReadLine());
            double strawberriesQuantity = double.Parse(Console.ReadLine());
            double raspberriesPrice = strawberriesPrice / 2;
            double orangesPrice = raspberriesPrice - raspberriesPrice * 0.40;
            double bananasPrice = raspberriesPrice - raspberriesPrice * 0.80;
            double totalPrice = strawberriesPrice * strawberriesQuantity + orangesPrice * orangesQuantity + raspberriesPrice * raspberriesQuantity + bananasPrice * bananasQuantity;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
