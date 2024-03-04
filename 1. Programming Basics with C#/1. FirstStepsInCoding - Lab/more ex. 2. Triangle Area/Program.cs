using System;

namespace more_ex._2._Triangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double s = (a*h) / 2;
            Console.WriteLine($"{s:f2}");
        }
    }
}
