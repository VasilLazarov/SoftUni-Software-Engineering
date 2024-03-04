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
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bomb)
                {
                    int startingIndex = i - range;
                    int countForRemove = i + range;
                    if (startingIndex < 0)
                    {
                        startingIndex = 0;
                    }
                    if (countForRemove >= numbers.Count)
                    {
                        countForRemove = numbers.Count - 1;
                    }
                    numbers.RemoveRange(startingIndex, countForRemove - startingIndex + 1);
                    i = -1;
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}

