using System;

namespace more_ex._2._Sleepy_Tom_Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDaysOff = int.Parse(Console.ReadLine());
            int daysOfTheYear = 365;
            int normalPlayTimePerYear = 30000;
            int playTime = (numberOfDaysOff * 127) + ((daysOfTheYear - numberOfDaysOff) * 63);
            int difference = Math.Abs(normalPlayTimePerYear - playTime);
            int hours = difference / 60;
            int minutes = difference % 60;

            if (playTime > normalPlayTimePerYear)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else if(playTime <= normalPlayTimePerYear)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
        }
    }
}
