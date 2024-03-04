using System;

namespace _8._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualFee = int.Parse(Console.ReadLine());
            double sneakers = annualFee - (annualFee * 0.4);
            double team = sneakers - (sneakers * 0.2);
            double ball = team * 0.25;
            double accessories = ball * 0.2;
            double totalPrize = annualFee + sneakers + team + ball + accessories;
            Console.WriteLine(totalPrize);
        }
    }
}
