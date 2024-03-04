using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothes = new Stack<int>(input);

            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = rackCapacity;
            int countOfRacks = 1;
            while (clothes.Any())
            {
                currentRackCapacity -= clothes.Peek();
                if(currentRackCapacity >= 0)
                {
                    clothes.Pop();
                }
                else
                {
                    countOfRacks++;
                    currentRackCapacity = rackCapacity;
                }
            }
            Console.WriteLine(countOfRacks);
        }
    }
}
