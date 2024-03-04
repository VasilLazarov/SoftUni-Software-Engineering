using System;

namespace _07._Fuel_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double litres = double.Parse(Console.ReadLine());
            bool isGreater = litres >= 25;
            switch (fuel)
            {
                case "Diesel":
                    if (isGreater)
                        Console.WriteLine("You have enough diesel.");
                    else
                    {
                        Console.WriteLine("Fill your tank with diesel!");
                    }
                    break;
                case "Gasoline":
                    if (isGreater)
                        Console.WriteLine("You have enough gasoline.");
                    else
                    {
                        Console.WriteLine("Fill your tank with gasoline!");
                    }
                    break;
                case "Gas":
                    if (isGreater)
                        Console.WriteLine("You have enough gas.");
                    else
                    {
                        Console.WriteLine("Fill your tank with gas!");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid fuel!");
                    break;
            }
        }
    }
}