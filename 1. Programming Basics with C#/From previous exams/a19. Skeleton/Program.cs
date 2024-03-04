using System;

namespace a19._Skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            int secondsFor100Meters = int.Parse(Console.ReadLine());
            int goalInSeconds = minutes * 60 + seconds;
            double numOfTimeReductions = length / 120.0;
            double secondsReduction = numOfTimeReductions * 2.5;
            double ourRecord = (length / 100.0) * secondsFor100Meters - secondsReduction;
            if(ourRecord <= goalInSeconds)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {ourRecord:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {ourRecord - goalInSeconds:f3} second slower.");
            }
        }
    }
}
