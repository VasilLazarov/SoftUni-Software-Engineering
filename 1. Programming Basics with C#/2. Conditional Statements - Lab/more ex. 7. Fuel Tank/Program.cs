using System;

namespace more_ex._7._Fuel_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine();
            double remainingLitersInTheTank = double.Parse(Console.ReadLine());
            if(remainingLitersInTheTank >= 25)
            {
                switch (typeOfFuel)
                {
                    case "Diesel":
                    case "Gasoline":
                    case "Gas":
                        Console.WriteLine($"You have enough {typeOfFuel.ToLower()}.");
                        break;
                    default:
                        Console.WriteLine("Invalid fuel!");
                        break;
                }
            }
            else if (remainingLitersInTheTank < 25)
            {
                switch (typeOfFuel)
                {
                    case "Diesel":
                    case "Gasoline":
                    case "Gas":
                        Console.WriteLine($"Fill your tank with {typeOfFuel.ToLower()}!");
                        break;
                    default:
                        Console.WriteLine("Invalid fuel!");
                        break;
                }
            }
        }
    }
}
