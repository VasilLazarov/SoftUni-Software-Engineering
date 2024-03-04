using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<string> petrolPumps = new Queue<string>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                string pump = Console.ReadLine();
                petrolPumps.Enqueue(pump);
            }

            int startingPump = 0;
            while (true)
            {
                bool isComplete = true;
                int amountOfPetrol = 0;
                foreach (var pump in petrolPumps)
                {
                    string[] pumpParameters = pump.Split(" ");
                    amountOfPetrol += int.Parse(pumpParameters[0]);
                    int distanceToNextPump = int.Parse(pumpParameters[1]);
                    if (amountOfPetrol >= distanceToNextPump)
                    {
                        amountOfPetrol -= distanceToNextPump;
                    }
                    else
                    {
                        string currentPump = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(currentPump);
                        startingPump++;
                        isComplete = false;
                        break;
                    }
                }
                if (isComplete)
                {
                    Console.WriteLine(startingPump);
                    break;
                }
            }
        }
    }
}
