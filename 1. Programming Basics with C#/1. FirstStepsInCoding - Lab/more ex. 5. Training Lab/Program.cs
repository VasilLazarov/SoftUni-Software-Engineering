using System;

namespace more_ex._5._Training_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double residueW = (w * 100) % 120;
            double residueH = ((h-1) *100) % 70;
            double usedW = (w*100) - residueW;
            double usedH = ((h-1)*100) - residueH;
            double numberOfRows = usedW / 120;
            double numberOfDesksPerRow = usedH / 70;
            double numberOfSeats = (numberOfRows * numberOfDesksPerRow) - 3;
            Console.WriteLine(numberOfSeats);
        }
    }
}
