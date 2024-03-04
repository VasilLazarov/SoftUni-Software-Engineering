using System;

namespace _5._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfPenPacks = int.Parse(Console.ReadLine());
            int numOfMarkerPacks = int.Parse(Console.ReadLine());
            int litersOfDetergent = int.Parse(Console.ReadLine());
            int percentDiscount = int.Parse(Console.ReadLine());
            double priceForPens = numOfPenPacks * 5.80;
            double priceForMarkers = numOfMarkerPacks * 7.20;
            double priceForDetergent = litersOfDetergent * 1.20;
            double priceForAll = priceForPens + priceForMarkers + priceForDetergent;
            double discount = priceForAll * (percentDiscount / 100.0);
            double necessaryMoney = priceForAll - discount;
            Console.WriteLine(necessaryMoney);
        }
    }
}
