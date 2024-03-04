using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = new List<string>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputCommand = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                if(inputCommand.Length == 3)
                {
                    if (guestList.Contains(inputCommand[0]))
                    {
                        Console.WriteLine($"{inputCommand[0]} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(inputCommand[0]);
                    }
                }
                else if(inputCommand.Length == 4)
                {
                    if (guestList.Contains(inputCommand[0]))
                    {
                        guestList.Remove(inputCommand[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{inputCommand[0]} is not in the list!");
                    }
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine, guestList));
        }
    }
}
