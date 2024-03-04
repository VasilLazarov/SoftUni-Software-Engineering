using System;

namespace _01._Experience_Gaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal neededXP = decimal.Parse(Console.ReadLine());
            int maxCountOfBattles = int.Parse(Console.ReadLine());
            decimal collectedXP = 0;
            bool successfull = false;
            int battlesCount = 0;
            for (int i = 1; i <= maxCountOfBattles; i++)
            {
                decimal currentBattleXP = decimal.Parse(Console.ReadLine());
                battlesCount = i;
                if(i % 15 == 0)
                {
                    currentBattleXP += currentBattleXP * 0.05m;
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        currentBattleXP += currentBattleXP * 0.15m;
                    }
                    else if (i % 5 == 0)
                    {
                        currentBattleXP -= currentBattleXP * 0.10m;
                    }
                }
                collectedXP += currentBattleXP;
                if (collectedXP >= neededXP)
                {
                    successfull = true;
                    break;
                }
            }
            if (successfull)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededXP - collectedXP:f2} more needed.");
            }
        }
    }
}
