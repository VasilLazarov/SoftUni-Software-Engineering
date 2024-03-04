using System;
using System.Collections.Generic;
using System.Reflection;

namespace _03._Wild_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> animalsInAreas = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "EndDay")
            {
                string[] inputElements = input.Split(':', '-', ' ');
                string command = inputElements[0];
                string animalName = inputElements[2];
                if (command == "Add")
                {
                    int neededFood = int.Parse(inputElements[3]);
                    string area = inputElements[4];
                    if (!animalsInAreas.ContainsKey(area))
                    {
                        animalsInAreas.Add(area, new Dictionary<string, int>());
                    }
                    bool existingAnimal = false;
                    foreach (var item in animalsInAreas)
                    {
                        foreach (var any in item.Value)
                        {
                            if (any.Key == animalName)
                            {
                                existingAnimal = true;
                            }
                        }
                    }
                    if (!existingAnimal)
                    {
                        animalsInAreas[area].Add(animalName, neededFood);
                    }
                    else
                    {
                        animalsInAreas[area][animalName] += neededFood;
                    }
                }
                else if (command == "Feed")
                {
                    int givenFood = int.Parse(inputElements[3]);
                    bool existingAnimal = false;
                    string currentArea = string.Empty;
                    foreach (var item in animalsInAreas)
                    {
                        foreach (var any in item.Value)
                        {
                            if (any.Key == animalName)
                            {
                                currentArea = item.Key;
                                existingAnimal = true;
                            }
                        }
                    }
                    if (existingAnimal)
                    {
                        animalsInAreas[currentArea][animalName] -= givenFood;
                        if(animalsInAreas[currentArea][animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            animalsInAreas[currentArea].Remove(animalName);
                            if(animalsInAreas[currentArea].Count == 0)
                            {
                                animalsInAreas.Remove(currentArea);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            Console.WriteLine("Animals:");
            foreach (var item in animalsInAreas)
            {
                foreach (var animall in item.Value)
                {
                    Console.WriteLine($"{animall.Key} -> {animall.Value}g");
                }
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in animalsInAreas)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
            }
        }
    }
}
