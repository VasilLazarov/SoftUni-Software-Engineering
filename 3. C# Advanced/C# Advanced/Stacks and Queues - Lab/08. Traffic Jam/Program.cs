using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsPassOnGreen = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();
            int carsPassed = 0;
            while(input != "end")
            {
                if(input == "green")
                {
                    for (int i = 1; i <= carsPassOnGreen; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        carsPassed++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
