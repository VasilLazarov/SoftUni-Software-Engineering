using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());
            string input = string.Empty;
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split();
                string command = inputs[0];
                if(command == "Add")
                {
                    int passengers = int.Parse(inputs[1]);
                    listOfWagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(inputs[0]);
                    FindWagonForPassengers(listOfWagons, passengers, maxCapacityOfWagon);
                }
            }
            Console.WriteLine(String.Join(" ", listOfWagons));
        }
        static void FindWagonForPassengers(List<int> listOfWagons, int passengers, int maxCapacityOfWagon)
        {
            for (int i = 0; i < listOfWagons.Count; i++)
            {
                if (listOfWagons[i] + passengers <= maxCapacityOfWagon)
                {
                    listOfWagons[i] += passengers;
                    break;
                }
            }
        }
    }
}
