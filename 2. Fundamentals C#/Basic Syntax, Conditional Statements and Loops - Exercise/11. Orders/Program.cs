using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double pricePerCapsile = 0;
            int days = 0;
            int capsulesCount = 0;
            double price = 0;
            double totalPrice = 0;
            while(n > 0)
            {
                n--;
                pricePerCapsile = double.Parse(Console.ReadLine());
                days = int.Parse(Console.ReadLine());
                capsulesCount = int.Parse(Console.ReadLine());
                price = pricePerCapsile * days * capsulesCount;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
