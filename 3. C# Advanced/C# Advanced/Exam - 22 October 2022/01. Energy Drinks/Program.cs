using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeins = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            int maxCaffein = 300;
            int stamatCaffein = 0;

            while (caffeins.Count != 0 && energyDrinks.Count != 0)
            {
                int currMiligramsCaffein = caffeins.Pop();
                int currDrink = energyDrinks.Dequeue();
                int currentCaffein = currMiligramsCaffein * currDrink;
                if(currentCaffein <= maxCaffein)
                {
                    stamatCaffein += currentCaffein;
                    maxCaffein -= currentCaffein;
                }
                else
                {
                    energyDrinks.Enqueue(currDrink);
                    if(stamatCaffein >= 30)
                    {
                        stamatCaffein -= 30;
                        maxCaffein += 30;
                    }
                    else
                    {
                        stamatCaffein = 0;
                    }
                }
            }
            if(energyDrinks.Count == 0)
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }
            else
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            Console.WriteLine($"Stamat is going to sleep with {stamatCaffein} mg caffeine.");
        }
    }
}
