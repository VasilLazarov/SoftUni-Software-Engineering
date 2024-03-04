using System;

namespace more_ex._6._Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceOfSkumriq = double.Parse(Console.ReadLine());
            double priceOfCaca = double.Parse(Console.ReadLine());
            double kgPalamud = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMidi = double.Parse(Console.ReadLine());
            double priceOfPalamud = priceOfSkumriq + (priceOfSkumriq * 0.6);
            double priceOfSafrid = priceOfCaca + (priceOfCaca * 0.8);
            double neededMoney = (kgPalamud*priceOfPalamud)+(kgSafrid*priceOfSafrid)+(kgMidi*7.5);
            Console.WriteLine($"{neededMoney:f2}");
        }
    }
}
