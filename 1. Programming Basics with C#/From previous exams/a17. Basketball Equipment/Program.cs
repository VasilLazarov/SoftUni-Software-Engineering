using System;

namespace a17._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualFee = int.Parse(Console.ReadLine());
            double sneakersPrice = annualFee * 0.60;
            double teamPrice = sneakersPrice * 0.80;
            double ballPrice = teamPrice * 0.25;
            double accessories = ballPrice * 0.20;
            double totalPrice = annualFee + sneakersPrice + teamPrice + ballPrice + accessories;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
