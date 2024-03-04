using System;

namespace _4._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = 0;
            string steps = "";
            while(totalSteps < 10000)
            {
                steps = Console.ReadLine();
                if(steps == "Going home")
                {
                    totalSteps += int.Parse(Console.ReadLine());
                    if(totalSteps < 10000)
                    {
                        Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
                    }
                    else
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
                    }
                    return;
                }
                else
                {
                    totalSteps += int.Parse(steps);
                }
            }
            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
        }
    }
}
