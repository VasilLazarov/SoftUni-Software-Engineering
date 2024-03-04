using System;

namespace more_ex._3._Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapesPerSqMeter = double.Parse(Console.ReadLine());
            int requiredLiterOfWine = int.Parse(Console.ReadLine());
            int numberOfWorkers = int.Parse(Console.ReadLine());
            double areaForWine = area * (40 / 100.0);
            double litersWineFromAreaForWine = (areaForWine * grapesPerSqMeter) / 2.5;

            if(litersWineFromAreaForWine < requiredLiterOfWine)
            {
                double notEnoughWineLiters = requiredLiterOfWine - litersWineFromAreaForWine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(notEnoughWineLiters)} liters wine needed.");
            }
            else if (litersWineFromAreaForWine >= requiredLiterOfWine)
            {
                double remainingWine = litersWineFromAreaForWine - requiredLiterOfWine;
                double litersPerWorker = remainingWine / numberOfWorkers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(litersWineFromAreaForWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(remainingWine)} liters left -> {Math.Ceiling(litersPerWorker)} liters per person.");

            }
        }
    }
}
