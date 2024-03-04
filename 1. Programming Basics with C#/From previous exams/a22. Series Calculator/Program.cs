using System;

namespace a22._Series_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serialName = Console.ReadLine();
            int numOfSeasons = int.Parse(Console.ReadLine());
            int numOfEpisodes = int.Parse(Console.ReadLine());
            double timeForOneEpisodeWithoutAds = double.Parse(Console.ReadLine());
            double fullTimeForOneEpisode = timeForOneEpisodeWithoutAds + timeForOneEpisodeWithoutAds * 0.20;
            double bonusTimeForLastEpisodeOnEverySeason = numOfSeasons * 10;
            double fullTimeForWarchingSerial = fullTimeForOneEpisode * numOfSeasons * numOfEpisodes + bonusTimeForLastEpisodeOnEverySeason;
            Console.WriteLine($"Total time needed to watch the {serialName} series is {Math.Floor(fullTimeForWarchingSerial)} minutes.");

        }
    }
}
