using System;

namespace more_ex._7._Fuel_Tank_without_switch_case
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine();
            double remainingLitersInTheTank = double.Parse(Console.ReadLine());
            if (remainingLitersInTheTank >= 25)
            {
                if(typeOfFuel == "Diesel" || typeOfFuel == "Gasoline" || typeOfFuel == "Gas")
                {
                    Console.WriteLine($"You have enough {typeOfFuel.ToLower()}.");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
            else if(remainingLitersInTheTank < 25)
            {
                if (typeOfFuel == "Diesel" || typeOfFuel == "Gasoline" || typeOfFuel == "Gas")
                {
                    Console.WriteLine($"Fill your tank with {typeOfFuel.ToLower()}!");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }

        }
    }
}
