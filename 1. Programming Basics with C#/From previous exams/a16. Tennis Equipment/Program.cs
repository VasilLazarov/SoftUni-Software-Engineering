using System;

namespace a16._Tennis_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double racketPrice = double.Parse(Console.ReadLine());
            int numOfRackets = int.Parse(Console.ReadLine());
            int numOfSneakers = int.Parse(Console.ReadLine());
            double sneakersPrice = racketPrice / 6;
            double moneyForRackAndSn = racketPrice * numOfRackets + sneakersPrice * numOfSneakers;
            double moneyForOther = moneyForRackAndSn * 0.20;
            double totalPrice = moneyForOther + moneyForRackAndSn;
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(totalPrice/8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(totalPrice * 7 / 8)}");
        }
    }
}
