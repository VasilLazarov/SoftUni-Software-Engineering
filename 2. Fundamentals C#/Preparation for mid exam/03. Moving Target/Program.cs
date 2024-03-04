using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputElements = input.Split();
                string command = inputElements[0];
                int index = int.Parse(inputElements[1]);
                int value = int.Parse(inputElements[2]);
                if(command == "Shoot")
                {
                    ShootCommand(targets, index, value);
                }
                else if(command == "Add")
                {
                    AddCommand(targets, index, value);
                }
                else if(command == "Strike")
                {
                    StrikeCommand(targets, index, value);
                }
            }
            Console.WriteLine(String.Join("|", targets));
        }
        static void ShootCommand(List<int> targets, int index, int value)
        {
            if(index >= 0 && index < targets.Count)
            {
                targets[index] -= value;
                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
        }
        static void AddCommand(List<int> targets, int index, int value)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }
        static void StrikeCommand(List<int> targets, int index, int value)
        {
            int startIndex = index - value;
            int endIndex = index + value;
            int countElementsForRemove = value * 2 + 1;
            if(startIndex >= 0 && endIndex < targets.Count)
            {
                targets.RemoveRange(startIndex, countElementsForRemove);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }
}
