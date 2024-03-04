using System;

namespace more_ex._6._Flower_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfMagnolias = int.Parse(Console.ReadLine());
            int numOfHyacinths = int.Parse(Console.ReadLine());
            int numOfRoses = int.Parse(Console.ReadLine());
            int numOfCacti = int.Parse(Console.ReadLine());
            double priceOfTheGift = double.Parse(Console.ReadLine());
            double moneyFromAnOrder = numOfMagnolias * 3.25 + numOfHyacinths * 4.0 + numOfRoses * 3.50 + numOfCacti * 8.0;
            double pureProfit = moneyFromAnOrder - (moneyFromAnOrder * 0.05);
            if(pureProfit >= priceOfTheGift)
            {
                double residueMoney = pureProfit - priceOfTheGift;
                Console.WriteLine($"She is left with {Math.Floor(residueMoney)} leva.");
            }
            else if(pureProfit < priceOfTheGift)
            {
                double insufficientMoney = Math.Abs(pureProfit - priceOfTheGift);
                Console.WriteLine($"She will have to borrow {Math.Ceiling(insufficientMoney)} leva.");
            }
        }
    }
}
