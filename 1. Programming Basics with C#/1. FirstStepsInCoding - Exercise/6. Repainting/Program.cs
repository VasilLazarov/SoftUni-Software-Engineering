using System;

namespace _6._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int thinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double bags = 0.40;
            double moneyForNylon = (nylon + 2) * 1.50;
            double moneyForPaint = (paint + (paint * 0.1)) * 14.50;
            double moneyForThinner = thinner * 5.00;
            double moneyForAllMaterials = bags + moneyForNylon + moneyForPaint + moneyForThinner;
            double moneyForMasters = (moneyForAllMaterials * 0.3) * hours;
            double totalPrice = moneyForAllMaterials + moneyForMasters;
            Console.WriteLine(totalPrice);
        }
    }
}
