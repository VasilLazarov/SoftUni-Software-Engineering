using System;

namespace _01._First_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pricePr = double.Parse(Console.ReadLine());
            double priceVideo = double.Parse(Console.ReadLine());
            double priceForRM = double.Parse(Console.ReadLine());
            int numberRM = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            pricePr -= pricePr * percent;
            priceVideo -= priceVideo * percent;
            double totalPrice = (pricePr + priceVideo + numberRM * priceForRM) * 1.57;
            Console.WriteLine($"Money needed - {totalPrice:F2} leva.");

        }
    }
}