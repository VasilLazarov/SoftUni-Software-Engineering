using System;

namespace a18._Football_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resultFromMatch1 = Console.ReadLine();
            string resultFromMatch2 = Console.ReadLine();
            string resultFromMatch3 = Console.ReadLine();
            int wins = 0;
            int loses = 0;
            int draws = 0;
            if(resultFromMatch1[0] > resultFromMatch1[2])
            {
                wins++;
            }
            else if(resultFromMatch1[0] == resultFromMatch1[2])
            {
                draws++;
            }
            else
            {
                loses++;
            }

            if (resultFromMatch2[0] > resultFromMatch2[2])
            {
                wins++;
            }
            else if (resultFromMatch2[0] == resultFromMatch2[2])
            {
                draws++;
            }
            else
            {
                loses++;
            }

            if (resultFromMatch3[0] > resultFromMatch3[2])
            {
                wins++;
            }
            else if (resultFromMatch3[0] == resultFromMatch3[2])
            {
                draws++;
            }
            else
            {
                loses++;
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}
