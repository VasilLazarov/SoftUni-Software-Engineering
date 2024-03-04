using System;

namespace _9._Yard_Greening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double kvMetri = double.Parse(Console.ReadLine());
            double priceWithoutDiscount = kvMetri * 7.61;
            double discount = priceWithoutDiscount * 0.18;
            double priceWithDiscount = priceWithoutDiscount - discount;
            Console.WriteLine($"The final price is: {priceWithDiscount} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");

        }
    }
}
