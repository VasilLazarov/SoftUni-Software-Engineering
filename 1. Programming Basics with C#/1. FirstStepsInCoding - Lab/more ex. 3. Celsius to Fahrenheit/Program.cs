using System;

namespace more_ex._3._Celsius_to_Fahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degreesCelsius = double.Parse(Console.ReadLine());
            double degreesFarenhait = (degreesCelsius * 1.8) + 32;
            Console.WriteLine($"{degreesFarenhait:f2}");
        }
    }
}
