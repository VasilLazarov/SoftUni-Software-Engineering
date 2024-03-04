using System;

namespace more_ex._7._House_Painting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double greenArea = ((2*(x*x))+(2*(x*y)))-((1.2*2)+(2*(1.5*1.5)));
            double redArea = ((2 * ((x * h)/2)) + (2 * (x * y)));
            double needGreenPaint = greenArea / 3.4;
            double needRedPaint = redArea / 4.3;
            
            Console.WriteLine($"{needGreenPaint:f2}");
            Console.WriteLine($"{needRedPaint:f2}");
        }
    }
}
