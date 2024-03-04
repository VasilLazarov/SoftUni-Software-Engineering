using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int i = 0;
            while (true)
            {
                
                if (firstPlayer[i] > secondPlayer[i])
                {
                    firstPlayer.Add(secondPlayer[i]);
                    int movedCard = firstPlayer[i];
                    firstPlayer.RemoveAt(i);
                    firstPlayer.Add(movedCard);
                    secondPlayer.RemoveAt(i);
                }
                else if (firstPlayer[i] < secondPlayer[i])
                {
                    secondPlayer.Add(firstPlayer[i]);
                    int movedCard = secondPlayer[i];
                    secondPlayer.RemoveAt(i);
                    secondPlayer.Add(movedCard);
                    firstPlayer.RemoveAt(i);
                }
                else if (firstPlayer[i] == secondPlayer[i])
                {
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                }
                if(firstPlayer.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
                    break;
                }
                else if(secondPlayer.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
                    break;
                }
            }

        }
    }
}
