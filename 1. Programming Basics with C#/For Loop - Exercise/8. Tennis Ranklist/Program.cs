using System;

namespace _8._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfTours = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int points = 0;
            int totalPoints = 0;
            int win = 0;
            for(int i = 0; i < numOfTours; i++)
            {
                string stage = Console.ReadLine();
                switch (stage)
                {
                    case "W":
                        points += 2000;
                        win++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }
            double averagePoints = points / numOfTours;
            double perWinTours = (double)win / numOfTours * 100;
            totalPoints = points + startingPoints;
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{perWinTours:f2}%");
        }
    }
}
