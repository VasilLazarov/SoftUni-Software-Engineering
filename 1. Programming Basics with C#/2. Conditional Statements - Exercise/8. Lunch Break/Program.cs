using System;

namespace _8._Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int episodeLength = int.Parse(Console.ReadLine());
            int restLength = int.Parse(Console.ReadLine());
            double timeForMovie = restLength * 5 / 8.0;
            if(timeForMovie >= episodeLength)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(timeForMovie - episodeLength)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(episodeLength - timeForMovie)} more minutes.");
            }
        }
    }
}
