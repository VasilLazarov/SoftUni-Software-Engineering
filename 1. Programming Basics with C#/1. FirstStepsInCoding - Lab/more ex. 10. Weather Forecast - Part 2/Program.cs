using System;

namespace more_ex._10._Weather_Forecast___Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double t = double.Parse(Console.ReadLine());
            if (t >= 26 && t <= 35)
            {
                Console.WriteLine("Hot");
            }
            else if (t >= 20.1 && t <= 25.9)
            {
                Console.WriteLine("Warm");
            }
            else if (t>=15 && t <= 20)
            {
                Console.WriteLine("Mild");
            }
            else if (t>=12 && t <= 14.9)
            {
                Console.WriteLine("Cool");
            }
            else if (t >= 5 && t <= 11.9)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
        
    }
}
