using System;

namespace a24._Movie_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeForPhotos = int.Parse(Console.ReadLine());
            int numOfScenes = int.Parse(Console.ReadLine());
            int timeForScene = int.Parse(Console.ReadLine());
            double necessaryTime = numOfScenes * timeForScene + timeForPhotos * 0.15;
            if(timeForPhotos > necessaryTime)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeForPhotos - necessaryTime)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(necessaryTime - timeForPhotos)} minutes.");
            }
        }
    }
}
