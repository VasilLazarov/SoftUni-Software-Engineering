using System;

namespace _4._Workout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double kilometers = double.Parse(Console.ReadLine());
            int percentage = 0;
            double totalKilometers = kilometers;
            double percN = 0;
            for(int i = 1; i <= days; i++)
            {
                percentage = int.Parse(Console.ReadLine());
                percN = 1 + (percentage / 100.0);
                kilometers *= percN;
                totalKilometers += kilometers;
            }
            if(totalKilometers >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalKilometers - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - totalKilometers)} more kilometers");
            }
        }
    }
}
