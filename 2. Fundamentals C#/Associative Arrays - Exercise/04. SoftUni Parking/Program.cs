using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingUsers 
                = new Dictionary<string, string>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ");
                string command = input[0];
                string username = input[1];
                
                if(command == "register")
                {
                    string licensePlateNumber = input[2];
                    if (!parkingUsers.ContainsKey(username))
                    {
                        parkingUsers.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingUsers[username]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (parkingUsers.ContainsKey(username))
                    {
                        parkingUsers.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }
            foreach (var user in parkingUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
