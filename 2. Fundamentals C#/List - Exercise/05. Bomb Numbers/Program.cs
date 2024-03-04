using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            //int index = 5;
            //int range = 2;
            //numbers.RemoveRange(index - range, 2*range + 1);

            int[] bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int bomb = bombAndPower[0];
            int range = bombAndPower[1];
            int countOfElementsForRemove = 2 * range + 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                int startingIndex = 0;
                int finalIndex = 0;
                int changedcount = countOfElementsForRemove;
                if (numbers[i] == bomb)
                {
                    startingIndex = i - range;
                    finalIndex = startingIndex + countOfElementsForRemove;
                    if (startingIndex < 0)
                    {
                        changedcount += startingIndex;
                        startingIndex = 0;
                    }
                    if(finalIndex >= numbers.Count)
                    {
                        changedcount += (numbers.Count - finalIndex);
                        finalIndex = numbers.Count - 1;
                    }
                    numbers.RemoveRange(startingIndex, changedcount);
                    i = -1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
