using System;

namespace more_ex._5._Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int foodLeftKg = int.Parse(Console.ReadLine());   
            double dogFoodKgPerDay = double.Parse(Console.ReadLine());
            double catFoodKgPerDay = double.Parse(Console.ReadLine());
            double turtleFoodKgPerDay = double.Parse(Console.ReadLine());
            double necessaryFood = (dogFoodKgPerDay + catFoodKgPerDay + (turtleFoodKgPerDay/1000)) * numberOfDays;
            if(foodLeftKg >= necessaryFood)
            {
                double residueFood = foodLeftKg - necessaryFood;
                Console.WriteLine($"{Math.Floor(residueFood)} kilos of food left.");
            }
            else if(foodLeftKg < necessaryFood)
            {
                double notEnoughFood = Math.Abs(foodLeftKg - necessaryFood);
                Console.WriteLine($"{Math.Ceiling(notEnoughFood)} more kilos of food are needed.");
            }
        }
    }
}
