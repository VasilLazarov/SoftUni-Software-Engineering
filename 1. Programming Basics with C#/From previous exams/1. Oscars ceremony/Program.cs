using System;

namespace _1._Oscars_ceremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceForTheHall = int.Parse(Console.ReadLine());
            double priceForStatuettes = priceForTheHall - priceForTheHall * 0.3;
            double priceForCatering = priceForStatuettes - priceForStatuettes * 0.15;
            double priceForSoundSystem = priceForCatering / 2.0;
            double total = priceForTheHall + priceForStatuettes + priceForCatering + priceForSoundSystem;

            Console.WriteLine($"{total:f2}");
        }
    }
}
