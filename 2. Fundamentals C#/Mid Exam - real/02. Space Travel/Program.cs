using System;

namespace _02._Space_Travel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputAllCommandes = Console.ReadLine().Split("||");
            int fuel = int.Parse(Console.ReadLine());
            int ammunition = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputAllCommandes.Length; i++)
            {
                string[] inputCurrentCommand = inputAllCommandes[i].Split(" ");
                string command = inputCurrentCommand[0];
                int value = 0;
                
                if(command == "Travel")
                {
                    value = int.Parse(inputCurrentCommand[1]);
                    fuel -= value;
                    if(fuel < 0)
                    {
                        Console.WriteLine("Mission failed.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"The spaceship travelled {value} light-years.");
                    }
                }
                else if (command == "Enemy")
                {
                    value = int.Parse(inputCurrentCommand[1]);
                    if (value <= ammunition)
                    {
                        ammunition -= value;
                        Console.WriteLine($"An enemy with {value} armour is defeated.");
                    }
                    else if((value * 2) <= fuel)
                    {
                        fuel -= (value * 2);
                        Console.WriteLine($"An enemy with {value} armour is outmaneuvered.");
                    }
                    else
                    {
                        Console.WriteLine("Mission failed.");
                        return;
                    }
                }
                else if (command == "Repair")
                {
                    value = int.Parse(inputCurrentCommand[1]);
                    fuel += value;
                    ammunition += (value * 2);
                    Console.WriteLine($"Ammunitions added: {value*2}.");
                    Console.WriteLine($"Fuel added: {value}.");
                }
                else if (command == "Titan")
                {
                    Console.WriteLine($"You have reached Titan, all passengers are safe.");
                    return;
                }
            }
        }
    }
}
